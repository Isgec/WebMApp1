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
  Private Sub mGctActivityDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("t_ccod") IsNot Nothing Then t_ccod = Request.QueryString("t_ccod")
    If Request.QueryString("t_nama") IsNot Nothing Then ProjectName = Request.QueryString("t_nama")
    SubHeader.Text = ProjectName
  End Sub

  Private Sub mGctBillingInfo_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If t_ccod = "" Then Exit Sub
    Dim tp309 As List(Of SIS.CT.tpisg309) = SIS.CT.tpisg309.GetMnYr(t_ccod)
    For Each t309 As SIS.CT.tpisg309 In tp309
      pnlBillingInfo.Controls.Add(GetMnYrTable(t309.t_ccod, t309.t_mnyr))
    Next

  End Sub
  Private Function GetMnYrTable(ByVal t_ccod As String, ByVal t_mnyr As String) As Table
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
    thc.Text = "Month/Year: " & t_mnyr
    thc.HorizontalAlign = HorizontalAlign.Center
    th.Cells.Add(thc)
    tbl.Rows.Add(th)
    th = New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    For i As Integer = 0 To 3
      thc = New TableCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        '.Font.Bold = True
        Select Case i
          Case 0
            .Text = ""
          Case 1
            .Text = "BUDGETED"
          Case 2
            .Text = "ACTUAL"
          Case 3
            .Text = "VARIANCE"
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
      td = New TableCell
      With td
        .Text = "Supply"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_sybd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_syac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_syvr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = "Erection"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_erbd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_erac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_ervr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = "Civil"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_clbd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_clac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_clvr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = "D&E"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_debd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_deac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_devr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = "Others"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_osbd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_osac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_osvr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      With td
        .Text = "TOTAL"
        .Font.Bold = True
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_tlbd.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_tlac.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      td = New TableCell
      With td
        .Text = dt.t_tlvr.ToString("n")
        .Attributes.Add("style", "text-align:center;")
      End With
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)

    Next


    Return tbl

  End Function

End Class
