<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_mappUserApps.aspx.vb" Inherits="EF_mappUserApps" title="Edit: Application Authorization" %>
<asp:Content ID="CPHmappUserApps" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelmappUserApps" runat="server" Text="&nbsp;Edit: Application Authorization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLmappUserApps" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLmappUserApps"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "mappUserApps"
    runat = "server" />
<asp:FormView ID="FVmappUserApps"
  runat = "server"
  DataKeyNames = "AppID,UserID"
  DataSourceID = "ODSmappUserApps"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AppID" runat="server" ForeColor="#CC6633" Text="App. ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_AppID"
            Width="88px"
            Text='<%# Bind("AppID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of App. ID."
            Runat="Server" />
          <asp:Label
            ID = "F_AppID_Display"
            Text='<%# Eval("MAPP_Applications2_ApplicationName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" runat="server" ForeColor="#CC6633" Text="User ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of User ID."
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsActive" runat="server" Text="Is Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsActive"
            Checked='<%# Bind("IsActive") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSmappUserApps"
  DataObjectTypeName = "SIS.MAPP.mappUserApps"
  SelectMethod = "mappUserAppsGetByID"
  UpdateMethod="mappUserAppsUpdate"
  DeleteMethod="mappUserAppsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.MAPP.mappUserApps"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AppID" Name="AppID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UserID" Name="UserID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
