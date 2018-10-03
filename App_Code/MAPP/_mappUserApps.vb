Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.MAPP
  <DataObject()> _
  Partial Public Class mappUserApps
    Private Shared _RecordCount As Integer
    Private _AppID As Int32 = 0
    Private _UserID As String = ""
    Private _IsActive As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _MAPP_Applications2_ApplicationName As String = ""
    Private _FK_MAPP_UserApps_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_MAPP_UserApps_ApplID As SIS.MAPP.mappApplications = Nothing
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
    Public Property AppID() As Int32
      Get
        Return _AppID
      End Get
      Set(ByVal value As Int32)
        _AppID = value
      End Set
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
        _UserID = value
      End Set
    End Property
    Public Property IsActive() As Boolean
      Get
        Return _IsActive
      End Get
      Set(ByVal value As Boolean)
        _IsActive = value
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
    Public Property MAPP_Applications2_ApplicationName() As String
      Get
        Return _MAPP_Applications2_ApplicationName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MAPP_Applications2_ApplicationName = ""
         Else
           _MAPP_Applications2_ApplicationName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _AppID & "|" & _UserID
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
    Public Class PKmappUserApps
      Private _AppID As Int32 = 0
      Private _UserID As String = ""
      Public Property AppID() As Int32
        Get
          Return _AppID
        End Get
        Set(ByVal value As Int32)
          _AppID = value
        End Set
      End Property
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_MAPP_UserApps_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_MAPP_UserApps_UserID Is Nothing Then
          _FK_MAPP_UserApps_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_MAPP_UserApps_UserID
      End Get
    End Property
    Public ReadOnly Property FK_MAPP_UserApps_ApplID() As SIS.MAPP.mappApplications
      Get
        If _FK_MAPP_UserApps_ApplID Is Nothing Then
          _FK_MAPP_UserApps_ApplID = SIS.MAPP.mappApplications.mappApplicationsGetByID(_AppID)
        End If
        Return _FK_MAPP_UserApps_ApplID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappUserAppsGetNewRecord() As SIS.MAPP.mappUserApps
      Return New SIS.MAPP.mappUserApps()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappUserAppsGetByID(ByVal AppID As Int32, ByVal UserID As String) As SIS.MAPP.mappUserApps
      Dim Results As SIS.MAPP.mappUserApps = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappUserAppsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppID",SqlDbType.Int,AppID.ToString.Length, AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.MAPP.mappUserApps(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappUserAppsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AppID As Int32, ByVal UserID As String) As List(Of SIS.MAPP.mappUserApps)
      Dim Results As List(Of SIS.MAPP.mappUserApps) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spmappUserAppsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spmappUserAppsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AppID",SqlDbType.Int,10, IIf(AppID = Nothing, 0,AppID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.MAPP.mappUserApps)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.MAPP.mappUserApps(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function mappUserAppsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AppID As Int32, ByVal UserID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappUserAppsGetByID(ByVal AppID As Int32, ByVal UserID As String, ByVal Filter_AppID As Int32, ByVal Filter_UserID As String) As SIS.MAPP.mappUserApps
      Return mappUserAppsGetByID(AppID, UserID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function mappUserAppsInsert(ByVal Record As SIS.MAPP.mappUserApps) As SIS.MAPP.mappUserApps
      Dim _Rec As SIS.MAPP.mappUserApps = SIS.MAPP.mappUserApps.mappUserAppsGetNewRecord()
      With _Rec
        .AppID = Record.AppID
        .UserID = Record.UserID
        .IsActive = Record.IsActive
      End With
      Return SIS.MAPP.mappUserApps.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.MAPP.mappUserApps) As SIS.MAPP.mappUserApps
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappUserAppsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppID",SqlDbType.Int,11, Record.AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsActive",SqlDbType.Bit,3, Record.IsActive)
          Cmd.Parameters.Add("@Return_AppID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AppID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.AppID = Cmd.Parameters("@Return_AppID").Value
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function mappUserAppsUpdate(ByVal Record As SIS.MAPP.mappUserApps) As SIS.MAPP.mappUserApps
      Dim _Rec As SIS.MAPP.mappUserApps = SIS.MAPP.mappUserApps.mappUserAppsGetByID(Record.AppID, Record.UserID)
      With _Rec
        .IsActive = Record.IsActive
      End With
      Return SIS.MAPP.mappUserApps.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.MAPP.mappUserApps) As SIS.MAPP.mappUserApps
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappUserAppsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AppID",SqlDbType.Int,11, Record.AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppID",SqlDbType.Int,11, Record.AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsActive",SqlDbType.Bit,3, Record.IsActive)
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
    Public Shared Function mappUserAppsDelete(ByVal Record As SIS.MAPP.mappUserApps) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappUserAppsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AppID",SqlDbType.Int,Record.AppID.ToString.Length, Record.AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
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
