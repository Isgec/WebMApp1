Imports System.Web.Script.Serialization
Partial Class GF_wfDBIcons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/WF_Main/App_Display/DF_wfDBIcons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DBIconID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVwfDBIcons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfDBIcons.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DBIconID As Int32 = GVwfDBIcons.DataKeys(e.CommandArgument).Values("DBIconID")  
        Dim RedirectUrl As String = TBLwfDBIcons.EditUrl & "?DBIconID=" & DBIconID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Copywf".ToLower Then
      Try
        Dim DBIconID As Int32 = GVwfDBIcons.DataKeys(e.CommandArgument).Values("DBIconID")  
        SIS.WF.wfDBIcons.CopyWF(DBIconID)
        GVwfDBIcons.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim DBIconID As Int32 = GVwfDBIcons.DataKeys(e.CommandArgument).Values("DBIconID")  
        SIS.WF.wfDBIcons.DeleteWF(DBIconID)
        GVwfDBIcons.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfDBIcons.Init
    DataClassName = "GwfDBIcons"
    SetGridView = GVwfDBIcons
  End Sub
  Protected Sub TBLwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBIcons.Init
    SetToolBar = TBLwfDBIcons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
