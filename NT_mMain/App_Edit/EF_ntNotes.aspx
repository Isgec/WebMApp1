<%@ Page Language="VB" MasterPageFile="~/Sample.master" AutoEventWireup="True" ClientIDMode="Static" CodeFile="EF_ntNotes.aspx.vb" Inherits="EF_ntNotes" title="Notes" %>
<asp:Content ID="CPHntNotes" ContentPlaceHolderID="cph1" runat="Server">
  <div class="container">
    <div class="container text-center">
      <h3>
        <asp:Label ID="LabelctPActivity" runat="server" Text="Notes"></asp:Label></h3>
    </div>
    <asp:UpdatePanel ID="UPNLntNotes" runat="server">
      <ContentTemplate>
        <LGM:ToolBar0
          ID="TBLntNotes"
          ToolType="lgNMEdit"
          UpdateAndStay="False"
          ValidationGroup="ntNotes"
          SVisible="false"
          runat="server" />
        <asp:FormView ID="FVntNotes"
          DataKeyNames="NotesId"
          DataSourceID="ODSntNotes"
          DefaultMode="Edit"
          CssClass="container"
          runat="server">
          <EditItemTemplate>
            <div class="form-group">
              <h6><span class="badge badge-secondary">Title</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox
                  ID="F_Title"
                  Text='<%# Bind("Title") %>'
                  CssClass="form-control"
                  MaxLength="500"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">Description</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox
                  ID="F_Description"
                  Text='<%# Bind("Description") %>'
                  CssClass="form-control"
                  MaxLength="20000"
                  TextMode="Multiline"
                  Height="100px"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">Send Mail To</span></h6>
              <div class="input-group mb-3">
                <asp:TextBox ID="F_SendEmailTo"
                  Text='<%# Bind("SendEmailTo") %>'
                  CssClass="form-control"
                  MaxLength="500"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  runat="Server" />
              </div>
              <h6><span class="badge badge-secondary">Reminder</span></h6>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text">E-Mail ID</span>
                </div>
                <asp:TextBox ID="F_ReminderTo"
                  Text='<%# Bind("ReminderTo") %>'
                  CssClass="form-control"
                  MaxLength="500"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  runat="Server" />
              </div>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text">Date</span>
                </div>
                <asp:TextBox ID="F_ReminderDateTime"
                  Text='<%# Bind("dt_ReminderDateTime") %>'
                  CssClass="form-control"
                  type="date"
                  runat="server" />
              </div>
              <h6><span class="badge badge-secondary">Attachment</span></h6>
              <div class="input-group mb-3">
                <asp:FileUpload ID="F_FileUpload" name="files[]" multiple="multiple" runat="server" CssClass="form-control-file" ToolTip="Select file(s)" />
              </div>
            </div>
          </EditItemTemplate>
        </asp:FormView>
        <asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClientClick="showProcessingMPV(); return true;" CssClass="btn btn-dark" CommandName="lgUpdate" />
      </ContentTemplate>
      <Triggers>
        <asp:PostBackTrigger ControlID="cmdSubmit" />
      </Triggers>
    </asp:UpdatePanel>
    <asp:ObjectDataSource
      ID="ODSntNotes"
      DataObjectTypeName="SIS.NT.ntNotes"
      SelectMethod="ntNotesGetByID"
      UpdateMethod="UZ_ntNotesUpdate"
      DeleteMethod="UZ_ntNotesDelete"
      OldValuesParameterFormatString="original_{0}"
      TypeName="SIS.NT.ntNotes"
      runat="server">
      <SelectParameters>
        <asp:QueryStringParameter DefaultValue="0" QueryStringField="NotesId" Name="NotesId" Type="String" />
      </SelectParameters>
    </asp:ObjectDataSource>
  </div>
</asp:Content>
