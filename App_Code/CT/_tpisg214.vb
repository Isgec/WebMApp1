Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg214
    Public Property t_cprj As String = ""
    Public Property t_acty As String = ""
    Public Property t_date As DateTime = Nothing
    Private _t_pprc As Double = 0
    Private _t_acpr As Double = 0
    Public Property t_pprc As Double
      Get
        Return Math.Round(_t_pprc, 2)
      End Get
      Set(value As Double)
        _t_pprc = value
      End Set
    End Property
    Public Property t_acpr As Double
      Get
        Return Math.Round(_t_acpr, 2)
      End Get
      Set(value As Double)
        _t_acpr = value
      End Set
    End Property
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
    Public Property EARLY As Double = 0
    Public Property DELAY0 As Double = 0
    Public Property DELAY10 As Double = 0
    Public Property DELAY20 As Double = 0
    Public Property DELAY30 As Double = 0
    Public Property DELAYZZ As Double = 0

    Public Shared Function SelectListForReviewTableFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
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
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectListForReviewTableNOTFinished(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
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
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function


    Public Shared Function SelectListForReviewTableStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
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
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectListForReviewTableNOTStarted(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
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
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetDataTable(ByVal t_cprj As String, ByVal t_acty As String, Optional ByVal AsOn As String = "") As String
      If AsOn = "" Then AsOn = Now.ToString("dd/MM/yyyy")
      Dim data As List(Of SIS.CT.tpisg214) = SIS.CT.tpisg214.SelectListForDataTable(t_cprj, t_acty, AsOn)
      Dim mStr As String = ""
      Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
      Dim row2 As String = "<td><b>PLANNED %</b></td>"
      Dim row3 As String = "<td><b>ACTUAL %</b></td>"
      Dim row4 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
      For Each dt As SIS.CT.tpisg214 In data
        row1 &= "<td style='text-align:center;background-color:black;color:white;'>" & dt.t_date.ToString("dd-MMM") & "</td>"
        row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.t_pprc, 0)) & "</td>"
        row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.t_acpr, 0)) & "</td>"
        row4 &= "<td style='text-align:center;background-color:gray;color:white;'>" & Math.Truncate((Math.Round(dt.t_pprc, 0) - Math.Round(dt.t_acpr, 0))) & "</td>"
      Next
      mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
      mStr &= "<tr>" & row1 & "</tr>"
      mStr &= "<tr>" & row2 & "</tr>"
      mStr &= "<tr>" & row3 & "</tr>"
      mStr &= "<tr>" & row4 & "</tr>"
      mStr &= "</table>"
      Return mStr
    End Function
    Public Shared Function SelectListForDataTable(ByVal t_cprj As String, ByVal t_acty As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg214200 as aa where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' and aa.t_date in (select max(bb.t_date) from ttpisg214200 as bb where bb.t_cprj=aa.t_cprj and bb.t_acty=aa.t_acty group by month(bb.t_date), year(bb.t_date)) order by t_date"
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal t_cprj As String, ByVal t_acty As String) As List(Of SIS.CT.tpisg214)
      Dim Results As List(Of SIS.CT.tpisg214) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg214200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "'"
          Results = New List(Of SIS.CT.tpisg214)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg214(Reader))
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
'Irrespective of Started or NOT Started
'Sql &= "select "
'Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
'Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
'Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and t_acsd < t_sdst then 1 else 0 end) as EARLY,"
'Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
'Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
'Sql &= "and t_sdst=t_acsd ) as DELAY0,"
'Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
'Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
'Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,t_acsd) between 1 and 10  then 1 else case when t_acsd = convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,getdate()) between 1 and 10  then 1 else 0 end end) as DELAY10,"
'Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
'Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
'Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,t_acsd) between 11 and 20  then 1 else case when t_acsd = convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,getdate()) between 11 and 20  then 1 else 0 end end) as DELAY20,"
'Sql &= "(select  count(*) as Cnt from ttpisg220200 where t_cprj='" & t_cprj & "' and t_acty='" & t_acty & "' "
'Sql &= "and t_sdst between DATEADD(day,-30, convert(datetime,'" & t_date & "',103)) and convert(datetime,'" & t_date & "',103)"
'Sql &= "and 1 = case when t_acsd > convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,t_acsd) between 21 and 30  then 1 else case when t_acsd = convert(datetime,'01/01/1753',103) and DATEDIFF(d,t_sdst,getdate()) between 21 and 30  then 1 else 0 end end) as DELAY30"
'Public Shared Function GetReviewTableFinish(ByVal t_cprj As String, ByVal t_acty As String, Optional ByVal AsOn As String = "") As String
'  If AsOn = "" Then AsOn = Now.ToString("dd/MM/yyyy")
'  Dim data As List(Of SIS.CT.tpisg214) = Nothing
'  Dim mStr As String = ""
'  Dim row1 As String = "<td style='text-align:center;'></td><td style='text-align:center;'>EARLY</td><td style='text-align:center;'>NO DELAY</td><td style='text-align:center;'>Delay of 1 to 10 Days</td><td style='text-align:center;'>Delay of 11 to 20 Days</td><td style='text-align:center;'>Delay of 21 to 30 Days</td><td style='text-align:center;'>Delay > 30 Days</td>"
'  Dim row2 As String = ""
'  Dim row3 As String = ""
'  data = SIS.CT.tpisg214.SelectListForReviewTableFinished(t_cprj, t_acty, AsOn)
'  For Each dt As SIS.CT.tpisg214 In data
'    row2 &= "<td style='text-align:center;'>FINISHED</td>"
'    row2 &= "<td style='text-align:center;'><button id='FDE' class='btn' onclick='abc'>" & Math.Truncate(Math.Round(dt.EARLY, 0)) & "</button></td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY0, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY10, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY20, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY30, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAYZZ, 0)) & "</td>"
'  Next
'  data = SIS.CT.tpisg214.SelectListForReviewTableNOTFinished(t_cprj, t_acty, AsOn)
'  For Each dt As SIS.CT.tpisg214 In data
'    row3 &= "<td style='text-align:center;'>NOT FINISHED</td>"
'    row3 &= "<td style='text-align:center;'>-</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY0, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY10, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY20, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY30, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAYZZ, 0)) & "</td>"
'  Next

