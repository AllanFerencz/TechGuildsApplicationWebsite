
Partial Class BackOfficeSubscriptions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Session("LoginRole") = 1 Then
            Response.Redirect("~/Login.aspx")
        End If



    End Sub

End Class
