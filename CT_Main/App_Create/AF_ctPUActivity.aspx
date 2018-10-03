<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_ctPUActivity.aspx.vb" Inherits="AF_ctPUActivity" title="Add: Project Activity Updates" %>
<asp:Content ID="CPHctPUActivity" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctPUActivity" runat="server" Text="&nbsp;Add: Project Activity Updates"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctPUActivity" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctPUActivity"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "ctPUActivity"
    runat = "server" />
<asp:FormView ID="FVctPUActivity"
  runat = "server"
  DataKeyNames = "t_cprj,t_atid,t_srno"
  DataSourceID = "ODSctPUActivity"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgctPUActivity" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_cprj" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_t_cprj"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("t_cprj") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "ctPUActivity"
            onblur= "script_ctPUActivity.validate_t_cprj(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_cprj"
            runat = "server"
            ControlToValidate = "F_t_cprj"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_t_cprj_Display"
            Text='<%# Eval("ttcmcs0522001_t_dsca") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_cprj"
            BehaviorID="B_ACEt_cprj"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_cprjCompletionList"
            TargetControlID="F_t_cprj"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_ctPUActivity.ACEt_cprj_Selected"
            OnClientPopulating="script_ctPUActivity.ACEt_cprj_Populating"
            OnClientPopulated="script_ctPUActivity.ACEt_cprj_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_atid" ForeColor="#CC6633" runat="server" Text="Activity :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_t_atid"
            CssClass = "mypktxt"
            Width="248px"
            Text='<%# Bind("t_atid") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Activity."
            ValidationGroup = "ctPUActivity"
            onblur= "script_ctPUActivity.validate_t_atid(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_atid"
            runat = "server"
            ControlToValidate = "F_t_atid"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_t_atid_Display"
            Text='<%# Eval("ttpisg2202002_t_iref") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEt_atid"
            BehaviorID="B_ACEt_atid"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_atidCompletionList"
            TargetControlID="F_t_atid"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_ctPUActivity.ACEt_atid_Selected"
            OnClientPopulating="script_ctPUActivity.ACEt_atid_Populating"
            OnClientPopulated="script_ctPUActivity.ACEt_atid_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_srno" ForeColor="#CC6633" runat="server" Text="Sr.No. :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_srno"
            Text='<%# Bind("t_srno") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="ctPUActivity"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_plsd" runat="server" Text="Planned Start Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_plsd"
            Text='<%# Bind("t_plsd") %>'
            Enabled = "False"
            ToolTip="Value of Planned Start Date."
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_plfd" runat="server" Text="Planned Finish Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_plfd"
            Text='<%# Bind("t_plfd") %>'
            Enabled = "False"
            ToolTip="Value of Planned Finish Date."
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_acsd" runat="server" Text="Actual Start Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_acsd"
            Text='<%# Bind("t_acsd") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="ctPUActivity"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtont_acsd" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEt_acsd"
            TargetControlID="F_t_acsd"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtont_acsd" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_acsd"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_acsd" />
          <AJX:MaskedEditValidator 
            ID = "MEVt_acsd"
            runat = "server"
            ControlToValidate = "F_t_acsd"
            ControlExtender = "MEEt_acsd"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_aced" runat="server" Text="Actual Finish Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_aced"
            Text='<%# Bind("t_aced") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="ctPUActivity"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtont_aced" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEt_aced"
            TargetControlID="F_t_aced"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtont_aced" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_aced"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_aced" />
          <AJX:MaskedEditValidator 
            ID = "MEVt_aced"
            runat = "server"
            ControlToValidate = "F_t_aced"
            ControlExtender = "MEEt_aced"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_otsd" runat="server" Text="Outlook Start Date :" />
        </td>
        <td>
          <asp:TextBox ID="F_t_otsd"
            Text='<%# Bind("t_otsd") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="ctPUActivity"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtont_otsd" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEt_otsd"
            TargetControlID="F_t_otsd"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtont_otsd" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_otsd"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_otsd" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_oted" runat="server" Text="Outlook Finish Date :" />
        </td>
        <td>
          <asp:TextBox ID="F_t_oted"
            Text='<%# Bind("t_oted") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="ctPUActivity"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtont_oted" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEt_oted"
            TargetControlID="F_t_oted"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtont_oted" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_oted"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_oted" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_rmks" runat="server" Text="Remarks :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_rmks"
            Text='<%# Bind("t_rmks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_tpgv" runat="server" Text="Value :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_tpgv"
            Text='<%# Bind("t_tpgv") %>'
            Width="128px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="ctPUActivity"
            MaxLength="15"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEt_tpgv"
            runat = "server"
            mask = "999999999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_t_tpgv" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_puom" runat="server" Text="UOM :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_puom"
            Text='<%# Bind("t_puom") %>'
            Enabled = "False"
            ToolTip="Value of UOM."
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSctPUActivity"
  DataObjectTypeName = "SIS.CT.ctPUActivity"
  InsertMethod="UZ_ctPUActivityInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctPUActivity"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
