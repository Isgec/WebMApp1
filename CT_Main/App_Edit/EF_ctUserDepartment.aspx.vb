Imports System.Web.Script.Serialization
Partial Class EF_ctUserDepartment
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
  Protected Sub ODSctUserDepartment_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSctUserDepartment.Selected
    Dim tmp As SIS.CT.ctUserDepartment = CType(e.ReturnValue, SIS.CT.ctUserDepartment)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVctUserDepartment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserDepartment.Init
    DataClassName = "EctUserDepartment"
    SetFormView = FVctUserDepartment
  End Sub
  Protected Sub TBLctUserDepartment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctUserDepartment.Init
    SetToolBar = TBLctUserDepartment
  End Sub
  Protected Sub FVctUserDepartment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserDepartment.PreRender
    TBLctUserDepartment.EnableSave = Editable
    TBLctUserDepartment.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Edit") & "/EF_ctUserDepartment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctUserDepartment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctUserDepartment", mStr)
    End If
  End Sub

End Class
