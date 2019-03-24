<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboardFinancial.aspx.vb" Inherits="mGctDashboardFinancial" title="Financial Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid text-center" style="margin-top: 10px">
    <div class="row text-center">
      <div class="col-sm-3">
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="BaselineStart" Font-Bold="true" runat="server"></asp:Label></h6>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="BaselineFinish" Font-Bold="true" runat="server" Text=""></asp:Label></h6>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Initial" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
          </div>
        </div>
      </div>
      <div class="col-sm-6">
        <div class="row">
          <div class="col-sm-12">
        <h4>
          <asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h5>
          <asp:Label ID="Label7" runat="server" Text="Financial Dashboard"></asp:Label></h5>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Label9" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
          </div>
        </div>
      </div>
      <div class="col-sm-3">
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Contractual" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Expected" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Overall" runat="server" Font-Bold="true" Text=""></asp:Label></h6>

          </div>
        </div>
      </div>
    </div>

       <h4>Contract Data</h4>
   <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="ContractData" runat="server"></div>
    </div>
      <h4>Payment Terms</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="PaymentTerms" runat="server"></div>
    </div>
      <h4>Project Estimate</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="ProjectEstimate" runat="server"></div>
    </div>
      <h4>Billing</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="Billing" runat="server"></div>
    </div>
      <h4>Cash Flow</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="CashFlow" runat="server"></div>
    </div>
      <h4>Receivables</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="Receivables" runat="server"></div>
    </div>
      <h4>Outstanding BG's</h4>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="OutstandingBGs" runat="server"></div>
    </div>

  </div>


</asp:Content>
