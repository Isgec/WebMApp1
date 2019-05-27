Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Security.Principal
Imports System.Security
Partial Class mLGDefault
  Inherits System.Web.UI.Page
  Public Property DeviceID As String
    Get
      If ViewState("DeviceID") IsNot Nothing Then
        Return Convert.ToString(ViewState("DeviceID"))
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("DeviceID", value)
    End Set
  End Property
  Public Property Qstring As String
    Get
      If ViewState("QString") IsNot Nothing Then
        Return Convert.ToString(ViewState("QString"))
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("QString", value)
    End Set
  End Property
  Protected Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    HttpContext.Current.Session("LoginID") = "0000"
    Dim UserID As String = F_UserID.Text
    Dim UserName As String = F_UserName.Text
    Dim MobileNo As String = F_MobileNo.Text
    If UserID <> "" Then
      Dim tmpUser As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
      If tmpUser Is Nothing Then
        Me.unknownDevice.Visible = False
        Me.unknownUser.Visible = True
        Me.registerUser.Visible = True
      Else
        Dim Found As Boolean = True
        Dim tmpDevice As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceIDUserID(DeviceID, UserID)
        If tmpDevice Is Nothing Then
          tmpDevice = New SIS.MAPP.maapRegisteredDevices
          Found = False
        End If
        With tmpDevice
          .DeviceID = DeviceID
          .UserID = UserID
          .UserName = UserName
          .MobileNo = MobileNo
          .RequestedOn = Now
          .IsRegistered = True
          .RegisteredOn = Now
        End With
        If Not Found Then
          tmpDevice = SIS.MAPP.maapRegisteredDevices.InsertData(tmpDevice)
        Else
          tmpDevice = SIS.MAPP.maapRegisteredDevices.UpdateData(tmpDevice)
        End If
        If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
          Me.registerUser.Visible = False
          Me.unknownUser.Visible = False
          Me.unknownDevice.Visible = False
          Response.Redirect("~/mMenu.aspx")
        End If
      End If
    End If
  End Sub

  Private Sub cmdRefresh_ServerClick(sender As Object, e As EventArgs) Handles cmdRefresh.ServerClick
    Dim tmpDvc As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(DeviceID)
    If tmpDvc Is Nothing Then
      Me.unknownDevice.Visible = True
      Me.registerUser.Visible = True
    Else
      If SIS.SYS.Utilities.SessionManager.DoLogin(tmpDvc.UserID) Then
        Response.Redirect("~/mMenu.aspx")
      End If
    End If

  End Sub
  Private Sub RedirectUser()
    If Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") IsNot Nothing Then
      Dim UserID As String = Request.QueryString("UserID")
      Dim AppID As String = Request.QueryString("AppID")
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        Dim tmpApl As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetByID(AppID)
        Response.Redirect("~" & tmpApl.MainPageURL)
      End If
    ElseIf Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") Is Nothing Then
      Dim UserID As String = Request.QueryString("UserID")
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        Response.Redirect("~/mMenu.aspx")
      End If
    ElseIf Request.QueryString("deviceID") Is Nothing Then
      Me.invalidDevice.Visible = True
    Else
      DeviceID = Request.QueryString("deviceID")
      Qstring = Request.QueryString.ToString
      L_DeviceID.Text = DeviceID
      L_QString.Text = Qstring
      If DeviceID = String.Empty Then
        Me.invalidDevice.Visible = True
      Else
        Dim tmpDvc As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(DeviceID)
        If tmpDvc Is Nothing Then
          Me.unknownDevice.Visible = True
          Me.registerUser.Visible = True
        Else
          If SIS.SYS.Utilities.SessionManager.DoLogin(tmpDvc.UserID) Then
            Response.Redirect("~/mMenu.aspx")
          End If
        End If
      End If
    End If
  End Sub

  Private Sub mLGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    'If Not Page.User.Identity.IsAuthenticated Then

    'End If
    If Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") IsNot Nothing Then
      Dim UserID As String = Request.QueryString("UserID")
      Dim AppID As String = Request.QueryString("AppID")
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        Dim tmpApl As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetByID(AppID)
        Response.Redirect("~" & tmpApl.MainPageURL)
      End If
    ElseIf Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") Is Nothing Then
      Dim UserID As String = Request.QueryString("UserID")
      If SIS.SYS.Utilities.SessionManager.DoLogin(UserID) Then
        Response.Redirect("~/mMenu.aspx")
      End If
    ElseIf Request.QueryString("deviceID") IsNot Nothing Then
      DeviceID = Request.QueryString("deviceID")
      L_DeviceID.Text = DeviceID
      If DeviceID = String.Empty Then
        Me.invalidDevice.Visible = True
      Else
        Dim tmpDvc As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(DeviceID)
        If tmpDvc Is Nothing Then
          Me.unknownDevice.Visible = True
          Me.registerUser.Visible = True
        Else
          If SIS.SYS.Utilities.SessionManager.DoLogin(tmpDvc.UserID) Then
            Response.Redirect("~/mMenu.aspx")
          End If
        End If
      End If
    Else
      If Page.User.Identity.IsAuthenticated AndAlso HttpContext.Current.Session("LoginID") IsNot Nothing Then
        Response.Redirect("~/mMenu.aspx")
      Else
        HttpContext.Current.Response.Cookies.Clear()
      End If
    End If
  End Sub

  Private Sub cmdContinue_Click(sender As Object, e As EventArgs) Handles cmdContinue.Click
    Response.Redirect("~/mMenu.aspx?" & Request.QueryString.ToString)
  End Sub
End Class
