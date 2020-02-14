Imports System.Web.UI.DataVisualization.Charting
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctCoverSheet
  Inherits System.Web.UI.Page
  Private Comp As String = "200"
  Private ContractCode As String = ""
  Private ContractDescription As String = ""
  Private Sub mGctCoverSheet_Load(sender As Object, e As EventArgs) Handles Me.Load
    Comp = Request.QueryString("Company")
    ContractCode = Request.QueryString("ContractCode")
    ContractDescription = Request.QueryString("ContractDescription")
  End Sub

  Private Sub mGctCoverSheet_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If ContractCode = "" Then Exit Sub
    L_Customer.Text = SIS.CT.tpisg089.GetContractCustomer(ContractCode, Comp)
    Label2.Text = ContractDescription
    Dim x As SIS.CT.tpisg161 = SIS.CT.tpisg161.tpisg161GetByID(ContractCode, Comp)
    If x IsNot Nothing Then
      Vt_ccod.Text = x.t_ccod
      Vt_ccno.Text = x.t_nama
      Vt_cust.Text = IIf(Convert.ToDateTime(x.t_ccdt).Year < 2000, "", x.t_ccdt)
      Vt_nodi.Text = IIf(Convert.ToDateTime(x.t_ecdt).Year < 2000, "", x.t_ecdt)
      If x.t_ccur = "INR" Then
        Vt_lddn.Text = Math.Round(x.t_orvl / 100000, 2)
      Else
        Vt_lddn.Text = Math.Round(x.t_orvl, 2).ToString & " [" & x.t_ccur & "]"
      End If
      Vt_prod.Text = Math.Round(x.t_ordl / 100000, 2)
      If x.t_ccur = "INR" Then
        Vt_zdat.Text = Math.Round(x.t_ovfc / 100000, 2)
      Else
        Vt_zdat.Text = Math.Round(x.t_ovfc, 2).ToString & " [" & x.t_ccur & "]"
      End If
      Vt_ccdt.Text = ""
      Vt_orvl.Text = Math.Round(x.t_iovc / 100000, 2)
        Vt_exrt.Text = Math.Round(x.t_dovc / 100000, 2)
        Vt_ordl.Text = Math.Round(x.t_iovt / 100000, 2)
        Vt_lddl.Text = Math.Round(x.t_dovt / 100000, 2)
        Label4.Text = Math.Round(x.t_rvov / 100000, 2)
        Label6.Text = ""
        Label8.Text = Math.Round(x.t_clmv / 100000, 2)
        Label10.Text = Math.Round(x.t_apvc / 100000, 2)

        Label17.Text = Math.Round(x.t_bcnt / 100000, 2)
        Label18.Text = Math.Round(x.t_cnut / 100000, 2)
        Label19.Text = Math.Round(x.t_ctsh / 100000, 2)
        Label20.Text = Math.Round(x.t_acnt / 100000, 2)

        Label22.Text = Math.Round(x.t_bwar / 100000, 2)
        Label23.Text = Math.Round(x.t_waru / 100000, 2)
        Label24.Text = Math.Round(x.t_wtsh / 100000, 2)
        Label25.Text = Math.Round(x.t_awar / 100000, 2)

        Label27.Text = Math.Round(x.t_cnsg / 100000, 2)
        Label28.Text = Math.Round(x.t_cnsu / 100000, 2)
        Label29.Text = Math.Round(x.t_cssh / 100000, 2)
        Label30.Text = Math.Round(x.t_acys / 100000, 2)

        Label32.Text = Math.Round(x.t_bcth / 100000, 2)
        Label33.Text = Math.Round(x.t_ctoh / 100000, 2)
        Label34.Text = Math.Round(x.t_ctoe / 100000, 2)
        Label35.Text = ""
        Try
          Label37.Text = SIS.CT.tpisg161.GetText(x.t_arcn, Comp)
        Catch ex As Exception

        End Try
        Try
          Label39.Text = SIS.CT.tpisg161.GetText(x.t_apmp, Comp)
        Catch ex As Exception

        End Try

      End If
  End Sub
End Class
