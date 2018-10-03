<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_wfDBIcons.aspx.vb" Inherits="EF_wfDBIcons" title="Edit: Icons" %>
<asp:Content ID="CPHwfDBIcons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfDBIcons" runat="server" Text="&nbsp;Edit: Icons"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBIcons" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfDBIcons"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "wfDBIcons"
    runat = "server" />
<asp:FormView ID="FVwfDBIcons"
  runat = "server"
  DataKeyNames = "DBIconID"
  DataSourceID = "ODSwfDBIcons"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DBIconID" runat="server" ForeColor="#CC6633" Text="DB Icon ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DBIconID"
            Text='<%# Bind("DBIconID") %>'
            ToolTip="Value of DB Icon ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IconName" runat="server" Text="Icon Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IconName"
            Text='<%# Bind("IconName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Icon Name."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IconStyle" runat="server" Text="Icon Style :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IconStyle"
            Text='<%# Bind("IconStyle") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Icon Style."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4">
          <LGM:LC_IconList id="F_IconList" runat="server"></LGM:LC_IconList>
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfDBIcons"
  DataObjectTypeName = "SIS.WF.wfDBIcons"
  SelectMethod = "wfDBIconsGetByID"
  UpdateMethod="UZ_wfDBIconsUpdate"
  DeleteMethod="UZ_wfDBIconsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WF.wfDBIcons"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DBIconID" Name="DBIconID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
