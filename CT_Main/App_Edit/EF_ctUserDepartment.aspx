<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_ctUserDepartment.aspx.vb" Inherits="EF_ctUserDepartment" title="Edit: Map User-Departments" %>
<asp:Content ID="CPHctUserDepartment" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctUserDepartment" runat="server" Text="&nbsp;Edit: Map User-Departments"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctUserDepartment" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctUserDepartment"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "ctUserDepartment"
    runat = "server" />
<asp:FormView ID="FVctUserDepartment"
  runat = "server"
  DataKeyNames = "UserID,DepartmentID"
  DataSourceID = "ODSctUserDepartment"
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
          <b><asp:Label ID="L_DepartmentID" runat="server" ForeColor="#CC6633" Text="Department :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DepartmentID"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Department."
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments2_Description") %>'
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
  ID = "ODSctUserDepartment"
  DataObjectTypeName = "SIS.CT.ctUserDepartment"
  SelectMethod = "ctUserDepartmentGetByID"
  UpdateMethod="ctUserDepartmentUpdate"
  DeleteMethod="ctUserDepartmentDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctUserDepartment"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UserID" Name="UserID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DepartmentID" Name="DepartmentID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
