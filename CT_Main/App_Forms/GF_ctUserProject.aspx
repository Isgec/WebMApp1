<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ctUserProject.aspx.vb" Inherits="GF_ctUserProject" title="Maintain List: Map User-Projects" %>
<asp:Content ID="CPHctUserProject" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelctUserProject" runat="server" Text="&nbsp;List: Map User-Projects"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLctUserProject" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLctUserProject"
      ToolType = "lgNMGrid"
      EditUrl = "~/CT_Main/App_Edit/EF_ctUserProject.aspx"
      AddUrl = "~/CT_Main/App_Create/AF_ctUserProject.aspx"
      ValidationGroup = "ctUserProject"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSctUserProject" runat="server" AssociatedUpdatePanelID="UPNLctUserProject" DisplayAfter="100">
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
          <b><asp:Label ID="L_UserID" runat="server" Text="User :" /></b>
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
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
    <asp:GridView ID="GVctUserProject" SkinID="gv_silver" runat="server" DataSourceID="ODSctUserProject" DataKeyNames="UserID,ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSctUserProject"
      runat = "server"
      DataObjectTypeName = "SIS.CT.ctUserProject"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "ctUserProjectSelectList"
      TypeName = "SIS.CT.ctUserProject"
      SelectCountMethod = "ctUserProjectSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVctUserProject" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
