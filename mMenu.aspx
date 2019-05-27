<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" CodeFile="mMenu.aspx.vb" Inherits="mLGMenu" title="ISGECApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" ClientIDMode="Static" runat="Server">
  <div id="authFailed" runat="server" visible="false" class="container text-center">
    <div class="btn btn-danger">
      <h4>DEVICE ATHENTICATION FAILED</h4>
    </div>
  </div>
  <div id="appIcons" runat="server" visible="false" class="container-fluid text-center" style="width:100%;margin: 0 auto;">
    <asp:Button runat="server" ID="cmdConfig" Text="Config" CssClass="btn btn-dark" />
  </div>
</asp:Content>

