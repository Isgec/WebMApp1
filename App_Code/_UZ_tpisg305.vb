Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class tpisg305
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
    Public Shared Function UZ_tpisg305SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_ccod As String) As List(Of SIS.CT.tpisg305)
      Dim Results As List(Of SIS.CT.tpisg305) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetFDBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from ttpisg305200 where t_ccod='" & t_ccod & "'"
          Results = New List(Of SIS.CT.tpisg305)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.CT.tpisg305(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_user"), TextBox).Text = ""
        CType(.FindControl("F_t_csdc"), TextBox).Text = ""
        CType(.FindControl("F_t_bdgd"), TextBox).Text = 0
        CType(.FindControl("F_t_aled"), TextBox).Text = 0
        CType(.FindControl("F_t_ccod"), TextBox).Text = ""
        CType(.FindControl("F_t_cbda"), TextBox).Text = 0
        CType(.FindControl("F_t_cycn"), TextBox).Text = 0
        CType(.FindControl("F_t_sson"), TextBox).Text = 0
        CType(.FindControl("F_t_stcs"), TextBox).Text = 0
        CType(.FindControl("F_t_cysc"), TextBox).Text = 0
        CType(.FindControl("F_t_coco"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        CType(.FindControl("F_t_updt"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
