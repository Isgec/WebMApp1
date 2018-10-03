<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_ntNotes.aspx.vb" Inherits="EF_ntNotes" title="Edit: Notes" %>
<asp:Content ID="CPHntNotes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelntNotes" runat="server" Text="&nbsp;Edit: Notes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLntNotes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLntNotes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "ntNotes"
    runat = "server" />
<asp:FormView ID="FVntNotes"
  runat = "server"
  DataKeyNames = "NotesId"
  DataSourceID = "ODSntNotes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Notes_RunningNo" runat="server" Text="Notes_RunningNo :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Notes_RunningNo"
            Text='<%# Bind("Notes_RunningNo") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "ntNotes"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEENotes_RunningNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Notes_RunningNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVNotes_RunningNo"
            runat = "server"
            ControlToValidate = "F_Notes_RunningNo"
            ControlExtender = "MEENotes_RunningNo"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_NotesId" runat="server" ForeColor="#CC6633" Text="NotesId :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_NotesId"
            Text='<%# Bind("NotesId") %>'
            ToolTip="Value of NotesId."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NotesHandle" runat="server" Text="NotesHandle :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_NotesHandle"
            Text='<%# Bind("NotesHandle") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for NotesHandle."
            MaxLength="200"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVNotesHandle"
            runat = "server"
            ControlToValidate = "F_NotesHandle"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IndexValue" runat="server" Text="IndexValue :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_IndexValue"
            Text='<%# Bind("IndexValue") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IndexValue."
            MaxLength="200"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIndexValue"
            runat = "server"
            ControlToValidate = "F_IndexValue"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Title" runat="server" Text="Title :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Title"
            Text='<%# Bind("Title") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTitle"
            runat = "server"
            ControlToValidate = "F_Title"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="20000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserId" runat="server" Text="UserId :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserId"
            CssClass = "myfktxt"
            Text='<%# Bind("UserId") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for UserId."
            ValidationGroup = "ntNotes"
            onblur= "script_ntNotes.validate_UserId(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserId"
            runat = "server"
            ControlToValidate = "F_UserId"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_UserId_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserId"
            BehaviorID="B_ACEUserId"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIdCompletionList"
            TargetControlID="F_UserId"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_ntNotes.ACEUserId_Selected"
            OnClientPopulating="script_ntNotes.ACEUserId_Populating"
            OnClientPopulated="script_ntNotes.ACEUserId_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Created_Date" runat="server" Text="Created_Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Created_Date"
            Text='<%# Bind("Created_Date") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            runat="server" />
          <asp:Image ID="ImageButtonCreated_Date" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECreated_Date"
            TargetControlID="F_Created_Date"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCreated_Date" />
          <AJX:MaskedEditExtender 
            ID = "MEECreated_Date"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Created_Date" />
          <AJX:MaskedEditValidator 
            ID = "MEVCreated_Date"
            runat = "server"
            ControlToValidate = "F_Created_Date"
            ControlExtender = "MEECreated_Date"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SendEmailTo" runat="server" Text="SendEmailTo :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SendEmailTo"
            Text='<%# Bind("SendEmailTo") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ntNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SendEmailTo."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSendEmailTo"
            runat = "server"
            ControlToValidate = "F_SendEmailTo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ntNotes"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSntNotes"
  DataObjectTypeName = "SIS.NT.ntNotes"
  SelectMethod = "ntNotesGetByID"
  UpdateMethod="UZ_ntNotesUpdate"
  DeleteMethod="UZ_ntNotesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NT.ntNotes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="NotesId" Name="NotesId" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
