Imports System.Web.Script.Serialization
Partial Class GF_mappUserApps
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/MAPP_Main/App_Display/DF_mappUserApps.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?AppID=" & aVal(0) & "&UserID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVmappUserApps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVmappUserApps.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim AppID As Int32 = GVmappUserApps.DataKeys(e.CommandArgument).Values("AppID")  
        Dim UserID As String = GVmappUserApps.DataKeys(e.CommandArgument).Values("UserID")  
        Dim RedirectUrl As String = TBLmappUserApps.EditUrl & "?AppID=" & AppID & "&UserID=" & UserID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVmappUserApps.Init
    DataClassName = "GmappUserApps"
    SetGridView = GVmappUserApps
  End Sub
  Protected Sub TBLmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappUserApps.Init
    SetToolBar = TBLmappUserApps
  End Sub
  Protected Sub F_AppID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_AppID.TextChanged
    Session("F_AppID") = F_AppID.Text
    Session("F_AppID_Display") = F_AppID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function AppIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.MAPP.mappApplications.SelectmappApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_UserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UserID.TextChanged
    Session("F_UserID") = F_UserID.Text
    Session("F_UserID_Display") = F_UserID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_AppID_Display.Text = String.Empty
    If Not Session("F_AppID_Display") Is Nothing Then
      If Session("F_AppID_Display") <> String.Empty Then
        F_AppID_Display.Text = Session("F_AppID_Display")
      End If
    End If
    F_AppID.Text = String.Empty
    If Not Session("F_AppID") Is Nothing Then
      If Session("F_AppID") <> String.Empty Then
        F_AppID.Text = Session("F_AppID")
      End If
    End If
    Dim strScriptAppID As String = "<script type=""text/javascript""> " & _
      "function ACEAppID_Selected(sender, e) {" & _
      "  var F_AppID = $get('" & F_AppID.ClientID & "');" & _
      "  var F_AppID_Display = $get('" & F_AppID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_AppID.value = p[0];" & _
      "  F_AppID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AppID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AppID", strScriptAppID)
      End If
    Dim strScriptPopulatingAppID As String = "<script type=""text/javascript""> " & _
      "function ACEAppID_Populating(o,e) {" & _
      "  var p = $get('" & F_AppID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEAppID_Populated(o,e) {" & _
      "  var p = $get('" & F_AppID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AppIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AppIDPopulating", strScriptPopulatingAppID)
      End If
    F_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        F_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    F_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        F_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim strScriptUserID As String = "<script type=""text/javascript""> " & _
      "function ACEUserID_Selected(sender, e) {" & _
      "  var F_UserID = $get('" & F_UserID.ClientID & "');" & _
      "  var F_UserID_Display = $get('" & F_UserID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_UserID.value = p[0];" & _
      "  F_UserID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserID", strScriptUserID)
      End If
    Dim strScriptPopulatingUserID As String = "<script type=""text/javascript""> " & _
      "function ACEUserID_Populating(o,e) {" & _
      "  var p = $get('" & F_UserID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEUserID_Populated(o,e) {" & _
      "  var p = $get('" & F_UserID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserIDPopulating", strScriptPopulatingUserID)
      End If
    Dim validateScriptAppID As String = "<script type=""text/javascript"">" & _
      "  function validate_AppID(o) {" & _
      "    validated_FK_MAPP_UserApps_ApplID_main = true;" & _
      "    validate_FK_MAPP_UserApps_ApplID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateAppID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateAppID", validateScriptAppID)
    End If
    Dim validateScriptUserID As String = "<script type=""text/javascript"">" & _
      "  function validate_UserID(o) {" & _
      "    validated_FK_MAPP_UserApps_UserID_main = true;" & _
      "    validate_FK_MAPP_UserApps_UserID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateUserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateUserID", validateScriptUserID)
    End If
    Dim validateScriptFK_MAPP_UserApps_UserID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_MAPP_UserApps_UserID(o) {" & _
      "    var value = o.id;" & _
      "    var UserID = $get('" & F_UserID.ClientID & "');" & _
      "    try{" & _
      "    if(UserID.value==''){" & _
      "      if(validated_FK_MAPP_UserApps_UserID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + UserID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_MAPP_UserApps_UserID(value, validated_FK_MAPP_UserApps_UserID);" & _
      "  }" & _
      "  validated_FK_MAPP_UserApps_UserID_main = false;" & _
      "  function validated_FK_MAPP_UserApps_UserID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_MAPP_UserApps_UserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_MAPP_UserApps_UserID", validateScriptFK_MAPP_UserApps_UserID)
    End If
    Dim validateScriptFK_MAPP_UserApps_ApplID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_MAPP_UserApps_ApplID(o) {" & _
      "    var value = o.id;" & _
      "    var AppID = $get('" & F_AppID.ClientID & "');" & _
      "    try{" & _
      "    if(AppID.value==''){" & _
      "      if(validated_FK_MAPP_UserApps_ApplID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + AppID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_MAPP_UserApps_ApplID(value, validated_FK_MAPP_UserApps_ApplID);" & _
      "  }" & _
      "  validated_FK_MAPP_UserApps_ApplID_main = false;" & _
      "  function validated_FK_MAPP_UserApps_ApplID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_MAPP_UserApps_ApplID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_MAPP_UserApps_ApplID", validateScriptFK_MAPP_UserApps_ApplID)
    End If
  End Sub
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
