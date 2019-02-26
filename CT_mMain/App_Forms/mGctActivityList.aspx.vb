Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization

Partial Class mGctActivityList
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Private ActivityID As String = ""
  Private ActivityType As String = ""
  Private ClickedID As String = ""
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private ClickedAt As String = ""
  Private IsAll As Boolean = False
  Private ItemReference As String = ""
  Private ListType As String = ""
  Private IsBacklog As Boolean = False
  Private IsNext As Boolean = False
  Private Sub mGctActivityList_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    ClickedID = Request.QueryString("ID")
    If Request.QueryString("t_cact") IsNot Nothing Then ActivityID = Request.QueryString("t_cact")
    If Request.QueryString("t_acty") IsNot Nothing Then ActivityType = Request.QueryString("t_acty")
    If Request.QueryString("all") IsNot Nothing Then IsAll = Request.QueryString("all")
    If Request.QueryString("ListType") IsNot Nothing Then ListType = Request.QueryString("ListType")
    If Request.QueryString("Backlog") IsNot Nothing Then IsBacklog = True
    If Request.QueryString("IsNext") IsNot Nothing Then IsNext = True

    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
    Dim lDt As DateTime = SIS.CT.DelayStatus30Days.LastUpdatedOn(ProjectID)

    If IsAll Then
      If IsNext Then
        Label2.Text = "(From " & Period.StDt.ToString("dd/MM/yyyy") & " Till " & DateAdd(DateInterval.Day, 31, Now).ToString("dd/MM/yyyy") & " - As On " & Now.ToString("dd/MM/yyyy") & ")"
      Else
        Label2.Text = "(From " & Period.StDt.ToString("dd/MM/yyyy") & " Till " & DateAdd(DateInterval.Day, -31, Now).ToString("dd/MM/yyyy") & " - As On " & Now.ToString("dd/MM/yyyy") & ")"
      End If
    Else
      If IsBacklog Then
        Label2.Text = "From " & Period.StDt.ToString("dd/MM/yyyy") & " Till " & Now.ToString("dd/MM/yyyy") & " - Updated On " & lDt.ToString("dd/MM/yyyy") & ""
      Else
        If IsNext Then
          Label2.Text = "(Next 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
        Else
          Label2.Text = "(Last 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
        End If
      End If
    End If
    Select Case ClickedID
      Case "ACTIVITY", "DATA_S", "DATA_F"
        Select Case ActivityType
          Case "DESIGN"
            Label4.Text = "ENGINEERING"
          Case "INDT"
            Label4.Text = "INDENTING"
          Case "RFQ-TO-PO"
            Label4.Text = "RFQ-TO-PO"
          Case "MFG"
            Label4.Text = "MANUFACTURING"
          Case "EREC"
            Label4.Text = "ERECTION"
          Case "DISP"
            Label4.Text = "DESPATCH"
          Case "RECPT"
            Label4.Text = "RECEIPT AT SITE"
          Case "OTHERS"
            Label4.Text = "OTHERS"
        End Select
    End Select
    Select Case ClickedID
      Case "DATA_S", "DATA_F"
        Dim tmp As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(ProjectID, ActivityID)
        ItemReference = tmp.t_sub1
        Label3.Text = ItemReference
      Case "ITEM"
        Dim tmp As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(ProjectID, ActivityID)
        ItemReference = tmp.t_sub1 & " " & tmp.t_sub2 & " " & tmp.t_sub3 & " " & tmp.t_sub4
        Label3.Text = ItemReference
    End Select
  End Sub


  Private Sub irefDelay30d_PreRender(sender As Object, e As EventArgs) Handles irefDelay30d.PreRender
    Dim tbl As Table = Nothing
    tbl = GetTable(ProjectID, ActivityID, ActivityType, ClickedID, IsAll, IsNext)
    irefDelay30d.Controls.Add(tbl)
  End Sub
  Private Function GetTable(ByVal t_cprj As String, ByVal t_cact As String, ByVal t_acty As String, ByVal ID As String, ByVal All As Boolean, Optional ByVal IsNext As Boolean = False) As Table
    Dim data As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing
    Select Case ListType
      Case "OverallAgeing"
        data = SIS.CT.Ageing.OverallActivity(t_cprj, ClickedID)
      Case "ActivityAgeing30"
        data = SIS.CT.Ageing.ActyActivity(t_cprj, t_acty, ClickedID)
      Case "ActivityAgeing" 'OverAll
        data = SIS.CT.Ageing.OAActyActivity(t_cprj, t_acty, ClickedID)
      Case Else
        data = SIS.CT.DelayStatus30Days.SelectActivity(t_cprj, t_cact, t_acty, ID, IsAll, IsNext)
    End Select
    'Now sorting is needed as parents are inserted after Select statement
    If data IsNot Nothing Then data.Sort(Function(x, y) x.t_actp.CompareTo(y.t_actp))
    Dim hideItem As Boolean = False
    Select Case ClickedID
      Case "ITEM", "DATA_S", "DATA_F"
        hideItem = True
    End Select
    Dim mStr As String = ""
    Dim tbl As New Table
    With tbl
      .ID = "tbl30Days"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      '.Width = Unit.Percentage(100)
      '.Style.Add(HtmlTextWriterStyle.Margin, "5px 5px 5px 5px")
      '.Style.Add(HtmlTextWriterStyle.WhiteSpace, "nowrap")
    End With
    'Write Header
    Dim th As New TableHeaderRow
    Dim btn As Button = Nothing
    th.Attributes.Add("style", "background-color:black;color:white;font-size:14px;")
    th.TableSection = TableRowSection.TableHeader
    For i As Integer = 0 To 14
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Font.Bold = True

        Select Case i
          Case 0
            .Text = "ACTIVITY"
          Case 1
            .Text = "ITEM"
          Case 2
            .Text = "SUB ITEM"
          Case 3
            .Text = "START DELAY"
          Case 4
            .Text = "FINISH DELAY"
          Case 5
            .Text = "PLN. %"
          Case 6
            .Text = "ACT. %"
          Case 7
            .Text = "DELAY TYPE"
          Case 8
            .Text = "SCHD. START"
          Case 9
            .Text = "SCHD. FINISH"
          Case 10
            .Text = "ACT. START"
          Case 11
            .Text = "ACT. FINISH"
          Case 12
            .Text = "OL. START"
          Case 13
            .Text = "OL. FINISH"
          Case 14
            .Text = "DEPTT"
        End Select
        If hideItem AndAlso i = 1 Then
        Else
          th.Cells.Add(thc)
        End If
      End With
    Next
    tbl.Rows.Add(th)
    '==========
    'Write Data
    '===========
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    For Each dt As SIS.CT.DelayStatus30Days.Activities In data
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      For I As Integer = 0 To 14
        td = New TableCell
        With td
          If Not dt.IsDue Then
            .CssClass = "btn-outline-secondary"
          Else
            If Not dt.IsCurrent Then
              If dt.IsStarted And dt.IsFinished Then
                .CssClass = "btn-outline-success"
              ElseIf dt.IsStarted And Not dt.IsFinished Then
                .CssClass = "btn-outline-info"
              Else
                If dt.PredClosed Then
                  If I = 0 Then
                    .CssClass = "btn-danger"
                  Else
                    .CssClass = "btn-outline-danger"
                  End If
                Else
                  If I = 0 Then
                    .CssClass = "btn-warning"
                  Else
                    .CssClass = "btn-outline-warning"
                  End If
                End If
              End If
            Else
              If dt.IsStarted And dt.IsFinished Then
                .CssClass = "btn-success"
              ElseIf dt.IsStarted And Not dt.IsFinished Then
                .CssClass = "btn-info"
              Else
                If dt.PredClosed Then
                  .CssClass = "btn-danger"
                Else
                  .CssClass = "btn-warning"
                End If
              End If
            End If
          End If
          If dt.t_acty = "PARENT" Then
            .CssClass = "btn-secondary"
          End If
          Select Case I
            Case 0

              Dim tmpStr As String = ""
              Dim predCnt As Integer = SIS.CT.DelayStatus30Days.GetPredActivitiesCount(t_cprj, dt.t_cact)
              Dim cogStyle As String = ""
              If predCnt > 0 Then
                cogStyle = "color:lime;cursor:pointer;"
              Else
                cogStyle = "color:gray;cursor:pointer;"
              End If
              tmpStr &= "<table style='border-collapse:collapse;border:none;'>"
              tmpStr &= "  <tr>"
              tmpStr &= "    <td style='background-color:black;border-collapse:collapse;border:none;width:18px;text-align:center;'>"
              tmpStr &= "      <i "
              If predCnt > 0 Then
                tmpStr &= "      id='cog_" & dt.t_cact & "' "
                tmpStr &= "      data-project='" & t_cprj & "' "
                tmpStr &= "      data-activity='" & dt.t_cact & "' "
                tmpStr &= "      data-loaded='0' "
                tmpStr &= "      onclick='load_pred(this);' "
              End If
              tmpStr &= "      class='fa fa-cog' style='" & cogStyle & "'></i>"
              tmpStr &= "    </td>"
              tmpStr &= "    <td style='border-collapse:collapse;border:none;'>" & dt.t_desc
              tmpStr &= "    </td>"
              tmpStr &= "  </tr>"
              tmpStr &= "</table>"
              .Text = tmpStr
            Case 1
              .Text = dt.t_sub1
              .Attributes.Add("style", "text-align:left;min-height:24px !important;")
            Case 2
              .Text = dt.SubItem
            Case 3
              .Text = dt.t_dela
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_delf
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_pprc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cpgv.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_drem
            Case 8
              .Text = dt.t_sdst
            Case 9
              .Text = dt.t_sdfn
            Case 10
              .Text = dt.t_acsd
            Case 11
              .Text = dt.t_acfn
            Case 12
              .Text = dt.t_otsd
            Case 13
              .Text = dt.t_oted
            Case 14
              .Text = dt.t_dept
          End Select
        End With
        If hideItem AndAlso I = 1 Then
        Else
          tr.Cells.Add(td)
        End If
      Next
      tbl.Rows.Add(tr)
      'If dt.t_acty <> "PARENT" Then
      tr = New TableRow
      Dim predTd As New TableCell '= SIS.CT.DelayStatus30Days.GetPredCell(t_cprj, dt.t_cact)
      If hideItem Then
        predTd.ColumnSpan = 14
      Else
        predTd.ColumnSpan = 15
      End If
      predTd.ID = "predTD_" & dt.t_cact
      predTd.ClientIDMode = ClientIDMode.Static
      tr.Cells.Add(predTd)
      tbl.Rows.Add(tr)
      'End If

    Next
    Return tbl
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getPredData(ByVal context As String) As String
    Dim aVal() As String = context.Split("|".ToCharArray)
    'x.id + '|' + indent.toString + '|' + tbl.id + '|' + tbl.getAttribute('data-project')+'|'+t_cact
    Dim rowID As String = aVal(0)
    Dim Indent As Integer = aVal(1)
    Dim tblID As String = aVal(2)
    Dim ProjectID As String = aVal(3)
    Dim ActivityID As String = aVal(4)
    Dim str As String = SIS.CT.DelayStatus30Days.GetPredRows(ProjectID, ActivityID, Indent, rowID)
    Dim mRet As String = "0|" & rowID & "|" & str
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getPredTbl(ByVal context As String) As String
    Dim aVal() As String = context.Split("|".ToCharArray)
    ' project + '|' + activity
    Dim ProjectID As String = aVal(0)
    Dim ActivityID As String = aVal(1)
    Dim str As String = SIS.CT.DelayStatus30Days.GetPredCellHTML(ProjectID, ActivityID)
    Dim mRet As String = ActivityID & "|" & str
    Return mRet
  End Function

  Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
    'SIS.CT.RebuildPredcessors.RebuildPred(ProjectID)
  End Sub
End Class
