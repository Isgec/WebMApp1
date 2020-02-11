Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class GF_cfCashflow
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
        Dim sYear As String = ""
        Dim sMonth As String = ""
        Dim sProject As String = ""
        Dim sInFlow As String = ""
        Dim sOutFlow As String = ""
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
              sYear = wsD.Cells(2, 1).Text
              sMonth = wsD.Cells(2, 2).Text
              For i As Integer = 2 To 99999
                '1. All 5 Columns must have value
                If wsD.Cells(i, 1).Text <> "" AndAlso wsD.Cells(i, 2).Text <> "" AndAlso wsD.Cells(i, 3).Text <> "" AndAlso wsD.Cells(i, 4).Text <> "" AndAlso wsD.Cells(i, 5).Text <> "" Then
                Else
                  Exit For
                End If
                'If sYear <> wsD.Cells(i, 1).Text Or sMonth <> wsD.Cells(i, 2).Text Then
                '  IsError = True
                '  ErrMsg = "Line No: " & i & ", All records do not belong to same year / month."
                '  Exit For
                'End If
                '2. Valid Year
                Dim tmpI As Integer = 0
                Try
                  tmpI = Convert.ToInt32(sYear)
                Catch ex As Exception
                  tmpI = 0
                End Try
                'If tmpI <> Now.Year And tmpI <> Now.Year - 1 Then
                '  IsError = True
                '  ErrMsg = "Line No: " & i & ", Invalid Year."
                '  Exit For
                'End If
                '3. Valid Month
                Try
                  tmpI = Convert.ToInt32(sMonth)
                Catch ex As Exception
                  tmpI = 0
                End Try
                If tmpI < 1 Or tmpI > 12 Then
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Month."
                  Exit For
                End If
                '4. Valid Project
                If Not ProjectExists(wsD.Cells(i, 3).Text) Then
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Contract Not Found."
                  Exit For
                End If
                '5. Value inflow
                Try
                  Dim tmpD As Decimal = Convert.ToDecimal(wsD.Cells(i, 4).Text)
                Catch ex As Exception
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Inflow value."
                  Exit For
                End Try
                '6. Value outflow
                Try
                  Dim tmpD As Decimal = Convert.ToDecimal(wsD.Cells(i, 5).Text)
                Catch ex As Exception
                  IsError = True
                  ErrMsg = "Line No: " & i & ", Invalid Outflow value."
                  Exit For
                End Try
              Next
              '3. Check Freezed
              'If DataFreezed(sYear, sMonth, Comp) Then
              '  IsError = True
              '  ErrMsg = "Data is Freezed for Year/Month"
              'End If
              '4. If Error Alert and Exit
              If IsError Then
                xlP.Dispose()
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ErrMsg) & "');", True)
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              '5. Update/Insert after validation
              For I As Integer = 2 To 99999
                sYear = wsD.Cells(I, 1).Text
                sMonth = wsD.Cells(I, 2).Text
                sProject = wsD.Cells(I, 3).Text
                sInFlow = wsD.Cells(I, 4).Text
                sOutFlow = wsD.Cells(I, 5).Text
                If sYear <> "" And sMonth <> "" And sProject <> "" And sInFlow <> "" And sOutFlow <> "" Then
                Else
                  Exit For
                End If
                If Not ProjectExists(sProject) Then
                  Continue For
                End If
                Dim Found As Boolean = False
                Dim o As tfisg014 = tfisg014.GetByPK(sYear, sMonth, sProject, Comp)
                If o IsNot Nothing Then
                  Found = True
                Else
                  o = New tfisg014
                End If
                o.t_cprj = sProject
                o.t_frez = 2 '2=>NO
                o.t_iamt = sInFlow
                o.t_mnth = sMonth
                o.t_oamt = sOutFlow
                Select Case Convert.ToInt32(sMonth)
                  Case 1, 2, 3
                    o.t_quat = "Q4"
                    o.t_fyer = Convert.ToInt32(sYear) - 1
                  Case 4, 5, 6
                    o.t_quat = "Q1"
                    o.t_fyer = sYear
                  Case 7, 8, 9
                    o.t_quat = "Q2"
                    o.t_fyer = sYear
                  Case 10, 11, 12
                    o.t_quat = "Q3"
                    o.t_fyer = sYear
                End Select
                o.t_nama = GetContractCustomer(sProject, Comp)
                o.t_udat = Now.ToString("dd/MM/yyyy")
                o.t_udby = LNUser
                o.t_year = sYear
                Try
                  If Not Found Then
                    tfisg014.Insert(o)
                  Else
                    tfisg014.Update(o)
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
  Public Shared Function GetContractCustomer(ByVal t_ccod As String, Comp As String) As String
    If t_ccod = "" Then Return ""
    Dim Results As String = ""
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select isnull(bp.t_nama,'') as tmp from ttpisg087" & Comp & " as ct inner join ttccom100" & Comp & " as bp on bp.t_bpid=ct.t_cust where ct.t_ccod='" & t_ccod & "'"
        Con.Open()
        Results = Cmd.ExecuteScalar
        Results = Results.Replace("'".ToCharArray, "")
      End Using
    End Using
    Return Results
  End Function

  Private Function DataFreezed(sYear As String, sMonth As String, Optional comp As String = "200") As Boolean
    Dim mret As Integer = 0
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select isnull(count(*),0) as cnt from ttfisg014" & comp & " where t_year=" & sYear & " and t_mnth=" & sMonth & " and t_frez=1"
        Con.Open()
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
        Cmd.CommandText = "select isnull(count(*),0) as cnt from ttfisg013" & comp & " where upper(t_ccod)='" & prj.ToUpper & "'"
        mret = Cmd.ExecuteScalar
      End Using
      'If mret <= 0 Then
      '  Using Cmd As SqlCommand = Con.CreateCommand()
      '    Cmd.CommandType = CommandType.Text
      '    Cmd.CommandText = "select isnull(count(*),0) as cnt from ttppdm600" & comp & " where upper(t_cprj)='" & prj.ToUpper & "'"
      '    mret = Cmd.ExecuteScalar
      '  End Using
      'End If
    End Using
    Return (mret > 0)
  End Function
  Private Sub mGF_dmisg121_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Authority As String = HttpContext.Current.Request.Url.Authority
    If Authority.ToUpper = "CLOUD.ISGEC.CO.IN" Then
      divOK.Visible = False
      divErr.Visible = True
    Else
      divOK.Visible = True
      divErr.Visible = False
      If Request.QueryString("Company") IsNot Nothing Then
        Comp = Request.QueryString("Company")
        'Dim ERPComp As String = Request.QueryString("Company")
        'Select Case ERPComp
        '  Case "700"
        '    Comp = "700"
        '  Case "651"
        '    Comp = "651"
        '  Case Else
        '    Comp = "200"
        'End Select
      End If
      If Request.QueryString("UserID") IsNot Nothing Then
        LNUser = Request.QueryString("UserID")
      End If
    End If
  End Sub

  'Private Sub LoadYearMonth()
  '  Dim tmp As New ListItem
  '  With tmp
  '    .Text = Now.Year
  '    .Value = Now.Year
  '    .Selected = True
  '  End With
  '  F_Year.Items.Add(tmp)
  '  tmp = New ListItem
  '  With tmp
  '    .Text = Now.Year - 1
  '    .Value = Now.Year - 1
  '  End With
  '  F_Year.Items.Add(tmp)
  '  For i As Integer = 1 To 12
  '    tmp = New ListItem
  '    With tmp
  '      .Text = MonthName(i)
  '      .Value = i
  '      .Selected = (i = Now.Month)
  '    End With
  '    F_Month.Items.Add(tmp)
  '  Next
  'End Sub
