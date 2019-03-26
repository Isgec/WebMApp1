Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class tpisg304
    Private Shared _RecordCount As Integer
    Private _t_user As String = ""
    Private _t_paym As String = ""
    Private _t_samt As Double = 0
    Private _t_camt As Double = 0
    Private _t_eamt As Double = 0
    Private _t_srcd As Double = 0
    Private _t_crcd As Double = 0
    Private _t_ercd As Double = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_ccod As String = ""
    Private _t_updt As String = ""
    Private _t_srno As Int32 = 0
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
    Public Property t_paym() As String
      Get
        Return _t_paym
      End Get
      Set(ByVal value As String)
        _t_paym = value
      End Set
    End Property
    Public Property t_samt() As Double
      Get
        Return _t_samt
      End Get
      Set(ByVal value As Double)
        _t_samt = value
      End Set
    End Property
    Public Property t_camt() As Double
      Get
        Return _t_camt
      End Get
      Set(ByVal value As Double)
        _t_camt = value
      End Set
    End Property
    Public Property t_eamt() As Double
      Get
        Return _t_eamt
      End Get
      Set(ByVal value As Double)
        _t_eamt = value
      End Set
    End Property
    Public Property t_srcd() As Double
      Get
        Return _t_srcd
      End Get
      Set(ByVal value As Double)
        _t_srcd = value
      End Set
    End Property
    Public Property t_crcd() As Double
      Get
        Return _t_crcd
      End Get
      Set(ByVal value As Double)
        _t_crcd = value
      End Set
    End Property
    Public Property t_ercd() As Double
      Get
        Return _t_ercd
      End Get
      Set(ByVal value As Double)
        _t_ercd = value
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
    Public Property t_srno() As Int32
      Get
        Return _t_srno
      End Get
      Set(ByVal value As Int32)
        _t_srno = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_ccod & "|" & _t_srno
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
    Public Class PKtpisg304
      Private _t_ccod As String = ""
      Private _t_srno As Int32 = 0
      Public Property t_ccod() As String
        Get
          Return _t_ccod
        End Get
        Set(ByVal value As String)
          _t_ccod = value
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg304GetNewRecord() As SIS.CT.tpisg304
      Return New SIS.CT.tpisg304()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg304GetByID(ByVal t_ccod As String, ByVal t_srno As Int32) As SIS.CT.tpisg304
      Dim Results As SIS.CT.tpisg304 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg304SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, t_ccod.ToString.Length, t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, t_srno.ToString.Length, t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg304(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg304SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As List(Of SIS.CT.tpisg304)
      Dim Results As List(Of SIS.CT.tpisg304) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg304SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg304SelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_ccod", SqlDbType.VarChar, 9, IIf(t_ccod Is Nothing, String.Empty, t_ccod))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.tpisg304)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg304(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg304SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg304GetByID(ByVal t_ccod As String, ByVal t_srno As Int32, ByVal Filter_t_ccod As String) As SIS.CT.tpisg304
      Return tpisg304GetByID(t_ccod, t_srno)
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
