Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctLast30DaysActy
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Private ActivityID As String = ""
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private IsBacklog As Boolean = False
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    ActivityID = Request.QueryString("t_acty")
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
    ProjectName.Text = Request.QueryString("t_dsca")
    If Request.QueryString("backlog") IsNot Nothing Then IsBacklog = True
  End Sub
  Protected Sub abc(ByVal sender As Object, ByVal e As EventArgs)

  End Sub


#Region " Item Ref. Table Last 30 Days"
  Private Sub irefDelay30d_PreRender(sender As Object, e As EventArgs) Handles irefDelay30d.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    'BaselineStart.Text = "Baseline Start: " & Period.StDt.ToString("dd/MM/yyyy")
    'BaselineFinish.Text = "Baseline Finish: " & Period.FnDt.ToString("dd/MM/yyyy")
    Dim lDt As DateTime = SIS.CT.DelayStatus30Days.LastUpdatedOn(ProjectID)
    If IsBacklog Then
      Label9.Text = "(Backlog-As On: " & Now.ToString("dd/MM/yyyy") & "-Updated On: " & lDt.ToString("dd/MM/yyyy") & ")"
    Else
      Label9.Text = "(Last 30 Days-As On: " & Now.ToString("dd/MM/yyyy") & "-Updated On: " & lDt.ToString("dd/MM/yyyy") & ")"
    End If
    Dim x As SIS.CT.DelayStatus30Days.ProjectDates = SIS.CT.DelayStatus30Days.OverAllImpactOnCommissioning(ProjectID)
    'Initial.Text = "Baseline Commissioning: " & x.Initial.ToString("dd/MM/yyyy")
    'Contractual.Text = "Contractual Commissioning: " & x.Contractual.ToString("dd/MM/yyyy")
    'Expected.Text = "Expected Commissioning: " & x.Expected.ToString("dd/MM/yyyy")
    'Overall.Text = "Expected Delay-Commissioning: " & x.TotalDays & IIf(x.CalenderDays <> x.TotalDays, " / " & x.CalenderDays, "")
    irefDelay30d.Controls.Add(GetTable(ProjectID))
  End Sub
  Private Function GetTable(ByVal t_cprj As String) As Table
    Dim data As List(Of SIS.CT.DelayStatus30Days) = SIS.CT.DelayStatus30Days.SelectItems(t_cprj, ActivityID, IsBacklog)
    data.Sort(Function(x, y) x.t_cact.CompareTo(y.t_cact))
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
    Dim thc As TableHeaderCell = Nothing
    th.Attributes.Add("style", "background-color:black;color:white;")
    th.TableSection = TableRowSection.TableHeader

    thc = New TableHeaderCell
    thc.Attributes.Add("style", "text-align:left;")
    thc.RowSpan = 2
    thc.Text = "ITEM"
    th.Cells.Add(thc)

    thc = New TableHeaderCell
    thc.Attributes.Add("style", "text-align:center;")
    thc.ColumnSpan = 2
    btn = New Button
    With btn
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "btn btn-dark btn-sm"
      .Attributes.Add("style", "white-space:normal;")
      .PostBackUrl = "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & t_cprj & "&t_cact=&ID=ACTIVITY&all=false&t_acty=" & ActivityID & IIf(IsBacklog, "&backlog=", "")
      .Font.Bold = True
      .ID = ActivityID
      .Text = ActivityID
    End With
    Select Case ActivityID
      Case "DESIGN"
        btn.Text = "ENGINEERING"
      Case "INDT"
        btn.Text = "INDENTING"
      Case "EREC"
        btn.Text = "ERECTION"
    End Select
    thc.Controls.Add(btn)
    th.Cells.Add(thc)


    If ActivityID = "DESIGN" Then
      thc = New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .RowSpan = 2
        .Text = "TOTAL DOCUMENTS"
      End With
      th.Cells.Add(thc)
      thc = New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .RowSpan = 2
        .Text = "DOCUMENTS RELEASED"
      End With
      th.Cells.Add(thc)
    End If

    tbl.Rows.Add(th)

    th = New TableHeaderRow
    th.Attributes.Add("style", "background-color:black;color:white;")
    th.TableSection = TableRowSection.TableHeader
    thc = New TableHeaderCell
    With thc
      .Attributes.Add("style", "text-align:center;")
      .Text = "Start"
      .Font.Bold = False
      th.Cells.Add(thc)
    End With
    thc = New TableHeaderCell
    With thc
      .Attributes.Add("style", "text-align:center;")
      .Text = "Finish"
      .Font.Bold = False
      th.Cells.Add(thc)
    End With
    tbl.Rows.Add(th)
    '==========
    'Write Data
    '===========
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tr2 As TableRow = Nothing
    Dim td2 As TableCell = Nothing
    For Each dt As SIS.CT.DelayStatus30Days In data
      tr = New TableRow
      tr2 = New TableRow
      '1. Item Reference
      tr.TableSection = TableRowSection.TableBody
      tr2.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.Honeydew
        tr2.BackColor = System.Drawing.Color.Honeydew
      End If
      RowColor = Not RowColor
      td = New TableCell
      td.Attributes.Add("style", "text-align:left;")
      td.Attributes.Add("rowspan", "2")
      btn = New Button
      With btn
        .ClientIDMode = ClientIDMode.Static
        .CssClass = "btn btn-outline-light text-dark btn-sm"
        .ID = dt.t_cact
        .Attributes.Add("style", "white-space:normal;text-align:left;")
        .PostBackUrl = dt.GetRedirectLink & "&ID=DATA_S&all=false&t_acty=" & ActivityID & IIf(IsBacklog, "&backlog=", "")
        .Text = dt.t_sub1
      End With
      td.Controls.Add(btn)
      tr.Cells.Add(td)
      '2. Start
      Dim xx As SIS.CT.DelayStatus30Days.activityType = Nothing
      Select Case ActivityID
          Case "DESIGN"
            xx = dt.Design
          Case "INDT"
            xx = dt.Indt
          Case "RFQ-TO-PO"
            xx = dt.RfqToPO
          Case "MFG"
            xx = dt.Mfg
          Case "EREC"
            xx = dt.Erec
          Case "DISP"
            xx = dt.Disp
          Case "RECPT"
            xx = dt.Recpt
          Case "OTHERS"
            xx = dt.Others
        End Select

        td = New TableCell
        td2 = New TableCell

      If Not xx.Initialized Then
        td.RowSpan = 2
        td.Text = "<i class='fa fa-close fa-2x'></i>"
        td.Attributes.Add("style", "text-align:center;")
        tr.Cells.Add(td)
        td = New TableCell
        td.RowSpan = 2
        td.Attributes.Add("style", "text-align:center;")
        td.Text = "<i class='fa fa-close fa-2x'></i>"
        tr.Cells.Add(td)
      Else
        td.Attributes.Add("style", "text-align:center;")
        td2.Attributes.Add("style", "text-align:center;")
        btn = New Button
        With btn
          .CssClass = "btn btn-outline-dark btn-sm"
          .ClientIDMode = ClientIDMode.Static
          .ID = dt.t_cact & "_" & ActivityID & "_S"
          .Text = xx.StartDelay
          If Not xx.IsCurrent Then
            If xx.Started And xx.Finished Then
              .CssClass = "btn btn-outline-success btn-sm"
            ElseIf xx.Started And Not xx.Finished Then
              .CssClass = "btn btn-outline-info btn-sm"
            Else
              .CssClass = "btn btn-outline-danger btn-sm"
            End If
          Else
            If xx.Started And xx.Finished Then
              .CssClass = "btn btn-success btn-sm"
            ElseIf xx.Started And Not xx.Finished Then
              .CssClass = "btn btn-info btn-sm"
            Else
              .CssClass = "btn btn-danger btn-sm"
            End If
          End If
          .PostBackUrl = dt.GetRedirectLink & "&ID=DATA_S&all=false&t_acty=" & ActivityID & IIf(IsBacklog, "&backlog=", "")
        End With
        td.Text = "" 'xx.SelfStartDelay
        td.Font.Bold = True
        td.Font.Size = FontUnit.Point(11)

        td2.Controls.Add(btn)
        tr2.Cells.Add(td2)
        tr.Cells.Add(td)
        td = New TableCell
        td2 = New TableCell
        td.Attributes.Add("style", "text-align:center;")
        td2.Attributes.Add("style", "text-align:center;")
        btn = New Button
        With btn
          .CssClass = "btn btn-outline-dark btn-sm"
          .ClientIDMode = ClientIDMode.Static
          .ID = dt.t_cact & "_" & ActivityID & "_F"
          .Text = xx.FinishDelay
          If Not xx.IsCurrent Then
            If xx.Started And xx.Finished Then
              .CssClass = "btn btn-outline-success btn-sm"
            ElseIf xx.Started And Not xx.Finished Then
              .CssClass = "btn btn-outline-info btn-sm"
            Else
              .CssClass = "btn btn-outline-danger btn-sm"
            End If
          Else
            If xx.Started And xx.Finished Then
              .CssClass = "btn btn-success btn-sm"
            ElseIf xx.Started And Not xx.Finished Then
              .CssClass = "btn btn-info btn-sm"
            Else
              .CssClass = "btn btn-danger btn-sm"
            End If
          End If
          .PostBackUrl = dt.GetRedirectLink & "&ID=DATA_S&all=false&t_acty=" & ActivityID & IIf(IsBacklog, "&backlog=", "")
        End With
        td.Text = xx.SelfFinishDelay
        td.Font.Bold = True
        td.Font.Size = FontUnit.Point(11)
        td2.Controls.Add(btn)
        tr2.Cells.Add(td2)
        tr.Cells.Add(td)
      End If

      '3.
      If ActivityID = "DESIGN" Then
        td = New TableCell
        td.Attributes.Add("style", "text-align:Center;")
        td.Attributes.Add("rowspan", "2")

        btn = New Button
        With btn
          .CssClass = "btn btn-outline-primary btn-sm"
          .ClientIDMode = ClientIDMode.Static
          .ID = dt.t_cact & "_" & ActivityID & "_DT"
          .Text = dt.TotalDocs
          If Not xx.IsCurrent Then
            If dt.ReleasedDocs = dt.TotalDocs Then
              .CssClass = "btn btn-outline-success btn-sm"
            ElseIf dt.ReleasedDocs > 0 Then
              .CssClass = "btn btn-outline-info btn-sm"
            Else
              .CssClass = "btn btn-outline-danger btn-sm"
            End If
          Else
            If dt.ReleasedDocs = dt.TotalDocs Then
              .CssClass = "btn btn-success btn-sm"
            ElseIf dt.ReleasedDocs > 0 Then
              .CssClass = "btn btn-info btn-sm"
            Else
              .CssClass = "btn btn-danger btn-sm"
            End If
          End If
          .PostBackUrl = dt.GetDocumentLink & "&ID=DT"
        End With
        td.Controls.Add(btn)
        tr.Cells.Add(td)

        td = New TableCell
        td.Attributes.Add("style", "text-align:Center;")
        td.Attributes.Add("rowspan", "2")
        btn = New Button
        With btn
          .CssClass = "btn btn-outline-primary btn-sm"
          .ClientIDMode = ClientIDMode.Static
          .ID = dt.t_cact & "_" & ActivityID & "_DR"
          .Text = dt.ReleasedDocs
          If Not xx.IsCurrent Then
            If dt.ReleasedDocs = dt.TotalDocs Then
              .CssClass = "btn btn-outline-success btn-sm"
            ElseIf dt.ReleasedDocs > 0 Then
              .CssClass = "btn btn-outline-info btn-sm"
            Else
              .CssClass = "btn btn-outline-danger btn-sm"
            End If
          Else
            If dt.ReleasedDocs = dt.TotalDocs Then
              .CssClass = "btn btn-success btn-sm"
            ElseIf dt.ReleasedDocs > 0 Then
              .CssClass = "btn btn-info btn-sm"
            Else
              .CssClass = "btn btn-danger btn-sm"
            End If
          End If
          .PostBackUrl = dt.GetDocumentLink & "&ID=DR"
        End With
        td.Controls.Add(btn)
        tr.Cells.Add(td)
      End If

      tbl.Rows.Add(tr)
      tbl.Rows.Add(tr2)
    Next

    Return tbl
  End Function
  'Private Function GetItemRefWiseDelay30dTable(ByVal t_cprj As String) As Table
  '  Dim data As List(Of SIS.CT.IrefDelayDays) = SIS.CT.IrefDelayDays.SelectListItemRefWiseDelay30d(t_cprj)
  '  Dim mStr As String = ""
  '  Dim tbl As New Table
  '  With tbl
  '    .CssClass = "table-bordered"
  '    .Width = Unit.Percentage(100)
  '    .Style.Add(HtmlTextWriterStyle.Margin, "5px 5px 5px 5px")
  '  End With
  '  'Write Header
  '  Dim th As New TableHeaderRow
  '  Dim btn As Button = Nothing
  '  th.Attributes.Add("style", "background-color:black;color:white;")
  '  th.TableSection = TableRowSection.TableHeader
  '  For i As Integer = 0 To 7
  '    Dim thc As New TableHeaderCell
  '    With thc
  '      .Attributes.Add("style", "text-align:center;")
  '      .ColumnSpan = 2
  '      btn = New Button
  '      With btn
  '        .ClientIDMode = ClientIDMode.Static
  '        .CssClass = "btn btn-dark btn-sm"
  '        .Attributes.Add("style", "white-space:normal;")
  '        .PostBackUrl = "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & t_cprj & "&t_cact="
  '      End With

  '      Select Case i
  '        Case 0
  '          .ColumnSpan = 1
  '          .RowSpan = 2
  '          .Text = "ITEM"
  '        Case 1
  '          btn.ID = t_cprj & "_" & "DESIGN"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "ENGINEERING"
  '          thc.Controls.Add(btn)
  '        Case 2
  '          btn.ID = t_cprj & "_" & "INDT"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "INDENTING"
  '          thc.Controls.Add(btn)
  '        Case 3
  '          btn.ID = t_cprj & "_" & "RFQ-TO-PO"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "RFQ-TO-PO"
  '          thc.Controls.Add(btn)
  '        Case 4
  '          btn.ID = t_cprj & "_" & "MFG"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "MANUFACTURING"
  '          thc.Controls.Add(btn)
  '        Case 5
  '          btn.ID = t_cprj & "_" & "EREC"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "ERECTION"
  '          thc.Controls.Add(btn)
  '        Case 6
  '          btn.ID = t_cprj & "_" & "OTHERS"
  '          btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
  '          btn.Text = "OTHERS"
  '          thc.Controls.Add(btn)
  '        Case 7
  '          .ColumnSpan = 1
  '          .RowSpan = 2
  '          .Text = "REASONS"
  '      End Select
  '      th.Cells.Add(thc)
  '    End With
  '  Next
  '  tbl.Rows.Add(th)
  '  th = New TableHeaderRow
  '  th.Attributes.Add("style", "background-color:black;color:white;")
  '  th.TableSection = TableRowSection.TableHeader
  '  For i As Integer = 0 To 5
  '    Dim thc As New TableHeaderCell
  '    With thc
  '      .Attributes.Add("style", "text-align:center;")
  '      .Text = "START"
  '      th.Cells.Add(thc)
  '    End With
  '    thc = New TableHeaderCell
  '    With thc
  '      .Attributes.Add("style", "text-align:center;")
  '      .Text = "FINISH"
  '      th.Cells.Add(thc)
  '    End With
  '  Next
  '  tbl.Rows.Add(th)
  '  '==========
  '  'Write Data
  '  '===========
  '  Dim tr As TableRow = Nothing
  '  Dim td As TableCell = Nothing
  '  Dim tr2 As TableRow = Nothing
  '  Dim td2 As TableCell = Nothing
  '  For Each dt As SIS.CT.IrefDelayDays In data
  '    tr = New TableRow
  '    tr2 = New TableRow
  '    '1. Item Reference
  '    tr.TableSection = TableRowSection.TableBody
  '    tr2.TableSection = TableRowSection.TableBody
  '    td = New TableCell
  '    td.Attributes.Add("style", "text-align:left;")
  '    td.Attributes.Add("rowspan", "2")
  '    btn = New Button
  '    With btn
  '      .ClientIDMode = ClientIDMode.Static
  '      .CssClass = "btn btn-outline-light text-dark btn-sm"
  '      .ID = dt.ID & "_Item"
  '      .Attributes.Add("style", "white-space:normal;text-align:left;")
  '      .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
  '      .Text = dt.t_sub1
  '    End With
  '    td.Controls.Add(btn)
  '    tr.Cells.Add(td)
  '    '2. Start
  '    Dim L_s As Integer = 0
  '    Dim L_f As Integer = 0
  '    For i As Integer = 0 To 5
  '      td = New TableCell
  '      td2 = New TableCell
  '      td.Attributes.Add("style", "text-align:center;")
  '      td2.Attributes.Add("style", "text-align:center;")
  '      btn = New Button
  '      With btn
  '        .CssClass = "btn btn-outline-dark btn-sm"
  '        .ClientIDMode = ClientIDMode.Static
  '        Select Case i
  '          Case 0
  '            .ID = dt.ID & "_D_s"
  '            .Text = dt.D_s_delay
  '            Select Case dt.D_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            L_s = dt.D_s_delay
  '            tr2.Cells.Add(td2)
  '          Case 1
  '            .ID = dt.ID & "_I_s"
  '            .Text = dt.I_s_delay
  '            Select Case dt.I_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.I_s_delay - L_s <> 0 Then
  '              td2.Text = "(" & dt.I_s_delay - L_s & ")"
  '            End If
  '            L_s = dt.I_s_delay
  '            tr2.Cells.Add(td2)
  '          Case 2
  '            .ID = dt.ID & "_R_s"
  '            .Text = dt.R_s_delay
  '            Select Case dt.R_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.R_s_delay - L_s <> 0 Then
  '              td2.Text = "(" & dt.R_s_delay - L_s & ")"
  '            End If
  '            L_s = dt.R_s_delay
  '            tr2.Cells.Add(td2)
  '          Case 3
  '            .ID = dt.ID & "_M_s"
  '            .Text = dt.M_s_delay
  '            Select Case dt.M_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.M_s_delay - L_s <> 0 Then
  '              td2.Text = "(" & dt.M_s_delay - L_s & ")"
  '            End If
  '            L_s = dt.M_s_delay
  '            tr2.Cells.Add(td2)
  '          Case 4
  '            .ID = dt.ID & "_E_s"
  '            .Text = dt.E_s_delay
  '            Select Case dt.E_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.E_s_delay - L_s <> 0 Then
  '              td2.Text = "(" & dt.E_s_delay - L_s & ")"
  '            End If
  '            L_s = dt.E_s_delay
  '            tr2.Cells.Add(td2)
  '          Case 5
  '            .ID = dt.ID & "_O_s"
  '            .Text = dt.O_s_delay
  '            Select Case dt.O_t_s
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.O_s_delay - L_s <> 0 Then
  '              td2.Text = "(" & dt.O_s_delay - L_s & ")"
  '            End If
  '            L_s = dt.O_s_delay
  '            tr2.Cells.Add(td2)
  '        End Select
  '        .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
  '      End With
  '      Try
  '        If Convert.ToDecimal(btn.Text) > 0 Then
  '          td.Controls.Add(btn)
  '        End If
  '      Catch ex As Exception
  '      End Try
  '      tr.Cells.Add(td)
  '      td = New TableCell
  '      td2 = New TableCell
  '      td.Attributes.Add("style", "text-align:center;")
  '      td2.Attributes.Add("style", "text-align:center;")
  '      btn = New Button
  '      With btn
  '        .CssClass = "btn btn-outline-dark btn-sm"
  '        .ClientIDMode = ClientIDMode.Static
  '        Select Case i
  '          Case 0
  '            .ID = dt.ID & "_D_f"
  '            .Text = dt.D_f_delay
  '            Select Case dt.D_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            L_f = dt.D_f_delay
  '            tr2.Cells.Add(td2)
  '          Case 1
  '            .ID = dt.ID & "_I_f"
  '            .Text = dt.I_f_delay
  '            Select Case dt.I_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.I_f_delay - L_f <> 0 Then
  '              td2.Text = "(" & dt.I_f_delay - L_f & ")"
  '            End If
  '            L_f = dt.I_f_delay
  '            tr2.Cells.Add(td2)
  '          Case 2
  '            .ID = dt.ID & "_R_f"
  '            .Text = dt.R_f_delay
  '            Select Case dt.R_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.R_f_delay - L_f <> 0 Then
  '              td2.Text = "(" & dt.R_f_delay - L_f & ")"
  '            End If
  '            L_f = dt.R_f_delay
  '            tr2.Cells.Add(td2)
  '          Case 3
  '            .ID = dt.ID & "_M_f"
  '            .Text = dt.M_f_delay
  '            Select Case dt.M_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.M_f_delay - L_f <> 0 Then
  '              td2.Text = "(" & dt.M_f_delay - L_f & ")"
  '            End If
  '            L_f = dt.M_f_delay
  '            tr2.Cells.Add(td2)
  '          Case 4
  '            .ID = dt.ID & "_E_f"
  '            .Text = dt.E_f_delay
  '            Select Case dt.E_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.E_f_delay - L_f <> 0 Then
  '              td2.Text = "(" & dt.E_f_delay - L_f & ")"
  '            End If
  '            L_f = dt.E_f_delay
  '            tr2.Cells.Add(td2)
  '          Case 5
  '            .ID = dt.ID & "_O_f"
  '            .Text = dt.O_f_delay
  '            Select Case dt.O_t_f
  '              Case "3"
  '                .CssClass = "btn btn-outline-success btn-sm"
  '              Case "2"
  '                .CssClass = "btn btn-info btn-sm"
  '              Case "1"
  '                .CssClass = "btn btn-outline-danger btn-sm"
  '            End Select
  '            If dt.O_f_delay - L_f <> 0 Then
  '              td2.Text = "(" & dt.O_f_delay - L_f & ")"
  '            End If
  '            L_f = dt.O_f_delay
  '            tr2.Cells.Add(td2)
  '        End Select
  '        .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
  '      End With
  '      Try
  '        If Convert.ToDecimal(btn.Text) > 0 Then
  '          td.Controls.Add(btn)
  '        End If
  '      Catch ex As Exception
  '      End Try
  '      tr.Cells.Add(td)
  '    Next
  '    tbl.Rows.Add(tr)
  '    tbl.Rows.Add(tr2)
  '  Next

  '  Return tbl
  'End Function
#End Region
  Private Sub cmdBase_Click(sender As Object, e As EventArgs) Handles cmdBase.Click
    If cmdBase.Text = "BASE" Then
      Session("BasedOn") = "OUTLOOK"
      cmdBase.Text = "OUTLOOK"
    Else
      Session("BasedOn") = "BASE"
      cmdBase.Text = "BASE"
    End If
  End Sub

End Class
