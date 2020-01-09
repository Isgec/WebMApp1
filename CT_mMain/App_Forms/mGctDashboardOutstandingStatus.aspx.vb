Imports System.Web.UI.DataVisualization.Charting
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctDashboardOutstandingStatus
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
    '1.Outstanding
    Try
      Dim Dt1 As SIS.CT.outstandingChart = SIS.CT.outstandingChart.GetChart(ContractCode, Comp)
      Chart1 = SIS.CT.outstandingChart.RenderChart(Chart1, Dt1)
      Chart1Data.InnerHtml = SIS.CT.outstandingChart.GetDataTable(Dt1, Comp)
    Catch ex As Exception
      Chart1Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try


  End Sub

End Class
