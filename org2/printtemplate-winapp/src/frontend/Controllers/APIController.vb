Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports PrintTemplate_Winapp.Models

Public Class APIController
    Private client As HttpClient
    Private token As String
    Private apiUrl As String
    Private authUrl As String
    Private templateUrl As String
    Private userUrl as String

    Public Sub New()
        client = New HttpClient()
        ' get urls from environment system
        apiUrl = Environment.GetEnvironmentVariable("BASE_URL")
        authUrl = Environment.GetEnvironmentVariable("AUTH_URL")
        templateUrl = Environment.GetEnvironmentVariable("TEMPLATE_URL")
        templateUrl = Environment.GetEnvironmentVariable("ME_URL")

        ' if not exists then default value
        If String.IsNullOrEmpty(apiUrl) Then
            apiUrl = "https://your-default-api-url.com"
        End If
    End Sub

    ' /Login
    Public Async Function Login(username As String, password As String) As Task(Of String)
        Dim loginData As New With {
            Key .username = username,
            Key .password = password
        }
        Dim content As New StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json")

        Dim response = Await client.PostAsync($"{apiUrl}/{authUrl}", content)
        If response.IsSuccessStatusCode Then
            Dim responseBody As String = Await response.Content.ReadAsStringAsync()
            ' token from server
            Dim result = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(responseBody)
            token = result("token")
            ' then stores token on local path
            Return "Login successful"
        End If
        Return "Login failed"
    End Function

    ' user information
    Public Async Function GetCurrentUser() As Task(Of UserModel)
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

        Dim response = Await client.GetAsync(userUrl)
        If response.IsSuccessStatusCode Then
            Dim responseBody As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of UserModel)(responseBody)
        End If
        Return Nothing
    End Function

    ' request templates
    Public Async Function GetRequestTemplates() As Task(Of List(Of RequestTemplateModel))
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

        Dim response = Await client.GetAsync($"apiUrl/templatesUrl")
        If response.IsSuccessStatusCode Then
            Dim responseBody As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of List(Of RequestTemplateModel))(responseBody)
        End If
        Return Nothing
    End Function
End Class
