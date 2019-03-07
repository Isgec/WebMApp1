Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.Script.Serialization
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Partial Class mGctActivityDetails
  Inherits System.Web.UI.Page
  Private ProjectID As String = ""
  Private ActivityID As String = ""
  Private ActivityType As String = ""
  Private ProjectName As String = ""
  Private ActivityName As String = ""
  Private ActivityTypeName As String = ""
  Private Sub mGctActivityDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("t_cprj") IsNot Nothing Then ProjectID = Request.QueryString("t_cprj")
    If Request.QueryString("t_cact") IsNot Nothing Then ActivityID = Request.QueryString("t_cact")
    If Request.QueryString("t_acty") IsNot Nothing Then ActivityType = Request.QueryString("t_acty")
    Select Case ActivityType
      Case "DESIGN"
        ActivityTypeName = "ENGINEERING"
      Case "INDT"
        ActivityTypeName = "INDENTING"
      Case "RFQ-TO-PO"
        ActivityTypeName = "RFQ-TO-PO"
      Case "MFG"
        ActivityTypeName = "MANUFACTURING"
      Case "EREC"
        ActivityTypeName = "ERECTION"
      Case "DISP"
        ActivityTypeName = "DESPATCH"
      Case "RECPT"
        ActivityTypeName = "RECEIPT AT SITE"
      Case "OTHERS"
        ActivityTypeName = "OTHERS"
    End Select
    SubHeader.Text = ActivityTypeName & " - " & ActivityName
  End Sub
  Private Sub divDetails_PreRender(sender As Object, e As EventArgs) Handles divDetails.PreRender
    Dim tbl As Table = Nothing
    Select Case ActivityType
      Case "DESIGN", "INDT", "RFQ-TO-PO"
        tbl = GetTable(ProjectID, ActivityID, ActivityType)
        divDetails.Controls.Add(tbl)
      Case Else ' "MFG", "EREC", "DISP", "RECPT", "OTHERS"
        divDetails.InnerHtml = "<h2> NO DATA FOUND</h2>"
    End Select

  End Sub
  Private Function GetTable(ByVal t_cprj As String, ByVal t_cact As String, ByVal t_acty As String) As Table
    Dim mStr As String = ""

    Dim tbl As New Table
    With tbl
      .ID = "tblDetail"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableHeaderRow
    th = DetailData.GetHeader(t_acty)
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim dMeta As DetailData = DetailData.GetMetaData(t_cprj, t_cact)
    Dim data As List(Of DetailData) = DetailData.GetData(dMeta)
    For Each dt As DetailData In Data
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      Select Case dMeta.t_acty
        Case "DESIGN"
          For I As Integer = 0 To 9
            td = New TableCell
            With td
              Select Case I
                Case 0
                  .Text = dt.t_docn
                Case 1
                  .Text = dt.t_revn
                Case 2
                  .Text = dt.t_dsca
                Case 3
                  .Text = dt.t_bssd
                  .Attributes.Add("style", "text-align:center;")
                Case 4
                  .Text = dt.t_bsfd
                  .Attributes.Add("style", "text-align:center;")
                Case 5
                  .Text = dt.t_rdat
                  .Attributes.Add("style", "text-align:center;")
                Case 6
                  .Attributes.Add("style", "text-align:center;")
                Case 7
                  .Text = dt.t_mosd
                Case 8
                  .Text = dt.t_moed
                Case 9
                  .Text = dt.t_resp
              End Select
            End With
            tr.Cells.Add(td)
          Next
        Case "INDT"
          For I As Integer = 0 To 10
            td = New TableCell
            With td
              Select Case I
                Case 0
                  .Text = dt.IndentNo
                  .Attributes.Add("style", "text-align:center;")
                Case 1
                  .Text = dt.IndentLineNo
                  .Attributes.Add("style", "text-align:center;")
                Case 2
                  .Text = dt.IndentDate
                  .Attributes.Add("style", "text-align:center;")
                Case 3
                  .Text = "[" & dt.Indenter & "] " & dt.IndenterName
                Case 4
                  .Text = "[" & dt.Buyer & "] " & dt.BuyerName
                Case 5
                  .Text = dt.DcoumentID
                Case 6
                  .Text = dt.DocumentRev
                  .Attributes.Add("style", "text-align:center;")
                Case 7
                  .Text = dt.ItemCode
                Case 8
                  .Text = dt.ItemDescription
                Case 9
                  .Text = dt.PurchaseOrder
                  .Attributes.Add("style", "text-align:center;")
                Case 10
                  .Text = dt.PurchaseOrderLine
                  .Attributes.Add("style", "text-align:center;")
              End Select
            End With
            tr.Cells.Add(td)
          Next
        Case "RFQ-TO-PO"
          For I As Integer = 0 To 10
            td = New TableCell
            With td
              Select Case I
                Case 0
                  .Text = dt.WorkFlowID
                  .Attributes.Add("style", "text-align:center;")
                Case 1
                  .Text = dt.CreatedOn
                  .Attributes.Add("style", "text-align:center;")
                Case 2
                  .Text = "[" & dt.Created & "] " & dt.CreatedName
                Case 3
                  .Text = dt.WFStatus
                Case 4
                  .Text = "[" & dt.Buyer & "] " & dt.BuyerName
                Case 5
                  .Text = dt.DcoumentID
                Case 6
                  .Text = dt.DocumentRev
                  .Attributes.Add("style", "text-align:center;")
                Case 7
                  .Text = dt.IndentNo
                  .Attributes.Add("style", "text-align:center;")
                Case 8
                  .Text = dt.IndentLineNo
                  .Attributes.Add("style", "text-align:center;")
                Case 9
                  .Text = dt.PurchaseOrder
                  .Attributes.Add("style", "text-align:center;")
                Case 10
                  .Text = dt.PurchaseOrderLine
                  .Attributes.Add("style", "text-align:center;")
              End Select
            End With
            tr.Cells.Add(td)
          Next
        Case "MFG"
        Case "EREC"
        Case "DISP"
        Case "RECPT"
        Case "OTHERS"

      End Select
      tbl.Rows.Add(tr)
    Next
    Return tbl
  End Function

  Public Class DetailData
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
    Public Property t_acty As String = ""
    Public Property t_iref As String = ""
    Public Property t_bohd As String = ""
    Public Property t_cact As String = ""
    Public Property t_cprj As String = ""
    'RFQ-TO-PO
    Public Property WorkFlowID As String = ""
    Public Property WFStatus As String = ""
    Public Property Created As String = ""
    Public Property CreatedName As String = ""
    Public Property CreatedOn As String = ""
    'Indent Fields
    Public Property PurchaseOrder As String = ""
    Public Property PurchaseOrderLine As String = ""
    Public Property IndentDate As String = ""
    Public Property Indenter As String = ""
    Public Property IndenterName As String = ""
    Public Property Buyer As String = ""
    Public Property BuyerName As String = ""
    Public Property IndentStatusID As String = ""
    Public Property IndentNo As String = ""
    Public Property IndentLineNo As String = ""
    Public Property ItemCode As String = ""
    Public Property ItemDescription As String = ""
    Public Property DcoumentID As String = ""
    Public Property DocumentRev As String = ""
    Public Property DocumentTitle As String = ""

    'Design Fields
    Public Property t_revn As String = ""
    Public Property t_docn As String = ""
    Public Property t_dsca As String = ""
    Public Property t_cspa As String = ""
    Public Property t_type As String = ""
    Public Property t_resp As String = ""
    Public Property t_orgn As String = ""
    Private _t_bssd As String = ""
    Public Property t_bssd As String
      Get
        If _t_bssd <> "" Then
          If Convert.ToDateTime(_t_bssd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_bssd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_bssd = value
      End Set
    End Property
    Private _t_bsfd As String = ""
    Public Property t_bsfd As String
      Get
        If _t_bsfd <> "" Then
          If Convert.ToDateTime(_t_bsfd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_bsfd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_bsfd = value
      End Set
    End Property
    Private _t_rssd As String = ""
    Public Property t_rssd As String
      Get
        If _t_rssd <> "" Then
          If Convert.ToDateTime(_t_rssd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_rssd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_rssd = value
      End Set
    End Property
    Public Property t_rsfd As String
      Get
        If _t_bsfd <> "" Then
          If Convert.ToDateTime(_t_bsfd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_bsfd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_bsfd = value
      End Set
    End Property
    Private _t_lrrd As String = ""
    Public Property t_lrrd As String
      Get
        If _t_lrrd <> "" Then
          If Convert.ToDateTime(_t_lrrd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_lrrd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_lrrd = value
      End Set
    End Property
    Private _t_rdat As String = ""
    Public Property t_rdat As String
      Get
        If _t_rdat <> "" Then
          If Convert.ToDateTime(_t_rdat).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_rdat).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_rdat = value
      End Set
    End Property
    Private _t_moed As String = ""
    Public Property t_moed As String
      Get
        If _t_moed <> "" Then
          If Convert.ToDateTime(_t_moed).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_moed).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_moed = value
      End Set
    End Property
    Private _t_mosd As String = ""
    Public Property t_mosd As String
      Get
        If _t_mosd <> "" Then
          If Convert.ToDateTime(_t_mosd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_mosd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_mosd = value
      End Set
    End Property

    Public Shared Function GetMetaData(ByVal t_cprj As String, ByVal t_cact As String) As DetailData
      Dim tmp As DetailData = Nothing
      Dim Sql As String = ""
      Sql &= " declare @iref NVarChar(150) "
      Sql &= " declare @acty NVarChar(30) "
      Sql &= " declare @bohd NVarChar(50) "
      Sql &= " select top 1 t_bohd + '|' + t_acty + '|' + t_sub1 from ttpisg220200 where t_cprj='" & t_cprj & "' and t_cact='" & t_cact & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim tmpStr As String = Cmd.ExecuteScalar
          Dim tmpAry() As String = tmpStr.Split("|".ToCharArray)
          tmp = New DetailData
          tmp.t_bohd = tmpAry(0)
          tmp.t_acty = tmpAry(1)
          tmp.t_iref = tmpAry(2)
          tmp.t_cprj = t_cprj
          tmp.t_cact = t_cact
        End Using
      End Using
      Return tmp
    End Function

    Public Shared Function GetData(ByVal MetaData As DetailData) As List(Of DetailData)
      Dim tmp As New List(Of DetailData)
      Dim Sql As String = ""
      Select Case MetaData.t_acty
        Case "DESIGN"
          Sql &= "  select "
          Sql &= "   t_docn, "
          Sql &= "   t_revn, "
          Sql &= "   t_dsca, "
          Sql &= "   t_cspa, "
          Sql &= "   t_type, "
          Sql &= "   t_resp, "
          Sql &= "   t_orgn, "
          Sql &= "   t_bssd, "
          Sql &= "   t_bsfd, "
          Sql &= "   t_rssd, "
          Sql &= "   t_lrrd, "
          Sql &= "   t_rdat, "
          Sql &= "   t_mosd, "
          Sql &= "   t_moed  "
          Sql &= "  from tdmisg140200 where t_cprj='" & MetaData.t_cprj & "' and t_iref='" & MetaData.t_iref & "'"
        Case "INDT"
          Sql &= "  select distinct  "
          Sql &= "   tdpur200.t_rdat As IndentDate, "
          Sql &= "   tdpur200.t_remn As Indenter, "
          Sql &= "   rq_tccom001.t_nama as IndenterName, "
          Sql &= "   tdpur200.t_ccon as Buyer, "
          Sql &= "   by_tccom001.t_nama as BuyerName, "
          Sql &= "   tdpur200.t_rqst as IndentStatusID, "
          Sql &= "   tdpur200.t_rqno As IndentNo, "
          Sql &= "   tdisg003.t_pono As IndentLineNo, "
          Sql &= "   tdisg003.t_item As ItemCode, "
          Sql &= "   tdisg003.t_desc as ItemDescription, "
          Sql &= "   tdisg003.t_docn as DcoumentID, "
          Sql &= "   tdisg003.t_revi as DocumentRev,  "
          Sql &= "   tdpur202.t_prno as PurchaseOrder,  "
          Sql &= "   tdpur202.t_ppon as PurchaseOrderLine  "
          Sql &= "  from ttdpur200200 as tdpur200  "
          Sql &= "   inner join ttdisg003200 as tdisg003 on tdpur200.t_rqno=tdisg003.t_rqno  "
          Sql &= "   inner join ttccom001200 as rq_tccom001 on tdpur200.t_remn=rq_tccom001.t_emno "
          Sql &= "   inner join ttccom001200 as by_tccom001 on tdpur200.t_ccon=by_tccom001.t_emno "
          Sql &= "   left outer join ttdpur202200 as tdpur202 on tdpur200.t_rqno=tdpur202.t_rqno and tdisg003.t_pono = tdpur202.t_pono "
          Sql &= "  where  "
          Sql &= "   tdpur200.t_rqst in (3,5,7,8)  "
          Sql &= "   and tdisg003.t_docn in "
          Sql &= "   (select t_docn from tdmisg140200 where t_cprj='" & MetaData.t_cprj & "' and t_iref='" & MetaData.t_iref & "')"
        Case "RFQ-TO-PO"
          Sql &= "  select  "
          Sql &= "   dmisg168.t_wfid as WorkFlowID, "
          Sql &= "   dmisg168.t_stat as WFStatus, "
          Sql &= "   dmisg168.t_user as Created, "
          Sql &= "   cr_tccom001.t_nama as CreatedName, "
          Sql &= "   dmisg168.t_date as CreatedOn, "
          Sql &= "   dmisg168.t_bpid as Buyer, "
          Sql &= "   by_tccom001.t_nama as BuyerName, "
          Sql &= "   dmisg140.t_docn as DcoumentID, "
          Sql &= "   dmisg140.t_revn as DocumentRev  "
          Sql &= "  from tdmisg168200 as dmisg168  "
          Sql &= "  inner join tdmisg167200 as dmisg167 on dmisg168.t_wfid=dmisg167.t_wfid "
          Sql &= "  inner join tdmisg140200 as dmisg140 on dmisg167.t_docn=dmisg140.t_docn "
          Sql &= "  inner join ttccom001200 as cr_tccom001 on dmisg168.t_user=cr_tccom001.t_emno "
          Sql &= "  inner join ttccom001200 as by_tccom001 on dmisg168.t_bpid=by_tccom001.t_emno "
          Sql &= "  where dmisg168.t_pwfd = 0 "
          Sql &= "  and dmisg140.t_cprj='" & MetaData.t_cprj & "' "
          Sql &= "  and dmisg140.t_iref='" & MetaData.t_iref & "' "
        Case "MFG"
        Case "EREC"
        Case "DISP"
        Case "RECPT"
        Case "OTHERS"
      End Select

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As DetailData = New DetailData(Reader)
            tmp.Add(x)
          End While
          Reader.Close()
        End Using
      End Using
      If MetaData.t_acty = "RFQ-TO-PO" Then
        'Populate Indent No From Joomla : Outer Join
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Con.Open()
          For Each wf As DetailData In tmp
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = "Select isnull(indentno,'') +'|'+ ltrim(str(isnull(IndentLine,'0'))) as x  from wf1_preorder where wfid=" & wf.WorkFlowID
              Dim x As String = Cmd.ExecuteScalar
              If x IsNot Nothing Then
                Dim a() As String = x.Split("|".ToCharArray)
                wf.IndentNo = a(0)
                wf.IndentLineNo = a(1)
              End If
            End Using
          Next
        End Using
        'Populate PO No
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Con.Open()
          For Each wf As DetailData In tmp
            If wf.IndentNo <> "" Then
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "Select isnull(t_prno,'') +'|'+ ltrim(str(isnull(t_ppon,'0'))) as x from ttdpur202200 where t_rqno='" & wf.IndentNo & "' and t_pono=" & wf.IndentLineNo
                Dim x As String = Cmd.ExecuteScalar
                If x IsNot Nothing Then
                  Dim a() As String = x.Split("|".ToCharArray)
                  wf.PurchaseOrder = a(0)
                  wf.PurchaseOrderLine = a(1)
                End If
              End Using
            End If
          Next
        End Using
      End If
      Return tmp
    End Function
    Public Shared Function GetHeader(ByVal t_acty As String) As TableHeaderRow
      Dim th As New TableHeaderRow
      th.Attributes.Add("style", "background-color:black;color:white;font-size:14px;")
      th.TableSection = TableRowSection.TableHeader

      Select Case t_acty
        Case "DESIGN"
          For i As Integer = 0 To 9
            Dim thc As New TableHeaderCell
            With thc
              .Attributes.Add("style", "text-align:center;")
              .Font.Bold = True
              Select Case i
                Case 0
                  .Text = "DOCUMENT"
                Case 1
                  .Text = "REV."
                Case 2
                  .Text = "TITLE"
                Case 3
                  .Text = "SCHD. START"
                Case 4
                  .Text = "SCHD. FINISH"
                Case 5
                  .Text = "ACT. START"
                Case 6
                  .Text = "ACT. FINISH"
                Case 7
                  .Text = "OL. START"
                Case 8
                  .Text = "OL. FINISH"
                Case 9
                  .Text = "ENG.FUNC."
              End Select
              th.Cells.Add(thc)
            End With
          Next
        Case "INDT"
          For i As Integer = 0 To 10
            Dim thc As New TableHeaderCell
            With thc
              .Attributes.Add("style", "text-align:center;")
              .Font.Bold = True
              Select Case i
                Case 0
                  .Text = "INDENT NO."
                Case 1
                  .Text = "LINE NO"
                Case 2
                  .Text = "INDENT DT."
                Case 3
                  .Text = "INDENTER"
                Case 4
                  .Text = "BUYER"
                Case 5
                  .Text = "DOCUMENT"
                Case 6
                  .Text = "REV."
                Case 7
                  .Text = "ITEM"
                Case 8
                  .Text = "ITEM DESC."
                Case 9
                  .Text = "PO NO"
                Case 10
                  .Text = "PO LINE"
              End Select
              th.Cells.Add(thc)
            End With
          Next
        Case "RFQ-TO-PO"
          For i As Integer = 0 To 10
            Dim thc As New TableHeaderCell
            With thc
              .Attributes.Add("style", "text-align:center;")
              .Font.Bold = True
              Select Case i
                Case 0
                  .Text = "WFID"
                Case 1
                  .Text = "CREATED ON"
                Case 2
                  .Text = "CREATED BY"
                Case 3
                  .Text = "STATUS"
                Case 4
                  .Text = "BUYER"
                Case 5
                  .Text = "DOCUMENT"
                Case 6
                  .Text = "REV."
                Case 7
                  .Text = "INDENT NO."
                Case 8
                  .Text = "LINE NO"
                Case 9
                  .Text = "PO NO"
                Case 10
                  .Text = "PO LINE"
              End Select
              th.Cells.Add(thc)
            End With
          Next
        Case "MFG"
        Case "EREC"
        Case "DISP"
        Case "RECPT"
        Case "OTHERS"
      End Select

      Return th
    End Function

  End Class
End Class
