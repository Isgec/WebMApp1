Imports System.Web.Script.Serialization
Partial Class mGF_dmisg121
  Inherits SIS.SYS.GridBase
  Public Property LatestRevision As Boolean
    Get
      If ViewState("LatestRevision") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("LatestRevision"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("LatestRevision", value)
    End Set
  End Property
  Private Sub ODSdmisg121_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ODSdmisg121.Selecting
    '1. Check To Search
    If e.InputParameters("SearchText") <> "" Then
      e.InputParameters("SearchState") = True
    End If
  End Sub


  Private Sub F_LatestRevision_CheckedChanged(sender As Object, e As EventArgs) Handles F_LatestRevision.CheckedChanged
    LatestRevision = F_LatestRevision.Checked
  End Sub
  Private Sub GVdmisg121_Init(sender As Object, e As EventArgs) Handles GVdmisg121.Init
    DataClassName = "tdmisg121200"
    SetGridView = GVdmisg121
  End Sub

  Private Sub TBLdmisg121200_Init(sender As Object, e As EventArgs) Handles TBLdmisg121200.Init
    SetToolBar = TBLdmisg121200
  End Sub

End Class
