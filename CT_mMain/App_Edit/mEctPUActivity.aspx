<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" CodeFile="mEctPUActivity.aspx.vb" Inherits="mEctPUActivity" title="Activity Progress Updates" %>
<asp:Content ID="CPHctPUActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container">
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
            <div class="form-group">
              <h6><span class="badge badge-secondary">Project</span></h6>
              <div class="input-group mb-3">
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
              </div>
              <h6><span class="badge badge-secondary">Activity</span></h6>
              <div class="input-group mb-3">
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
              </div>
              <div class="input-group mb-3" style="display:none;">
                <div class="input-group-prepend">
                  <span class="input-group-text">Serial No :</span>
                </div>
                  <asp:TextBox ID="F_t_srno"
                    Text='<%# Bind("t_srno") %>'
                    Enabled = "False"
                    runat="server" />
              </div>
              <h6><span class="badge badge-secondary">% Progress :</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_t_tpgv"
                  Text='<%# Bind("t_tpgv") %>'
                  CssClass = "form-control"
                  type="number"
                  runat="server" />
                <asp:Label ID="F_t_puom"
                  Text='<%# "<b>Cumulative % As On date: </b>" & Eval("t_cpgv") %>'
                  Enabled = "False"
                  CssClass = "form-control"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Actual Start Date :</span></h6>
              <div class="input-group mb-3">
              <asp:TextBox ID="F_t_acsd"
                Text='<%# Bind("dt_acsd") %>'
                CssClass = "form-control"
                Enabled='<%# Editable %>'
                type="date"
                runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Outlook Start Date :</span></h6>
              <div class="input-group mb-3">
              <asp:TextBox ID="F_t_otsd"
                Text='<%# Bind("dt_otsd") %>'
                CssClass = "form-control"
                type="date"
                runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Outlook Finish Date :</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_t_oted"
                  Text='<%# Bind("dt_oted") %>'
                  CssClass = "form-control"
                  type="date"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Cumulative % As on Date :</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_t_cpgv"
                  Text='<%# Bind("t_cpgv") %>'
                  CssClass = "form-control"
                  type="number"
                  runat="server" />
                <asp:TextBox ID="TextBox2"
                  Text='<%# Eval("t_puom") %>'
                  Enabled = "False"
                  CssClass = "form-control"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Actual Finish Date :</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_t_aced"
                  Text='<%# Bind("dt_aced") %>'
                  CssClass = "form-control"
                  type="date"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Remarks :</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_t_rmks"
                  Text='<%# Bind("t_rmks") %>'
                  CssClass = "form-control"
                  TextMode="Multiline"
                  Height="80px"
                  MaxLength="500"
                  runat="server" />
              </div>
            </div>
            <asp:Button ID="cmdSubmit" runat="server" Text="Update" CssClass="btn btn-primary" CommandName="lgUpdate" />
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
