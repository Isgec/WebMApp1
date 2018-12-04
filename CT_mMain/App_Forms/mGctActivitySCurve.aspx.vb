Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctActivitySCurve
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Dim Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.StartFinish(ProjectID)
    ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
    ProjectName.Text = Request.QueryString("t_dsca")
  End Sub
  Protected Sub abc(ByVal sender As Object, ByVal e As EventArgs)

  End Sub

#Region " Other Charts"
  Private Sub rCharts_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rCharts.ItemDataBound
    If ProjectID = "" Then Exit Sub
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      Dim Chart2 As Chart = CType(e.Item.FindControl("Chart2"), Chart)
      AddHandler Chart2.PostPaint, AddressOf Chart2_PostPaint
      If Period IsNot Nothing Then
        Chart2.ChartAreas(0).AxisX.Minimum = Period.StDt.ToOADate
        Chart2.ChartAreas(0).AxisX.Maximum = Period.FnDt.ToOADate
      End If
    End If
  End Sub
  Private Sub Chart2_PostPaint(sender As Object, e As ChartPaintEventArgs)
    ' Make sure all series have been drawn before proceeding 
    If TypeOf e.ChartElement Is Series AndAlso DirectCast(e.ChartElement, Series).Name = "Series4" Then
      Dim s As Series = e.Chart.Series(0)
      Dim cg As ChartGraphics = e.ChartGraphics
      Dim max As Double = 60 ' s.Points.FindMaxByValue().YValues(0)

      ' Highlight the maximum sales this year 
      For i As Integer = 0 To s.Points.Count - 1
        If s.Points(i).YValues(0) = max Then
          ' Get relative coordinates of the data point 
          Dim pos As System.Drawing.PointF = System.Drawing.PointF.Empty
          pos.X = CSng(cg.GetPositionFromAxis("ChartArea2", AxisName.X, s.Points(i + 1).XValue))
          pos.Y = CSng(cg.GetPositionFromAxis("ChartArea2", AxisName.Y, max))

          ' Convert relative coordinates to absolute coordinates. 
          pos = cg.GetAbsolutePoint(pos)

          ' Draw concentric circles at the data point 
          'For radius As Integer = 10 To 39 Step 10
          '  cg.Graphics.DrawEllipse(System.Drawing.Pens.Red,
          '     CSng(pos.X - radius / 2),
          '     CSng(pos.Y - radius / 2), radius, radius)
          'Next
          cg.Graphics.DrawPolygon(System.Drawing.Pens.Red, {New Drawing.Point(pos.X - 2, pos.Y), New Drawing.Point(pos.X, pos.Y - 2), New Drawing.Point(pos.X + 2, pos.Y), New Drawing.Point(pos.X, pos.Y + 2)})
        End If
      Next
    End If

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

#End Region

End Class
