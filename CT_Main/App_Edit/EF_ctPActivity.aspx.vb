Imports System.Web.Script.Serialization
Partial Class EF_ctPActivity
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
  Protected Sub ODSctPActivity_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSctPActivity.Selected
    Dim tmp As SIS.CT.ctPActivity = CType(e.ReturnValue, SIS.CT.ctPActivity)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVctPActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPActivity.Init
    DataClassName = "EctPActivity"
    SetFormView = FVctPActivity
  End Sub
  Protected Sub TBLctPActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPActivity.Init
    SetToolBar = TBLctPActivity
  End Sub
  Protected Sub FVctPActivity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPActivity.PreRender
    TBLctPActivity.EnableSave = Editable
    TBLctPActivity.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/CT_Main/App_Edit") & "/EF_ctPActivity.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptctPActivity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptctPActivity", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvctPUActivityCC As New gvBase
  Protected Sub GVctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVctPUActivity.Init
    gvctPUActivityCC.DataClassName = "GctPUActivity"
    gvctPUActivityCC.SetGridView = GVctPUActivity
  End Sub
  Protected Sub TBLctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPUActivity.Init
    gvctPUActivityCC.SetToolBar = TBLctPUActivity
  End Sub
  Protected Sub GVctPUActivity_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVctPUActivity.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        Dim RedirectUrl As String = TBLctPUActivity.EditUrl & "?t_cprj=" & t_cprj & "&t_atid=" & t_atid & "&t_srno=" & t_srno
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        SIS.CT.ctPUActivity.DeleteWF(t_cprj, t_atid, t_srno)
        GVctPUActivity.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim t_cprj As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_cprj")  
        Dim t_atid As String = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_atid")  
        Dim t_srno As Int32 = GVctPUActivity.DataKeys(e.CommandArgument).Values("t_srno")  
        SIS.CT.ctPUActivity.InitiateWF(t_cprj, t_atid, t_srno)
        GVctPUActivity.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLctPUActivity_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLctPUActivity.AddClicked
    Dim t_cprj As String = CType(FVctPActivity.FindControl("F_t_cprj"),TextBox).Text
    Dim t_cact As String = CType(FVctPActivity.FindControl("F_t_cact"),TextBox).Text
    TBLctPUActivity.AddUrl &= "?t_cprj=" & t_cprj
    TBLctPUActivity.AddUrl &= "&t_cact=" & t_cact
  End Sub

End Class
