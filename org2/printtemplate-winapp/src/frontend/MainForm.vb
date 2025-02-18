Public Class MainForm
    Private controller As APIController

    Public Sub New()
        InitializeComponent()
        controller = New APIController()
    End Sub

    ' login event
    Private Async Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim result As String = Await controller.Login(TxtUsername.Text, TxtPassword.Text)
        MessageBox.Show(result)
        ' Check and show functions if valid credentials
        '
        '
        '
    End Sub

    ' user info event
    Private Async Sub BtnGetUser_Click(sender As Object, e As EventArgs) Handles BtnGetUser.Click
        Dim user As UserModel = Await controller.GetCurrentUser()
        If user IsNot Nothing Then
            TxtUserInfo.Text = $"Username: {user.Username}, Role: {user.Role}"
            'stores local session
            '
            '
        Else
            MessageBox.Show("Failed to get user details.")
            '
            '
            '
        End If
    End Sub

    ' template request event
    Private Async Sub BtnGetTemplates_Click(sender As Object, e As EventArgs) Handles BtnGetTemplates.Click
        Dim templates As List(Of RequestTemplateModel) = Await controller.GetRequestTemplates()
        If templates IsNot Nothing Then
            For Each template As RequestTemplateModel In templates
                ListBoxTemplates.Items.Add($"TemplateID: {template.TemplateID}, Type: {template.RequestType}, Status: {template.ApprovalStatus}")
            Next
        Else
            MessageBox.Show("Failed to get templates.")
            '
            '
            '
        End If
    End Sub
End Class
