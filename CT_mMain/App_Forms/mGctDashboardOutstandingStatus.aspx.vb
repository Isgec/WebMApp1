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
    Label2.Text = ContractDescription
    '1.Outstanding
    Try
      Dim Dt1 As SIS.CT.outstandingChart = SIS.CT.outstandingChart.GetChart(ContractCode, Comp)
      Chart1 = SIS.CT.outstandingChart.RenderChart(Chart1, Dt1)
      Chart1Data.InnerHtml = SIS.CT.outstandingChart.GetDataTable(Dt1, Comp)
      If Dt1.ContractList.Count > 1 Then
        Dim xStr As String = ""
        For I = 1 To Dt1.ContractList.Count - 1
          If xStr = "" Then
            xStr = "<u>Including Contract(s)</u><br/>"
            xStr &= Dt1.ContractList(I).ContractID & " - " & Dt1.ContractList(I).ContractName & " [" & Dt1.ContractList(I).Division & "]"
          Else
            xStr &= "<br/>" & Dt1.ContractList(I).ContractID & " - " & Dt1.ContractList(I).ContractName & " [" & Dt1.ContractList(I).Division & "]"
          End If
        Next
        IncludingContracts.Text = xStr
      End If
      If Dt1.MainContract IsNot Nothing Then
        IncludingContracts.Text = "<u>Lead Division - " & Dt1.MainContract.Division & "</u><br/>"
        IncludingContracts.Text &= Dt1.MainContract.ContractID & " - " & Dt1.MainContract.ContractName
      End If
      If Dt1.IsExport Then
        LReportHeader.Text = "OUTSTANDING STATUS [EXPORT]"
        LCur.Text = "[All amounts are in " & Dt1.Currency & "]"
      Else
        LReportHeader.Text = "OUTSTANDING STATUS [DOMESTIC]"
      End If
      Dim tmpP As Double = 0
      Dim sTmp As String = ""
      tmpP = Dt1.Retention
      If tmpP > 1 Or tmpP < -1 Then
        sTmp = Math.Truncate(Math.Round(tmpP, 0))
      Else
        sTmp = Math.Round(tmpP, 2)
      End If
      LUNFC.Text = sTmp
    Catch ex As Exception
      Chart1Data.InnerHtml = "<h3>NO DATA FOUND</h3>"
    End Try


  End Sub

End Class
