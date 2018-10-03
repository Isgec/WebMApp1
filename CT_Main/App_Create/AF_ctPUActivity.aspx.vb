Partial Class AF_ctPUActivity
  Inherits SIS.SYS.InsertBase
  Protected Sub FVctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.Init
    DataClassName = "ActPUActivity"
    SetFormView = FVctPUActivity
  End Sub
  Protected Sub TBLctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPUActivity.Init
    SetToolBar = TBLctPUActivity
  End Sub
  Protected Sub FVctPUActivity_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.DataBound
    SIS.CT.ctPUActivity.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVctPUActivity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.PreRender
    Dim oF_t_cprj_Display As Label  = FVctPUActivity.FindControl("F_t_cprj_Display")
    oF_t_cprj_Display.Text = String.Empty
    If Not Session("F_t_cprj_Display") Is Nothing Then
      If Session("F_t_cprj_Display") <> String.Empty Then
        oF_t_cprj_Display.Text = Session("F_t_cprj_Display")
      End If
    End If
    Dim oF_t_cprj As TextBox  = FVctPUActivity.FindControl("F_t_cprj")
    oF_t_cprj.Enabled = True
    oF_t_cprj.Text = String.Empty
    If Not Session("F_t_cprj") Is Nothing Then
      If Session("F_t_cprj") <> String.Empty Then
        oF_t_cprj.Text = Session("F_t_cprj")
      End If
    End If
    Dim oF_t_atid_Display As Label  = FVctPUActivity.FindControl("F_t_atid_Display")
    oF_t_atid_Display.Text = String.Empty
    If Not Session("F_t_atid_Display") Is Nothing Then
      If Session("F_t_atid_Display") <> String.Empty Then
        oF_t_atid_Display.Text = Session("F_t_atid_Display")
      End If
    End If
    Dim oF_t_atid As TextBox  = FVctPUActivity.FindControl("F_t_atid")
    oF_t_atid.Enabled = True
    oF_t_atid.Text = String.Empty
    If Not Session("F_t_atid") Is Nothing Then
      If Session("F_t_atid") <> String.Empty Then
        oF_t_atid.Text = Session("F_t_atid")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Create") & "/AF_ctPUActivity.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctPUActivity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctPUActivity", mStr)
    End If
    If Request.QueryString("t_cprj") IsNot Nothing Then
      CType(FVctPUActivity.FindControl("F_t_cprj"), TextBox).Text = Request.QueryString("t_cprj")
      CType(FVctPUActivity.FindControl("F_t_cprj"), TextBox).Enabled = False
    End If
    If Request.QueryString("t_cact") IsNot Nothing Then
      CType(FVctPUActivity.FindControl("F_t_atid"), TextBox).Text = Request.QueryString("t_cact")
      CType(FVctPUActivity.FindControl("F_t_atid"), TextBox).Enabled = False
    End If
    If Request.QueryString("t_srno") IsNot Nothing Then
      CType(FVctPUActivity.FindControl("F_t_srno"), TextBox).Text = Request.QueryString("t_srno")
      CType(FVctPUActivity.FindControl("F_t_srno"), TextBox).Enabled = False
    Else
      CType(FVctPUActivity.FindControl("F_t_srno"), TextBox).Text = 0
      CType(FVctPUActivity.FindControl("F_t_srno"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_cprjCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.CT.ctProjects.SelectctProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_atidCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.CT.ctPActivity.SelectctPActivityAutoCompleteList(prefixText, count, contextKey)
  End Function
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
