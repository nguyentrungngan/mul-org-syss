Imports PrintTemplateWinapp.Models
Imports System.Data.SqlClient

Public Class Database
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Public Shared Function GetUserByUsername(username As String) As User
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            ' Query to fetch user by username
            Dim query As String = "SELECT * FROM Users WHERE Username = @Username"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Username", username)
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                Return New User() With {
                    .UserID = reader.GetInt32(0),
                    .Username = reader.GetString(1),
                    .Role = reader.GetString(3),
                    .BranchID = reader.GetInt32(4)
                }
            End If
        End Using
        Return Nothing
    End Function

    ' Similar methods for CreateRequestTemplate, GetRequestTemplates, ApproveRequestTemplate

    'Public Shared CreateRequestTemplate
    'Public Shared GetRequestTemplates
    'Public Shared ApproveRequestTemplate
End Class
