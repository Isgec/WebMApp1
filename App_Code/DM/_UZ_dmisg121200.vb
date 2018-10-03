Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DMISG
  Partial Public Class dmisg121200
    Public ReadOnly Property Status As String
      Get
        Dim mRet As String = ""
        Select Case t_wfst
          Case 1
            mRet = "Under Design"
          Case 2
            mRet = "Submitted"
          Case 3
            mRet = "Under Review"
          Case 4
            mRet = "Under Approval"
          Case 5
            mRet = "Released"
          Case 6
            mRet = "Withdrawn"
          Case 7
            mRet = "Under Revision"
          Case 8
            mRet = "Superseded"
          Case 9
            mRet = "Under DCR"
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetDownloadLink() As String
      Get
        '
        'Comment Added
        Dim Authority As String = HttpContext.Current.Request.Url.Authority
        'Commented as handled while download
        'If Authority.ToLower = "localhost" Then Authority = "192.9.200.146"
        Dim tmpURL As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & Authority & HttpContext.Current.Request.ApplicationPath
        'Return "javascript:window.open('" & tmpURL & "/DM_mMain/App_Downloads/download.aspx?doc=" & PrimaryKey & "', 'win" & t_docn & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
        Return tmpURL & "/DM_mMain/App_Downloads/download.aspx?doc=" & PrimaryKey
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Shared Function UZ_dmisg121200SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchText As String, ByVal SearchState As Boolean, ByVal LatestRevision As Boolean) As List(Of SIS.DMISG.dmisg121200)
      If SearchText Is Nothing Then SearchText = ""
      Dim Results As List(Of SIS.DMISG.dmisg121200) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg_LG_121200SelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LatestRevision", SqlDbType.Bit, 3, LatestRevision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsSearch", SqlDbType.Bit, 3, SearchState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DMISG.dmisg121200)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DMISG.dmisg121200(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_dmisg121200Count(ByVal SearchText As String, ByVal SearchState As Boolean, ByVal LatestRevision As Boolean) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UZ_dmisg121200SelectList_All(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchText As String, ByVal SearchState As Boolean) As List(Of SIS.DMISG.dmisg121200)
      If SearchText Is Nothing Then SearchText = ""
      Dim Results As List(Of SIS.DMISG.dmisg121200) = Nothing
      Dim DocID As String = ""
      Dim RevNo As String = ""
      Dim Find As Boolean = False
      If SearchText.StartsWith("##") Then
        Find = True
        SearchText = SearchText.Replace("##", "")
        Dim aVal() As String = SearchText.Split("_".ToCharArray)
        DocID = aVal(0)
        RevNo = aVal(1)
        SearchText = ""
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdmisg_LG_121200SelectListFilteres_All"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocID", SqlDbType.NVarChar, 50, DocID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevNo", SqlDbType.NVarChar, 10, RevNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFind", SqlDbType.Bit, 3, Find)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsSearch", SqlDbType.Bit, 3, SearchState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DMISG.dmisg121200)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DMISG.dmisg121200(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_dmisg121200Count_All(ByVal SearchText As String, ByVal SearchState As Boolean) As Integer
      Return _RecordCount
    End Function
  End Class
End Namespace
