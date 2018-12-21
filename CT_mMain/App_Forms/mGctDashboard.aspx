<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboard.aspx.vb" Inherits="mGctDashboard" Title="Project Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmdActivitySCurve" runat="server" Text="Activity Type wise S-Curve" ToolTip="S-Curve of Major Activities." />
  <asp:LinkButton ID="cmd30Days" runat="server" Text="Progress Status [Last 30 Days]" ToolTip="Last 30 days." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Progress Status [Overall]" ToolTip="Since Project Start." />
  <asp:LinkButton ID="cmd30Next" runat="server" Text="Progress Status [Next 30 Days]" ToolTip="Next 30 days." />
  <asp:LinkButton ID="cmdDelayed" runat="server" Text="Delayed Status [Overall]" ToolTip="Delayed Since Project Start." />
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
                <span class=" btn btn-sm btn-dark" style="width:40px;text-align:center;cursor:pointer" title="Menu" onclick="openNav()">&#9776;</span>
                <asp:DropDownList
                  ID="F_t_cprj"
                  CssClass="form-control"
                  ClientIDMode="static"
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
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary btn-sm" Text="SHOW" />
                <%--<asp:HyperLink ID="cmdHome" runat="server" CssClass="btn btn-danger btn-sm" Text="HOME" NavigateUrl="~/mMenu.aspx"></asp:HyperLink>--%>
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
    <%--Project & Period Detaila--%>
    <div class="row">
      <div class="col-sm-4 text-center">
      <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text="PROGRESS S-CURVE"></asp:Label></h5>
      </div>
      <div class="col-sm-4 text-center">
      <h4><asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
      </div>
      <div class="col-sm-4 text-center">
      <h6>(<asp:Label ID="ProjectPeriod" runat="server"></asp:Label>)</h6>
      </div>
    </div>
    <%--Main Graph Row--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" >
          <h5>OVERALL SUMMARY</h5>
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
          <div id="OverallDataTable" runat="server" class="container-fluid text-center"></div>
        </div>
      </div>
    </div>
    <%--Start Finish Counts--%>
    <div class="row chartDiv">
      <div class="col-sm-6 text-center">
        <h5>
          <asp:Label ID="Label2" runat="server" Text="Activity - Due for Start "></asp:Label></h5>
        <h6>
          <asp:Label ID="Label3" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
        <div id="ReviewSheetStart" runat="server" class="container-fluid text-center">
          <table class='table-bordered' style='width: 100%; margin: 5px 5px 5px 5px;'>
            <thead>
              <tr style="background-color: black; color: white;">
                <th rowspan="2" style='text-align: center;'></th>
                <th rowspan="2" style='text-align: center;'>Early Start</th>
                <th rowspan="2" style='text-align: center;'>On Time</th>
                <th colspan="4" style='text-align: center;'>Delay [Days]</th>
              </tr>
              <tr style="background-color: black; color: white;">
                <th style='text-align: center;'>1 to 30 </th>
                <th style='text-align: center;'>31 to 60 </th>
                <th style='text-align: center;'>61 to 90</th>
                <th style='text-align: center;'>> 91</th>
              </tr>
            </thead>
            <tr>
              <td style='text-align: center; font-weight: bold;'>STARTED</td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="STE" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="ST0" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="ST10" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="ST20" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="ST30" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="STZ" runat="server" OnClick="abc"></asp:Button>
              </td>
            </tr>
            <tr>
              <td style='text-align: center; font-weight: bold;'>NOT STARTED</td>
              <td style='text-align: center;'>-</td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="NST0" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NST10" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NST20" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NST30" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NSTZ" runat="server" OnClick="abc"></asp:Button>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div class="col-sm-6 text-center ">
        <h5>
          <asp:Label ID="Label4" runat="server" Text="Activity - Due for Finish "></asp:Label></h5>
        <h6>
          <asp:Label ID="Label5" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
        <div id="ReviewSheetFinish" runat="server" class="container-fluid text-center">
          <table class='table-bordered' style='width: 100%; margin: 5px 5px 5px 5px;'>
            <thead>
              <tr style="background-color: black; color: white;">
                <th rowspan="2" style='text-align: center;'></th>
                <th rowspan="2" style='text-align: center;'>Early Finish</th>
                <th rowspan="2" style='text-align: center;'>On Time</th>
                <th colspan="4" style='text-align: center;'>Delay [Days]</th>
              </tr>
              <tr style="background-color: black; color: white;">
                <th style='text-align: center;'>1 to 30</th>
                <th style='text-align: center;'>31 to 60 </th>
                <th style='text-align: center;'>61 to 90 </th>
                <th style='text-align: center;'>> 91 </th>
              </tr>
            </thead>
            <tr>
              <td style='text-align: center; font-weight: bold;'>FINISHED</td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="FDE" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="FD0" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="FD10" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="FD20" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="FD30" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="FDZ" runat="server" OnClick="abc"></asp:Button>
              </td>
            </tr>
            <tr>
              <td style='text-align: center; font-weight: bold;'>NOT FINISHED</td>
              <td style='text-align: center;'>-</td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-success fix" ID="NFD0" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NFD10" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NFD20" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NFD30" runat="server" OnClick="abc"></asp:Button>
              </td>
              <td style='text-align: center;'>
                <asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NFDZ" runat="server" OnClick="abc"></asp:Button>
              </td>
            </tr>
          </table>
        </div>

      </div>
    </div>

  </div>


</asp:Content>
