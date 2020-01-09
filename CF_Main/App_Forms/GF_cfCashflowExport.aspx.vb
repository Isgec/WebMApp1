Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class GF_cfCashflowExport
  Inherits SIS.SYS.GridBase
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Private Comp As String = "200"
  Private LNUser As String = ""
  Private Sub cmdTmplUpload_Click(sender As Object, e As EventArgs) Handles cmdTmplUpload.Click
    If IsUploaded.Value <> "YES" Then Exit Sub
    IsUploaded.Value = ""
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    If cmdTmplUpload.CommandName.ToLower = "tmplupload" Then
      Try
        Dim x As New tfisg017
        With F_FileUpload
          If .HasFile Then
            Dim tmpPath As String = Server.MapPath("~/../App_Temp")
            Dim tmpName As String = IO.Path.GetRandomFileName()
            Dim tmpFile As String = tmpPath & "\\" & tmpName
            .SaveAs(tmpFile)
            Dim fi As FileInfo = New FileInfo(tmpFile)
            Dim IsError As Boolean = False
            Dim ErrMsg As String = ""
            Using xlP As ExcelPackage = New ExcelPackage(fi)
              Dim wsD As ExcelWorksheet = Nothing
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              '1. Process Document
              If wsD Is Nothing Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              '2. Validate Document
              Try
                x.t_ddte = wsD.Cells(3, 12).Text
              Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid Report Date at Line 3, Column N") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End Try
              For i As Integer = 6 To 99999
                x.t_cprj = wsD.Cells(i, 2).Text
                If x.t_cprj = "" Then
                  Exit For
                End If
                If Not ProjectExists(x.t_cprj, Comp) Then
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Project."
                  Exit For
                End If
                x.t_ptyp = wsD.Cells(i, 3).Text
                If x.GetEnum = "0" Then
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Project Type."
                  Exit For
                End If
                x.t_ccur = wsD.Cells(i, 11).Text
                If Not CurrencyExists(x.t_ccur, Comp) Then
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Currency."
                  Exit For
                End If
              Next
              If IsError Then
                xlP.Dispose()
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ErrMsg) & "');", True)
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              '5. Update/Insert after validation
              For I As Integer = 6 To 99999
                x = New tfisg017
                x.t_ddte = wsD.Cells(3, 12).Text
                x.t_cprj = wsD.Cells(I, 2).Text
                If x.t_cprj = "" Then
                  Exit For
                End If
                x.t_ptyp = wsD.Cells(I, 3).Text
                Try
                  x.t_outd = wsD.Cells(I, 4).Text
                Catch ex As Exception
                  x.t_outd = 0
                End Try
                Try
                  x.t_outi = wsD.Cells(I, 5).Text
                Catch ex As Exception
                  x.t_outi = 0
                End Try
                Try
                  x.t_unfc = wsD.Cells(I, 6).Text
                Catch ex As Exception
                  x.t_unfc = 0
                End Try
                Try
                  x.t_unin = wsD.Cells(I, 7).Text
                Catch ex As Exception
                  x.t_unin = 0
                End Try
                Try
                  x.t_outr = wsD.Cells(I, 8).Text
                Catch ex As Exception
                  x.t_outr = 0
                End Try
                Try
                  x.t_ouin = wsD.Cells(I, 9).Text
                Catch ex As Exception
                  x.t_ouin = 0
                End Try
                Try
                  x.t_prgr = wsD.Cells(I, 10).Text
                Catch ex As Exception
                  x.t_prgr = ""
                End Try
                Try
                  x.t_ccur = wsD.Cells(I, 11).Text
                Catch ex As Exception
                  x.t_ccur = 0
                End Try
                Try
                  x.t_rate = wsD.Cells(I, 12).Text
                Catch ex As Exception
                  x.t_rate = 0
                End Try
                Dim Found As Boolean = False
                Dim o As tfisg017 = tfisg017.GetByPK(x.t_ddte, x.t_cprj, Comp)
                If o IsNot Nothing Then
                  Found = True
                End If
                x.t_dtte = Now.ToString("dd/MM/yyyy")
                x.t_user = LNUser
                Try
                  If Not Found Then
                    tfisg017.Insert(x)
                  Else
                    tfisg017.Update(x)
                  End If
                Catch ex As Exception
                  IsError = True
                  ErrMsg = "There was error during insert/update at Line " & I & ", check and import again." & ex.Message
                End Try
              Next
              xlP.Dispose()
              If IsError Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ErrMsg) & "');", True)
              Else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
              End If
            End Using
          End If
        End With
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
  Private Function CurrencyExists(ccur As String, Optional comp As String = "200") As Boolean
    Dim mret As Integer = 0
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Con.Open()
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select isnull(count(*),0) as cnt from ttcmcs002" & comp & " where upper(t_ccur)='" & ccur.ToUpper & "'"
        mret = Cmd.ExecuteScalar
      End Using
    End Using
    Return (mret > 0)
  End Function
  Private Function ProjectExists(prj As String, Optional comp As String = "200") As Boolean
    Dim mret As Integer = 0
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Con.Open()
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select isnull(count(*),0) as cnt from ttppdm600" & comp & " where upper(t_cprj)='" & prj.ToUpper & "'"
        mret = Cmd.ExecuteScalar
      End Using
    End Using
    Return (mret > 0)
  End Function
  Private Sub mGF_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Authority As String = HttpContext.Current.Request.Url.Authority
    If Authority.ToUpper = "CLOUD.ISGEC.CO.IN" Then
      divOK.Visible = False
      divErr.Visible = True
    Else
      divOK.Visible = True
      divErr.Visible = False
      If Request.QueryString("Company") IsNot Nothing Then
        Comp = Request.QueryString("Company")
      End If
      If Request.QueryString("UserID") IsNot Nothing Then
        LNUser = Request.QueryString("UserID")
      End If
    End If
  End Sub
