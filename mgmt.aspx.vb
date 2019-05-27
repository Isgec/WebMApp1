Partial Class lgmgmt
  Inherits System.Web.UI.Page

  Private Sub lgIos_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Response.Redirect("~/mDefault.aspx?userid=mgmt")
  End Sub
End Class
