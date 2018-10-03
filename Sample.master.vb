Imports System.Web.Services
Imports System.IO
Partial Class lgSample
  Inherits System.Web.UI.MasterPage

  Private Sub lgSample_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Page.User.Identity.IsAuthenticated Then
    End If
  End Sub
End Class

