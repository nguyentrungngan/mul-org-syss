using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ERPReportGenerator
{
    static class Program
    {
        public static dynamic Config;

        [STAThread]
        static void Main()
        {
            LoadConfig();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void LoadConfig()
        {
            string configPath = "config.json";
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Configuration file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            try
            {
                string json = File.ReadAllText(configPath);
                Config = JObject.Parse(json);
                //

                // make new features here




                //
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading config.json: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
