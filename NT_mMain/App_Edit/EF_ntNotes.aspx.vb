Imports System.Web.Script.Serialization
Partial Class EF_ntNotes
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
  Protected Sub ODSntNotes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSntNotes.Selected
    Dim tmp As SIS.NT.ntNotes = CType(e.ReturnValue, SIS.NT.ntNotes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVntNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVntNotes.Init
    DataClassName = "EntNotes"
    SetFormView = FVntNotes
  End Sub
  Protected Sub TBLntNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLntNotes.Init
    SetToolBar = TBLntNotes
  End Sub

  Private Sub cmdSubmit_Command(sender As Object, e As CommandEventArgs) Handles cmdSubmit.Command
    If Request.Files.Count > 0 Then
      SIS.NT.ntNotes.AddRequestFiles(Request, PrimaryKey)
    End If
    TBLntNotes.ExecuteSave()
  End Sub
End Class
