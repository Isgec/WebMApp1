Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.MAPP
  <DataObject()> _
  Partial Public Class mappApplications
    Private Shared _RecordCount As Integer
    Private _AppID As Int32 = 0
    Private _ApplicationName As String = ""
    Private _ApplicationDescription As String = ""
    Private _IsActive As Boolean = False
    Private _MainPageURL As String = ""
    Private _AppIconID As String = ""
    Private _AppIconStyle As String = ""
    Private _WF_DBIcons1_IconName As String = ""
    Private _FK_MAPP_Applications_ApplIconID As SIS.WF.wfDBIcons = Nothing
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
    Public Property ApplicationName() As String
      Get
        Return _ApplicationName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApplicationName = ""
         Else
           _ApplicationName = value
         End If
      End Set
    End Property
    Public Property ApplicationDescription() As String
      Get
        Return _ApplicationDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApplicationDescription = ""
         Else
           _ApplicationDescription = value
         End If
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
    Public Property MainPageURL() As String
      Get
        Return _MainPageURL
      End Get
      Set(ByVal value As String)
        _MainPageURL = value
      End Set
    End Property
    Public Property AppIconID() As String
      Get
        Return _AppIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AppIconID = ""
         Else
           _AppIconID = value
         End If
      End Set
    End Property
    Public Property AppIconStyle() As String
      Get
        Return _AppIconStyle
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AppIconStyle = ""
         Else
           _AppIconStyle = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons1_IconName() As String
      Get
        Return _WF_DBIcons1_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons1_IconName = ""
         Else
           _WF_DBIcons1_IconName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ApplicationName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _AppID
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
    Public Class PKmappApplications
      Private _AppID As Int32 = 0
      Public Property AppID() As Int32
        Get
          Return _AppID
        End Get
        Set(ByVal value As Int32)
          _AppID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_MAPP_Applications_ApplIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_MAPP_Applications_ApplIconID Is Nothing Then
          _FK_MAPP_Applications_ApplIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_AppIconID)
        End If
        Return _FK_MAPP_Applications_ApplIconID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappApplicationsSelectList(ByVal OrderBy As String) As List(Of SIS.MAPP.mappApplications)
      Dim Results As List(Of SIS.MAPP.mappApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.MAPP.mappApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.MAPP.mappApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappApplicationsGetNewRecord() As SIS.MAPP.mappApplications
      Return New SIS.MAPP.mappApplications()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappApplicationsGetByID(ByVal AppID As Int32) As SIS.MAPP.mappApplications
      Dim Results As SIS.MAPP.mappApplications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppID",SqlDbType.Int,AppID.ToString.Length, AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.MAPP.mappApplications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function mappApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.MAPP.mappApplications)
      Dim Results As List(Of SIS.MAPP.mappApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spmappApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spmappApplicationsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.MAPP.mappApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.MAPP.mappApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function mappApplicationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function mappApplicationsInsert(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Dim _Rec As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetNewRecord()
      With _Rec
        .ApplicationName = Record.ApplicationName
        .ApplicationDescription = Record.ApplicationDescription
        .IsActive = Record.IsActive
        .MainPageURL = Record.MainPageURL
        .AppIconID = Record.AppIconID
        .AppIconStyle = Record.AppIconStyle
      End With
      Return SIS.MAPP.mappApplications.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationName",SqlDbType.NVarChar,51, Iif(Record.ApplicationName= "" ,Convert.DBNull, Record.ApplicationName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationDescription",SqlDbType.NVarChar,251, Iif(Record.ApplicationDescription= "" ,Convert.DBNull, Record.ApplicationDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsActive",SqlDbType.Bit,3, Record.IsActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainPageURL",SqlDbType.NVarChar,501, Record.MainPageURL)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppIconID",SqlDbType.Int,11, Iif(Record.AppIconID= "" ,Convert.DBNull, Record.AppIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppIconStyle",SqlDbType.NVarChar,501, Iif(Record.AppIconStyle= "" ,Convert.DBNull, Record.AppIconStyle))
          Cmd.Parameters.Add("@Return_AppID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AppID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.AppID = Cmd.Parameters("@Return_AppID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function mappApplicationsUpdate(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Dim _Rec As SIS.MAPP.mappApplications = SIS.MAPP.mappApplications.mappApplicationsGetByID(Record.AppID)
      With _Rec
        .ApplicationName = Record.ApplicationName
        .ApplicationDescription = Record.ApplicationDescription
        .IsActive = Record.IsActive
        .MainPageURL = Record.MainPageURL
        .AppIconID = Record.AppIconID
        .AppIconStyle = Record.AppIconStyle
      End With
      Return SIS.MAPP.mappApplications.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AppID",SqlDbType.Int,11, Record.AppID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationName",SqlDbType.NVarChar,51, Iif(Record.ApplicationName= "" ,Convert.DBNull, Record.ApplicationName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationDescription",SqlDbType.NVarChar,251, Iif(Record.ApplicationDescription= "" ,Convert.DBNull, Record.ApplicationDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsActive",SqlDbType.Bit,3, Record.IsActive)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainPageURL",SqlDbType.NVarChar,501, Record.MainPageURL)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppIconID",SqlDbType.Int,11, Iif(Record.AppIconID= "" ,Convert.DBNull, Record.AppIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppIconStyle",SqlDbType.NVarChar,501, Iif(Record.AppIconStyle= "" ,Convert.DBNull, Record.AppIconStyle))
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
    Public Shared Function mappApplicationsDelete(ByVal Record As SIS.MAPP.mappApplications) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AppID",SqlDbType.Int,Record.AppID.ToString.Length, Record.AppID)
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
'    Autocomplete Method
    Public Shared Function SelectmappApplicationsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spmappApplicationsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.MAPP.mappApplications = New SIS.MAPP.mappApplications(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
