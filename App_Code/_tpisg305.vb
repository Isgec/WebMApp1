Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()> _
  Partial Public Class tpisg305
    Private Shared _RecordCount As Integer
    Private _t_user As String = ""
    Private _t_csdc As String = ""
    Private _t_bdgd As Double = 0
    Private _t_aled As Double = 0
    Private _t_ccod As String = ""
    Private _t_cbda As Double = 0
    Private _t_cycn As Double = 0
    Private _t_sson As Double = 0
    Private _t_stcs As Double = 0
    Private _t_cysc As Double = 0
    Private _t_coco As Double = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
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
    Public Property t_csdc() As String
      Get
        Return _t_csdc
      End Get
      Set(ByVal value As String)
        _t_csdc = value
      End Set
    End Property
    Public Property t_bdgd() As Double
      Get
        Return _t_bdgd
      End Get
      Set(ByVal value As Double)
        _t_bdgd = value
      End Set
    End Property
    Public Property t_aled() As Double
      Get
        Return _t_aled
      End Get
      Set(ByVal value As Double)
        _t_aled = value
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
    Public Property t_cbda() As Double
      Get
        Return _t_cbda
      End Get
      Set(ByVal value As Double)
        _t_cbda = value
      End Set
    End Property
    Public Property t_cycn() As Double
      Get
        Return _t_cycn
      End Get
      Set(ByVal value As Double)
        _t_cycn = value
      End Set
    End Property
    Public Property t_sson() As Double
      Get
        Return _t_sson
      End Get
      Set(ByVal value As Double)
        _t_sson = value
      End Set
    End Property
    Public Property t_stcs() As Double
      Get
        Return _t_stcs
      End Get
      Set(ByVal value As Double)
        _t_stcs = value
      End Set
    End Property
    Public Property t_cysc() As Double
      Get
        Return _t_cysc
      End Get
      Set(ByVal value As Double)
        _t_cysc = value
      End Set
    End Property
    Public Property t_coco() As Double
      Get
        Return _t_coco
      End Get
      Set(ByVal value As Double)
        _t_coco = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_csdc & "|" & _t_ccod
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
    Public Class PKtpisg305
      Private _t_csdc As String = ""
      Private _t_ccod As String = ""
      Public Property t_csdc() As String
        Get
          Return _t_csdc
        End Get
        Set(ByVal value As String)
          _t_csdc = value
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
    Public Shared Function tpisg305GetNewRecord() As SIS.CT.tpisg305
      Return New SIS.CT.tpisg305()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg305GetByID(ByVal t_csdc As String, ByVal t_ccod As String) As SIS.CT.tpisg305
      Dim Results As SIS.CT.tpisg305 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg305SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_csdc", SqlDbType.VarChar, t_csdc.ToString.Length, t_csdc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccod", SqlDbType.VarChar, t_ccod.ToString.Length, t_ccod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.CT.tpisg305(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tpisg305SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As List(Of SIS.CT.tpisg305)
      Dim Results As List(Of SIS.CT.tpisg305) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg305SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg305SelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_ccod", SqlDbType.VarChar, 9, IIf(t_ccod Is Nothing, String.Empty, t_ccod))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.tpisg305)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg305(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg305SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg305GetByID(ByVal t_csdc As String, ByVal t_ccod As String, ByVal Filter_t_ccod As String) As SIS.CT.tpisg305
      Return tpisg305GetByID(t_csdc, t_ccod)
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
