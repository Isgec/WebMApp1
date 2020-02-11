<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboardCostSheet.aspx.vb" Inherits="mGctDashboardCostSheet" Title="Cost Sheet" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmdBilling" runat="server" Text="Billing Status" ToolTip="Billing Status Dashboard" />
  <asp:LinkButton ID="cmdOutstanding" runat="server" Text="Outstanding Status" ToolTip="Outstanding Status" />
  <asp:LinkButton ID="cmdCoverSheet" runat="server" Text="Cover Sheet" ToolTip="Cover Sheet" />
<%--  <asp:LinkButton ID="cmd30Next" runat="server" Text="Progress Status [Next 30 Days]" ToolTip="Next 30 days." />
  <asp:LinkButton ID="cmdDelayed" runat="server" Text="Delayed Status [Overall]" ToolTip="Delayed Since Project Start." />
  <asp:LinkButton ID="cmdFinance" runat="server" Text="Financial Dashboard" ToolTip="Financial Dashboard." />--%>
</div>

  <%--Main Container--%>
  <div class="container" style="margin-top: 10px">
    <%--Project Selection Drop Down--%>
    <div class="row">
      <div class="col-sm-12">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">
              <div class="input-group mb-3">
                <span class=" btn btn-sm btn-dark" style="width: 40px; text-align: center; cursor: pointer" title="Menu" onclick="openNav()">&#9776;</span>
                <asp:DropDownList
                  ID="F_t_ccod"
                  CssClass="form-control"
                  ClientIDMode="static"
                  runat="Server">
                </asp:DropDownList>
                <AJX:CascadingDropDown
                  ID="cF_t_ccod"
                  TargetControlID="F_t_ccod"
                  PromptText="Select Contract"
                  PromptValue=""
                  ServicePath="~/App_Services/MfgServices.asmx"
                  ServiceMethod="GetContractsCashflow"
                  Category="t_ccod"
                  LoadingText="Loading. . ."
                  runat="server" />
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary btn-sm" Text="SHOW" />
              </div>
            </div>
            <br />
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
    <%--Contract Detaila--%>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5>
          <asp:Label ID="Label1" runat="server" Font-Underline="true" Text="CASH FLOW"></asp:Label></h5>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h4>
          <asp:Label ID="ContractName" runat="server"></asp:Label></h4>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-8 text-left">
        <h5><asp:Label ID="L_Customer" Font-Bold="true" runat="server" Text=""></asp:Label></h5>
      </div>
      <div class="col-sm-4 text-right">
        <asp:Label runat="server" Text="[All amounts are in LAKH]" ForeColor="Red" Font-Italic="true"></asp:Label>
      </div>
    </div>
    <%--Cashflow Detaila--%>
    <div class="chartDiv text-left">
      <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="Label2" runat="server">TOTAL BUDGET [Inflow]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LTBI" Font-Bold="true" runat="server"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label5" runat="server">TOTAL ACTUAL [Inflow]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LTAI" Font-Bold="true" runat="server"></asp:Label>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="Label3" runat="server">TOTAL BUDGET [Outflow]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LTBO" Font-Bold="true" runat="server"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label8" runat="server">TOTAL ACTUAL [Outflow]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LTAO" Font-Bold="true" runat="server"></asp:Label>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="Label10" runat="server">BUDGET [Net]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LBN" Font-Bold="true" runat="server"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label12" runat="server">ACTUAL [Net]:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LAN" Font-Bold="true" runat="server"></asp:Label>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3 text-right" >
            <asp:Label ID="Label4" runat="server">CASHFLOW STATUS:</asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="LSTATUS" Font-Bold="true" runat="server"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label7" runat="server"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label9" Font-Bold="true" runat="server"></asp:Label>
        </div>
      </div>
    </div>
    <%--NET-Cumulative Row--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" style="overflow:scroll;" >
          <h5>Budget vs Actual - NET Cashflow - Cumulative</h5>
          <asp:Chart
            ID="Chart4"
            Height="400px"
            Width="1000px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend1" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea1">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Chart4Data" runat="server" class="container-fluid text-center"></div>
        </div>
      </div>
    </div>

    <%--Main Budget vs Actual Row Inflow--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" style="overflow:scroll;" >
          <h5>Budget vs Actual - Inflow</h5>
          <asp:Chart
            ID="Chart1"
            Height="400px"
            Width="1000px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend1" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea1">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Chart1Data" runat="server" class="container-fluid text-center"></div>
        </div>
      </div>
    </div>
    <%--Main Budget vs Actual Row Outflow--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" style="overflow:scroll;" >
          <h5>Budget vs Actual - Outflow</h5>
          <asp:Chart
            ID="Chart5"
            Height="400px"
            Width="1000px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend1" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea1">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Chart5Data" runat="server" class="container-fluid text-center"></div>
        </div>
      </div>
    </div>

  </div>
</asp:Content>
