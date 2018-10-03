<%@ Application Language="VB" %>

<script runat="server">

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Code that runs on application shutdown
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    Try
      SIS.SYS.Utilities.SessionManager.CreateSessionEnvironement()
    Catch ex As Exception
    End Try
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    Try
      SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
    Catch ex As Exception
    End Try
  End Sub

  Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
  End Sub
</script>