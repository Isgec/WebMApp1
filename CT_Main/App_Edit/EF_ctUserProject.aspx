<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_ctUserProject.aspx.vb" Inherits="EF_ctUserProject" title="Edit: Map User-Projects" %>
<asp:Content ID="CPHctUserProject" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctUserProject" runat="server" Text="&nbsp;Edit: Map User-Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctUserProject" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctUserProject"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "ctUserProject"
    runat = "server" />
<asp:FormView ID="FVctUserProject"
  runat = "server"
  DataKeyNames = "UserID,ProjectID"
  DataSourceID = "ODSctUserProject"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" runat="server" ForeColor="#CC6633" Text="User :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of User."
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
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
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
  ID = "ODSctUserProject"
  DataObjectTypeName = "SIS.CT.ctUserProject"
  SelectMethod = "ctUserProjectGetByID"
  UpdateMethod="ctUserProjectUpdate"
  DeleteMethod="ctUserProjectDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctUserProject"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UserID" Name="UserID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
