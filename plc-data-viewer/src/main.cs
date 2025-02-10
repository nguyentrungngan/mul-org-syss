using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Timers;

class Program
{
    private static string connectionString;
    private static int refreshInterval;

    static void Main()
    {
        LoadConfig();
        Timer timer = new Timer(refreshInterval * 1000);
        timer.Elapsed += FetchAndDisplayData;
        timer.Start();

        Console.WriteLine("PLC Data Viewer started. Press Enter to exit.");
        // do new feature here




        //
        Console.ReadLine();
    }

    static void LoadConfig()
    {
        try
        {
            var config = System.IO.File.ReadAllText("config.json");
            dynamic jsonConfig = Newtonsoft.Json.JsonConvert.DeserializeObject(config);
            connectionString = $"Server={jsonConfig.database.host},{jsonConfig.database.port};" +
                               $"Database={jsonConfig.database.database_name};" +
                               $"User Id={jsonConfig.database.username};" +
                               $"Password={jsonConfig.database.password};";
            refreshInterval = jsonConfig.viewer_settings.refresh_interval;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading config: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void FetchAndDisplayData(object sender, ElapsedEventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 10 * FROM plc_data ORDER BY timestamp DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.Clear();
                Console.WriteLine("Latest PLC Data:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["id"]}: {reader["value"]} at {reader["timestamp"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
    }
}
