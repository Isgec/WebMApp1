<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_ctProjects.ascx.vb" Inherits="LC_ctProjects" %>
<asp:DropDownList 
  ID = "DDLctProjects"
  DataSourceID = "OdsDdlctProjects"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorctProjects"
  Runat = "server" 
  ControlToValidate = "DDLctProjects"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlctProjects"
  TypeName = "SIS.CT.ctProjects"
  SortParameterName = "OrderBy"
  SelectMethod = "ctProjectsSelectList"
  Runat="server" />
