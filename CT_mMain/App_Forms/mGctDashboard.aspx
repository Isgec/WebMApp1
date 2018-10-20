<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboard.aspx.vb" Inherits="mGctDashboard" title="Project Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
  <style>
.chartDiv {
  overflow: hidden;
  margin: 15px auto;
  padding: 0px 0px 6px 0px;
  text-align:center;
  /*background: #e3e3e3;*/
  color: #333333;
  -moz-border-radius: 5px;
  -webkit-border-radius: 5px;
  border-radius: 5px;
  border: 1px solid gray;
}

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
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container" style="margin-top:30px">
    <div class="row">
      <div class="col-sm-4">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">
              <div class="input-group mb-3">
                <asp:DropDownList
                  ID="F_t_cprj"
                  CssClass="form-control"
                  runat="Server">
                </asp:DropDownList>
                <AJX:CascadingDropDown
                  ID="cF_t_cprj"
                  TargetControlID="F_t_cprj"
                  PromptText="Select Project"
                  PromptValue=""
                  ServicePath="~/App_Services/MfgServices.asmx"
                  ServiceMethod="GetProjects"
                  Category="t_cprj"
                  LoadingText="Loading. . ."
                  runat="server" />
              </div>
              <div class="input-group mb-3">
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary btn-sm" Text="SHOW" />
              </div>
              <div class="input-group mb-3">
                <asp:HyperLink ID="cmdHome" runat="server" CssClass="btn btn-danger btn-sm" Text="HOME" NavigateUrl="~/mMenu.aspx"></asp:HyperLink>
              </div>
            </div>
            <br />
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
      <div class="col-sm-8">
        <h2>DASHBOARD</h2>
        <div class="container-fluid">
          <div class="chartDiv">
                <h2>Overall Planned Vs Actual</h2>
            <asp:Chart
              ID="Chart1"
              DataSourceID="ODStpisg216"
              Height="200px"
              Width="300px"
              ClientIDMode="Predictable"
              runat="server">
              <Series>
                <asp:Series Name="Series1" ChartArea="ChartArea1" XValueMember="t_curr" YValueMembers="t_prop" ChartType="Spline"></asp:Series>
                <asp:Series Name="Series2" ChartArea="ChartArea1" XValueMember="t_curr" YValueMembers="t_proa" ChartType="Spline"></asp:Series>
              </Series>
              
              <ChartAreas>
                <asp:ChartArea Name="ChartArea1" >
                  
                  <AxisX Interval="10">
                    <MajorGrid Enabled="False" />
                  </AxisX>
                  <AxisY>
                    <MajorGrid Enabled="False" />
                    
                    <CustomLabels>
                      <asp:CustomLabel Text="% Progress" />
                    </CustomLabels>
                  </AxisY>
                </asp:ChartArea>
              </ChartAreas>
            </asp:Chart>
            <asp:ObjectDataSource
              ID="ODStpisg216"
              runat="server"
              SelectMethod="SelectList"
              TypeName="SIS.CT.tpisg216" 
              OldValuesParameterFormatString="original_{0}">
              <SelectParameters>
                <asp:ControlParameter ControlID="F_t_cprj" PropertyName="SelectedValue" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
              </SelectParameters>
            </asp:ObjectDataSource>
          </div>
          <br />
          <br />
          <asp:Repeater ID="rCharts" runat="server" DataSourceID="ODStpisg206" ClientIDMode="Predictable">
            <ItemTemplate>
              <div class="chartDiv">
                <h3><%# Eval("t_dsca") %></h3>
                <asp:Label ID="L_t_acty" runat="server" Text='<%# Eval("t_acty") %>' style="display:none;" ></asp:Label>
                <asp:Label ID="L_t_cprj" runat="server" Text='<%# Eval("t_cprj") %>' style="display:none;"></asp:Label>
                <asp:Chart
                  ID="Chart2"
                  Height="200px"
                  Width="700px"
                  DataSourceID="ODStpisg214"
                  IsMapEnabled="true"
                  RenderType="ImageTag"
                  runat="server" >
                  <Series>
                    <asp:Series 
                      Name="Series3" 
                      ChartArea="ChartArea2" 
                      XValueMember="t_date" 
                      YValueMembers="t_pprc" 
                      ChartType="Spline" 
                      XValueType="DateTime" 
                      ToolTip="Value of X: #VALX Value of Y #VALY" 
                      LegendText="Planned Progress %" 
                      IsVisibleInLegend="True" 
                      Legend="Legend2" >
                      <SmartLabelStyle Enabled="true" />
                    </asp:Series>
                    <asp:Series 
                      Name="Series4" 
                      ChartArea="ChartArea2" 
                      XValueMember="t_date" 
                      YValueMembers="t_acpr" 
                      ChartType="Spline" 
                      XValueType="DateTime" 
                      ToolTip="Value of X: #VALX Value of Y #VALY" 
                      LegendText="Actual Progress %" 
                      IsVisibleInLegend="True" 
                      Legend="Legend2"  >
                    </asp:Series>
                  </Series>
                  <Legends>
                    <asp:Legend Name="Legend2" ></asp:Legend>
                  </Legends>
                  <ChartAreas>
                    <asp:ChartArea Name="ChartArea2">
                      <AxisX Interval="5" Title="Time" TitleForeColor="Blue" >
                        <MajorGrid LineColor="LightGray" LineWidth="1" />
                      </AxisX>
                      <AxisY Interval="10" Minimum="0" Maximum="100" Title="% Progress" TitleForeColor="Blue" >
                        <MajorGrid LineColor="LightGray" LineWidth="1"  />
                      </AxisY>
                    </asp:ChartArea>
                  </ChartAreas>
                </asp:Chart>
                <asp:ObjectDataSource
                  ID="ODStpisg214"
                  runat="server"
                  SelectMethod="SelectList"
                  TypeName="SIS.CT.tpisg214" 
                  OldValuesParameterFormatString="original_{0}">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="L_t_cprj" PropertyName="Text" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
                    <asp:ControlParameter ControlID="L_t_acty" PropertyName="Text" Name="t_acty" Type="String" DefaultValue=""  />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </div>
            </ItemTemplate>
          </asp:Repeater>
          <asp:ObjectDataSource
            ID="ODStpisg206"
            runat="server"
            SelectMethod="SelectList"
            TypeName="SIS.CT.tpisg206" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
              <asp:ControlParameter ControlID="F_t_cprj" PropertyName="SelectedValue" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
