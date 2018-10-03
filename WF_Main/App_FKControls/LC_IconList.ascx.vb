Imports System.Xml
Partial Class LC_IconList
  Inherits System.Web.UI.UserControl

  Private Sub LinkButton1_Command(sender As Object, e As CommandEventArgs) Handles LinkButton1.Command, LinkButton10.Command,
    LinkButton11.Command, LinkButton12.Command,
    LinkButton13.Command, LinkButton14.Command, LinkButton15.Command, LinkButton16.Command,
    LinkButton17.Command, LinkButton2.Command, LinkButton3.Command, LinkButton4.Command, LinkButton5.Command, LinkButton6.Command,
    LinkButton7.Command, LinkButton8.Command, LinkButton9.Command

    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WF_Main/App_FKControls/") & e.CommandName & ".txt")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    Dim xTr As New XmlDocument
    xTr.LoadXml(mStr)
    Try
      For Each nd As XmlNode In xTr.ChildNodes(0).ChildNodes(1).ChildNodes
        nd.ChildNodes(0).Attributes("href").Value = "#"
        If nd.ChildNodes(0).Attributes("onclick") Is Nothing Then
          Dim tmp As XmlAttribute = xTr.CreateAttribute("onclick")
          tmp.Value = "return icon_selected(this);"
          nd.ChildNodes(0).Attributes.Append(tmp)
        End If
      Next

    Catch ex As Exception

    End Try
    xTr.Save(HttpContext.Current.Server.MapPath("~/WF_Main/App_FKControls/") & e.CommandName & ".txt")

    icons.InnerHtml = mStr
  End Sub
End Class
