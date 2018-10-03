<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_ctPActivity.ascx.vb" Inherits="LC_ctPActivity" %>
<asp:DropDownList 
  ID = "DDLctPActivity"
  DataSourceID = "OdsDdlctPActivity"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorctPActivity"
  Runat = "server" 
  ControlToValidate = "DDLctPActivity"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlctPActivity"
  TypeName = "SIS.CT.ctPActivity"
  SortParameterName = "OrderBy"
  SelectMethod = "ctPActivitySelectList"
  Runat="server" />
