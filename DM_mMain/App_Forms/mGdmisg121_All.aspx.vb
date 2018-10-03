Imports System.Web.Script.Serialization
Partial Class mGF_dmisg121_All
  Inherits SIS.SYS.GridBase
  Private Sub ODSdmisg121_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ODSdmisg121.Selecting
    Dim DocID As String = ""
    Dim RevNo As String = ""
    If Request.QueryString("docID") IsNot Nothing Then
      DocID = Request.QueryString("docid")
    End If
    If Request.QueryString("revno") IsNot Nothing Then
      RevNo = Request.QueryString("revno")
    End If
    '1. Check To Search
    If e.InputParameters("SearchText") <> "" Then
      e.InputParameters("SearchState") = True
    End If
    If DocID <> "" AndAlso RevNo <> "" Then
      e.InputParameters("SearchText") = "##" & DocID & "_" & RevNo
      e.InputParameters("SearchState") = True
    End If
  End Sub

  Private Sub GVdmisg121_Init(sender As Object, e As EventArgs) Handles GVdmisg121.Init
    DataClassName = "tdmisg121200"
    SetGridView = GVdmisg121
  End Sub

  Private Sub TBLdmisg121200_Init(sender As Object, e As EventArgs) Handles TBLdmisg121200.Init
    SetToolBar = TBLdmisg121200
  End Sub
End Class
