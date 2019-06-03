Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Partial Class mGctBillingInfo
  Inherits System.Web.UI.Page
  Private t_ccod As String = ""
  Private ProjectName As String = ""
  Private Divisor As Integer = 100000

  Private Sub mGctActivityDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("t_ccod") IsNot Nothing Then t_ccod = Request.QueryString("t_ccod")
    If Request.QueryString("t_nama") IsNot Nothing Then ProjectName = Request.QueryString("t_nama")
    SubHeader.Text = ProjectName
    ciSubHeader.Text = ProjectName
  End Sub

  Private Sub mGctBillingInfo_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Try
      If HttpContext.Current.Session("BrowserWidth") IsNot Nothing Then
        If Convert.ToInt32(HttpContext.Current.Session("BrowserWidth")) <= 1000 Then
          Divisor = 100000
        Else
          Divisor = 1
        End If
      End If
    Catch ex As Exception
    End Try

    If t_ccod = "" Then Exit Sub
    Dim tp309 As List(Of SIS.CT.tpisg309) = SIS.CT.tpisg309.GetMnYr(t_ccod)
    Dim First As Boolean = True
    Dim pnl As HtmlTableCell = Nothing
    For Each t309 As SIS.CT.tpisg309 In tp309
      pnl = New HtmlTableCell
      pnl.Controls.Add(GetMnYrFDTable(t_ccod, t309.t_mnyr, First))
      rowFD.Cells.Add(pnl)
      First = False
    Next

    Dim tp310 As List(Of SIS.CT.tpisg310) = SIS.CT.tpisg310.GetMnYr(t_ccod)
    First = True
    For Each t310 As SIS.CT.tpisg310 In tp310
      pnl = New HtmlTableCell
      pnl.Controls.Add(GetMnYrCITable(t_ccod, t310.t_moyr, First))
      rowCI.Cells.Add(pnl)
      First = False
    Next
    pnl = New HtmlTableCell
    pnl.Controls.Add(GetMnYrCI_TOTTable(t_ccod))
    rowCI.Cells.Add(pnl)

  End Sub
  Private Function GetMnYrFDTable(ByVal t_ccod As String, ByVal t_mnyr As String, ByVal isFirst As Boolean) As Table
    Dim tbl As New Table
    With tbl
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableRow
    Dim thc As New TableCell
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    thc = New TableCell
    thc.ColumnSpan = 4
    If isFirst Then
      thc.Text = "Month/Year: " & t_mnyr
    Else
      thc.Text = t_mnyr
    End If
    thc.HorizontalAlign = HorizontalAlign.Center
    th.Cells.Add(thc)
    tbl.Rows.Add(th)
    th = New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    Dim colFrom As Integer = IIf(isFirst, 0, 2)
    For i As Integer = colFrom To 2
      thc = New TableCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        '.Font.Bold = True
        Select Case i
          Case 0
            .Text = ""
          Case 1
            .Text = ""
          Case 2
            .Text = "VALUE"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tp309 As List(Of SIS.CT.tpisg309) = SIS.CT.tpisg309.UZ_tpisg309SelectList(t_mnyr, t_ccod)

    For Each dt As SIS.CT.tpisg309 In tp309

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Supply"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

        td = New TableCell

        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If


      td = New TableCell

      With td
        .Text = (dt.t_sybd / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell

        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_syac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell

        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_syvr / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Erection"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

        td = New TableCell
        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If
      td = New TableCell
      With td
        .Text = (dt.t_erbd / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_erac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ervr / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Civil"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

        td = New TableCell
        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If
      td = New TableCell
      With td
        .Text = (dt.t_clbd / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_clac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_clvr / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)


      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "TOTAL"
          .Font.Bold = True
          .BackColor = Drawing.Color.White
        End With
        tr.Cells.Add(td)

        td = New TableCell
        With td
          .Text = "Budgted"
          .Font.Bold = True
        End With
        tr.Cells.Add(td)

      End If
      td = New TableCell
      With td
        .Text = (dt.t_tlbd / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Actual"
          .Font.Bold = True
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_tlac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .Text = "Variance"
          .Font.Bold = True
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_tlvr / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

    Next


    Return tbl

  End Function
  Private Function GetMnYrCITable(ByVal t_ccod As String, ByVal t_mnyr As String, ByVal isFirst As Boolean) As Table
    Dim tbl As New Table
    With tbl
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableRow
    Dim thc As New TableCell
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    thc = New TableCell
    thc.ColumnSpan = 4
    If isFirst Then
      thc.Text = "Month/Year: " & t_mnyr
    Else
      thc.Text = t_mnyr
    End If
    thc.HorizontalAlign = HorizontalAlign.Center
    th.Cells.Add(thc)
    tbl.Rows.Add(th)
    th = New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    Dim colFrom As Integer = IIf(isFirst, 0, 2)
    For i As Integer = colFrom To 2
      thc = New TableCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        '.Font.Bold = True
        Select Case i
          Case 0
            .Text = ""
          Case 1
            .Text = ""
          Case 2
            .Text = "VALUE"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tp310 As List(Of SIS.CT.tpisg310) = SIS.CT.tpisg310.UZ_tpisg310SelectList(t_mnyr, t_ccod)

    For Each dt As SIS.CT.tpisg310 In tp310

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Inflow"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

        td = New TableCell

        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If


      td = New TableCell

      With td
        .Text = (dt.t_ifbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell

        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ifac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell

        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ifva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Outflow"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

        td = New TableCell
        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If
      td = New TableCell
      With td
        .Text = (dt.t_ofbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ofac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ofva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      If isFirst Then
        td = New TableCell
        With td
          .RowSpan = 3
          .Text = "Net"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

        td = New TableCell
        With td
          .Text = "Budgted"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If
      td = New TableCell
      With td
        .Text = (dt.t_ntbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Actual"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ntac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      If isFirst Then
        td = New TableCell
        With td
          .Text = "Variance"
          .Font.Bold = True
          .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
        End With
        tr.Cells.Add(td)

      End If

      td = New TableCell
      With td
        .Text = (dt.t_ntva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)




    Next


    Return tbl

  End Function

  Private Function GetMnYrCI_TOTTable(ByVal t_ccod As String) As Table
    Dim tbl As New Table
    With tbl
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableRow
    Dim thc As New TableCell
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    thc = New TableCell
    thc.Text = "&nbsp;"
    thc.HorizontalAlign = HorizontalAlign.Center
    th.Cells.Add(thc)
    tbl.Rows.Add(th)
    th = New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    thc = New TableCell
    With thc
      .Attributes.Add("style", "text-align:center;")
      .Text = "TOTAL"
      th.Cells.Add(thc)
    End With
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tp310 As List(Of SIS.CT.tpisg310) = SIS.CT.tpisg310.UZ_tpisg310TotalList(t_ccod)

    For Each dt As SIS.CT.tpisg310 In tp310

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      td = New TableCell

      With td
        .Text = (dt.t_ifbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black


      td = New TableCell
      With td
        .Text = (dt.t_ifac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      td = New TableCell
      With td
        .Text = (dt.t_ifva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 249, 230)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = (dt.t_ofbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black


      td = New TableCell
      With td
        .Text = (dt.t_ofac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      td = New TableCell
      With td
        .Text = (dt.t_ofva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(229, 242, 255)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = (dt.t_ntbu / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      td = New TableCell
      With td
        .Text = (dt.t_ntac / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black

      td = New TableCell
      With td
        .Text = (dt.t_ntva / Divisor).ToString("n")
        .Attributes.Add("style", "text-align:center;")
        .BackColor = System.Drawing.Color.FromArgb(255, 255, 179)
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)




    Next


    Return tbl

  End Function


End Class
