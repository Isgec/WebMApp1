Imports System.Web.Script.Serialization
Partial Class GF_ctPActivity
  Inherits SIS.SYS.GridBase
  Protected Sub GVctPActivity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVctPActivity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_cact As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cact")
        Dim RedirectUrl As String = TBLctPActivity.EditUrl & "?t_cprj=" & t_cprj & "&t_cact=" & t_cact
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVctPActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVctPActivity.Init
    DataClassName = "GctPActivity"
    SetGridView = GVctPActivity
  End Sub
  Protected Sub TBLctPActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPActivity.Init
    SetToolBar = TBLctPActivity
  End Sub
  Protected Sub F_t_cprj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_cprj.TextChanged
    Session("F_t_cprj") = F_t_cprj.Text
    Session("F_t_cprj_Display") = F_t_cprj_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_cprjCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_t_cact_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_cact.TextChanged
    Session("F_t_cact") = F_t_cact.Text
    Session("F_t_cact_Display") = F_t_cact_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_cactCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.CT.ctPActivity.UZ_SelectctPActivityAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_t_cprj_Display.Text = String.Empty
    If Not Session("F_t_cprj_Display") Is Nothing Then
      If Session("F_t_cprj_Display") <> String.Empty Then
        F_t_cprj_Display.Text = Session("F_t_cprj_Display")
      End If
    End If
    F_t_cprj.Text = String.Empty
    If Not Session("F_t_cprj") Is Nothing Then
      If Session("F_t_cprj") <> String.Empty Then
        F_t_cprj.Text = Session("F_t_cprj")
      End If
    End If
    Dim strScriptt_cprj As String = "<script type=""text/javascript""> " & _
      "function ACEt_cprj_Selected(sender, e) {" & _
      "  var F_t_cprj = $get('" & F_t_cprj.ClientID & "');" & _
      "  var F_t_cprj_Display = $get('" & F_t_cprj_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_t_cprj.value = p[0];" & _
      "  F_t_cprj_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_cprj") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_cprj", strScriptt_cprj)
      End If
    Dim strScriptPopulatingt_cprj As String = "<script type=""text/javascript""> " & _
      "function ACEt_cprj_Populating(o,e) {" & _
      "  var p = $get('" & F_t_cprj.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEt_cprj_Populated(o,e) {" & _
      "  var p = $get('" & F_t_cprj.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_cprjPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_cprjPopulating", strScriptPopulatingt_cprj)
      End If
    F_t_cact_Display.Text = String.Empty
    If Not Session("F_t_cact_Display") Is Nothing Then
      If Session("F_t_cact_Display") <> String.Empty Then
        F_t_cact_Display.Text = Session("F_t_cact_Display")
      End If
    End If
    F_t_cact.Text = String.Empty
    If Not Session("F_t_cact") Is Nothing Then
      If Session("F_t_cact") <> String.Empty Then
        F_t_cact.Text = Session("F_t_cact")
      End If
    End If
    Dim strScriptt_cact As String = "<script type=""text/javascript""> " & _
      "function ACEt_cact_Selected(sender, e) {" & _
      "  var F_t_cact = $get('" & F_t_cact.ClientID & "');" & _
      "  var F_t_cact_Display = $get('" & F_t_cact_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_t_cact.value = p[1];" & _
      "  F_t_cact_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_cact") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_cact", strScriptt_cact)
      End If
    Dim strScriptPopulatingt_cact As String = "<script type=""text/javascript""> " &
      "function ACEt_cact_Populating(o,e) {" &
      "  var p = $get('" & F_t_cact.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  var cx = $get('" & F_t_cprj.ClientID & "');" &
      "  o._contextKey = cx.value;" &
      "}" &
      "function ACEt_cact_Populated(o,e) {" &
      "  var p = $get('" & F_t_cact.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_cactPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_cactPopulating", strScriptPopulatingt_cact)
      End If
    Dim validateScriptt_cprj As String = "<script type=""text/javascript"">" & _
      "  function validate_t_cprj(o) {" & _
      "    validated_FK_ttpisg220200_t_cprj_main = true;" & _
      "    validate_FK_ttpisg220200_t_cprj(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatet_cprj") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatet_cprj", validateScriptt_cprj)
    End If
    Dim validateScriptt_cact As String = "<script type=""text/javascript"">" &
      "  function validate_t_cact(o) {" &
      "    validated_FK_ttpisg220200_t_cact_main = true;}" &
      "    //validate_FK_ttpisg220200_t_cact(o);}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatet_cact") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatet_cact", validateScriptt_cact)
    End If
    Dim validateScriptFK_ttpisg220200_t_cprj As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ttpisg220200_t_cprj(o) {" & _
      "    var value = o.id;" & _
      "    var t_cprj = $get('" & F_t_cprj.ClientID & "');" & _
      "    try{" & _
      "    if(t_cprj.value==''){" & _
      "      if(validated_FK_ttpisg220200_t_cprj.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + t_cprj.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ttpisg220200_t_cprj(value, validated_FK_ttpisg220200_t_cprj);" & _
      "  }" & _
      "  validated_FK_ttpisg220200_t_cprj_main = false;" & _
      "  function validated_FK_ttpisg220200_t_cprj(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ttpisg220200_t_cprj") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ttpisg220200_t_cprj", validateScriptFK_ttpisg220200_t_cprj)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ttpisg220200_t_cprj(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ttpisg220200_t_cact(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim t_cprj As String = CType(aVal(1), String)
    Dim t_cact As String = CType(aVal(2), String)
    Dim oVar As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(t_cprj, t_cact)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.t_desc
    End If
    Return mRet
  End Function
End Class
