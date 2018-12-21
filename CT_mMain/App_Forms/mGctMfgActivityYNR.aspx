<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctMfgActivityYNR.aspx.vb" Inherits="mGctMfgActivityYNR" title="Maintain List: Project Activity" %>
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
        <asp:Label ID="LabelctPActivity" runat="server" Text="Project Progress Update-Manufacturing [YNR]"></asp:Label></h3>
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
              runat="Server">
            </asp:DropDownList>
            <AJX:CascadingDropDown
              ID="cF_t_cprj" 
              TargetControlID="F_t_cprj"
              PromptText="Select Project"
              PromptValue=""
              ServicePath="~/App_Services/MfgServices.asmx" 
              ServiceMethod="GetProjects"
              Category="t_cprj"
              LoadingText="Loading. . ."
              runat="server" />
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Supplier :</span>
            </div>
            <asp:DropDownList
              ID="F_t_bpid"
              CssClass="form-control"
              runat="Server">
            </asp:DropDownList>
            <AJX:CascadingDropDown
              ID="cF_t_bpid" 
              TargetControlID="F_t_bpid" 
              ParentControlID="F_t_cprj"
              PromptText="Select Suppliers"
              PromptValue=""
              ServicePath="~/App_Services/MfgServices.asmx" 
              ServiceMethod="GetYNRSuppliers"
              Category="t_bpid"
              LoadingText="Loading. . ."
              runat="server" />
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Purchase Order :</span>
            </div>
            <asp:DropDownList
              ID="F_t_orno"
              CssClass="form-control"
              runat="Server">
            </asp:DropDownList>
            <AJX:CascadingDropDown
              id="cF_t_orno" 
              TargetControlID="F_t_orno" 
              ParentControlID="F_t_bpid"
              PromptText="Select Order"
              PromptValue=""
              ServicePath="~/App_Services/MfgServices.asmx" 
              ServiceMethod="GetOrders"
              Category="t_orno"
              LoadingText="Loading. . ."
              runat="server" />
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Item Reference :</span>
            </div>
            <asp:DropDownList
              ID="F_t_iref"
              CssClass="form-control"
              runat="Server">
            </asp:DropDownList>
            <AJX:CascadingDropDown
              id="cF_t_iref" 
              TargetControlID="F_t_iref" 
              ParentControlID="F_t_orno"
              PromptText="Select Item Ref."
              PromptValue=""
              ServicePath="~/App_Services/MfgServices.asmx" 
              ServiceMethod="GetIrefs"
              Category="t_iref"
              LoadingText="Loading. . ."
              runat="server" />
          </div>
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Sub Item :</span>
            </div>
            <asp:DropDownList
              ID="F_t_sitm"
              CssClass="form-control"
              runat="Server">
            </asp:DropDownList>
            <AJX:CascadingDropDown
              id="cF_t_sitm" 
              TargetControlID="F_t_sitm" 
              ParentControlID="F_t_iref"
              PromptText="Select Sub Item"
              PromptValue=""
              ServicePath="~/App_Services/MfgServices.asmx" 
              ServiceMethod="GetMfgSubItems"
              Category="t_sitm"
              LoadingText="Loading. . ."
              runat="server" />
          </div>
          <div class="input-group mb-3">
            <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
            <asp:HyperLink ID="cmdHome" runat="server" CssClass="btn btn-danger" Text="Home" NavigateUrl="~/mMenu.aspx"></asp:HyperLink>
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
          SelectMethod="UZ_ctMfgActivityYNRSelectList"
          TypeName="SIS.CT.ctPActivity"
          SortParameterName="OrderBy"
          EnablePaging="False">
          <SelectParameters>
            <asp:ControlParameter ControlID="F_t_cprj" PropertyName="SelectedValue" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
            <asp:ControlParameter ControlID="F_t_orno" PropertyName="SelectedValue" Name="t_orno" Type="String" DefaultValue="" Size="9" />
            <asp:ControlParameter ControlID="F_t_iref" PropertyName="SelectedValue" Name="t_iref" Type="String" DefaultValue="" />
            <asp:ControlParameter ControlID="F_t_sitm" PropertyName="SelectedValue" Name="t_sitm" Type="String" DefaultValue="" />
          </SelectParameters>
        </asp:ObjectDataSource>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cmdSubmit" />
      </Triggers>
    </asp:UpdatePanel>
  </div>
</asp:Content>
