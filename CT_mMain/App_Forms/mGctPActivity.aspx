<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" CodeFile="mGctPActivity.aspx.vb" Inherits="mGF_ctPActivity" title="Maintain List: Project Activity" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
<style>
.switch {
  position: relative;
  display: inline-block;
  width: 50px;
  height: 24px;
}

.switch input {display:none;}

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
    a.transparent-input{
       background-color:rgba(0,0,0,0) !important;
       border:none !important;
    }
    span.transparent-input{
       background-color:rgba(0,0,0,0) !important;
       border:none !important;
    }
</style>
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container">
    <div class="container text-center">
      <h3>
        <asp:Label ID="LabelctPActivity" runat="server" Text="Project Progress Update"></asp:Label></h3>
    </div>
    <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
      <ContentTemplate>
        <div class="form-group">
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Project :</span>
            </div>
            <asp:DropDownList
              ID="F_t_cprj"
              CssClass="form-control"
              AutoPostBack="true"
              runat="Server">
            </asp:DropDownList>
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Show updated by me only :</span>
            </div>
            <div class="form-control" style="text-align:right;max-height:38px !important">
              <label class="switch ">
                <asp:CheckBox id="F_OnlyMe" runat="server" AutoPostBack="true" />
                <span class="slider round"></span>
              </label>

            </div>
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Activity :</span>
            </div>
            <asp:TextBox
              ID="F_SearchText"
              CssClass="form-control"
              onfocus="return this.select();"
              runat="Server" />
            <asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-dark" Text="Search" />
          </div>
        </div>
        <br />
        <asp:GridView ID="GVctPActivity" SkinID="gv_bs1" runat="server" AllowPaging="false" DataSourceID="ODSctPActivity" DataKeyNames="t_cprj,t_cact">
          <Columns>
            <asp:TemplateField HeaderText="Note">
              <ItemTemplate>
                <asp:ImageButton ID="cmdNotes" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="View/reply Notes" SkinID="notes" CommandName="lgNotes" CommandArgument='<%# Container.DataItemIndex %>' />
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activity" SortExpression="t_desc">
              <ItemTemplate>
                <asp:LinkButton ID="L_t_cact" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("t_cact") %>' Text='<%# Eval("t_desc") %>' CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Schd. Start Date" SortExpression="t_sdst">
              <ItemTemplate>
                <asp:Label ID="Labelt_sdst" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sdst") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter"  />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Schd. Finish Date" SortExpression="t_sdfn">
              <ItemTemplate>
                <asp:Label ID="Labelt_sdfn" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sdfn") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter"  />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
          </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource
          ID="ODSctPActivity"
          runat="server"
          DataObjectTypeName="SIS.CT.ctPActivity"
          OldValuesParameterFormatString="original_{0}"
          SelectMethod="UZ_ctPActivitySelectList"
          TypeName="SIS.CT.ctPActivity"
          SortParameterName="OrderBy"
          EnablePaging="False">
          <SelectParameters>
            <asp:ControlParameter ControlID="F_t_cprj" PropertyName="SelectedValue" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
            <asp:ControlParameter ControlID="F_SearchText" PropertyName="Text" Name="SearchText" Type="String" DefaultValue="" Size="250" />
            <asp:ControlParameter ControlID="F_OnlyMe" PropertyName="Checked" Name="OnlyMe" Type="Boolean" DefaultValue="False" Direction="Input" Size="3" />
            <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
          </SelectParameters>
        </asp:ObjectDataSource>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="F_t_cprj" />
        <asp:AsyncPostBackTrigger ControlID="cmdSearch" />
      </Triggers>
    </asp:UpdatePanel>
  </div>
</asp:Content>
