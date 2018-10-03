<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_maapRegisteredDevices.aspx.vb" Inherits="EF_maapRegisteredDevices" title="Edit: Registered Devices" %>
<asp:Content ID="CPHmaapRegisteredDevices" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelmaapRegisteredDevices" runat="server" Text="&nbsp;Edit: Registered Devices"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLmaapRegisteredDevices" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLmaapRegisteredDevices"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "maapRegisteredDevices"
    runat = "server" />
<asp:FormView ID="FVmaapRegisteredDevices"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSmaapRegisteredDevices"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_DeviceID" runat="server" Text="Device ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DeviceID"
            Text='<%# Bind("DeviceID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="maapRegisteredDevices"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Device ID."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDeviceID"
            runat = "server"
            ControlToValidate = "F_DeviceID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "maapRegisteredDevices"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserID" runat="server" Text="User :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "myfktxt"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for User."
            ValidationGroup = "maapRegisteredDevices"
            onblur= "script_maapRegisteredDevices.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "maapRegisteredDevices"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_maapRegisteredDevices.ACEUserID_Selected"
            OnClientPopulating="script_maapRegisteredDevices.ACEUserID_Populating"
            OnClientPopulated="script_maapRegisteredDevices.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserName" runat="server" Text="User Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_UserName"
            Text='<%# Bind("UserName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="maapRegisteredDevices"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for User Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserName"
            runat = "server"
            ControlToValidate = "F_UserName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "maapRegisteredDevices"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MobileNo" runat="server" Text="Mobile No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MobileNo"
            Text='<%# Bind("MobileNo") %>'
            Width="128px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="maapRegisteredDevices"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Mobile No."
            MaxLength="15"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVMobileNo"
            runat = "server"
            ControlToValidate = "F_MobileNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "maapRegisteredDevices"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_RequestedOn"
            Text='<%# Bind("RequestedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="maapRegisteredDevices"
            runat="server" />
          <asp:Image ID="ImageButtonRequestedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CERequestedOn"
            TargetControlID="F_RequestedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonRequestedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEERequestedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_RequestedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVRequestedOn"
            runat = "server"
            ControlToValidate = "F_RequestedOn"
            ControlExtender = "MEERequestedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "maapRegisteredDevices"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IsRegistered" runat="server" Text="Is Registered :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsRegistered"
            Checked='<%# Bind("IsRegistered") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsExpired" runat="server" Text="Is Expired :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsExpired"
            Checked='<%# Bind("IsExpired") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ExpiredOn" runat="server" Text="Expired On :" />&nbsp;
        </td>
        <td>
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
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegisteredOn" runat="server" Text="Registered On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RegisteredOn"
            Text='<%# Bind("RegisteredOn") %>'
            ToolTip="Value of Registered On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RegisteredBy" runat="server" Text="Registered By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RegisteredBy"
            Width="72px"
            Text='<%# Bind("RegisteredBy") %>'
            Enabled = "False"
            ToolTip="Value of Registered By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RegisteredBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSmaapRegisteredDevices"
  DataObjectTypeName = "SIS.MAPP.maapRegisteredDevices"
  SelectMethod = "maapRegisteredDevicesGetByID"
  UpdateMethod="UZ_maapRegisteredDevicesUpdate"
  DeleteMethod="UZ_maapRegisteredDevicesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.MAPP.maapRegisteredDevices"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
