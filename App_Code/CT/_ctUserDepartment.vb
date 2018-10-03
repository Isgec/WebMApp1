Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class ctUserDepartment
    Private Shared _RecordCount As Integer
    Private _UserID As String = ""
    Private _DepartmentID As String = ""
    Private _IsActive As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _HRM_Departments2_Description As String = ""
    Private _FK_CT_UserDepartment_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_CT_UserDepartment_DepartmentID As SIS.QCM.qcmDepartments = Nothing
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
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
        _UserID = value
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
        _DepartmentID = value
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
    Public Property HRM_Departments2_Description() As String
      Get
        Return _HRM_Departments2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments2_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _UserID & "|" & _DepartmentID
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
    Public Class PKctUserDepartment
      Private _UserID As String = ""
      Private _DepartmentID As String = ""
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
      Public Property DepartmentID() As String
        Get
          Return _DepartmentID
        End Get
        Set(ByVal value As String)
          _DepartmentID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_CT_UserDepartment_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_CT_UserDepartment_UserID Is Nothing Then
          _FK_CT_UserDepartment_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_CT_UserDepartment_UserID
      End Get
    End Property
    Public ReadOnly Property FK_CT_UserDepartment_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_CT_UserDepartment_DepartmentID Is Nothing Then
          _FK_CT_UserDepartment_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_CT_UserDepartment_DepartmentID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctUserDepartmentGetNewRecord() As SIS.CT.ctUserDepartment
      Return New SIS.CT.ctUserDepartment()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctUserDepartmentGetByID(ByVal UserID As String, ByVal DepartmentID As String) As SIS.CT.ctUserDepartment
      Dim Results As SIS.CT.ctUserDepartment = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctUserDepartmentSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,DepartmentID.ToString.Length, DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.ctUserDepartment(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctUserDepartmentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DepartmentID As String) As List(Of SIS.CT.ctUserDepartment)
      Dim Results As List(Of SIS.CT.ctUserDepartment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spctUserDepartmentSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spctUserDepartmentSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DepartmentID",SqlDbType.NVarChar,6, IIf(DepartmentID Is Nothing, String.Empty,DepartmentID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.ctUserDepartment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.ctUserDepartment(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ctUserDepartmentSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DepartmentID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctUserDepartmentGetByID(ByVal UserID As String, ByVal DepartmentID As String, ByVal Filter_UserID As String, ByVal Filter_DepartmentID As String) As SIS.CT.ctUserDepartment
      Return ctUserDepartmentGetByID(UserID, DepartmentID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function ctUserDepartmentInsert(ByVal Record As SIS.CT.ctUserDepartment) As SIS.CT.ctUserDepartment
      Dim _Rec As SIS.CT.ctUserDepartment = SIS.CT.ctUserDepartment.ctUserDepartmentGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .DepartmentID = Record.DepartmentID
        .IsActive = Record.IsActive
      End With
      Return SIS.CT.ctUserDepartment.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.CT.ctUserDepartment) As SIS.CT.ctUserDepartment
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctUserDepartmentInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsActive",SqlDbType.Bit,3, Record.IsActive)
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DepartmentID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_DepartmentID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
          Record.DepartmentID = Cmd.Parameters("@Return_DepartmentID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function ctUserDepartmentUpdate(ByVal Record As SIS.CT.ctUserDepartment) As SIS.CT.ctUserDepartment
      Dim _Rec As SIS.CT.ctUserDepartment = SIS.CT.ctUserDepartment.ctUserDepartmentGetByID(Record.UserID, Record.DepartmentID)
      With _Rec
        .IsActive = Record.IsActive
      End With
      Return SIS.CT.ctUserDepartment.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.CT.ctUserDepartment) As SIS.CT.ctUserDepartment
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctUserDepartmentUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
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
    Public Shared Function ctUserDepartmentDelete(ByVal Record As SIS.CT.ctUserDepartment) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctUserDepartmentDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DepartmentID",SqlDbType.NVarChar,Record.DepartmentID.ToString.Length, Record.DepartmentID)
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
