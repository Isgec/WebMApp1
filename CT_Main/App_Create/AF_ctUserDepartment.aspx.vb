Partial Class AF_ctUserDepartment
  Inherits SIS.SYS.InsertBase
  Protected Sub FVctUserDepartment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserDepartment.Init
    DataClassName = "ActUserDepartment"
    SetFormView = FVctUserDepartment
  End Sub
  Protected Sub TBLctUserDepartment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctUserDepartment.Init
    SetToolBar = TBLctUserDepartment
  End Sub
  Protected Sub FVctUserDepartment_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserDepartment.DataBound
    SIS.CT.ctUserDepartment.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVctUserDepartment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserDepartment.PreRender
    Dim oF_UserID_Display As Label  = FVctUserDepartment.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVctUserDepartment.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim oF_DepartmentID_Display As Label  = FVctUserDepartment.FindControl("F_DepartmentID_Display")
    oF_DepartmentID_Display.Text = String.Empty
    If Not Session("F_DepartmentID_Display") Is Nothing Then
      If Session("F_DepartmentID_Display") <> String.Empty Then
        oF_DepartmentID_Display.Text = Session("F_DepartmentID_Display")
      End If
    End If
    Dim oF_DepartmentID As TextBox  = FVctUserDepartment.FindControl("F_DepartmentID")
    oF_DepartmentID.Enabled = True
    oF_DepartmentID.Text = String.Empty
    If Not Session("F_DepartmentID") Is Nothing Then
      If Session("F_DepartmentID") <> String.Empty Then
        oF_DepartmentID.Text = Session("F_DepartmentID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Create") & "/AF_ctUserDepartment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctUserDepartment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctUserDepartment", mStr)
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVctUserDepartment.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVctUserDepartment.FindControl("F_UserID"), TextBox).Enabled = False
    End If
    If Request.QueryString("DepartmentID") IsNot Nothing Then
      CType(FVctUserDepartment.FindControl("F_DepartmentID"), TextBox).Text = Request.QueryString("DepartmentID")
      CType(FVctUserDepartment.FindControl("F_DepartmentID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DepartmentIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDepartments.SelectqcmDepartmentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_CT_UserDepartment_UserID(ByVal value As String) As String
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
  Public Shared Function validate_FK_CT_UserDepartment_DepartmentID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DepartmentID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmDepartments = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(DepartmentID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
