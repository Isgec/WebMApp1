<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" CodeFile="mGdmisg121_All.aspx.vb" Inherits="mGF_dmisg121_All" title="List: Documents" %>
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
<asp:Content ID="CPHdmisg121" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container" id="divOK" runat="server" clientidmode="static">
    <div class="container text-center">
      <h3>
        <asp:Label ID="Labeldmisg121" runat="server" Text="Document List-ALL"></asp:Label></h3>
      <h5>
        <asp:Label ID="Label1" runat="server" Text="[Please refer DOCUMENT LINKING session for documents released before 20-08-2018]"></asp:Label></h5>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <asp:DropDownList ID="F_Company" runat="server" AutoPostBack="true">
          <asp:ListItem Selected="True" Text="ISGEC" Value="200"></asp:ListItem>
          <asp:ListItem Text="REDECAM" Value="700"></asp:ListItem>
          <asp:ListItem Text="ISGEC COVEMA" Value="651"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>
    <asp:UpdatePanel ID="UPNLdmisg121" runat="server">
      <ContentTemplate>
        <LGM:ToolBar0 
          ID = "TBLdmisg121200"
          ToolType = "lgNMGrid"
          SVisible="false"
          runat = "server" />
        <div class="form-group">
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <span class="input-group-text">Search :</span>
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
          <iframe id="xFrame" name="xFrame" style="height:20px;width:20px;display:none;" ></iframe>

        <asp:GridView ID="GVdmisg121" SkinID="gv_bs1" runat="server" AllowPaging="True" PagerSettings-Position="Bottom" DataSourceID="ODSdmisg121" DataKeyNames="t_docn,t_revn" AutoGenerateColumns="False">
          <Columns>
            <asp:TemplateField HeaderText="Document" SortExpression="t_docn">
              <ItemTemplate>
                <a href='<%# Eval("GetDownloadLink") %>' target="xFrame"><%# EVal("t_docn") %></a>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rev" SortExpression="t_revn">
              <ItemTemplate>
                <asp:Label ID="Labelt_revn" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter"  />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="t_dsca">
              <ItemTemplate>
                <asp:Label ID="Labelt_dsca" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dsca") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="t_wfst">
              <ItemTemplate>
                <asp:Label ID="Labelt_wfst" runat="server"  ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("Status") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
          </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource
          ID="ODSdmisg121"
          runat="server"
          DataObjectTypeName="SIS.DMISG.dmisg121200"
          OldValuesParameterFormatString="original_{0}"
          SelectMethod="UZ_dmisg121200SelectList_All"
          SelectCountMethod = "UZ_dmisg121200Count_All"
          TypeName="SIS.DMISG.dmisg121200"
          SortParameterName="OrderBy"
          EnablePaging="True">
          <SelectParameters>
            <asp:ControlParameter ControlID="F_SearchText" PropertyName="Text" Name="SearchText" Type="String" DefaultValue="" Size="250" />
            <asp:ControlParameter ControlID="F_Company" PropertyName="SelectedValue" Name="Comp" Type="String" DefaultValue="200" Direction="Input" Size="3" />
            <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
          </SelectParameters>
        </asp:ObjectDataSource>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cmdSearch" />
      </Triggers>
    </asp:UpdatePanel>
  </div>
  <div class="container-fluid text-center" id="divErr" runat="server" clientidmode="static">
    <h1>Access Denied</h1>
  </div>

</asp:Content>
