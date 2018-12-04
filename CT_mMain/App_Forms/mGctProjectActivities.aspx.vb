Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctProjectActivities
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Dim Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = F_t_cprj.SelectedValue
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.StartFinish(ProjectID)

  End Sub

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    If ProjectID = "" Then Exit Sub
    Tree1.Nodes.Clear()
    Dim nd As New TreeNode
    With nd
      .Text = getColHead(F_t_cprj.SelectedItem.Text)
      .Value = ProjectID
    End With
    Tree1.Nodes.Add(nd)
    Dim tmpAs As List(Of SIS.CT.tpisg220) = SIS.CT.tpisg220.SelectProjectActivity(ProjectID)
    For Each tmp As SIS.CT.tpisg220 In tmpAs
      Dim tnd As New TreeNode
      With tnd
        .Text = GetRow(tmp)
        .Value = ProjectID & "_" & tmp.t_cact
        .PopulateOnDemand = True
      End With
      nd.ChildNodes.Add(tnd)
    Next
  End Sub
  Private Function AddChilds(ByVal nd As TreeNode) As TreeNode
    Dim ary() As String = nd.Value.Split("_".ToCharArray)
    Dim ProjectID As String = ""
    Dim ActivityID As String = ""
    Try
      ProjectID = ary(0)
      ActivityID = ary(1)
    Catch ex As Exception
      Return nd
    End Try
    Dim tmpAs As List(Of SIS.CT.tpisg220) = SIS.CT.tpisg220.SelectProjectActivity(ProjectID, ActivityID)
    For Each tmp As SIS.CT.tpisg220 In tmpAs
      Dim tnd As New TreeNode
      With tnd
        .Text = GetRow(tmp)
        .Value = ProjectID & "_" & tmp.t_cact
        .PopulateOnDemand = True
      End With
      nd.ChildNodes.Add(tnd)
      'AddChilds(tnd)
    Next
    Return nd
  End Function

  Private Sub Tree1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles Tree1.SelectedNodeChanged

  End Sub

  Private Sub Tree1_TreeNodePopulate(sender As Object, e As TreeNodeEventArgs) Handles Tree1.TreeNodePopulate
    Dim nd As TreeNode = e.Node
    AddChilds(nd)
  End Sub
  Private Function getSplittedStr(ByVal Str As String) As String
    Dim aVal As New ArrayList
    Dim restStr As String = Str
    Do While restStr.Length > 0
      If restStr.Length > 100 Then
        aVal.Add(restStr.Substring(0, 99))
        restStr = restStr.Substring(100)
      Else
        aVal.Add(restStr)
        restStr = ""
      End If

    Loop
    For Each tmp As String In aVal
      restStr &= IIf(restStr = "", tmp, "<br/>" & tmp)
    Next
    Return restStr
  End Function
  Private Function GetRow(ByVal x As SIS.CT.tpisg220) As String
    Dim row As String = ""
    row &= "</a></td><td style='width:500px!important;text-align:left;'>" & getSplittedStr(x.t_desc) & "</td><td style='width:20%;'></td>"
    row &= "<td class='col70c'>" & x.t_sdst & "</td>"
    row &= "<td class='col70c'>" & x.t_sdfn & "</td>"
    row &= "<td class='col70c'>" & x.t_acsd & "</td>"
    row &= "<td class='col70c'>" & x.t_acfn & "</td>"
    row &= "<td class='col70c'>" & Math.Round(x.t_pprc, 2) & "</td>"
    row &= "<td class='col70c'>" & Math.Round(x.t_cpgv, 2) & "</td>"
    row &= "<td class='col70c'>" & x.t_dela & "</td>"
    row &= "<td class='col70c'>" & x.t_delf & "</td>"
    row &= "<td class='col150c'>" & x.t_drem & "<a href='#'>"
    Return row
  End Function
  Private Function getColHead(ByVal str As String) As String
    Dim cols As String = ""
    cols = "</a></td><td class='btn-primary' style='width:500px!important;text-align:left;height:30px;font-size:14px;font-weight:bold;'>" & str & "</td><td style='width:20%;'></td>"
    cols &= "<td class='btn-info col70c'     >Pl-Start</td>"
    cols &= "<td class='btn-primary col70c'  >Pl-Finish</td>"
    cols &= "<td class='btn-info col70c'     >Act-Start</td>"
    cols &= "<td class='btn-primary col70c'  >Act-Finish</td>"
    cols &= "<td class='btn-info col70c'     >Pl-Progress-%</td>"
    cols &= "<td class='btn-primary col70c'  >Act-Progress-%</td>"
    cols &= "<td class='btn-info col70c'     >Start-Delay</td>"
    cols &= "<td class='btn-primary col70c'  >Finish-Delay</td>"
    cols &= "<td class='btn-info col150c'    >Delay-Remarks<a href='#'>"
    Return cols
  End Function
End Class
