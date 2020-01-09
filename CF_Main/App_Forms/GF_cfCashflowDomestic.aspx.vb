Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class GF_cfCashflowDomestic
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
        Dim x As New tfisg016
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
                x.t_ddte = wsD.Cells(3, 14).Text
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
                If Not ProjectExists(x.t_cprj) Then
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
              Next
              If IsError Then
                xlP.Dispose()
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ErrMsg) & "');", True)
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              '5. Update/Insert after validation
              For I As Integer = 6 To 99999
                x = New tfisg016
                x.t_ddte = wsD.Cells(3, 14).Text
                x.t_cprj = wsD.Cells(I, 2).Text
                If x.t_cprj = "" Then
                  Exit For
                End If
                x.t_ptyp = wsD.Cells(I, 3).Text
                Try
                  x.t_tdte = wsD.Cells(I, 4).Text
                Catch ex As Exception
                  x.t_tdte = 0
                End Try
                Try
                  x.t_cnra = wsD.Cells(I, 5).Text
                Catch ex As Exception
                  x.t_cnra = 0
                End Try
                Try
                  x.t_notd = wsD.Cells(I, 6).Text
                Catch ex As Exception
                  x.t_notd = 0
                End Try
                Try
                  x.t_sla1 = wsD.Cells(I, 7).Text
                Catch ex As Exception
                  x.t_sla1 = 0
                End Try
                Try
                  x.t_sla2 = wsD.Cells(I, 8).Text
                Catch ex As Exception
                  x.t_sla2 = 0
                End Try
                Try
                  x.t_sla3 = wsD.Cells(I, 9).Text
                Catch ex As Exception
                  x.t_sla3 = 0
                End Try
                Try
                  x.t_sla4 = wsD.Cells(I, 10).Text
                Catch ex As Exception
                  x.t_sla4 = 0
                End Try
                Try
                  x.t_sla5 = wsD.Cells(I, 11).Text
                Catch ex As Exception
                  x.t_sla5 = 0
                End Try
                Try
                  x.t_unre = wsD.Cells(I, 12).Text
                Catch ex As Exception
                  x.t_unre = 0
                End Try
                Try
                  x.t_totl = wsD.Cells(I, 13).Text
                Catch ex As Exception
                  x.t_totl = 0
                End Try
                Try
                  x.t_relr = wsD.Cells(I, 14).Text
                Catch ex As Exception
                  x.t_relr = 0
                End Try
                Try
                  x.t_rele = wsD.Cells(I, 15).Text
                Catch ex As Exception
                  x.t_rele = 0
                End Try
                Dim Found As Boolean = False
                Dim o As tfisg016 = tfisg016.GetByPK(x.t_ddte, x.t_cprj, Comp)
                If o IsNot Nothing Then
                  Found = True
                End If
                x.t_dtte = Now.ToString("dd/MM/yyyy")
                x.t_user = LNUser
                Try
                  If Not Found Then
                    tfisg016.Insert(x)
                  Else
                    tfisg016.Update(x)
                  End If
                Catch ex As Exception
                  IsError = True
                  ErrMsg = "There was error during insert/update at Line " & I & ", check and import again." & ex.Message
                End Try
                Found = False
                Dim p As tfisg018 = tfisg018.GetByPK(x.t_ddte, x.t_cprj, Comp)
                If p IsNot Nothing Then
                  Found = True
                End If
                Dim y As New tfisg018
                With y
                  .t_cprj = x.t_cprj
                  .t_ddte = x.t_ddte
                  .t_sld1 = x.t_sla1
                  .t_sld2 = x.t_sla2
                  .t_sld3 = x.t_sla3
                  .t_sld4 = x.t_sla4
                  .t_sld5 = x.t_sla5
                End With
                Try
                  If Not Found Then
                    tfisg018.Insert(y)
                  Else
                    tfisg018.Update(y)
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
Public Class tfisg016
  Public Property t_ddte As DateTime
  Public Property t_cprj As String = ""
  Public Property t_ptyp As String = ""
  Public Property t_tdte As Double = 0.00
  Public Property t_cnra As Double = 0.00
  Public Property t_notd As Double = 0.00
  Public Property t_sla1 As Double = 0.00
  Public Property t_sla2 As Double = 0.00
  Public Property t_sla3 As Double = 0.00
  Public Property t_sla4 As Double = 0.00
  Public Property t_sla5 As Double = 0.00
  Public Property t_unre As Double = 0.00
  Public Property t_totl As Double = 0.00
  Public Property t_rele As Double = 0.00
  Public Property t_relr As Double = 0.00
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

  Public Shared Function GetByPK(sReportDate As String, sPrj As String, Optional comp As String = "200") As tfisg016
    Dim mRet As tfisg016 = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select * from ttfisg016" & comp & " where t_cprj='" & sPrj & "' and t_ddte=convert(datetime,'" & sReportDate & "',103)"
        Con.Open()
        Dim rd As SqlDataReader = Cmd.ExecuteReader
        If rd.Read Then
          mRet = New tfisg016(rd)
        End If
      End Using
    End Using
    Return mRet
  End Function
  Public Shared Function Update(obj As tfisg016, Optional comp As String = "200") As tfisg016
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " Update ttfisg016" & comp & " set "
        Sql &= " t_ptyp = " & obj.GetEnum
        Sql &= ", t_tdte = " & obj.t_tdte
        Sql &= ", t_cnra = " & obj.t_cnra
        Sql &= ", t_notd = " & obj.t_notd
        Sql &= ", t_sla1 = " & obj.t_sla1
        Sql &= ", t_sla2 = " & obj.t_sla2
        Sql &= ", t_sla3 = " & obj.t_sla3
        Sql &= ", t_sla4 = " & obj.t_sla4
        Sql &= ", t_sla5 = " & obj.t_sla5
        Sql &= ", t_unre = " & obj.t_unre
        Sql &= ", t_totl = " & obj.t_totl
        Sql &= ", t_relr = " & obj.t_relr
        Sql &= ", t_rele = " & obj.t_rele
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
  Public Shared Function Insert(obj As tfisg016, Optional comp As String = "200") As tfisg016
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " insert into ttfisg016" & comp & " (t_ddte,t_cprj,t_ptyp,t_tdte,t_cnra,t_notd,t_sla1,t_sla2,t_sla3,t_sla4,t_sla5,t_unre,t_totl,t_rele,t_relr,t_dtte,t_user,t_Refcntd,t_Refcntu) values "
        Sql &= " (convert(datetime,'" & obj.t_ddte.ToString("dd/MM/yyyy") & "',103),'" & obj.t_cprj & "'," & obj.GetEnum & ", " & obj.t_tdte & ", " & obj.t_cnra & ", " & obj.t_notd & ", " & obj.t_sla1 & ", " & obj.t_sla2 & ", " & obj.t_sla3 & ", " & obj.t_sla4 & ", " & obj.t_sla5 & ", " & obj.t_unre & ", " & obj.t_totl & ", " & obj.t_rele & "," & obj.t_relr & ", convert(datetime,'" & obj.t_dtte & "',103),'" & obj.t_user & "'," & obj.t_Refcntd & ", " & obj.t_Refcntu & ")"
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
Public Class tfisg018
  Public Property t_ddte As DateTime
  Public Property t_cprj As String = ""
  Public Property t_sld1 As Double = 0.00
  Public Property t_sld2 As Double = 0.00
  Public Property t_sld3 As Double = 0.00
  Public Property t_sld4 As Double = 0.00
  Public Property t_sld5 As Double = 0.00
  Public Property t_Refcntd As Integer = 0
  Public Property t_Refcntu As Integer = 0
  Public Shared Function GetByPK(sReportDate As String, sPrj As String, Optional comp As String = "200") As tfisg018
    Dim mRet As tfisg018 = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select * from ttfisg018" & comp & " where t_cprj='" & sPrj & "' and t_ddte=convert(datetime,'" & sReportDate & "',103)"
        Con.Open()
        Dim rd As SqlDataReader = Cmd.ExecuteReader
        If rd.Read Then
          mRet = New tfisg018(rd)
        End If
      End Using
    End Using
    Return mRet
  End Function
  Public Shared Function Update(obj As tfisg018, Optional comp As String = "200") As tfisg018
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " Update ttfisg018" & comp & " set "
        Sql &= " t_sld1 = " & obj.t_sld1
        Sql &= ", t_sld2 = " & obj.t_sld2
        Sql &= ", t_sld3 = " & obj.t_sld3
        Sql &= ", t_sld4 = " & obj.t_sld4
        Sql &= ", t_sld5 = " & obj.t_sld5
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
  Public Shared Function Insert(obj As tfisg018, Optional comp As String = "200") As tfisg018
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Dim Sql As String = ""
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Sql &= " insert into ttfisg018" & comp & " (t_ddte,t_cprj,t_sld1,t_sld2,t_sld3,t_sld4,t_sld5,t_Refcntd,t_Refcntu) values "
        Sql &= " (convert(datetime,'" & obj.t_ddte.ToString("dd/MM/yyyy") & "',103),'" & obj.t_cprj & "'," & obj.t_sld1 & ", " & obj.t_sld2 & ", " & obj.t_sld3 & ", " & obj.t_sld4 & ", " & obj.t_sld5 & ", " & obj.t_Refcntd & ", " & obj.t_Refcntu & ")"
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