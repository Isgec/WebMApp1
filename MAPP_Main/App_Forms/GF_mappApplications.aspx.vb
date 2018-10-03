Imports System.Web.Script.Serialization
Partial Class GF_mappApplications
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/MAPP_Main/App_Display/DF_mappApplications.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?AppID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVmappApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVmappApplications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim AppID As Int32 = GVmappApplications.DataKeys(e.CommandArgument).Values("AppID")  
        Dim RedirectUrl As String = TBLmappApplications.EditUrl & "?AppID=" & AppID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim AppID As Int32 = GVmappApplications.DataKeys(e.CommandArgument).Values("AppID")  
        SIS.MAPP.mappApplications.DeleteWF(AppID)
        GVmappApplications.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVmappApplications.Init
    DataClassName = "GmappApplications"
    SetGridView = GVmappApplications
  End Sub
  Protected Sub TBLmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappApplications.Init
    SetToolBar = TBLmappApplications
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
