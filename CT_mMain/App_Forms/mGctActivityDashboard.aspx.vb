Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctActivityDashboard
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
  Public Property ActivityID As String
    Get
      If ViewState("ActivityID") IsNot Nothing Then
        Return ViewState("ActivityID")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("ActivityID", value)
    End Set
  End Property
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing

  Private Sub mGctActivityDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    ActivityID = Request.QueryString("t_acty")
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    Period = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
    ProjectName.Text = SIS.CT.ctProjects.ctProjectsGetByID(ProjectID).t_dsca
    cmd30Days.Text = ActivityID & "-" & cmd30Days.Text
    cmdBacklog.Text = ActivityID & "-" & cmdBacklog.Text
    cmd30Next.Text = ActivityID & "-" & cmd30Next.Text
    Try
      ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
      ProjectActivityName.Text = ProjectID & " - " & ActivityID
    Catch ex As Exception
    End Try
  End Sub
#Region " Chart Render & Data Table "
  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetCTChart(ProjectID, ActivityID)
    Chart1 = SIS.CT.CTChart.RenderChart(Chart1, Dt, 10, 3)
    ActivityDataTable.InnerHtml = Dt.GetDataTable()
  End Sub
  Private Sub Chart1_Customize(sender As Object, e As EventArgs) Handles Chart1.Customize
    If ProjectID = "" Then Exit Sub
    Try
      'Dim xVal As Double = Chart1.Series("Actual").Points.Last.XValue
      'Chart1.Series("Planned").SmartLabelStyle.Enabled = False
      'Chart1.Series("Planned").SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes
      'Chart1.Series("Planned").SmartLabelStyle.IsMarkerOverlappingAllowed = False
      'Chart1.Series("Planned").SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Left
      'Chart1.Series("Planned").SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Box
      'Chart1.Series("Planned").SmartLabelStyle.CalloutLineWidth = 1

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
      'Chart1.Series("Actual").SmartLabelStyle.Enabled = False
      'Chart1.Series("Actual").SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes
      'Chart1.Series("Actual").SmartLabelStyle.IsMarkerOverlappingAllowed = False
      'Chart1.Series("Actual").SmartLabelStyle.MovingDirection = LabelAlignmentStyles.TopRight
      'Chart1.Series("Actual").SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Box
      'Chart1.Series("Actual").SmartLabelStyle.CalloutLineWidth = 1
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
#End Region

#Region " Ageing Tables "
  Private Sub ReviewSheetStart_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetStart.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    'Label3.Text = "(Last 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
    Dim xx As List(Of SIS.CT.Ageing) = SIS.CT.Ageing.OAActyStarted(ProjectID, ActivityID, "")
    For Each x As SIS.CT.Ageing In xx
      STE.Text = x.EARLY
      ST0.Text = x.DELAY0
      ST10.Text = x.DELAY10
      ST20.Text = x.DELAY20
      ST30.Text = x.DELAY30
      STZ.Text = x.DELAYZZ
    Next
    xx = SIS.CT.Ageing.OAActyNOTStarted(ProjectID, ActivityID, "")
    For Each x As SIS.CT.Ageing In xx
      NST0.Text = x.DELAY0
      NST10.Text = x.DELAY10
      NST20.Text = x.DELAY20
      NST30.Text = x.DELAY30
      NSTZ.Text = x.DELAYZZ
    Next

  End Sub
  Private Sub ReviewSheetFinish_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetFinish.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    'Label5.Text = "(Last 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
    Dim xx As List(Of SIS.CT.Ageing) = SIS.CT.Ageing.OAActyFinished(ProjectID, ActivityID, "")
    For Each x As SIS.CT.Ageing In xx
      FDE.Text = x.EARLY
      FD0.Text = x.DELAY0
      FD10.Text = x.DELAY10
      FD20.Text = x.DELAY20
      FD30.Text = x.DELAY30
      FDZ.Text = x.DELAYZZ
    Next
    xx = SIS.CT.Ageing.OAActyNOTFinished(ProjectID, ActivityID, "")
    For Each x As SIS.CT.Ageing In xx
      NFD0.Text = x.DELAY0
      NFD10.Text = x.DELAY10
      NFD20.Text = x.DELAY20
      NFD30.Text = x.DELAY30
      NFDZ.Text = x.DELAYZZ
    Next
  End Sub
  Protected Sub abc(ByVal sender As Object, ByVal e As EventArgs)
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    Dim btn As Button = CType(sender, Button)
    Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & ProjectID & "&ID=" & btn.ID & "&ListType=ActivityAgeing&All=False&t_acty=" & ActivityID
    Response.Redirect(RedirectURL)
  End Sub

#End Region
#Region " Menu Item Clicks "
  Private Sub cmd30Days_Click(sender As Object, e As EventArgs) Handles cmd30Days.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysActy.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&t_acty=" & ActivityID
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdBacklog_Click(sender As Object, e As EventArgs) Handles cmdBacklog.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysActy.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&t_acty=" & ActivityID & "&backlog="
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmd30Next_Click(sender As Object, e As EventArgs) Handles cmd30Next.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctNext30DaysActy.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&t_acty=" & ActivityID
      Response.Redirect(RedirectURL)
    End If
  End Sub

#End Region

End Class
