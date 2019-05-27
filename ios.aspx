<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="false" CodeFile="ios.aspx.vb" Inherits="lgIos" title="ISGEC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
  <div class="container">
    <div class="row" style="margin-top:15px;">
      <div class="col-sm-12 text-center">
      <input type="image" alt="Add to home screen" src="ios.png" />
      </div>
    </div>
    <div class="row" style="margin-top:5px;">
      <div class="col-sm-12">
       <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text">Employee Code</span>
          </div>
          <asp:TextBox id="F_CardNo" runat="server" cssclass="form-control" placeholder="EmployeeCode" required="required" MaxLength="8" />
        </div>

      </div>
    </div>
    <div class="row" style="margin-top:5px;">
      <div class="col-sm-12 text-center">
      <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" />

      </div>
    </div>
  </div>
</asp:Content>

