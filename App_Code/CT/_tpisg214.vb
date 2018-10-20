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
    Public Property t_pprc As Double = 0
    Public Property t_acpr As Double = 0
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
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
