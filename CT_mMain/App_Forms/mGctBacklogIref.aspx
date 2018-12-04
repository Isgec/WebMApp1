<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctBacklogIref.aspx.vb" Inherits="mGctDashboard" title="Project Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
  <style>
    .chartDiv {
      overflow: hidden;
      margin: 15px auto;
      padding: 0px 0px 6px 0px;
      text-align: center;
      /*background: #e3e3e3;*/
      color: #333333;
      -moz-border-radius: 5px;
      -webkit-border-radius: 5px;
      border-radius: 5px;
      border: 1px solid gray;
    }

    th div {
      position: absolute;
      background: transparent;
      color: #fff;
      padding: 9px 25px;
      top: 0;
      margin-left: -25px;
      line-height: normal;
      border-left: 1px solid #800;
    }

    .switch {
      position: relative;
      display: inline-block;
      width: 50px;
      height: 24px;
    }

      .switch input {
        display: none;
      }

    .slider {
      position: absolute;
      cursor: pointer;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      background-color: #ccc;
      -webkit-transition: .4s;
      transition: .4s;
    }

      .slider:before {
        position: absolute;
        content: "";
        height: 16px;
        width: 16px;
        left: 4px;
        bottom: 4px;
        background-color: white;
        -webkit-transition: .4s;
        transition: .4s;
      }

    input:checked + .slider {
      background-color: #2196F3;
    }

    input:focus + .slider {
      box-shadow: 0 0 1px #2196F3;
    }

    input:checked + .slider:before {
      -webkit-transform: translateX(26px);
      -ms-transform: translateX(26px);
      transform: translateX(26px);
    }

    /* Rounded sliders */
    .slider.round {
      border-radius: 24px;
    }

      .slider.round:before {
        border-radius: 50%;
      }
  </style>
  <style>
    a.transparent-input {
      background-color: rgba(0,0,0,0) !important;
      border: none !important;
    }

    span.transparent-input {
      background-color: rgba(0,0,0,0) !important;
      border: none !important;
    }
  </style>
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container" style="margin-top: 10px">
    <%--Project & Period Detaila--%>
    <div class="row">
      <div class="col-sm-4 text-center">
      <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text=""></asp:Label></h5>
      </div>
      <div class="col-sm-4 text-center">
      <h4><asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
      </div>
      <div class="col-sm-4 text-center">
      <h6>(<asp:Label ID="ProjectPeriod" runat="server"></asp:Label>)</h6>
      </div>
    </div>
    <%--Backlog Item Reference Wise Delay Days--%>
    <div class="row chartDiv">
      <div class="col-sm-12 text-center">
            <h5><asp:Label ID="Label10" runat="server" Text="Backlog Item Wise Delay Status"></asp:Label></h5>
            <h6><asp:Label ID="Label11" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
            <div id="irefDelayAll" runat="server" class="container-fluid text-center">
            </div>
      </div>
    </div>
  </div>


</asp:Content>
