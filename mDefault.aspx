<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" CodeFile="mDefault.aspx.vb" Inherits="mLGDefault" title="Home" %>
<asp:Content ID="none" ContentPlaceHolderID="cphMain" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" ClientIDMode="Static" runat="Server">
  <asp:UpdatePanel ID="UPNLmctDefault" runat="server">
    <ContentTemplate>
      <div id="Div1" runat="server" class="container text-right" style="display: none;">
        <asp:Label runat="server" ID="L_DeviceID" Text=""></asp:Label>
        <asp:Label runat="server" ID="L_QString" Text=""></asp:Label>
        <asp:Label runat="server" ID="L_Err" Text=""></asp:Label>
        <input type="submit" class="btn btn-success" value="Refresh Device" id="cmdRefresh" runat="server" />
      </div>
      <div id="invalidDevice" runat="server" visible="false" class="container text-center">
        <div class="btn btn-danger">
          <h4>INVALID DEVICE ACCESS</h4>
          <p>
            <h6>Please get the Mobile App from ISGEC.
            </h6>
          </p>
        </div>
      </div>

      <div id="unknownUser" runat="server" visible="false" class="container text-center">
        <div class="btn btn-danger">
          <h4>USER ID is NOT valid</h4>
          <p>
            <h6>Please contact concerned person in
              <br />
              ISGEC to get the registered USER ID.
            </h6>
          </p>
        </div>
      </div>
      <div id="unknownDevice" runat="server" visible="false" class="container text-center">
        <div class="btn btn-danger">
          <h4>DEVICE ID is NOT registered</h4>
          <p>
            <h6>Please enter USER ID to get your
              <br />
              DEVICE registered.
            </h6>
          </p>
        </div>
      </div>
      <div id="registerUser" runat="server" visible="false" class="container">
        <div class="form-group">
          <label for="F_UserID">USER ID:</label>
          <asp:TextBox class="form-control" ID="F_UserID" runat="server" MaxLength="8" required="required" />
          <label for="F_UserName">USER NAME:</label>
          <asp:TextBox class="form-control" ID="F_UserName" runat="server" MaxLength="50" required="required" />
          <label for="F_MobileNo">MOBILE No.:</label>
          <asp:TextBox class="form-control" ID="F_MobileNo" runat="server" MaxLength="15" required="required" />
        </div>
        <div class="form-group">
          <asp:Button ID="cmdSubmit" runat="server" class="btn btn-primary" Text="Register" />
        </div>
      </div>
      <input type="submit" style="display:none;" id="idFirst" runat="server" value="0" />
      <div id="registeredAndAuthenticated" runat="server" visible="false" class="container text-center">
          <asp:Button ID="cmdContinue" runat="server" class="btn btn-warning" Text="Continue" />
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="idFirst"  />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>

