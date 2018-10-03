Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DMISG
  <DataObject()> _
  Partial Public Class dmisg121200
    Private Shared _RecordCount As Integer
    Public Property t_wfst As Integer = 0
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_cprj As String = ""
    Private _t_dsca As String = ""
    Private _t_aldo As String = ""
    Private _t_alre As String = ""
    Private _t_cspa As String = ""
    Private _t_type As String = ""
    Private _t_resp As String = ""
    Private _t_eunt As String = ""
    Private _t_size As Int32 = 0
    Private _t_orgn As String = ""
    Private _t_subm As Int32 = 0
    Private _t_intr As Int32 = 0
    Private _t_prod As Int32 = 0
    Private _t_erec As Int32 = 0
    Private _t_info As Int32 = 0
    Private _t_remk As String = ""
    Private _t_pldt As String = ""
    Private _t_rele As Int32 = 0
    Private _t_acdt As String = ""
    Private _t_vend As Int32 = 0
    Private _t_bpid As String = ""
    Private _t_revd As Int32 = 0
    Private _t_redt As String = ""
    Private _t_logn As String = ""
    Private _t_verk As String = ""
    Private _t_extn As Int32 = 0
    Private _t_ofbp As String = ""
    Private _t_nama As String = ""
    Private _t_eogn As String = ""
    Private _t_exdt As String = ""
    Private _t_exrk As String = ""
    Private _t_cler As Int32 = 0
    Private _t_bloc As Int32 = 0
    Private _t_appr As Int32 = 0
    Private _t_link As Int32 = 0
    Private _t_tran As String = ""
    Private _t_soft As String = ""
    Private _t_test As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_imby As String = ""
    Private _t_imdt As String = ""
    Private _t_emno As String = ""
    Private _t_nhrs As Single = 0
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
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
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
    Public Property t_dsca() As String
      Get
        Return _t_dsca
      End Get
      Set(ByVal value As String)
        _t_dsca = value
      End Set
    End Property
    Public Property t_aldo() As String
      Get
        Return _t_aldo
      End Get
      Set(ByVal value As String)
        _t_aldo = value
      End Set
    End Property
    Public Property t_alre() As String
      Get
        Return _t_alre
      End Get
      Set(ByVal value As String)
        _t_alre = value
      End Set
    End Property
    Public Property t_cspa() As String
      Get
        Return _t_cspa
      End Get
      Set(ByVal value As String)
        _t_cspa = value
      End Set
    End Property
    Public Property t_type() As String
      Get
        Return _t_type
      End Get
      Set(ByVal value As String)
        _t_type = value
      End Set
    End Property
    Public Property t_resp() As String
      Get
        Return _t_resp
      End Get
      Set(ByVal value As String)
        _t_resp = value
      End Set
    End Property
    Public Property t_eunt() As String
      Get
        Return _t_eunt
      End Get
      Set(ByVal value As String)
        _t_eunt = value
      End Set
    End Property
    Public Property t_size() As Int32
      Get
        Return _t_size
      End Get
      Set(ByVal value As Int32)
        _t_size = value
      End Set
    End Property
    Public Property t_orgn() As String
      Get
        Return _t_orgn
      End Get
      Set(ByVal value As String)
        _t_orgn = value
      End Set
    End Property
    Public Property t_subm() As Int32
      Get
        Return _t_subm
      End Get
      Set(ByVal value As Int32)
        _t_subm = value
      End Set
    End Property
    Public Property t_intr() As Int32
      Get
        Return _t_intr
      End Get
      Set(ByVal value As Int32)
        _t_intr = value
      End Set
    End Property
    Public Property t_prod() As Int32
      Get
        Return _t_prod
      End Get
      Set(ByVal value As Int32)
        _t_prod = value
      End Set
    End Property
    Public Property t_erec() As Int32
      Get
        Return _t_erec
      End Get
      Set(ByVal value As Int32)
        _t_erec = value
      End Set
    End Property
    Public Property t_info() As Int32
      Get
        Return _t_info
      End Get
      Set(ByVal value As Int32)
        _t_info = value
      End Set
    End Property
    Public Property t_remk() As String
      Get
        Return _t_remk
      End Get
      Set(ByVal value As String)
        _t_remk = value
      End Set
    End Property
    Public Property t_pldt() As String
      Get
        If Not _t_pldt = String.Empty Then
          Return Convert.ToDateTime(_t_pldt).ToString("dd/MM/yyyy")
        End If
        Return _t_pldt
      End Get
      Set(ByVal value As String)
         _t_pldt = value
      End Set
    End Property
    Public Property t_rele() As Int32
      Get
        Return _t_rele
      End Get
      Set(ByVal value As Int32)
        _t_rele = value
      End Set
    End Property
    Public Property t_acdt() As String
      Get
        If Not _t_acdt = String.Empty Then
          Return Convert.ToDateTime(_t_acdt).ToString("dd/MM/yyyy")
        End If
        Return _t_acdt
      End Get
      Set(ByVal value As String)
         _t_acdt = value
      End Set
    End Property
    Public Property t_vend() As Int32
      Get
        Return _t_vend
      End Get
      Set(ByVal value As Int32)
        _t_vend = value
      End Set
    End Property
    Public Property t_bpid() As String
      Get
        Return _t_bpid
      End Get
      Set(ByVal value As String)
        _t_bpid = value
      End Set
    End Property
    Public Property t_revd() As Int32
      Get
        Return _t_revd
      End Get
      Set(ByVal value As Int32)
        _t_revd = value
      End Set
    End Property
    Public Property t_redt() As String
      Get
        If Not _t_redt = String.Empty Then
          Return Convert.ToDateTime(_t_redt).ToString("dd/MM/yyyy")
        End If
        Return _t_redt
      End Get
      Set(ByVal value As String)
         _t_redt = value
      End Set
    End Property
    Public Property t_logn() As String
      Get
        Return _t_logn
      End Get
      Set(ByVal value As String)
        _t_logn = value
      End Set
    End Property
    Public Property t_verk() As String
      Get
        Return _t_verk
      End Get
      Set(ByVal value As String)
        _t_verk = value
      End Set
    End Property
    Public Property t_extn() As Int32
      Get
        Return _t_extn
      End Get
      Set(ByVal value As Int32)
        _t_extn = value
      End Set
    End Property
    Public Property t_ofbp() As String
      Get
        Return _t_ofbp
      End Get
      Set(ByVal value As String)
        _t_ofbp = value
      End Set
    End Property
    Public Property t_nama() As String
      Get
        Return _t_nama
      End Get
      Set(ByVal value As String)
        _t_nama = value
      End Set
    End Property
    Public Property t_eogn() As String
      Get
        Return _t_eogn
      End Get
      Set(ByVal value As String)
        _t_eogn = value
      End Set
    End Property
    Public Property t_exdt() As String
      Get
        If Not _t_exdt = String.Empty Then
          Return Convert.ToDateTime(_t_exdt).ToString("dd/MM/yyyy")
        End If
        Return _t_exdt
      End Get
      Set(ByVal value As String)
         _t_exdt = value
      End Set
    End Property
    Public Property t_exrk() As String
      Get
        Return _t_exrk
      End Get
      Set(ByVal value As String)
        _t_exrk = value
      End Set
    End Property
    Public Property t_cler() As Int32
      Get
        Return _t_cler
      End Get
      Set(ByVal value As Int32)
        _t_cler = value
      End Set
    End Property
    Public Property t_bloc() As Int32
      Get
        Return _t_bloc
      End Get
      Set(ByVal value As Int32)
        _t_bloc = value
      End Set
    End Property
    Public Property t_appr() As Int32
      Get
        Return _t_appr
      End Get
      Set(ByVal value As Int32)
        _t_appr = value
      End Set
    End Property
    Public Property t_link() As Int32
      Get
        Return _t_link
      End Get
      Set(ByVal value As Int32)
        _t_link = value
      End Set
    End Property
    Public Property t_tran() As String
      Get
        Return _t_tran
      End Get
      Set(ByVal value As String)
        _t_tran = value
      End Set
    End Property
    Public Property t_soft() As String
      Get
        Return _t_soft
      End Get
      Set(ByVal value As String)
        _t_soft = value
      End Set
    End Property
    Public Property t_test() As Int32
      Get
        Return _t_test
      End Get
      Set(ByVal value As Int32)
        _t_test = value
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
    Public Property t_imby() As String
      Get
        Return _t_imby
      End Get
      Set(ByVal value As String)
        _t_imby = value
      End Set
    End Property
    Public Property t_imdt() As String
      Get
        If Not _t_imdt = String.Empty Then
          Return Convert.ToDateTime(_t_imdt).ToString("dd/MM/yyyy")
        End If
        Return _t_imdt
      End Get
      Set(ByVal value As String)
         _t_imdt = value
      End Set
    End Property
    Public Property t_emno() As String
      Get
        Return _t_emno
      End Get
      Set(ByVal value As String)
        _t_emno = value
      End Set
    End Property
    Public Property t_nhrs() As Single
      Get
        Return _t_nhrs
      End Get
      Set(ByVal value As Single)
        _t_nhrs = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_docn & "|" & _t_revn
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
    Public Class PKdmisg121200
      Private _t_docn As String = ""
      Private _t_revn As String = ""
      Public Property t_docn() As String
        Get
          Return _t_docn
        End Get
        Set(ByVal value As String)
          _t_docn = value
        End Set
      End Property
      Public Property t_revn() As String
        Get
          Return _t_revn
        End Get
        Set(ByVal value As String)
          _t_revn = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dmisg121200GetNewRecord() As SIS.DMISG.dmisg121200
      Return New SIS.DMISG.dmisg121200()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dmisg121200GetByID(ByVal t_docn As String, ByVal t_revn As String) As SIS.DMISG.dmisg121200
      Dim Results As SIS.DMISG.dmisg121200 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg121200SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,t_docn.ToString.Length, t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.DMISG.dmisg121200(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dmisg121200SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.DMISG.dmisg121200)
      Dim Results As List(Of SIS.DMISG.dmisg121200) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spdmisg121200SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spdmisg121200SelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DMISG.dmisg121200)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DMISG.dmisg121200(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function dmisg121200SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function dmisg121200Insert(ByVal Record As SIS.DMISG.dmisg121200) As SIS.DMISG.dmisg121200
      Dim _Rec As SIS.DMISG.dmisg121200 = SIS.DMISG.dmisg121200.dmisg121200GetNewRecord()
      With _Rec
        .t_docn = Record.t_docn
        .t_revn = Record.t_revn
        .t_cprj = Record.t_cprj
        .t_dsca = Record.t_dsca
        .t_aldo = Record.t_aldo
        .t_alre = Record.t_alre
        .t_cspa = Record.t_cspa
        .t_type = Record.t_type
        .t_resp = Record.t_resp
        .t_eunt = Record.t_eunt
        .t_size = Record.t_size
        .t_orgn = Record.t_orgn
        .t_subm = Record.t_subm
        .t_intr = Record.t_intr
        .t_prod = Record.t_prod
        .t_erec = Record.t_erec
        .t_info = Record.t_info
        .t_remk = Record.t_remk
        .t_pldt = Record.t_pldt
        .t_rele = Record.t_rele
        .t_acdt = Record.t_acdt
        .t_vend = Record.t_vend
        .t_bpid = Record.t_bpid
        .t_revd = Record.t_revd
        .t_redt = Record.t_redt
        .t_logn = Record.t_logn
        .t_verk = Record.t_verk
        .t_extn = Record.t_extn
        .t_ofbp = Record.t_ofbp
        .t_nama = Record.t_nama
        .t_eogn = Record.t_eogn
        .t_exdt = Record.t_exdt
        .t_exrk = Record.t_exrk
        .t_cler = Record.t_cler
        .t_bloc = Record.t_bloc
        .t_appr = Record.t_appr
        .t_link = Record.t_link
        .t_tran = Record.t_tran
        .t_soft = Record.t_soft
        .t_test = Record.t_test
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_imby = Record.t_imby
        .t_imdt = Record.t_imdt
        .t_emno = Record.t_emno
        .t_nhrs = Record.t_nhrs
      End With
      Return SIS.DMISG.dmisg121200.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.DMISG.dmisg121200) As SIS.DMISG.dmisg121200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg121200Insert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca",SqlDbType.VarChar,101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aldo",SqlDbType.VarChar,33, Record.t_aldo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_alre",SqlDbType.VarChar,21, Record.t_alre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type",SqlDbType.VarChar,8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp",SqlDbType.VarChar,4, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt",SqlDbType.VarChar,7, Record.t_eunt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size",SqlDbType.Int,11, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orgn",SqlDbType.VarChar,4, Record.t_orgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm",SqlDbType.Int,11, Record.t_subm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_intr",SqlDbType.Int,11, Record.t_intr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod",SqlDbType.Int,11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec",SqlDbType.Int,11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info",SqlDbType.Int,11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk",SqlDbType.VarChar,101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pldt",SqlDbType.DateTime,21, Record.t_pldt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rele",SqlDbType.Int,11, Record.t_rele)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acdt",SqlDbType.DateTime,21, Record.t_acdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vend",SqlDbType.Int,11, Record.t_vend)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid",SqlDbType.VarChar,10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revd",SqlDbType.Int,11, Record.t_revd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_redt",SqlDbType.DateTime,21, Record.t_redt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_logn",SqlDbType.VarChar,17, Record.t_logn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_verk",SqlDbType.VarChar,101, Record.t_verk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_extn",SqlDbType.Int,11, Record.t_extn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbp",SqlDbType.VarChar,10, Record.t_ofbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama",SqlDbType.VarChar,36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eogn",SqlDbType.VarChar,17, Record.t_eogn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exdt",SqlDbType.DateTime,21, Record.t_exdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exrk",SqlDbType.VarChar,101, Record.t_exrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cler",SqlDbType.Int,11, Record.t_cler)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bloc",SqlDbType.Int,11, Record.t_bloc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr",SqlDbType.Int,11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link",SqlDbType.Int,11, Record.t_link)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tran",SqlDbType.VarChar,10, Record.t_tran)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_soft",SqlDbType.VarChar,51, Record.t_soft)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_test",SqlDbType.Int,11, Record.t_test)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_imby",SqlDbType.VarChar,17, Record.t_imby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_imdt",SqlDbType.DateTime,21, Record.t_imdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_emno",SqlDbType.VarChar,10, Record.t_emno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nhrs",SqlDbType.Real,8, Record.t_nhrs)
          Cmd.Parameters.Add("@Return_t_docn", SqlDbType.VarChar, 33)
          Cmd.Parameters("@Return_t_docn").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_revn", SqlDbType.VarChar, 33)
          Cmd.Parameters("@Return_t_revn").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_docn = Cmd.Parameters("@Return_t_docn").Value
          Record.t_revn = Cmd.Parameters("@Return_t_revn").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function dmisg121200Update(ByVal Record As SIS.DMISG.dmisg121200) As SIS.DMISG.dmisg121200
      Dim _Rec As SIS.DMISG.dmisg121200 = SIS.DMISG.dmisg121200.dmisg121200GetByID(Record.t_docn, Record.t_revn)
      With _Rec
        .t_cprj = Record.t_cprj
        .t_dsca = Record.t_dsca
        .t_aldo = Record.t_aldo
        .t_alre = Record.t_alre
        .t_cspa = Record.t_cspa
        .t_type = Record.t_type
        .t_resp = Record.t_resp
        .t_eunt = Record.t_eunt
        .t_size = Record.t_size
        .t_orgn = Record.t_orgn
        .t_subm = Record.t_subm
        .t_intr = Record.t_intr
        .t_prod = Record.t_prod
        .t_erec = Record.t_erec
        .t_info = Record.t_info
        .t_remk = Record.t_remk
        .t_pldt = Record.t_pldt
        .t_rele = Record.t_rele
        .t_acdt = Record.t_acdt
        .t_vend = Record.t_vend
        .t_bpid = Record.t_bpid
        .t_revd = Record.t_revd
        .t_redt = Record.t_redt
        .t_logn = Record.t_logn
        .t_verk = Record.t_verk
        .t_extn = Record.t_extn
        .t_ofbp = Record.t_ofbp
        .t_nama = Record.t_nama
        .t_eogn = Record.t_eogn
        .t_exdt = Record.t_exdt
        .t_exrk = Record.t_exrk
        .t_cler = Record.t_cler
        .t_bloc = Record.t_bloc
        .t_appr = Record.t_appr
        .t_link = Record.t_link
        .t_tran = Record.t_tran
        .t_soft = Record.t_soft
        .t_test = Record.t_test
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_imby = Record.t_imby
        .t_imdt = Record.t_imdt
        .t_emno = Record.t_emno
        .t_nhrs = Record.t_nhrs
      End With
      Return SIS.DMISG.dmisg121200.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.DMISG.dmisg121200) As SIS.DMISG.dmisg121200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg121200Update"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca",SqlDbType.VarChar,101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aldo",SqlDbType.VarChar,33, Record.t_aldo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_alre",SqlDbType.VarChar,21, Record.t_alre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type",SqlDbType.VarChar,8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp",SqlDbType.VarChar,4, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt",SqlDbType.VarChar,7, Record.t_eunt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size",SqlDbType.Int,11, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orgn",SqlDbType.VarChar,4, Record.t_orgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm",SqlDbType.Int,11, Record.t_subm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_intr",SqlDbType.Int,11, Record.t_intr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod",SqlDbType.Int,11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec",SqlDbType.Int,11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info",SqlDbType.Int,11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk",SqlDbType.VarChar,101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pldt",SqlDbType.DateTime,21, Record.t_pldt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rele",SqlDbType.Int,11, Record.t_rele)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acdt",SqlDbType.DateTime,21, Record.t_acdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vend",SqlDbType.Int,11, Record.t_vend)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid",SqlDbType.VarChar,10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revd",SqlDbType.Int,11, Record.t_revd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_redt",SqlDbType.DateTime,21, Record.t_redt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_logn",SqlDbType.VarChar,17, Record.t_logn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_verk",SqlDbType.VarChar,101, Record.t_verk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_extn",SqlDbType.Int,11, Record.t_extn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbp",SqlDbType.VarChar,10, Record.t_ofbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama",SqlDbType.VarChar,36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eogn",SqlDbType.VarChar,17, Record.t_eogn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exdt",SqlDbType.DateTime,21, Record.t_exdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exrk",SqlDbType.VarChar,101, Record.t_exrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cler",SqlDbType.Int,11, Record.t_cler)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bloc",SqlDbType.Int,11, Record.t_bloc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr",SqlDbType.Int,11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link",SqlDbType.Int,11, Record.t_link)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tran",SqlDbType.VarChar,10, Record.t_tran)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_soft",SqlDbType.VarChar,51, Record.t_soft)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_test",SqlDbType.Int,11, Record.t_test)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_imby",SqlDbType.VarChar,17, Record.t_imby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_imdt",SqlDbType.DateTime,21, Record.t_imdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_emno",SqlDbType.VarChar,10, Record.t_emno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nhrs",SqlDbType.Real,8, Record.t_nhrs)
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
    Public Shared Function dmisg121200Delete(ByVal Record As SIS.DMISG.dmisg121200) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg121200Delete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn",SqlDbType.VarChar,Record.t_docn.ToString.Length, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,Record.t_revn.ToString.Length, Record.t_revn)
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
