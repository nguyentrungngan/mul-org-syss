' Models/RequestTemplate.vb
Public Class RequestTemplate
    Public Property TemplateID As Integer
    Public Property RequestType As String
    Public Property CreatorID As Integer
    Public Property ApprovalStatus As String
    Public Property ApproverID As Integer?
    Public Property ApprovedAt As DateTime?
End Class