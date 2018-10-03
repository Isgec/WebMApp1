<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_wfDBIcons.ascx.vb" Inherits="LC_wfDBIcons" %>
<asp:DropDownList 
  ID = "DDLwfDBIcons"
  DataSourceID = "OdsDdlwfDBIcons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorwfDBIcons"
  Runat = "server" 
  ControlToValidate = "DDLwfDBIcons"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlwfDBIcons"
  TypeName = "SIS.WF.wfDBIcons"
  SortParameterName = "OrderBy"
  SelectMethod = "wfDBIconsSelectList"
  Runat="server" />
