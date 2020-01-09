<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" ClientIDMode="Static" CodeFile="GF_cfCashflowExport.aspx.vb" Inherits="GF_cfCashflowExport" title="Upload: Export Report" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHdmisg121" ContentPlaceHolderID="cph1" runat="Server">
  <style>
    .lgOutline{
      border: solid 1pt silver;
      border-radius: 10px;
      padding:20px;
    }
  </style>
  <div class="container" id="divOK" runat="server">
    <div class="row">
      <div class="col-sm-12 text-center">
        <h3>
          <asp:Label ID="Labeldmisg121" runat="server" Text="Upload Customer Outstanding Report (Export Projects)"></asp:Label></h3>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
<%--        <asp:DropDownList ID="F_Company" runat="server">
          <asp:ListItem Selected="True" Text="ISGEC" Value="200"></asp:ListItem>
          <asp:ListItem Text="REDECAM" Value="700"></asp:ListItem>
        </asp:DropDownList>--%>
      </div>
    </div>
    <div class="row lgOutline" style="margin-top:100px;">
      <div class="col-sm-12" style="text-align:center;">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:HiddenField ID="IsUploaded" runat="server"></asp:HiddenField>
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="250px" />
              <asp:Button ID="cmdTmplUpload" Text="Upload" OnClientClick="$get('IsUploaded').value='YES';" runat="server" ToolTip="Click to upload & process template file." CommandName="tmplUpload" CommandArgument='<%# Eval("PrimaryKey") %>' />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdTmplUpload" />
            </Triggers>
          </asp:UpdatePanel>
      </div>
    </div>
  </div>
  <div class="container-fluid text-center" id="divErr" runat="server">
    <h1>Access Denied</h1>
  </div>
  <div class="row">
    <div class="col-sm-12 text-center">
      <asp:HyperLink runat="server" NavigateUrl="~/App_Templates/Export_Template.xlsx" Text="Download Template"></asp:HyperLink>
    </div>
  </div>

</asp:Content>
