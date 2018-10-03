<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" CodeFile="mConfig.aspx.vb" Inherits="mLGConfig" title="Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" ClientIDMode="Static" runat="Server">
    <div id="authFailed" runat="server" visible="false" class="container text-center">
    <div class="btn btn-danger">
      <h4>DEVICE ATHENTICATION FAILED</h4>
    </div>
  </div>
  <div id="celldata" runat="server" class="container">

  </div>
  <asp:Button runat="server" id="cmdRefresh" Text="Refresh" CssClass="btn btn-warning" />
  <input type="button" class="btn btn-success" onclick="return getLocation();" value="Get Location" />
  <input type="button" class="btn btn-danger" onclick="return Android.showToast('Show Message Button Clicked');" value="Show Message" />

  <script>
    function getLocation() {
      var s;
      try {
        s= Android.getLocation();
      }catch(e){}
      celldata.innerHTML = s;
      alert(s);
      return false;
    }
  </script>
</asp:Content>

