<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctActivityDashboard.aspx.vb" Inherits="mGctActivityDashboard" title="Project-Activity Dashboard" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmd30Days" runat="server" Text="Progress Status [Last 30 Days]" ToolTip="Last 30 days." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Progress Status [Overall]" ToolTip="Since Project Start." />
  <asp:LinkButton ID="cmd30Next" runat="server" Text="Progress Status [Next 30 Days]" ToolTip="Next 30 days." />
</div>

  <div class="container" style="margin-top: 15px">
    <%--Project & Period Detaila--%>
    <div class="row">
      <div class="col-sm-1 text-left">
        <span class=" btn btn-sm btn-dark" style="width:40px;text-align:center;cursor:pointer" title="Menu" onclick="openNav()">&#9776;</span>
      </div>
      <div class="col-sm-3 text-center">
      <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text="PROGRESS S-CURVE"></asp:Label></h5>
      </div>
      <div class="col-sm-5 text-center">
      <h4><asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
      </div>
      <div class="col-sm-3 text-center">
      <h6>(<asp:Label ID="ProjectPeriod" runat="server"></asp:Label>)</h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center chartDiv">
        <h5><asp:Label ID="ProjectActivityName" runat="server" Font-Underline="true"></asp:Label></h5>
        <asp:Chart
          ID="Chart1"
          Height="300px"
          Width="1000px"
          ClientIDMode="Predictable"
          runat="server">
          <Legends>
            <asp:Legend Name="Legend1" Docking="Top" IsDockedInsideChartArea="true">
              <Position Auto="True" />
            </asp:Legend>
          </Legends>
          <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
          </ChartAreas>
        </asp:Chart>
        <div id="ActivityDataTable" runat="server" class="container-fluid text-center"></div>
      </div>
    </div>
    <style>
      .fix{
        width: 40px !important;
        margin-top: 4px;
        margin-bottom: 6px;
      }
    </style>
    <div class="row chartDiv" >
      <div class="col-sm-6 text-center">
            <h5><asp:Label ID="Label2" runat="server" Text="Activity - Due for Start "></asp:Label></h5>
            <h6><asp:Label ID="Label3" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
            <div id="ReviewSheetStart" runat="server" class="container-fluid text-center">
              <table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>
                <thead>
                  <tr style="background-color:black;color:white;">
                  <th rowspan="2" style='text-align:center;'></th><th rowspan="2" style='text-align:center;'>Early Start</th><th rowspan="2" style='text-align:center;'>On Time</th><th colspan="3" style='text-align:center;'>Delay [Days]</th>
                  </tr>
                <tr style="background-color:black;color:white;">
                  <th style='text-align:center;'> 1 to 10 </th><th style='text-align:center;'> 11 to 20 </th><th style='text-align:center;'> 21 to 30</th>
                  </tr>
                </thead>
                <tr>
                  <td style='text-align:center;font-weight:bold;'>STARTED</td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="STE" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="ST0" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="ST10" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="ST20" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="ST30" runat="server" OnClick="abc"></asp:Button> </td>
                </tr>
                <tr>
                  <td style='text-align:center;font-weight:bold;'>NOT STARTED</td>
                  <td style='text-align:center;'>-</td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="NST0" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NST10" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NST20" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NST30" runat="server" OnClick="abc"></asp:Button> </td>
                </tr>
              </table>
            </div>
            <div id="ReviewDetail" runat="server" class="container-fluid text-center"></div>
      </div>
      <div class="col-sm-6 text-center ">
            <h5><asp:Label ID="Label4" runat="server" Text="Activity - Due for Finish "></asp:Label></h5>
            <h6><asp:Label ID="Label5" runat="server" Font-Underline="true" Text=""></asp:Label></h6>
            <div id="ReviewSheetFinish" runat="server" class="container-fluid text-center">
              <table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>
                <thead>
                  <tr style="background-color:black;color:white;">
                  <th rowspan="2" style='text-align:center;'></th><th rowspan="2" style='text-align:center;'>Early Finish</th><th rowspan="2" style='text-align:center;'>On Time</th><th colspan="3" style='text-align:center;'>Delay [Days]</th>
                  </tr>
                  <tr style="background-color:black;color:white;">
                  <th style='text-align:center;'> 1 to 10</th><th style='text-align:center;'> 11 to 20 </th><th style='text-align:center;'> 21 to 30 </th>
                  </tr>
                </thead>
                <tr>
                  <td style='text-align:center;font-weight:bold;'>FINISHED</td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="FDE" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="FD0" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="FD10" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="FD20" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="FD30" runat="server" OnClick="abc"></asp:Button> </td>
                </tr>
                <tr>
                  <td style='text-align:center;font-weight:bold;'>NOT FINISHED</td>
                  <td style='text-align:center;'>-</td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-success fix" ID="NFD0" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NFD10" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-warning fix" ID="NFD20" runat="server" OnClick="abc"></asp:Button> </td>
                  <td style='text-align:center;'><asp:Button CssClass="btn btn-sm btn btn-danger fix" ID="NFD30" runat="server" OnClick="abc"></asp:Button> </td>
                </tr>
              </table>
            </div>

      </div>
    </div>
  </div>


</asp:Content>
