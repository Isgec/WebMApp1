<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ctPActivity.aspx.vb" Inherits="GF_ctPActivity" title="Maintain List: Project Activity" %>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelctPActivity" runat="server" Text="&nbsp;List: Project Activity"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLctPActivity" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLctPActivity"
      ToolType = "lgNMGrid"
      EditUrl = "~/CT_Main/App_Edit/EF_ctPActivity.aspx"
      AddUrl = "~/CT_Main/App_Create/AF_ctPActivity.aspx?skip=1"
      ValidationGroup = "ctPActivity"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSctPActivity" runat="server" AssociatedUpdatePanelID="UPNLctPActivity" DisplayAfter="100">
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
          <b><asp:Label ID="L_t_cprj" runat="server" Text="Project ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_t_cprj"
            CssClass = "mypktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_t_cprj(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_t_cprj_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_cprj"
            BehaviorID="B_ACEt_cprj"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_cprjCompletionList"
            TargetControlID="F_t_cprj"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEt_cprj_Selected"
            OnClientPopulating="ACEt_cprj_Populating"
            OnClientPopulated="ACEt_cprj_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_cact" runat="server" Text="Activity ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_t_cact"
            CssClass = "mypktxt"
            Width="248px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_t_cact(this);"
            AutopostBack ="True"
            Runat="Server" />
          <asp:Label
            ID = "F_t_cact_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_cact"
            BehaviorID="B_ACEt_cact"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_cactCompletionList"
            TargetControlID="F_t_cact"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEt_cact_Selected"
            OnClientPopulating="ACEt_cact_Populating"
            OnClientPopulated="ACEt_cact_Populated"
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
    <asp:GridView ID="GVctPActivity" SkinID="gv_silver" runat="server" DataSourceID="ODSctPActivity" DataKeyNames="t_cprj,t_cact">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="ttcmcs0522001_t_dsca">
          <ItemTemplate>
             <asp:Label ID="L_t_cprj" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("t_cprj") %>' Text='<%# Eval("ttcmcs0522001_t_dsca") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Activity ID" SortExpression="ttpisg2002002_t_desc">
          <ItemTemplate>
             <asp:Label ID="L_t_cact" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("t_cact") %>' Text='<%# Eval("ttpisg2002002_t_desc") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Schedule Start" SortExpression="t_sdst">
          <ItemTemplate>
            <asp:Label ID="Labelt_sdst" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sdst") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Schedule Finish" SortExpression="t_sdfn">
          <ItemTemplate>
            <asp:Label ID="Labelt_sdfn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sdfn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Start" SortExpression="t_acsd">
          <ItemTemplate>
            <asp:Label ID="Labelt_acsd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_acsd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Finish" SortExpression="t_acfn">
          <ItemTemplate>
            <asp:Label ID="Labelt_acfn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_acfn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Reference" SortExpression="t_sub1">
          <ItemTemplate>
            <asp:Label ID="Labelt_sub1" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_sub1") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSctPActivity"
      runat = "server"
      DataObjectTypeName = "SIS.CT.ctPActivity"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ctPActivitySelectList"
      TypeName = "SIS.CT.ctPActivity"
      SelectCountMethod = "ctPActivitySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_cprj" PropertyName="Text" Name="t_cprj" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_t_cact" PropertyName="Text" Name="t_cact" Type="String" Size="30" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVctPActivity" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_t_cprj" />
    <asp:AsyncPostBackTrigger ControlID="F_t_cact" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
