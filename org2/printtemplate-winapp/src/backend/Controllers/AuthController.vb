' Controllers/AuthController.vb
Imports System.Web.Http
Imports PrintTemplateWinapp.Services

Public Class AuthController
    Inherits ApiController

    Private ReadOnly _authService As AuthService

    Public Sub New()
        _authService = New AuthService()
    End Sub

    ' POST /login
    Public Function Login(<FromBody> userCredentials As UserCredentials) As IHttpActionResult
        Dim token = _authService.Login(userCredentials.Username, userCredentials.Password)
        If String.IsNullOrEmpty(token) Then
            Return Unauthorized()
        End If
        Return Ok(New With {.token = token})
    End Function

    ' GET /me
    Public Function GetCurrentUser() As IHttpActionResult
        Dim currentUser = _authService.GetCurrentUser()
        If currentUser Is Nothing Then
            Return Unauthorized()
        End If
        Return Ok(currentUser)
    End Function
End Class