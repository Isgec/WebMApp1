Imports System.Web.Script.Serialization
Partial Class EF_mappUserApps
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
  Protected Sub ODSmappUserApps_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSmappUserApps.Selected
    Dim tmp As SIS.MAPP.mappUserApps = CType(e.ReturnValue, SIS.MAPP.mappUserApps)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappUserApps.Init
    DataClassName = "EmappUserApps"
    SetFormView = FVmappUserApps
  End Sub
  Protected Sub TBLmappUserApps_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLmappUserApps.Init
    SetToolBar = TBLmappUserApps
  End Sub
  Protected Sub FVmappUserApps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVmappUserApps.PreRender
    TBLmappUserApps.EnableSave = Editable
    TBLmappUserApps.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/MAPP_Main/App_Edit") & "/EF_mappUserApps.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptmappUserApps") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptmappUserApps", mStr)
    End If
  End Sub

End Class
