Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.MAPP
  Partial Public Class mappApplications
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal AppID As Int32) As SIS.MAPP.mappApplications
      Dim Results As SIS.MAPP.mappApplications = mappApplicationsGetByID(AppID)
      Return Results
    End Function
    Public Shared Function UZ_mappApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.MAPP.mappApplications)
      Dim Results As List(Of SIS.MAPP.mappApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spmapp_LG_ApplicationsSelectListSearch"
            Cmd.CommandText = "spmappApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spmapp_LG_ApplicationsSelectListFilteres"
            Cmd.CommandText = "spmappApplicationsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.MAPP.mappApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.MAPP.mappApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_mappApplicationsInsert(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Dim _Result As SIS.MAPP.mappApplications = mappApplicationsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_mappApplicationsUpdate(ByVal Record As SIS.MAPP.mappApplications) As SIS.MAPP.mappApplications
      Dim _Result As SIS.MAPP.mappApplications = mappApplicationsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_mappApplicationsDelete(ByVal Record As SIS.MAPP.mappApplications) As Integer
      Dim _Result as Integer = mappApplicationsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_AppID"), TextBox).Text = ""
        CType(.FindControl("F_ApplicationName"), TextBox).Text = ""
        CType(.FindControl("F_ApplicationDescription"), TextBox).Text = ""
        CType(.FindControl("F_IsActive"), CheckBox).Checked = False
        CType(.FindControl("F_MainPageURL"), TextBox).Text = ""
        CType(.FindControl("F_AppIconID"), TextBox).Text = ""
        CType(.FindControl("F_AppIconID_Display"), Label).Text = ""
        CType(.FindControl("F_AppIconStyle"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
