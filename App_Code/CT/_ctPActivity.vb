Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class ctPActivity
    'checking Modification in Git Hub
    Private Shared _RecordCount As Integer
    Private _t_cprj As String = ""
    Private _t_acty As String = ""
    Private _t_amod As String = ""
    Private _t_dept As String = ""
    Private _t_desc As String = ""
    Private _t_exdo As Int32 = 0
    Private _t_outl As Int32 = 0
    Private _t_pcbs As String = ""
    Private _t_sub1 As String = ""
    Private _t_sub2 As String = ""
    Private _t_sub3 As String = ""
    Private _t_sub4 As String = ""
    Private _t_vali As Int32 = 0
    Private _t_cpgv As Double = 0
    Private _t_cact As String = ""
    Private _t_pcod As String = ""
    Private _t_sdst As String = ""
    Private _t_sdfn As String = ""
    Private _t_acsd As String = ""
    Private _t_acfn As String = ""
    'Private _t_iref As String = ""
    Private _t_otsd As String = ""
    Private _t_oted As String = ""
    Private _t_rmks As String = ""
    Private _t_gps3 As String = ""
    Private _t_gps4 As String = ""
    Private _t_gps2 As String = ""
    Private _t_pred As String = ""
    Private _t_gps1 As String = ""
    Private _t_succ As String = ""
    Private _t_dura As Int32 = 0
    Private _t_bcod As String = ""
    Private _t_pact As String = ""
    Private _t_bohd As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_actp As Int32 = 0
    Private _t_schd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _ttcmcs0522001_t_dsca As String = ""
    Private _FK_ttpisg220200_t_cprj As SIS.CT.ctProjects = Nothing
    Public Property t_orno As String = ""
    Public Property t_sitm As String = ""
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
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Property t_acty() As String
      Get
        Return _t_acty
      End Get
      Set(ByVal value As String)
        _t_acty = value
      End Set
    End Property
    Public Property t_amod() As String
      Get
        Return _t_amod
      End Get
      Set(ByVal value As String)
        _t_amod = value
      End Set
    End Property
    Public Property t_dept() As String
      Get
        Return _t_dept
      End Get
      Set(ByVal value As String)
        _t_dept = value
      End Set
    End Property
    Public Property t_desc() As String
      Get
        Return _t_desc
      End Get
      Set(ByVal value As String)
        _t_desc = value
      End Set
    End Property
    Public Property t_exdo() As Int32
      Get
        Return _t_exdo
      End Get
      Set(ByVal value As Int32)
        _t_exdo = value
      End Set
    End Property
    Public Property t_outl() As Int32
      Get
        Return _t_outl
      End Get
      Set(ByVal value As Int32)
        _t_outl = value
      End Set
    End Property
    Public Property t_pcbs() As String
      Get
        Return _t_pcbs
      End Get
      Set(ByVal value As String)
        _t_pcbs = value
      End Set
    End Property
    Public Property t_sub1() As String
      Get
        Return _t_sub1
      End Get
      Set(ByVal value As String)
        _t_sub1 = value
      End Set
    End Property
    Public Property t_sub2() As String
      Get
        Return _t_sub2
      End Get
      Set(ByVal value As String)
        _t_sub2 = value
      End Set
    End Property
    Public Property t_sub3() As String
      Get
        Return _t_sub3
      End Get
      Set(ByVal value As String)
        _t_sub3 = value
      End Set
    End Property
    Public Property t_sub4() As String
      Get
        Return _t_sub4
      End Get
      Set(ByVal value As String)
        _t_sub4 = value
      End Set
    End Property
    Public Property t_vali() As Int32
      Get
        Return _t_vali
      End Get
      Set(ByVal value As Int32)
        _t_vali = value
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
    Public Property t_cact() As String
      Get
        Return _t_cact
      End Get
      Set(ByVal value As String)
        _t_cact = value
      End Set
    End Property
    Public Property t_pcod() As String
      Get
        Return _t_pcod
      End Get
      Set(ByVal value As String)
        _t_pcod = value
      End Set
    End Property
    Public Property t_sdst() As String
      Get
        If Not _t_sdst = String.Empty Then
          Return Convert.ToDateTime(_t_sdst).ToString("dd/MM/yyyy")
        End If
        Return _t_sdst
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_sdst = ""
        Else
          _t_sdst = value
        End If
      End Set
    End Property
    Public Property t_sdfn() As String
      Get
        If Not _t_sdfn = String.Empty Then
          Return Convert.ToDateTime(_t_sdfn).ToString("dd/MM/yyyy")
        End If
        Return _t_sdfn
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_sdfn = ""
        Else
          _t_sdfn = value
        End If
      End Set
    End Property
    Public Property t_acsd() As String
      Get
        If Not _t_acsd = String.Empty Then
          Return Convert.ToDateTime(_t_acsd).ToString("dd/MM/yyyy")
        End If
        Return _t_acsd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_acsd = ""
        Else
          _t_acsd = value
        End If
      End Set
    End Property
    Public Property t_acfn() As String
      Get
        If Not _t_acfn = String.Empty Then
          Return Convert.ToDateTime(_t_acfn).ToString("dd/MM/yyyy")
        End If
        Return _t_acfn
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_acfn = ""
        Else
          _t_acfn = value
        End If
      End Set
    End Property
    'Public Property t_iref() As String
    '  Get
    '    Return _t_iref
    '  End Get
    '  Set(ByVal value As String)
    '    _t_iref = value
    '  End Set
    'End Property
    Public Property t_otsd() As String
      Get
        If Not _t_otsd = String.Empty Then
          Return Convert.ToDateTime(_t_otsd).ToString("dd/MM/yyyy")
        End If
        Return _t_otsd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_otsd = ""
        Else
          _t_otsd = value
        End If
      End Set
    End Property
    Public Property t_oted() As String
      Get
        If Not _t_oted = String.Empty Then
          Return Convert.ToDateTime(_t_oted).ToString("dd/MM/yyyy")
        End If
        Return _t_oted
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_oted = ""
        Else
          _t_oted = value
        End If
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
    Public Property t_gps3() As String
      Get
        Return _t_gps3
      End Get
      Set(ByVal value As String)
        _t_gps3 = value
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
    Public Property t_gps2() As String
      Get
        Return _t_gps2
      End Get
      Set(ByVal value As String)
        _t_gps2 = value
      End Set
    End Property
    Public Property t_pred() As String
      Get
        Return _t_pred
      End Get
      Set(ByVal value As String)
        _t_pred = value
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
    Public Property t_succ() As String
      Get
        Return _t_succ
      End Get
      Set(ByVal value As String)
        _t_succ = value
      End Set
    End Property
    Public Property t_dura() As Int32
      Get
        Return _t_dura
      End Get
      Set(ByVal value As Int32)
        _t_dura = value
      End Set
    End Property
    Public Property t_bcod() As String
      Get
        Return _t_bcod
      End Get
      Set(ByVal value As String)
        _t_bcod = value
      End Set
    End Property
    Public Property t_pact() As String
      Get
        Return _t_pact
      End Get
      Set(ByVal value As String)
        _t_pact = value
      End Set
    End Property
    Public Property t_bohd() As String
      Get
        Return _t_bohd
      End Get
      Set(ByVal value As String)
        _t_bohd = value
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
    Public Property t_actp() As Int32
      Get
        Return _t_actp
      End Get
      Set(ByVal value As Int32)
        _t_actp = value
      End Set
    End Property
    Public Property t_schd() As Int32
      Get
        Return _t_schd
      End Get
      Set(ByVal value As Int32)
        _t_schd = value
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
    Public Property ttcmcs0522001_t_dsca() As String
      Get
        Return _ttcmcs0522001_t_dsca
      End Get
      Set(ByVal value As String)
        _ttcmcs0522001_t_dsca = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _t_desc.ToString.PadRight(256, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_cprj & "|" & _t_cact
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
    Public Class PKctPActivity
      Private _t_cprj As String = ""
      Private _t_cact As String = ""
      Public Property t_cprj() As String
        Get
          Return _t_cprj
        End Get
        Set(ByVal value As String)
          _t_cprj = value
        End Set
      End Property
      Public Property t_cact() As String
        Get
          Return _t_cact
        End Get
        Set(ByVal value As String)
          _t_cact = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ttpisg220200_t_cprj() As SIS.CT.ctProjects
      Get
        If _FK_ttpisg220200_t_cprj Is Nothing Then
          _FK_ttpisg220200_t_cprj = SIS.CT.ctProjects.ctProjectsGetByID(_t_cprj)
        End If
        Return _FK_ttpisg220200_t_cprj
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPActivitySelectList(ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPActivitySelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.ctPActivity(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPActivityGetNewRecord() As SIS.CT.ctPActivity
      Return New SIS.CT.ctPActivity()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPActivityGetByID(ByVal t_cprj As String, ByVal t_cact As String) As SIS.CT.ctPActivity
      Dim Results As SIS.CT.ctPActivity = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPActivitySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, t_cprj.ToString.Length, t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cact", SqlDbType.VarChar, t_cact.ToString.Length, t_cact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.ctPActivity(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPActivitySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String, ByVal t_cact As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spctPActivitySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spctPActivitySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.VarChar, 9, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cact", SqlDbType.VarChar, 30, IIf(t_cact Is Nothing, String.Empty, t_cact))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.ctPActivity(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ctPActivitySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String, ByVal t_cact As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ctPActivityGetByID(ByVal t_cprj As String, ByVal t_cact As String, ByVal Filter_t_cprj As String, ByVal Filter_t_cact As String) As SIS.CT.ctPActivity
      Return ctPActivityGetByID(t_cprj, t_cact)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function ctPActivityUpdate(ByVal Record As SIS.CT.ctPActivity) As SIS.CT.ctPActivity
      Dim _Rec As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(Record.t_cprj, Record.t_cact)
      With _Rec
        .t_acty = Record.t_acty
        .t_amod = Record.t_amod
        .t_dept = Record.t_dept
        .t_desc = Record.t_desc
        .t_exdo = Record.t_exdo
        .t_outl = Record.t_outl
        .t_pcbs = Record.t_pcbs
        .t_sub1 = Record.t_sub1
        .t_sub2 = Record.t_sub2
        .t_sub3 = Record.t_sub3
        .t_sub4 = Record.t_sub4
        .t_vali = Record.t_vali
        .t_cpgv = Record.t_cpgv
        .t_pcod = Record.t_pcod
        .t_sdst = Record.t_sdst
        .t_sdfn = Record.t_sdfn
        .t_acsd = Record.t_acsd
        .t_acfn = Record.t_acfn
        '.t_iref = Record.t_iref
        .t_otsd = Record.t_otsd
        .t_oted = Record.t_oted
        .t_rmks = Record.t_rmks
        .t_gps3 = Record.t_gps3
        .t_gps4 = Record.t_gps4
        .t_gps2 = Record.t_gps2
        .t_pred = Record.t_pred
        .t_gps1 = Record.t_gps1
        .t_succ = Record.t_succ
        .t_dura = Record.t_dura
        .t_bcod = Record.t_bcod
        .t_pact = Record.t_pact
        .t_bohd = Record.t_bohd
        .t_Refcntd = Record.t_Refcntd
        .t_actp = Record.t_actp
        .t_schd = Record.t_schd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.CT.ctPActivity.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.CT.ctPActivity) As SIS.CT.ctPActivity
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPActivityUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cact", SqlDbType.VarChar, 31, Record.t_cact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acty", SqlDbType.VarChar, 10, Record.t_acty)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_amod", SqlDbType.VarChar, 21, Record.t_amod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dept", SqlDbType.VarChar, 10, Record.t_dept)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_desc", SqlDbType.VarChar, 257, Record.t_desc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exdo", SqlDbType.Int, 11, Record.t_exdo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_outl", SqlDbType.Int, 11, Record.t_outl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pcbs", SqlDbType.VarChar, 21, Record.t_pcbs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sub1", SqlDbType.VarChar, 151, Record.t_sub1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sub2", SqlDbType.VarChar, 151, Record.t_sub2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sub3", SqlDbType.VarChar, 151, Record.t_sub3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sub4", SqlDbType.VarChar, 151, Record.t_sub4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vali", SqlDbType.Int, 11, Record.t_vali)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cpgv", SqlDbType.Float, 16, Record.t_cpgv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cact", SqlDbType.VarChar, 31, Record.t_cact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pcod", SqlDbType.VarChar, 10, Record.t_pcod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdst", SqlDbType.DateTime, 21, IIf(Record.t_sdst = "", "01/01/1970", Record.t_sdst))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdfn", SqlDbType.DateTime, 21, IIf(Record.t_sdfn = "", "01/01/1970", Record.t_sdfn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acsd", SqlDbType.DateTime, 21, IIf(Record.t_acsd = "", "01/01/1970", Record.t_acsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acfn", SqlDbType.DateTime, 21, IIf(Record.t_acfn = "", "01/01/1970", Record.t_acfn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_otsd", SqlDbType.DateTime, 21, IIf(Record.t_otsd = "", "01/01/1970", Record.t_otsd))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_oted", SqlDbType.DateTime, 21, IIf(Record.t_oted = "", "01/01/1970", Record.t_oted))
          'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.VarChar, 51, Record.t_iref)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rmks", SqlDbType.VarChar, 501, Record.t_rmks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps3", SqlDbType.VarChar, 101, Record.t_gps3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps4", SqlDbType.VarChar, 101, Record.t_gps4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps2", SqlDbType.VarChar, 101, Record.t_gps2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pred", SqlDbType.VarChar, 201, Record.t_pred)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gps1", SqlDbType.VarChar, 101, Record.t_gps1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_succ", SqlDbType.VarChar, 201, Record.t_succ)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dura", SqlDbType.Int, 11, Record.t_dura)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bcod", SqlDbType.VarChar, 10, Record.t_bcod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pact", SqlDbType.VarChar, 31, Record.t_pact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bohd", SqlDbType.VarChar, 21, Record.t_bohd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_actp", SqlDbType.Int, 11, Record.t_actp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_schd", SqlDbType.Int, 11, Record.t_schd)
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
    '    Autocomplete Method
    Public Shared Function SelectctPActivityAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spctPActivityAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(256, " "), "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.CT.ctPActivity = New SIS.CT.ctPActivity(Reader)
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
