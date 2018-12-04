Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Partial Class mGctActivityDashboard
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Private ActivityID As String = ""
  Private Period As SIS.CT.tpisg216.ProjectPeriod = Nothing
  Private Sub mGctActivityDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    ProjectID = Request.QueryString("t_cprj")
    ActivityID = Request.QueryString("t_acty")
    If ProjectID = "" Or ActivityID = "" Then
      Exit Sub
    End If
    Period = SIS.CT.tpisg216.StartFinish(ProjectID)
    ProjectName.Text = SIS.CT.ctProjects.ctProjectsGetByID(ProjectID).t_dsca
    cmd30Days.Text = ActivityID & "-" & cmd30Days.Text
    cmdBacklog.Text = ActivityID & "-" & cmdBacklog.Text
  End Sub
#Region " Chart Render & Data Table "
  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    Try
      ProjectPeriod.Text = Period.StDt.ToString("dd/MM/yyyy") & " - " & Period.FnDt.ToString("dd/MM/yyyy")
      ProjectActivityName.Text = ProjectID & " - " & ActivityID
    Catch ex As Exception
    End Try
    If Period IsNot Nothing Then
      Chart1.ChartAreas(0).AxisX.Minimum = Period.StDt.ToOADate
      Chart1.ChartAreas(0).AxisX.Maximum = Period.FnDt.ToOADate
    End If
  End Sub

  Private Sub ActivityDataTable_PreRender(sender As Object, e As EventArgs) Handles ActivityDataTable.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    ActivityDataTable.InnerHtml = SIS.CT.tpisg214.GetDataTable(ProjectID, ActivityID)
  End Sub

#End Region

#Region " Ageing Tables "
  Private Sub ReviewSheetStart_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetStart.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    Label3.Text = "(Last 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
    Dim xx As List(Of SIS.CT.tpisg214) = SIS.CT.tpisg214.SelectListForReviewTableStarted(ProjectID, ActivityID, "")
    For Each x As SIS.CT.tpisg214 In xx
      STE.Text = x.EARLY
      ST0.Text = x.DELAY0
      ST10.Text = x.DELAY10
      ST20.Text = x.DELAY20
      ST30.Text = x.DELAY30
    Next
    xx = SIS.CT.tpisg214.SelectListForReviewTableNOTStarted(ProjectID, ActivityID, "")
    For Each x As SIS.CT.tpisg214 In xx
      NST0.Text = x.DELAY0
      NST10.Text = x.DELAY10
      NST20.Text = x.DELAY20
      NST30.Text = x.DELAY30
    Next

  End Sub
  Private Sub ReviewSheetFinish_PreRender(sender As Object, e As EventArgs) Handles ReviewSheetFinish.PreRender
    If ProjectID = "" Or ActivityID = "" Then Exit Sub
    Label5.Text = "(Last 30 Days - As On " & Now.ToString("dd/MM/yyyy") & ")"
    Dim xx As List(Of SIS.CT.tpisg214) = SIS.CT.tpisg214.SelectListForReviewTableFinished(ProjectID, ActivityID, "")
    For Each x As SIS.CT.tpisg214 In xx
      FDE.Text = x.EARLY
      FD0.Text = x.DELAY0
      FD10.Text = x.DELAY10
      FD20.Text = x.DELAY20
      FD30.Text = x.DELAY30
    Next
    xx = SIS.CT.tpisg214.SelectListForReviewTableNOTFinished(ProjectID, ActivityID, "")
    For Each x As SIS.CT.tpisg214 In xx
      NFD0.Text = x.DELAY0
      NFD10.Text = x.DELAY10
      NFD20.Text = x.DELAY20
      NFD30.Text = x.DELAY30
    Next
  End Sub

#End Region


  Protected Sub abc(sender As Object, e As EventArgs)

  End Sub
#Region " Menu Item Clicks "
  Private Sub cmd30Days_Click(sender As Object, e As EventArgs) Handles cmd30Days.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctLast30DaysActy.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&t_acty=" & ActivityID
      Response.Redirect(RedirectURL)
    End If
  End Sub

  Private Sub cmdBacklog_Click(sender As Object, e As EventArgs) Handles cmdBacklog.Click
    If ProjectID <> "" Then
      Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctBacklogActy.aspx?t_cprj=" & ProjectID & "&t_dsca=" & ProjectName.Text & "&t_acty=" & ActivityID
      Response.Redirect(RedirectURL)
    End If
  End Sub

#End Region

End Class
