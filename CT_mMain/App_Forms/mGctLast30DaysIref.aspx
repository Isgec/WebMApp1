<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctLast30DaysIref.aspx.vb" Inherits="mGctLast30DaysIref" title="Delayed Item-Last 30 Days" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" style="margin-top: 10px">
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
          <asp:Label ID="Label7" runat="server" Text="Item Wise Progress Status"></asp:Label></h5>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
        <h6>
          <asp:Label ID="Label9" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
        <asp:Button ID="cmdBase" runat="server" CssClass="btn btn-primary btn-sm" Text="BASE" />
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

    <div class="row chartDiv">
      <div class="col-sm-12 text-center" id="irefDelay30d" runat="server" style="overflow:scroll;"></div>
    </div>

  </div>


</asp:Content>
