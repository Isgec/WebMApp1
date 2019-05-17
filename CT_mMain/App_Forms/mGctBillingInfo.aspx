<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctBillingInfo.aspx.vb" Inherits="mGctBillingInfo" title="Billing Information" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" style="margin-top: 15px;">
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5><asp:Label ID="MainHeader" runat="server" Font-Underline="true" Text="BILLING INFORMATION"></asp:Label></h5>
        <h6><asp:Label ID="SubHeader" runat="server"></asp:Label></h6>
      </div>
    </div>
      <div class="row chartDiv">
        <div class="col-sm-12" style="overflow-x:scroll;">
        <table style="width:100%;">
          <tr id="rowFD" runat="server">

          </tr>
        </table>

        </div>
      </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text="CASHFLOW INFORMATION"></asp:Label></h5>
        <h6><asp:Label ID="ciSubHeader" runat="server"></asp:Label></h6>
      </div>
    </div>

      <div class="row chartDiv">
        <div class="col-sm-12" style="overflow-x:scroll;">
        <table style="width:100%;">
          <tr id="rowCI" runat="server">

          </tr>
        </table>

        </div>
      </div>

  </div>
</asp:Content>
