<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_IconList.ascx.vb" Inherits="LC_IconList" %>
<script type="text/javascript">
  function icon_selected(o) {
    var ctl = $get(getFIconName());
    ctl.value = o.innerText.replace('Example of','').trim();
  }
</script>
<table style="width:100%">
  <tr>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="NewIcons" Text="New"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="WebAppl" Text="Web Appl"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton3" runat="server" CommandName="Medical" Text="Medical"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton4" runat="server" CommandName="Payment" Text="Payment"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton5" runat="server" CommandName="Spinner" Text="Spinner"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton6" runat="server" CommandName="TextEditor" Text="Text Editor"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton7" runat="server" CommandName="Transportation" Text="Transportation"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton8" runat="server" CommandName="VideoPlayer" Text="Video Player"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton9" runat="server" CommandName="Accessibility" Text="Accessibility"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton10" runat="server" CommandName="Brand" Text="Brand"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton11" runat="server" CommandName="Chart" Text="Chart"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton12" runat="server" CommandName="Currency" Text="Currency"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton13" runat="server" CommandName="Directional" Text="Directional"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton14" runat="server" CommandName="FileType" Text="File Type"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton15" runat="server" CommandName="FormControl" Text="Form Control"></asp:LinkButton> </td>
  <td style="border-right: 1pt black solid;text-align:center"><asp:LinkButton ID="LinkButton16" runat="server" CommandName="Gender" Text="Gender"></asp:LinkButton> </td>
  <td><asp:LinkButton ID="LinkButton17" runat="server" CommandName="Hand" Text="Hand"></asp:LinkButton> </td>
  </tr>
</table>
  <div id="icons" runat="server" style="padding-left:4px; height:150px;width:1000px;overflow-x:hidden;overflow-y:scroll; background-color:aliceblue">


  </div>