End Class
Public Class tfisg014
  Public Property t_year As Integer = 0
  Public Property t_mnth As Integer = 0
  Public Property t_cprj As String = ""
  Public Property t_iamt As Double = 0
  Public Property t_oamt As Double = 0
  Public Property t_quat As String = ""
  Public Property t_Refcntd As Integer = 0
  Public Property t_Refcntu As Integer = 0
  Public Property t_udat As String = ""
  Public Property t_udby As String = ""
  Public Property t_frez As Integer = 0
  Public Property t_fyer As Integer = 0
  Public Property t_nama As String = ""
  Public Shared Function GetByPK(sYear As String, sMonth As String, sPrj As String, Optional comp As String = "200") As tfisg014
    Dim mRet As tfisg014 = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select * from ttfisg014" & comp & " where t_cprj='" & sPrj & "' and t_year=" & sYear & " and t_mnth=" & sMonth
        Con.Open()
        Dim rd As SqlDataReader = Cmd.ExecuteReader
        If rd.Read Then
          mret = New tfisg014(rd)
        End If
      End Using
    End Using
    Return mret
  End Function
  Public Shared Function Update(obj As tfisg014, Optional comp As String = "200") As tfisg014
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = " Update ttfisg014" & comp & " set "
        Cmd.CommandText &= " t_iamt=" & obj.t_iamt & ",t_oamt=" & obj.t_oamt & ",t_quat='" & obj.t_quat & "',t_Refcntd=0,t_Refcntu=0,t_udat=convert(datetime,'" & obj.t_udat & "',103),t_udby='" & obj.t_udby & "',t_frez=" & obj.t_frez & ",t_fyer=" & obj.t_fyer & ",t_nama='" & obj.t_nama & "' "
        Cmd.CommandText &= " where t_year=" & obj.t_year & " and t_mnth=" & obj.t_mnth & " and t_cprj='" & obj.t_cprj & "'"
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    Return obj
  End Function
  Public Shared Function Insert(obj As tfisg014, Optional comp As String = "200") As tfisg014
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetCFBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = " insert into ttfisg014" & comp & " (t_year,t_mnth,t_cprj,t_iamt,t_oamt,t_quat,t_Refcntd,t_Refcntu,t_udat,t_udby,t_frez,t_fyer,t_nama) values "
        Cmd.CommandText &= " (" & obj.t_year & "," & obj.t_mnth & ",'" & obj.t_cprj & "'," & obj.t_iamt & "," & obj.t_oamt & ",'" & obj.t_quat & "',0,0,convert(datetime,'" & obj.t_udat & "',103),'" & obj.t_udby & "'," & obj.t_frez & "," & obj.t_fyer & ",'" & obj.t_nama & "')"
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