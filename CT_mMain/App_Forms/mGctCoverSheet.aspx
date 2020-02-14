<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctCoverSheet.aspx.vb" Inherits="mGctCoverSheet" Title="Cover Sheet" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Main Container--%>
  <div class="container" style="margin-top: 10px">
    <%--Contract Detail--%>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5>
          <asp:Label ID="Label1" runat="server" Font-Underline="true" Text="COVER SHEET"></asp:Label></h5>
        <h6>
          <asp:Label ID="Label2" runat="server"></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h4>
          <asp:Label ID="ContractName" runat="server"></asp:Label></h4>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-8 text-left">
        <h5>
          <asp:Label ID="L_Customer" Font-Bold="true" runat="server" Text=""></asp:Label></h5>
      </div>
      <div class="col-sm-4 text-right">
        <asp:Label runat="server" Text="[All amounts are in LAKH]" ForeColor="Red" Font-Italic="true"></asp:Label>
      </div>
    </div>


    <%--Cumulative Billing Status--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" style="overflow: scroll;">
          <h5></h5>

          <table style="width: 100%;" class="table-bordered">
            <tr>
              <td style="text-align: center; font-weight: bold; width: 5%;">1.
              </td>
              <td colspan="3" style="width: 40%;">
                <asp:Label ID="Ht_ccod" runat="server" Font-Bold="true" Text="Contract"></asp:Label></td>
              <td style="width: 35%;">
                <asp:Label ID="Vt_ccod" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">2.
              </td>
              <td colspan="3">
                <asp:Label ID="Ht_ccno" runat="server" Font-Bold="true" Text="Name of Customer"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_ccno" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">3.
              </td>
              <td colspan="3">
                <asp:Label ID="Ht_cust" runat="server" Font-Bold="true" Text="Contractual date of commissioning"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_cust" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">4.
              </td>
              <td colspan="3">
                <asp:Label ID="Ht_nodi" runat="server" Font-Bold="true" Text="Expected date of commissioning"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_nodi" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td colspan="3">
                <asp:Label ID="Ht_lddn" runat="server" Font-Bold="true" Text="Order Value in Project currency as on date"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_lddn" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">5.
              </td>
              <td colspan="3">
                <asp:Label ID="Ht_prod" runat="server" Font-Bold="true" Text="Order value (INR)"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_prod" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">a.
              </td>
              <td colspan="2">
                <asp:Label ID="Ht_zdat" runat="server" Font-Bold="true" Text="Original order value in Project Currency"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_zdat" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">b.
              </td>
              <td colspan="2">
                <asp:Label ID="Ht_ccdt" runat="server" Font-Bold="true" Text="Variation Order(if any)"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_ccdt" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">i)
              </td>
              <td>
                <asp:Label ID="Ht_orvl" runat="server" Font-Bold="true" Text="Increase in Order value due to Client"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_orvl" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">ii)
              </td>
              <td>
                <asp:Label ID="Ht_exrt" runat="server" Font-Bold="true" Text="Decrease in Order value due to Client"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_exrt" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">c.
              </td>
              <td colspan="2">
                <asp:Label ID="Ht_ordl" runat="server" Font-Bold="true" Text="Increase in Order value due to Internal Transfer"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_ordl" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">d.
              </td>
              <td colspan="2">
                <asp:Label ID="Ht_lddl" runat="server" Font-Bold="true" Text="Decrease in Order value due to Internal Transfer"></asp:Label></td>
              <td>
                <asp:Label ID="Vt_lddl" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td colspan="3">
                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Revised Order value"></asp:Label></td>
              <td>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">6.
              </td>
              <td colspan="3">
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Time and cost overrun claim (if any included above)"></asp:Label></td>
              <td>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">i)
              </td>
              <td colspan="2">
                <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Claimed Value"></asp:Label></td>
              <td>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;"></td>
              <td style="text-align: center; font-weight: bold;">ii)
              </td>
              <td colspan="2">
                <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Approved value by client"></asp:Label></td>
              <td>
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td colspan="5">
                <table style="width: 100%;">
                  <tr>
                    <td style="text-align: center; font-weight: bold; width: 5%;"></td>
                    <td style="text-align: center; font-weight: bold; width: 25%;">
                      <asp:Label ID="Label11" runat="server" Font-Bold="true" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; width: 15%; background-color: gainsboro;">
                      <asp:Label ID="Label12" runat="server" Font-Bold="true" Text="Budgeted"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; width: 15%; background-color: gainsboro;">
                      <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Utilized"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; width: 25%; background-color: gainsboro;">
                      <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Transfered to CTOH"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; width: 15%; background-color: gainsboro;">
                      <asp:Label ID="Label15" runat="server" Font-Bold="true" Text="Balance"></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;">7.
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                      <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="Contingency"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label18" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label19" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;"></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label40" runat="server" Font-Bold="true" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label41" runat="server" Font-Bold="true" Text="Budgeted"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label42" runat="server" Font-Bold="true" Text="Utilized"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label43" runat="server" Font-Bold="true" Text="Transfered to CTOH"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label44" runat="server" Font-Bold="true" Text="Balance"></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;">8.
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                      <asp:Label ID="Label21" runat="server" Font-Bold="true" Text="Warranty"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label23" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label24" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label25" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;"></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label45" runat="server" Font-Bold="true" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label46" runat="server" Font-Bold="true" Text="Generated"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label47" runat="server" Font-Bold="true" Text="Utilized"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label48" runat="server" Font-Bold="true" Text="Transfered to CTOH"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label49" runat="server" Font-Bold="true" Text="Balance"></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;">9.
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                      <asp:Label ID="Label26" runat="server" Font-Bold="true" Text="Contingency-S"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label27" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label28" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label29" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label30" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;"></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label50" runat="server" Font-Bold="true" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label51" runat="server" Font-Bold="true" Text="Budgeted"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label52" runat="server" Font-Bold="true" Text="Actual as on date"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label53" runat="server" Font-Bold="true" Text="Expected"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold; background-color: gainsboro;">
                      <asp:Label ID="Label54" runat="server" Font-Bold="true" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <td style="text-align: center; font-weight: bold;">10.
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                      <asp:Label ID="Label31" runat="server" Font-Bold="true" Text="CTOH"></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label32" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label33" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label34" runat="server" Text=""></asp:Label></td>
                    <td style="text-align: center; font-weight: bold;">
                      <asp:Label ID="Label35" runat="server" Text=""></asp:Label></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">11.
              </td>
              <td colspan="3">
                <asp:Label ID="Label36" runat="server" Font-Bold="true" Text="Area of Concern"></asp:Label></td>
              <td>
                <asp:Label ID="Label37" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
              <td style="text-align: center; font-weight: bold;">12.
              </td>
              <td colspan="3">
                <asp:Label ID="Label38" runat="server" Font-Bold="true" Text="Action Plan / Mitigation Plan"></asp:Label></td>
              <td>
                <asp:Label ID="Label39" runat="server" Text=""></asp:Label></td>
            </tr>
          </table>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
