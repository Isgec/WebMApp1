Partial Class lgIos
  Inherits System.Web.UI.Page
  Private Sub lgIos_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Request.QueryString("install") IsNot Nothing Then
      If Request.QueryString("install").ToString.ToUpper = "YES" Then
        Dim tmpDeviceID As String = Guid.NewGuid().ToString
        Dim tmpDevice As SIS.MAPP.maapRegisteredDevices = Nothing
        tmpDevice = New SIS.MAPP.maapRegisteredDevices
        With tmpDevice
          .DeviceID = tmpDeviceID
          .UserID = ""
          .UserName = "Delete It"
          .MobileNo = ""
          .RequestedOn = Now
          .IsRegistered = False
          .RegisteredOn = Now
        End With
        tmpDevice = SIS.MAPP.maapRegisteredDevices.InsertData(tmpDevice)
        Response.Redirect("~/ios.aspx?install=" & tmpDeviceID)
      Else
        Dim tmpDeviceID As String = Request.QueryString("install")
        Dim tmpDevice As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(tmpDeviceID)
        If tmpDevice IsNot Nothing Then
          If tmpDevice.IsRegistered Then
            Response.Redirect("~/mDefault.aspx?DeviceID=" & tmpDeviceID)
          End If
        End If

      End If
    End If
  End Sub
  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    Dim CardNo As String = F_CardNo.Text
    If CardNo = "" Then Exit Sub
    Dim tmpDeviceID As String = Request.QueryString("install")
    Dim tmpDevice As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByDeviceID(tmpDeviceID)
    If tmpDevice IsNot Nothing Then
      Try
        With tmpDevice
          .DeviceID = tmpDeviceID
          .UserID = CardNo
          '.UserName = .FK_MAPP_RegisteredDevices_UserID.UserFullName
          '.MobileNo = .FK_MAPP_RegisteredDevices_UserID.MobileNo
          .RequestedOn = Now
          .IsRegistered = True
          .RegisteredOn = Now
        End With
        tmpDevice = SIS.MAPP.maapRegisteredDevices.UpdateData(tmpDevice)
        Response.Redirect("~/mDefault.aspx?DeviceID=" & tmpDeviceID)
      Catch ex As Exception
        'Show Invalid Card No
      End Try
    End If



  End Sub
End Class
