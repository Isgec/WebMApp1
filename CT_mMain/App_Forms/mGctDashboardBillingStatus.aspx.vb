Imports System.Web.UI.DataVisualization.Charting
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctDashboardBillingStatus
  Inherits System.Web.UI.Page
  Private Comp As String = "200"
  Private ContractCode As String = ""
  Private ContractDescription As String = ""
  Private Sub mGctDashboardBillingStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
    Comp = Request.QueryString("Company")
    ContractCode = Request.QueryString("ContractCode")
    ContractDescription = Request.QueryString("ContractDescription")

  End Sub

  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender
    If ContractCode = "" Then Exit Sub
    L_Customer.Text = SIS.CT.tpisg089.GetContractCustomer(ContractCode, Comp)
    Label2.Text = ContractDescription
    '1.Billing
    Dim Dt1 As SIS.CT.billingChart = Nothing
    Try
      Dt1 = SIS.CT.billingChart.GetChart(ContractCode, Comp)
      Chart1 = SIS.CT.billingChart.RenderChart(Chart1, Dt1)
      Chart1Data.InnerHtml = SIS.CT.billingChart.GetDataTable(Dt1, Comp)
    Catch ex As Exception
      Chart1Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try
    Try
      LTB.Text = Dt1.TotalBudget
      LTA.Text = Dt1.totalActual
      If Dt1.totalActual - Dt1.TotalBudget >= 0 Then
        LSTATUS.Text = "POSITIVE"
      Else
        LSTATUS.Text = "NEGATIVE"
      End If
    Catch ex As Exception
    End Try
    '1.Cumulative Billing
    Try
      Dim Dt2 As SIS.CT.billingChart = SIS.CT.billingChart.GetChart(ContractCode, Comp, True)
      Chart2 = SIS.CT.billingChart.RenderChart(Chart2, Dt2)
      Chart2Data.InnerHtml = SIS.CT.billingChart.GetDataTable(Dt2, Comp)
    Catch ex As Exception
      Chart2Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try
  End Sub

End Class
