<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_ctPUActivity.aspx.vb" Inherits="EF_ctPUActivity" title="Edit: Project Activity Updates" %>
<asp:Content ID="CPHctPUActivity" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctPUActivity" runat="server" Text="&nbsp;Edit: Project Activity Updates"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctPUActivity" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctPUActivity"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "ctPUActivity"
    runat = "server" />
<asp:FormView ID="FVctPUActivity"
  runat = "server"
  DataKeyNames = "t_cprj,t_atid,t_srno"
  DataSourceID = "ODSctPUActivity"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_cprj" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_t_cprj"
            Width="56px"
            Text='<%# Bind("t_cprj") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_t_cprj_Display"
            Text='<%# Eval("ttcmcs0522001_t_dsca") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_atid" runat="server" ForeColor="#CC6633" Text="Activity :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_t_atid"
            Width="248px"
            Text='<%# Bind("t_atid") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Activity."
            Runat="Server" />
          <asp:Label
            ID = "F_t_atid_Display"
            Text='<%# Eval("ttpisg2202002_t_iref") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_srno" runat="server" ForeColor="#CC6633" Text="Sr.No. :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_srno"
            Text='<%# Bind("t_srno") %>'
            ToolTip="Value of Sr.No.."
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
          <asp:Label ID="L_t_plsd" runat="server" Text="Planned Start Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_plsd"
            Text='<%# Bind("t_plsd") %>'
            ToolTip="Value of Planned Start Date."
            Enabled = "False"
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
            ToolTip="Value of Planned Finish Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_acsd" runat="server" Text="Actual Start Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_acsd"
            Text='<%# Bind("t_acsd") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
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
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_otsd" runat="server" Text="Outlook Start Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_otsd"
            Text='<%# Bind("t_otsd") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
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
          <AJX:MaskedEditValidator 
            ID = "MEVt_otsd"
            runat = "server"
            ControlToValidate = "F_t_otsd"
            ControlExtender = "MEEt_otsd"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_oted" runat="server" Text="Outlook Finish Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_oted"
            Text='<%# Bind("t_oted") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
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
          <AJX:MaskedEditValidator 
            ID = "MEVt_oted"
            runat = "server"
            ControlToValidate = "F_t_oted"
            ControlExtender = "MEEt_oted"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_rmks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_rmks"
            Text='<%# Bind("t_rmks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="ctPUActivity"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVt_rmks"
            runat = "server"
            ControlToValidate = "F_t_rmks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_tpgv" runat="server" Text="Value :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_t_tpgv"
            Text='<%# Bind("t_tpgv") %>'
            style="text-align: right"
            Width="128px"
            CssClass = "mytxt"
            ValidationGroup= "ctPUActivity"
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
          <AJX:MaskedEditValidator 
            ID = "MEVt_tpgv"
            runat = "server"
            ControlToValidate = "F_t_tpgv"
            ControlExtender = "MEEt_tpgv"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "ctPUActivity"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_puom" runat="server" Text="UOM :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_puom"
            Text='<%# Bind("t_puom") %>'
            ToolTip="Value of UOM."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_crby" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_crby"
            Text='<%# Bind("t_crby") %>'
            ToolTip="Value of Created By."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_cron" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_cron"
            Text='<%# Bind("t_cron") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_gps1" runat="server" Text="Longitude :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_gps1"
            Text='<%# Bind("t_gps1") %>'
            ToolTip="Value of Longitude."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_gps2" runat="server" Text="Latitude :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_gps2"
            Text='<%# Bind("t_gps2") %>'
            ToolTip="Value of Latitude."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_gps3" runat="server" Text="Altitude :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_gps3"
            Text='<%# Bind("t_gps3") %>'
            ToolTip="Value of Altitude."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_gps4" runat="server" Text="Place Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_gps4"
            Text='<%# Bind("t_gps4") %>'
            ToolTip="Value of Place Name."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
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
  ID = "ODSctPUActivity"
  DataObjectTypeName = "SIS.CT.ctPUActivity"
  SelectMethod = "ctPUActivityGetByID"
  UpdateMethod="UZ_ctPUActivityUpdate"
  DeleteMethod="UZ_ctPUActivityDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctPUActivity"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cprj" Name="t_cprj" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_atid" Name="t_atid" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_srno" Name="t_srno" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
