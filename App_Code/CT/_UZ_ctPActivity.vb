Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class ctPActivity
    Public Property tot_cpgv As Decimal = 0.00
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Gray
      If t_acsd <> "" Then
        mRet = Drawing.Color.DodgerBlue
        If Convert.ToDateTime(t_acfn).Year > 2015 Then
          mRet = Drawing.Color.Green
        End If
      Else  'If Convert.ToDateTime(t_sdst)  Then
        mRet = Drawing.Color.Red
      End If
      Return mRet
    End Function
    Public ReadOnly Property EnableLink As Boolean
      Get
        If t_manu = 1 Then Return False Else Return True
      End Get
    End Property
    Public Function bgCssClass() As String
      Dim mRet As String = "table-primary"
      If ChildStatus = "No Record" Then
      ElseIf ChildStatus = "" Then
        mRet = "table-warning"
      ElseIf Year(Convert.ToDateTime(ChildStatus)) < 2015 Then
        mRet = "table-warning"
      Else
        mRet = "table-success"
      End If
      Return mRet
    End Function
    Public ReadOnly Property ChildStatus As String
      Get
        Dim Results As String = ""
        Dim Sql As String = ""
        Sql &= " Select (case when (select count(*) from ttpisg183200 "
        Sql &= "            where t_cprj='" & t_cprj & "' and t_atid='" & t_cact & "' and t_orno='" & t_orno & "' )=0"
        Sql &= "         Then"
        Sql &= "           'No Record'"
        Sql &= "         Else"
        Sql &= "           (select convert(nvarchar(10),isnull(aa.t_aced,'')) from ttpisg183200 as aa"
        Sql &= "             where aa.t_cprj ='" & t_cprj & "' and aa.t_atid='" & t_cact & "' and t_orno='" & t_orno & "'"
        Sql &= "               And aa.t_srno = (select max(bb.t_srno) from ttpisg183200 as bb"
        Sql &= "                                where aa.t_cprj = bb.t_cprj And aa.t_atid = bb.t_atid And aa.t_orno = bb.t_orno)"
        Sql &= "                               )"
        Sql &= "         End) As tmp"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Results = Cmd.ExecuteScalar
          End Using
        End Using
        Return Results
      End Get
    End Property
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
    Public Shared Function UZ_ctPActivitySelectList(ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String, ByVal OnlyMe As Boolean) As List(Of SIS.CT.ctPActivity)
      Dim Filter_Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Filter_Departments = "" Then
              Filter_Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Filter_Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using

      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_PActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, IIf(SearchText Is Nothing, "", SearchText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Departments", SqlDbType.NVarChar, 250, Filter_Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsSearch", SqlDbType.Bit, 3, SearchState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OnlyMe", SqlDbType.Bit, 3, OnlyMe)
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
    Public Shared Function UZ_ctPActivityUpdate(ByVal Record As SIS.CT.ctPActivity) As SIS.CT.ctPActivity
      Dim _Result As SIS.CT.ctPActivity = ctPActivityUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_cprj"), TextBox).Text = ""
          CType(.FindControl("F_t_cprj_Display"), Label).Text = ""
          CType(.FindControl("F_t_cact"), TextBox).Text = ""
          CType(.FindControl("F_t_cact_Display"), Label).Text = ""
          CType(.FindControl("F_t_pcod"), TextBox).Text = ""
          CType(.FindControl("F_t_pcod_Display"), Label).Text = ""
          CType(.FindControl("F_t_sdst"), TextBox).Text = ""
          CType(.FindControl("F_t_sdfn"), TextBox).Text = ""
          CType(.FindControl("F_t_acsd"), TextBox).Text = ""
          CType(.FindControl("F_t_acfn"), TextBox).Text = ""
          'CType(.FindControl("F_t_iref"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function UZ_SelectctPActivityAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_PActivityAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 9, aVal(0))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ByCode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "), "" & "|" & ""))
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
    Public Shared Function UZ_DelayedActivity(ByVal t_cprj As String, ByVal t_acty As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      Dim Sql As String = ""
      Sql &= "select * from (                                                                                                                                                                                     "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'"
      Sql &= "And t_acty='" & t_acty & "'"
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                "
      Sql &= ") as tmp                                                                                                                                                                                            "
      Sql &= "order by t_days desc, t_sub1                                                                                                                                                                                "


      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.ctPActivity(Reader)
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_BacklogActivity(ByVal t_cprj As String, ByVal t_acty As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Dim Period As SIS.CT.tpisg216.ProjectPeriod = SIS.CT.tpisg216.GetProjectPeriod(t_cprj)
      Dim s_date As String = Period.StDt.ToString("dd/MM/yyyy")
      Dim t_date As String = Now.AddDays(-31).ToString("dd/MM/yyyy")
      Dim Sql As String = ""
      Sql &= "select * from (                                                                                                                                                                                     "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'"
      Sql &= "And t_acty='" & t_acty & "'"
      Sql &= "and t_sdst between convert(datetime,'" & s_date & "',103) And DATEADD(d,-31, convert(datetime,'" & t_date & "',103))                                                                            "
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdst between convert(datetime,'" & s_date & "',103) And DATEADD(d,-31, convert(datetime,'" & t_date & "',103))                                                                            "
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between convert(datetime,'" & s_date & "',103) And DATEADD(d,-31, convert(datetime,'" & t_date & "',103))                                                                            "
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between convert(datetime,'" & s_date & "',103) And DATEADD(d,-31, convert(datetime,'" & t_date & "',103))                                                                            "
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                "
      Sql &= ") as tmp                                                                                                                                                                                            "
      Sql &= "order by t_days desc, t_sub1                                                                                                                                                                                "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.ctPActivity(Reader)
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_OverallDelayedActivity(ByVal t_cprj As String, ByVal t_acty As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      If t_cprj = "" Then Return Results
      Dim Period As SIS.CT.tpisg216.ProjectPeriod = SIS.CT.tpisg216.GetProjectPeriod(t_cprj)
      Dim s_date As String = Period.StDt.ToString("dd/MM/yyyy")
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      Dim Sql As String = ""
      Sql &= "select top 10 * from (                                                                                                                                                                                     "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'"
      Sql &= "And t_acty='" & t_acty & "'"
      Sql &= "and t_sdst between convert(datetime,'" & s_date & "',103) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_dela as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdst between convert(datetime,'" & s_date & "',103) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >0 then 1 else  0 end                                                                                "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                                 "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between convert(datetime,'" & s_date & "',103) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                   "
      Sql &= "union all                                                                                                                                                                                           "
      Sql &= "select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,                                                                                                                              "
      Sql &= "(select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
      Sql &= "t_drem as t_type,                                                                                                                                                                                     "
      Sql &= "t_delf as t_days                                                                                                                                                              "
      Sql &= "from ttpisg220200                                                                                                                                                                                   "
      Sql &= "where t_cprj='" & t_cprj & "'                                                                                                                                                                      "
      Sql &= "And t_acty='" & t_acty & "'                                                                                                                                                                        "
      Sql &= "and t_sdfn between convert(datetime,'" & s_date & "',103) And convert(datetime,'" & t_date & "',103)                                                                            "
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >0 then 1 else  0 end                                                                                "
      Sql &= ") as tmp                                                                                                                                                                                            "
      Sql &= "order by t_days desc, t_sub1                                                                                                                                                                                "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.ctPActivity(Reader)
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_IrefWiseDelayedActivity(ByVal t_cprj As String, ByVal t_cact As String, ByVal t_acty As String, ByVal ID As String, ByVal All As Boolean, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      'Dim o_acty As String = "'PARENT','DESIGN','INDT','RFQ-TO-PO','MFG','EREC'"
      Dim othAct As String = "('DISP','RECPT')"

      Dim Sql As String = ""
      Select Case ID
        Case "DATA_S"
          Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1, "
          Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
          Sql &= " t_drem as t_type, "
          Sql &= " t_dela as t_days "
          Sql &= " from ttpisg220200  "
          Sql &= " where t_cprj='" & t_cprj & "'"
          Sql &= " and t_sub1= (select t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
          If t_acty = "OTHERS" Then
            Sql &= " And t_acty in " & othAct
          Else
            Sql &= " And t_acty='" & t_acty & "'"
          End If
          'Sql &= " and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)"
          Sql &= " order by t_cact "
        Case "DATA_F"
          Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,"
          Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
          Sql &= " t_drem as t_type, "
          Sql &= " t_delf as t_days "
          Sql &= " from ttpisg220200 "
          Sql &= " where t_cprj='" & t_cprj & "'"
          Sql &= " and t_sub1= (select t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
          If t_acty = "OTHERS" Then
            Sql &= " And t_acty in " & othAct
          Else
            Sql &= " And t_acty='" & t_acty & "'"
          End If
          'Sql &= " and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103) "
          Sql &= " order by t_cact "
        Case "ACTIVITY"
          Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1, "
          Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
          Sql &= " t_drem as t_type, "
          Sql &= " (case when t_dela > t_delf then t_dela else t_delf end) as t_days "
          Sql &= " from ttpisg220200  "
          Sql &= " where t_cprj='" & t_cprj & "'"
          If t_acty = "OTHERS" Then
            Sql &= " And t_acty in " & othAct
          Else
            Sql &= " And t_acty='" & t_acty & "'"
          End If
          'Sql &= " and ((t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)) or (t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)))"
          Sql &= " order by t_cact "
        Case "ITEM"
          Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1, "
          Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem, "
          Sql &= " t_drem as t_type, "
          Sql &= " (case when t_dela > t_delf then t_dela else t_delf end) as t_days "
          Sql &= " from ttpisg220200  "
          Sql &= " where t_cprj='" & t_cprj & "'"
          Sql &= " and t_sub1= (select t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
          'Sql &= " and ((t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)) or (t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) And convert(datetime,'" & t_date & "',103)))"
          Sql &= " order by t_cact "
      End Select

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.ctPActivity(Reader)
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function UZ_ctMfgActivitySelectList(ByVal t_cprj As String, ByVal t_orno As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_MFGActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.NVarChar, 9, IIf(t_orno Is Nothing, String.Empty, t_orno))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.CT.ctPActivity)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.ctPActivity(Reader)
            tmp.t_orno = t_orno
            Results.Add(tmp)
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_ctEreActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_EREActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctConActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_CONActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctEstActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_ESTIMATION
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_ESTActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctLogActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_LOGISTIC
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_LOGActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctMktActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_MARKETING
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_MKTActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctPrjActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_PROJECT
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_PRJActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctMatActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_ENGG
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_MATActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctEngActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_ENGG
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_ENGActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctYNRActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'CT_ENGG
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_YNRActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctAPCActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      'C
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_APCActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
    Public Shared Function UZ_ctCivActivitySelectList(ByVal t_cprj As String, ByVal t_iref As String, ByVal t_sitm As String, ByVal OrderBy As String) As List(Of SIS.CT.ctPActivity)
      Dim Departments As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from CT_UserDepartment where userid='" & UserID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            If Departments = "" Then
              Departments = "'" & Reader("DepartmentID") & "'"
            Else
              Departments &= ",'" & Reader("DepartmentID") & "'"
            End If
          End While
          Reader.Close()
        End Using
      End Using
      Dim ItemRef As String = ""
      Try
        Dim aVal() As String = t_iref.Split("_".ToCharArray)
        ItemRef = aVal(0)
      Catch ex As Exception
      End Try
      'Get Mapped Department and format string to be used in SQL IN Clause
      Dim Results As List(Of SIS.CT.ctPActivity) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spct_LG_CIVActivitySelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.NVarChar, 6, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iref", SqlDbType.NVarChar, 200, IIf(ItemRef Is Nothing, String.Empty, ItemRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sitm", SqlDbType.NVarChar, 9, IIf(t_sitm Is Nothing, String.Empty, t_sitm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Departments", SqlDbType.NVarChar, 250, Departments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
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
  End Class
End Namespace
