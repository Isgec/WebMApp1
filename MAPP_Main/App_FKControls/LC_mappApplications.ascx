<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_mappApplications.ascx.vb" Inherits="LC_mappApplications" %>
<asp:DropDownList 
  ID = "DDLmappApplications"
  DataSourceID = "OdsDdlmappApplications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatormappApplications"
  Runat = "server" 
  ControlToValidate = "DDLmappApplications"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlmappApplications"
  TypeName = "SIS.MAPP.mappApplications"
  SortParameterName = "OrderBy"
  SelectMethod = "mappApplicationsSelectList"
  Runat="server" />
