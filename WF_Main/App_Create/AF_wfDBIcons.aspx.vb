Partial Class AF_wfDBIcons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBIcons.Init
    DataClassName = "AwfDBIcons"
    SetFormView = FVwfDBIcons
  End Sub
  Protected Sub TBLwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBIcons.Init
    SetToolBar = TBLwfDBIcons
  End Sub
  Protected Sub FVwfDBIcons_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBIcons.DataBound
    SIS.WF.wfDBIcons.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVwfDBIcons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBIcons.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WF_Main/App_Create") & "/AF_wfDBIcons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfDBIcons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfDBIcons", mStr)
    End If
    If Not Page.ClientScript.IsClientScriptBlockRegistered("FIconName") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "FIconName", "<script type='text/javascript'>function getFIconName(){return '" & FVwfDBIcons.FindControl("F_IconName").ClientID & "'}</script>")
    End If
    If Request.QueryString("DBIconID") IsNot Nothing Then
      CType(FVwfDBIcons.FindControl("F_DBIconID"), TextBox).Text = Request.QueryString("DBIconID")
      CType(FVwfDBIcons.FindControl("F_DBIconID"), TextBox).Enabled = False
    End If
  End Sub

End Class
