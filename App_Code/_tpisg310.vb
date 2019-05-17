Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg310
    Private Shared _RecordCount As Integer
    Private _t_ccod As String = ""
    Private _t_moyr As String = ""
    Private _t_ifbu As Double = 0
    Private _t_ifac As Double = 0
    Private _t_ifva As Double = 0
    Private _t_ofbu As Double = 0
    Private _t_ofac As Double = 0
    Private _t_ofva As Double = 0
    Private _t_ntbu As Double = 0
    Private _t_ntac As Double = 0
    Private _t_ntva As Double = 0
    Private _t_user As String = ""
    Private _t_updt As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
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
    Public Property t_ccod() As String
      Get
        Return _t_ccod
      End Get
      Set(ByVal value As String)
        _t_ccod = value
      End Set
    End Property
    Public Property t_moyr() As String
      Get
        Return _t_moyr
      End Get
      Set(ByVal value As String)
        _t_moyr = value
      End Set
    End Property
    Public Property t_ifbu() As Double
      Get
        Return _t_ifbu
      End Get
      Set(ByVal value As Double)
        _t_ifbu = value
      End Set
    End Property
    Public Property t_ifac() As Double
      Get
        Return _t_ifac
      End Get
      Set(ByVal value As Double)
        _t_ifac = value
      End Set
    End Property
    Public Property t_ifva() As Double
      Get
        Return _t_ifva
      End Get
      Set(ByVal value As Double)
        _t_ifva = value
      End Set
    End Property
    Public Property t_ofbu() As Double
      Get
        Return _t_ofbu
      End Get
      Set(ByVal value As Double)
        _t_ofbu = value
      End Set
    End Property
    Public Property t_ofac() As Double
      Get
        Return _t_ofac
      End Get
      Set(ByVal value As Double)
        _t_ofac = value
      End Set
    End Property
    Public Property t_ofva() As Double
      Get
        Return _t_ofva
      End Get
      Set(ByVal value As Double)
        _t_ofva = value
      End Set
    End Property
    Public Property t_ntbu() As Double
      Get
        Return _t_ntbu
      End Get
      Set(ByVal value As Double)
        _t_ntbu = value
      End Set
    End Property
    Public Property t_ntac() As Double
      Get
        Return _t_ntac
      End Get
      Set(ByVal value As Double)
        _t_ntac = value
      End Set
    End Property
    Public Property t_ntva() As Double
      Get
        Return _t_ntva
      End Get
      Set(ByVal value As Double)
        _t_ntva = value
      End Set
    End Property
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_updt() As String
      Get
        If Not _t_updt = String.Empty Then
          Return Convert.ToDateTime(_t_updt).ToString("dd/MM/yyyy")
        End If
        Return _t_updt
      End Get
      Set(ByVal value As String)
        _t_updt = value
      End Set
    End Property
    Public Property t_Refcntd() As Int32
      Get
        Return _t_Refcntd
      End Get
      Set(ByVal value As Int32)
        _t_Refcntd = value
      End Set
    End Property
    Public Property t_Refcntu() As Int32
      Get
        Return _t_Refcntu
      End Get
      Set(ByVal value As Int32)
        _t_Refcntu = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_ccod & "|" & _t_moyr
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
    Public Class PKtpisg310
      Private _t_ccod As String = ""
      Private _t_moyr As String = ""
      Public Property t_ccod() As String
        Get
          Return _t_ccod
        End Get
        Set(ByVal value As String)
          _t_ccod = value
        End Set
      End Property
      Public Property t_moyr() As String
        Get
          Return _t_moyr
        End Get
        Set(ByVal value As String)
          _t_moyr = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg310GetNewRecord() As SIS.CT.tpisg310
      Return New SIS.CT.tpisg310()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg310GetByID(ByVal t_ccod As String, ByVal t_moyr As String) As SIS.CT.tpisg310
      Dim Results As SIS.CT.tpisg310 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg310SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, t_ccod.ToString.Length, t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_moyr", SqlDbType.VarChar, t_moyr.ToString.Length, t_moyr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg310(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg310SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.CT.tpisg310)
      Dim Results As List(Of SIS.CT.tpisg310) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg310SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg310SelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.tpisg310)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg310(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg310SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function tpisg310Insert(ByVal Record As SIS.CT.tpisg310) As SIS.CT.tpisg310
      Dim _Rec As SIS.CT.tpisg310 = SIS.CT.tpisg310.tpisg310GetNewRecord()
      With _Rec
        .t_ccod = Record.t_ccod
        .t_moyr = Record.t_moyr
        .t_ifbu = Record.t_ifbu
        .t_ifac = Record.t_ifac
        .t_ifva = Record.t_ifva
        .t_ofbu = Record.t_ofbu
        .t_ofac = Record.t_ofac
        .t_ofva = Record.t_ofva
        .t_ntbu = Record.t_ntbu
        .t_ntac = Record.t_ntac
        .t_ntva = Record.t_ntva
        .t_user = Record.t_user
        .t_updt = Record.t_updt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.CT.tpisg310.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.CT.tpisg310) As SIS.CT.tpisg310
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg310Insert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, 10, Record.t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_moyr", SqlDbType.VarChar, 11, Record.t_moyr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifbu", SqlDbType.Float, 16, Record.t_ifbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifac", SqlDbType.Float, 16, Record.t_ifac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifva", SqlDbType.Float, 16, Record.t_ifva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbu", SqlDbType.Float, 16, Record.t_ofbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofac", SqlDbType.Float, 16, Record.t_ofac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofva", SqlDbType.Float, 16, Record.t_ofva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntbu", SqlDbType.Float, 16, Record.t_ntbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntac", SqlDbType.Float, 16, Record.t_ntac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntva", SqlDbType.Float, 16, Record.t_ntva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user", SqlDbType.VarChar, 17, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_updt", SqlDbType.DateTime, 21, Record.t_updt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          Cmd.Parameters.Add("@Return_t_ccod", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_ccod").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_moyr", SqlDbType.VarChar, 11)
          Cmd.Parameters("@Return_t_moyr").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_ccod = Cmd.Parameters("@Return_t_ccod").Value
          Record.t_moyr = Cmd.Parameters("@Return_t_moyr").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function tpisg310Update(ByVal Record As SIS.CT.tpisg310) As SIS.CT.tpisg310
      Dim _Rec As SIS.CT.tpisg310 = SIS.CT.tpisg310.tpisg310GetByID(Record.t_ccod, Record.t_moyr)
      With _Rec
        .t_ifbu = Record.t_ifbu
        .t_ifac = Record.t_ifac
        .t_ifva = Record.t_ifva
        .t_ofbu = Record.t_ofbu
        .t_ofac = Record.t_ofac
        .t_ofva = Record.t_ofva
        .t_ntbu = Record.t_ntbu
        .t_ntac = Record.t_ntac
        .t_ntva = Record.t_ntva
        .t_user = Record.t_user
        .t_updt = Record.t_updt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.CT.tpisg310.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.CT.tpisg310) As SIS.CT.tpisg310
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg310Update"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_ccod", SqlDbType.VarChar, 10, Record.t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_moyr", SqlDbType.VarChar, 11, Record.t_moyr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, 10, Record.t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_moyr", SqlDbType.VarChar, 11, Record.t_moyr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifbu", SqlDbType.Float, 16, Record.t_ifbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifac", SqlDbType.Float, 16, Record.t_ifac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifva", SqlDbType.Float, 16, Record.t_ifva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbu", SqlDbType.Float, 16, Record.t_ofbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofac", SqlDbType.Float, 16, Record.t_ofac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofva", SqlDbType.Float, 16, Record.t_ofva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntbu", SqlDbType.Float, 16, Record.t_ntbu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntac", SqlDbType.Float, 16, Record.t_ntac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntva", SqlDbType.Float, 16, Record.t_ntva)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user", SqlDbType.VarChar, 17, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_updt", SqlDbType.DateTime, 21, Record.t_updt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function tpisg310Delete(ByVal Record As SIS.CT.tpisg310) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg310Delete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_ccod", SqlDbType.VarChar, Record.t_ccod.ToString.Length, Record.t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_moyr", SqlDbType.VarChar, Record.t_moyr.ToString.Length, Record.t_moyr)
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
