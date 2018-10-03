<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_mappUserApps.aspx.vb" Inherits="AF_mappUserApps" title="Add: Application Authorization" %>
<asp:Content ID="CPHmappUserApps" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelmappUserApps" runat="server" Text="&nbsp;Add: Application Authorization"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLmappUserApps" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLmappUserApps"
    ToolType = "lgNMAdd"
    InsertAndStay = "True"
    ValidationGroup = "mappUserApps"
    runat = "server" />
<asp:FormView ID="FVmappUserApps"
  runat = "server"
  DataKeyNames = "AppID,UserID"
  DataSourceID = "ODSmappUserApps"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgmappUserApps" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AppID" ForeColor="#CC6633" runat="server" Text="App. ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_AppID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("AppID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for App. ID."
            ValidationGroup = "mappUserApps"
            onblur= "script_mappUserApps.validate_AppID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAppID"
            runat = "server"
            ControlToValidate = "F_AppID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "mappUserApps"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_AppID_Display"
            Text='<%# Eval("MAPP_Applications2_ApplicationName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEAppID"
            BehaviorID="B_ACEAppID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="AppIDCompletionList"
            TargetControlID="F_AppID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_mappUserApps.ACEAppID_Selected"
            OnClientPopulating="script_mappUserApps.ACEAppID_Populating"
            OnClientPopulated="script_mappUserApps.ACEAppID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" ForeColor="#CC6633" runat="server" Text="User ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for User ID."
            ValidationGroup = "mappUserApps"
            onblur= "script_mappUserApps.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "mappUserApps"
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
            OnClientItemSelected="script_mappUserApps.ACEUserID_Selected"
            OnClientPopulating="script_mappUserApps.ACEUserID_Populating"
            OnClientPopulated="script_mappUserApps.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsActive" runat="server" Text="Is Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsActive"
           Checked='<%# Bind("IsActive") %>'
           CssClass = "mychk"
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
  ID = "ODSmappUserApps"
  DataObjectTypeName = "SIS.MAPP.mappUserApps"
  InsertMethod="mappUserAppsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.MAPP.mappUserApps"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
