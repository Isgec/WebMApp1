Imports System.Web.Script.Serialization
Partial Class EF_ctUserProject
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
  Protected Sub ODSctUserProject_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSctUserProject.Selected
    Dim tmp As SIS.CT.ctUserProject = CType(e.ReturnValue, SIS.CT.ctUserProject)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVctUserProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserProject.Init
    DataClassName = "EctUserProject"
    SetFormView = FVctUserProject
  End Sub
  Protected Sub TBLctUserProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctUserProject.Init
    SetToolBar = TBLctUserProject
  End Sub
  Protected Sub FVctUserProject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctUserProject.PreRender
    TBLctUserProject.EnableSave = Editable
    TBLctUserProject.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Edit") & "/EF_ctUserProject.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctUserProject") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctUserProject", mStr)
    End If
  End Sub

End Class
