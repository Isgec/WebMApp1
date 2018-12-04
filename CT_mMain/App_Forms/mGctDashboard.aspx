<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboard.aspx.vb" Inherits="mGctDashboard" Title="Project Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
  <style>
    .chartDiv {
      overflow: hidden;
      margin: 15px auto;
      padding: 0px 0px 6px 0px;
      text-align: center;
      /*background: #e3e3e3;*/
      color: #333333;
      -moz-border-radius: 5px;
      -webkit-border-radius: 5px;
      border-radius: 5px;
      border: 1px solid gray;
    }
  </style>
  <style>
    .sidenav {
      height: 100%;
      width: 0;
      position: fixed;
      z-index: 1;
      top: 0;
      left: 0;
      background-color: #111;
      overflow-x: hidden;
      transition: 0.5s;
      padding-top: 60px;
    }

      .sidenav a {
        padding: 8px 8px 8px 32px;
        text-decoration: none;
        /*font-size: 25px;*/
        color: #818181;
        display: block;
        transition: 0.3s;
      }

        .sidenav a:hover {
          color: #f1f1f1;
        }

      .sidenav .closebtn {
        position: absolute;
        top: 0;
        right: 25px;
        font-size: 36px;
        margin-left: 50px;
      }

    @media screen and (max-height: 450px) {
      .sidenav {
        padding-top: 15px;
      }

        .sidenav a {
          font-size: 18px;
        }
    }
  </style>
  <script>
    function openNav() {
      document.getElementById("mySidenav").style.width = "250px";
    }

    function closeNav() {
      document.getElementById("mySidenav").style.width = "0";
    }
  </script>
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmdActivitySCurve" runat="server" Text="Activity wise S-Curve" ToolTip="S-Curve of Major Activities." />
  <asp:LinkButton ID="cmd30Days" runat="server" Text="Delayed Items [Last 30 Days]" ToolTip="Last 30 days from today." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Delayed Items [Backlog]" ToolTip="Since Project Start till 30 days befor from today." />
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
            DataSourceID="ODStpisg216"
            Height="400px"
            Width="1000px"
            ClientIDMode="Predictable"
            runat="server">
            <Series>
              <asp:Series
                Name="Series1"
                ChartArea="ChartArea1"
                XValueMember="t_curr"
                YValueMembers="t_prop"
                ChartType="Spline"
                XValueType="DateTime"
                ToolTip="Value of X: #VALX Value of Y #VALY"
                LegendText="Planned Progress %"
                IsVisibleInLegend="True"
                Legend="Legend1">
              </asp:Series>
              <asp:Series
                Name="Series2"
                ChartArea="ChartArea1"
                XValueMember="t_curr"
                YValueMembers="t_proa"
                ChartType="Spline"
                XValueType="DateTime"
                ToolTip="Value of X: #VALX Value of Y #VALY"
                LegendText="Actual Progress %"
                IsVisibleInLegend="True"
                Legend="Legend1">
              </asp:Series>
            </Series>
            <Legends>
              <asp:Legend Name="Legend1" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea1">
                <AxisX Interval="30" Title="Time" TitleForeColor="Blue">
                  <MajorGrid LineColor="LightGray" LineWidth="1" />
                  <LabelStyle Format="dd-MMM" />
                </AxisX>
                <AxisY Interval="10" Minimum="0" Maximum="100" Title="% Progress" TitleForeColor="Blue">
                  <MajorGrid LineColor="LightGray" LineWidth="1" />
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
