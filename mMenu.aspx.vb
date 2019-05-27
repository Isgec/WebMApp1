Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Security.Principal
Imports System.Security
Partial Class mLGMenu
  Inherits System.Web.UI.Page
  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      '======This Page is opened when Back Button is pressed, user not logged out from  Application Launched from App Icon.=====
      '======As Application ID gets changed================
      'To Re-instate Environment do re-login in background
      '========Un-comment Following Code==================
      'If HttpContext.Current.Session("ApplicationID").ToString <> "30" Then
      '  Dim RedirectURL As String = HttpContext.Current.Session("LastURL")
      '  HttpContext.Current.Session.Clear()
      '  If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
      '    RedirectURL = RedirectURL.Replace("mMenu", "mDefault")
      '    RedirectURL &= "?UserID=" & UserID
      '    Response.Redirect(RedirectURL)
      '  End If
      'End If
      '===============End of Uncomment=====================
      Me.appIcons.Visible = True
      ShowAppIcons(UserID)
    Else
      authFailed.Visible = True
    End If
  End Sub

  Private Sub ShowAppIcons(ByVal UserID As String)
    Dim maxR As Integer = 1
    Dim R As Integer = 0
    Dim sb As New StringBuilder
    Dim tmpAs As List(Of SIS.MAPP.mappUserApps) = SIS.MAPP.mappUserApps.UZ_mappUserAppsSelectList(0, 999, "", False, "", 0, UserID)
    If tmpAs.Count > 0 Then
      For Each tmpA As SIS.MAPP.mappUserApps In tmpAs
        R += 1
        sb.Append("<div style='width:100px;display:inline-block;'>")
        Dim tmpL As SIS.MAPP.mappApplications = tmpA.FK_MAPP_UserApps_ApplID
        Dim tmpI As SIS.WF.wfDBIcons = tmpL.FK_MAPP_Applications_ApplIconID
        Dim tmpUrl As String = tmpL.MainPageURL
        Dim tmpAuthority As String = Request.Url.Authority
        If tmpUrl.StartsWith("@NoLocalHost", StringComparison.OrdinalIgnoreCase) Then
          tmpUrl = tmpUrl.Replace("@NoLocalHost", "")
          If tmpAuthority.ToLower = "localhost" Then
            tmpAuthority = "192.9.200.146"
          End If
        End If
        Dim FinalURL As String = Request.Url.Scheme & Uri.SchemeDelimiter & tmpAuthority
        If tmpUrl.StartsWith("/") Then
          FinalURL &= Request.ApplicationPath
          FinalURL &= tmpUrl
        Else
          FinalURL &= "/"
          FinalURL &= tmpUrl
        End If
        FinalURL &= "?LoginID=" & HttpContext.Current.Session("LoginID")
        sb.Append("<a href='" & FinalURL & "' class='list-group-item' title='" & tmpL.ApplicationName & "' style='border:none;'><i class='" & tmpI.IconName & "' style='" & tmpL.AppIconStyle & "' ></i><br/>" & tmpL.ApplicationName & "</a>")
        sb.Append("</div>")
      Next
      sb.Append("</div>")
    End If
    appIcons.InnerHtml = sb.ToString
  End Sub
End Class