'  mStr &= "<table class='table-dark table-striped' style='width:100%;margin:5px 5px 5px 5px;'>"
'  mStr &= "<tr>" & row1 & "</tr>"
'  mStr &= "<tr>" & row2 & "</tr>"
'  mStr &= "<tr>" & row3 & "</tr>"
'  mStr &= "</table>"
'  Return mStr
'End Function
'Public Shared Function GetReviewTableStart(ByVal t_cprj As String, ByVal t_acty As String, Optional ByVal AsOn As String = "") As String
'  If AsOn = "" Then AsOn = Now.ToString("dd/MM/yyyy")
'  Dim data As List(Of SIS.CT.tpisg214) = Nothing
'  Dim mStr As String = ""
'  Dim row1 As String = "<td style='text-align:center;'></td><td style='text-align:center;'>EARLY</td><td style='text-align:center;'>NO DELAY</td><td style='text-align:center;'>Delay of 1 to 10 Days</td><td style='text-align:center;'>Delay of 11 to 20 Days</td><td style='text-align:center;'>Delay of 21 to 30 Days</td>"
'  Dim row2 As String = ""
'  Dim row3 As String = ""
'  data = SIS.CT.tpisg214.SelectListForReviewTableStarted(t_cprj, t_acty, AsOn)
'  For Each dt As SIS.CT.tpisg214 In data
'    row2 &= "<td style='text-align:center;'>STARTED</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.EARLY, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY0, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY10, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY20, 0)) & "</td>"
'    row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY30, 0)) & "</td>"
'  Next
'  data = SIS.CT.tpisg214.SelectListForReviewTableNOTStarted(t_cprj, t_acty, AsOn)
'  For Each dt As SIS.CT.tpisg214 In data
'    row3 &= "<td style='text-align:center;'>NOT STARTED</td>"
'    row3 &= "<td style='text-align:center;'>-</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY0, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY10, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY20, 0)) & "</td>"
'    row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.DELAY30, 0)) & "</td>"
'  Next

'  mStr &= "<table class='table-dark table-striped' style='width:100%;margin:5px 5px 5px 5px;'>"
'  mStr &= "<tr>" & row1 & "</tr>"
'  mStr &= "<tr>" & row2 & "</tr>"
'  mStr &= "<tr>" & row3 & "</tr>"
'  mStr &= "</table>"
'  Return mStr
'End Function
