Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class ctPUActivity
    Private Shared _RecordCount As Integer
    Private _t_srno As Int32 = 0
    Private _t_plsd As String = ""
    Private _t_plfd As String = ""
    Private _t_acsd As String = ""
    Private _t_aced As String = ""
    Private _t_puom As String = ""
    Private _t_tpgv As Double = 0
    Private _t_cpgv As Double = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_gps2 As String = ""
    Private _t_gps4 As String = ""
    Private _t_cron As String = ""
    Private _t_gps1 As String = ""
    Private _t_gps3 As String = ""
    Private _t_crby As String = ""
    Private _t_otsd As String = ""
    Private _t_atid As String = ""
    Private _t_cprj As String = ""
    Private _t_Refcntu As Int32 = 0
    Private _t_rmks As String = ""
    Private _t_oted As String = ""
    Public Property t_orno As String = ""
    Public Property t_bohd As String = ""
    Private _ttcmcs0522001_t_dsca As String = ""
    Private _ttpisg2202002_t_desc As String = ""
    Private _FK_ttpisg183200_t_cprj As SIS.CT.ctProjects = Nothing
    Private _FK_ttpisg183200_t_atid As SIS.CT.ctPActivity = Nothing
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
    Public Property t_srno() As Int32
      Get
        Return _t_srno
      End Get
      Set(ByVal value As Int32)
        _t_srno = value
      End Set
    End Property
    Public Property t_plsd() As String
      Get
        If Not _t_plsd = String.Empty Then
          Return Convert.ToDateTime(_t_plsd).ToString("dd/MM/yyyy")
        End If
        Return _t_plsd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_plsd = ""
        Else
          _t_plsd = value
        End If
      End Set
    End Property
    Public Property t_plfd() As String
      Get
        If Not _t_plfd = String.Empty Then
          Return Convert.ToDateTime(_t_plfd).ToString("dd/MM/yyyy")
        End If
        Return _t_plfd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_plfd = ""
        Else
          _t_plfd = value
        End If
      End Set
    End Property
    Public Property t_puom() As String
      Get
        Return _t_puom
      End Get
      Set(ByVal value As String)
        _t_puom = value
      End Set
    End Property
    Public Property t_tpgv() As Double
      Get
        Return _t_tpgv
      End Get
      Set(ByVal value As Double)
        _t_tpgv = value
      End Set
    End Property
    Public Property t_cpgv() As Double
      Get
        Return _t_cpgv
      End Get
      Set(ByVal value As Double)
        _t_cpgv = value
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
    Public Property t_gps2() As String
      Get
        Return _t_gps2
      End Get
      Set(ByVal value As String)
        _t_gps2 = value
      End Set
    End Property
    Public Property t_gps4() As String
      Get
        Return _t_gps4
      End Get
      Set(ByVal value As String)
        _t_gps4 = value
      End Set
    End Property
    Public Property t_cron() As String
      Get
        If Not _t_cron = String.Empty Then
          Return Convert.ToDateTime(_t_cron).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        Return _t_cron
      End Get
      Set(ByVal value As String)
         _t_cron = value
      End Set
    End Property
    Public Property t_gps1() As String
      Get
        Return _t_gps1
      End Get
      Set(ByVal value As String)
        _t_gps1 = value
      End Set
    End Property
    Public Property t_gps3() As String
      Get
        Return _t_gps3
      End Get
      Set(ByVal value As String)
        _t_gps3 = value
      End Set
    End Property
    Public Property t_crby() As String
      Get
        Return _t_crby
      End Get
      Set(ByVal value As String)
        _t_crby = value
      End Set
    End Property
    Public Property t_atid() As String
      Get
        Return _t_atid
      End Get
      Set(ByVal value As String)
        _t_atid = value
      End Set
    End Property
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
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
    Public Property t_rmks() As String
      Get
        Return _t_rmks
      End Get
      Set(ByVal value As String)
        _t_rmks = value
      End Set
    End Property
    Public Property ttcmcs0522001_t_dsca() As String
      Get
        Return _ttcmcs0522001_t_dsca
      End Get
      Set(ByVal value As String)
        _ttcmcs0522001_t_dsca = value
      End Set
    End Property
    Public Property ttpisg2202002_t_desc() As String
      Get
        Return _ttpisg2202002_t_desc
      End Get
      Set(ByVal value As String)
        _ttpisg2202002_t_desc = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_cprj & "|" & _t_atid & "|" & _t_srno
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
    Public Class PKctPUActivity
      Private _t_cprj As String = ""
      Private _t_atid As String = ""
      Private _t_srno As Int32 = 0
      Public Property t_cprj() As String
        Get
          Return _t_cprj
        End Get
        Set(ByVal value As String)
          _t_cprj = value
        End Set
      End Property
      Public Property t_atid() As String
        Get
          Return _t_atid
        End Get
        Set(ByVal value As String)
          _t_atid = value
        End Set
      End Property
      Public Property t_srno() As Int32
        Get
          Return _t_srno
        End Get
        Set(ByVal value As Int32)
          _t_srno = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ttpisg183200_t_cprj() As SIS.CT.ctProjects
      Get
        If _FK_ttpisg183200_t_cprj Is Nothing Then
          _FK_ttpisg183200_t_cprj = SIS.CT.ctProjects.ctProjectsGetByID(_t_cprj)
        End If
        Return _FK_ttpisg183200_t_cprj
      End Get
    End Property
    Public ReadOnly Property FK_ttpisg183200_t_atid() As SIS.CT.ctPActivity
      Get
        If _FK_ttpisg183200_t_atid Is Nothing Then
          _FK_ttpisg183200_t_atid = SIS.CT.ctPActivity.ctPActivityGetByID(_t_cprj, _t_atid)
        End If
        Return _FK_ttpisg183200_t_atid
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctPUActivityGetNewRecord() As SIS.CT.ctPUActivity
      Return New SIS.CT.ctPUActivity()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ctPUActivityGetByID(ByVal t_cprj As String, ByVal t_atid As String, ByVal t_srno As Int32) As SIS.CT.ctPUActivity
      Dim Results As SIS.CT.ctPUActivity = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPUActivitySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, t_cprj.ToString.Length, t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atid", SqlDbType.VarChar, t_atid.ToString.Length, t_atid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, t_srno.ToString.Length, t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.ctPUActivity(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPUActivitySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_atid As String, ByVal t_cprj As String) As List(Of SIS.CT.ctPUActivity)
      Dim Results As List(Of SIS.CT.ctPUActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "t_srno DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spctPUActivitySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spctPUActivitySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_atid", SqlDbType.VarChar, 30, IIf(t_atid Is Nothing, String.Empty, t_atid))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.ctPUActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.ctPUActivity(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ctPUActivitySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_atid As String, ByVal t_cprj As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPUActivityGetByID(ByVal t_cprj As String, ByVal t_atid As String, ByVal t_srno As Int32, ByVal Filter_t_atid As String, ByVal Filter_t_cprj As String) As SIS.CT.ctPUActivity
      Return ctPUActivityGetByID(t_cprj, t_atid, t_srno)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function ctPUActivityInsert(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Dim _Rec As SIS.CT.ctPUActivity = SIS.CT.ctPUActivity.ctPUActivityGetNewRecord()
      With _Rec
        .t_srno = Record.t_srno
        .t_plsd = Record.t_plsd
        .t_plfd = Record.t_plfd
        .t_acsd = Record.t_acsd
        .t_aced = Record.t_aced
        .t_otsd = Record.t_otsd
        .t_oted = Record.t_oted
        .t_puom = Record.t_puom
        .t_tpgv = Record.t_tpgv
        .t_cpgv = Record.t_cpgv
        .t_Refcntd = Record.t_Refcntd
        .t_gps2 = Record.t_gps2
        .t_gps4 = Record.t_gps4
        .t_cron = Now
        .t_gps1 = Record.t_gps1
        .t_gps3 = Record.t_gps3
        .t_crby = HttpContext.Current.Session("LoginID")
        .t_atid = Record.t_atid
        .t_cprj = Record.t_cprj
        .t_Refcntu = Record.t_Refcntu
        .t_rmks = Record.t_rmks
        .t_orno = Record.t_orno
        .t_bohd = Record.t_bohd
      End With
      Return SIS.CT.ctPUActivity.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPUActivityInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_plsd", SqlDbType.DateTime, 21, IIf(Record.t_plsd = "", "01/01/1970", Record.t_plsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_plfd", SqlDbType.DateTime, 21, IIf(Record.t_plfd = "", "01/01/1970", Record.t_plfd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acsd", SqlDbType.DateTime, 21, IIf(Record.t_acsd = "", "01/01/1970", Record.t_acsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aced", SqlDbType.DateTime, 21, IIf(Record.t_aced = "", "01/01/1970", Record.t_aced))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_otsd", SqlDbType.DateTime, 21, IIf(Record.t_otsd = "", "01/01/1970", Record.t_otsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_oted", SqlDbType.DateTime, 21, IIf(Record.t_oted = "", "01/01/1970", Record.t_oted))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_puom", SqlDbType.VarChar, 11, Record.t_puom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tpgv", SqlDbType.Float, 16, Record.t_tpgv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cpgv", SqlDbType.Float, 16, Record.t_cpgv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps2", SqlDbType.VarChar, 101, Record.t_gps2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps4", SqlDbType.VarChar, 251, Record.t_gps4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cron", SqlDbType.DateTime, 21, Record.t_cron)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps1", SqlDbType.VarChar, 101, Record.t_gps1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps3", SqlDbType.VarChar, 101, Record.t_gps3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crby", SqlDbType.VarChar, 17, Record.t_crby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atid", SqlDbType.VarChar, 31, Record.t_atid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 7, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rmks", SqlDbType.VarChar, 501, Record.t_rmks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bohd", SqlDbType.VarChar, 50, Record.t_bohd)
          Cmd.Parameters.Add("@Return_t_cprj", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_t_cprj").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_atid", SqlDbType.VarChar, 31)
          Cmd.Parameters("@Return_t_atid").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_srno", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_srno").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_cprj = Cmd.Parameters("@Return_t_cprj").Value
          Record.t_atid = Cmd.Parameters("@Return_t_atid").Value
          Record.t_srno = Cmd.Parameters("@Return_t_srno").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function ctPUActivityUpdate(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Dim _Rec As SIS.CT.ctPUActivity = SIS.CT.ctPUActivity.ctPUActivityGetByID(Record.t_cprj, Record.t_atid, Record.t_srno)
      With _Rec
        .t_srno = Record.t_srno
        .t_plsd = Record.t_plsd
        .t_plfd = Record.t_plfd
        .t_acsd = Record.t_acsd
        .t_aced = Record.t_aced
        .t_otsd = Record.t_otsd
        .t_oted = Record.t_oted
        .t_puom = Record.t_puom
        .t_tpgv = Record.t_tpgv
        .t_cpgv = Record.t_cpgv
        .t_Refcntd = Record.t_Refcntd
        .t_gps2 = Record.t_gps2
        .t_gps4 = Record.t_gps4
        .t_cron = Now
        .t_gps1 = Record.t_gps1
        .t_gps3 = Record.t_gps3
        .t_crby = HttpContext.Current.Session("LoginID")
        .t_atid = Record.t_atid
        .t_cprj = Record.t_cprj
        .t_Refcntu = Record.t_Refcntu
        .t_rmks = Record.t_rmks
        .t_orno = IIf(.t_orno = "", Record.t_orno, .t_orno)
      End With
      'Update CT 
      'Only in case of Erec & Commissioning NOT for MFG
      Dim tmpPA As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(Record.t_cprj, Record.t_atid)
      Select Case tmpPA.t_bohd
        Case "CT_ERECTION", "CT_COMMISSIONING", "CT_ESTIMATION", "CT_LOGISTIC", "CT_MARKETING", "CT_PROJECT"
          If Record.t_tpgv + Record.t_cpgv < 100 Then Record.t_aced = ""
          If Record.t_tpgv + Record.t_cpgv = 0 Then Record.t_acsd = ""
          Dim Sql As String = ""
          Sql &= " UPDATE ttpisg220200 SET "
          Sql &= " t_acsd=convert(datetime,'" & IIf(Record.t_acsd = "", "01/01/1753", Record.t_acsd) & "',103), "
          Sql &= " t_acfn=convert(datetime,'" & IIf(Record.t_aced = "", "01/01/1753", Record.t_aced) & "',103), "
          Sql &= " t_otsd=convert(datetime,'" & IIf(Record.t_otsd = "", "01/01/1970", Record.t_otsd) & "',103), "
          Sql &= " t_oted=convert(datetime,'" & IIf(Record.t_oted = "", "01/01/1970", Record.t_oted) & "',103), "
          Sql &= " t_rmks='" & Record.t_rmks & "',"
          Sql &= " t_gps1='" & Record.t_gps1 & "',"
          Sql &= " t_gps2='" & Record.t_gps2 & "',"
          Sql &= " t_gps3='" & Record.t_gps3 & "',"
          Sql &= " t_gps4='" & Record.t_gps4 & "',"
          Sql &= " t_cpgv= " & Record.t_cpgv + Record.t_tpgv
          Sql &= " WHERE t_cprj ='" & Record.t_cprj & "' AND t_cact ='" & Record.t_atid & "'"
          Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = Sql
              Con.Open()
              Cmd.ExecuteNonQuery()
            End Using
          End Using
        Case "CT_MANUFACTURING"
          Dim mayUpdate As Boolean = False
          If tmpPA.t_acsd = "" Then
            If Record.t_tpgv > 0 Then
              mayUpdate = True
            End If
          Else
            If Convert.ToDateTime(tmpPA.t_acsd) < Convert.ToDateTime("31/12/2000") Then
              mayUpdate = True
            ElseIf Record.t_acsd <> "" Then
              If Convert.ToDateTime(tmpPA.t_acsd) > Convert.ToDateTime(Record.t_acsd) Then
                mayUpdate = True
              End If
            End If
            If Record.t_tpgv + Record.t_cpgv = 0 Then
              Record.t_acsd = ""
              If Convert.ToDateTime(tmpPA.t_acsd) > Convert.ToDateTime("31/12/2000") Then
                mayUpdate = True
              End If
            End If

          End If
          If mayUpdate Then
            Dim Sql As String = ""
            Sql &= " UPDATE ttpisg220200 SET "
            Sql &= " t_acsd=convert(datetime,'" & IIf(Record.t_acsd = "", "01/01/1753", Record.t_acsd) & "',103) "
            Sql &= " WHERE t_cprj ='" & Record.t_cprj & "' AND t_cact ='" & Record.t_atid & "'"
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                Con.Open()
                Cmd.ExecuteNonQuery()
              End Using
            End Using
          End If
      End Select
      Return SIS.CT.ctPUActivity.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPUActivityUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_atid", SqlDbType.VarChar, 31, Record.t_atid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cprj", SqlDbType.NVarChar, 7, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_plsd", SqlDbType.DateTime, 21, IIf(Record.t_plsd = "", "01/01/1970", Record.t_plsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_plfd", SqlDbType.DateTime, 21, IIf(Record.t_plfd = "", "01/01/1970", Record.t_plfd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acsd", SqlDbType.DateTime, 21, IIf(Record.t_acsd = "", "01/01/1970", Record.t_acsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aced", SqlDbType.DateTime, 21, IIf(Record.t_aced = "", "01/01/1970", Record.t_aced))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_otsd", SqlDbType.DateTime, 21, IIf(Record.t_otsd = "", "01/01/1970", Record.t_otsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_oted", SqlDbType.DateTime, 21, IIf(Record.t_oted = "", "01/01/1970", Record.t_oted))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_puom", SqlDbType.VarChar, 11, Record.t_puom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tpgv", SqlDbType.Float, 16, Record.t_tpgv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cpgv", SqlDbType.Float, 16, Record.t_cpgv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps2", SqlDbType.VarChar, 101, Record.t_gps2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps4", SqlDbType.VarChar, 251, Record.t_gps4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cron", SqlDbType.DateTime, 21, Record.t_cron)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps1", SqlDbType.VarChar, 101, Record.t_gps1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps3", SqlDbType.VarChar, 101, Record.t_gps3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crby", SqlDbType.VarChar, 17, Record.t_crby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atid", SqlDbType.VarChar, 31, Record.t_atid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 7, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rmks", SqlDbType.VarChar, 501, Record.t_rmks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bohd", SqlDbType.VarChar, 50, Record.t_bohd)
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
    Public Shared Function ctPUActivityDelete(ByVal Record As SIS.CT.ctPUActivity) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPUActivityDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cprj", SqlDbType.NVarChar, Record.t_cprj.ToString.Length, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_atid", SqlDbType.VarChar, Record.t_atid.ToString.Length, Record.t_atid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_srno", SqlDbType.Int, Record.t_srno.ToString.Length, Record.t_srno)
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
