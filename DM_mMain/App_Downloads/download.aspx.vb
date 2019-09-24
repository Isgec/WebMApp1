Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip

Partial Class docdownload
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Value As String = ""
    Dim comp As String = "200"
    If Request.QueryString("doc") IsNot Nothing Then
      Value = Request.QueryString("doc")
      comp = Request.QueryString("comp")
      DownloadDoc(Value, comp)
    End If
  End Sub
  Private Sub DownloadDoc(ByVal pk As String, ByVal comp As String)
    Dim docHndl As String = "DOCUMENTMASTERPDF_" & comp
    Dim docIndx As String = pk.Replace("|", "_")

    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = ""
    Dim rDoc As SIS.EDI.ediAFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex(docHndl, docIndx)
    If rDoc IsNot Nothing Then
      Dim rLib As SIS.EDI.ediALib = SIS.EDI.ediALib.ediALibGetByID(rDoc.t_lbcd)
      If rLib IsNot Nothing Then
        Dim NeedsMapping As Boolean = False
        Dim Mapped As Boolean = False
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "192.9.200.146" Then
          UrlAuthority = "192.9.200.146"
          NeedsMapping = True
        End If
        libPath = "D:\" & rLib.t_path
        If NeedsMapping Then
          libPath = "\\" & UrlAuthority & "\" & rLib.t_path
          If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "administrator", "Indian@12345") Then
            Mapped = True
          End If
        End If
        filePath = libPath & "\" & rDoc.t_dcid
        fileName = rDoc.t_fnam
        If IO.File.Exists(filePath) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
          Response.WriteFile(filePath)
          Response.End()
        End If
        If Mapped Then
          ConnectToNetworkFunctions.disconnectFromNetwork("X:")
        End If
      End If
    End If
  End Sub

End Class
