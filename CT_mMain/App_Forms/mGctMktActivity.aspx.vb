Imports System.Data
Imports System.Data.SqlClient
Imports AjaxControlToolkit
Imports System.Web.Script.Serialization
Partial Class mGctMktActivity
  Inherits System.Web.UI.Page
  Protected Sub GVctPActivity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVctPActivity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cprj")
        Dim t_cact As String = GVctPActivity.DataKeys(e.CommandArgument).Values("t_cact")
        Dim tmpU As SIS.CT.ctPUActivity = SIS.CT.ctPUActivity.GetctPUActivityForUpdate(t_cprj, t_cact, "", "CT_MARKETING")
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

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    GVctPActivity.DataBind()
  End Sub

End Class
