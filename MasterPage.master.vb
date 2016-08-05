

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblSiteMessage.InnerHtml = ""

        If Session("SiteMessage") IsNot Nothing Then

            lblSiteMessage.InnerHtml = Session("SiteMessage")
            'lblSiteMessage.Visible = True
            Session.Remove("SiteMessage")

            If Session("SiteMessageType") = "Success" Then
                lblSiteMessage.Attributes.Add("class", "alert text-center alert-success")
            Else
                lblSiteMessage.Attributes.Add("class", "alert text-center alert-danger")
            End If

        Else

            'lblSiteMessage.Visible = False

        End If

    End Sub
End Class

