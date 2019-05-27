<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDocumentList.aspx.vb" Inherits="mGctDocumentList" title="Project-Document List" %>
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

  <script type="text/javascript">
    var script_ct = {
      ProjectID: '',
      ActivityID: '',
      cntWin: 1,
      getDVData: function (cprj, acty) {
        alert('hi');
        this.ProjectID = cprj;
        this.ActivityID = acty;
        $get('L_t_cprj').innerText = cprj;
        $get('L_t_acty').innerText = acty;
        $("#myModal").modal("show");
        var arg = $get('__EVENTARGUMENT');
        arg.value = cprj + '|' + acty;
        __doPostBack('cmdRefresh', '')

        //this.dvLoadData();
      },
      dvLoadData: function () {
        //$get('cmdRefresh').click();
        //__doPostBack('ButtonA', '')
        //PageMethods.getDVData(this.ProjectID + '|' + this.ActivityID, this.DataShow, this.DataErr);
      },
      DataShow: function (r) {
        var divDVData = $get('pnlDVData');
        try { divDVData.innerHTML = r; } catch (ex) { }

      },
      DataErr: function (ex) {
        var er = ex.get_message();
        var divDVData = $get('pnlDVData');
        try { divDVData.innerHTML = er; } catch (ex) { }
      },

      temp: function () {
      }
    }
  </script>
  <%--  <style type="text/css">
   .modal-my{
    overflow-y: scroll;    
    height:350px; 
   }
  </style>--%>
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container" style="margin-top: 15px">
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
          <asp:Label ID="Label7" runat="server" Text="DOCUMENT LIST"></asp:Label></h5>
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
          <asp:Label ID="ItemRef" runat="server"  Text=""></asp:Label></h6>
      </div>
      <div class="col-sm-4 text-right">
        <h6>
          <asp:Label ID="Overall" runat="server" Font-Bold="true" Text=""></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center chartDiv">
        <h5>
          <asp:Label ID="ProjectActivityName" runat="server" Font-Underline="true"></asp:Label></h5>
        <div id="irefDelay30d" runat="server" class="container-fluid" style="overflow:scroll;">
        </div>

      </div>
    </div>

  </div>
</asp:Content>
