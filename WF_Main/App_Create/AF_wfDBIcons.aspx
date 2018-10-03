<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_wfDBIcons.aspx.vb" Inherits="AF_wfDBIcons" title="Add: Icons" %>
<asp:Content ID="CPHwfDBIcons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfDBIcons" runat="server" Text="&nbsp;Add: Icons"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBIcons" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfDBIcons"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "wfDBIcons"
    runat = "server" />
<asp:FormView ID="FVwfDBIcons"
  runat = "server"
  DataKeyNames = "DBIconID"
  DataSourceID = "ODSwfDBIcons"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgwfDBIcons" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DBIconID" ForeColor="#CC6633" runat="server" Text="DB Icon ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DBIconID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IconName" runat="server" Text="Icon Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IconName"
            Text='<%# Bind("IconName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Icon Name."
            MaxLength="100"
            Width="350px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Icon Style."
            MaxLength="250"
            Width="350px"
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
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfDBIcons"
  DataObjectTypeName = "SIS.WF.wfDBIcons"
  InsertMethod="UZ_wfDBIconsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WF.wfDBIcons"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
