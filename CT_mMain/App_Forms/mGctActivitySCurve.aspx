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
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Side Menu Bar--%>
<div id="mySidenav" class="sidenav">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <asp:LinkButton ID="cmd30Days" runat="server" Text="Progress Status [Last 30 Days]" ToolTip="Last 30 days." />
  <asp:LinkButton ID="cmdBacklog" runat="server" Text="Progress Status [Overall]" ToolTip="Since Project Start." />
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
                ID="Chart1"
                Height="120px"
                Width="350px"
                IsMapEnabled="true"
                RenderType="ImageTag"
                runat="server">
                <ChartAreas>
                  <asp:ChartArea Name="ChartArea1">
                  </asp:ChartArea>
                </ChartAreas>
              </asp:Chart>
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
