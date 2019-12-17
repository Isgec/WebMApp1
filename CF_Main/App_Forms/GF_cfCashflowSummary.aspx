<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" ClientIDMode="Static" CodeFile="GF_cfCashflowSummary.aspx.vb" Inherits="GF_cfCashflowSummary" title="Upload: Cashflow Summary [Monthly]" %>
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
          <asp:Label ID="Labeldmisg121" runat="server" Text="Upload Cashflow Summary [Monthly]"></asp:Label></h3>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
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

</asp:Content>
