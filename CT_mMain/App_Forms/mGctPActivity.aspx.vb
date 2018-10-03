Imports System.Web.Script.Serialization
Partial Class mGF_ctPActivity
  Inherits System.Web.UI.Page
  Public Property OnlyMe As Boolean
    Get
      If ViewState("OnlyMe") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("Onlyme"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("OnlyMe", value)
    End Set
  End Property
  Protected Sub GVctPActivity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVctPActivity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_cact As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cact")
        Dim tmpU As SIS.CT.ctPUActivity = SIS.CT.ctPUActivity.GetctPUActivityForUpdate(t_cprj, t_cact)
        If tmpU IsNot Nothing Then
          Dim t_srno As String = tmpU.t_srno
          Dim RedirectUrl As String = "~/CT_mMain/App_Edit/mEctPUActivity.aspx" & "?t_cprj=" & t_cprj & "&t_cact=" & t_cact & "&t_srno=" & t_srno & "&ed=" & IIf(tmpU.AddNewUpdate, "Y", "N")
          Response.Redirect(RedirectUrl)
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgNotes".ToLower Then
      Try
        Dim t_cprj As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_cact As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cact")
        Dim tmpA As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(t_cprj, t_cact)

        Dim Prefix As String = ""
        Dim NextNo As Integer = 0
        Dim NotesID As String = SIS.NT.ntNotes.GetNextNotesNo(Prefix, NextNo)

        Dim tmpNote As New SIS.NT.ntNotes
        With tmpNote
          .Notes_RunningNo = NextNo
          .NotesId = NotesID
          .NotesHandle = "P_PROJECTACTIVITY_200"
          .IndexValue = t_cprj & "_" & t_cact
          .Title = t_cprj & ": " & tmpA.t_desc
          .Description = ""
          .UserId = HttpContext.Current.Session("LoginID")
          .Created_Date = Now
          .SendEmailTo = ""
        End With
        tmpNote = SIS.NT.ntNotes.InsertData(tmpNote)
        Dim RedirectUrl As String = "~/NT_mMain/App_Edit/EF_ntNotes.aspx?NotesID=" & NotesID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Private Sub ODSctPActivity_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ODSctPActivity.Selecting
    '1. Check To Search
    If e.InputParameters("SearchText") <> "" Then
      e.InputParameters("SearchState") = True
    ElseIf e.InputParameters("t_cprj") = "" Then
      e.Cancel = True
    End If
  End Sub

  Private Sub GVctPActivity_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVctPActivity.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
      e.Row.CssClass = CType(e.Row.DataItem, SIS.CT.ctPActivity).bgCssClass
    End If
  End Sub
  Private Sub mGF_ctPActivity_PreRender(sender As Object, e As EventArgs) Handles Me.Load
    If Not Page.IsCallback AndAlso Not Page.IsPostBack Then
      Dim x As ListItem
      F_t_cprj.Items.Clear()
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim tmpProjs As List(Of SIS.CT.ctUserProject) = SIS.CT.ctUserProject.ctUserProjectSelectList(0, 999, "", False, "", UserID, "")
      If tmpProjs.Count <= 0 Then
        x = New ListItem
        x.Text = "NO PROJECT AUTHORIZATION"
        x.Value = ""
        F_t_cprj.Items.Add(x)
        F_t_cprj.SelectedIndex = 0
        F_t_cprj.Enabled = False
      Else
        If tmpProjs.Count = 1 Then
          For Each tmp As SIS.CT.ctUserProject In tmpProjs
            x = New ListItem
            x.Value = tmp.ProjectID
            x.Text = tmp.IDM_Projects2_Description
            F_t_cprj.Items.Add(x)
            F_t_cprj.SelectedIndex = 0
            F_t_cprj.Enabled = False
          Next
        Else
          Dim Selected As Boolean = False
          For Each tmp As SIS.CT.ctUserProject In tmpProjs
            x = New ListItem
            x.Value = tmp.ProjectID
            x.Text = tmp.IDM_Projects2_Description
            F_t_cprj.Items.Add(x)
          Next
          If HttpContext.Current.Session("ProjectID") IsNot Nothing Then
            F_t_cprj.SelectedValue = HttpContext.Current.Session("ProjectID")
          End If
        End If
      End If
    End If
  End Sub

  Private Sub F_t_cprj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles F_t_cprj.SelectedIndexChanged
    HttpContext.Current.Session("ProjectID") = F_t_cprj.SelectedValue
  End Sub

  Private Sub F_OnlyMe_CheckedChanged(sender As Object, e As EventArgs) Handles F_OnlyMe.CheckedChanged
    OnlyMe = F_OnlyMe.Checked
  End Sub
End Class
