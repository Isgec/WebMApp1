<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_ctUserDepartment.aspx.vb" Inherits="AF_ctUserDepartment" title="Add: Map User-Departments" %>
<asp:Content ID="CPHctUserDepartment" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctUserDepartment" runat="server" Text="&nbsp;Add: Map User-Departments"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctUserDepartment" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctUserDepartment"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "ctUserDepartment"
    runat = "server" />
<asp:FormView ID="FVctUserDepartment"
  runat = "server"
  DataKeyNames = "UserID,DepartmentID"
  DataSourceID = "ODSctUserDepartment"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgctUserDepartment" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "ctUserDepartment"
            onblur= "script_ctUserDepartment.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctUserDepartment"
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
            OnClientItemSelected="script_ctUserDepartment.ACEUserID_Selected"
            OnClientPopulating="script_ctUserDepartment.ACEUserID_Populating"
            OnClientPopulated="script_ctUserDepartment.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DepartmentID" ForeColor="#CC6633" runat="server" Text="Department :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DepartmentID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Department."
            ValidationGroup = "ctUserDepartment"
            onblur= "script_ctUserDepartment.validate_DepartmentID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDepartmentID"
            runat = "server"
            ControlToValidate = "F_DepartmentID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctUserDepartment"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentID"
            BehaviorID="B_ACEDepartmentID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentIDCompletionList"
            TargetControlID="F_DepartmentID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_ctUserDepartment.ACEDepartmentID_Selected"
            OnClientPopulating="script_ctUserDepartment.ACEDepartmentID_Populating"
            OnClientPopulated="script_ctUserDepartment.ACEDepartmentID_Populated"
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
  ID = "ODSctUserDepartment"
  DataObjectTypeName = "SIS.CT.ctUserDepartment"
  InsertMethod="ctUserDepartmentInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctUserDepartment"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
