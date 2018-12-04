Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg216
    Public Property t_cprj As String = ""
    Public Property t_curr As DateTime = Nothing
    Private _t_prop As Double = 0
    Private _t_proa As Double = 0
    Public Property t_prop As Double
      Get
        Return Math.Round(_t_prop, 2)
      End Get
      Set(value As Double)
        _t_prop = value
      End Set
    End Property
    Public Property t_proa As Double
      Get
        Return Math.Round(_t_proa, 2)
      End Get
      Set(value As Double)
        _t_proa = value
      End Set
    End Property
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
    Public Class ProjectPeriod
      Public Property StDt As DateTime = Nothing
      Public Property FnDt As DateTime = Nothing
    End Class
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
    Public Shared Function SelectList(ByVal t_cprj As String) As List(Of SIS.CT.tpisg216)
      Dim Results As List(Of SIS.CT.tpisg216) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg216200 where t_cprj='" & t_cprj & "'"
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
    Public Shared Function StartFinish(ByVal t_cprj As String) As ProjectPeriod
      If t_cprj = "" Then Return Nothing
      Dim Results As New ProjectPeriod
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select Min(t_curr) as stdt, Max(t_curr) as fndt from ttpisg216200 where t_cprj='" & t_cprj & "'"
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
