Imports System.Web.Script.Serialization
Partial Class EF_mappApplications
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSmappApplications_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSmappApplications.Selected
    Dim tmp As SIS.MAPP.mappApplications = CType(e.ReturnValue, SIS.MAPP.mappApplications)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappApplications.Init
    DataClassName = "EmappApplications"
    SetFormView = FVmappApplications
  End Sub
  Protected Sub TBLmappApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappApplications.Init
    SetToolBar = TBLmappApplications
  End Sub
  Protected Sub FVmappApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappApplications.PreRender
    TBLmappApplications.EnableSave = Editable
    TBLmappApplications.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/MAPP_Main/App_Edit") & "/EF_mappApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptmappApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptmappApplications", mStr)
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
