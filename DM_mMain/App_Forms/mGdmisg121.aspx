<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" CodeFile="mGdmisg121.aspx.vb" Inherits="mGF_dmisg121" title="List: Documents" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
<style>
.switch {
  position: relative;
  display: inline-block;
  width: 50px;
  height: 24px;
}

.switch input {display:none;}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 16px;
  width: 16px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 24px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>
<style>
    a.transparent-input{
       background-color:rgba(0,0,0,0) !important;
       border:none !important;
    }
    span.transparent-input{
       background-color:rgba(0,0,0,0) !important;
       border:none !important;
    }
</style>
</asp:Content>
<asp:Content ID="CPHdmisg121" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container-fluid" id="divOK" runat="server" clientidmode="static">
    <div class="row">
      <div class="col-sm-12 text-center">
        <h3>
          <asp:Label ID="Labeldmisg121" runat="server" Text="Released Document List [All Revisions]"></asp:Label></h3>
        <h5>
          <asp:Label ID="Label1" runat="server" Text="[Please refer DOCUMENT LINKING session for documents released before 20-08-2018]"></asp:Label></h5>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <asp:DropDownList ID="F_Company" runat="server" AutoPostBack="true">
          <asp:ListItem Selected="True" Text="ISGEC" Value="200"></asp:ListItem>
          <asp:ListItem Text="REDECAM" Value="700"></asp:ListItem>
          <asp:ListItem Text="ISGEC COVEMA" Value="651"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>
    <asp:Button ID="cmdDelete" ClientIDMode="static" runat="server" style="display:none;" />
    <div class="row">
      <div class="col-sm-12">
        <asp:UpdatePanel ID="UPNLdmisg121" runat="server">
          <ContentTemplate>
            <LGM:ToolBar0
              ID="TBLdmisg121200"
              ToolType="lgNMGrid"
              SVisible="false"
              runat="server" />
            <div class="form-group">
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text">Latest Released :</span>
                </div>
                <div class="form-control" style="text-align: right; max-height: 38px !important">
                  <label class="switch ">
                    <asp:CheckBox ID="F_LatestRevision" runat="server" AutoPostBack="true" />
                    <span class="slider round"></span>
                  </label>
                </div>
              </div>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text">Search :</span>
                </div>
                <asp:TextBox
                  ID="F_SearchText"
                  CssClass="form-control"
                  onfocus="return this.select();"
                  runat="Server" />
                <asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-dark" Text="Search" />
              </div>
            </div>
            <iframe id="xFrame" name="xFrame" style="height: 20px; width: 20px; display: none;"></iframe>
            <div class="container-fluid chartDiv">
              <div class="row">
                <div class="col-sm-12 text-center">
                  <h5>
                    Selected Documents for Download
                  </h5>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10 text-center" style="overflow-y:scroll;height:100px;">
                  <asp:CheckBoxList 
                    ID="lstSelected" 
                    ClientIDMode="static" 
                    Width="100%"
                    RepeatColumns="5" 
                    RepeatDirection="Horizontal" 
                    runat="server">
                  </asp:CheckBoxList>
                </div>
                <div class="col-sm-1"></div>
              </div>
              <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-2">
                  <asp:Button ID="cmdRemove" runat="server" CssClass="btn-danger" Text="Remove" />
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-2">
                  <asp:Button ID="cmdDownload" runat="server" CssClass="btn-success" Text="Download" />
                </div>
                <div class="col-sm-3"></div>
              </div>
            </div>
            <asp:GridView 
              ID="GVdmisg121" 
              Width="98%" 
              runat="server" 
              AllowPaging="True" 
              AllowSorting="True" 
              PagerSettings-Position="TopAndBottom" 
              DataSourceID="ODSdmisg121" 
              DataKeyNames="t_docn,t_revn" 
              HeaderStyle-BackColor="Black"
              HeaderStyle-ForeColor="White"
              AutoGenerateColumns="False">
              <Columns>
                <asp:TemplateField HeaderText="Document" SortExpression="t_docn">
                  <ItemTemplate>
                    <%--<asp:LinkButton ID="L_t_docn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("t_docn") %>' Text='<%# Eval("t_docn") %>'  OnClientClick='<%# Eval("GetDownloadLink") %>'></asp:LinkButton>--%>
                    <a href='<%# Eval("GetDownloadLink") %>' target="xFrame"><%# EVal("t_docn") %></a>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rev" SortExpression="t_revn">
                  <ItemTemplate>
                    <asp:Label ID="Labelt_revn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle CssClass="alignCenter" />
                  <HeaderStyle CssClass="alignCenter" />
                </asp:TemplateField>
                <asp:TemplateField >
                  <HeaderTemplate>
                    <asp:Button ID="L_SelectAll" runat="server" Text="SelectAll" CommandArgument="SelectAll" CommandName="Sort" ></asp:Button>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:Button ID="cmdSelect" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text="Select" CommandName="cmdSelect" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                  </ItemTemplate>
                  <ItemStyle CssClass="alignCenter" />
                  <HeaderStyle CssClass="alignCenter" />
                </asp:TemplateField>
                <asp:TemplateField>
                  <HeaderTemplate>
                    <div class="row">
                      <div class="col-sm-6 text-left">
                         <asp:Label ID="L_Desc" runat="server" Text="Description"></asp:Label>
                      </div>
                      <div class="col-sm-4 text-right">
                        <h6>Page Size:</h6>
                      </div>
                      <div class="col-sm-2 text-right">
                        <asp:DropDownList ID="D_PageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSizeChanged" >
                          <asp:ListItem Text="--" Value="0"></asp:ListItem>
                          <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="25" Value="25"></asp:ListItem>
                          <asp:ListItem Text="50" Value="50"></asp:ListItem>
                          <asp:ListItem Text="75" Value="75"></asp:ListItem>
                          <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                    </div>
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:Label ID="Labelt_dsca" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_dsca") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
              <EmptyDataTemplate>
                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
              </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource
              ID="ODSdmisg121"
              runat="server"
              DataObjectTypeName="SIS.DMISG.dmisg121200"
              OldValuesParameterFormatString="original_{0}"
              SelectMethod="UZ_dmisg121200SelectList"
              SelectCountMethod="UZ_dmisg121200Count"
              TypeName="SIS.DMISG.dmisg121200"
              SortParameterName="OrderBy"
              EnablePaging="True">
              <SelectParameters>
                <asp:ControlParameter ControlID="F_SearchText" PropertyName="Text" Name="SearchText" Type="String" DefaultValue="" Size="250" />
                <asp:ControlParameter ControlID="F_LatestRevision" PropertyName="Checked" Name="LatestRevision" Type="Boolean" DefaultValue="False" Direction="Input" Size="3" />
                <asp:ControlParameter ControlID="F_Company" PropertyName="SelectedValue" Name="Comp" Type="String" DefaultValue="200" Direction="Input" Size="3" />
                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              </SelectParameters>
            </asp:ObjectDataSource>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmdSearch" />
            <asp:PostBackTrigger ControlID="cmdDownload" />
          </Triggers>
        </asp:UpdatePanel>

      </div>
    </div>
  </div>
  <div class="container-fluid text-center" id="divErr" runat="server" clientidmode="static">
    <h1>Access Denied</h1>
  </div>

</asp:Content>
