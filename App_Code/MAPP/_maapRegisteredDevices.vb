Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.MAPP
  <DataObject()> _
  Partial Public Class maapRegisteredDevices
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _DeviceID As String = ""
    Private _UserID As String = ""
    Public Property UserName As String = ""
    Public Property MobileNo As String = ""
    Private _RequestedOn As String = ""
    Private _IsRegistered As Boolean = False
    Private _IsExpired As Boolean = False
    Private _ExpiredOn As String = ""
    Private _RegisteredOn As String = ""
    Private _RegisteredBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _FK_MAPP_RegisteredDevices_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_MAPP_RegisteredDevices_RegisteredBy As SIS.QCM.qcmUsers = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property DeviceID() As String
      Get
        Return _DeviceID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DeviceID = ""
         Else
           _DeviceID = value
         End If
      End Set
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UserID = ""
         Else
           _UserID = value
         End If
      End Set
    End Property
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedOn = ""
         Else
           _RequestedOn = value
         End If
      End Set
    End Property
    Public Property IsRegistered() As Boolean
      Get
        Return _IsRegistered
      End Get
      Set(ByVal value As Boolean)
        _IsRegistered = value
      End Set
    End Property
    Public Property IsExpired() As Boolean
      Get
        Return _IsExpired
      End Get
      Set(ByVal value As Boolean)
        _IsExpired = value
      End Set
    End Property
    Public Property ExpiredOn() As String
      Get
        If Not _ExpiredOn = String.Empty Then
          Return Convert.ToDateTime(_ExpiredOn).ToString("dd/MM/yyyy")
        End If
        Return _ExpiredOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExpiredOn = ""
         Else
           _ExpiredOn = value
         End If
      End Set
    End Property
    Public Property RegisteredOn() As String
      Get
        If Not _RegisteredOn = String.Empty Then
          Return Convert.ToDateTime(_RegisteredOn).ToString("dd/MM/yyyy")
        End If
        Return _RegisteredOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RegisteredOn = ""
         Else
           _RegisteredOn = value
         End If
      End Set
    End Property
    Public Property RegisteredBy() As String
      Get
        Return _RegisteredBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RegisteredBy = ""
         Else
           _RegisteredBy = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKmaapRegisteredDevices
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_MAPP_RegisteredDevices_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_MAPP_RegisteredDevices_UserID Is Nothing Then
          _FK_MAPP_RegisteredDevices_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_MAPP_RegisteredDevices_UserID
      End Get
    End Property
    Public ReadOnly Property FK_MAPP_RegisteredDevices_RegisteredBy() As SIS.QCM.qcmUsers
      Get
        If _FK_MAPP_RegisteredDevices_RegisteredBy Is Nothing Then
          _FK_MAPP_RegisteredDevices_RegisteredBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RegisteredBy)
        End If
        Return _FK_MAPP_RegisteredDevices_RegisteredBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function maapRegisteredDevicesGetNewRecord() As SIS.MAPP.maapRegisteredDevices
      Return New SIS.MAPP.maapRegisteredDevices()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function maapRegisteredDevicesGetByID(ByVal SerialNo As Int32) As SIS.MAPP.maapRegisteredDevices
      Dim Results As SIS.MAPP.maapRegisteredDevices = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaapRegisteredDevicesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function maapRegisteredDevicesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.MAPP.maapRegisteredDevices)
      Dim Results As List(Of SIS.MAPP.maapRegisteredDevices) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spmaapRegisteredDevicesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
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
    Public Shared Function maapRegisteredDevicesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function maapRegisteredDevicesGetByID(ByVal SerialNo As Int32, ByVal Filter_UserID As String) As SIS.MAPP.maapRegisteredDevices
      Return maapRegisteredDevicesGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function maapRegisteredDevicesInsert(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Dim _Rec As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetNewRecord()
      With _Rec
        .DeviceID = Record.DeviceID
        .UserID = Record.UserID
        .UserName = Record.UserName
        .MobileNo = Record.MobileNo
        .RequestedOn = Record.RequestedOn
        .IsRegistered = Record.IsRegistered
        .IsExpired = Record.IsExpired
        .ExpiredOn = Record.ExpiredOn
        .RegisteredOn = Now
        .RegisteredBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.MAPP.maapRegisteredDevices.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaapRegisteredDevicesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeviceID",SqlDbType.NVarChar,51, Iif(Record.DeviceID= "" ,Convert.DBNull, Record.DeviceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, 50, IIf(Record.UserName = "", Convert.DBNull, Record.UserName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileNo", SqlDbType.NVarChar, 15, IIf(Record.MobileNo = "", Convert.DBNull, Record.MobileNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn", SqlDbType.DateTime, 21, IIf(Record.RequestedOn = "", Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRegistered",SqlDbType.Bit,3, Record.IsRegistered)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsExpired",SqlDbType.Bit,3, Record.IsExpired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExpiredOn",SqlDbType.DateTime,21, Iif(Record.ExpiredOn= "" ,Convert.DBNull, Record.ExpiredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegisteredOn",SqlDbType.DateTime,21, Iif(Record.RegisteredOn= "" ,Convert.DBNull, Record.RegisteredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegisteredBy",SqlDbType.NVarChar,9, Iif(Record.RegisteredBy= "" ,Convert.DBNull, Record.RegisteredBy))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function maapRegisteredDevicesUpdate(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Dim _Rec As SIS.MAPP.maapRegisteredDevices = SIS.MAPP.maapRegisteredDevices.maapRegisteredDevicesGetByID(Record.SerialNo)
      With _Rec
        .DeviceID = Record.DeviceID
        .UserID = Record.UserID
        .UserName = Record.UserName
        .MobileNo = Record.MobileNo
        .RequestedOn = Record.RequestedOn
        .IsRegistered = Record.IsRegistered
        .IsExpired = Record.IsExpired
        .ExpiredOn = Record.ExpiredOn
        .RegisteredOn = Record.RegisteredOn
        .RegisteredBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.MAPP.maapRegisteredDevices.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.MAPP.maapRegisteredDevices) As SIS.MAPP.maapRegisteredDevices
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaapRegisteredDevicesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeviceID",SqlDbType.NVarChar,51, Iif(Record.DeviceID= "" ,Convert.DBNull, Record.DeviceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, 50, IIf(Record.UserName = "", Convert.DBNull, Record.UserName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileNo", SqlDbType.NVarChar, 15, IIf(Record.MobileNo = "", Convert.DBNull, Record.MobileNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn", SqlDbType.DateTime, 21, IIf(Record.RequestedOn = "", Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRegistered",SqlDbType.Bit,3, Record.IsRegistered)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsExpired",SqlDbType.Bit,3, Record.IsExpired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExpiredOn",SqlDbType.DateTime,21, Iif(Record.ExpiredOn= "" ,Convert.DBNull, Record.ExpiredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegisteredOn",SqlDbType.DateTime,21, Iif(Record.RegisteredOn= "" ,Convert.DBNull, Record.RegisteredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegisteredBy",SqlDbType.NVarChar,9, Iif(Record.RegisteredBy= "" ,Convert.DBNull, Record.RegisteredBy))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function maapRegisteredDevicesDelete(ByVal Record As SIS.MAPP.maapRegisteredDevices) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmaapRegisteredDevicesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
