Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg220



    'Public Shared Function GetDataTable(ByVal t_cprj As String, Optional ByVal AsOn As String = "") As String
    '  If AsOn = "" Then AsOn = Now.ToString("dd/MM/yyyy")
    '  Dim data As List(Of SIS.CT.tpisg216) = SIS.CT.tpisg216.SelectListForDataTable(t_cprj, AsOn)
    '  Dim mStr As String = ""
    '  Dim row1 As String = "<td></td>"
    '  Dim row2 As String = "<td>Planned Progress %</td>"
    '  Dim row3 As String = "<td>Actual Progress %</td>"
    '  Dim row4 As String = "<td>Varience</td>"
    '  For Each dt As SIS.CT.tpisg216 In data
    '    row1 &= "<td style='text-align:center;'>" & dt.t_curr.ToString("dd-MMM") & "</td>"
    '    row2 &= "<td style='text-align:center;'>" & dt.t_prop.ToString("n") & "</td>"
    '    row3 &= "<td style='text-align:center;'>" & dt.t_proa.ToString("n") & "</td>"
    '    row4 &= "<td style='text-align:center;'>" & (dt.t_prop - dt.t_proa).ToString("n") & "</td>"
    '  Next
    '  mStr &= "<table class='table-dark table-striped' style='width:100%;margin:5px 5px 5px 5px;'>"
    '  mStr &= "<tr>" & row1 & "</tr>"
    '  mStr &= "<tr>" & row2 & "</tr>"
    '  mStr &= "<tr>" & row3 & "</tr>"
    '  mStr &= "<tr>" & row4 & "</tr>"
    '  mStr &= "</table>"
    '  Return mStr
    'End Function
    'Public Shared Function SelectListForDataTable(ByVal t_cprj As String, ByVal AsOn As String) As List(Of SIS.CT.tpisg216)
    '  Dim Results As List(Of SIS.CT.tpisg216) = Nothing
    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = "select * from ttpisg216200 as aa where aa.t_cprj='" & t_cprj & "' and aa.t_curr in (select max(bb.t_curr) from ttpisg216200 as bb where bb.t_cprj=aa.t_cprj group by month(bb.t_curr), year(bb.t_curr)) order by t_curr"
    '      Results = New List(Of SIS.CT.tpisg216)()
    '      Con.Open()
    '      Dim Reader As SqlDataReader = Cmd.ExecuteReader()
    '      While (Reader.Read())
    '        Results.Add(New SIS.CT.tpisg216(Reader))
    '      End While
    '      Reader.Close()
    '    End Using
    '  End Using
    '  Return Results
    'End Function

    Public Shared Function SelectProjectActivity(ByVal t_cprj As String) As List(Of SIS.CT.tpisg220)
      Dim Results As List(Of SIS.CT.tpisg220) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg220200 as aa where aa.t_cprj='" & t_cprj & "' and t_acty='PARENT' and t_cact=t_pact order by t_actp "
          Results = New List(Of SIS.CT.tpisg220)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg220(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectProjectActivity(ByVal t_cprj As String, ByVal ActivityID As String) As List(Of SIS.CT.tpisg220)
      Dim Results As List(Of SIS.CT.tpisg220) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg220200 as aa where aa.t_cprj='" & t_cprj & "' and t_pact='" & ActivityID & "' and t_cact<>t_pact order by t_actp "
          Results = New List(Of SIS.CT.tpisg220)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg220(Reader))
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
    Public Property t_pper As Decimal = 0
    Public Property t_valu As Decimal = 0
    Public Property t_sele As Integer = 0
    Public Property t_numv As Integer = 0
    Public Property t_numo As Integer = 0
    Public Property t_numt As Integer = 0
    Public Property t_numq As Integer = 0
    Public Property t_nutc As Integer = 0
    Public Property t_sitm As String = ""
    Public Property t_pprc As Decimal = 0
    Public Property t_elap As Integer = 0
    Public Property t_ddur As Integer = 0
    Public Property t_elad As Decimal = 0
    Public Property t_emsp As Decimal = 0
    Public Property t_pmsp As Decimal = 0
    Public Property t_slck As Decimal = 0
    Public Property t_dela As Decimal = 0
    Public Property t_atsk As Decimal = 0
    Public Property t_odur As Decimal = 0
    Public Property t_delf As Decimal = 0
    Public Property t_drem As String = ""
    Public Property t_cric As Integer = 0
    Public Property t_moed As String = ""
    Public Property t_mosd As String = ""

    Public Property t_cprj As String = ""
    Public Property t_acty As String = ""
    Public Property t_amod As String = ""
    Public Property t_dept As String = ""
    Public Property t_desc As String = ""
    Public Property t_exdo As Int32 = 0
    Public Property t_outl As Int32 = 0
    Public Property t_pcbs As String = ""
    Public Property t_sub1 As String = ""
    Public Property t_sub2 As String = ""
    Public Property t_sub3 As String = ""
    Public Property t_sub4 As String = ""
    Public Property t_vali As Int32 = 0
    Public Property t_cpgv As Double = 0
    Public Property t_cact As String = ""
    Public Property t_pcod As String = ""
    Public Property t_sdst As String = ""
    Public Property t_sdfn As String = ""
    Public Property t_acsd As String = ""
    Public Property t_acfn As String = ""
    Public Property t_otsd As String = ""
    Public Property t_oted As String = ""
    Public Property t_rmks As String = ""
    Public Property t_gps3 As String = ""
    Public Property t_gps4 As String = ""
    Public Property t_gps2 As String = ""
    Public Property t_pred As String = ""
    Public Property t_gps1 As String = ""
    Public Property t_succ As String = ""
    Public Property t_dura As Int32 = 0
    Public Property t_bcod As String = ""
    Public Property t_pact As String = ""
    Public Property t_bohd As String = ""
    Public Property t_Refcntd As Int32 = 0
    Public Property t_actp As Int32 = 0
    Public Property t_schd As Int32 = 0
    Public Property t_Refcntu As Int32 = 0
    Public Property Name As String = "tpisg220"
  End Class
End Namespace