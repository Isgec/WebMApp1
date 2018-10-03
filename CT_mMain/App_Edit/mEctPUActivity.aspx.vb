Imports System.Web.Script.Serialization
Partial Class mEctPUActivity
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
    If tmp.t_acsd <> "" Then
      If Year(Convert.ToDateTime(tmp.t_acsd)) > 2015 Then
        Editable = False
      End If
    End If
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
    If Request.QueryString("ed") IsNot Nothing Then
      If Request.QueryString("ed") = "N" Then
        CType(FVctPUActivity.FindControl("cmdSubmit"), Button).Visible = False
      End If
    End If
  End Sub
  Private Sub FVctPUActivity_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVctPUActivity.ItemCommand
    If e.CommandName.ToLower = "lgupdate".ToLower Then
      TBLctPUActivity.ExecuteSave()
    End If
  End Sub
  Private Sub FVctPUActivity_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVctPUActivity.ItemUpdating
    If e.NewValues("t_tpgv") = "" Then
      e.NewValues("t_tpgv") = "0"
    End If
    If e.NewValues("t_cpgv") = "" Then
      e.NewValues("t_cpgv") = "0"
    End If
  End Sub
End Class
