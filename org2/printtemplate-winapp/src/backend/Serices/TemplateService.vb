' Services/TemplateService.vb
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports PrintTemplateWinapp.Models
Imports PrintTemplateWinapp.Database

Public Class TemplateService
    Public Function CreateTemplate(newTemplate As RequestTemplate) As RequestTemplate
        ' Insert new template into the database
        Return Database.CreateRequestTemplate(newTemplate)
    End Function

    Public Function GetTemplates() As List(Of RequestTemplate)
        ' Retrieve all templates from the database
        Return Database.GetRequestTemplates()
    End Function

    Public Function ApproveTemplate(templateID As Integer, approvalDetails As ApprovalDetails) As Boolean
        ' Update approval status in the database
        Return Database.ApproveRequestTemplate(templateID, approvalDetails)
    End Function
End Class