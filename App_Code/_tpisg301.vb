Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class tpisg301
    Private Shared _RecordCount As Integer
    Public Property t_cdra As Double = 0
    Public Property t_cdsa As Double = 0
    Private _t_user As String = ""
    Private _t_ccod As String = ""
    Private _t_ccno As String = ""
    Private _t_cust As String = ""
    Private _t_nodi As String = ""
    Private _t_lddn As String = ""
    Private _t_prod As String = ""
    Private _t_zdat As String = ""
    Private _t_ccdt As String = ""
    Private _t_orvl As Double = 0
    Private _t_exrt As Double = 0
    Private _t_ordl As Double = 0
    Private _t_lddl As String = ""
    Private _t_blbd As Double = 0
    Private _t_blal As Double = 0
    Private _t_blvr As Double = 0
    Private _t_cinb As Double = 0
    Private _t_cino As Double = 0
    Private _t_cina As Double = 0
    Private _t_cinv As Double = 0
    Private _t_cotb As Double = 0
    Private _t_coto As Double = 0
    Private _t_cota As Double = 0
    Private _t_cotv As Double = 0
    Private _t_cntb As Double = 0
    Private _t_cnto As Double = 0
    Private _t_cnta As Double = 0
    Private _t_cntv As Double = 0
    Private _t_rsnd As Double = 0
    Private _t_rsum As Double = 0
    Private _t_rsbm As Double = 0
    Private _t_rsgy As Double = 0
    Private _t_rsmy As Double = 0
    Private _t_rsur As Double = 0
    Private _t_rstl As Double = 0
    Private _t_rcnd As Double = 0
    Private _t_rcum As Double = 0
    Private _t_rcbm As Double = 0
    Private _t_rcgy As Double = 0
    Private _t_rcmy As Double = 0
    Private _t_rcur As Double = 0
    Private _t_rctl As Double = 0
    Private _t_rend As Double = 0
    Private _t_reum As Double = 0
    Private _t_rebm As Double = 0
    Private _t_regy As Double = 0
    Private _t_remy As Double = 0
    Private _t_reur As Double = 0
    Private _t_retl As Double = 0
    Private _t_rtnd As Double = 0
    Private _t_rtum As Double = 0
    Private _t_rtbm As Double = 0
    Private _t_rtgy As Double = 0
    Private _t_rtmy As Double = 0
    Private _t_rtur As Double = 0
    Private _t_rttl As Double = 0
    Private _t_obga As Double = 0
    Private _t_obgc As Double = 0
    Private _t_obgp As Double = 0
    Private _t_obgt As Double = 0
    Private _t_cder As Double = 0
    Private _t_cdsr As Double = 0
    Private _t_cddr As Double = 0
    Private _t_cdds As Double = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_updt As String = ""
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_ccod() As String
      Get
        Return _t_ccod
      End Get
      Set(ByVal value As String)
        _t_ccod = value
      End Set
    End Property
    Public Property t_ccno() As String
      Get
        Return _t_ccno
      End Get
      Set(ByVal value As String)
        _t_ccno = value
      End Set
    End Property
    Public Property t_cust() As String
      Get
        Return _t_cust
      End Get
      Set(ByVal value As String)
        _t_cust = value
      End Set
    End Property
    Public Property t_nodi() As String
      Get
        Return _t_nodi
      End Get
      Set(ByVal value As String)
        _t_nodi = value
      End Set
    End Property
    Public Property t_lddn() As String
      Get
        Return _t_lddn
      End Get
      Set(ByVal value As String)
        _t_lddn = value
      End Set
    End Property
    Public Property t_prod() As String
      Get
        Return _t_prod
      End Get
      Set(ByVal value As String)
        _t_prod = value
      End Set
    End Property
    Public Property t_zdat() As String
      Get
        If Not _t_zdat = String.Empty Then
          Return Convert.ToDateTime(_t_zdat).ToString("dd/MM/yyyy")
        End If
        Return _t_zdat
      End Get
      Set(ByVal value As String)
         _t_zdat = value
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
    Public Property t_orvl() As Double
      Get
        Return _t_orvl
      End Get
      Set(ByVal value As Double)
        _t_orvl = value
      End Set
    End Property
    Public Property t_exrt() As Double
      Get
        Return _t_exrt
      End Get
      Set(ByVal value As Double)
        _t_exrt = value
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
    Public Property t_lddl() As String
      Get
        Return _t_lddl
      End Get
      Set(ByVal value As String)
        _t_lddl = value
      End Set
    End Property
    Public Property t_blbd() As Double
      Get
        Return _t_blbd
      End Get
      Set(ByVal value As Double)
        _t_blbd = value
      End Set
    End Property
    Public Property t_blal() As Double
      Get
        Return _t_blal
      End Get
      Set(ByVal value As Double)
        _t_blal = value
      End Set
    End Property
    Public Property t_blvr() As Double
      Get
        Return _t_blvr
      End Get
      Set(ByVal value As Double)
        _t_blvr = value
      End Set
    End Property
    Public Property t_cinb() As Double
      Get
        Return _t_cinb
      End Get
      Set(ByVal value As Double)
        _t_cinb = value
      End Set
    End Property
    Public Property t_cino() As Double
      Get
        Return _t_cino
      End Get
      Set(ByVal value As Double)
        _t_cino = value
      End Set
    End Property
    Public Property t_cina() As Double
      Get
        Return _t_cina
      End Get
      Set(ByVal value As Double)
        _t_cina = value
      End Set
    End Property
    Public Property t_cinv() As Double
      Get
        Return _t_cinv
      End Get
      Set(ByVal value As Double)
        _t_cinv = value
      End Set
    End Property
    Public Property t_cotb() As Double
      Get
        Return _t_cotb
      End Get
      Set(ByVal value As Double)
        _t_cotb = value
      End Set
    End Property
    Public Property t_coto() As Double
      Get
        Return _t_coto
      End Get
      Set(ByVal value As Double)
        _t_coto = value
      End Set
    End Property
    Public Property t_cota() As Double
      Get
        Return _t_cota
      End Get
      Set(ByVal value As Double)
        _t_cota = value
      End Set
    End Property
    Public Property t_cotv() As Double
      Get
        Return _t_cotv
      End Get
      Set(ByVal value As Double)
        _t_cotv = value
      End Set
    End Property
    Public Property t_cntb() As Double
      Get
        Return _t_cntb
      End Get
      Set(ByVal value As Double)
        _t_cntb = value
      End Set
    End Property
    Public Property t_cnto() As Double
      Get
        Return _t_cnto
      End Get
      Set(ByVal value As Double)
        _t_cnto = value
      End Set
    End Property
    Public Property t_cnta() As Double
      Get
        Return _t_cnta
      End Get
      Set(ByVal value As Double)
        _t_cnta = value
      End Set
    End Property
    Public Property t_cntv() As Double
      Get
        Return _t_cntv
      End Get
      Set(ByVal value As Double)
        _t_cntv = value
      End Set
    End Property
    Public Property t_rsnd() As Double
      Get
        Return _t_rsnd
      End Get
      Set(ByVal value As Double)
        _t_rsnd = value
      End Set
    End Property
    Public Property t_rsum() As Double
      Get
        Return _t_rsum
      End Get
      Set(ByVal value As Double)
        _t_rsum = value
      End Set
    End Property
    Public Property t_rsbm() As Double
      Get
        Return _t_rsbm
      End Get
      Set(ByVal value As Double)
        _t_rsbm = value
      End Set
    End Property
    Public Property t_rsgy() As Double
      Get
        Return _t_rsgy
      End Get
      Set(ByVal value As Double)
        _t_rsgy = value
      End Set
    End Property
    Public Property t_rsmy() As Double
      Get
        Return _t_rsmy
      End Get
      Set(ByVal value As Double)
        _t_rsmy = value
      End Set
    End Property
    Public Property t_rsur() As Double
      Get
        Return _t_rsur
      End Get
      Set(ByVal value As Double)
        _t_rsur = value
      End Set
    End Property
    Public Property t_rstl() As Double
      Get
        Return _t_rstl
      End Get
      Set(ByVal value As Double)
        _t_rstl = value
      End Set
    End Property
    Public Property t_rcnd() As Double
      Get
        Return _t_rcnd
      End Get
      Set(ByVal value As Double)
        _t_rcnd = value
      End Set
    End Property
    Public Property t_rcum() As Double
      Get
        Return _t_rcum
      End Get
      Set(ByVal value As Double)
        _t_rcum = value
      End Set
    End Property
    Public Property t_rcbm() As Double
      Get
        Return _t_rcbm
      End Get
      Set(ByVal value As Double)
        _t_rcbm = value
      End Set
    End Property
    Public Property t_rcgy() As Double
      Get
        Return _t_rcgy
      End Get
      Set(ByVal value As Double)
        _t_rcgy = value
      End Set
    End Property
    Public Property t_rcmy() As Double
      Get
        Return _t_rcmy
      End Get
      Set(ByVal value As Double)
        _t_rcmy = value
      End Set
    End Property
    Public Property t_rcur() As Double
      Get
        Return _t_rcur
      End Get
      Set(ByVal value As Double)
        _t_rcur = value
      End Set
    End Property
    Public Property t_rctl() As Double
      Get
        Return _t_rctl
      End Get
      Set(ByVal value As Double)
        _t_rctl = value
      End Set
    End Property
    Public Property t_rend() As Double
      Get
        Return _t_rend
      End Get
      Set(ByVal value As Double)
        _t_rend = value
      End Set
    End Property
    Public Property t_reum() As Double
      Get
        Return _t_reum
      End Get
      Set(ByVal value As Double)
        _t_reum = value
      End Set
    End Property
    Public Property t_rebm() As Double
      Get
        Return _t_rebm
      End Get
      Set(ByVal value As Double)
        _t_rebm = value
      End Set
    End Property
    Public Property t_regy() As Double
      Get
        Return _t_regy
      End Get
      Set(ByVal value As Double)
        _t_regy = value
      End Set
    End Property
    Public Property t_remy() As Double
      Get
        Return _t_remy
      End Get
      Set(ByVal value As Double)
        _t_remy = value
      End Set
    End Property
    Public Property t_reur() As Double
      Get
        Return _t_reur
      End Get
      Set(ByVal value As Double)
        _t_reur = value
      End Set
    End Property
    Public Property t_retl() As Double
      Get
        Return _t_retl
      End Get
      Set(ByVal value As Double)
        _t_retl = value
      End Set
    End Property
    Public Property t_rtnd() As Double
      Get
        Return _t_rtnd
      End Get
      Set(ByVal value As Double)
        _t_rtnd = value
      End Set
    End Property
    Public Property t_rtum() As Double
      Get
        Return _t_rtum
      End Get
      Set(ByVal value As Double)
        _t_rtum = value
      End Set
    End Property
    Public Property t_rtbm() As Double
      Get
        Return _t_rtbm
      End Get
      Set(ByVal value As Double)
        _t_rtbm = value
      End Set
    End Property
    Public Property t_rtgy() As Double
      Get
        Return _t_rtgy
      End Get
      Set(ByVal value As Double)
        _t_rtgy = value
      End Set
    End Property
    Public Property t_rtmy() As Double
      Get
        Return _t_rtmy
      End Get
      Set(ByVal value As Double)
        _t_rtmy = value
      End Set
    End Property
    Public Property t_rtur() As Double
      Get
        Return _t_rtur
      End Get
      Set(ByVal value As Double)
        _t_rtur = value
      End Set
    End Property
    Public Property t_rttl() As Double
      Get
        Return _t_rttl
      End Get
      Set(ByVal value As Double)
        _t_rttl = value
      End Set
    End Property
    Public Property t_obga() As Double
      Get
        Return _t_obga
      End Get
      Set(ByVal value As Double)
        _t_obga = value
      End Set
    End Property
    Public Property t_obgc() As Double
      Get
        Return _t_obgc
      End Get
      Set(ByVal value As Double)
        _t_obgc = value
      End Set
    End Property
    Public Property t_obgp() As Double
      Get
        Return _t_obgp
      End Get
      Set(ByVal value As Double)
        _t_obgp = value
      End Set
    End Property
    Public Property t_obgt() As Double
      Get
        Return _t_obgt
      End Get
      Set(ByVal value As Double)
        _t_obgt = value
      End Set
    End Property
    Public Property t_cder() As Double
      Get
        Return _t_cder
      End Get
      Set(ByVal value As Double)
        _t_cder = value
      End Set
    End Property
    Public Property t_cdsr() As Double
      Get
        Return _t_cdsr
      End Get
      Set(ByVal value As Double)
        _t_cdsr = value
      End Set
    End Property
    Public Property t_cddr() As Double
      Get
        Return _t_cddr
      End Get
      Set(ByVal value As Double)
        _t_cddr = value
      End Set
    End Property
    Public Property t_cdds() As Double
      Get
        Return _t_cdds
      End Get
      Set(ByVal value As Double)
        _t_cdds = value
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
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_ccod
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
    Public Class PKtpisg301
      Private _t_ccod As String = ""
      Public Property t_ccod() As String
        Get
          Return _t_ccod
        End Get
        Set(ByVal value As String)
          _t_ccod = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg301GetByID(ByVal t_ccod As String) As SIS.CT.tpisg301
      Dim Results As SIS.CT.tpisg301 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg301200 where t_ccod='" & t_ccod & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg301(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg301SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.CT.tpisg301)
      Dim Results As List(Of SIS.CT.tpisg301) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg301SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg301SelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.tpisg301)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg301(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg301SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
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
