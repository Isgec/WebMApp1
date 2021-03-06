﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class Ageing
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
    Public Property EARLY As Double = 0
    Public Property DELAY0 As Double = 0
    Public Property DELAY10 As Double = 0
    Public Property DELAY20 As Double = 0
    Public Property DELAY30 As Double = 0
    Public Property DELAYZZ As Double = 0

    Public Shared Function OverallActivity(ByVal t_cprj As String, ByVal ID As String) As List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Results As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      Dim NoParent As Boolean = False

      Select Case ID
        Case "STE", "ST0", "ST10", "ST20", "ST30", "STZ", "NST0", "NST10", "NST20", "NST30", "NSTZ", "FDE", "FD0", "FD10", "FD20", "FD30", "FDZ", "NFD0", "NFD10", "NFD20", "NFD30", "NFDZ"
          NoParent = True
      End Select
      Dim Sql As String = ""
      Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,t_drem, t_dela, t_delf,t_otsd,t_oted, t_pprc,t_cpgv,t_acty,t_dept,t_pact, t_outl,t_actp, "
      Sql &= " IsCurrent = case when ((t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (t_sdfn between dateadd(d,-30,getdate()) and getdate())) or ((t_sdst < dateadd(d,-30,getdate()))   and   (t_sdfn > getdate())) then 1 else 0 end, "

      Sql &= " (case ( "
      Sql &= "     select top 1 xx.t_cpgv  "
      Sql &= " 	from ttpisg220200 as xx "
      Sql &= " 	where xx.t_cprj='" & t_cprj & "' "
      Sql &= " 	and xx.t_cact = (select top 1 yy.t_pact from ttpisg221200 as yy "
      Sql &= " 	where yy.t_cprj='" & t_cprj & "' "
      Sql &= " 	and yy.t_cact=zz.t_cact)) "
      Sql &= "  when 100 then 1 else 0 end) as PredClosed, "


      Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub4 from ttpisg243200 as aa where aa.t_cprd=zz.t_pcod and aa.t_iref=zz.t_sub1 and aa.t_sitm=zz.t_sitm ) as SubItem "
      Sql &= " from ttpisg220200 as zz "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Sql &= " and t_acty <> 'PARENT' "

      Select Case ID
        Case "STE"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end "
        Case "ST0"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "ST10"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end "
        Case "ST20"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end "
        Case "ST30"
          Sql &= "and t_sdst <=  convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end "
        Case "STZ"
          Sql &= "and t_sdst <=  convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end "
        Case "NST0"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "NST10"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end "
        Case "NST20"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end "
        Case "NST30"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end "
        Case "NSTZ"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end "
        Case "FDE"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end "
        Case "FD0"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "FD10"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end "
        Case "FD20"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end "
        Case "FD30"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end "
        Case "FDZ"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end "
        Case "NFD0"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "NFD10"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end "
        Case "NFD20"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end "
        Case "NFD30"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end "
        Case "NFDZ"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end "
      End Select
      Sql &= " order by t_actp "

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
                tmp.ShowPred = True
              Catch ex As Exception
              End Try
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      If NoParent Then Return Results
      '===========================================
      'Process List to Include Parent As Per Logic
      '===========================================
      Dim NewResults As New List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Last_t_pact As String = ""
      Dim ADDED As Boolean = False

      For Each tmp As SIS.CT.DelayStatus30Days.Activities In Results
        If Last_t_pact = "" Then
          Last_t_pact = tmp.t_pact
        End If
        If Last_t_pact <> tmp.t_pact Then
          Last_t_pact = tmp.t_pact
          ADDED = False
        End If
        Select Case tmp.t_acty
          Case "DESIGN"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, True, 0)
            ADDED = True
          Case "INDT"
            'Parent NOT to be loaded
            'If Not ADDED Then InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case "RFQ-TO-PO"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case Else
            If Not ADDED Then
              If tmp.SubItem <> "" Then
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 2)
              Else
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
              End If
            End If
            ADDED = True
        End Select
      Next
      Results.AddRange(NewResults)
      '===========================================
      Return Results
    End Function

    Public Shared Function OverallFinished(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OverallNOTFinished(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function OverallStarted(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <=  convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <=  convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end) as DELAYZZ"

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OverallNOTStarted(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "'"
      Sql &= "and t_acty <> 'PARENT' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

#Region "  Activity Type Wise Ageing Last 30 Days "
    Public Shared Function ActyFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 10  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 11 and 20  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 21 and 30  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf > 30  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ActyNOTFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 10  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 11 and 20  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 21 and 30  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf > 30  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ActyStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 10  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 11 and 20  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 21 and 30  then 1 else 0 end) as DELAY30"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ActyNOTStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 10  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 11 and 20  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 21 and 30  then 1 else 0 end) as DELAY30"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ActyActivity(ByVal t_cprj As String, ByVal t_acty As String, ByVal ID As String) As List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Results As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      Dim NoParent As Boolean = False

      Select Case ID
        Case "STE", "ST0", "ST10", "ST20", "ST30", "STZ", "NST0", "NST10", "NST20", "NST30", "NSTZ", "FDE", "FD0", "FD10", "FD20", "FD30", "FDZ", "NFD0", "NFD10", "NFD20", "NFD30", "NFDZ"
          NoParent = True
      End Select

      Dim Sql As String = ""
      Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,t_drem, t_dela, t_delf,t_otsd,t_oted, t_pprc,t_cpgv,t_acty,t_dept,t_pact, t_outl,t_actp, "
      Sql &= " IsCurrent = case when ((t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (t_sdfn between dateadd(d,-30,getdate()) and getdate())) or ((t_sdst < dateadd(d,-30,getdate()))   and   (t_sdfn > getdate())) then 1 else 0 end, "

      Sql &= " (case ( "
      Sql &= "     select top 1 xx.t_cpgv  "
      Sql &= " 	from ttpisg220200 as xx "
      Sql &= " 	where xx.t_cprj='" & t_cprj & "' "
      Sql &= " 	and xx.t_cact = (select top 1 yy.t_pact from ttpisg221200 as yy "
      Sql &= " 	where yy.t_cprj='" & t_cprj & "' "
      Sql &= " 	and yy.t_cact=zz.t_cact)) "
      Sql &= "  when 100 then 1 else 0 end) as PredClosed, "


      Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=zz.t_pcod and aa.t_iref=zz.t_sub1 and aa.t_sitm=zz.t_sitm ) as SubItem "
      Sql &= " from ttpisg220200 as zz  "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Sql &= " And (t_acty='" & t_acty & "' )"

      Select Case ID
        Case "STE", "ST0", "ST10", "ST20", "ST30", "STZ", "NST0", "NST10", "NST20", "NST30", "NSTZ"
          'Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      End Select
      Select Case ID
        Case "FDE", "FD0", "FD10", "FD20", "FD30", "FDZ", "NFD0", "NFD10", "NFD20", "NFD30", "NFDZ"
          'Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          Sql &= " and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      End Select

      Select Case ID
        Case "STE"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end "
        Case "ST0"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "ST10"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 10  then 1 else 0 end "
        Case "ST20"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 11 and 20  then 1 else 0 end "
        Case "ST30"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 21 and 30  then 1 else 0 end "
        Case "STZ"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >= 31  then 1 else 0 end "
        Case "NST0"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "NST10"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 10  then 1 else 0 end "
        Case "NST20"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 11 and 20  then 1 else 0 end "
        Case "NST30"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 21 and 30  then 1 else 0 end "
        Case "NSTZ"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >= 31  then 1 else 0 end "
        Case "FDE"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end "
        Case "FD0"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "FD10"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 10  then 1 else 0 end "
        Case "FD20"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 11 and 20  then 1 else 0 end "
        Case "FD30"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 21 and 30  then 1 else 0 end "
        Case "FDZ"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >= 31  then 1 else 0 end "
        Case "NFD0"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "NFD10"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 10  then 1 else 0 end "
        Case "NFD20"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 11 and 20  then 1 else 0 end "
        Case "NFD30"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 21 and 30  then 1 else 0 end "
        Case "NFDZ"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >= 31  then 1 else 0 end "
      End Select
      Sql &= " order by t_actp "

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
                tmp.ShowPred = True
              Catch ex As Exception
              End Try
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      If NoParent Then Return Results
      '===========================================
      'Process List to Include Parent As Per Logic
      '===========================================
      Dim NewResults As New List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Last_t_pact As String = ""
      Dim ADDED As Boolean = False

      For Each tmp As SIS.CT.DelayStatus30Days.Activities In Results
        If Last_t_pact = "" Then
          Last_t_pact = tmp.t_pact
        End If
        If Last_t_pact <> tmp.t_pact Then
          Last_t_pact = tmp.t_pact
          ADDED = False
        End If
        Select Case tmp.t_acty
          Case "DESIGN"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, True, 0)
            ADDED = True
          Case "INDT"
            'Parent NOT to be loaded
            'If Not ADDED Then InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case "RFQ-TO-PO"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case Else
            If Not ADDED Then
              If tmp.SubItem <> "" Then
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 2)
              Else
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
              End If
            End If
            ADDED = True
        End Select
      Next
      Results.AddRange(NewResults)
      '===========================================

      Return Results
    End Function

