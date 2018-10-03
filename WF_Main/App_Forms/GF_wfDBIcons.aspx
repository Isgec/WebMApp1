<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_wfDBIcons.aspx.vb" Inherits="GF_wfDBIcons" title="Maintain List: Icons" %>
<asp:Content ID="CPHwfDBIcons" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelwfDBIcons" runat="server" Text="&nbsp;List: Icons"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBIcons" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfDBIcons"
      ToolType = "lgNMGrid"
      EditUrl = "~/WF_Main/App_Edit/EF_wfDBIcons.aspx"
      AddUrl = "~/WF_Main/App_Create/AF_wfDBIcons.aspx"
      ValidationGroup = "wfDBIcons"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfDBIcons" runat="server" AssociatedUpdatePanelID="UPNLwfDBIcons" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVwfDBIcons" SkinID="gv_silver" runat="server" DataSourceID="ODSwfDBIcons" DataKeyNames="DBIconID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DB Icon ID" SortExpression="DBIconID">
          <ItemTemplate>
            <asp:Label ID="LabelDBIconID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DBIconID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Icon Name" SortExpression="IconName">
          <ItemTemplate>
            <asp:Label ID="LabelIconName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IconName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Icon Style" SortExpression="IconStyle">
          <ItemTemplate>
            <asp:Label ID="LabelIconStyle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IconStyle") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Copy">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCopy" ValidationGroup='<%# "Copy" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CopyWFVisible") %>' Enabled='<%# EVal("CopyWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Copy" SkinID="Copy" OnClientClick='<%# "return Page_ClientValidate(""Copy" & Container.DataItemIndex & """) && confirm(""Copy record ?"");" %>' CommandName="CopyWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSwfDBIcons"
      runat = "server"
      DataObjectTypeName = "SIS.WF.wfDBIcons"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfDBIconsSelectList"
      TypeName = "SIS.WF.wfDBIcons"
      SelectCountMethod = "wfDBIconsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVwfDBIcons" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
