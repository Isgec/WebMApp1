<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctActivitySCurve.aspx.vb" Inherits="mGctActivitySCurve" title="Activity Dashboard" %>
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
  <asp:LinkButton ID="cmd30Days" runat="server" Text="Delayed Items [Last 30 Days]" ToolTip="Last 30 days from today." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Delayed Items [Backlog]" ToolTip="Since Project Start till 30 days befor from today." />
</div>

  <%--Main Container--%>
  <div class="container" style="margin-top: 10px">
    <%--Project & Period Detaila--%>
    <div class="row">
      <div class="col-sm-1 text-left">
        <span class=" btn btn-sm btn-dark" style="width:40px;text-align:center;cursor:pointer" title="Menu" onclick="openNav()">&#9776;</span>
      </div>
      <div class="col-sm-3 text-center">
      <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text="Activity wise S-Curves"></asp:Label></h5>
      </div>
      <div class="col-sm-5 text-center">
      <h4><asp:Label ID="ProjectName" runat="server"></asp:Label></h4>
      </div>
      <div class="col-sm-3 text-center">
      <h6>(<asp:Label ID="ProjectPeriod" runat="server"></asp:Label>)</h6>
      </div>
    </div>
    <%--Other Graph Row--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" >
        <asp:Repeater ID="rCharts" runat="server" DataSourceID="ODStpisg206" ClientIDMode="Predictable">
          <ItemTemplate>
            <a class="chartDiv btn btn-outline-warning" runat="server" href='<%# Eval("GetRedirectLink") %>'>
              <h6 style="white-space:normal;"><%# Eval("t_dsca") %></h6>
              <asp:Label ID="L_t_acty" runat="server" Text='<%# Eval("t_acty") %>' Style="display: none;"></asp:Label>
              <asp:Label ID="L_t_cprj" runat="server" Text='<%# Eval("t_cprj") %>' Style="display: none;"></asp:Label>
              <asp:Chart
                ID="Chart2"
                Height="120px"
                Width="350px"
                DataSourceID="ODStpisg214"
                IsMapEnabled="true"
                RenderType="ImageTag"
                runat="server">
                <Series>
                  <asp:Series
                    Name="Series3"
                    ChartArea="ChartArea2"
                    XValueMember="t_date"
                    YValueMembers="t_pprc"
                    ChartType="Spline"
                    XValueType="DateTime"
                    ToolTip="Value of X: #VALX Value of Y #VALY">
                    <SmartLabelStyle Enabled="true" />
                  </asp:Series>
                  <asp:Series
                    Name="Series4"
                    ChartArea="ChartArea2"
                    XValueMember="t_date"
                    YValueMembers="t_acpr"
                    ChartType="Spline"
                    XValueType="DateTime"
                    ToolTip="Value of X: #VALX Value of Y #VALY">                    
                  </asp:Series>
                </Series>
                <ChartAreas>
                  <asp:ChartArea Name="ChartArea2">
                    <AxisX Interval="60" TitleForeColor="Blue">
                      <MajorGrid LineColor="LightGray" LineWidth="1" />
                      <LabelStyle Format="dd-MMM" />
                    </AxisX>
                    <AxisY Interval="20" Minimum="0" Maximum="100" TitleForeColor="Blue">
                      <MajorGrid LineColor="LightGray" LineWidth="1" />
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
                  <asp:ControlParameter ControlID="L_t_acty" PropertyName="Text" Name="t_acty" Type="String" DefaultValue="" />
                </SelectParameters>
              </asp:ObjectDataSource>
            </a>
          </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource
          ID="ODStpisg206"
          runat="server"
          SelectMethod="SelectList"
          TypeName="SIS.CT.tpisg206"
          OldValuesParameterFormatString="original_{0}">
          <SelectParameters>
            <asp:QueryStringParameter QueryStringField="t_cprj" Name="t_cprj" Type="string" DefaultValue="" />
          </SelectParameters>
        </asp:ObjectDataSource>
        </div>
      </div>
    </div>

  </div>


</asp:Content>
