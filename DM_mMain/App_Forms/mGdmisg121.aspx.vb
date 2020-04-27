Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip
Imports ejiVault
Partial Class mGF_dmisg121
  Inherits SIS.SYS.GridBase
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Public Property LatestRevision As Boolean
    Get
      If ViewState("LatestRevision") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("LatestRevision"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("LatestRevision", value)
    End Set
  End Property
  Private Sub ODSdmisg121_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ODSdmisg121.Selecting
    '1. Check To Search
    If e.InputParameters("SearchText") <> "" Then
      e.InputParameters("SearchState") = True
    End If
  End Sub
  Private Sub F_LatestRevision_CheckedChanged(sender As Object, e As EventArgs) Handles F_LatestRevision.CheckedChanged
    LatestRevision = F_LatestRevision.Checked
  End Sub
  Private Sub GVdmisg121_Init(sender As Object, e As EventArgs) Handles GVdmisg121.Init
    DataClassName = "tdmisg121200"
    SetGridView = GVdmisg121
  End Sub
  Private Sub TBLdmisg121200_Init(sender As Object, e As EventArgs) Handles TBLdmisg121200.Init
    SetToolBar = TBLdmisg121200
  End Sub

  Private Sub GVdmisg121_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVdmisg121.RowCommand
    If e.CommandName.ToLower = "cmdSelect".ToLower Then
      Dim t_docn As String = GVdmisg121.DataKeys(e.CommandArgument).Values("t_docn")
      Dim t_revn As String = GVdmisg121.DataKeys(e.CommandArgument).Values("t_revn")
      Dim tmp As String = t_docn & "_" & t_revn
      Dim Found As Boolean = False
      For Each str As ListItem In lstSelected.Items
        If str.Text = tmp Then
          Found = True
          Exit Sub
        End If
      Next
      If Not Found Then
        lstSelected.Items.Add(tmp)
      End If
    End If
    If e.CommandName.ToLower = "Sort".ToLower Then
      If e.CommandArgument.tolower = "SelectAll".ToLower Then
        For Each r As GridViewRow In GVdmisg121.Rows
          If r.RowType = DataControlRowType.DataRow Then
            Dim t_docn As String = GVdmisg121.DataKeys(r.RowIndex).Values("t_docn")
            Dim t_revn As String = GVdmisg121.DataKeys(r.RowIndex).Values("t_revn")
            Dim tmp As String = t_docn & "_" & t_revn
            Dim Found As Boolean = False
            For Each str As ListItem In lstSelected.Items
              If str.Text = tmp Then
                Found = True
                Exit Sub
              End If
            Next
            If Not Found Then
              lstSelected.Items.Add(tmp)
            End If
          End If
        Next
      End If
    End If
  End Sub

  Private Sub GVdmisg121_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVdmisg121.Sorting
    e.Cancel = True
  End Sub
  Protected Sub PageSizeChanged(ByVal s As Object, ByVal e As EventArgs)
    TBLdmisg121200.RecordsPerPage = CType(s, DropDownList).SelectedValue
    GVdmisg121.PageSize = CType(s, DropDownList).SelectedValue
    GVdmisg121.DataBind()
  End Sub
  Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
    For I As Integer = lstSelected.Items.Count - 1 To 0 Step -1
      If lstSelected.Items(I).Selected Then
        lstSelected.Items.Remove(lstSelected.Items(I))
      End If
    Next
  End Sub

  Private Sub cmdDownload_Click(sender As Object, e As EventArgs) Handles cmdDownload.Click
    If lstSelected.Items.Count <= 0 Then Exit Sub
    Dim x As String = IO.Path.GetRandomFileName
    DownloadAll(x.ToString)
  End Sub
  Private Sub DownloadAll(ByVal pk As String)
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim L_Comp As String = EJI.DBCommon.ERPCompany
    EJI.DBCommon.ERPCompany = F_Company.SelectedValue

    Dim docHndl As String = "DOCUMENTMASTERPDF_" & F_Company.SelectedValue
    Dim filePath As String = ""
    Dim fileName As String = pk & ".zip"
    Dim LibraryID As String = ""


    Dim tmpFilesToDelete As New ArrayList
    Response.Clear()
    Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
    Using zip As New ZipFile
      zip.CompressionLevel = Zlib.CompressionLevel.Level5
      For Each tDoc As ListItem In lstSelected.Items
        Dim docIndx As String = tDoc.Text
        Dim rDoc As EJI.ediAFile = EJI.ediAFile.GetFileByHandleIndex(docHndl, docIndx)
        If rDoc IsNot Nothing Then
          Dim rLib As EJI.ediALib = EJI.ediALib.GetLibraryByID(rDoc.t_lbcd)
          If LibraryID <> rDoc.t_lbcd Then
            If Not EJI.DBCommon.IsLocalISGECVault Then
              EJI.ediALib.ConnectISGECVault(rLib)
            End If
            LibraryID = rDoc.t_lbcd
          End If
          filePath = rLib.LibraryPath & "\" & rDoc.t_dcid
          fileName = rDoc.t_fnam
          '====================
          '====================
          If IO.File.Exists(filePath) Then
            Dim tmpFile As String = Server.MapPath("~/..") & "App_Temp/" & fileName
            If IO.File.Exists(tmpFile) Then
              Try
                Dim fInfo As New FileInfo(tmpFile)
                fInfo.IsReadOnly = False
                IO.File.Delete(tmpFile)
              Catch ex As Exception
              End Try
            End If
            Try
              IO.File.Copy(filePath, tmpFile)
            Catch ex As Exception
            End Try
            zip.AddFile(tmpFile, "Files")
            tmpFilesToDelete.Add(tmpFile)
          End If
        End If
      Next
      zip.Save(Response.OutputStream)
    End Using
    For Each str As String In tmpFilesToDelete
      Try
        Dim fInfo As New FileInfo(str)
        fInfo.IsReadOnly = False
        IO.File.Delete(str)
      Catch ex As Exception
      End Try
    Next
    If Not EJI.DBCommon.IsLocalISGECVault Then
      EJI.ediALib.DisconnectISGECVault()
    End If
    EJI.DBCommon.ERPCompany = L_Comp
    Response.End()

  End Sub

  Private Sub mGF_dmisg121_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Authority As String = HttpContext.Current.Request.Url.Authority
    If Authority.ToUpper = "CLOUD.ISGEC.CO.IN" Then
      divOK.Visible = False
      divErr.Visible = True
    Else
      divOK.Visible = True
      divErr.Visible = False
      If Not Page.IsPostBack And Not Page.IsCallback Then
        GVdmisg121.PageSize = 25
        CType(GVdmisg121.HeaderRow.FindControl("D_PageSize"), DropDownList).SelectedIndex = 1
      End If
    End If
  End Sub
End Class