#End Region

#Region "  Activity Type Wise Ageing OverAll "
    Public Shared Function OAActyFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OAActyNOTFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdfn <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OAActyStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OAActyNOTStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.Ageing)
      Dim Results As List(Of SIS.CT.Ageing) = Nothing
      Dim t_date As String = IIf(AsOn = "", Now.ToString("dd/MM/yyyy"), AsOn)

      Dim Sql As String = ""
      Sql &= "select "
      Sql &= "(0) as EARLY,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end ) as DELAY0,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end) as DELAY10,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end) as DELAY20,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end) as DELAY30,"

      Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
      Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
      Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end) as DELAYZZ"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.Ageing)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.Ageing(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function OAActyActivity(ByVal t_cprj As String, ByVal t_acty As String, ByVal ID As String) As List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Results As List(Of SIS.CT.DelayStatus30Days.Activities) = Nothing
      Dim t_date As String = Now.ToString("dd/MM/yyyy")
      Dim NoParent As Boolean = False

      Select Case ID
        Case "STE", "ST0", "ST10", "ST20", "ST30", "STZ", "NST0", "NST10", "NST20", "NST30", "NSTZ", "FDE", "FD0", "FD10", "FD20", "FD30", "FDZ", "NFD0", "NFD10", "NFD20", "NFD30", "NFDZ"
          NoParent = True
      End Select

      Dim Sql As String = ""
      Sql &= " select t_cprj, t_cact, t_desc, t_sdst, t_acsd, t_sdfn, t_acfn, t_sub1,t_drem, t_dela, t_delf,t_otsd,t_oted, t_pprc,t_cpgv,t_acty,t_dept,t_pact, t_outl,t_actp, "
      Sql &= " IsCurrent = case when ((t_sdst between dateadd(d,-30,getdate()) and getdate())   or   (t_sdfn between dateadd(d,-30,getdate()) and getdate())) or ((t_sdst < dateadd(d,-30,getdate()))   and   (t_sdfn > getdate())) then 1 else 0 end, "

      Sql &= " (case ( "
      Sql &= "     select top 1 xx.t_cpgv  "
      Sql &= " 	from ttpisg220200 as xx "
      Sql &= " 	where xx.t_cprj='" & t_cprj & "' "
      Sql &= " 	and xx.t_cact = (select top 1 yy.t_pact from ttpisg221200 as yy "
      Sql &= " 	where yy.t_cprj='" & t_cprj & "' "
      Sql &= " 	and yy.t_cact=zz.t_cact)) "
      Sql &= "  when 100 then 1 else 0 end) as PredClosed, "


      Sql &= " (select aa.t_sub2 + ' ' + aa.t_sub3 + ' ' + aa.t_sub3 from ttpisg243200 as aa where aa.t_cprd=zz.t_pcod and aa.t_iref=zz.t_sub1 and aa.t_sitm=zz.t_sitm ) as SubItem "
      Sql &= " from ttpisg220200 as zz  "
      Sql &= " where t_cprj='" & t_cprj & "'"
      Sql &= " And (t_acty='" & t_acty & "' )"

      Select Case ID
        Case "STE", "ST0", "ST10", "ST20", "ST30", "STZ", "NST0", "NST10", "NST20", "NST30", "NSTZ"
          Sql &= "and t_sdst <= convert(datetime,'" & t_date & "',103)"
          'Sql &= " and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      End Select
      Select Case ID
        Case "FDE", "FD0", "FD10", "FD20", "FD30", "FDZ", "NFD0", "NFD10", "NFD20", "NFD30", "NFDZ"
          Sql &= " and t_sdfn <= convert(datetime,'" & t_date & "',103)"
          'Sql &= " and t_sdfn between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
      End Select

      Select Case ID
        Case "STE"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end "
        Case "ST0"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "ST10"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end "
        Case "ST20"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end "
        Case "ST30"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end "
        Case "STZ"
          Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end "
        Case "NST0"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela = 0  then 1 else 0 end "
        Case "NST10"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 1 and 30  then 1 else 0 end "
        Case "NST20"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 31 and 60  then 1 else 0 end "
        Case "NST30"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela between 61 and 90  then 1 else 0 end "
        Case "NSTZ"
          Sql &= "and 1 = case when t_acsd = convert(datetime,'01/01/1753',103) and t_dela >= 91  then 1 else 0 end "
        Case "FDE"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_acfn < t_sdfn then 1 else 0 end "
        Case "FD0"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "FD10"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end "
        Case "FD20"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end "
        Case "FD30"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end "
        Case "FDZ"
          Sql &= " and 1 = case when t_acfn > convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end "
        Case "NFD0"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf = 0  then 1 else 0 end "
        Case "NFD10"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 1 and 30  then 1 else 0 end "
        Case "NFD20"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 31 and 60  then 1 else 0 end "
        Case "NFD30"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf between 61 and 90  then 1 else 0 end "
        Case "NFDZ"
          Sql &= " and 1 = case when t_acfn = convert(datetime,'01/01/1753',103) and t_delf >= 91  then 1 else 0 end "
      End Select
      Sql &= " order by t_actp "

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
                tmp.ShowPred = True
              Catch ex As Exception
              End Try
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      If NoParent Then Return Results
      '===========================================
      'Process List to Include Parent As Per Logic
      '===========================================
      Dim NewResults As New List(Of SIS.CT.DelayStatus30Days.Activities)
      Dim Last_t_pact As String = ""
      Dim ADDED As Boolean = False

      For Each tmp As SIS.CT.DelayStatus30Days.Activities In Results
        If Last_t_pact = "" Then
          Last_t_pact = tmp.t_pact
        End If
        If Last_t_pact <> tmp.t_pact Then
          Last_t_pact = tmp.t_pact
          ADDED = False
        End If
        Select Case tmp.t_acty
          Case "DESIGN"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, True, 0)
            ADDED = True
          Case "INDT"
            'Parent NOT to be loaded
            'If Not ADDED Then InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case "RFQ-TO-PO"
            If Not ADDED Then SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
            ADDED = True
          Case Else
            If Not ADDED Then
              If tmp.SubItem <> "" Then
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 2)
              Else
                SIS.CT.DelayStatus30Days.InsertParents(NewResults, tmp.t_pact, tmp.t_cprj, False, 1)
              End If
            End If
            ADDED = True
        End Select
      Next
      Results.AddRange(NewResults)
      '===========================================

      Return Results
    End Function

#End Region

  End Class
End Namespace