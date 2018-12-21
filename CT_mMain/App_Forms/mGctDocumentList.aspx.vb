Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctDocumentList
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Private ActivityID As String = ""
  Private ClickedID As String = ""
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private ItemReference As String = ""
  Private IsNext As Boolean = False

  Private Sub mGctActivityList_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    ActivityID = Request.QueryString("t_cact")
    ClickedID = Request.QueryString("ID")
    If Request.QueryString("IsNext") IsNot Nothing Then IsNext = True
    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
  End Sub


  Private Sub irefDelay30d_PreRender(sender As Object, e As EventArgs) Handles irefDelay30d.PreRender
    Dim tmp As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(ProjectID, ActivityID)
    ItemReference = tmp.t_sub1
    ItemRef.Text = ItemReference
    BaselineFinish.Text = ProjectID
    Dim tbl As Table = Nothing
    tbl = GetTable(ProjectID, ActivityID, ClickedID, IsNext)
    irefDelay30d.Controls.Add(tbl)
  End Sub
  Private Function GetTable(ByVal t_cprj As String, ByVal t_cact As String, ByVal ID As String, Optional ByVal IsNext As Boolean = False) As Table
    Dim data As List(Of SIS.CT.tdmisg140) = Nothing
    data = SIS.CT.tdmisg140.SelectDocumentList(t_cprj, t_cact, IIf(ClickedID = "DT", True, False), IsNext)
    'data.Sort(Function(x, y) x.t_cact.CompareTo(y.t_cact))

    Dim mStr As String = ""
    Dim tbl As New Table
    With tbl
      .ID = "tbl30Days"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
      .Style.Add(HtmlTextWriterStyle.Margin, "5px 5px 5px 5px")
    End With
    'Write Header
    Dim th As New TableHeaderRow
    Dim btn As Button = Nothing
    th.Attributes.Add("style", "background-color:black;color:white;font-size:14px;")
    th.TableSection = TableRowSection.TableHeader
    For i As Integer = 0 To 8
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Font.Bold = True

        Select Case i
          Case 0
            .Text = "DOCUMENT"
          Case 1
            .Text = "REV."
          Case 2
            .Text = "TITLE"
          Case 3
            .Text = "SCHD. START"
          Case 4
            .Text = "SCHD. FINISH"
          Case 5
            .Text = "ACT. START"
          Case 6
            .Text = "ACT. FINISH"
          Case 7
            .Text = "OL. START"
          Case 8
            .Text = "OL. FINISH"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    '==========
    'Write Data
    '===========
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    For Each dt As SIS.CT.tdmisg140 In data
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      For I As Integer = 0 To 8
        td = New TableCell
        With td
          .ClientIDMode = ClientIDMode.Static
          .ID = dt.t_docn
          .CssClass = "btn-outline-primary"
          Select Case I
            Case 0
              .Text = dt.t_docn
            Case 1
              .Text = dt.t_revn
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_dsca
            Case 3
              .Text = dt.t_bssd
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_bsfd
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_acdt
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_adct
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_mosd
              .Attributes.Add("style", "text-align:center;")
            Case 8
              .Text = dt.t_moed
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    Return tbl
  End Function

End Class
