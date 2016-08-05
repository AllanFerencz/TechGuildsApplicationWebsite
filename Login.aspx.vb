
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnSubmitLogin_Click(sender As Object, e As EventArgs) Handles btnSubmitLogin.Click

        Dim UserSalt As String = ""
        Dim UserAuthentication As Integer = -1


        If txtUserNameLogin.Text = "" Then
            lblMessage.Text = "Must enter an email"
        ElseIf txtPasswordLogin.Text = "" Then
            lblMessage.Text = "Must enter a name"
        Else

            UserSalt = DBL.Tables.Users.getUserSalt(txtUserNameLogin.Text)



            If Not UserSalt = "" Then

                Dim UserHashedPassword = DBL.Tables.Users.hashPassword(txtPasswordLogin.Text, UserSalt)

                UserAuthentication = DBL.Tables.Users.SelectUser(txtUserNameLogin.Text, UserHashedPassword)


                If UserAuthentication = -1 Then
                    lblMessage.Text = "Incorrect Password"
                Else

                    Session("username") = txtUserNameLogin.Text
                    Session("LoginRole") = UserAuthentication

                    If UserAuthentication = 0 Then
                        Session("SiteMessage") = "Successfully Logged in!"
                        Session("SiteMessageType") = "Success"
                        Response.Redirect("~/Welcome.aspx")
                    Else
                        Response.Redirect("~/Account/BackOfficeSubscriptions.aspx")
                    End If
                End If
            Else
                lblMessage.Text = "Incorrect Password"
            End If
        End If
    End Sub


End Class
