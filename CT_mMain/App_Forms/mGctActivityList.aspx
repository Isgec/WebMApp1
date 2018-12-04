<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctActivityList.aspx.vb" Inherits="mGctActivityList" title="Project-Activity List" %>
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
    var loading = false;
    var loadingImg;
    function show_row(x, tbl) {
      var indent = parseInt(x.getAttribute('data-indent'));
      var expended = parseInt(x.getAttribute('data-expended'));
      var bottom = parseInt(x.getAttribute('data-bottom'));

      x.style.display = 'table-row';
      x.setAttribute('data-state', 'table-row');

      if (bottom == '0')
        return;
      if (expended == '0')
        return;

      for (var i = 0, row; row = tbl.rows[i]; i++) {
        if (row.id.substr(0, x.id.length) == x.id) {
          if (parseInt(row.getAttribute('data-indent')) == indent + 1) {
            show_row(row, tbl);
          }
        }
      }


    }
    function hide_row(x, tbl) {
      var indent = parseInt(x.getAttribute('data-indent'));
      var expended = parseInt(x.getAttribute('data-expended'));
      var bottom = parseInt(x.getAttribute('data-bottom'));

      x.style.display = 'none';
      x.setAttribute('data-state', 'none');

      if (bottom == '0')
        return;
      if (expended == '0')
        return;

      for (var i = 0, row; row = tbl.rows[i]; i++) {
        if (row.id.substr(0, x.id.length) == x.id) {
          if (parseInt(row.getAttribute('data-indent')) > indent) {
            hide_row(row, tbl);
          }
        }
      }


    }
    function tree_chkreload(o) {
      if (loading)
        return;
      var x = $get(o.id.replace('img_', ''));
      var aID = x.id.split('_');
      var bottom = parseInt(x.getAttribute('data-bottom'));
      var loaded = parseInt(x.getAttribute('data-loaded'));

      if (bottom == 0)
        return;
      if (loaded == 1) {
        if (!confirm('Reload Predecessors ?'))
          return;
      }
      load_activity(x);
    }
    function load_activity(x) {
      var aID = x.id.split('_');
      var tbl = document.getElementById(aID[0]);
      var indent = parseInt(x.getAttribute('data-indent'));
      var expended = parseInt(x.getAttribute('data-expended'));
      var bottom = parseInt(x.getAttribute('data-bottom'));
      var loaded = parseInt(x.getAttribute('data-loaded'));
      var t_cact = x.getAttribute('data-activity');
      //remove all child rows
      loading = true;
      loadingImg = $get('img_' + x.id);
      loadingImg.src = '/WebMapp1/TreeImgs/Loading.gif';
      if (loaded == 1)
        for (var i = tbl.rows.length - 1; i > -1; i--) {
          var row = tbl.rows[i];
          if (row.id.substr(0, x.id.length) == x.id) {
            if (parseInt(row.getAttribute('data-indent')) > indent) {
              tbl.deleteRow(i);
            }
          }
        }
      //Reload
      PageMethods.getPredData(x.id + '|' + indent + '|' + tbl.id + '|' + tbl.getAttribute('data-project') + '|' + t_cact, success, failed);

    }

    function success(r) {
      var aR = r.split('|');
      var rowID = aR[1];
      var rows = aR[2].split('##');
      var x = $get(rowID);
      for (var i = 0; i < rows.length; i++){
        x.insertAdjacentHTML('afterend',rows[i]);
      }
      x.setAttribute('data-loaded', '1');
      //Expand It
      var aID = x.id.split('_');
      var tbl = document.getElementById(aID[0]);
      var indent = parseInt(x.getAttribute('data-indent'));
      x.setAttribute('data-expended', '1');
      for (var i = 0, row; row = tbl.rows[i]; i++) {
        if (row.id.substr(0, x.id.length) == x.id) {
          if (parseInt(row.getAttribute('data-indent')) == indent + 1) {
            show_row(row, tbl);
          }
        }
      }
      $get('img_' + x.id).src = '/WebMapp1/TreeImgs/Minus.gif';
      loading = false;
    }
    function failed(e) {
      loadingImg.src = '/WebMapp1/WebMapp1/TreeImgs/Plus.gif';
      loading = false;
      alert(e.get_message);
    }

    function tree_toggle(x) {
      if (loading)
        return;
      var aID = x.id.split('_');
      var tbl = document.getElementById(aID[0]);
      var indent = parseInt(x.getAttribute('data-indent'));
      var expended = parseInt(x.getAttribute('data-expended'));
      var bottom = parseInt(x.getAttribute('data-bottom'));
      var loaded = parseInt(x.getAttribute('data-loaded'));

      if (bottom == 0)
        return;

      if (expended == 0) {
        if (loaded == 0) {
          load_activity(x);
        } else {
          x.setAttribute('data-expended', '1');
          $get('img_' + x.id).src = '/WebMapp1/TreeImgs/Minus.gif';
          for (var i = 0, row; row = tbl.rows[i]; i++) {
            if (row.id.substr(0, x.id.length) == x.id) {
              if (parseInt(row.getAttribute('data-indent')) == indent + 1) {
                show_row(row, tbl);
              }
            }
          }
        }
        return;
      }

      if (expended == '1') {
        x.setAttribute('data-expended', '0');
        $get('img_' + x.id).src = '/WebMapp1/TreeImgs/Plus.gif';
        for (var i = 0, row; row = tbl.rows[i]; i++) {
          if (row.id.substr(0, x.id.length) == x.id) {
            if (parseInt(row.getAttribute('data-indent')) > indent ) {
              hide_row(row, tbl);
            }
          }
        }
      }

    }
  </script>
    <style type="text/css">
      .treeRow[data-state='none']::after{

      }
   .modal-my{
    overflow-y: scroll;    
    height:350px; 
   }
  </style>
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" style="margin-top: 15px">
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5>
          <asp:Label ID="Label1" runat="server" Font-Underline="true" Text="ACTIVITY LIST"></asp:Label></h5>
        <h6>(<asp:Label ID="Label2" runat="server"></asp:Label>)</h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-5 text-left">
        <h6>
          <asp:Label ID="Label3" runat="server"></asp:Label></h6>
      </div>
      <div class="col-sm-2 text-center">
        <asp:Button ID="cmdRefresh" runat="server" CssClass="btn btn-success" Text="Rebuild Predcessors" />
      </div>
      <div class="col-sm-5 text-right">
        <h6>
          <asp:Label ID="Label4" runat="server"></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center chartDiv">
        <h5>
          <asp:Label ID="ProjectActivityName" runat="server" Font-Underline="true"></asp:Label></h5>
        <div id="irefDelay30d" runat="server" class="container-fluid">
        </div>

      </div>
    </div>

  </div>
</asp:Content>
