Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctDashboard
  Inherits System.Web.UI.Page

  Private Sub Chart1_PostPaint(sender As Object, e As ChartPaintEventArgs) Handles Chart1.PostPaint

  End Sub

  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    Chart1.AlternateText = ""
  End Sub

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    Chart1.DataBind()
    'rCharts.DataBind()
  End Sub

  Private Sub rCharts_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rCharts.ItemDataBound
    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
      Dim Chart2 As Chart = CType(e.Item.FindControl("Chart2"), Chart)
      AddHandler Chart2.PostPaint, AddressOf Chart2_PostPaint
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
End Class
