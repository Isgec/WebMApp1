<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_mappApplications.aspx.vb" Inherits="GF_mappApplications" title="Maintain List: Mobile Applications" %>
<asp:Content ID="CPHmappApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelmappApplications" runat="server" Text="&nbsp;List: Mobile Applications"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLmappApplications" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLmappApplications"
      ToolType = "lgNMGrid"
      EditUrl = "~/MAPP_Main/App_Edit/EF_mappApplications.aspx"
      AddUrl = "~/MAPP_Main/App_Create/AF_mappApplications.aspx"
      ValidationGroup = "mappApplications"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSmappApplications" runat="server" AssociatedUpdatePanelID="UPNLmappApplications" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVmappApplications" SkinID="gv_silver" runat="server" DataSourceID="ODSmappApplications" DataKeyNames="AppID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="App. ID" SortExpression="AppID">
          <ItemTemplate>
            <asp:Label ID="LabelAppID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AppID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Application Name" SortExpression="ApplicationName">
          <ItemTemplate>
            <asp:Label ID="LabelApplicationName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApplicationName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Application Description" SortExpression="ApplicationDescription">
          <ItemTemplate>
            <asp:Label ID="LabelApplicationDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApplicationDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Active" SortExpression="IsActive">
          <ItemTemplate>
            <asp:Label ID="LabelIsActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsActive") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Page URL" SortExpression="MainPageURL">
          <ItemTemplate>
            <asp:Label ID="LabelMainPageURL" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MainPageURL") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
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
      ID = "ODSmappApplications"
      runat = "server"
      DataObjectTypeName = "SIS.MAPP.mappApplications"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_mappApplicationsSelectList"
      TypeName = "SIS.MAPP.mappApplications"
      SelectCountMethod = "mappApplicationsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVmappApplications" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
