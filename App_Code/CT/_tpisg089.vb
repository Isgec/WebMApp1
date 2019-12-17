Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg089
    Public Property t_ccod As String = ""
    Public Property t_year As Integer = 0
    Public Property t_mnth As Integer = 0
    Public Property t_amti As Double = 0.00
    Public Property t_amto As Double = 0.00
    Public Property t_namt As Double = 0.00
    Public Property t_oami As Double = 0.00
    Public Property t_oamn As Double = 0.00
    Public Property t_oamo As Double = 0.00
    Public Property t_cmti As Double = 0.00
    Public Property t_cmto As Double = 0.00
    Public Property t_cnmt As Double = 0.00

    Public Class ChartPeriod
      Public Property StDt As DateTime = Nothing
      Public Property FnDt As DateTime = Nothing
    End Class
    Public Shared Function GetContractCustomer(ByVal t_ccod As String) As String
      If t_ccod = "" Then Return ""
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(bp.t_nama +'-'+bp.t_bpid,'') as tmp from ttpisg087200 as ct inner join ttccom100200 as bp on bp.t_bpid=ct.t_cust where ct.t_ccod='" & t_ccod & "'"
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetDataTable(ByVal t_cprj As String, Optional ByVal AsOn As String = "") As String
      If AsOn = "" Then AsOn = Now.ToString("dd/MM/yyyy")
      Dim data As List(Of SIS.CT.tpisg216) = SIS.CT.tpisg216.SelectListForDataTable(t_cprj, AsOn)
      Dim mStr As String = ""
      Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
      Dim row2 As String = "<td><b>PLANNED %</b></td>"
      Dim row3 As String = "<td><b>ACTUAL %</b></td>"
      Dim row4 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
      For Each dt As SIS.CT.tpisg216 In data
        row1 &= "<td style='text-align:center;background-color:black;color:white;'>" & dt.t_curr.ToString("dd-MMM") & "</td>"
        row2 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.t_prop, 0)) & "</td>"
        row3 &= "<td style='text-align:center;'>" & Math.Truncate(Math.Round(dt.t_proa, 0)) & "</td>"
        row4 &= "<td style='text-align:center;background-color:gray;color:white;'>" & Math.Truncate((Math.Round(dt.t_prop, 0) - Math.Round(dt.t_proa, 0))) & "</td>"
      Next
      mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
      mStr &= "<tr>" & row1 & "</tr>"
      mStr &= "<tr>" & row2 & "</tr>"
      mStr &= "<tr>" & row3 & "</tr>"
      mStr &= "<tr>" & row4 & "</tr>"
      mStr &= "</table>"
      Return mStr
    End Function
    Public Shared Function SelectListForDataTable(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg216)
      Dim Results As List(Of SIS.CT.tpisg216) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg216200 as aa where aa.t_cprj='" & t_cprj & "' and aa.t_curr in (select max(bb.t_curr) from ttpisg216200 as bb where bb.t_cprj=aa.t_cprj group by month(bb.t_curr), year(bb.t_curr)) order by t_curr"
          Results = New List(Of SIS.CT.tpisg216)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg216(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal t_ccod As String) As List(Of SIS.CT.tpisg089)
      Dim Results As New List(Of SIS.CT.tpisg089)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg089200 where t_ccod='" & t_ccod & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg089(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetMainPeriod(ByVal t_ccod As String) As ChartPeriod
      If t_ccod = "" Then Return Nothing
      Dim Results As New ChartPeriod
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select min(convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )) as stdt, max(convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )) as fndt from ttpisg089200 where (t_amti>0 or t_amto>0) and t_ccod='" & t_ccod & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If (Reader.Read()) Then
            Try
              Results.StDt = Convert.ToDateTime(Reader("stdt"))
              Results.FnDt = Convert.ToDateTime(Reader("fndt"))
            Catch ex As Exception
            End Try
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetOutlookPeriod(ByVal t_ccod As String) As ChartPeriod
      If t_ccod = "" Then Return Nothing
      Dim Results As New ChartPeriod
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select min(convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )) as stdt, max(convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )) as fndt from ttpisg089200 where t_oami > 0 and t_ccod='" & t_ccod & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If (Reader.Read()) Then
            Try
              Results.StDt = Convert.ToDateTime(Reader("stdt"))
              Results.FnDt = Convert.ToDateTime(Reader("fndt"))
            Catch ex As Exception
            End Try
          End If
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
