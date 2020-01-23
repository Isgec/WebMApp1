<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctDashboardOutstandingStatus.aspx.vb" Inherits="mGctDashboardOutstandingStatus" Title="Outstanding Status" %>
<asp:Content ID="None" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="CPHctPActivity" ContentPlaceHolderID="cph1" runat="Server">
  <%--Main Container--%>
  <div class="container" style="margin-top: 10px">
    <%--Contract Detail--%>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h5>
          <asp:Label ID="Label1" runat="server" Font-Underline="true" Text="OUTSTANDING STATUS"></asp:Label></h5>
        <h6>
          <asp:Label ID="Label2" runat="server"></asp:Label></h6>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h4>
          <asp:Label ID="ContractName" runat="server"></asp:Label></h4>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12 text-center">
        <h6>
          <asp:Label ID="IncludingContracts" runat="server"></asp:Label></h6>
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

    <%--Billing Status--%>
    <div class="row">
      <div class="col-sm-12 text-center ">
        <div class="chartDiv" style="overflow:scroll;" >
          <h5>Outstanding Status</h5>
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


  </div>
</asp:Content>
