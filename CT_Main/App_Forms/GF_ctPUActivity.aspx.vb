Imports System.Web.Script.Serialization
Partial Class GF_ctPUActivity
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/CT_Main/App_Display/DF_ctPUActivity.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_cprj=" & aVal(0) & "&t_atid=" & aVal(1) & "&t_srno=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVctPUActivity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVctPUActivity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        Dim RedirectUrl As String = TBLctPUActivity.EditUrl & "?t_cprj=" & t_cprj & "&t_atid=" & t_atid & "&t_srno=" & t_srno
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        SIS.CT.ctPUActivity.DeleteWF(t_cprj, t_atid, t_srno)
        GVctPUActivity.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        SIS.CT.ctPUActivity.InitiateWF(t_cprj, t_atid, t_srno)
        GVctPUActivity.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVctPUActivity.Init
    DataClassName = "GctPUActivity"
    SetGridView = GVctPUActivity
  End Sub
  Protected Sub TBLctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPUActivity.Init
    SetToolBar = TBLctPUActivity
  End Sub
  Protected Sub F_t_atid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_atid.TextChanged
    Session("F_t_atid") = F_t_atid.Text
    Session("F_t_atid_Display") = F_t_atid_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_atidCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.CT.ctPActivity.SelectctPActivityAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_t_cprj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_cprj.TextChanged
    Session("F_t_cprj") = F_t_cprj.Text
    Session("F_t_cprj_Display") = F_t_cprj_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_cprjCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.CT.ctProjects.SelectctProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_t_atid_Display.Text = String.Empty
    If Not Session("F_t_atid_Display") Is Nothing Then
      If Session("F_t_atid_Display") <> String.Empty Then
        F_t_atid_Display.Text = Session("F_t_atid_Display")
      End If
    End If
    F_t_atid.Text = String.Empty
    If Not Session("F_t_atid") Is Nothing Then
      If Session("F_t_atid") <> String.Empty Then
        F_t_atid.Text = Session("F_t_atid")
      End If
    End If
    Dim strScriptt_atid As String = "<script type=""text/javascript""> " & _
      "function ACEt_atid_Selected(sender, e) {" & _
      "  var F_t_atid = $get('" & F_t_atid.ClientID & "');" & _
      "  var F_t_atid_Display = $get('" & F_t_atid_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_t_atid.value = p[1];" & _
      "  F_t_atid_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_atid") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_atid", strScriptt_atid)
      End If
    Dim strScriptPopulatingt_atid As String = "<script type=""text/javascript""> " & _
      "function ACEt_atid_Populating(o,e) {" & _
      "  var p = $get('" & F_t_atid.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEt_atid_Populated(o,e) {" & _
      "  var p = $get('" & F_t_atid.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_t_atidPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_t_atidPopulating", strScriptPopulatingt_atid)
      End If
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
    Dim validateScriptt_atid As String = "<script type=""text/javascript"">" & _
      "  function validate_t_atid(o) {" & _
      "    validated_FK_ttpisg183200_t_atid_main = true;" & _
      "    validate_FK_ttpisg183200_t_atid(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatet_atid") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatet_atid", validateScriptt_atid)
    End If
    Dim validateScriptt_cprj As String = "<script type=""text/javascript"">" & _
      "  function validate_t_cprj(o) {" & _
      "    validated_FK_ttpisg183200_t_cprj_main = true;" & _
      "    validate_FK_ttpisg183200_t_cprj(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatet_cprj") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatet_cprj", validateScriptt_cprj)
    End If
    Dim validateScriptFK_ttpisg183200_t_cprj As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ttpisg183200_t_cprj(o) {" & _
      "    var value = o.id;" & _
      "    var t_cprj = $get('" & F_t_cprj.ClientID & "');" & _
      "    try{" & _
      "    if(t_cprj.value==''){" & _
      "      if(validated_FK_ttpisg183200_t_cprj.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + t_cprj.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ttpisg183200_t_cprj(value, validated_FK_ttpisg183200_t_cprj);" & _
      "  }" & _
      "  validated_FK_ttpisg183200_t_cprj_main = false;" & _
      "  function validated_FK_ttpisg183200_t_cprj(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ttpisg183200_t_cprj") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ttpisg183200_t_cprj", validateScriptFK_ttpisg183200_t_cprj)
    End If
    Dim validateScriptFK_ttpisg183200_t_atid As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ttpisg183200_t_atid(o) {" & _
      "    var value = o.id;" & _
      "    var t_cprj = $get('" & F_t_cprj.ClientID & "');" & _
      "    try{" & _
      "    if(t_cprj.value==''){" & _
      "      if(validated_FK_ttpisg183200_t_atid.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + t_cprj.value ;" & _
      "    }catch(ex){}" & _
      "    var t_atid = $get('" & F_t_atid.ClientID & "');" & _
      "    try{" & _
      "    if(t_atid.value==''){" & _
      "      if(validated_FK_ttpisg183200_t_atid.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + t_atid.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ttpisg183200_t_atid(value, validated_FK_ttpisg183200_t_atid);" & _
      "  }" & _
      "  validated_FK_ttpisg183200_t_atid_main = false;" & _
      "  function validated_FK_ttpisg183200_t_atid(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ttpisg183200_t_atid") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ttpisg183200_t_atid", validateScriptFK_ttpisg183200_t_atid)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ttpisg183200_t_cprj(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim t_cprj As String = CType(aVal(1),String)
    Dim oVar As SIS.CT.ctProjects = SIS.CT.ctProjects.ctProjectsGetByID(t_cprj)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ttpisg183200_t_atid(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim t_cprj As String = CType(aVal(1),String)
    Dim t_atid As String = CType(aVal(2),String)
    Dim oVar As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(t_cprj,t_atid)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
