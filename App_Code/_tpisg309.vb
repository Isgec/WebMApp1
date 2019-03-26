Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class tpisg309
    Private Shared _RecordCount As Integer
    Private _t_user As String = ""
    Private _t_mnyr As String = ""
    Private _t_sybd As Double = 0
    Private _t_syac As Double = 0
    Private _t_syvr As Double = 0
    Private _t_erbd As Double = 0
    Private _t_erac As Double = 0
    Private _t_ervr As Double = 0
    Private _t_clbd As Double = 0
    Private _t_clac As Double = 0
    Private _t_clvr As Double = 0
    Private _t_debd As Double = 0
    Private _t_deac As Double = 0
    Private _t_devr As Double = 0
    Private _t_osbd As Double = 0
    Private _t_osac As Double = 0
    Private _t_osvr As Double = 0
    Private _t_tlbd As Double = 0
    Private _t_tlac As Double = 0
    Private _t_tlvr As Double = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_ccod As String = ""
    Private _t_updt As String = ""
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
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_mnyr() As String
      Get
        Return _t_mnyr
      End Get
      Set(ByVal value As String)
        _t_mnyr = value
      End Set
    End Property
    Public Property t_sybd() As Double
      Get
        Return _t_sybd
      End Get
      Set(ByVal value As Double)
        _t_sybd = value
      End Set
    End Property
    Public Property t_syac() As Double
      Get
        Return _t_syac
      End Get
      Set(ByVal value As Double)
        _t_syac = value
      End Set
    End Property
    Public Property t_syvr() As Double
      Get
        Return _t_syvr
      End Get
      Set(ByVal value As Double)
        _t_syvr = value
      End Set
    End Property
    Public Property t_erbd() As Double
      Get
        Return _t_erbd
      End Get
      Set(ByVal value As Double)
        _t_erbd = value
      End Set
    End Property
    Public Property t_erac() As Double
      Get
        Return _t_erac
      End Get
      Set(ByVal value As Double)
        _t_erac = value
      End Set
    End Property
    Public Property t_ervr() As Double
      Get
        Return _t_ervr
      End Get
      Set(ByVal value As Double)
        _t_ervr = value
      End Set
    End Property
    Public Property t_clbd() As Double
      Get
        Return _t_clbd
      End Get
      Set(ByVal value As Double)
        _t_clbd = value
      End Set
    End Property
    Public Property t_clac() As Double
      Get
        Return _t_clac
      End Get
      Set(ByVal value As Double)
        _t_clac = value
      End Set
    End Property
    Public Property t_clvr() As Double
      Get
        Return _t_clvr
      End Get
      Set(ByVal value As Double)
        _t_clvr = value
      End Set
    End Property
    Public Property t_debd() As Double
      Get
        Return _t_debd
      End Get
      Set(ByVal value As Double)
        _t_debd = value
      End Set
    End Property
    Public Property t_deac() As Double
      Get
        Return _t_deac
      End Get
      Set(ByVal value As Double)
        _t_deac = value
      End Set
    End Property
    Public Property t_devr() As Double
      Get
        Return _t_devr
      End Get
      Set(ByVal value As Double)
        _t_devr = value
      End Set
    End Property
    Public Property t_osbd() As Double
      Get
        Return _t_osbd
      End Get
      Set(ByVal value As Double)
        _t_osbd = value
      End Set
    End Property
    Public Property t_osac() As Double
      Get
        Return _t_osac
      End Get
      Set(ByVal value As Double)
        _t_osac = value
      End Set
    End Property
    Public Property t_osvr() As Double
      Get
        Return _t_osvr
      End Get
      Set(ByVal value As Double)
        _t_osvr = value
      End Set
    End Property
    Public Property t_tlbd() As Double
      Get
        Return _t_tlbd
      End Get
      Set(ByVal value As Double)
        _t_tlbd = value
      End Set
    End Property
    Public Property t_tlac() As Double
      Get
        Return _t_tlac
      End Get
      Set(ByVal value As Double)
        _t_tlac = value
      End Set
    End Property
    Public Property t_tlvr() As Double
      Get
        Return _t_tlvr
      End Get
      Set(ByVal value As Double)
        _t_tlvr = value
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
    Public Property t_ccod() As String
      Get
        Return _t_ccod
      End Get
      Set(ByVal value As String)
        _t_ccod = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_mnyr & "|" & _t_ccod
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
    Public Class PKtpisg309
      Private _t_mnyr As String = ""
      Private _t_ccod As String = ""
      Public Property t_mnyr() As String
        Get
          Return _t_mnyr
        End Get
        Set(ByVal value As String)
          _t_mnyr = value
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
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg309GetNewRecord() As SIS.CT.tpisg309
      Return New SIS.CT.tpisg309()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg309GetByID(ByVal t_mnyr As String, ByVal t_ccod As String) As SIS.CT.tpisg309
      Dim Results As SIS.CT.tpisg309 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg309SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_mnyr", SqlDbType.VarChar, t_mnyr.ToString.Length, t_mnyr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, t_ccod.ToString.Length, t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg309(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg309SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As List(Of SIS.CT.tpisg309)
      Dim Results As List(Of SIS.CT.tpisg309) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg309SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg309SelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_ccod", SqlDbType.VarChar, 9, IIf(t_ccod Is Nothing, String.Empty, t_ccod))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.tpisg309)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg309(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg309SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg309GetByID(ByVal t_mnyr As String, ByVal t_ccod As String, ByVal Filter_t_ccod As String) As SIS.CT.tpisg309
      Return tpisg309GetByID(t_mnyr, t_ccod)
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
