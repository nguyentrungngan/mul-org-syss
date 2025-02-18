' Services/AuthService.vb
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports PrintTemplateWinapp.Models
Imports PrintTemplateWinapp.Database

Public Class AuthService
    Public Function Login(username As String, password As String) As String
        ' Validate credentials and return JWT token if valid
        Dim user = Database.GetUserByUsername(username)
        If user IsNot Nothing AndAlso user.PasswordHash = password Then
            Dim token As String = GenerateJwtToken(user)
            Return token
        End If
        Return String.Empty
    End Function

    Private Function GenerateJwtToken(user As User) As String
        ' Generate JWT token logic
        Dim claims As New List(Of Claim) From {
            New Claim(ClaimTypes.Name, user.Username),
            New Claim(ClaimTypes.Role, user.Role)
        }
        Dim key = New SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
        Dim creds = New SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        Dim token As New JwtSecurityToken(
            issuer:="yourdomain.com",
            audience:="yourdomain.com",
            claims:=claims,
            expires:=DateTime.Now.AddHours(1),
            signingCredentials:=creds
        )
        Return New JwtSecurityTokenHandler().WriteToken(token)
    End Function

    Public Function GetCurrentUser() As User
        ' Logic to fetch current logged-in user details
        Return Database.GetCurrentUser()
    End Function
End Class
