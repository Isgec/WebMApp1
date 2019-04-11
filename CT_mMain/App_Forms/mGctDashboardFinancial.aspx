<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboardFinancial.aspx.vb" Inherits="mGctDashboardFinancial" Title="Financial Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmdBillingInfo" runat="server" Text="Billing Information" ToolTip="Billing Information." />
<%--  <asp:LinkButton ID="cmd30Days" runat="server" Text="Progress Status [Last 30 Days]" ToolTip="Last 30 days." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Progress Status [Overall]" ToolTip="Since Project Start." />
  <asp:LinkButton ID="cmd30Next" runat="server" Text="Progress Status [Next 30 Days]" ToolTip="Next 30 days." />
  <asp:LinkButton ID="cmdDelayed" runat="server" Text="Delayed Status [Overall]" ToolTip="Delayed Since Project Start." />
  <asp:LinkButton ID="cmdFinance" runat="server" Text="Financial Dashboard" ToolTip="Financial Dashboard." />--%>
</div>

  <%--Main Container--%>
  <div class="container" style="margin-top: 10px">
    <%--Project Selection Drop Down--%>
    <div class="row">
      <div class="col-sm-12">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">
              <div class="input-group mb-3">
                <span class=" btn btn-sm btn-dark" style="width: 40px; text-align: center; cursor: pointer" title="Menu" onclick="openNav()">&#9776;</span>
                <asp:DropDownList
                  ID="F_t_ccod"
                  CssClass="form-control"
                  ClientIDMode="static"
                  runat="Server">
                </asp:DropDownList>
                <AJX:CascadingDropDown
                  ID="cF_t_ccod"
                  TargetControlID="F_t_ccod"
                  PromptText="Select Contract"
                  PromptValue=""
                  ServicePath="~/App_Services/MfgServices.asmx"
                  ServiceMethod="GetContracts"
                  Category="t_ccod"
                  LoadingText="Loading. . ."
                  runat="server" />
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary btn-sm" Text="SHOW" />
              </div>
            </div>
            <br />
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
    <%--Contract Detaila--%>
    <div class="row">
      <div class="col-sm-6">
        <h5>
          <asp:Label ID="Label1" runat="server" Font-Underline="true" Text="FINANCIAL DASHBOARD"></asp:Label></h5>
      </div>
      <div class="col-sm-6 text-right">
        <h4>
          <asp:Label ID="ContractName" runat="server"></asp:Label></h4>
      </div>
    </div>
    <%--Main Data Row--%>
    <h4>1. Contract Data</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr>
          <td>
            <asp:Label ID="Ht_ccod" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_ccod" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_ccno" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_ccno" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_cust" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_cust" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_nodi" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_nodi" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_lddn" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_lddn" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_prod" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_prod" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_zdat" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_zdat" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_ccdt" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_ccdt" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_orvl" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_orvl" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_exrt" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_exrt" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_ordl" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_ordl" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Ht_lddl" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td>
            <asp:Label ID="Vt_lddl" runat="server" Text=""></asp:Label></td>
        </tr>
      </table>
    </div>
    <%--Payment Term--%>
    <h4>2. Payment Terms</h4>
    <div class="chartDiv" id="PaymentTerms" runat="server">
    </div>
    <h4>3. Project Estimate</h4>
    <div class="chartDiv" id="ProjectEstimate" runat="server">
    </div>
    <h4>4. Billing</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr>
          <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Billing (To Date):"></asp:Label></td>
          <td>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr style="background-color: gainsboro;">
          <td>
            <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="12px" Text="BILLING"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="CUMULATIVE AS ON DATE"></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Budget"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_blbd" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Actual"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_blal" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Variance (Fevo+/Adver-)"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_blvr" runat="server" Text=""></asp:Label></td>
        </tr>
      </table>
    </div>
    <h4>5. Cash Flow</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr style="background-color: gainsboro;">
          <td>
            <asp:Label ID="Label11" runat="server" Font-Bold="true" Font-Size="12px" Text="CASHFLOW"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label12" runat="server" Font-Bold="true" Text="BUDGET"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="OUTLOOK"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="ACTUAL"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label17" runat="server" Font-Bold="true" Text="VARIANCE"></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Inflow"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cinb" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cino" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cina" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cinv" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label19" runat="server" Font-Bold="true" Text="Outflow"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cotb" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_coto" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cota" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cotv" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label24" runat="server" Font-Bold="true" Text="Net"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cntb" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cnto" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cnta" runat="server" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cntv" runat="server" Text=""></asp:Label></td>
        </tr>
      </table>
    </div>
    <h4>6. Receivables</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr style="background-color: gainsboro;">
          <td>
            <asp:Label ID="Label13" runat="server" Font-Bold="true" Font-Size="12px" Text="Receivables"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label15" runat="server" Font-Bold="true" Text="Not due"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="31 to 60 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="61 to 90 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label20" runat="server" Font-Bold="true" Text="91 to 120 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label37" runat="server" Font-Bold="true" Text="121 to 180 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label38" runat="server" Font-Bold="true" Text="181 to 365 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label39" runat="server" Font-Bold="true" Text="More than 365 Days"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label29" runat="server" Font-Bold="true" Text="Unclaimed Retention"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label30" runat="server" Font-Bold="true" Text="Total"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label31" runat="server" Font-Bold="true" Text="Net Receivable"></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label21" runat="server" Font-Bold="true" Text="Supply"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsnd" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsum" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsbm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rscm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsdm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsgy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsmy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rsur" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rstl" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_nrts" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label27" runat="server" Font-Bold="true" Text="Civil Work"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcnd" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcum" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcbm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rccm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcdm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcgy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcmy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rcur" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rctl" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_nrtc" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label32" runat="server" Font-Bold="true" Text="Erection & Commg"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_rend" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_reum" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rebm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_recm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_redm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_regy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_remy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_reur" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_retl" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_nrte" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label49" runat="server" Font-Bold="true" Text="TOTAL"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtnd" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtum" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtbm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtcm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtdm" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtgy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtmy" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rtur" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_rttl" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_nrtl" runat="server" /></td>
        </tr>
      </table>
    </div>
    <h4>7. Outstanding BG's</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr>
          <td>
            <asp:Label ID="Label33" runat="server" Font-Bold="true" Text="Advance"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_obga" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label44" runat="server" Font-Bold="true" Text="Contract performance"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_obgc" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label53" runat="server" Font-Bold="true" Text="Product performance"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_obgp" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label61" runat="server" Font-Bold="true" Text="TOTAL"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_obgt" runat="server" /></td>
        </tr>
      </table>
    </div>
    <h4>8. Extra Claim / Client Debits</h4>
    <div class="chartDiv">
      <table style="width: 100%;" class="table-bordered">
        <tr style="background-color: gainsboro;">
          <td>
            <asp:Label ID="Label22" runat="server" Font-Bold="true" Text=""></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label23" runat="server" Font-Bold="true" Text="Raised Amount"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Label34" runat="server" Font-Bold="true" Text="Settled Amount"></asp:Label></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Extra Claim Raised by us on Customer"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cder" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_cdsr" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label28" runat="server" Font-Bold="true" Text="Debit Note Raised By Customer"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cddr" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_cdds" runat="server" /></td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label26" runat="server" Font-Bold="true" Text="Variation Order"></asp:Label></td>
          <td class="text-center">
            <asp:Label ID="Vt_cdra" runat="server" /></td>
          <td class="text-center">
            <asp:Label ID="Vt_cdsa" runat="server" /></td>
        </tr>
      </table>
    </div>
  </div>
</asp:Content>
