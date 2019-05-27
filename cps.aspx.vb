Partial Class lgcps
  Inherits System.Web.UI.Page

  Private Sub lgIos_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Response.Redirect("~/mDefault.aspx?userid=5173")
  End Sub
End Class
