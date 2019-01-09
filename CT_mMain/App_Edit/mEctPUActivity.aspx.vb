Imports System.Web.Script.Serialization
Partial Class mEctPUActivity
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
  Public Property t_nama() As String
    Get
      If ViewState("t_nama") IsNot Nothing Then
        Return CType(ViewState("t_nama"), String)
      End If
      Return ""
    End Get
    Set(ByVal value As String)
      ViewState.Add("t_nama", value)
    End Set
  End Property
  Protected Sub ODSctPUActivity_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSctPUActivity.Selected
    Dim tmp As SIS.CT.ctPUActivity = CType(e.ReturnValue, SIS.CT.ctPUActivity)
    If tmp.t_acsd <> "" Then
      'If tmp.t_bohd <> "CT_MANUFACTURING" Then
      If Year(Convert.ToDateTime(tmp.t_acsd)) > 2015 Then
        Editable = False
      End If
      'End If
    End If
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.Init
    DataClassName = "EctPUActivity"
    SetFormView = FVctPUActivity
  End Sub
  Protected Sub TBLctPUActivity_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLctPUActivity.Init
    SetToolBar = TBLctPUActivity
  End Sub
  Protected Sub FVctPUActivity_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVctPUActivity.PreRender
    If Request.QueryString("ed") IsNot Nothing Then
      If Request.QueryString("ed") = "N" Then
        CType(FVctPUActivity.FindControl("cmdSubmit"), Button).Visible = False
      End If
    End If
  End Sub
  Private Sub FVctPUActivity_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVctPUActivity.ItemCommand
    If e.CommandName.ToLower = "lgupdate".ToLower Then
      TBLctPUActivity.ExecuteSave()
    End If
  End Sub
  Private Sub FVctPUActivity_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVctPUActivity.ItemUpdating
    If e.NewValues("t_tpgv") = "" Then
      e.NewValues("t_tpgv") = "0"
    End If
    If e.NewValues("t_cpgv") = "" Then
      e.NewValues("t_cpgv") = "0"
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_acsd(ByVal value As String) As String
    Dim aVal() As String = value.Split("|".ToCharArray)
    Dim AllowedDays As Integer = ConfigurationManager.AppSettings("AllowedDays")
    Dim mRet As String = "0|Success"
    Dim acsd As DateTime = Nothing
    Dim aced As DateTime = Nothing
    Try
      If aVal(0) <> "" Then
        acsd = aVal(0)
        If acsd.Date > Now.Date Then
          Return "1|Future Date NOT allowed.|F_t_acsd"
        End If
        If acsd.Date < Now.AddDays(-1 * AllowedDays).Date Then
          mRet = "1|Update older than " & AllowedDays & " days NOT Allowed.|F_t_acsd"
        End If
      End If
      If aVal(1) <> "" Then
        aced = aVal(1)
        If aced.Date < acsd.Date Then
          mRet = "1|Start Date can not be greater than Finish Date.|F_t_acsd"
        End If
      End If
    Catch ex As Exception
      mRet = "1|Invalid Date|F_t_acsd"
    End Try
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_aced(ByVal value As String) As String
    Dim aVal() As String = value.Split("|".ToCharArray)
    Dim mRet As String = "0|Success"
    Dim acsd As DateTime = Nothing
    Dim aced As DateTime = Nothing
    Dim AllowedDays As Integer = ConfigurationManager.AppSettings("AllowedDays")
    Try
      If aVal(1) <> "" Then
        aced = aVal(1)
        If aced.Date > Now.Date Then
          Return "1|Future Date NOT allowed.|F_t_aced"
        End If
        If aced.Date < Now.AddDays(-1 * AllowedDays).Date Then
          mRet = "1|Update older than " & AllowedDays & " days NOT Allowed.|F_t_aced"
        End If
        If aVal(0) <> "" Then
          acsd = aVal(0)
          If aced.Date < acsd.Date Then
            mRet = "1|Finish Date can not be less than Start Date.|F_t_aced"
          End If
        End If
      End If
    Catch ex As Exception
      mRet = "1|Invalid Date|F_t_aced"
    End Try
    Return mRet
  End Function


  Private Sub FVctPUActivity_Load(sender As Object, e As EventArgs) Handles FVctPUActivity.Load
    If Request.QueryString("t_nama") IsNot Nothing Then
      t_nama = Request.QueryString("t_nama")
    End If
  End Sub
End Class
