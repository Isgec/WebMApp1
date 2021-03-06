<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctNext30DaysActy.aspx.vb" Inherits="mGctNext30DaysActy" title="Progress Status-Next 30 Days" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" style="margin-top: 10px">
    <div class="row">
       <div class="col-sm-4 text-left">
      <h6><asp:Label ID="BaselineStart" Font-Bold="true" runat="server"></asp:Label></h6>
      </div>
      <div class="col-sm-4 text-center">
      <h4><asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
      </div>
       <div class="col-sm-4 text-right">
        <h6>
          <asp:Label ID="Contractual" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
      </div>

  </div>
    <div class="row">
      <div class="col-sm-4 text-left">
        <h6>
          <asp:Label ID="BaselineFinish" Font-Bold="true" runat="server" Text=""></asp:Label></h6>
      </div>

      <div class="col-sm-4 text-center">
        <h5>
          <asp:Label ID="Label7" runat="server" Text="Item Wise Progress Status"></asp:Label></h5>
      </div>
      <div class="col-sm-4 text-right">
        <h6>
          <asp:Label ID="Expected" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-4">
        <h6>
          <asp:Label ID="Initial" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
      </div>
      <div class="col-sm-4 text-center">
        <h6>
          <asp:Label ID="Label9" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
      </div>
      <div class="col-sm-4 text-right">
        <h6>
          <asp:Label ID="Overall" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
        <asp:Button ID="cmdBase" runat="server" CssClass="btn btn-primary btn-sm" Text="BASE" />
      </div>
    </div>

    <div class="row chartDiv">
      <div class="col-sm-12 text-center">

        <style>
          .table-fixed tbody {
            height: 200px;
            overflow-y: auto;
            width: 100%;
          }

          .table-fixed thead,
          .table-fixed tbody,
          .table-fixed tr,
          .table-fixed td,
          .table-fixed th {
            display: block;
          }

            .table-fixed tr:after {
              content: "";
              display: block;
              visibility: hidden;
              clear: both;
            }

            .table-fixed tbody td,
            .table-fixed thead > tr > th {
              float: left;
            }
        </style>
        <style>
          #tbl30Days tr:hover {
            background-color: lavenderblush;
          }
        </style>
        <div id="irefDelay30d" runat="server" class="container-fluid text-center" style="overflow:scroll;">
        </div>
      </div>
    </div>

  </div>


</asp:Content>
