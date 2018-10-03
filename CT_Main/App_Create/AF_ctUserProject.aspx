<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_ctUserProject.aspx.vb" Inherits="AF_ctUserProject" title="Add: Map User-Projects" %>
<asp:Content ID="CPHctUserProject" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctUserProject" runat="server" Text="&nbsp;Add: Map User-Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctUserProject" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctUserProject"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "ctUserProject"
    runat = "server" />
<asp:FormView ID="FVctUserProject"
  runat = "server"
  DataKeyNames = "UserID,ProjectID"
  DataSourceID = "ODSctUserProject"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgctUserProject" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" ForeColor="#CC6633" runat="server" Text="User :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for User."
            ValidationGroup = "ctUserProject"
            onblur= "script_ctUserProject.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctUserProject"
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
            OnClientItemSelected="script_ctUserProject.ACEUserID_Selected"
            OnClientPopulating="script_ctUserProject.ACEUserID_Populating"
            OnClientPopulated="script_ctUserProject.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "ctUserProject"
            onblur= "script_ctUserProject.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctUserProject"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_ctUserProject.ACEProjectID_Selected"
            OnClientPopulating="script_ctUserProject.ACEProjectID_Populating"
            OnClientPopulated="script_ctUserProject.ACEProjectID_Populated"
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
  ID = "ODSctUserProject"
  DataObjectTypeName = "SIS.CT.ctUserProject"
  InsertMethod="ctUserProjectInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctUserProject"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
