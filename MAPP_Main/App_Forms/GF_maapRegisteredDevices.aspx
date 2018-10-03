<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_maapRegisteredDevices.aspx.vb" Inherits="GF_maapRegisteredDevices" title="Maintain List: Registered Devices" %>
<asp:Content ID="CPHmaapRegisteredDevices" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelmaapRegisteredDevices" runat="server" Text="&nbsp;List: Registered Devices"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLmaapRegisteredDevices" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLmaapRegisteredDevices"
      ToolType = "lgNMGrid"
      EditUrl = "~/MAPP_Main/App_Edit/EF_maapRegisteredDevices.aspx"
      AddUrl = "~/MAPP_Main/App_Create/AF_maapRegisteredDevices.aspx"
      ValidationGroup = "maapRegisteredDevices"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSmaapRegisteredDevices" runat="server" AssociatedUpdatePanelID="UPNLmaapRegisteredDevices" DisplayAfter="100">
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
            CssClass = "myfktxt"
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
    <script type="text/javascript"> 
   var script_IsRegistered = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_IsExpired = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_ExpiredOn = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVmaapRegisteredDevices" SkinID="gv_silver" runat="server" DataSourceID="ODSmaapRegisteredDevices" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" Height="30px" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Device ID" SortExpression="DeviceID">
          <ItemTemplate>
            <asp:Label ID="LabelDeviceID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DeviceID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
          <ItemTemplate>
            <asp:Label ID="LabelUserName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("UserName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Mobile No" SortExpression="MobileNo">
          <ItemTemplate>
            <asp:Label ID="LabelMobileNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("MobileNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested On" SortExpression="RequestedOn">
          <ItemTemplate>
            <asp:Label ID="LabelRequestedOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("RequestedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Registered" SortExpression="IsRegistered">
          <ItemTemplate>
          <asp:CheckBox ID="F_IsRegistered"
            Checked='<%# Bind("IsRegistered") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Expired" SortExpression="IsExpired">
          <ItemTemplate>
          <asp:CheckBox ID="F_IsExpired"
            Checked='<%# Bind("IsExpired") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Expired On" SortExpression="ExpiredOn">
          <ItemTemplate>
          <asp:TextBox ID="F_ExpiredOn"
            Text='<%# Bind("ExpiredOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonExpiredOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEExpiredOn"
            TargetControlID="F_ExpiredOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonExpiredOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEExpiredOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ExpiredOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVExpiredOn"
            runat = "server"
            ControlToValidate = "F_ExpiredOn"
            ControlExtender = "MEEExpiredOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
            <asp:ImageButton ID="cmdSave" ValidationGroup='<%# "Save" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("SaveWFVisible") %>' Enabled='<%# EVal("SaveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="Save" OnClientClick='<%# "return Page_ClientValidate(""Save" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="SaveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
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
      ID = "ODSmaapRegisteredDevices"
      runat = "server"
      DataObjectTypeName = "SIS.MAPP.maapRegisteredDevices"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_maapRegisteredDevicesSelectList"
      TypeName = "SIS.MAPP.maapRegisteredDevices"
      SelectCountMethod = "maapRegisteredDevicesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVmaapRegisteredDevices" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
