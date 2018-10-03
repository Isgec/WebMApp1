<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_ntNotes.aspx.vb" Inherits="GF_ntNotes" title="Maintain List: Notes" %>
<asp:Content ID="CPHntNotes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelntNotes" runat="server" Text="&nbsp;List: Notes"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLntNotes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLntNotes"
      ToolType = "lgNMGrid"
      EditUrl = "~/NT_Main/App_Edit/EF_ntNotes.aspx"
      AddUrl = "~/NT_Main/App_Create/AF_ntNotes.aspx"
      ValidationGroup = "ntNotes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSntNotes" runat="server" AssociatedUpdatePanelID="UPNLntNotes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVntNotes" SkinID="gv_silver" runat="server" DataSourceID="ODSntNotes" DataKeyNames="NotesId">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Notes_RunningNo" SortExpression="Notes_RunningNo">
          <ItemTemplate>
            <asp:Label ID="LabelNotes_RunningNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Notes_RunningNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NotesId" SortExpression="NotesId">
          <ItemTemplate>
            <asp:Label ID="LabelNotesId" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NotesId") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NotesHandle" SortExpression="NotesHandle">
          <ItemTemplate>
            <asp:Label ID="LabelNotesHandle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NotesHandle") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndexValue" SortExpression="IndexValue">
          <ItemTemplate>
            <asp:Label ID="LabelIndexValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndexValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserId" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserId" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserId") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created_Date" SortExpression="Created_Date">
          <ItemTemplate>
            <asp:Label ID="LabelCreated_Date" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Created_Date") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SendEmailTo" SortExpression="SendEmailTo">
          <ItemTemplate>
            <asp:Label ID="LabelSendEmailTo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SendEmailTo") %>'></asp:Label>
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
      ID = "ODSntNotes"
      runat = "server"
      DataObjectTypeName = "SIS.NT.ntNotes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ntNotesSelectList"
      TypeName = "SIS.NT.ntNotes"
      SelectCountMethod = "ntNotesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVntNotes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
