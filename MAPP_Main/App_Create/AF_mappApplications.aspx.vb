Partial Class AF_mappApplications
  Inherits SIS.SYS.InsertBase
  Protected Sub FVmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappApplications.Init
    DataClassName = "AmappApplications"
    SetFormView = FVmappApplications
  End Sub
  Protected Sub TBLmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappApplications.Init
    SetToolBar = TBLmappApplications
  End Sub
  Protected Sub FVmappApplications_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappApplications.DataBound
    SIS.MAPP.mappApplications.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVmappApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappApplications.PreRender
    Dim oF_AppIconID_Display As Label  = FVmappApplications.FindControl("F_AppIconID_Display")
    Dim oF_AppIconID As TextBox  = FVmappApplications.FindControl("F_AppIconID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/MAPP_Main/App_Create") & "/AF_mappApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptmappApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptmappApplications", mStr)
    End If
    If Request.QueryString("AppID") IsNot Nothing Then
      CType(FVmappApplications.FindControl("F_AppID"), TextBox).Text = Request.QueryString("AppID")
      CType(FVmappApplications.FindControl("F_AppID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function AppIconIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.WF.wfDBIcons.SelectwfDBIconsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_MAPP_Applications_ApplIconID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim AppIconID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.WF.wfDBIcons = SIS.WF.wfDBIcons.wfDBIconsGetByID(AppIconID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
