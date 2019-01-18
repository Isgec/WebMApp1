Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class ctPUActivity
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
    Public Property t_aced() As String
      Get
        If Not _t_aced = String.Empty Then
          Return Convert.ToDateTime(_t_aced).ToString("dd/MM/yyyy")
        End If
        Return _t_aced
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_aced = ""
        Else
          _t_aced = value
        End If
      End Set
    End Property

    Public Property dt_oted() As String
      Get
        If Not _t_oted = String.Empty Then
          Return Convert.ToDateTime(_t_oted).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_oted = ""
        Else
          _t_oted = value
        End If
      End Set
    End Property
    Public Property dt_otsd() As String
      Get
        If Not _t_otsd = String.Empty Then
          Return Convert.ToDateTime(_t_otsd).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_otsd = ""
        Else
          _t_otsd = value
        End If
      End Set
    End Property
    Public Property dt_acsd() As String
      Get
        If Not _t_acsd = String.Empty Then
          Return Convert.ToDateTime(_t_acsd).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_acsd = ""
        Else
          _t_acsd = value
        End If
      End Set
    End Property
    Public Property dt_aced() As String
      Get
        If Not _t_aced = String.Empty Then
          Return Convert.ToDateTime(_t_aced).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_aced = ""
        Else
          _t_aced = value
        End If
      End Set
    End Property
    Public Property dt_cted() As String
      Get
        If Not _t_cted = String.Empty Then
          Return Convert.ToDateTime(_t_cted).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_cted = ""
        Else
          _t_cted = value
        End If
      End Set
    End Property
    Public Property dt_ctsd() As String
      Get
        If Not _t_ctsd = String.Empty Then
          Return Convert.ToDateTime(_t_ctsd).ToString("yyyy-MM-dd")
        End If
        Return ""
      End Get
      Set(ByVal value As String)
        If value = "01/01/0001 00:00:00" Then
          _t_ctsd = ""
        Else
          _t_ctsd = value
        End If
      End Set
    End Property
    Public Shared Function GetLastUpdate(ByVal t_cprj As String, ByVal t_atid As String, ByVal t_orno As String) As SIS.CT.ctPUActivity
      Dim Results As SIS.CT.ctPUActivity = Nothing
      Dim Sql As String = ""
      Sql &= " Select * from ttpisg183200 as aa "
      Sql &= " where aa.t_cprj='" & t_cprj & "' and aa.t_atid='" & t_atid & "'" & " and t_orno ='" & t_orno & "'"
      Sql &= "   and aa.t_srno=(select max(bb.t_srno) from ttpisg183200 as bb where bb.t_cprj=aa.t_cprj and bb.t_atid=aa.t_atid and bb.t_orno=aa.t_orno)"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim x As SqlDataReader = Cmd.ExecuteReader
          If x.Read Then
            Results = New SIS.CT.ctPUActivity(x)
          End If
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetPOPercent(ByVal Record As SIS.CT.ctPUActivity) As Double
      Dim Results As Double = 0
      Dim Sql As String = ""
      Sql &= " Select isnull(t_cpgv,0) from ttpisg220200 "
      Sql &= " where t_cprj='" & Record.t_cprj & "' and t_sub1 = (select t_sub1 from ttpisg220200 where t_cprj='" & Record.t_cprj & "' and t_cact='" & Record.t_atid & "') "
      Sql &= "   and t_bohd='CT_POAPPROVED'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal t_cprj As String, ByVal t_atid As String, ByVal t_srno As Int32) As SIS.CT.ctPUActivity
      Dim Results As SIS.CT.ctPUActivity = ctPUActivityGetByID(t_cprj, t_atid, t_srno)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal t_cprj As String, ByVal t_atid As String, ByVal t_srno As Int32) As SIS.CT.ctPUActivity
      Dim Results As SIS.CT.ctPUActivity = ctPUActivityGetByID(t_cprj, t_atid, t_srno)
      Return Results
    End Function
    Public Shared Function UZ_ctPUActivitySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_atid As String, ByVal t_cprj As String) As List(Of SIS.CT.ctPUActivity)
      Dim Results As List(Of SIS.CT.ctPUActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "t_srno DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spct_LG_PUAivitySelectListSearch"
            Cmd.CommandText = "spctPUActivitySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spct_LG_PUAivitySelectListFilteres"
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
    Public Shared Function UZ_ctPUActivityInsert(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Dim _Result As SIS.CT.ctPUActivity = ctPUActivityInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_ctPUActivityUpdate(ByVal Record As SIS.CT.ctPUActivity) As SIS.CT.ctPUActivity
      Dim _Result As SIS.CT.ctPUActivity = ctPUActivityUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_ctPUActivityDelete(ByVal Record As SIS.CT.ctPUActivity) As Integer
      Dim _Result As Integer = ctPUActivityDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_srno"), TextBox).Text = 0
          CType(.FindControl("F_t_plsd"), TextBox).Text = ""
          CType(.FindControl("F_t_plfd"), TextBox).Text = ""
          CType(.FindControl("F_t_acsd"), TextBox).Text = ""
          CType(.FindControl("F_t_aced"), TextBox).Text = ""
          CType(.FindControl("F_t_puom"), TextBox).Text = ""
          CType(.FindControl("F_t_tpgv"), TextBox).Text = 0
          CType(.FindControl("F_t_otsd"), TextBox).Text = ""
          CType(.FindControl("F_t_atid"), TextBox).Text = ""
          CType(.FindControl("F_t_atid_Display"), Label).Text = ""
          CType(.FindControl("F_t_cprj"), TextBox).Text = ""
          CType(.FindControl("F_t_cprj_Display"), Label).Text = ""
          CType(.FindControl("F_t_rmks"), TextBox).Text = ""
          CType(.FindControl("F_t_oted"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Property AddNewUpdate As Boolean = True
    Public Shared Function GetctPUActivityForUpdate(ByVal t_cprj As String, ByVal t_cact As String, Optional ByVal t_orno As String = "", Optional ByVal t_bohd As String = "") As SIS.CT.ctPUActivity
      Dim tmpA As SIS.CT.ctPActivity = SIS.CT.ctPActivity.ctPActivityGetByID(t_cprj, t_cact)
      t_bohd = tmpA.t_bohd
      Dim tmpL As SIS.CT.ctPUActivity = SIS.CT.ctPUActivity.GetLastUpdate(t_cprj, t_cact, t_orno)
      Dim tmpU As SIS.CT.ctPUActivity = Nothing
      Dim tmpLFound As Boolean = False
      Dim mayAddNewUpdate As Boolean = True
      If tmpL IsNot Nothing Then
        tmpLFound = True
        If tmpL.t_aced <> "" Then
          If Year(Convert.ToDateTime(tmpL.t_aced)) > 2015 Then
            mayAddNewUpdate = False
          End If
        End If
        If tmpL.t_cpgv + tmpL.t_tpgv >= 100 Then
          mayAddNewUpdate = False
        End If
        If tmpA.t_rmcm = 1 Then
          If tmpL.t_cpgv + tmpL.t_tpgv >= 100 Then
            mayAddNewUpdate = False
          Else
            mayAddNewUpdate = True
          End If
        Else
          If tmpL.t_tpgv = 0 Then
            mayAddNewUpdate = True
          End If
        End If
      End If
      If Not mayAddNewUpdate Then
        tmpU = tmpL
      Else
        tmpU = New SIS.CT.ctPUActivity
        With tmpU
          .t_cprj = t_cprj
          .t_atid = t_cact
          .t_srno = 0
          .t_plsd = tmpA.t_sdst
          .t_plfd = tmpA.t_sdfn
          .t_puom = tmpA.t_pcbs
          .t_crby = HttpContext.Current.Session("LoginID")
          .t_cron = Now
          .t_gps1 = ""
          .t_gps2 = ""
          .t_gps3 = ""
          .t_gps4 = ""
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_tpgv = 0.00
          .t_rmks = ""
          .t_orno = t_orno
          .t_bohd = t_bohd
          .t_wipd = 3
          If tmpLFound Then
            .t_acsd = tmpL.t_acsd
            .t_aced = tmpL.t_aced
            .t_otsd = tmpL.t_otsd
            .t_oted = tmpL.t_oted
            .t_cpgv = tmpL.t_cpgv + tmpL.t_tpgv
            If Not mayAddNewUpdate Then
              .t_wipd = tmpL.t_wipd
            End If
          Else
            .t_acsd = ""
            .t_aced = ""
            .t_otsd = ""
            .t_oted = ""
            .t_cpgv = 0.00
            .t_wipd = 3
          End If
        End With
        tmpU.AddNewUpdate = mayAddNewUpdate
        tmpU = SIS.CT.ctPUActivity.ctPUActivityInsert(tmpU)
      End If
      Return tmpU
    End Function
  End Class
End Namespace
