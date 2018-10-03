Imports System.Web.Script.Serialization
Partial Class EF_ctPUActivity
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
  Protected Sub ODSctPUActivity_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSctPUActivity.Selected
    Dim tmp As SIS.CT.ctPUActivity = CType(e.ReturnValue, SIS.CT.ctPUActivity)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.Init
    DataClassName = "EctPUActivity"
    SetFormView = FVctPUActivity
  End Sub
  Protected Sub TBLctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPUActivity.Init
    SetToolBar = TBLctPUActivity
  End Sub
  Protected Sub FVctPUActivity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.PreRender
    TBLctPUActivity.EnableSave = Editable
    TBLctPUActivity.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Edit") & "/EF_ctPUActivity.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctPUActivity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctPUActivity", mStr)
    End If
  End Sub

End Class
