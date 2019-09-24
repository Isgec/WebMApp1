<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" ClientIDMode="Static" CodeFile="mEctPUActivity.aspx.vb" Inherits="mEctPUActivity" title="Activity Progress Updates" %>
<asp:Content ID="CPHctPUActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid">
    <div class="container text-center">
      <h3>
        <asp:Label ID="LabelctPActivity" runat="server" Text="Activity Progress Update"></asp:Label></h3>
    </div>
    <asp:UpdatePanel ID="UPNLctPUActivity" runat="server">
      <ContentTemplate>
        <LGM:ToolBar0
          ID="TBLctPUActivity"
          ToolType="lgNMEdit"
          UpdateAndStay="False"
          ValidationGroup="ctPUActivity"
          SVisible="False"
          runat="server" />
        <asp:FormView ID="FVctPUActivity"
          DataKeyNames="t_cprj,t_atid,t_srno"
          DataSourceID="ODSctPUActivity"
          DefaultMode="Edit"
          CssClass="container"
          runat="server">
          <EditItemTemplate>
            <script type="text/javascript">
              var script_pu = {
                IsOk: false,
                validate_pp: function () {
                  var tpgv = $get('F_t_tpgv');
                  var cpgv = $get('F_t_cpgv');
                  var acsd = $get('F_t_acsd');
                  var aced = $get('F_t_aced');
                  var ofpr = $get('OnlyFullProgress');
                  var val = 0.00;
                  if (tpgv.value != '') { try { val = parseFloat(tpgv.value); } catch (x) { } }
                  if (cpgv.innerText != '') { try { val = val + parseFloat(cpgv.innerText); } catch (x) { } }

                  if (val < 0 || val > 100) {
                    alert('Total Progress % Can NOT be less than ZERO or greater than HUNDRED.');
                    tpgv.value = '';
                    tpgv.focus();
                    return false;
                  }
                  if (ofpr.value == 'yes') {
                    if (val > 0 && val < 100) {
                      alert('Progress % Can be ZERO or HUNDRED PERCENT.');
                      tpgv.value = '';
                      tpgv.focus();
                      return false;
                    }
                  }
                  if (tpgv.value > '0') {
                    if (acsd.value == '') {
                      acsd.disabled = false;
                      ValidatorEnable($get('RFVF_t_acsd'), true);
                    }
                    if (cpgv.innerText != '') {
                      if (parseFloat(cpgv.innerText)==0){
                        acsd.disabled = false;
                        ValidatorEnable($get('RFVF_t_acsd'), true);
                      }
                    }
                  }
                  if (val == 0) {
                    //acsd.value = '';
                    acsd.disabled = true;
                    ValidatorEnable($get('RFVF_t_acsd'), false);
                  }
                  if (val == 100) {
                    if (aced.value == '') {
                      aced.disabled = false;
                      ValidatorEnable($get('RFVF_t_aced'), true);
                    }
                  } else {
                    aced.disabled = true;
                    ValidatorEnable($get('RFVF_t_aced'), false);
                    if (aced.value != '') {
                      aced.value = '';
                    }
                  }
                  return true;
                },
                validate_wipd: function(){
                  var oted = $get('F_t_oted');
                  var wipd = $get('F_t_wipd');
                  oted.disabled = true;
                  ValidatorEnable($get('RFVF_t_oted'), false);
                  if (wipd.value == '2') {
                    oted.disabled = false;
                    ValidatorEnable($get('RFVF_t_oted'), true);
                    return false;
                  }
                  if (wipd.value == '1') {
                    oted.value = '';
                  }
                  return true;

                },
                validate_acsd: function () {
                  var mRet = true;
                  var tpgv = $get('F_t_tpgv');
                  var cpgv = $get('F_t_cpgv');
                  var acsd = $get('F_t_acsd');
                  var aced = $get('F_t_aced');
                  var val = 0.00;
                  if (tpgv.value != '') { try { val = parseFloat(tpgv.value); } catch (x) { } }
                  if (cpgv.innerText != '') { try { val = val + parseFloat(cpgv.innerText); } catch (x) { } }


                  if (tpgv.value > '0') {
                    if (acsd.value == '') {
                      //acsd.focus();
                      return false;
                    }
                  }
                  PageMethods.validate_acsd(acsd.value + '|' + aced.value, this.validated_dt);
                },
                validate_aced: function () {
                  var mRet = true;
                  var tpgv = $get('F_t_tpgv');
                  var cpgv = $get('F_t_cpgv');
                  var acsd = $get('F_t_acsd');
                  var aced = $get('F_t_aced');
                  var val = 0.00;
                  if (tpgv.value != '') { try { val = parseFloat(tpgv.value); } catch (x) { } }
                  if (cpgv.innerText != '') { try { val = val + parseFloat(cpgv.innerText); } catch (x) { } }

                  if (val == 100) {
                    if (aced.value == '') {
                      //aced.focus();
                      return false;
                    }
                  } 
                  PageMethods.validate_aced(acsd.value + '|' + aced.value, this.validated_dt);
                },

                validated_dt: function (r) {
                  var p = r.split('|');
                  if (p[0] == '1') {
                    try { Android.showToast(p[1]); } catch (e) { alert(p[1]); }
                    $get(p[2]).value = '';
                    $get(p[2]).focus();
                  } 
                },
                temp: function () {
                }
              }
            </script>
            <style>
              .forsssm-control {
                  display: table;
                  white-space: pre-line;
                  word-break: break-all;
                  padding:4px;
              }
