<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctActivityDetails.aspx.vb" Inherits="mGctActivityDetails" title="Project-Activity Details" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" style="margin-top: 15px">
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5><asp:Label ID="MainHeader" runat="server" Font-Underline="true" Text="ACTIVITY DETAIL"></asp:Label></h5>
        <h6><asp:Label ID="SubHeader" runat="server"></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center chartDiv">
        <div id="divDetails" runat="server" class="container-fluid">
        </div>
      </div>
    </div>
  </div>
</asp:Content>
