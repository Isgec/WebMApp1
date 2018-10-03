Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Security.Principal
Imports System.Security
Partial Class mLGConfig
  Inherits System.Web.UI.Page
  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Not Page.User.Identity.IsAuthenticated Then
      Me.authFailed.Visible = True
    End If
  End Sub
  Private Function showData() As String
    Dim str As String = ""
    Try
      str &= "Device ID :  " & Request.QueryString("DeviceID") & "<br/>"
      str &= "Longitude :  " & Request.QueryString("lon") & "<br/>"
      str &= "Latitude  :  " & Request.QueryString("lat") & "<br/>"
      str &= "Altitude  :  " & Request.QueryString("alt") & "<br/>"
      str &= "Place     :  " & Request.QueryString("pla") & "<br/>"
      str &= "Error     :  " & Request.QueryString("err") & "<br/>"
    Catch ex As Exception
    End Try
    celldata.InnerHtml = str
    Return str
  End Function
End Class