End Class
Public Class tfisg017
  Public Property t_nama As String = ""
  Public Property t_ddte As DateTime
  Public Property t_cprj As String = ""
  Public Property t_ptyp As String = ""
  Public Property t_outd As Double = 0.00
  Public Property t_outi As Double = 0.00
  Public Property t_unfc As Double = 0.00
  Public Property t_unin As Double = 0.00
  Public Property t_outr As Double = 0.00
  Public Property t_ouin As Double = 0.00
  Public Property t_prgr As String = ""
  Public Property t_ccur As String = ""
  Public Property t_rate As Double = 0.00
  Public Property t_dtte As DateTime
  Public Property t_user As String = ""
  Public Property t_Refcntd As Integer = 0
  Public Property t_Refcntu As Integer = 0
  Public Function GetEnum() As Integer
    Select Case t_ptyp.ToUpper
      Case "SUPPLY"
        Return 1
      Case "CIVIL WORKS"
        Return 2
      Case "ERECTION & COMMISSIONING"
        Return 3
      Case "SPARES & VARIATION ORDER"
        Return 4
      Case "O & M"
        Return 5
      Case "OTHERS"
        Return 6
    End Select
    Return 0
  End Function

  Public Shared Function GetByPK(sReportDate As String, sPrj As String, Optional comp As String = "200") As tfisg017
    Dim mRet As tfisg017 = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select * from ttfisg017" & comp & " where t_cprj='" & sPrj & "' and t_ddte=convert(datetime,'" & sReportDate & "',103)"
        Con.Open()
        Dim rd As SqlDataReader = Cmd.ExecuteReader
        If rd.Read Then
          mRet = New tfisg017(rd)
        End If
      End Using
    End Using
    Return mRet
  End Function
  Public Shared Function Update(obj As tfisg017, Optional comp As String = "200") As tfisg017
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " Update ttfisg017" & comp & " set "
        Sql &= " t_ptyp = " & obj.GetEnum
        Sql &= ", t_ddte = '" & obj.t_ddte & "'"
        Sql &= ", t_nama = '" & obj.t_nama & "'"
        Sql &= ", t_cprj = '" & obj.t_cprj & "'"
        Sql &= ", t_ptyp = " & obj.t_ptyp
        Sql &= ", t_outd = " & obj.t_outd
        Sql &= ", t_outi = " & obj.t_outi
        Sql &= ", t_unfc = " & obj.t_unfc
        Sql &= ", t_unin = " & obj.t_unin
        Sql &= ", t_outr = " & obj.t_outr
        Sql &= ", t_ouin = " & obj.t_ouin
        Sql &= ", t_prgr = " & obj.t_prgr
        Sql &= ", t_ccur = " & obj.t_ccur
        Sql &= ", t_rate = " & obj.t_rate
        Sql &= ", t_dtte = convert(datetime,'" & obj.t_dtte.ToString("dd/MM/yyyy") & "',103)"
        Sql &= ", t_user = '" & obj.t_user & "'"
        Sql &= ", t_Refcntd = 0"
        Sql &= ", t_Refcntu = 0"
        Sql &= " where t_ddte = convert(datetime,'" & obj.t_ddte.ToString("dd/MM/yyyy") & "',103) and t_cprj='" & obj.t_cprj & "'"
        Cmd.CommandText = Sql
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    Return obj
  End Function
  Public Shared Function Insert(obj As tfisg017, Optional comp As String = "200") As tfisg017
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " insert into ttfisg017" & comp & " (t_ddte,t_cprj,t_ptyp,t_outd,t_outi,t_unfc,t_unin,t_outr,t_ouin,t_prgr,t_ccur,t_rate,t_dtte,t_user,t_Refcntd,t_Refcntu,t_nama) values "
        Sql &= " (convert(datetime,'" & obj.t_ddte.ToString("dd/MM/yyyy") & "',103),'" & obj.t_cprj & "'," & obj.GetEnum & ", " & obj.t_outd & ", " & obj.t_outi & ", " & obj.t_unfc & ", " & obj.t_unin & ", " & obj.t_outr & ", " & obj.t_ouin & ", '" & obj.t_prgr & "', '" & obj.t_ccur & "', " & obj.t_rate & ", " & " convert(datetime,'" & obj.t_dtte & "',103),'" & obj.t_user & "'," & obj.t_Refcntd & ", " & obj.t_Refcntu & ",'" & obj.t_nama & "')"
        Cmd.CommandText = Sql
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    Return obj
  End Function

  Sub New(rd As SqlDataReader)
    SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
  End Sub
  Sub New()
    'dummy
  End Sub
End Class
