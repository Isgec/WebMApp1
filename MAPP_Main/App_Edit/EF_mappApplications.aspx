<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_mappApplications.aspx.vb" Inherits="EF_mappApplications" title="Edit: Mobile Applications" %>
<asp:Content ID="CPHmappApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelmappApplications" runat="server" Text="&nbsp;Edit: Mobile Applications"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLmappApplications" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLmappApplications"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "mappApplications"
    runat = "server" />
<asp:FormView ID="FVmappApplications"
  runat = "server"
  DataKeyNames = "AppID"
  DataSourceID = "ODSmappApplications"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AppID" runat="server" ForeColor="#CC6633" Text="App. ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AppID"
            Text='<%# Bind("AppID") %>'
            ToolTip="Value of App. ID."
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
          <asp:Label ID="L_ApplicationName" runat="server" Text="Application Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApplicationName"
            Text='<%# Bind("ApplicationName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="mappApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Application Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApplicationName"
            runat = "server"
            ControlToValidate = "F_ApplicationName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "mappApplications"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApplicationDescription" runat="server" Text="Application Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApplicationDescription"
            Text='<%# Bind("ApplicationDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Application Description."
            MaxLength="250"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsActive" runat="server" Text="Is Active :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsActive"
            Checked='<%# Bind("IsActive") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MainPageURL" runat="server" Text="Main Page URL :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MainPageURL"
            Text='<%# Bind("MainPageURL") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="mappApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Main Page URL."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVMainPageURL"
            runat = "server"
            ControlToValidate = "F_MainPageURL"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "mappApplications"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AppIconID" runat="server" Text="App Icon :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_AppIconID"
            CssClass = "myfktxt"
            Text='<%# Bind("AppIconID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for App Icon."
            onblur= "script_mappApplications.validate_AppIconID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_AppIconID_Display"
            Text='<%# Eval("WF_DBIcons1_IconName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEAppIconID"
            BehaviorID="B_ACEAppIconID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="AppIconIDCompletionList"
            TargetControlID="F_AppIconID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_mappApplications.ACEAppIconID_Selected"
            OnClientPopulating="script_mappApplications.ACEAppIconID_Populating"
            OnClientPopulated="script_mappApplications.ACEAppIconID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AppIconStyle" runat="server" Text="App Icon Style :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AppIconStyle"
            Text='<%# Bind("AppIconStyle") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for App Icon Style."
            MaxLength="500"
            runat="server" />
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
  ID = "ODSmappApplications"
  DataObjectTypeName = "SIS.MAPP.mappApplications"
  SelectMethod = "mappApplicationsGetByID"
  UpdateMethod="UZ_mappApplicationsUpdate"
  DeleteMethod="UZ_mappApplicationsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.MAPP.mappApplications"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AppID" Name="AppID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
