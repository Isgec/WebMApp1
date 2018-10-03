
Partial Class ErrorPage
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Me.LabelError.Text = Session("myError")
	End Sub
End Class
