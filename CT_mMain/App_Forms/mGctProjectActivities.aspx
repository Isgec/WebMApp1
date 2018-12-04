<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="False" EnableEventValidation = "false" CodeFile="mGctProjectActivities.aspx.vb" Inherits="mGctProjectActivities" title="Project Activities" %>
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
  <div class="container" style="margin-top: 10px">
    <%--Project Selection Drop Down--%>
    <div class="row">
      <div class="col-sm-12">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">
              <div class="input-group mb-3">
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
    <div class="row" style="display:none">
      <div class="col-sm-4 text-center">
      <h5><asp:Label ID="Label1" runat="server" Font-Underline="true" Text="ACTIVITIES"></asp:Label></h5>
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
          <script type="text/javascript">
            function placeUP() {
              var mouseX;
              var mouseY;
              // below line for get mouse position
              $(document).mousemove(function (e) {
                mouseX = e.pageX;
                mouseY = e.pageY;

              });
              // below line for show loading panel at proper place
              $('#Tree1 a').click(function () {
              $('#UP').css({ 'top': mouseY, 'left': mouseX });
            });
          }
          </script>
          <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
              <div id="UP" style="position: absolute; background-image: url('/Images/loader.gif'); background-repeat: no-repeat; width: 20px;">
                &nbsp;
              </div>
            </ProgressTemplate>
          </asp:UpdateProgress>

          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

              <script type="text/javascript">
                Sys.Application.add_load(placeUP);
              </script>
              <style>
                #Tree1 {
                  overflow:scroll;
                  height:550px;
                }
                #Tree1 table{
                  /*width:1200px;*/
                }
                #Tree1 tr:hover{
                  background-color:yellow;
                }
                #Tree1 td {
                  border-bottom:solid 1pt gray;
                }
                .nowrap {
                  white-space:nowrap;
                }
                .col70 {width:70px !important;}
                .col70c{width:100px !important; text-align:center;}
                .col100 {width:100px !important;}
                .col100c{width:100px !important; text-align:center;}
                .col150 {width:150px !important;}
                .col150c{width:150px !important; text-align:center;}
                .Tree1_2 {
                  display:none;
                  width:1px;
                }
              </style>
              <asp:TreeView
                ID="Tree1"
                ClientIDMode="static"
                runat="server" 
                ShowLines="True" 
                ExpandDepth="2" 
                ImageSet="BulletedList3">
              <NodeStyle Width="500px"  CssClass="nowrap" />
              </asp:TreeView>
              <asp:ObjectDataSource
                ID="ODStpisg220"
                runat="server"
                SelectMethod="SelectList"
                TypeName="SIS.CT.tpisg220"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                  <asp:ControlParameter ControlID="F_t_cprj" PropertyName="SelectedValue" Name="t_cprj" Type="String" DefaultValue="" Size="6" />
                </SelectParameters>
              </asp:ObjectDataSource>
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
      </div>
    </div>

  </div>


</asp:Content>
