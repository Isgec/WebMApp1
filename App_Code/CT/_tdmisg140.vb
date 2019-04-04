Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  <DataObject()>
  Partial Public Class tdmisg140
    Public Property t_cprj As String = ""
    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property t_dsca As String = ""
    Public Property t_resp As String = ""
    Private _t_bssd As String = "" 'UTC Date/Time Baseline Schedule Start Date 1970
    Private _t_bsfd As String = "" 'UTC Date/Time Baseline Schedule Finish Date
    Private _t_rssd As String = "" 'UTC Date/Time Latest Revised Schedule Start Date
    Private _t_rsfd As String = "" 'UTC Date/Time Latest Revised Schedule Finish Date
    Private _t_lrrd As String = "" 'UTC Date/Time Latest Revision Release Date
    Private _t_mosd As String = "" 'Date System Outlook Start Date 1753
    Private _t_moed As String = "" 'Date System Outlook Finish Date
    Private _t_acdt As String = "" 'UTC Date/Time Baseline Actual Release Date
    Private _t_adct As String = "" 'UTC Date/Time Actual Realese Date (CT)
    Public Property t_adct As String
      Get
        If Not _t_adct = String.Empty Then
          Return Convert.ToDateTime(_t_adct).ToString("dd/MM/yyyy")
        End If
        Return _t_adct
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_adct = ""
        Else
          _t_adct = value
        End If
      End Set
    End Property
    Public Property t_acdt As String
      Get
        If Not _t_acdt = String.Empty Then
          Return Convert.ToDateTime(_t_acdt).ToString("dd/MM/yyyy")
        End If
        Return _t_acdt
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_acdt = ""
        Else
          _t_acdt = value
        End If
      End Set
    End Property
    Public Property t_moed As String
      Get
        If Not _t_moed = String.Empty Then
          Return Convert.ToDateTime(_t_moed).ToString("dd/MM/yyyy")
        End If
        Return _t_moed
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_moed = ""
        Else
          _t_moed = value
        End If
      End Set
    End Property
    Public Property t_mosd As String
      Get
        If Not _t_mosd = String.Empty Then
          Return Convert.ToDateTime(_t_mosd).ToString("dd/MM/yyyy")
        End If
        Return _t_mosd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_mosd = ""
        Else
          _t_mosd = value
        End If
      End Set
    End Property
    Public Property t_lrrd As String
      Get
        If Not _t_lrrd = String.Empty Then
          Return Convert.ToDateTime(_t_lrrd).ToString("dd/MM/yyyy")
        End If
        Return _t_lrrd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_lrrd = ""
        Else
          _t_lrrd = value
        End If
      End Set
    End Property
    Public Property t_rsfd As String
      Get
        If Not _t_rsfd = String.Empty Then
          Return Convert.ToDateTime(_t_rsfd).ToString("dd/MM/yyyy")
        End If
        Return _t_rsfd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_rsfd = ""
        Else
          _t_rsfd = value
        End If
      End Set
    End Property
    Public Property t_rssd As String
      Get
        If Not _t_rssd = String.Empty Then
          Return Convert.ToDateTime(_t_rssd).ToString("dd/MM/yyyy")
        End If
        Return _t_rssd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_rssd = ""
        Else
          _t_rssd = value
        End If
      End Set
    End Property
    Public Property t_bsfd As String
      Get
        If Not _t_bsfd = String.Empty Then
          Return Convert.ToDateTime(_t_bsfd).ToString("dd/MM/yyyy")
        End If
        Return _t_bsfd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_bsfd = ""
        Else
          _t_bsfd = value
        End If
      End Set
    End Property
    Public Property t_bssd As String
      Get
        If Not _t_bssd = String.Empty Then
          Return Convert.ToDateTime(_t_bssd).ToString("dd/MM/yyyy")
        End If
        Return _t_bssd
      End Get
      Set(ByVal value As String)
        If value = "01/01/1753" OrElse value = "01/01/1970" Then
          _t_bssd = ""
        Else
          _t_bssd = value
        End If
      End Set
    End Property
    Public Shared Function SelectDocumentList(ByVal t_cprj As String, ByVal t_cact As String, ByVal All As Boolean, Optional ByVal IsNext As Boolean = False) As List(Of SIS.CT.tdmisg140)
      Dim Results As List(Of SIS.CT.tdmisg140) = Nothing
      Dim Sql As String = ""
      Sql &= " Select "
      Sql &= " t_cprj,"
      Sql &= " t_docn,"
      Sql &= " t_revn,"
      Sql &= " t_dsca,"
      Sql &= " t_resp,"
      Sql &= " t_bssd,"
      Sql &= " t_bsfd,"
      Sql &= " t_rssd,"
      Sql &= " t_rsfd,"
      Sql &= " t_lrrd,"
      Sql &= " t_mosd,"
      Sql &= " t_moed,"
      Sql &= " t_acdt,"
      Sql &= " t_adct "
      Sql &= " From tdmisg140200 "
      Sql &= " where "
      Sql &= " t_cprj = '" & t_cprj & "'"
      Sql &= " and (t_iref = (Select top 1 t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "' ) or t_iref='" & t_cact & "')"
      If Not All Then
        Sql &= " and year(t_acdt) > 1970 "
      End If
      If IsNext Then
        Sql &= " and t_acdt between dateadd(d,30,getdate()) and getdate() "
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.tdmisg140)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tdmisg140(Reader))
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