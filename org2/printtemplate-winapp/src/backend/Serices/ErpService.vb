' Services/ERPService.vb
Imports PrintTemplateWinapp.Models
Public Class ERPService
    Private ReadOnly _erpBaseUrl As String = ConfigurationManager.AppSettings("ERPSystem:BaseUrl")

    Public Function GetERPItems() As List(Of ERPItem)
        ' Call ERP system's API and retrieve item list
        ' Example HTTP GET request
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = client.GetAsync($"{_erpBaseUrl}/items").Result
            If response.IsSuccessStatusCode Then
                Dim result As String = response.Content.ReadAsStringAsync().Result
                ' Parse result and return ERP items
                Return JsonConvert.DeserializeObject(Of List(Of ERPItem))(result)
            End If
        End Using
        Return New List(Of ERPItem)()
    End Function
End Class

