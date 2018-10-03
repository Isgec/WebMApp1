<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_ctPActivity.aspx.vb" Inherits="EF_ctPActivity" title="Edit: Project Activity" %>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelctPActivity" runat="server" Text="&nbsp;Edit: Project Activity"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLctPActivity" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLctPActivity"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "ctPActivity"
    runat = "server" />
<asp:FormView ID="FVctPActivity"
  runat = "server"
  DataKeyNames = "t_cprj,t_cact"
  DataSourceID = "ODSctPActivity"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_cprj" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_t_cprj"
            Width="56px"
            Text='<%# Bind("t_cprj") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
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
          <b><asp:Label ID="L_t_cact" runat="server" ForeColor="#CC6633" Text="Activity ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_t_cact"
            Width="248px"
            Text='<%# Bind("t_cact") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Activity ID."
            Runat="Server" />
          <asp:Label
            ID = "F_t_cact_Display"
            Text='<%# Eval("ttpisg2002002_t_desc") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_pcod" runat="server" Text="Product Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_t_pcod"
            Width="80px"
            Text='<%# Bind("t_pcod") %>'
            Enabled = "False"
            ToolTip="Value of Product Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_t_pcod_Display"
            Text='<%# Eval("ttpisg2002002_t_desc") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_sdst" runat="server" Text="Schedule Start :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_sdst"
            Text='<%# Bind("t_sdst") %>'
            ToolTip="Value of Schedule Start."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_sdfn" runat="server" Text="Schedule Finish :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_sdfn"
            Text='<%# Bind("t_sdfn") %>'
            ToolTip="Value of Schedule Finish."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_acsd" runat="server" Text="Actual Start :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_acsd"
            Text='<%# Bind("t_acsd") %>'
            ToolTip="Value of Actual Start."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_acfn" runat="server" Text="Actual Finish :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_acfn"
            Text='<%# Bind("t_acfn") %>'
            ToolTip="Value of Actual Finish."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_iref" runat="server" Text="Item Reference :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_iref"
            Text='<%# Bind("t_iref") %>'
            ToolTip="Value of Item Reference."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelctPUActivity" runat="server" Text="&nbsp;List: Project Activity Updates"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLctPUActivity" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLctPUActivity"
      ToolType = "lgNMGrid"
      EditUrl = "~/CT_Main/App_Edit/EF_ctPUActivity.aspx"
      AddUrl = "~/CT_Main/App_Create/AF_ctPUActivity.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "ctPUActivity"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSctPUActivity" runat="server" AssociatedUpdatePanelID="UPNLctPUActivity" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVctPUActivity" SkinID="gv_silver" runat="server" DataSourceID="ODSctPUActivity" DataKeyNames="t_cprj,t_atid,t_srno">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sr.No." SortExpression="t_srno">
          <ItemTemplate>
            <asp:Label ID="Labelt_srno" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_srno") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Planned Start Date" SortExpression="t_plsd">
          <ItemTemplate>
            <asp:Label ID="Labelt_plsd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_plsd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Planned Finish Date" SortExpression="t_plfd">
          <ItemTemplate>
            <asp:Label ID="Labelt_plfd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_plfd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Start Date" SortExpression="t_acsd">
          <ItemTemplate>
            <asp:Label ID="Labelt_acsd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_acsd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actual Finish Date" SortExpression="t_aced">
          <ItemTemplate>
            <asp:Label ID="Labelt_aced" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_aced") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="t_puom">
          <ItemTemplate>
            <asp:Label ID="Labelt_puom" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_puom") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value" SortExpression="t_tpgv">
          <ItemTemplate>
            <asp:Label ID="Labelt_tpgv" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_tpgv") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSctPUActivity"
      runat = "server"
      DataObjectTypeName = "SIS.CT.ctPUActivity"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ctPUActivitySelectList"
      TypeName = "SIS.CT.ctPUActivity"
      SelectCountMethod = "ctPUActivitySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_cact" PropertyName="Text" Name="t_atid" Type="String" Size="30" />
        <asp:ControlParameter ControlID="F_t_cprj" PropertyName="Text" Name="t_cprj" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVctPUActivity" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSctPActivity"
  DataObjectTypeName = "SIS.CT.ctPActivity"
  SelectMethod = "ctPActivityGetByID"
  UpdateMethod="UZ_ctPActivityUpdate"
  DeleteMethod="ctPActivityDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.CT.ctPActivity"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cprj" Name="t_cprj" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cact" Name="t_cact" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
