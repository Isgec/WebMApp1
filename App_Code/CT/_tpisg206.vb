Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tpisg206
    Public Property t_acty As String = ""
    Public Property t_dsca As String = ""
    Public Property t_cprj As String = ""
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
    Public ReadOnly Property GetRedirectLink As String
      Get
        Return "~/CT_mMain/App_Forms/mGctActivityDashboard.aspx?t_cprj=" & t_cprj & "&t_acty=" & t_acty
      End Get
    End Property

    Public ReadOnly Property DataTable As String
      Get
        Dim data As List(Of SIS.CT.tpisg214) = SIS.CT.tpisg214.SelectList(t_cprj, t_acty)
        Dim mStr As String = ""
        Dim row1 As String = ""
        Dim row2 As String = ""
        Dim row3 As String = ""
        mStr &= "<table><tr><td></td></tr></table>"
        For Each dt As SIS.CT.tpisg214 In data

        Next
        Return mStr
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ByVal t_cprj As String) As List(Of SIS.CT.tpisg206)
      Dim Results As List(Of SIS.CT.tpisg206) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg206200 as aa where aa.t_acty = 'DESIGN' UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'CIVIL'   UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'INDT'  UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'RFQ-TO-PO' UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'MFG' UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'DISP' UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'RECPT' UNION ALL select * from ttpisg206200 as aa where aa.t_acty = 'EREC'"
          Results = New List(Of SIS.CT.tpisg206)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.CT.tpisg206(Reader)
            tmp.t_cprj = t_cprj
            Results.Add(tmp)
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
