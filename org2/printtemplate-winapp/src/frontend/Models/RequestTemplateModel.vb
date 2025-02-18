Public Class RequestTemplateModel
    Public Property TemplateID As Integer
    Public Property RequestType As String
    Public Property CreatorID As Integer
    Public Property Items As List(Of RequestItem)
    Public Property ApprovalStatus As String
    Public Property CreatedAt As DateTime
End Class

Public Class RequestItem
    Public Propterty ItemCode as String
    Public Property Description As String
    Public Property Quantity As Integer
End Class
