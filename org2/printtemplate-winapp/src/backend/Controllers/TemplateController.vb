' Controllers/TemplateController.vb
Imports System.Web.Http
Imports PrintTemplateWinapp.Services

Public Class TemplateController
    Inherits ApiController

    Private ReadOnly _templateService As TemplateService

    Public Sub New()
        _templateService = New TemplateService()
    End Sub

    ' POST /templates
    Public Function CreateTemplate(<FromBody> newTemplate As RequestTemplate) As IHttpActionResult
        Dim createdTemplate = _templateService.CreateTemplate(newTemplate)
        Return Ok(createdTemplate)
    End Function

    ' GET /templates
    Public Function GetTemplates() As IHttpActionResult
        Dim templates = _templateService.GetTemplates()
        Return Ok(templates)
    End Function

    ' PUT /templates/{templateID}/approve
    Public Function ApproveTemplate(templateID As Integer, <FromBody> approvalDetails As ApprovalDetails) As IHttpActionResult
        Dim result = _templateService.ApproveTemplate(templateID, approvalDetails)
        If result Then
            Return Ok(New With {.message = "Request approved successfully"})
        End If
        Return BadRequest("Failed to approve request")
    End Function
End Class