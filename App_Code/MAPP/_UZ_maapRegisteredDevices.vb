Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.MAPP
  Partial Public Class maapRegisteredDevices
    Public Shared Function maapRegisteredDevicesGetByDeviceID(ByVal DeviceID As String) As SIS.MAPP.maapRegisteredDevices
      Dim Results As SIS.MAPP.maapRegisteredDevices = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaap_LG_RegisteredDevicesSelectByDeviceID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeviceID", SqlDbType.NVarChar, DeviceID.ToString.Length, DeviceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "0340")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.MAPP.maapRegisteredDevices(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function maapRegisteredDevicesGetByDeviceIDUserID(ByVal DeviceID As String, ByVal UserID As String) As SIS.MAPP.maapRegisteredDevices
      Dim Results As SIS.MAPP.maapRegisteredDevices = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaap_LG_RegisteredDevicesSelectByDeviceIDUserID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeviceID", SqlDbType.NVarChar, DeviceID.ToString.Length, DeviceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "0340")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.MAPP.maapRegisteredDevices(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SaveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SaveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SaveWF(ByVal SerialNo As Int32, ByVal IsRegistered As Boolean, ByVal IsExpired As Boolean, ByVal ExpiredOn As DateTime) As SIS.MAPP.maapRegisteredDevices
      Dim Results As SIS.MAPP.maapRegisteredDevices = maapRegisteredDevicesGetByID(SerialNo)
      Return Results
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal SerialNo As Int32, ByVal IsRegistered As Boolean, ByVal IsExpired As Boolean, ByVal ExpiredOn As DateTime) As SIS.MAPP.maapRegisteredDevices
      Dim Results As SIS.MAPP.maapRegisteredDevices = maapRegisteredDevicesGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_maapRegisteredDevicesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.MAPP.maapRegisteredDevices)
      Dim Results As List(Of SIS.MAPP.maapRegisteredDevices) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spmapp_LG_RegisteredDevicesSelectListSearch"
            Cmd.CommandText = "spmaapRegisteredDevicesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spmapp_LG_maapRegisteredDevicesSelectListFilteres"
            Cmd.CommandText = "spmaapRegisteredDevicesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.MAPP.maapRegisteredDevices)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.MAPP.maapRegisteredDevices(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_maapRegisteredDevicesInsert(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Dim _Result As SIS.MAPP.maapRegisteredDevices = maapRegisteredDevicesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_maapRegisteredDevicesUpdate(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Dim _Result As SIS.MAPP.maapRegisteredDevices = maapRegisteredDevicesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_maapRegisteredDevicesDelete(ByVal Record As SIS.MAPP.maapRegisteredDevices) As Integer
      Dim _Result as Integer = maapRegisteredDevicesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_DeviceID"), TextBox).Text = ""
        CType(.FindControl("F_UserID"), TextBox).Text = ""
          CType(.FindControl("F_UserName"), TextBox).Text = ""
          CType(.FindControl("F_MobileNo"), TextBox).Text = ""
          CType(.FindControl("F_UserID_Display"), Label).Text = ""
          CType(.FindControl("F_RequestedOn"), TextBox).Text = ""
        CType(.FindControl("F_IsRegistered"), CheckBox).Checked = False
        CType(.FindControl("F_IsExpired"), CheckBox).Checked = False
        CType(.FindControl("F_ExpiredOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
