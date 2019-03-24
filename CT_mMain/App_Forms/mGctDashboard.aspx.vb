Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctDashboard
  Inherits System.Web.UI.Page
  Public Property ProjectID As String
    Get
      If ViewState("ProjectID") IsNot Nothing Then
        Return ViewState("ProjectID")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("ProjectID", value)
    End Set
  End Property
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private LastUpdated As DateTime = Nothing
  Private Sub mGctDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    Session("BasedOn") = "BASE"
    Session("Home") = HttpContext.Current.Request.Url.AbsoluteUri
    ProjectID = F_t_cprj.SelectedValue
    If ProjectID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
    ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
    ProjectName.Text = F_t_cprj.SelectedItem.Text
    LastUpdated = SIS.CT.DelayStatus30Days.LastUpdatedOn(ProjectID)
    LUpdated.Text = "(Last Updated On: " & LastUpdated & ")"
  End Sub
#Region "  Delayed Activity Count Ageing Start & Finish"
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
#Region "  Menu Item Clicks "
  Private Sub cmd30Days_Click(sender As Object, e As EventArgs) Handles cmd30Days.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdBacklog_Click(sender As Object, e As EventArgs) Handles cmdBacklog.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&backlog="
      Response.Redirect(RedirectURL)
    End If
  End Sub
  Private Sub cmd30Next_Click(sender As Object, e As EventArgs) Handles cmd30Next.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctNext30DaysIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
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
#Region "  Chart Render "
  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetCTChart(ProjectID)
    Chart1 = SIS.CT.CTChart.RenderChart(Chart1, Dt)
    Try
      OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart1_Customize(sender As Object, e As EventArgs) Handles Chart1.Customize
    If ProjectID = "" Then Exit Sub
    Try
      'Dim xVal As Double = Chart1.Series("Actual").Points.Last.XValue
      'For Each pt As DataPoint In Chart1.Series("Planned").Points
      '  If pt.XValue = xVal Then
      '    pt.Label = "#VALX{dd-MM-yyyy}, #VALY{##0.00}"
      '    pt.LabelBorderColor = Drawing.Color.Pink
      '    pt.LabelBorderWidth = 1
      '    pt.LabelBorderDashStyle = ChartDashStyle.Solid
      '    pt.LabelForeColor = Drawing.Color.OrangeRed
      '    pt.IsValueShownAsLabel = True
      '  End If
      'Next
      'Dim xt As DataPoint = Chart1.Series("Actual").Points.Last
      'With xt
      '  .IsValueShownAsLabel = True
      '  .Label = "#VALY{##0.00}"
      '  .LabelBorderColor = Drawing.Color.CadetBlue
      '  .LabelBorderWidth = 1
      '  .LabelBorderDashStyle = ChartDashStyle.Solid
      '  .LabelForeColor = Drawing.Color.DarkBlue
      'End With
    Catch ex As Exception

    End Try
  End Sub

  Private Sub cmdDelayed_Click(sender As Object, e As EventArgs) Handles cmdDelayed.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysIref.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&delayed="
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdFinance_Click(sender As Object, e As EventArgs) Handles cmdFinance.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctDashboardFinancial.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text
      Response.Redirect(RedirectURL)
    End If

  End Sub



#End Region
End Class
