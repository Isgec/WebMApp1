Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class IrefDelayDays
    Public Property D_s_delay As Decimal = 0
    Public Property D_f_delay As Decimal = 0
    Public Property I_s_delay As Decimal = 0
    Public Property I_f_delay As Decimal = 0
    Public Property R_s_delay As Decimal = 0
    Public Property R_f_delay As Decimal = 0
    Public Property M_s_delay As Decimal = 0
    Public Property M_f_delay As Decimal = 0
    Public Property E_s_delay As Decimal = 0
    Public Property E_f_delay As Decimal = 0
    Public Property O_s_delay As Decimal = 0
    Public Property O_f_delay As Decimal = 0
    Public Property D_t_s As String = ""
    Public Property D_t_f As String = ""
    Public Property I_t_s As String = ""
    Public Property I_t_f As String = ""
    Public Property R_t_s As String = ""
    Public Property R_t_f As String = ""
    Public Property M_t_s As String = ""
    Public Property M_t_f As String = ""
    Public Property E_t_s As String = ""
    Public Property E_t_f As String = ""
    Public Property O_t_s As String = ""
    Public Property O_t_f As String = ""
    Public Property t_sub1 As String = 0
    Public Property t_cact As String = ""
    Public Property t_cprj As String = ""
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
    Public ReadOnly Property GetRedirectLink As String
      Get
        Return "~/CT_mMain/App_Forms/mGctActivityList.aspx?t_cprj=" & t_cprj & "&t_cact=" & t_cact
      End Get
    End Property
    Public Shared Function SelectListItemRefWiseDelay30d(ByVal t_cprj As String) As List(Of SIS.CT.IrefDelayDays)
      Dim Results As List(Of SIS.CT.IrefDelayDays) = Nothing
      Dim Sql As String = ""
      Sql &= " select distinct t_sub1, t_cprj, "
      Sql &= " (select top 1 t_cact          from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate()))  and t_cact is not null) as t_cact,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN') as D_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN') as D_f_delay,"
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN' and t_dela = (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN')) as D_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN' and t_delf = (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='DESIGN')) as D_t_f,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT') as I_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT') as I_f_delay,"
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT' and t_dela = (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT') ) as I_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT' and t_delf = (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='INDT') ) as I_t_f, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO') as R_s_delay, "
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO') as R_f_delay, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO' and t_dela =(select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO')) as R_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO' and t_delf =(select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='RFQ-TO-PO')) as R_t_f, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG') as M_s_delay, "
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG') as M_f_delay, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG' and t_dela=(select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG')) as M_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG' and t_delf=(select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='MFG')) as M_t_f, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC') as E_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC') as E_f_delay,"
      Sql &= " (select top 1 (case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC' and t_dela=(select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC')) as E_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC' and t_delf=(select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty='EREC')) as E_t_f, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC')) as O_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC')) as O_f_delay, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC') and t_dela=(select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC'))) as O_t_s, "
      Sql &= " (select top 1(case when year(t_acsd)>1753 and year(t_acfn)>1753 then 3 else (case when year(t_acsd)>1753 and year(t_acfn)=1753 then 2 else 1 end) end) as D_t  from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC') and t_delf=(select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate())) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC'))) as O_t_f  "
      Sql &= " from ttpisg220200 as aa"
      Sql &= " where t_cprj='" & t_cprj & "' "
      Sql &= " and ((t_sdst between dateadd(d,-30,getdate()) and getdate()) or (t_sdfn between dateadd(d,-30,getdate()) and getdate()))"
      Sql &= " and (t_dela > 0 or t_delf>0)"
      Sql &= " order by t_sub1"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.IrefDelayDays)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.IrefDelayDays(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectListItemRefWiseDelayAll(ByVal t_cprj As String) As List(Of SIS.CT.IrefDelayDays)
      Dim Results As List(Of SIS.CT.IrefDelayDays) = Nothing
      If t_cprj = "" Then Return Results
      Dim Period As SIS.CT.tpisg216.ProjectPeriod = SIS.CT.tpisg216.StartFinish(t_cprj)
      Dim s_date As String = Period.StDt.ToString("dd/MM/yyyy")
      Dim t_date As String = Now.AddDays(-31).ToString("dd/MM/yyyy")
      Dim Sql As String = ""
      Sql &= " select distinct t_sub1, t_cprj, "
      Sql &= " (select top 1 t_cact          from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)))  and t_cact is not null) as t_cact,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='DESIGN') as D_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='DESIGN') as D_f_delay,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='INDT') as I_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='INDT') as I_f_delay,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='RFQ-TO-PO') as R_s_delay, "
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='RFQ-TO-PO') as R_f_delay, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='MFG') as M_s_delay, "
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='MFG') as M_f_delay, "
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='EREC') as E_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty='EREC') as E_f_delay,"
      Sql &= " (select isnull(max(t_dela),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC')) as O_s_delay,"
      Sql &= " (select isnull(max(t_delf),0) from ttpisg220200 as bb where bb.t_sub1=aa.t_sub1 and bb.t_cprj=aa.t_cprj and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103))) and t_acty not in ('DESIGN','INDT','RFQ-TO-PO','MFG','EREC')) as O_f_delay "
      Sql &= " from ttpisg220200 as aa"
      Sql &= " where t_cprj='" & t_cprj & "' "
      Sql &= " and ((t_sdst between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)) or (t_sdfn between convert(datetime,'" & s_date & "', 103) and convert(datetime,'" & t_date & "', 103)))"
      Sql &= " and (t_dela > 0 or t_delf>0)"
      Sql &= " order by t_sub1"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.IrefDelayDays)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.IrefDelayDays(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
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