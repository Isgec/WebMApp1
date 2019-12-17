Imports System.Web.UI.DataVisualization.Charting
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctDashboardCostSheet
  Inherits System.Web.UI.Page
  Public Property t_ccod As String
    Get
      If ViewState("t_ccod") IsNot Nothing Then
        Return ViewState("t_ccod")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("t_ccod", value)
    End Set
  End Property

  Private Sub mGctDashboardFinancial_Load(sender As Object, e As EventArgs) Handles Me.Load
    Session("Home") = HttpContext.Current.Request.Url.AbsoluteUri
    t_ccod = F_t_ccod.SelectedValue
    If t_ccod = "" Then Exit Sub
    ContractName.Text = F_t_ccod.SelectedItem.Text
  End Sub


  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    If t_ccod = "" Then Exit Sub
    L_Customer.Text = SIS.CT.tpisg089.GetContractCustomer(t_ccod)
    Dim tmp As SIS.CT.costChart = Nothing
    Dim Dt1 As SIS.CT.costChart = SIS.CT.costChart.GetCostChart(t_ccod, "BA")
    Chart1 = SIS.CT.costChart.RenderChart(Chart1, Dt1)
    Try
      Chart1Data.InnerHtml = Dt1.GetDataTable(False, tmp)
    Catch ex As Exception
    End Try
    'Set Values
    LTBI.Text = tmp.PlannedY.Sum()
    LTAI.Text = tmp.ActualY.Sum()
    LTBO.Text = tmp.OPlannedY.Sum()
    LTAO.Text = tmp.OActualY.Sum()

    '2. Bud vs Act Cum
    Dim Dt2 As SIS.CT.costChart = SIS.CT.costChart.GetCostChart(t_ccod, "BAC")
    Chart2 = SIS.CT.costChart.RenderChart(Chart2, Dt2)
    Try
      Chart2Data.InnerHtml = Dt2.GetDataTable(True)
    Catch ex As Exception
    End Try

    '3. Net
    Dim Dt3 As SIS.CT.costChart = SIS.CT.costChart.GetCostChart(t_ccod, "NET")
    Chart3 = SIS.CT.costChart.RenderChartNet(Chart3, Dt3)
    Try
      Chart3Data.InnerHtml = Dt3.GetDataTableNet(False, tmp)
    Catch ex As Exception
    End Try
    LBN.Text = tmp.PlannedY.Sum
    LAN.Text = tmp.ActualY.Sum
    '4. Net
    Dim Dt4 As SIS.CT.costChart = SIS.CT.costChart.GetCostChart(t_ccod, "NETC")
    Chart4 = SIS.CT.costChart.RenderChartNet(Chart4, Dt4)
    Try
      Chart4Data.InnerHtml = Dt4.GetDataTableNet(True)
    Catch ex As Exception
    End Try

  End Sub

End Class
