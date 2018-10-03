Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfDBIcons
    Private Shared _RecordCount As Integer
    Private _DBIconID As Int32 = 0
    Private _IconName As String = ""
    Private _IconStyle As String = ""
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
    Public Property DBIconID() As Int32
      Get
        Return _DBIconID
      End Get
      Set(ByVal value As Int32)
        _DBIconID = value
      End Set
    End Property
    Public Property IconName() As String
      Get
        Return _IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IconName = ""
         Else
           _IconName = value
         End If
      End Set
    End Property
    Public Property IconStyle() As String
      Get
        Return _IconStyle
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IconStyle = ""
         Else
           _IconStyle = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IconName.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DBIconID
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
    Public Class PKwfDBIcons
      Private _DBIconID As Int32 = 0
      Public Property DBIconID() As Int32
        Get
          Return _DBIconID
        End Get
        Set(ByVal value As Int32)
          _DBIconID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBIconsSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfDBIcons)
      Dim Results As List(Of SIS.WF.wfDBIcons) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBIconID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBIcons)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBIcons(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBIconsGetNewRecord() As SIS.WF.wfDBIcons
      Return New SIS.WF.wfDBIcons()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBIconsGetByID(ByVal DBIconID As Int32) As SIS.WF.wfDBIcons
      Dim Results As SIS.WF.wfDBIcons = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBIconID",SqlDbType.Int,DBIconID.ToString.Length, DBIconID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfDBIcons(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBIconsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WF.wfDBIcons)
      Dim Results As List(Of SIS.WF.wfDBIcons) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBIconID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDBIconsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDBIconsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBIcons)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBIcons(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDBIconsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDBIconsInsert(ByVal Record As SIS.WF.wfDBIcons) As SIS.WF.wfDBIcons
      Dim _Rec As SIS.WF.wfDBIcons = SIS.WF.wfDBIcons.wfDBIconsGetNewRecord()
      With _Rec
        .IconName = Record.IconName
        .IconStyle = Record.IconStyle
      End With
      Return SIS.WF.wfDBIcons.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfDBIcons) As SIS.WF.wfDBIcons
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IconName",SqlDbType.NVarChar,101, Iif(Record.IconName= "" ,Convert.DBNull, Record.IconName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IconStyle",SqlDbType.NVarChar,251, Iif(Record.IconStyle= "" ,Convert.DBNull, Record.IconStyle))
          Cmd.Parameters.Add("@Return_DBIconID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBIconID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DBIconID = Cmd.Parameters("@Return_DBIconID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDBIconsUpdate(ByVal Record As SIS.WF.wfDBIcons) As SIS.WF.wfDBIcons
      Dim _Rec As SIS.WF.wfDBIcons = SIS.WF.wfDBIcons.wfDBIconsGetByID(Record.DBIconID)
      With _Rec
        .IconName = Record.IconName
        .IconStyle = Record.IconStyle
      End With
      Return SIS.WF.wfDBIcons.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfDBIcons) As SIS.WF.wfDBIcons
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBIconID",SqlDbType.Int,11, Record.DBIconID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IconName",SqlDbType.NVarChar,101, Iif(Record.IconName= "" ,Convert.DBNull, Record.IconName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IconStyle",SqlDbType.NVarChar,251, Iif(Record.IconStyle= "" ,Convert.DBNull, Record.IconStyle))
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
    Public Shared Function wfDBIconsDelete(ByVal Record As SIS.WF.wfDBIcons) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBIconID",SqlDbType.Int,Record.DBIconID.ToString.Length, Record.DBIconID)
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
    Public Shared Function SelectwfDBIconsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBIconsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.WF.wfDBIcons = New SIS.WF.wfDBIcons(Reader)
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
