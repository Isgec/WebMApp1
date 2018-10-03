Imports System.Web.Script.Serialization
Partial Class EF_wfDBIcons
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSwfDBIcons_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSwfDBIcons.Selected
    Dim tmp As SIS.WF.wfDBIcons = CType(e.ReturnValue, SIS.WF.wfDBIcons)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBIcons.Init
    DataClassName = "EwfDBIcons"
    SetFormView = FVwfDBIcons
  End Sub
  Protected Sub TBLwfDBIcons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBIcons.Init
    SetToolBar = TBLwfDBIcons
  End Sub
  Protected Sub FVwfDBIcons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBIcons.PreRender
    TBLwfDBIcons.EnableSave = Editable
    TBLwfDBIcons.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WF_Main/App_Edit") & "/EF_wfDBIcons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfDBIcons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfDBIcons", mStr)
    End If
    If Not Page.ClientScript.IsClientScriptBlockRegistered("FIconName") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "FIconName", "<script type='text/javascript'>function getFIconName(){return '" & FVwfDBIcons.FindControl("F_IconName").ClientID & "'}</script>")
    End If
  End Sub

End Class
