Imports System.Web.UI.DataVisualization.Charting
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class mGctDashboardFinancial
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

  Private Sub mGctDashboardFinancial_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    '1. tpisg301
    If t_ccod = "" Then Exit Sub
    Dim tp301 As SIS.CT.tpisg301 = SIS.CT.tpisg301.tpisg301GetByID(t_ccod)
    If tp301 IsNot Nothing Then
      Ht_ccod.Text = "Contract Code:"
      Vt_ccod.Text = tp301.t_ccod
      Ht_ccno.Text = "Contract No.:"
      Vt_ccno.Text = tp301.t_ccno
      Ht_cust.Text = "Customer:"
      Vt_cust.Text = tp301.t_cust
      Ht_nodi.Text = "Name of Divisions involved ( if More than one Division):"
      Vt_nodi.Text = tp301.t_nodi
      Ht_lddn.Text = "Lead Division ( if More than one Division):"
      Vt_lddn.Text = tp301.t_lddn
      Ht_prod.Text = "Product:"
      Vt_prod.Text = tp301.t_prod
      Ht_zdat.Text = "Zero date:"
      Vt_zdat.Text = tp301.t_zdat
      Ht_ccdt.Text = "Contractual Completion Date :"
      Vt_ccdt.Text = tp301.t_ccdt
      Ht_orvl.Text = "Order Value ( in Foreign Currency):"
      Vt_orvl.Text = tp301.t_orvl
      Ht_exrt.Text = "Exchange Rate:"
      Vt_exrt.Text = tp301.t_exrt
      Ht_ordl.Text = "Order Value  (Rs. in Lac):"
      Vt_ordl.Text = tp301.t_ordl
      Ht_lddl.Text = "LD Details:"
      Vt_lddl.Text = tp301.t_lddl
    End If
    '2. Payment Term
    PaymentTerms.Controls.Add(GetPaymentTerms(t_ccod))
    '3. Project Estimate
    ProjectEstimate.Controls.Add(GetProjectEstimate(t_ccod))
    '4. Billing
    Vt_blal.Text = tp301.t_blal.ToString("n")
    Vt_blbd.Text = tp301.t_blbd.ToString("n")
    Vt_blvr.Text = tp301.t_blvr.ToString("n")
    '5. Cashflow
    Vt_cinb.Text = tp301.t_cinb.ToString("n")
    Vt_cino.Text = tp301.t_cino.ToString("n")
    Vt_cina.Text = tp301.t_cina.ToString("n")
    Vt_cinv.Text = tp301.t_cinv.ToString("n")
    Vt_cotb.Text = tp301.t_cotb.ToString("n")
    Vt_coto.Text = tp301.t_coto.ToString("n")
    Vt_cota.Text = tp301.t_cota.ToString("n")
    Vt_cotv.Text = tp301.t_cotv.ToString("n")
    Vt_cntb.Text = tp301.t_cntb.ToString("n")
    Vt_cnto.Text = tp301.t_cnto.ToString("n")
    Vt_cnta.Text = tp301.t_cnta.ToString("n")
    Vt_cntv.Text = tp301.t_cntv.ToString("n")
    '6. Receavables
    Vt_rsnd.Text = tp301.t_rsnd.ToString("n")
    Vt_rsum.Text = tp301.t_rsum.ToString("n")
    Vt_rsbm.Text = tp301.t_rsbm.ToString("n")
    Vt_rscm.Text = tp301.t_rscm.ToString("n")
    Vt_rsdm.Text = tp301.t_rsdm.ToString("n")
    Vt_rsgy.Text = tp301.t_rsgy.ToString("n")
    Vt_rsmy.Text = tp301.t_rsmy.ToString("n")
    Vt_rsur.Text = tp301.t_rsur.ToString("n")
    Vt_rstl.Text = tp301.t_rstl.ToString("n")
    Vt_nrts.Text = tp301.t_nrts.ToString("n")
    Vt_rcnd.Text = tp301.t_rcnd.ToString("n")
    Vt_rcum.Text = tp301.t_rcum.ToString("n")
    Vt_rcbm.Text = tp301.t_rcbm.ToString("n")
    Vt_rccm.Text = tp301.t_rccm.ToString("n")
    Vt_rcdm.Text = tp301.t_rcdm.ToString("n")
    Vt_rcgy.Text = tp301.t_rcgy.ToString("n")
    Vt_rcmy.Text = tp301.t_rcmy.ToString("n")
    Vt_rcur.Text = tp301.t_rcur.ToString("n")
    Vt_rctl.Text = tp301.t_rctl.ToString("n")
    Vt_nrtc.Text = tp301.t_nrtc.ToString("n")
    Vt_rend.Text = tp301.t_rend.ToString("n")
    Vt_reum.Text = tp301.t_reum.ToString("n")
    Vt_rebm.Text = tp301.t_rebm.ToString("n")
    Vt_recm.Text = tp301.t_recm.ToString("n")
    Vt_redm.Text = tp301.t_redm.ToString("n")
    Vt_regy.Text = tp301.t_regy.ToString("n")
    Vt_remy.Text = tp301.t_remy.ToString("n")
    Vt_reur.Text = tp301.t_reur.ToString("n")
    Vt_retl.Text = tp301.t_retl.ToString("n")
    Vt_nrte.Text = tp301.t_nrte.ToString("n")
    Vt_rtnd.Text = tp301.t_rtnd.ToString("n")
    Vt_rtum.Text = tp301.t_rtum.ToString("n")
    Vt_rtbm.Text = tp301.t_rtbm.ToString("n")
    Vt_rtcm.Text = tp301.t_rtcm.ToString("n")
    Vt_rtdm.Text = tp301.t_rtdm.ToString("n")
    Vt_rtgy.Text = tp301.t_rtgy.ToString("n")
    Vt_rtmy.Text = tp301.t_rtmy.ToString("n")
    Vt_rtur.Text = tp301.t_rtur.ToString("n")
    Vt_rttl.Text = tp301.t_rttl.ToString("n")
    Vt_nrtl.Text = tp301.t_nrtl.ToString("n")
    '7. Out BG
    Vt_obga.Text = tp301.t_obga.ToString("n")
    Vt_obgc.Text = tp301.t_obgc.ToString("n")
    Vt_obgp.Text = tp301.t_obgp.ToString("n")
    Vt_obgt.Text = tp301.t_obgt.ToString("n")
    '8.
    Vt_cder.Text = tp301.t_cder.ToString("n")
    Vt_cddr.Text = tp301.t_cddr.ToString("n")
    Vt_cdsr.Text = tp301.t_cdsr.ToString("n")
    Vt_cdds.Text = tp301.t_cdds.ToString("n")
    Vt_cdra.Text = tp301.t_cdra.ToString("n")
    Vt_cdsa.Text = tp301.t_cdsa.ToString("n")
  End Sub
  Private Function GetProjectEstimate(ByVal t_ccod As String) As Table
    Dim tbl As New Table
    With tbl
      .ID = "tblProjectEstimate"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    For i As Integer = 0 To 8
      Dim thc As New TableCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        '.Font.Bold = True
        Select Case i
          Case 0
            .Text = "PROJECT ESTIMATE"
          Case 1
            .Text = "BUDGETED"
          Case 2
            .Text = "ACTUAL / EXPECTED"
          Case 3
            .Text = "CONSUMPTION / COMMITMENT AS ON DATE"
          Case 4
            .Text = "COST BOOKED AS ON DATE IN ACCOUNTS"
          Case 5
            .Text = "CONTINGENCY CONSUMPTION"
          Case 6
            .Text = "SAVINGS / OVERRUN"
          Case 7
            .Text = "SAVING TRANSFERRED TO CONTINGENCY-S"
          Case 8
            .Text = "CONTINGENCY-S CONSUMPTION"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tp305 As List(Of SIS.CT.tpisg305) = SIS.CT.tpisg305.UZ_tpisg305SelectList(0, 999, "", False, "", t_ccod)

    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "SUPPLY"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)

    For Each dt As SIS.CT.tpisg305 In tp305
      tr = New TableRow
      'tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        'tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 8
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_csdc
            Case 1
              .Text = dt.t_bdgd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_aled.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_coco.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_cbda.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_cysc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cycn.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_sson.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 8
              .Text = dt.t_stcs.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "TOTAL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)
    Dim tp306 As List(Of SIS.CT.tpisg306) = SIS.CT.tpisg306.UZ_tpisg306SelectList(0, 999, "", False, "", t_ccod)
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "ERECTION"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)

    For Each dt As SIS.CT.tpisg306 In tp306
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 8
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_csdc
            Case 1
              .Text = dt.t_bdgd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_aled.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_coco.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_cbda.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_cysc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cycn.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_sson.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 8
              .Text = dt.t_stcs.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "TOTAL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)
    Dim tp307 As List(Of SIS.CT.tpisg307) = SIS.CT.tpisg307.UZ_tpisg307SelectList(0, 999, "", False, "", t_ccod)
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "CIVIL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)
    For Each dt As SIS.CT.tpisg307 In tp307
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 8
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_csdc
            Case 1
              .Text = dt.t_bdgd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_aled.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_coco.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_cbda.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_cysc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cycn.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_sson.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 8
              .Text = dt.t_stcs.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "TOTAL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)
    Dim tp308 As List(Of SIS.CT.tpisg308) = SIS.CT.tpisg308.UZ_tpisg308SelectList(0, 999, "", False, "", t_ccod)
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "OVERALL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)
    For Each dt As SIS.CT.tpisg308 In tp308
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 8
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_csdc
            Case 1
              .Text = dt.t_bdgd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_aled.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_coco.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_cbda.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_cysc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cycn.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_sson.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 8
              .Text = dt.t_stcs.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    tr = New TableRow
    td = New TableCell
    td.ColumnSpan = 9
    td.Text = "TOTAL"
    td.Style.Add("font-weight", "bold")
    tr.Cells.Add(td)
    tbl.Rows.Add(tr)

    Return tbl

  End Function

  Private Function GetPaymentTerms(ByVal t_ccod As String) As Table
    Dim tbl As New Table
    With tbl
      .ID = "tblPaymentTerms"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableRow
    th.Font.Bold = True
    th.BackColor = Drawing.Color.Gainsboro
    Dim thc As New TableCell
    thc.ColumnSpan = 4
    thc.BorderColor = Drawing.Color.DarkGray
    th.Cells.Add(thc)
    thc = New TableCell
    thc.ColumnSpan = 3
    thc.BorderColor = Drawing.Color.DarkGray
    thc.Text = "Amount Received"
    thc.Attributes.Add("style", "text-align:center;")
    thc.Font.Bold = True
    th.Cells.Add(thc)
    tbl.Rows.Add(th)

    th = New TableRow
    th.BackColor = Drawing.Color.Gainsboro
    For i As Integer = 0 To 6
      thc = New TableCell
      With thc
        thc.BorderColor = Drawing.Color.DarkGray
        .Attributes.Add("style", "text-align:center;")
        .Font.Bold = True
        Select Case i
          Case 0
            .Text = "PAYMENT TERMS"
          Case 1
            .Text = "SUPPLY"
          Case 2
            .Text = "CIVIL"
          Case 3
            .Text = "E&C"
          Case 4
            .Text = "SUPPLY"
          Case 5
            .Text = "CIVIL"
          Case 6
            .Text = "E&C"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim tp302 As List(Of SIS.CT.tpisg302) = SIS.CT.tpisg302.UZ_tpisg302SelectList(0, 999, "", False, "", t_ccod)
    For Each dt As SIS.CT.tpisg302 In tp302
      tr = New TableRow
      'tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        'tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 6
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_paym
            Case 1
              .Text = dt.t_samt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_camt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_eamt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_srcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_crcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_ercd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    Dim tp303 As List(Of SIS.CT.tpisg303) = SIS.CT.tpisg303.UZ_tpisg303SelectList(0, 999, "", False, "", t_ccod)
    For Each dt As SIS.CT.tpisg303 In tp303
      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 6
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_paym
              .Attributes.Add("style", "text-align:center;")
            Case 1
              .Text = dt.t_samt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_camt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_eamt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_srcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_crcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_ercd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    Dim tp304 As List(Of SIS.CT.tpisg304) = SIS.CT.tpisg304.UZ_tpisg304SelectList(0, 999, "", False, "", t_ccod)
    For Each dt As SIS.CT.tpisg304 In tp304
      tr = New TableRow
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 6
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.t_paym
              .Attributes.Add("style", "text-align:center;")
            Case 1
              .Text = dt.t_samt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.t_camt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.t_eamt.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_srcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_crcd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_ercd.ToString("n")
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next

    Return tbl

  End Function

  Private Sub cmdBillingInfo_Click(sender As Object, e As EventArgs) Handles cmdBillingInfo.Click
    If t_ccod = "" Then Exit Sub
    Dim RedirectURL As String = "~/CT_mMain/App_Forms/mGctBillingInfo.aspx?t_ccod=" & t_ccod & "&t_nama=" & ContractName.Text
    Response.Redirect(RedirectURL)
  End Sub
End Class
