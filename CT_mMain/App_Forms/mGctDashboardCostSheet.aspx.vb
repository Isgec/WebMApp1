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
  Private Comp As String = "200"

  Private Sub mGctDashboardFinancial_Load(sender As Object, e As EventArgs) Handles Me.Load
    t_ccod = F_t_ccod.SelectedValue
    If t_ccod = "" Then Exit Sub
    ContractName.Text = F_t_ccod.SelectedItem.Text
    If Request.QueryString("Company") IsNot Nothing Then
      Comp = Request.QueryString("Company")
    End If

  End Sub


  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    If t_ccod = "" Then Exit Sub
    L_Customer.Text = SIS.CT.tpisg089.GetContractCustomer(t_ccod, Comp)

    '1.Inflow
    Try
      Dim Dt1 As SIS.CT.costChart = SIS.CT.costChart.GetChart(t_ccod, Comp, "I")
      Chart1 = SIS.CT.costChart.RenderChart(Chart1, Dt1)
      Chart1Data.InnerHtml = SIS.CT.costChart.GetDataTable(Dt1, Comp)
      LTBI.Text = Dt1.TotalBudget
      LTAI.Text = Dt1.TotalActual
    Catch ex As Exception
      Chart1Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try

    '2. Outflow
    Try
      Dim Dt5 As SIS.CT.costChart = SIS.CT.costChart.GetChart(t_ccod, Comp, "O")
      Chart5 = SIS.CT.costChart.RenderChart(Chart5, Dt5)
      Chart5Data.InnerHtml = SIS.CT.costChart.GetDataTable(Dt5, Comp)
      LTBO.Text = Dt5.TotalBudget
      LTAO.Text = Dt5.TotalActual
    Catch ex As Exception
      Chart5Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try

    '3. Net Cumulative
    Try
      Dim Dt4 As SIS.CT.costChart = SIS.CT.costChart.GetChart(t_ccod, Comp, "NET", True)
      Chart4 = SIS.CT.costChart.RenderChart(Chart4, Dt4)
      Chart4Data.InnerHtml = SIS.CT.costChart.GetDataTable(Dt4, Comp)
      LBN.Text = (Convert.ToDecimal(LTBI.Text) - Convert.ToDecimal(LTBO.Text)).ToString("n")
      LAN.Text = (Convert.ToDecimal(LTAI.Text) - Convert.ToDecimal(LTAO.Text)).ToString("n")
    Catch ex As Exception
      Chart4Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try
    Try
      If Convert.ToDecimal(LAN.Text) - Convert.ToDecimal(LBN.Text) >= 0 Then
        LSTATUS.Text = "POSITIVE"
      Else
        LSTATUS.Text = "NEGATIVE"
      End If
    Catch ex As Exception
      LSTATUS.Text = ex.Message
    End Try

  End Sub

  Private Sub cmdBilling_Click(sender As Object, e As EventArgs) Handles cmdBilling.Click
    If t_ccod = "" Then Exit Sub
    Response.Redirect("~/CT_mMain/App_Forms/mGctDashboardBillingStatus.aspx?Company=" & Comp & "&ContractCode=" & t_ccod & "&ContractDescription=" & ContractName.Text)
  End Sub

  Private Sub cmdOutstanding_Click(sender As Object, e As EventArgs) Handles cmdOutstanding.Click
    If t_ccod = "" Then Exit Sub
    Response.Redirect("~/CT_mMain/App_Forms/mGctDashboardOutstandingStatus.aspx?Company=" & Comp & "&ContractCode=" & t_ccod & "&ContractDescription=" & ContractName.Text)
  End Sub

  Private Sub cmdCoverSheet_Click(sender As Object, e As EventArgs) Handles cmdCoverSheet.Click
    If t_ccod = "" Then Exit Sub
    Response.Redirect("~/CT_mMain/App_Forms/mGctCoverSheet.aspx?Company=" & Comp & "&ContractCode=" & t_ccod & "&ContractDescription=" & ContractName.Text)
  End Sub
End Class
