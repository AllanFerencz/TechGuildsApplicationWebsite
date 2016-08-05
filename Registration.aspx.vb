
Partial Class Registration
    Inherits System.Web.UI.Page

    Protected Sub btnSubmitRegistration_Click(sender As Object, e As EventArgs) Handles btnSubmitRegistration.Click

        Dim authentication As Integer = 0

        If txtConfirmPasswordRegistration.Text = "" Then
            lblMessage.Text = "Must enter an Confirm Password"
        ElseIf txtPasswordRegistration.Text = "" Then
            lblMessage.Text = "Must enter a Password"
        ElseIf txtUserName.Text = "" Then
            lblMessage.Text = "Must enter an UserName"
        ElseIf Not txtPasswordRegistration.Text = txtConfirmPasswordRegistration.Text Then
            lblMessage.Text = "Confirm Password doesn't match"
        Else

            Dim UserSalt = DBL.Tables.Users.createSalt()
            Dim UserHashedPassword = DBL.Tables.Users.hashPassword(txtPasswordRegistration.Text, UserSalt)


            If chkAdmin.Checked = True Then
                authentication = 1
            End If

            If DBL.Tables.Users.SelectUniqueUser(txtUserName.Text) Then

                Session("SiteMessageType") = "Success"
                Session("SiteMessage") = DBL.Tables.Users.InsertUser(txtUserName.Text, UserHashedPassword, UserSalt, authentication)
                Response.Redirect("~/Login.aspx")
            Else
                lblMessage.Text = "Must pick a unique username"
            End If
        End If
    End Sub

End Class
