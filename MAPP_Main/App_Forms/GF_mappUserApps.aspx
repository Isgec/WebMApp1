<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_mappUserApps.aspx.vb" Inherits="GF_mappUserApps" title="Maintain List: Application Authorization" %>
<asp:Content ID="CPHmappUserApps" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelmappUserApps" runat="server" Text="&nbsp;List: Application Authorization"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLmappUserApps" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLmappUserApps"
      ToolType = "lgNMGrid"
      EditUrl = "~/MAPP_Main/App_Edit/EF_mappUserApps.aspx"
      AddUrl = "~/MAPP_Main/App_Create/AF_mappUserApps.aspx"
      ValidationGroup = "mappUserApps"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSmappUserApps" runat="server" AssociatedUpdatePanelID="UPNLmappUserApps" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AppID" runat="server" Text="App. ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_AppID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_AppID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_AppID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEAppID"
            BehaviorID="B_ACEAppID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="AppIDCompletionList"
            TargetControlID="F_AppID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEAppID_Selected"
            OnClientPopulating="ACEAppID_Populating"
            OnClientPopulated="ACEAppID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_UserID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUserID_Selected"
            OnClientPopulating="ACEUserID_Populating"
            OnClientPopulated="ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVmappUserApps" SkinID="gv_silver" runat="server" DataSourceID="ODSmappUserApps" DataKeyNames="AppID,UserID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="App. ID" SortExpression="MAPP_Applications2_ApplicationName">
          <ItemTemplate>
             <asp:Label ID="L_AppID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("AppID") %>' Text='<%# Eval("MAPP_Applications2_ApplicationName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User ID" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Active" SortExpression="IsActive">
          <ItemTemplate>
            <asp:Label ID="LabelIsActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsActive") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSmappUserApps"
      runat = "server"
      DataObjectTypeName = "SIS.MAPP.mappUserApps"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_mappUserAppsSelectList"
      TypeName = "SIS.MAPP.mappUserApps"
      SelectCountMethod = "mappUserAppsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_AppID" PropertyName="Text" Name="AppID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVmappUserApps" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_AppID" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