.fxxxorm-control {
    display: inline-block;
    overflow: hidden;
    vertical-align: middle;
    /* new lines */
    width: 100%;
    position: absolute;
    left: 0;
    padding-left: 30px;
    white-space: nowrap;
    text-overflow: ellipsis;
}

.input-group-sm>.custom-select, .input-group-sm>.form-control:not(textarea) {
     height:unset; /*calc(1.5em + .5rem + 2px);*/ 
}
            </style>
            <asp:TextBox ID="OnlyFullProgress" runat="server" Text='<%# Eval("OnlyFullProgress") %>' style="display:none;"></asp:TextBox>
            <div>
              <h6><span class="badge badge-secondary">Project</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:Label
                  ID="F_t_cprj"
                  Text='<%# Bind("t_cprj") %>'
                  CssClass="form-control"
                  runat="Server" />
                <asp:Label
                  ID="F_t_cprj_Display"
                  Text='<%# Eval("ttcmcs0522001_t_dsca") %>'
                  CssClass="form-control"
                  runat="Server" />
                <asp:Label
                  ID="Label1"
                  Text='<%# "PO : " & Eval("t_orno") %>'
                  CssClass="form-control"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">Activity</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:Label
                  ID="F_t_atid"
                  Text='<%# Bind("t_atid") %>'
                  CssClass="form-control"
                  runat="Server" />
                <asp:Label
                  ID="F_t_atid_Display"
                  Text='<%# Eval("ttpisg2202002_t_desc") %>'
                  CssClass="form-control"
                  runat="Server" />
                <asp:Label
                  ID="Label2"
                  Text='<%# t_nama %>'
                  CssClass="form-control"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">System driven outlook Start & Finish Date</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:TextBox
                  ID="Label3"
                  Text='<%# Eval("dt_ctsd") %>'
                  CssClass="form-control"
                  type="date"
                  enabled="false"
                  runat="Server" />
                <asp:TextBox
                  ID="Label4"
                  Text='<%# Eval("dt_cted") %>'
                  CssClass="form-control"
                  type="date"
                  enabled="false"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">% Progress :</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:TextBox ID="F_t_tpgv"
                  Text='<%# Bind("t_tpgv") %>'
                  CssClass="form-control"
                  type="number"
                  onblur="return script_pu.validate_pp();"
                  runat="server" 
                  ValidationGroup="pp" />
               <asp:RequiredFieldValidator 
                 ID="RFVF_t_tpgv" 
                 ControlToValidate="F_t_tpgv"
                 runat="server"
                 ErrorMessage="Required !!!" 
                 ForeColor="Red" 
                 EnableClientScript="true"
                 ValidationGroup="pp" />
                <asp:Label ID="F_t_puom"
                  Text="<b>Cumulative % As On date: </b>"
                  CssClass="form-control"
                  runat="server" />
                <asp:Label ID="F_t_cpgv"
                  Text='<%# Bind("t_cpgv") %>'
                  CssClass="form-control"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Actual Start Date :</span></h6>
              <div class="input-group input-group-sm mb-1">
              <asp:TextBox ID="F_t_acsd"
                Text='<%# Bind("dt_acsd") %>'
                CssClass="form-control"
                Enabled='<%# Editable %>'
                onblur="return script_pu.validate_acsd();"
                type="date"
                runat="server" 
                ValidationGroup="pp" />
               <asp:RequiredFieldValidator 
                 ID="RFVF_t_acsd" 
                 ControlToValidate="F_t_acsd"
                 runat="server"
                 Enabled="False"
                 ErrorMessage="Start Date is Required." 
                 ForeColor="Red" 
                 EnableClientScript="true"
                 ValidationGroup="pp" />
              </div>
              <h6><span class="badge badge-secondary">Outlook Start Date :</span></h6>
              <div class="input-group input-group-sm mb-1">
              <asp:TextBox ID="F_t_otsd"
                Text='<%# Bind("dt_otsd") %>'
                Enabled='<%# Editable %>'
                CssClass="form-control"
                type="date"
                runat="server" />
              </div>
              <div id="pnlconfirmation" runat="server">
                <h6><span class="badge badge-danger">Pl. Confirm Base Line/System Outlook Dates are OK :</span></h6>
                <div class="input-group input-group-sm mb-1">
                  <asp:DropDownList
                    ID="F_t_wipd"
                    SelectedValue='<%# Bind("lg_t_wipd") %>'
                    CssClass="form-control"
                    ValidationGroup="pp"
                    onblur="return script_pu.validate_wipd();"
                    runat="server">
                  <asp:ListItem Value="" Text="---"></asp:ListItem>
                  <asp:ListItem Value="1" Text="YES"></asp:ListItem>
                  <asp:ListItem Value="2" Text="NO"></asp:ListItem>
                  </asp:DropDownList>
                 <asp:RequiredFieldValidator 
                   ID="RFVlg_t_wipd" 
                   ControlToValidate="F_t_wipd"
                   runat="server"
                   ErrorMessage="<div class='btn-danger align-middle'>Confirmation is Required.</div>" 
                   EnableClientScript="true"
                   ValidationGroup="pp" />
                </div>
              </div>
              <h6><span class="badge badge-secondary">Outlook Finish Date :</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:TextBox ID="F_t_oted"
                  Text='<%# Bind("dt_oted") %>'
                  CssClass="form-control"
                  Enabled="false"
                  type="date"
                  runat="server" />
               <asp:RequiredFieldValidator 
                 ID="RFVF_t_oted" 
                 ControlToValidate="F_t_oted"
                 runat="server"
                 Enabled="False"
                 ErrorMessage="<div class='btn-danger'>Enter outlook finish date.</div>" 
                 ForeColor="Red" 
                 EnableClientScript="true"
                 ValidationGroup="pp" />
              </div>

              <h6><span class="badge badge-secondary">Actual Finish Date :</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:TextBox ID="F_t_aced"
                  Text='<%# Bind("dt_aced") %>'
                  CssClass="form-control"
                  type="date"
                  Enabled="False"
                  onblur="return script_pu.validate_aced();"
                  runat="server"
                  ValidationGroup="pp" />
               <asp:RequiredFieldValidator 
                 ID="RFVF_t_aced" 
                 ControlToValidate="F_t_aced"
                 runat="server"
                 Enabled="False"
                 ErrorMessage="Total Progress is 100%, Finish date is required." 
                 ForeColor="Red" 
                 EnableClientScript="true"
                 ValidationGroup="pp" />
              </div>
              <h6><span class="badge badge-secondary">Remarks :</span></h6>
              <div class="input-group input-group-sm mb-1">
                <asp:TextBox ID="F_t_rmks"
                  Text='<%# Bind("t_rmks") %>'
                  CssClass="form-control"
                  TextMode="Multiline"
                  Height="80px"
                  MaxLength="500"
                  runat="server" />
              </div>
            </div>
            <asp:Button ID="cmdSubmit" runat="server"  ValidationGroup="pp" CausesValidation="true" OnClientClick="return Page_ClientValidate('pp');" Text="Update" CssClass="btn btn-primary" CommandName="lgUpdate" />
            <script>
              document.write('<a class="btn btn-dark" href="' + document.referrer + '">Go Back</a>');
            </script>
          </EditItemTemplate>
        </asp:FormView>
      </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource
      ID="ODSctPUActivity"
      DataObjectTypeName="SIS.CT.ctPUActivity"
      SelectMethod="ctPUActivityGetByID"
      UpdateMethod="UZ_ctPUActivityUpdate"
      DeleteMethod="UZ_ctPUActivityDelete"
      OldValuesParameterFormatString="original_{0}"
      TypeName="SIS.CT.ctPUActivity"
      runat="server">
      <SelectParameters>
        <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cprj" Name="t_cprj" Type="String" />
        <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cact" Name="t_atid" Type="String" />
        <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_srno" Name="t_srno" Type="Int32" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </div>
</asp:Content>
