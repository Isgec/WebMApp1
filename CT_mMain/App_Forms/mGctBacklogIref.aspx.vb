Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctDashboard
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Dim Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
    ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
    ProjectName.Text = Request.QueryString("t_dsca")
  End Sub
  Protected Sub abc(ByVal sender As Object, ByVal e As EventArgs)

  End Sub
#Region " Backlog Item Ref. Table Upto Last 30 Days "
  Private Sub irefDelayAll_PreRender(sender As Object, e As EventArgs) Handles irefDelayAll.PreRender
    If ProjectID = "" Then Exit Sub
    Label11.Text = "(From " & Period.StDt.ToString("dd/MM/yyyy") & " Till " & DateAdd(DateInterval.Day, -31, Now).ToString("dd/MM/yyyy") & " - As On " & Now.ToString("dd/MM/yyyy") & ")"

    irefDelayAll.Controls.Add(GetItemRefWiseDelayAllTable(ProjectID))
  End Sub
  Private Function GetItemRefWiseDelayAllTable(ByVal t_cprj As String) As Table
    Dim data As List(Of SIS.CT.IrefDelayDays) = SIS.CT.IrefDelayDays.SelectListItemRefWiseDelayAll(t_cprj)
    Dim mStr As String = ""
    Dim tbl As New Table
    With tbl
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
      .Style.Add(HtmlTextWriterStyle.Margin, "5px 5px 5px 5px")
    End With
    'Write Header
    Dim th As New TableHeaderRow
    Dim btn As Button = Nothing
    th.Attributes.Add("style", "background-color:black;color:white;")
    th.TableSection = TableRowSection.TableHeader
    For i As Integer = 0 To 6
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .ColumnSpan = 2
        btn = New Button
        With btn
          .ClientIDMode = ClientIDMode.Static
          .Attributes.Add("class", "btn btn-sm btn-dark fix")
          .Attributes.Add("style", "white-space:normal;")
          .PostBackUrl = "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & t_cprj & "&t_cact="
        End With

        Select Case i
          Case 0
            .ColumnSpan = 1
            .RowSpan = 2
            .Text = "ITEM"
          Case 1
            btn.ID = "All" & t_cprj & "_" & "DESIGN"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "ENGINEERING"
            thc.Controls.Add(btn)
          Case 2
            btn.ID = "All" & t_cprj & "_" & "INDT"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "INDENTING"
            thc.Controls.Add(btn)
          Case 3
            btn.ID = "All" & t_cprj & "_" & "RFQ-TO-PO"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "RFQ-TO-PO"
            thc.Controls.Add(btn)
          Case 4
            btn.ID = "All" & t_cprj & "_" & "MFG"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "MANUFACTURING"
            thc.Controls.Add(btn)
          Case 5
            btn.ID = "All" & t_cprj & "_" & "EREC"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "ERECTION"
            thc.Controls.Add(btn)
          Case 6
            btn.ID = "All" & t_cprj & "_" & "OTHERS"
            btn.PostBackUrl &= btn.ID & "&ID=" & btn.ID
            btn.Text = "OTHERS"
            thc.Controls.Add(btn)
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    th = New TableHeaderRow
    th.Attributes.Add("style", "background-color:black;color:white;")
    th.TableSection = TableRowSection.TableHeader
    For i As Integer = 0 To 5
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Text = "START"
        th.Cells.Add(thc)
      End With
      thc = New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Text = "FINISH"
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    '==========
    'Write Data
    '===========
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    For Each dt As SIS.CT.IrefDelayDays In data
      tr = New TableRow
      '1. Item Reference
      tr.TableSection = TableRowSection.TableBody
      td = New TableCell
      td.Attributes.Add("style", "text-align:center;")
      btn = New Button
      With btn
        .ClientIDMode = ClientIDMode.Static
        .Attributes.Add("class", "btn btn-sm btn-outline-light text-dark fix")
        .ID = dt.aID & "_Item"
        .Attributes.Add("style", "white-space:normal;")
        .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
        .Text = dt.t_sub1
      End With
      td.Controls.Add(btn)
      tr.Cells.Add(td)
      '2. Start
      For i As Integer = 0 To 5
        td = New TableCell
        td.Attributes.Add("style", "text-align:center;")
        btn = New Button
        With btn
          .Attributes.Add("class", "btn btn-sm btn-outline-warning fix")
          .ClientIDMode = ClientIDMode.Static
          Select Case i
            Case 0
              .ID = dt.aID & "_D_s"
              .Text = dt.D_s_delay
            Case 1
              .ID = dt.aID & "_I_s"
              .Text = dt.I_s_delay
            Case 2
              .ID = dt.aID & "_R_s"
              .Text = dt.R_s_delay
            Case 3
              .ID = dt.aID & "_M_s"
              .Text = dt.M_s_delay
            Case 4
              .ID = dt.aID & "_E_s"
              .Text = dt.E_s_delay
            Case 5
              .ID = dt.aID & "_O_s"
              .Text = dt.O_s_delay
          End Select
          .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
        End With
        Try
          If Convert.ToDecimal(btn.Text) > 0 Then
            td.Controls.Add(btn)
          End If
        Catch ex As Exception
        End Try
        tr.Cells.Add(td)
        td = New TableCell
        td.Attributes.Add("style", "text-align:center;")
        btn = New Button
        With btn
          .Attributes.Add("class", "btn btn-sm btn-outline-warning fix")
          .ClientIDMode = ClientIDMode.Static
          Select Case i
            Case 0
              .ID = dt.aID & "_D_f"
              .Text = dt.D_f_delay
            Case 1
              .ID = dt.aID & "_I_f"
              .Text = dt.I_f_delay
            Case 2
              .ID = dt.aID & "_R_f"
              .Text = dt.R_f_delay
            Case 3
              .ID = dt.aID & "_M_f"
              .Text = dt.M_f_delay
            Case 4
              .ID = dt.aID & "_E_f"
              .Text = dt.E_f_delay
            Case 5
              .ID = dt.aID & "_O_f"
              .Text = dt.O_f_delay
          End Select
          .PostBackUrl = dt.GetRedirectLink & "&ID=" & btn.ID
        End With
        Try
          If Convert.ToDecimal(btn.Text) > 0 Then
            td.Controls.Add(btn)
          End If
        Catch ex As Exception
        End Try
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next

    Return tbl
  End Function

#End Region

End Class
