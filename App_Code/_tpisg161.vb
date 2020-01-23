Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class tpisg161
    Private Shared _RecordCount As Integer
    Private _t_ccod As String = ""
    Private _t_revn As Int32 = 0
    Private _t_gndt As String = ""
    Private _t_rfdt As String = ""
    Private _t_nama As String = ""
    Private _t_ccdt As String = ""
    Private _t_ecdt As String = ""
    Private _t_orvl As Double = 0
    Private _t_ordl As Double = 0
    Private _t_ovfc As Double = 0
    Private _t_iovc As Double = 0
    Private _t_dovc As Double = 0
    Private _t_iovt As Double = 0
    Private _t_dovt As Double = 0
    Private _t_rvov As Double = 0
    Private _t_clmv As Double = 0
    Private _t_apvc As Double = 0
    Private _t_bcnt As Double = 0
    Private _t_cnut As Double = 0
    Private _t_ctsh As Double = 0
    Private _t_acnt As Double = 0
    Private _t_bwar As Double = 0
    Private _t_waru As Double = 0
    Private _t_wtsh As Double = 0
    Private _t_awar As Double = 0
    Private _t_cnsg As Double = 0
    Private _t_cnsu As Double = 0
    Private _t_cssh As Double = 0
    Private _t_acys As Double = 0
    Private _t_bcth As Double = 0
    Private _t_ctoh As Double = 0
    Private _t_ctoe As Double = 0
    Private _t_arcn As Int32 = 0
    Private _t_apmp As Int32 = 0
    Private _t_gusr As String = ""
    Private _t_frzd As Int32 = 0
    Private _t_frzb As String = ""
    Private _t_frzo As String = ""
    Private _t_ltsr As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Public Property t_ccod() As String
      Get
        Return _t_ccod
      End Get
      Set(ByVal value As String)
        _t_ccod = value
      End Set
    End Property
    Public Property t_revn() As Int32
      Get
        Return _t_revn
      End Get
      Set(ByVal value As Int32)
        _t_revn = value
      End Set
    End Property
    Public Property t_gndt() As String
      Get
        If Not _t_gndt = String.Empty Then
          Return Convert.ToDateTime(_t_gndt).ToString("dd/MM/yyyy")
        End If
        Return _t_gndt
      End Get
      Set(ByVal value As String)
         _t_gndt = value
      End Set
    End Property
    Public Property t_rfdt() As String
      Get
        If Not _t_rfdt = String.Empty Then
          Return Convert.ToDateTime(_t_rfdt).ToString("dd/MM/yyyy")
        End If
        Return _t_rfdt
      End Get
      Set(ByVal value As String)
         _t_rfdt = value
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
    Public Property t_ccdt() As String
      Get
        If Not _t_ccdt = String.Empty Then
          Return Convert.ToDateTime(_t_ccdt).ToString("dd/MM/yyyy")
        End If
        Return _t_ccdt
      End Get
      Set(ByVal value As String)
         _t_ccdt = value
      End Set
    End Property
    Public Property t_ecdt() As String
      Get
        If Not _t_ecdt = String.Empty Then
          Return Convert.ToDateTime(_t_ecdt).ToString("dd/MM/yyyy")
        End If
        Return _t_ecdt
      End Get
      Set(ByVal value As String)
         _t_ecdt = value
      End Set
    End Property
    Public Property t_orvl() As Double
      Get
        Return _t_orvl
      End Get
      Set(ByVal value As Double)
        _t_orvl = value
      End Set
    End Property
    Public Property t_ordl() As Double
      Get
        Return _t_ordl
      End Get
      Set(ByVal value As Double)
        _t_ordl = value
      End Set
    End Property
    Public Property t_ovfc() As Double
      Get
        Return _t_ovfc
      End Get
      Set(ByVal value As Double)
        _t_ovfc = value
      End Set
    End Property
    Public Property t_iovc() As Double
      Get
        Return _t_iovc
      End Get
      Set(ByVal value As Double)
        _t_iovc = value
      End Set
    End Property
    Public Property t_dovc() As Double
      Get
        Return _t_dovc
      End Get
      Set(ByVal value As Double)
        _t_dovc = value
      End Set
    End Property
    Public Property t_iovt() As Double
      Get
        Return _t_iovt
      End Get
      Set(ByVal value As Double)
        _t_iovt = value
      End Set
    End Property
    Public Property t_dovt() As Double
      Get
        Return _t_dovt
      End Get
      Set(ByVal value As Double)
        _t_dovt = value
      End Set
    End Property
    Public Property t_rvov() As Double
      Get
        Return _t_rvov
      End Get
      Set(ByVal value As Double)
        _t_rvov = value
      End Set
    End Property
    Public Property t_clmv() As Double
      Get
        Return _t_clmv
      End Get
      Set(ByVal value As Double)
        _t_clmv = value
      End Set
    End Property
    Public Property t_apvc() As Double
      Get
        Return _t_apvc
      End Get
      Set(ByVal value As Double)
        _t_apvc = value
      End Set
    End Property
    Public Property t_bcnt() As Double
      Get
        Return _t_bcnt
      End Get
      Set(ByVal value As Double)
        _t_bcnt = value
      End Set
    End Property
    Public Property t_cnut() As Double
      Get
        Return _t_cnut
      End Get
      Set(ByVal value As Double)
        _t_cnut = value
      End Set
    End Property
    Public Property t_ctsh() As Double
      Get
        Return _t_ctsh
      End Get
      Set(ByVal value As Double)
        _t_ctsh = value
      End Set
    End Property
    Public Property t_acnt() As Double
      Get
        Return _t_acnt
      End Get
      Set(ByVal value As Double)
        _t_acnt = value
      End Set
    End Property
    Public Property t_bwar() As Double
      Get
        Return _t_bwar
      End Get
      Set(ByVal value As Double)
        _t_bwar = value
      End Set
    End Property
    Public Property t_waru() As Double
      Get
        Return _t_waru
      End Get
      Set(ByVal value As Double)
        _t_waru = value
      End Set
    End Property
    Public Property t_wtsh() As Double
      Get
        Return _t_wtsh
      End Get
      Set(ByVal value As Double)
        _t_wtsh = value
      End Set
    End Property
    Public Property t_awar() As Double
      Get
        Return _t_awar
      End Get
      Set(ByVal value As Double)
        _t_awar = value
      End Set
    End Property
    Public Property t_cnsg() As Double
      Get
        Return _t_cnsg
      End Get
      Set(ByVal value As Double)
        _t_cnsg = value
      End Set
    End Property
    Public Property t_cnsu() As Double
      Get
        Return _t_cnsu
      End Get
      Set(ByVal value As Double)
        _t_cnsu = value
      End Set
    End Property
    Public Property t_cssh() As Double
      Get
        Return _t_cssh
      End Get
      Set(ByVal value As Double)
        _t_cssh = value
      End Set
    End Property
    Public Property t_acys() As Double
      Get
        Return _t_acys
      End Get
      Set(ByVal value As Double)
        _t_acys = value
      End Set
    End Property
    Public Property t_bcth() As Double
      Get
        Return _t_bcth
      End Get
      Set(ByVal value As Double)
        _t_bcth = value
      End Set
    End Property
    Public Property t_ctoh() As Double
      Get
        Return _t_ctoh
      End Get
      Set(ByVal value As Double)
        _t_ctoh = value
      End Set
    End Property
    Public Property t_ctoe() As Double
      Get
        Return _t_ctoe
      End Get
      Set(ByVal value As Double)
        _t_ctoe = value
      End Set
    End Property
    Public Property t_arcn() As Int32
      Get
        Return _t_arcn
      End Get
      Set(ByVal value As Int32)
        _t_arcn = value
      End Set
    End Property
    Public Property t_apmp() As Int32
      Get
        Return _t_apmp
      End Get
      Set(ByVal value As Int32)
        _t_apmp = value
      End Set
    End Property
    Public Property t_gusr() As String
      Get
        Return _t_gusr
      End Get
      Set(ByVal value As String)
        _t_gusr = value
      End Set
    End Property
    Public Property t_frzd() As Int32
      Get
        Return _t_frzd
      End Get
      Set(ByVal value As Int32)
        _t_frzd = value
      End Set
    End Property
    Public Property t_frzb() As String
      Get
        Return _t_frzb
      End Get
      Set(ByVal value As String)
        _t_frzb = value
      End Set
    End Property
    Public Property t_frzo() As String
      Get
        If Not _t_frzo = String.Empty Then
          Return Convert.ToDateTime(_t_frzo).ToString("dd/MM/yyyy")
        End If
        Return _t_frzo
      End Get
      Set(ByVal value As String)
         _t_frzo = value
      End Set
    End Property
    Public Property t_ltsr() As Int32
      Get
        Return _t_ltsr
      End Get
      Set(ByVal value As Int32)
        _t_ltsr = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_ccod & "|" & _t_revn
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
    Public Class PKtpisg161
      Private _t_ccod As String = ""
      Private _t_revn As Int32 = 0
      Public Property t_ccod() As String
        Get
          Return _t_ccod
        End Get
        Set(ByVal value As String)
          _t_ccod = value
        End Set
      End Property
      Public Property t_revn() As Int32
        Get
          Return _t_revn
        End Get
        Set(ByVal value As Int32)
          _t_revn = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg161GetNewRecord() As SIS.CT.tpisg161
      Return New SIS.CT.tpisg161()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg161GetByID(ByVal t_ccod As String, Comp As String) As SIS.CT.tpisg161
      Dim Results As SIS.CT.tpisg161 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg161" & Comp & " as aa where aa.t_ccod='" & t_ccod & "' and aa.t_revn=(select max(bb.t_revn) from ttpisg161" & Comp & " as bb where bb.t_ccod=aa.t_ccod)"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg161(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetText(ByVal textID As String, Comp As String) As String
      Dim sb As New System.Text.StringBuilder
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select convert(varchar(240), t_text) as t_text from ttttxt010" & Comp & " where t_ctxt=" & textID & " order by t_seqe"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            sb.Append(Reader("t_text"))
          End If
          Reader.Close()
        End Using
      End Using
      Return sb.ToString().Replace(Chr(10), "<br/>")
    End Function

    Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Sub New()
      'dummy
    End Sub
  End Class
End Namespace
