<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ctPUActivity.aspx.vb" Inherits="GF_ctPUActivity" title="Maintain List: Project Activity Updates" %>
<asp:Content ID="CPHctPUActivity" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelctPUActivity" runat="server" Text="&nbsp;List: Project Activity Updates"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLctPUActivity" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLctPUActivity"
      ToolType = "lgNMGrid"
      EditUrl = "~/CT_Main/App_Edit/EF_ctPUActivity.aspx"
      AddUrl = "~/CT_Main/App_Create/AF_ctPUActivity.aspx"
      AddPostBack = "True"
      ValidationGroup = "ctPUActivity"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSctPUActivity" runat="server" AssociatedUpdatePanelID="UPNLctPUActivity" DisplayAfter="100">
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
          <b><asp:Label ID="L_t_cprj" runat="server" Text="Project :" /></b>
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
          <b><asp:Label ID="L_t_atid" runat="server" Text="Activity :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_t_atid"
            CssClass = "mypktxt"
            Width="248px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_t_atid(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_t_atid_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_atid"
            BehaviorID="B_ACEt_atid"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_atidCompletionList"
            TargetControlID="F_t_atid"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEt_atid_Selected"
            OnClientPopulating="ACEt_atid_Populating"
            OnClientPopulated="ACEt_atid_Populated"
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
    <asp:GridView ID="GVctPUActivity" SkinID="gv_silver" runat="server" DataSourceID="ODSctPUActivity" DataKeyNames="t_cprj,t_atid,t_srno">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sr.No." SortExpression="t_srno">
          <ItemTemplate>
            <asp:Label ID="Labelt_srno" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_srno") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Planned Start Date" SortExpression="t_plsd">
          <ItemTemplate>
            <asp:Label ID="Labelt_plsd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_plsd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Planned Finish Date" SortExpression="t_plfd">
          <ItemTemplate>
            <asp:Label ID="Labelt_plfd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_plfd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Start Date" SortExpression="t_acsd">
          <ItemTemplate>
            <asp:Label ID="Labelt_acsd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_acsd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Finish Date" SortExpression="t_aced">
          <ItemTemplate>
            <asp:Label ID="Labelt_aced" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_aced") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="t_puom">
          <ItemTemplate>
            <asp:Label ID="Labelt_puom" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_puom") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value" SortExpression="t_tpgv">
          <ItemTemplate>
            <asp:Label ID="Labelt_tpgv" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_tpgv") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSctPUActivity"
      runat = "server"
      DataObjectTypeName = "SIS.CT.ctPUActivity"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ctPUActivitySelectList"
      TypeName = "SIS.CT.ctPUActivity"
      SelectCountMethod = "ctPUActivitySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_atid" PropertyName="Text" Name="t_atid" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_t_cprj" PropertyName="Text" Name="t_cprj" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVctPUActivity" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_t_atid" />
    <asp:AsyncPostBackTrigger ControlID="F_t_cprj" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
