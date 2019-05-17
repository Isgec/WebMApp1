Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class tpisg310
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function GetMnYr(ByVal t_ccod As String) As List(Of SIS.CT.tpisg310)
      Dim Results As List(Of SIS.CT.tpisg310) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select distinct t_moyr, t_sern from ttpisg310200 where t_ccod='" & t_ccod & "' order by t_sern"
          Results = New List(Of SIS.CT.tpisg310)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg310(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function UZ_tpisg310SelectList(ByVal t_moyr As String, ByVal t_ccod As String) As List(Of SIS.CT.tpisg310)
      Dim Results As List(Of SIS.CT.tpisg310) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg310200 where t_ccod='" & t_ccod & "' and t_moyr='" & t_moyr & "'"
          Results = New List(Of SIS.CT.tpisg310)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg310(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tpisg310TotalList(ByVal t_ccod As String) As List(Of SIS.CT.tpisg310)
      Dim Results As List(Of SIS.CT.tpisg310) = Nothing
      Dim Sql As String = " Select "
      Sql &= " isnull(sum(t_ifbu),0) as t_ifbu, "
      Sql &= " isnull(sum(t_ifac),0) as t_ifac, "
      Sql &= " isnull(sum(t_ifva),0) as t_ifva, "
      Sql &= " isnull(sum(t_ofbu),0) as t_ofbu, "
      Sql &= " isnull(sum(t_ofac),0) as t_ofac, "
      Sql &= " isnull(sum(t_ofva),0) as t_ofva, "
      Sql &= " isnull(sum(t_ntbu),0) as t_ntbu, "
      Sql &= " isnull(sum(t_ntac),0) as t_ntac, "
      Sql &= " isnull(sum(t_ntva),0) as t_ntva  "
      Sql &= " from ttpisg310200 where t_ccod='" & t_ccod & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.CT.tpisg310)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg310(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_ccod"), TextBox).Text = ""
          CType(.FindControl("F_t_moyr"), TextBox).Text = ""
          CType(.FindControl("F_t_ifbu"), TextBox).Text = 0
          CType(.FindControl("F_t_ifac"), TextBox).Text = 0
          CType(.FindControl("F_t_ifva"), TextBox).Text = 0
          CType(.FindControl("F_t_ofbu"), TextBox).Text = 0
          CType(.FindControl("F_t_ofac"), TextBox).Text = 0
          CType(.FindControl("F_t_ofva"), TextBox).Text = 0
          CType(.FindControl("F_t_ntbu"), TextBox).Text = 0
          CType(.FindControl("F_t_ntac"), TextBox).Text = 0
          CType(.FindControl("F_t_ntva"), TextBox).Text = 0
          CType(.FindControl("F_t_user"), TextBox).Text = ""
          CType(.FindControl("F_t_updt"), TextBox).Text = ""
          CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
          CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
