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
  Protected Sub AuthenticateAndRedirect(ByVal UserID As String)
    HttpContext.Current.Session("LoginID") = UserID
    Try
      Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
      If Membership.ValidateUser(UserID, pw) Then
      End If
      HttpContext.Current.Session("IsAuthenticated") = True
      Dim isPersistent As Boolean = True
      Dim userData As String = "ApplicationSpecific data for this user."
      Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
                UserID,
                DateTime.Now,
                DateTime.Now.AddMinutes(1),
                isPersistent,
                userData,
                FormsAuthentication.FormsCookiePath)
      ' Encrypt the ticket.
      Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
      ' Create the cookie. 
      HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
      SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
      Response.Redirect("~/mMenu.aspx")
    Catch ex As Exception
      L_Err.Text = "Err: " & ex.Message
    End Try
  End Sub
  Protected Sub AuthenticateAndRedirect(ByVal UserID As String, ByVal AppID As String)
    HttpContext.Current.Session("LoginID") = UserID
    Dim tmpApl As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetByID(AppID)
    Try
      Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
      If Membership.ValidateUser(UserID, pw) Then
      End If
      HttpContext.Current.Session("IsAuthenticated") = True
      Dim isPersistent As Boolean = True
      Dim userData As String = "ApplicationSpecific data for this user."
      Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
                UserID,
                DateTime.Now,
                DateTime.Now.AddMinutes(1),
                isPersistent,
                userData,
                FormsAuthentication.FormsCookiePath)
      ' Encrypt the ticket.
      Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
      ' Create the cookie. 
      HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
      SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
      Response.Redirect("~" & tmpApl.MainPageURL)
    Catch ex As Exception
      L_Err.Text = "Err: " & ex.Message
    End Try
  End Sub
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
        If AuthenticateRegisteredUser(UserID) Then
          Me.registerUser.Visible = False
          Me.unknownUser.Visible = False
          Me.unknownDevice.Visible = False
          Response.Redirect("mMenu.aspx?" & Request.QueryString.ToString)
        End If
      End If
    End If
  End Sub
  Public Function AuthenticateRegisteredUser(ByVal UserID As String) As Boolean
    Dim mRet As Boolean = True
    Try
      Dim pw As String = SIS.SYS.Utilities.SessionManager.GetPassword(UserID)
      If Membership.ValidateUser(UserID, pw) Then
      End If
      HttpContext.Current.Session("IsAuthenticated") = True
      Dim isPersistent As Boolean = True
      Dim userData As String = "ApplicationSpecific data for this user."
      Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
                UserID,
                DateTime.Now,
                DateTime.Now.AddMinutes(1),
                isPersistent,
                userData,
                FormsAuthentication.FormsCookiePath)
      ' Encrypt the ticket.
      Dim encTicket As String = FormsAuthentication.Encrypt(ticket)
      ' Create the cookie.
      HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
      SIS.SYS.Utilities.SessionManager.InitializeEnvironment(UserID)
      HttpContext.Current.Session("LoginID") = UserID
      mRet = True
    Catch ex As Exception
      L_Err.Text = "Err: " & ex.Message
    End Try
    Return mRet
  End Function

  Private Sub cmdRefresh_ServerClick(sender As Object, e As EventArgs) Handles cmdRefresh.ServerClick
    Dim tmpDvc As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(DeviceID)
    If tmpDvc Is Nothing Then
      Me.unknownDevice.Visible = True
      Me.registerUser.Visible = True
    Else
      If AuthenticateRegisteredUser(tmpDvc.UserID) Then
        Response.Redirect("mMenu.aspx?" & Qstring)
      End If
    End If

  End Sub

  Private Sub mLGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    'If idFirst.Value = "0" Then
    '  idFirst.Value = "1"
    '  Exit Sub
    'ElseIf idFirst.Value = "1" Then
    '  idFirst.Value = "2"
    'End If
    If Not Page.User.Identity.IsAuthenticated Then
      If Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") IsNot Nothing Then
        Dim UserID As String = Request.QueryString("UserID")
        Dim AppID As String = Request.QueryString("AppID")
        AuthenticateAndRedirect(UserID, AppID)
      ElseIf Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("AppID") Is Nothing Then
        Dim UserID As String = Request.QueryString("UserID")
        AuthenticateAndRedirect(UserID)
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
            If AuthenticateRegisteredUser(tmpDvc.UserID) Then
              Response.Redirect("mMenu.aspx?" & Request.QueryString.ToString)
            End If
          End If
        End If
      End If
    ElseIf idFirst.Value > "0" Then
      'registeredAndAuthenticated.Visible = True
    End If

  End Sub

  Private Sub cmdContinue_Click(sender As Object, e As EventArgs) Handles cmdContinue.Click
    Response.Redirect("mMenu.aspx?" & Request.QueryString.ToString)
  End Sub
End Class
'Dim userAgent As String = Request.Headers("User-Agent")
'If userAgent = "ISGEC_Registered_Mobile" Then
'    Dim uid As String = ""
'    Dim upw As String = ""
'    Try
'      uid = Request.QueryString("id")
'      upw = Request.QueryString("pw")
'      'abcd = userAgent & ", " & uid & ", " & upw
'      If Membership.ValidateUser(uid, upw) Then
'        Dim id As GenericIdentity = New GenericIdentity(uid, upw)
'        Context.User = New GenericPrincipal(id, {"user"})
'        FormsAuthentication.SetAuthCookie(uid, True)
'        SIS.SYS.Utilities.SessionManager.InitializeEnvironment(uid)
'        'Response.Redirect("~/WF_Main/App_Forms/GF_wfUserDB.aspx")
'      Else
'        'Response.Clear()
'        'Response.AppendHeader("UA=", userAgent & "-Lalit")
'        'Response.End()
'      End If
'    Catch ex As Exception
'    End Try
'  End If
