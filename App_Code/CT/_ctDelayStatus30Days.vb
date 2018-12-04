Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class DelayStatus30Days
    Public Class Activities
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

      Public Property t_cprj As String = ""
      Public Property t_sub1 As String = ""
      Public Property t_cact As String = ""
      Public Property t_acty As String = ""
      Public Property t_dept As String = ""
      Private _t_sdst As String = ""
      Private _t_sdfn As String = ""
      Private _t_acsd As String = ""
      Private _t_acfn As String = ""
      Private _t_otsd As String = ""
      Private _t_oted As String = ""
      Public Property t_desc As String = ""
      Public Property t_drem As String = ""
      Public Property SubItem As String = ""
      Public Property t_dela As Integer = 0
      Public Property t_delf As Integer = 0
      Public Property IsCurrent As Boolean = False
      Public Property IsStarted As Boolean = False
      Public Property IsFinished As Boolean = False
      Public Property IsDue As Boolean = False
      Public Property t_pprc As Decimal = 0
      Public Property t_cpgv As Decimal = 0
      Public Property Top As Boolean = False
      Public Property Middle As Boolean = False
      Public Property Bottom As Boolean = False
      Public Property Indent As Integer = 0
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

    End Class

    Public Shared Function SelectActivity(ByVal t_cprj As String, ByVal t_cact As String, ByVal t_acty As String, ByVal ID As String, ByVal All As Boolean) As List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Results As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")

      Dim Sql As String = ""
      Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,t_drem, t_dela, t_delf,t_otsd,t_oted, t_pprc,t_cpgv,t_acty,t_dept, "
      Sql &= " IsCurrent = case when ((t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (t_sdfn between dateadd(d,-30,getdate()) and getdate())) or ((t_sdst < dateadd(d,-30,getdate()))   and   (t_sdfn > getdate())) then 1 else 0 end, "
      Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=ttpisg220200.t_pcod and aa.t_iref=ttpisg220200.t_sub1 and aa.t_sitm=ttpisg220200.t_sitm ) as SubItem "
      Sql &= " from ttpisg220200  "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Select Case ID
        Case "DATA_S", "DATA_F"
          Sql &= " and t_sub1= (select t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
          Sql &= " And t_acty='" & t_acty & "'"
        Case "ACTIVITY"
          Sql &= " And t_acty='" & t_acty & "'"
        Case "ITEM"
          Sql &= " and t_sub1= (select t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
      End Select
      Sql &= " order by t_cact "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.DelayStatus30Days.Activities)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.DelayStatus30Days.Activities(Reader)
            With tmp
              Try
                If Convert.ToDateTime(tmp.t_sdst) > Now Then tmp.IsDue = False Else tmp.IsDue = True
                If Year(Convert.ToDateTime(tmp.t_acsd)) > 1753 Then tmp.IsStarted = True
                If Year(Convert.ToDateTime(tmp.t_acfn)) > 1753 Then tmp.IsFinished = True
              Catch ex As Exception
              End Try
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Class sub1
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

      Public Property t_sub1 As String = ""
      Public Property t_cact As String = ""
      Public Property t_acty As String = ""
      Public Property t_atsk As Integer = 0

      Public Property TotalDocs As Integer = 0
      Public Property ReleasedDocs As Integer = 0

      Public Property Started As Boolean = False
      Public Property Finished As Boolean = False
      Public Property CountAll As Integer = 0
      Public Property CountStarted As Integer = 0
      Public Property CountFinished As Integer = 0
      Public Property CountMark As Integer = 0
      Public Property StartedDelay As Integer = 0
      Public Property FinishedDelay As Integer = 0
      Public Property NotStartedDelay As Integer = 0
      Public Property NotFinishedDelay As Integer = 0
    End Class

    Public Class activityType
      Public Property Initialized As Boolean = False
      Public Property Started As Boolean = False
      Public Property Finished As Boolean = False
      Public Property CountAll As Integer = 0
      Public Property CountStarted As Integer = 0
      Public Property CountFinished As Integer = 0
      Public Property StartDelay As Integer = 0
      Public Property FinishDelay As Integer = 0
      Public Property SelfStartDelay As Integer = 0
      Public Property SelfFinishDelay As Integer = 0
      Public Property IsCurrent As Boolean = False
    End Class
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

    Public Property t_cprj As String = ""
    Public Property t_sub1 As String = ""
    Public Property t_cact As String = ""
    Public Property t_atsk As Integer = 0

    Public Property TotalDocs As Integer = 0
    Public Property ReleasedDocs As Integer = 0

    Public Property Design As activityType = New activityType
    Public Property Indt As activityType = New activityType
    Public Property RfqToPO As activityType = New activityType
    Public Property Mfg As activityType = New activityType
    Public Property Erec As activityType = New activityType
    Public Property Others As activityType = New activityType
    Public Property Disp As activityType = New activityType
    Public Property Recpt As activityType = New activityType

    Public ReadOnly Property ID As String
      Get
        Return t_cprj & "_" & t_cact
      End Get
    End Property
    Public ReadOnly Property aID As String
      Get
        Return "All" & t_cprj & "_" & t_cact
      End Get
    End Property
    Public ReadOnly Property GetDocumentLink As String
      Get
        Return "~/CT_mMain/App_Forms/mGctDocumentList.aspx?t_cprj=" & t_cprj & "&t_cact=" & t_cact
      End Get
    End Property
    Public ReadOnly Property GetRedirectLink As String
      Get
        Return "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & t_cprj & "&t_cact=" & t_cact
      End Get
    End Property
    Public Shared Function GetActivity(ByVal tmp As SIS.CT.DelayStatus30Days.sub1, ByVal tmp1 As SIS.CT.DelayStatus30Days) As SIS.CT.DelayStatus30Days.activityType
      Select Case tmp.t_acty
        Case "DESIGN"
          Return tmp1.Design
        Case "INDT"
          Return tmp1.Indt
        Case "RFQ-TO-PO"
          Return tmp1.RfqToPO
        Case "MFG"
          Return tmp1.Mfg
        Case "EREC"
          Return tmp1.Erec
        Case "DISP"
          Return tmp1.Disp
        Case "RECPT"
          Return tmp1.Recpt
        Case Else
          Return tmp1.Others
      End Select
    End Function
    Public Class ProjectDates
      Public Property Contractual As DateTime = Nothing
      Public Property Initial As DateTime = Nothing
      Public Property Expected As DateTime = Nothing
      Public Property TotalDays As Integer = 0
      Public Property CalenderDays As Integer = 0
      Public Property CalenderType As Integer = 0
    End Class
    Public Shared Function LastUpdatedOn(ByVal t_cprj As String) As DateTime
      Dim mRet As DateTime = Nothing
      Dim Sql As String = ""
      Dim plDt As DateTime = Nothing
      Dim acDt As DateTime = Nothing
      Sql &= "  select top 1 t_limp from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet = Cmd.ExecuteScalar()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function OverAllImpactOnCommissioning(ByVal t_cprj As String) As ProjectDates
      Dim mRet As New ProjectDates
      Dim Sql As String = ""
      Dim plDt As DateTime = Nothing
      Dim acDt As DateTime = Nothing
      Sql &= "  select t_cdis,t_ecdt,t_ccdt,t_ctyp from ttpisg245200 as bb where bb.t_cprj='" & t_cprj & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim x As SqlDataReader = Cmd.ExecuteReader()
          If x.Read() Then
            mRet.Initial = x("t_cdis")
            mRet.Contractual = x("t_ccdt")
            mRet.Expected = x("t_ecdt")
            mRet.CalenderType = x("t_ctyp")
          End If
          x.Close()
          mRet.TotalDays = Math.Round((mRet.Expected - mRet.Initial).TotalDays, 0)
          Select Case mRet.CalenderType
            Case 1 '5 day Week
              Dim tmpDays As Integer = mRet.TotalDays - 1
              Dim weeks As Integer = tmpDays / 7
              mRet.CalenderDays = tmpDays - (weeks * 2)
              Dim daysLeft As Integer = tmpDays Mod 7
              For I As Integer = 1 To daysLeft
                Dim dow As Integer = (mRet.Initial.DayOfWeek + I) Mod 7
                If dow = DayOfWeek.Saturday Then mRet.CalenderDays -= 1
                If dow = DayOfWeek.Sunday Then mRet.CalenderDays -= 1
              Next
            Case 2 '6 day week
              Dim weeks As Integer = mRet.TotalDays / 7
              mRet.CalenderDays = mRet.TotalDays - weeks
            Case 3 ' 7 All Day week
              mRet.CalenderDays = mRet.TotalDays
          End Select
        End Using
      End Using
      Return mRet
    End Function
    'Public Shared Function SelectItems(ByVal t_cprj As String) As List(Of SIS.CT.DelayStatus30Days)
    '  Dim Results As List(Of SIS.CT.DelayStatus30Days) = Nothing
    '  Dim Sql As String = ""
    '  Sql &= "   select distinct aa.t_sub1,aa.t_acty,"
    '  Sql &= "   (select top 1 t_cact from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1) as t_cact,"
    '  Sql &= "   (select round(IsNull(min(t_atsk),0),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = 'EREC' and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as t_atsk,   "
    '  Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountAll,   "
    '  Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where year(bb.t_acsd)>1753 and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountStarted,   "
    '  Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where year(bb.t_acfn)>1753 and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountFinished,   "
    '  Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where (((bb.t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (bb.t_sdfn between dateadd(d,-30,getdate()) and getdate())) OR ((bb.t_sdst < dateadd(d,-30,getdate()))   and   (bb.t_sdfn > getdate())) ) and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountMark,   "
    '  Sql &= "   (select IsNull(min(bb.t_dela),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
    '  Sql &= "     and bb.t_otsd = (select min(cc.t_otsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
    '  Sql &= " ) as NotStartedDelay,   "
    '  Sql &= "   (select IsNull(min(bb.t_dela),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
    '  Sql &= "     and bb.t_acsd = (select min(cc.t_acsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
    '  Sql &= " ) as StartedDelay,   "
    '  Sql &= "   (select IsNull(max(bb.t_delf),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
    '  Sql &= "     and bb.t_oted = (select max(cc.t_oted) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
    '  Sql &= " ) as NotFinishedDelay,   "
    '  Sql &= "   (select IsNull(max(bb.t_delf),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
    '  Sql &= "     and bb.t_acfn = (select max(cc.t_acfn) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
    '  Sql &= " ) as FinishedDelay    "
    '  Sql &= "    from ttpisg220200  as aa"
    '  Sql &= "    where aa.t_cprj='" & t_cprj & "'"
    '  Sql &= "    and aa.t_acty in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC','DISP','RECPT')"
    '  Sql &= "    and aa.t_sub1 in ("
    '  Sql &= "      select t_sub1 from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj "
    '  Sql &= "  and bb.t_acty in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC','DISP','RECPT')"
    '  Sql &= "  and (((bb.t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (bb.t_sdfn between dateadd(d,-30,getdate()) and getdate()))  OR ((bb.t_sdst < dateadd(d,-30,getdate()))   and   (bb.t_sdfn > getdate()))  ) "
    '  Sql &= "  and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
    '  Sql &= "    )"
    '  Sql &= "    order by t_sub1, t_acty"
    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Con.Open()
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = Sql
    '      Results = New List(Of SIS.CT.DelayStatus30Days)()
    '      Dim Reader As SqlDataReader = Cmd.ExecuteReader()
    '      Dim L_sub1 As String = ""
    '      Dim L_acty As String = ""
    '      Dim tmp As SIS.CT.DelayStatus30Days.sub1 = Nothing
    '      Dim tmp1 As SIS.CT.DelayStatus30Days = Nothing
    '      Dim xx As SIS.CT.DelayStatus30Days.activityType = Nothing
    '      While (Reader.Read())
    '        tmp = New SIS.CT.DelayStatus30Days.sub1(Reader)
    '        If tmp.t_sub1 <> L_sub1 Then
    '          If tmp1 IsNot Nothing Then
    '            Results.Add(tmp1)
    '          End If
    '          tmp1 = New SIS.CT.DelayStatus30Days()
    '          With tmp1
    '            .t_cprj = t_cprj
    '            .t_cact = tmp.t_cact
    '            .t_sub1 = tmp.t_sub1
    '            If tmp.t_atsk < 0 Then
    '              .t_atsk = Math.Abs(tmp.t_atsk)
    '            Else
    '              .t_atsk = 0
    '            End If
    '            xx = SIS.CT.DelayStatus30Days.GetActivity(tmp, tmp1)
    '          End With
    '          L_sub1 = tmp.t_sub1
    '          L_acty = tmp.t_acty
    '        ElseIf tmp.t_sub1 = L_sub1 AndAlso L_acty <> tmp.t_acty Then
    '          xx = SIS.CT.DelayStatus30Days.GetActivity(tmp, tmp1)
    '          L_acty = tmp.t_acty
    '        End If
    '        With xx
    '          .Initialized = True
    '          If tmp.CountMark > 0 Then .IsCurrent = True
    '          .CountAll = tmp.CountAll
    '          .CountFinished = tmp.CountFinished
    '          .CountStarted = tmp.CountStarted
    '          If .CountStarted > 0 Then .Started = True
    '          If .CountAll = .CountFinished Then .Finished = True
    '          If .Started Then .StartDelay = tmp.StartedDelay Else .StartDelay = tmp.NotStartedDelay
    '          If .Finished Then .FinishDelay = tmp.FinishedDelay Else .FinishDelay = tmp.NotFinishedDelay
    '        End With
    '      End While
    '      Reader.Close()
    '      If tmp1 IsNot Nothing Then
    '        Results.Add(tmp1)
    '      End If
    '    End Using
    '  End Using
    '  'Update SelfDelay
    '  For Each x As SIS.CT.DelayStatus30Days In Results
    '    x.Design.SelfStartDelay = x.Design.StartDelay
    '    x.Design.SelfFinishDelay = x.Design.FinishDelay
    '    x.Indt.SelfStartDelay = x.Indt.StartDelay - x.Design.StartDelay
    '    x.Indt.SelfFinishDelay = x.Indt.FinishDelay - x.Design.FinishDelay
    '    x.RfqToPO.SelfStartDelay = x.RfqToPO.StartDelay - x.Indt.StartDelay
    '    x.RfqToPO.SelfFinishDelay = x.RfqToPO.FinishDelay - x.Indt.FinishDelay
    '    x.Mfg.SelfStartDelay = x.Mfg.StartDelay - x.RfqToPO.StartDelay
    '    x.Mfg.SelfFinishDelay = x.Mfg.FinishDelay - x.RfqToPO.FinishDelay
    '    x.Disp.SelfStartDelay = x.Disp.StartDelay - x.Mfg.StartDelay
    '    x.Disp.SelfFinishDelay = x.Disp.FinishDelay - x.Mfg.FinishDelay
    '    x.Recpt.SelfStartDelay = x.Recpt.StartDelay - x.Disp.StartDelay
    '    x.Recpt.SelfFinishDelay = x.Recpt.FinishDelay - x.Disp.FinishDelay
    '    x.Erec.SelfStartDelay = x.Erec.StartDelay - x.Recpt.StartDelay
    '    x.Erec.SelfFinishDelay = x.Erec.FinishDelay - x.Recpt.FinishDelay
    '  Next
    '  '================
    '  Return Results
    'End Function
    Public Shared Function SelectItems(ByVal t_cprj As String, Optional ByVal t_acty As String = "") As List(Of SIS.CT.DelayStatus30Days)
      Dim Results As List(Of SIS.CT.DelayStatus30Days) = Nothing
      Dim Sql As String = ""
      Sql &= "   select distinct aa.t_sub1,aa.t_acty,"
      If t_acty = "DESIGN" Then
        Sql &= "   (select isnull(count(*),0) from tdmisg140200 as bb where bb.t_cprj=aa.t_cprj and bb.t_iref=aa.t_sub1) as TotalDocs,"
        Sql &= "   (select isnull(count(*),0) from tdmisg140200 as bb where bb.t_cprj=aa.t_cprj and bb.t_iref=aa.t_sub1 and year(t_adct)>1970) as ReleasedDocs,"
      End If
      Sql &= "   (select top 1 t_cact from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1) as t_cact,"
      Sql &= "   (select round(IsNull(min(t_atsk),0),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = 'EREC' and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as t_atsk,   "
      Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountAll,   "
      Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where year(bb.t_acsd)>1753 and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountStarted,   "
      Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where year(bb.t_acfn)>1753 and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountFinished,   "
      Sql &= "   (select IsNull(count(*),0) from ttpisg220200 as bb where (((bb.t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (bb.t_sdfn between dateadd(d,-30,getdate()) and getdate())) OR ((bb.t_sdst < dateadd(d,-30,getdate()))   and   (bb.t_sdfn > getdate())) ) and bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE') as CountMark,   "
      Sql &= "   (select IsNull(min(bb.t_dela),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
      Sql &= "     and bb.t_otsd = (select min(cc.t_otsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
      Sql &= " ) as NotStartedDelay,   "
      Sql &= "   (select IsNull(min(bb.t_dela),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
      Sql &= "     and bb.t_acsd = (select min(cc.t_acsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
      Sql &= " ) as StartedDelay,   "
      Sql &= "   (select IsNull(max(bb.t_delf),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
      Sql &= "     and bb.t_oted = (select max(cc.t_oted) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
      Sql &= " ) as NotFinishedDelay,   "
      Sql &= "   (select IsNull(max(bb.t_delf),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
      Sql &= "     and bb.t_acfn = (select max(cc.t_acfn) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1 and cc.t_acty = bb.t_acty and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE')"
      Sql &= " ) as FinishedDelay    "
      Sql &= "    from ttpisg220200  as aa"
      Sql &= "    where aa.t_cprj='" & t_cprj & "'"
      Sql &= "    and aa.t_acty in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC','DISP','RECPT')"
      Sql &= "    and aa.t_sub1 in ("
      Sql &= "      select t_sub1 from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj "
      Sql &= "  and bb.t_acty in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC','DISP','RECPT')"
      Sql &= "  and (((bb.t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (bb.t_sdfn between dateadd(d,-30,getdate()) and getdate()))  OR ((bb.t_sdst < dateadd(d,-30,getdate()))   and   (bb.t_sdfn > getdate()))  ) "
      Sql &= "  and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE'"
      Sql &= "    )"
      Sql &= "    order by t_sub1, t_acty"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.DelayStatus30Days)()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          Dim L_sub1 As String = ""
          Dim L_acty As String = ""
          Dim tmp As SIS.CT.DelayStatus30Days.sub1 = Nothing
          Dim tmp1 As SIS.CT.DelayStatus30Days = Nothing
          Dim xx As SIS.CT.DelayStatus30Days.activityType = Nothing
          While (Reader.Read())
            tmp = New SIS.CT.DelayStatus30Days.sub1(Reader)
            If tmp.t_sub1 <> L_sub1 Then
              If tmp1 IsNot Nothing Then
                Results.Add(tmp1)
              End If
              tmp1 = New SIS.CT.DelayStatus30Days()
              With tmp1
                .t_cprj = t_cprj
                .t_cact = tmp.t_cact
                .t_sub1 = tmp.t_sub1
                .TotalDocs = tmp.TotalDocs
                .ReleasedDocs = tmp.ReleasedDocs
                If tmp.t_atsk < 0 Then
                  .t_atsk = Math.Abs(tmp.t_atsk)
                Else
                  .t_atsk = 0
                End If
                xx = SIS.CT.DelayStatus30Days.GetActivity(tmp, tmp1)
              End With
              L_sub1 = tmp.t_sub1
              L_acty = tmp.t_acty
            ElseIf tmp.t_sub1 = L_sub1 AndAlso L_acty <> tmp.t_acty Then
              xx = SIS.CT.DelayStatus30Days.GetActivity(tmp, tmp1)
              L_acty = tmp.t_acty
            End If
            With xx
              .Initialized = True
              If tmp.CountMark > 0 Then .IsCurrent = True
              .CountAll = tmp.CountAll
              .CountFinished = tmp.CountFinished
              .CountStarted = tmp.CountStarted
              If .CountStarted > 0 Then .Started = True
              If .CountAll = .CountFinished Then .Finished = True
              If .Started Then .StartDelay = tmp.StartedDelay Else .StartDelay = tmp.NotStartedDelay
              If .Finished Then .FinishDelay = tmp.FinishedDelay Else .FinishDelay = tmp.NotFinishedDelay
            End With
          End While
          Reader.Close()
          If tmp1 IsNot Nothing Then
            Results.Add(tmp1)
          End If
        End Using
      End Using
      'Update SelfDelay
      For Each x As SIS.CT.DelayStatus30Days In Results
        x.Design.SelfStartDelay = x.Design.StartDelay
        x.Design.SelfFinishDelay = x.Design.FinishDelay
        x.Indt.SelfStartDelay = x.Indt.StartDelay - x.Design.StartDelay
        x.Indt.SelfFinishDelay = x.Indt.FinishDelay - x.Design.FinishDelay
        x.RfqToPO.SelfStartDelay = x.RfqToPO.StartDelay - x.Indt.StartDelay
        x.RfqToPO.SelfFinishDelay = x.RfqToPO.FinishDelay - x.Indt.FinishDelay
        x.Mfg.SelfStartDelay = x.Mfg.StartDelay - x.RfqToPO.StartDelay
        x.Mfg.SelfFinishDelay = x.Mfg.FinishDelay - x.RfqToPO.FinishDelay
        x.Disp.SelfStartDelay = x.Disp.StartDelay - x.Mfg.StartDelay
        x.Disp.SelfFinishDelay = x.Disp.FinishDelay - x.Mfg.FinishDelay
        x.Recpt.SelfStartDelay = x.Recpt.StartDelay - x.Disp.StartDelay
        x.Recpt.SelfFinishDelay = x.Recpt.FinishDelay - x.Disp.FinishDelay
        x.Erec.SelfStartDelay = x.Erec.StartDelay - x.Recpt.StartDelay
        x.Erec.SelfFinishDelay = x.Erec.FinishDelay - x.Recpt.FinishDelay
      Next
      '================
      Return Results
    End Function

    Public Shared Function SelectIrefs(ByVal t_cprj As String) As List(Of SIS.CT.DelayStatus30Days)
      Dim actAry As Array = {"DESIGN", "INDT", "RFQ-TO-PO", "MFG", "EREC", "OTHERS"}
      Dim othAct As String = "('DISP','RECPT')"
      Dim Results As List(Of SIS.CT.DelayStatus30Days) = Nothing
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '1. Select ItemReferences fall in last 30 Days
        Sql &= " select distinct t_sub1  "
        Sql &= "  from ttpisg220200 "
        Sql &= "  where t_cprj='" & t_cprj & "'"
        Sql &= "  and t_acty <> 'PARENT' "
        Sql &= "  and ( "
        Sql &= " (t_sdst between dateadd(d,-30,getdate()) and getdate())  "
        Sql &= " or  "
        Sql &= " (t_sdfn between dateadd(d,-30,getdate()) and getdate()) "
        Sql &= "  ) "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.DelayStatus30Days)()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As SIS.CT.DelayStatus30Days = New SIS.CT.DelayStatus30Days(Reader)
            tmp.t_cprj = t_cprj
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
        '2. Mark current Activity of Item as per schedule
        Sql = ""
        For Each x As SIS.CT.DelayStatus30Days In Results
          Sql = ""
          Sql &= " select distinct t_acty  "
          Sql &= "  from ttpisg220200  "
          Sql &= "  where t_cprj='" & t_cprj & "'"
          Sql &= "  and t_sub1='" & x.t_sub1 & "'"
          Sql &= "  and t_acty in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC') "
          Sql &= "  and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) "
          Sql &= "  union all "
          Sql &= "  select distinct 'OTHERS' as t_acty  "
          Sql &= "  from ttpisg220200  "
          Sql &= "  where t_cprj='" & t_cprj & "'"
          Sql &= "  and t_sub1='" & x.t_sub1 & "'"
          Sql &= "  and t_acty in " & othAct
          Sql &= "  and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) "
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Select Case Reader("t_acty")
                Case "DESIGN"
                  x.Design.IsCurrent = True
                Case "INDT"
                  x.Indt.IsCurrent = True
                Case "RFQ-TO-PO"
                  x.RfqToPO.IsCurrent = True
                Case "MFG"
                  x.Mfg.IsCurrent = True
                Case "EREC"
                  x.Erec.IsCurrent = True
                Case "OTHERS"
                  x.Others.IsCurrent = True
              End Select
            End While
            Reader.Close()
          End Using
          '3. Update Started=>any one started, Finished=>All Finished for each activity of Item
          For Each act As String In actAry
            Dim xx As activityType = Nothing
            Select Case act
              Case "DESIGN"
                xx = x.Design
              Case "INDT"
                xx = x.Indt
              Case "RFQ-TO-PO"
                xx = x.RfqToPO
              Case "MFG"
                xx = x.Mfg
              Case "EREC"
                xx = x.Erec
              Case "OTHERS"
                xx = x.Others
            End Select
            Sql = ""
            Sql &= "  select distinct "
            Sql &= "  (select top 1 t_cact from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1) as t_cact, "
            Sql &= "  (select IsNull(count(*),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1  "
            If act <> "OTHERS" Then
              Sql &= "  and bb.t_acty = aa.t_acty  "
            Else
              Sql &= "  and bb.t_acty in " & othAct
            End If
            Sql &= "  and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            Sql &= "  ) as CountAll, "
            Sql &= "  (select IsNull(count(*),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and year(bb.t_acsd)>1753) as CountStarted, "
            Sql &= "  (select IsNull(count(*),0) from ttpisg220200 as bb where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 and bb.t_acty = aa.t_acty and year(bb.t_acfn)>1753) as CountFinished  "
            Sql &= "  from ttpisg220200 as aa "
            Sql &= "  where aa.t_cprj='" & x.t_cprj & "'"
            Sql &= "  and aa.t_sub1='" & x.t_sub1 & "'"
            If act <> "OTHERS" Then
              Sql &= "  and aa.t_acty = '" & act & "'"
            Else
              Sql &= "  and aa.t_acty in " & othAct
            End If
            Sql &= "  and LEFT(UPPER(aa.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = Sql
              Dim Reader As SqlDataReader = Cmd.ExecuteReader()
              While (Reader.Read())
                x.t_cact = Reader("t_cact")
                xx.CountAll = Reader("CountAll")
                xx.CountStarted = Reader("CountStarted")
                xx.CountFinished = Reader("CountFinished")
                If xx.CountStarted > 0 Then xx.Started = True
                If xx.CountAll = xx.CountFinished Then xx.Finished = True
              End While
              Reader.Close()
            End Using
            '4. Get Start and Finish Delay
            Sql = ""
            Sql &= " select distinct "
            Sql &= "  (select min(bb.t_dela) from ttpisg220200 as bb  "
            Sql &= "   where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1 "
            If act <> "OTHERS" Then
              Sql &= "  and bb.t_acty = aa.t_acty "
            Else
              Sql &= "  and bb.t_acty in " & othAct
            End If
            Sql &= "   and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            If Not xx.Started Then
              Sql &= "   and bb.t_otsd = (select min(cc.t_otsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1  "
            Else
              Sql &= "   and bb.t_acsd = (select min(cc.t_acsd) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1  "
              Sql &= "   and YEAR(cc.t_acsd)>1753 "
            End If
            If act <> "OTHERS" Then
              Sql &= "  and cc.t_acty = bb.t_acty "
            Else
              Sql &= "  and cc.t_acty in " & othAct
            End If
            Sql &= "    and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            Sql &= "   )) as StartDelay, "
            Sql &= "  (select max(bb.t_delf) from ttpisg220200 as bb  "
            Sql &= "   where bb.t_cprj=aa.t_cprj and bb.t_sub1=aa.t_sub1  "
            If act <> "OTHERS" Then
              Sql &= "  and bb.t_acty = aa.t_acty "
            Else
              Sql &= "  and bb.t_acty in " & othAct
            End If
            Sql &= "   and LEFT(UPPER(bb.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            If Not xx.Finished Then
              Sql &= "   and bb.t_oted = (select max(cc.t_oted) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1  "
            Else
              Sql &= "   and bb.t_acfn = (select max(cc.t_acfn) from ttpisg220200 as cc where cc.t_cprj=bb.t_cprj and cc.t_sub1=bb.t_sub1  "
              Sql &= "   and YEAR(cc.t_acfn)>1753 "
            End If
            If act <> "OTHERS" Then
              Sql &= "  and cc.t_acty = bb.t_acty "
            Else
              Sql &= "  and cc.t_acty in " & othAct
            End If
            Sql &= "    and LEFT(UPPER(cc.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            Sql &= "   )) as FinishDelay "
            Sql &= "   from ttpisg220200 as aa "
            Sql &= "  where aa.t_cprj='" & x.t_cprj & "'"
            Sql &= "  and aa.t_sub1='" & x.t_sub1 & "'"
            If act <> "OTHERS" Then
              Sql &= "  and aa.t_acty = '" & act & "'"
            Else
              Sql &= "  and aa.t_acty in " & othAct
            End If
            Sql &= "  and LEFT(UPPER(aa.t_desc),30) != 'GETTING MANUFACTURING SCHEDULE' "
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = Sql
              Dim Reader As SqlDataReader = Cmd.ExecuteReader()
              While (Reader.Read())
                xx.StartDelay = Reader("StartDelay")
                xx.FinishDelay = Reader("FinishDelay")
              End While
              Reader.Close()
            End Using
          Next ' Activity
        Next ' Item Reference
      End Using
      'Update SelfDelay
      For Each x As SIS.CT.DelayStatus30Days In Results
        x.Design.SelfStartDelay = x.Design.StartDelay
        x.Design.SelfFinishDelay = x.Design.FinishDelay
        x.Indt.SelfStartDelay = x.Indt.StartDelay - x.Design.StartDelay
        x.Indt.SelfFinishDelay = x.Indt.FinishDelay - x.Design.FinishDelay
        x.RfqToPO.SelfStartDelay = x.RfqToPO.StartDelay - x.Indt.StartDelay
        x.RfqToPO.SelfFinishDelay = x.RfqToPO.FinishDelay - x.Indt.FinishDelay
        x.Mfg.SelfStartDelay = x.Mfg.StartDelay - x.RfqToPO.StartDelay
        x.Mfg.SelfFinishDelay = x.Mfg.FinishDelay - x.RfqToPO.FinishDelay
        x.Others.SelfStartDelay = x.Others.StartDelay - x.Mfg.StartDelay
        x.Others.SelfFinishDelay = x.Others.FinishDelay - x.Mfg.FinishDelay
        x.Erec.SelfStartDelay = x.Erec.StartDelay - x.Others.StartDelay
        x.Erec.SelfFinishDelay = x.Erec.FinishDelay - x.Others.FinishDelay
      Next
      '================
      Return Results
    End Function

    Public Shared Function GetPredRows(ByVal t_cprj As String, ByVal t_cact As String, ByVal Indent As Integer, ByVal Prefix As String) As String
      Dim mRet As String = ""

      Dim CACTs As List(Of SIS.CT.DelayStatus30Days.Activities) = GetChildActivities(t_cprj, t_cact)
      For Each cact As SIS.CT.DelayStatus30Days.Activities In CACTs
        Dim tr As TableRow = GetRow(Indent, cact, Prefix)
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim hw As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(sw)
        tr.RenderControl(hw)
        mRet &= IIf(mRet <> "", "##" & sb.ToString(), sb.ToString)
      Next
      Return mRet
    End Function

    Private Shared Function GetRow(ByVal Indent As Integer, ByVal dt As SIS.CT.DelayStatus30Days.Activities, ByVal Prefix As String, Optional ByVal IsServerCall As Boolean = False) As TableRow
      Dim CACTs As Integer = GetChildActivitiesCount(dt.t_cprj, dt.t_cact)
      If CACTs = 0 Then
        dt.Bottom = True
        dt.Top = False
        dt.Middle = False
      Else
        If Indent > 0 Then
          dt.Middle = True
          dt.Top = False
          dt.Bottom = False
        End If
      End If

      Indent += 1
      '=============
      'Render Row
      Dim tr As TableRow = Nothing
      Dim td As TableCell = Nothing
      tr = New TableRow
      'tr.TableSection = TableRowSection.TableBody
      tr.ClientIDMode = ClientIDMode.Static
      tr.ID = Prefix & "_" & dt.t_cact
      tr.Attributes.Add("onclick", "return tree_toggle(this);")
      tr.Attributes.Add("data-state", "table-row")
      tr.Attributes.Add("data-expended", "0")
      tr.Attributes.Add("data-indent", Indent)
      tr.Attributes.Add("data-bottom", CACTs)
      tr.Attributes.Add("data-loaded", "0")
      tr.Attributes.Add("data-activity", dt.t_cact)
      If Indent = 1 Then
        tr.Attributes.Add("style", "display:table-row;")
      Else
        tr.Attributes.Add("style", "display:none;")
      End If
      tr.CssClass = "treeRow"

      For I As Integer = 1 To 14
        td = New TableCell
        With td
          If Not dt.IsDue Then
            .CssClass = "btn-outline-secondary"
          Else
            If Not dt.IsCurrent Then
              If dt.IsStarted And dt.IsFinished Then
                .CssClass = "btn-outline-success"
              ElseIf dt.IsStarted And Not dt.IsFinished Then
                .CssClass = "btn-outline-info"
              Else
                .CssClass = "btn-outline-danger"
              End If
            Else
              If dt.IsStarted And dt.IsFinished Then
                .CssClass = "btn-success"
              ElseIf dt.IsStarted And Not dt.IsFinished Then
                .CssClass = "btn-info"
              Else
                .CssClass = "btn-danger"
              End If
            End If
          End If

          Select Case I
            Case 0
              .Text = dt.SubItem
            Case 2
              .Text = dt.t_sub1
              .Attributes.Add("style", "text-align:left;min-height:24px !important;")
            Case 1
              td.CssClass = ""
              Dim xTbl As New Table
              With xTbl
                .Attributes.Add("style", "border-collapse:collapse;border:none;")
              End With
              Dim xTr As New TableRow
              Dim xTd As New TableCell
              For imgs As Integer = 1 To Indent
                xTd = New TableCell
                xTd.Attributes.Add("style", "border-collapse:collapse;border:none;")

                Dim mg As New Image
                With mg
                  .AlternateText = dt.t_cact
                  If imgs = Indent Then
                    If CACTs > 0 Then
                      If IsServerCall Then
                        .ImageUrl = "~/TreeImgs/Plus.gif"
                      Else
                        .ImageUrl = "../../WebMapp1/TreeImgs/Plus.gif"
                      End If
                      mg.ClientIDMode = ClientIDMode.Static
                      mg.ID = "img_" & tr.ID
                      mg.Attributes.Add("onclick", "return tree_chkreload(this);")
                      xTd.Controls.Add(mg)
                      xTr.Cells.Add(xTd)
                    End If
                  ElseIf imgs = Indent - 1 Then
                    If IsServerCall Then
                      .ImageUrl = "~/TreeImgs/LineTopMidBottom.gif"
                    Else
                      .ImageUrl = "../../WebMapp1/TreeImgs/LineTopMidBottom.gif"
                    End If
                    xTd.Controls.Add(mg)
                    xTr.Cells.Add(xTd)
                  Else
                    If IsServerCall Then
                      .ImageUrl = "~/TreeImgs/LineTopBottom.gif"
                    Else
                      .ImageUrl = "../../WebMapp1/TreeImgs/LineTopBottom.gif"
                    End If
                    xTd.Controls.Add(mg)
                    xTr.Cells.Add(xTd)
                  End If
                End With
              Next
              xTd = New TableCell
              xTd.Attributes.Add("style", "border-collapse:collapse;border:none;cursor:pointer;")

              xTd.Text = dt.t_desc
              xTr.Cells.Add(xTd)
              xTbl.Rows.Add(xTr)
              td.Controls.Add(xTbl)
            Case 3
              .Text = dt.t_dela
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.t_delf
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.t_pprc.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.t_cpgv.ToString("n")
              .Attributes.Add("style", "text-align:center;")
            Case 7
              .Text = dt.t_drem
            Case 8
              .Text = dt.t_sdst
            Case 9
              .Text = dt.t_sdfn
            Case 10
              .Text = dt.t_acsd
            Case 11
              .Text = dt.t_acfn
            Case 12
              .Text = dt.t_otsd
            Case 13
              .Text = dt.t_oted
            Case 14
              .Text = dt.t_dept
          End Select
        End With
        tr.Cells.Add(td)
      Next
      Return tr
    End Function


    Public Shared Function GetPredCell(ByVal t_cprj As String, ByVal t_cact As String) As TableCell
      'Main Function Call For activity
      Dim mRet As New TableCell
      Dim CACTs As List(Of SIS.CT.DelayStatus30Days.Activities) = GetChildActivities(t_cprj, t_cact)
      If CACTs.Count <= 0 Then
        Return mRet
      End If
      Dim tbl As New Table
      With tbl
        .Width = Unit.Percentage(100)
        .Style.Add(HtmlTextWriterStyle.Margin, "2px 2px 2px 2px")
        .ClientIDMode = ClientIDMode.Static
        .ID = t_cact
        .Attributes.Add("data-project", t_cprj)
      End With
      '===================
      'Write Header
      Dim th As New TableHeaderRow
      Dim btn As Button = Nothing
      'th.Attributes.Add("style", "background-color:black;color:white;font-size:14px;")
      th.TableSection = TableRowSection.TableHeader
      For i As Integer = 0 To 13
        Dim thc As New TableHeaderCell
        With thc
          .Attributes.Add("style", "text-align:center;")
          .CssClass = "bg-info"

          Select Case i
            Case 0
              .Text = "PREDCESSOR"
            Case 1
              .Text = "ITEM"
            Case 2
              .Text = "START DELAY"
            Case 3
              .Text = "FINISH DELAY"
            Case 4
              .Text = "PLN. %"
            Case 5
              .Text = "ACT. %"
            Case 6
              .Text = "DELAY TYPE"
            Case 7
              .Text = "SCHD. START"
            Case 8
              .Text = "SCHD. FINISH"
            Case 9
              .Text = "ACT. START"
            Case 10
              .Text = "ACT. FINISH"
            Case 11
              .Text = "OL. START"
            Case 12
              .Text = "OL. FINISH"
            Case 13
              .Text = "DEPTT"
          End Select
          th.Cells.Add(thc)
        End With
      Next
      tbl.Rows.Add(th)

      '===================
      Dim Indent As Integer = 0
      For Each cact As SIS.CT.DelayStatus30Days.Activities In CACTs
        cact.Top = True
        tbl.Rows.Add(GetRow(Indent, cact, t_cact, True))
      Next
      mRet.Controls.Add(tbl)
      Return mRet
    End Function

    'Private Shared Sub RenderCACT(ByVal Indent As Integer, ByVal dt As SIS.CT.DelayStatus30Days.Activities, ByRef tbl As Table, ByVal Prefix As String)
    '  Dim CACTs As List(Of SIS.CT.DelayStatus30Days.Activities) = GetChildActivities(dt.t_cprj, dt.t_cact)
    '  If CACTs.Count = 0 Then
    '    dt.Bottom = True
    '    dt.Top = False
    '    dt.Middle = False
    '  Else
    '    If Indent > 0 Then
    '      dt.Middle = True
    '      dt.Top = False
    '      dt.Bottom = False
    '    End If
    '  End If

    '  Indent += 1
    '  '=============
    '  'Render Row
    '  Dim tr As TableRow = Nothing
    '  Dim td As TableCell = Nothing
    '  tr = New TableRow
    '  'tr.TableSection = TableRowSection.TableBody
    '  tr.ClientIDMode = ClientIDMode.Static
    '  tr.ID = Prefix & "_" & dt.t_cact
    '  tr.Attributes.Add("onclick", "return tree_toggle(this);")
    '  tr.Attributes.Add("data-state", "table-row")
    '  tr.Attributes.Add("data-expended", "0")
    '  tr.Attributes.Add("data-indent", Indent)
    '  tr.Attributes.Add("data-bottom", CACTs.Count)
    '  tr.Attributes.Add("data-loaded", "0")
    '  If Indent = 1 Then
    '    tr.Attributes.Add("style", "display:table-row;")
    '  Else
    '    tr.Attributes.Add("style", "display:none;")
    '  End If
    '  tr.CssClass = "treeRow"

    '  For I As Integer = 2 To 13
    '    td = New TableCell
    '    With td

    '      '.ClientIDMode = ClientIDMode.Static
    '      '.ID = dt.t_cact

    '      If Not dt.IsDue Then
    '        .CssClass = "btn-outline-secondary"
    '      Else
    '        If Not dt.IsCurrent Then
    '          If dt.IsStarted And dt.IsFinished Then
    '            .CssClass = "btn-outline-success"
    '          ElseIf dt.IsStarted And Not dt.IsFinished Then
    '            .CssClass = "btn-outline-info"
    '          Else
    '            .CssClass = "btn-outline-danger"
    '          End If
    '        Else
    '          If dt.IsStarted And dt.IsFinished Then
    '            .CssClass = "btn-success"
    '          ElseIf dt.IsStarted And Not dt.IsFinished Then
    '            .CssClass = "btn-info"
    '          Else
    '            .CssClass = "btn-danger"
    '          End If
    '        End If
    '      End If

    '      Select Case I
    '        Case 0
    '          .Text = dt.t_sub1
    '          .Attributes.Add("style", "text-align:left;min-height:24px !important;")
    '        Case 1
    '          .Text = dt.SubItem
    '        Case 2
    '          td.CssClass = ""
    '          Dim xTbl As New Table
    '          With xTbl
    '            .Attributes.Add("style", "border-collapse:collapse;border:none;")
    '          End With
    '          Dim xTr As New TableRow
    '          Dim xTd As New TableCell
    '          For imgs As Integer = 1 To Indent
    '            xTd = New TableCell
    '            xTd.Attributes.Add("style", "border-collapse:collapse;border:none;")

    '            Dim mg As New Image
    '            With mg
    '              .AlternateText = dt.t_cact
    '              If imgs = Indent Then
    '                If CACTs.Count > 0 Then
    '                  .ImageUrl = "~/TreeImgs/Plus.gif"
    '                  mg.ClientIDMode = ClientIDMode.Static
    '                  mg.ID = "img_" & tr.ID
    '                  mg.Attributes.Add("onclick", "return tree_refresh(this);")
    '                  xTd.Controls.Add(mg)
    '                  xTr.Cells.Add(xTd)
    '                End If
    '              ElseIf imgs = Indent - 1 Then
    '                .ImageUrl = "~/TreeImgs/LineTopMidBottom.gif"
    '                xTd.Controls.Add(mg)
    '                xTr.Cells.Add(xTd)
    '              Else
    '                .ImageUrl = "~/TreeImgs/LineTopBottom.gif"
    '                xTd.Controls.Add(mg)
    '                xTr.Cells.Add(xTd)
    '              End If
    '            End With
    '          Next
    '          xTd = New TableCell
    '          xTd.Attributes.Add("style", "border-collapse:collapse;border:none;")

    '          xTd.Text = dt.t_desc
    '          xTr.Cells.Add(xTd)
    '          xTbl.Rows.Add(xTr)
    '          td.Controls.Add(xTbl)
    '          '.Text = dt.t_desc
    '        '.Style.Add(HtmlTextWriterStyle.PaddingLeft, Indent * 20 & "px")
    '        Case 3
    '          .Text = dt.t_dela
    '          .Attributes.Add("style", "text-align:center;")
    '        Case 4
    '          .Text = dt.t_delf
    '          .Attributes.Add("style", "text-align:center;")
    '        Case 5
    '          .Text = dt.t_pprc.ToString("n")
    '          .Attributes.Add("style", "text-align:center;")
    '        Case 6
    '          .Text = dt.t_cpgv.ToString("n")
    '          .Attributes.Add("style", "text-align:center;")
    '        Case 7
    '          .Text = dt.t_drem
    '        Case 8
    '          .Text = dt.t_sdst
    '        Case 9
    '          .Text = dt.t_sdfn
    '        Case 10
    '          .Text = dt.t_acsd
    '        Case 11
    '          .Text = dt.t_acfn
    '        Case 12
    '          .Text = dt.t_otsd
    '        Case 13
    '          .Text = dt.t_oted
    '      End Select
    '    End With
    '    tr.Cells.Add(td)
    '  Next
    '  tbl.Rows.Add(tr)
    '  '=============
    '  'For Each tmp As SIS.CT.DelayStatus30Days.Activities In CACTs
    '  '  RenderCACT(Indent, tmp, tbl, Prefix & "_" & dt.t_cact)
    '  'Next
    'End Sub
    Private Shared Function GetChildActivities(ByVal t_cprj As String, ByVal t_cact As String) As List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Results As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing

      Dim Sql As String = ""

      Sql &= " select distinct t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,t_drem, t_dela, t_delf,t_otsd,t_oted, t_pprc,t_cpgv,t_acty, t_dept "
      Sql &= " from ttpisg220200  "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Sql &= " and t_cact in (select distinct t_pact from ttpisg247200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
      Sql &= " order by t_cact "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.DelayStatus30Days.Activities)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.DelayStatus30Days.Activities(Reader)
            With tmp
              Try
                If Convert.ToDateTime(tmp.t_sdst) > Now Then tmp.IsDue = False Else tmp.IsDue = True
                If Year(Convert.ToDateTime(tmp.t_acsd)) > 1753 Then tmp.IsStarted = True
                If Year(Convert.ToDateTime(tmp.t_acfn)) > 1753 Then tmp.IsFinished = True
              Catch ex As Exception
              End Try
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Private Shared Function GetChildActivitiesCount(ByVal t_cprj As String, ByVal t_cact As String) As Integer
      Dim Results As Integer = 0
      Dim Sql As String = ""
      Sql &= " select isnull(count(*),null) as cnt "
      Sql &= " from ttpisg220200  "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Sql &= " and t_cact in (select distinct t_pact from ttpisg247200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "')"
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

    Public Sub New()
    End Sub
  End Class
End Namespace