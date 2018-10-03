Partial Class AF_mappUserApps
  Inherits SIS.SYS.InsertBase
  Protected Sub FVmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappUserApps.Init
    DataClassName = "AmappUserApps"
    SetFormView = FVmappUserApps
  End Sub
  Protected Sub TBLmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappUserApps.Init
    SetToolBar = TBLmappUserApps
  End Sub
  Protected Sub FVmappUserApps_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappUserApps.DataBound
    SIS.MAPP.mappUserApps.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVmappUserApps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappUserApps.PreRender
    Dim oF_AppID_Display As Label  = FVmappUserApps.FindControl("F_AppID_Display")
    oF_AppID_Display.Text = String.Empty
    If Not Session("F_AppID_Display") Is Nothing Then
      If Session("F_AppID_Display") <> String.Empty Then
        oF_AppID_Display.Text = Session("F_AppID_Display")
      End If
    End If
    Dim oF_AppID As TextBox  = FVmappUserApps.FindControl("F_AppID")
    oF_AppID.Enabled = True
    oF_AppID.Text = String.Empty
    If Not Session("F_AppID") Is Nothing Then
      If Session("F_AppID") <> String.Empty Then
        oF_AppID.Text = Session("F_AppID")
      End If
    End If
    Dim oF_UserID_Display As Label  = FVmappUserApps.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVmappUserApps.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/MAPP_Main/App_Create") & "/AF_mappUserApps.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptmappUserApps") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptmappUserApps", mStr)
    End If
    If Request.QueryString("AppID") IsNot Nothing Then
      CType(FVmappUserApps.FindControl("F_AppID"), TextBox).Text = Request.QueryString("AppID")
      CType(FVmappUserApps.FindControl("F_AppID"), TextBox).Enabled = False
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVmappUserApps.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVmappUserApps.FindControl("F_UserID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function AppIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.MAPP.mappApplications.SelectmappApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_MAPP_UserApps_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_MAPP_UserApps_ApplID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim AppID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetByID(AppID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
