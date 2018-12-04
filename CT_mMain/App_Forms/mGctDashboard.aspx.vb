Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctDashboard
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Dim Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = F_t_cprj.SelectedValue
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.StartFinish(ProjectID)
    ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
    ProjectName.Text = F_t_cprj.SelectedItem.Text
  End Sub
#Region " Main Overall Chart"
  Private Sub Chart1_PostPaint(sender As Object, e As ChartPaintEventArgs) Handles Chart1.PostPaint
    If TypeOf e.ChartElement Is Series AndAlso DirectCast(e.ChartElement, Series).Name = "Series2" Then
      Dim s As Series = e.Chart.Series(0)
      Dim cg As ChartGraphics = e.ChartGraphics

      For i As Integer = 0 To s.Points.Count - 1
        If DateTime.FromOADate(s.Points(i).XValue).Date = Now.AddDays(-90).Date Then
          Dim pos As System.Drawing.PointF = System.Drawing.PointF.Empty
          pos.X = CSng(cg.GetPositionFromAxis("ChartArea1", AxisName.X, s.Points(i + 1).XValue))
          pos.Y = CSng(cg.GetPositionFromAxis("ChartArea1", AxisName.Y, s.Points(i).YValues(0)))

          pos = cg.GetAbsolutePoint(pos)

          cg.Graphics.DrawPolygon(System.Drawing.Pens.Red, {New Drawing.Point(pos.X - 3, pos.Y), New Drawing.Point(pos.X, pos.Y - 3), New Drawing.Point(pos.X + 3, pos.Y), New Drawing.Point(pos.X, pos.Y + 3)})
        End If
      Next
    End If

  End Sub
  Private Sub OverallDataTable_PreRender(sender As Object, e As EventArgs) Handles OverallDataTable.PreRender
    If ProjectID = "" Then Exit Sub
    OverallDataTable.InnerHtml = SIS.CT.tpisg216.GetDataTable(F_t_cprj.SelectedValue)
  End Sub
#End Region

#Region " Delayed Activity Count Ageing Start & Finish"
  Private Sub ReviewSheetStart_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetStart.PreRender
    If ProjectID = "" Then Exit Sub
    Dim xx As List(Of SIS.CT.Ageing) = SIS.CT.Ageing.OverallStarted(ProjectID, "")
    For Each x As SIS.CT.Ageing In xx
      STE.Text = x.EARLY
      ST0.Text = x.DELAY0
      ST10.Text = x.DELAY10
      ST20.Text = x.DELAY20
      ST30.Text = x.DELAY30
      STZ.Text = x.DELAYZZ
    Next
    xx = SIS.CT.Ageing.OverallNOTStarted(ProjectID, "")
    For Each x As SIS.CT.Ageing In xx
      NST0.Text = x.DELAY0
      NST10.Text = x.DELAY10
      NST20.Text = x.DELAY20
      NST30.Text = x.DELAY30
      NSTZ.Text = x.DELAYZZ
    Next
  End Sub

  Private Sub ReviewSheetFinish_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetFinish.PreRender
    If ProjectID = "" Then Exit Sub
    Dim xx As List(Of SIS.CT.Ageing) = SIS.CT.Ageing.OverallFinished(ProjectID, "")
    For Each x As SIS.CT.Ageing In xx
      FDE.Text = x.EARLY
      FD0.Text = x.DELAY0
      FD10.Text = x.DELAY10
      FD20.Text = x.DELAY20
      FD30.Text = x.DELAY30
      FDZ.Text = x.DELAYZZ
    Next
    xx = SIS.CT.Ageing.OverallNOTFinished(ProjectID, "")
    For Each x As SIS.CT.Ageing In xx
      NFD0.Text = x.DELAY0
      NFD10.Text = x.DELAY10
      NFD20.Text = x.DELAY20
      NFD30.Text = x.DELAY30
      NFDZ.Text = x.DELAYZZ
    Next
  End Sub
  Protected Sub abc(ByVal sender As Object, ByVal e As EventArgs)
    If ProjectID = "" Then Exit Sub
    Dim btn As Button = CType(sender, Button)
    Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & ProjectID & "&ID=" & btn.ID & "&ListType=OverallAgeing&All=True"
    Response.Redirect(RedirectURL)
  End Sub

#End Region

#Region " Menu Item Clicks "
  Private Sub cmd30Days_Click(sender As Object, e As EventArgs) Handles cmd30Days.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdBacklog_Click(sender As Object, e As EventArgs) Handles cmdBacklog.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctBacklogIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdActivitySCurve_Click(sender As Object, e As EventArgs) Handles cmdActivitySCurve.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctActivitySCurve.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
      Response.Redirect(RedirectURL)
    End If
  End Sub
#End Region

End Class
