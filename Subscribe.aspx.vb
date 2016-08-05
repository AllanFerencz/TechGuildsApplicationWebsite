Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail

Partial Class Subscribe
    Inherits System.Web.UI.Page

    Protected Sub btnSubmitSubscribe_Click(sender As Object, e As EventArgs) Handles btnSubmitSubscribe.Click


        
        If txtName.Text = "" Then
            lblMessage.Text = "Must enter a name!"
        ElseIf txtAge.Text = "" Then
            lblMessage.Text = "Must enter an age!"
        ElseIf IsNumeric(txtAge.Text) = False Then
            lblMessage.Text = "Age must be a number!"
        ElseIf txtEmail.Text = "" Then
            lblMessage.Text = "Must enter an email!"
        Else

            Try
                Dim mailTester As MailAddress = New MailAddress(txtEmail.Text)
            Catch ex As Exception
                lblMessage.Text = "The Email Address Error: Make sure your email addresses is properly formated!"
                Exit Sub
            End Try


            If DBL.Tables.Subscriptions.SelectSubscription(txtEmail.Text) Then
                Session("SiteMessageType") = "Success"
                Session("SiteMessage") = DBL.Tables.Subscriptions.InsertSubscription(txtName.Text, txtAge.Text, txtEmail.Text)
                Response.Redirect("~/Subscribe.aspx")
            Else
                lblMessage.Text = "That email address is already in our system"
            End If


        End If
    End Sub
End Class
