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
    Dim dMeta As DetailData = DetailData.GetMetaData(t_cprj, t_cact)
    SubHeader.Text = ActivityTypeName & " - " & dMeta.t_iref

    Dim tbl As New Table
    With tbl
      .ID = "tblDetail"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableHeaderRow
    th = DetailData.GetHeader(dMeta)
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim data As List(Of DetailData) = DetailData.GetData(dMeta)
    For Each dt As DetailData In data
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
          For I As Integer = 0 To 8
            td = New TableCell
            With td
              Select Case I
                Case 0
                  .Text = dt.t_docn
                Case 1
                  .Text = dt.t_revn
                  .Attributes.Add("style", "text-align:center;")
                Case 2
                  .Text = dt.t_dsca
                Case 3
                  .Text = dt.t_bssd
                  .Attributes.Add("style", "text-align:center;")
                Case 4
                  .Text = dt.t_bsfd
                  .Attributes.Add("style", "text-align:center;")
                Case 5
                  .Text = dt.t_acdt
                  .Attributes.Add("style", "text-align:center;")
                Case 6
                  .Text = dt.t_rssd
                  .Attributes.Add("style", "text-align:center;")
                Case 7
                  .Text = dt.t_rsfd
                  .Attributes.Add("style", "text-align:center;")
                Case 8
                  .Text = dt.t_resp
                  .Attributes.Add("style", "text-align:center;")
              End Select
            End With
            tr.Cells.Add(td)
          Next
        Case "INDT"
          For I As Integer = 0 To 9
            td = New TableCell
            With td
              Select Case I
                Case 0
                  .Text = dt.IndentNo
                  .Attributes.Add("style", "text-align:center;")
                Case 1
                  .Text = dt.IndentDate
                  .Attributes.Add("style", "text-align:center;")
                Case 2
                  '.Text = "[" & dt.Indenter & "] " & dt.IndenterName
                  .Text = dt.IndenterName
                Case 3
                  '.Text = "[" & dt.Buyer & "] " & dt.BuyerName
                  .Text = dt.BuyerName
                Case 4
                  .Text = dt.DcoumentID
                Case 5
                  .Text = dt.DocumentRev
                  .Attributes.Add("style", "text-align:center;")
                Case 6
                  .Text = dt.ItemCode
                Case 7
                  .Text = dt.ItemDescription
                Case 8
                  .Text = dt.PurchaseOrder
                  .Attributes.Add("style", "text-align:center;")
                Case 9
                  .Text = dt.PurchaseOrderLine
                  .Attributes.Add("style", "text-align:center;")
              End Select
            End With
            tr.Cells.Add(td)
          Next
        Case "RFQ-TO-PO"
          Select Case dMeta.t_bohd
            Case "CT_RFQRAISED", "CT_RFQOFFERECEIVED", "CT_RFQCOMMERCIALFINALISED"
              Dim bgClass As System.Drawing.Color = IIf(dt.SupplierName <> "", Drawing.Color.White, Drawing.Color.Cyan)
              If dt.WFStatus = "Technical Specification Released Returned" Then
                bgClass = Drawing.Color.MistyRose
              End If
              tr.BackColor = bgClass
              For I As Integer = -1 To 9
                td = New TableCell
                With td
                  Select Case I
                    Case -1
                      .Text = dt.dWorkFlowID
                      .Attributes.Add("style", "text-align:center;")
                    Case 0
                      .Text = dt.EnquiryID
                      .Attributes.Add("style", "text-align:center;")
                    Case 1
                      .Text = dt.CreatedOn
                      .Attributes.Add("style", "text-align:center;")
                    Case 2
                      .Text = dt.CreatedName
                    Case 3
                      .Text = dt.WFStatus
                    Case 4
                      .Text = dt.BuyerName
                    Case 5
                      .Text = dt.DcoumentID
                    Case 6
                      .Text = dt.DocumentRev
                      .Attributes.Add("style", "text-align:center;")
                    Case 7
                      .Text = dt.SupplierName
                    Case 8
                      .Text = dt.PurchaseOrder
                      .Attributes.Add("style", "text-align:center;")
                    Case 9
                      .Text = dt.PurchaseOrderLine
                      .Attributes.Add("style", "text-align:center;")
                  End Select
                End With
                tr.Cells.Add(td)
              Next
            Case "CT_POAPPROVED", "CT_POSENTFORAPPROVAL"
              For I As Integer = 0 To 9
                td = New TableCell
                With td
                  Select Case I
                    Case 0
                      .Text = dt.PurchaseOrder
                      .Attributes.Add("style", "text-align:center;")
                    Case 1
                      .Text = dt.PurchaseOrderLine
                      .Attributes.Add("style", "text-align:center;")
                    Case 2
                      .Text = dt.PODate
                      .Attributes.Add("style", "text-align:center;")
                    Case 3
                      .Text = dt.SupplierName
                    Case 4
                      .Text = dt.POStatus
                      .Attributes.Add("style", "text-align:center;")
                    Case 5
                      .Text = dt.BuyerName
                    Case 6
                      .Text = dt.DcoumentID
                    Case 6
                      .Text = dt.DocumentRev
                      .Attributes.Add("style", "text-align:center;")
                    Case 8
                      .Text = dt.ItemCode
                    Case 9
                      .Text = dt.ItemDescription
                  End Select
                End With
                tr.Cells.Add(td)
              Next
          End Select
        Case "MFG"
        Case "EREC"
        Case "DISP"
        Case "RECPT"
        Case "OTHERS"

      End Select
      tbl.Rows.Add(tr)
      Select Case dMeta.t_acty
        Case "RFQ-TO-PO"
          Select Case dMeta.t_bohd
            Case "CT_RFQRAISED", "CT_RFQOFFERECEIVED", "CT_RFQCOMMERCIALFINALISED"
              If dt.WFStatus = "Technical offer Received" Then
                If dt.ReceiptNo <> "" Then
                  tr = New TableRow
                  tr.TableSection = TableRowSection.TableBody
                  tr.CssClass = "btn-outline-warning"
                  tr.ForeColor = Drawing.Color.Black
                  td = New TableCell
                  td.ColumnSpan = 2
                  tr.Cells.Add(td)
                  td = New TableCell
                  td.ColumnSpan = 9
                  td.Controls.Add(GetIDMSTable(dt.ReceiptNo))
                  tr.Cells.Add(td)
                  tbl.Rows.Add(tr)
                End If
              End If
          End Select
      End Select

    Next
    Return tbl
  End Function
  Private Function GetIDMSTable(ByVal ReceiptNo As String) As Table
    Dim tbl As New Table
    With tbl
      .ID = "tblIDMSDetail"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableHeaderRow
    For i As Integer = 0 To 7
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Font.Bold = True
        Select Case i
          Case 0
            .Text = "RECEIPT NO"
          Case 1
            .Text = "REV"
          Case 2
            .Text = "CREATED BY"
          Case 3
            .Text = "CREATED ON"
          Case 4
            .Text = "DISTRIBUTED BY"
          Case 5
            .Text = "DISTRIBUTED ON"
          Case 6
            .Text = "ENGG.DECIPLENEs"
          Case 7
            .Text = "STATUS"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim data As List(Of IDMSReceipt) = IDMSReceipt.GetData(ReceiptNo)
    For Each dt As IDMSReceipt In data
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 7
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.ReceiptNo
              .Attributes.Add("style", "text-align:center;")
            Case 1
              .Text = dt.ReceiptRev
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.CreaterName
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.CreatedOn
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.DistributerName
              .Attributes.Add("style", "text-align:center;")
            Case 5
              .Text = dt.DistributedOn
              .Attributes.Add("style", "text-align:center;")
            Case 6
              .Text = dt.DistributedTo
            Case 7
              .Text = dt.Status
              .Attributes.Add("style", "text-align:center;")
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
      '=========Response=====
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      td = New TableCell
      td.ColumnSpan = 2
      tr.Cells.Add(td)
      td = New TableCell
      td.ColumnSpan = 6
      td.Controls.Add(GetResponseTable(dt.ReceiptNo, dt.ReceiptRev))
      tr.Cells.Add(td)
      tbl.Rows.Add(tr)
      '======================
    Next
    Return tbl

  End Function
  Private Function GetResponseTable(ByVal ReceiptNo As String, ByVal Rev As String) As Table
    Dim tbl As New Table
    With tbl
      .ID = "tblRespDetail"
      .ClientIDMode = ClientIDMode.Static
      .CssClass = "table-bordered"
      .Width = Unit.Percentage(100)
    End With
    'Write Header
    Dim th As New TableHeaderRow
    For i As Integer = 0 To 4
      Dim thc As New TableHeaderCell
      With thc
        .Attributes.Add("style", "text-align:center;")
        .Font.Bold = True
        Select Case i
          Case 0
            .Text = "ENGG.DECIPLENE"
          Case 1
            .Text = "CREATED BY"
          Case 2
            .Text = "CREATED ON"
          Case 3
            .Text = "STATUS"
          Case 4
            .Text = "REMARKS"
        End Select
        th.Cells.Add(thc)
      End With
    Next
    tbl.Rows.Add(th)
    'Write Data
    Dim RowColor As Boolean = False
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing
    Dim data As List(Of IDMSReceiptResponse) = IDMSReceiptResponse.GetData(ReceiptNo, Rev)
    For Each dt As IDMSReceiptResponse In data
      tr = New TableRow
      tr.TableSection = TableRowSection.TableBody
      If RowColor Then
        tr.BackColor = System.Drawing.Color.WhiteSmoke
      End If
      RowColor = Not RowColor
      tr.CssClass = "btn-outline-warning"
      tr.ForeColor = Drawing.Color.Black
      For I As Integer = 0 To 4
        td = New TableCell
        With td
          Select Case I
            Case 0
              .Text = dt.ResponseFrom
              .Attributes.Add("style", "text-align:center;")
            Case 1
              .Text = dt.CreaterName
              .Attributes.Add("style", "text-align:center;")
            Case 2
              .Text = dt.CreatedOn
              .Attributes.Add("style", "text-align:center;")
            Case 3
              .Text = dt.Status
              .Attributes.Add("style", "text-align:center;")
            Case 4
              .Text = dt.Remarks
          End Select
        End With
        tr.Cells.Add(td)
      Next
      tbl.Rows.Add(tr)
    Next
    Return tbl

  End Function

  Public Class IDMSReceipt

    'IDMS Receipt
    Public Property ReceiptNo As String = ""
    Public Property ReceiptRev As String = ""
    Public Property CreatedBy As String = ""
    Private Property _CreatedOn As String = ""
    Public Property CreatedOn As String
      Get
        If _CreatedOn <> "" Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return ""
      End Get
      Set(value As String)
        _CreatedOn = value
      End Set
    End Property
    Public Property DistributedBy As String = ""
    Private Property _DistributedOn As String = ""
    Public Property DistributedOn As String
      Get
        If _DistributedOn <> "" Then
          Return Convert.ToDateTime(_DistributedOn).ToString("dd/MM/yyyy")
        End If
        Return ""
      End Get
      Set(value As String)
        _DistributedOn = value
      End Set
    End Property
    Public Property DistributedTo As String = ""
    Public Property CreaterName As String = ""
    Public Property DistributerName As String = ""

    Public Property Status As String = ""



    Public Shared Function GetData(ByVal ReceiptNo As String) As List(Of IDMSReceipt)
      Dim tmp As New List(Of IDMSReceipt)
      Dim Sql As String = ""
      Sql &= "  select "
      Sql &= "   t_rcno as ReceiptNo, "
      Sql &= "   t_revn as ReceiptRev, "
      Sql &= "   (case t_stat when 1 then 'Submitted' when 2 then 'Linked' when 3 then 'Under Evaluation' when 4 then 'Commented' when 5 then 'Technically Cleared' when 6 then 'Issued' when 7 then 'Superseded' when 8 then 'Closed' end) as Status, "
      Sql &= "   t_user as CreatedBy, "
      Sql &= "   t_date as CreatedOn, "
      Sql &= "   t_suer as DistributedBy, "
      Sql &= "   t_sdat as DistributedOn, "
      Sql &= "   cr_tccom001.t_nama as CreaterName, "
      Sql &= "   di_tccom001.t_nama as DistributerName, "
      Sql &= "   str(t_sent_1)+'|'+str(t_sent_2)+'|'+str(t_sent_3)+'|'+str(t_sent_4)+'|'+str(t_sent_5)+'|'+str(t_sent_6)+'|'+str(t_sent_7) as DistributedTo "
      Sql &= "  from tdmisg134200 as dmisg134 "
      Sql &= "   inner join ttccom001200 as cr_tccom001 on dmisg134.t_user=cr_tccom001.t_emno "
      Sql &= "   inner join ttccom001200 as di_tccom001 on dmisg134.t_suer=di_tccom001.t_emno "
      Sql &= "  where t_rcno='" & ReceiptNo & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As IDMSReceipt = New IDMSReceipt(Reader)
            Dim y() As String = x.DistributedTo.Split("|".ToCharArray)
            x.DistributedTo = ""
            If y(0).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Mech.", ", Mech.")
            If y(1).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Stru.", ", Stru.")
            If y(2).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Piping", ", Piping")
            If y(3).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Process", ", Process")
            If y(4).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "C & I", ", C & I")
            If y(5).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Elec.", ", Elec.")
            If y(6).Trim = "1" Then x.DistributedTo &= IIf(x.DistributedTo = "", "Quality", ", Quality")
            tmp.Add(x)
          End While
          Reader.Close()
        End Using
      End Using
      Return tmp
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
  Public Class IDMSReceiptResponse
    Public Property ReceiptNo As String = ""
    Public Property ReceiptRev As String = ""
    Public Property ResponseFrom As String = ""
    Private Property _CreatedOn As String = ""
    Public Property CreatedOn As String
      Get
        If _CreatedOn <> "" Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return ""
      End Get
      Set(value As String)
        _CreatedOn = value
      End Set
    End Property
    Public Property CreatedBy As String = ""
    Public Property Status As String = ""
    Public Property Remarks As String = ""
    Public Property CreaterName As String = ""
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

    Public Shared Function GetData(ByVal ReceiptNo As String, ByVal Rev As String) As List(Of IDMSReceiptResponse)
      Dim tmp As New List(Of IDMSReceiptResponse)
      Dim Sql As String = ""
      Sql &= "  select "
      Sql &= "   t_rcno as ReceipNo, "
      Sql &= "   t_revn as ReceiptRev, "
      Sql &= "   (case t_engi when 1 then 'Mech.' when 2 then 'Stru.' when 3 then 'Piping' when 4 then 'Process' when 5 then 'C & I' when 6 then 'Elec.' when 7 then 'Quality' end  ) as ResponseFrom, "
      Sql &= "   (case t_cler when 2 then 'Commented' when 1 then 'Technically Cleared' end) as Status, "
      Sql &= "   t_logn as CreatedBy, "
      Sql &= "   t_date as CreatedOn, "
      Sql &= "   t_remk as Remarks, "
      Sql &= "   cr_tccom001.t_nama as CreaterName "
      Sql &= "   from tdmisg136200 as dmisg136 "
      Sql &= "   inner join ttccom001200 as cr_tccom001 on dmisg136.t_logn=cr_tccom001.t_emno "
      Sql &= "   where t_rcno='" & ReceiptNo & "' and t_revn='" & Rev & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As IDMSReceiptResponse = New IDMSReceiptResponse(Reader)
            tmp.Add(x)
          End While
          Reader.Close()
        End Using
      End Using
      Return tmp
    End Function

  End Class
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
    Public Property ForOrder As String = ""
    Public Property EnquiryID As String = ""
    Public Property dWorkFlowID As String = ""
    Public Property WorkFlowID As String = ""
    Public Property WFStatus As String = ""
    Public Property Created As String = ""
    Public Property CreatedName As String = ""
    Public Property ReceiptNo As String = ""
    Private _CreatedOn As String = ""
    Public Property CreatedOn As String
      Get
        If _CreatedOn <> "" Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(value As String)
        _CreatedOn = value
      End Set
    End Property
    Public Property SupplierCode As String = ""
    Public Property SupplierName As String = ""
    'Indent Fields
    Public Property PurchaseOrder As String = ""
    Public Property PurchaseOrderLine As String = ""
    Public Property POStatus As String = ""
    Private _PODate As String = ""
    Public Property PODate As String
      Get
        If _PODate <> "" Then
          Return Convert.ToDateTime(_PODate).ToString("dd/MM/yyyy")
        End If
        Return ""
      End Get
      Set(value As String)
        _PODate = value
      End Set
    End Property
    Private _IndentDate As String = ""
    Public Property IndentDate As String
      Get
        If _IndentDate <> "" Then
          Return Convert.ToDateTime(_IndentDate).ToString("dd/MM/yyyy")
        End If
        Return _IndentDate
      End Get
      Set(value As String)
        _IndentDate = value
      End Set
    End Property
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
    Private _t_rsfd As String = ""
    Public Property t_rsfd As String
      Get
        If _t_rsfd <> "" Then
          If Convert.ToDateTime(_t_rsfd).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_rsfd).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_rsfd = value
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
    Private _t_acdt As String = ""
    Public Property t_acdt As String
      Get
        If _t_acdt <> "" Then
          If Convert.ToDateTime(_t_acdt).Year <= 2000 Then
            Return ""
          Else
            Return Convert.ToDateTime(_t_acdt).ToString("dd/MM/yyyy")
          End If
        End If
        Return ""
      End Get
      Set(value As String)
        _t_acdt = value
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
          Sql &= "   dateadd(n,330,t_bssd) as t_bssd, "
          Sql &= "   dateadd(n,330,t_bsfd) as t_bsfd, "
          Sql &= "   dateadd(n,330,t_rssd) as t_rssd, "
          Sql &= "   dateadd(n,330,t_rsfd) as t_rsfd, "
          Sql &= "   t_lrrd, "
          Sql &= "   t_rdat, "
          Sql &= "   t_acdt, "
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
          Select Case MetaData.t_bohd
            Case "CT_RFQRAISED", "CT_RFQOFFERECEIVED", "CT_RFQCOMMERCIALFINALISED"
              Sql &= "  select distinct "
              Sql &= "  (case when t_pwfd=0 then str(dmisg168.t_wfid) else str(dmisg168.t_pwfd) end)+'|'+str(dmisg168.t_wfid) as ForOrder, "
              Sql &= "  dmisg168.t_stat as WFStatus, "
              Sql &= "  dmisg168.t_user as Created, "
              Sql &= "  cr_tccom001.t_nama as CreatedName, "
              Sql &= "  convert(nvarchar(10),dmisg168.t_date,103) as CreatedOn, "
              Sql &= "  dmisg168.t_bpid as Buyer, "
              Sql &= "  by_tccom001.t_nama as BuyerName, "
              Sql &= "  dmisg140.t_docn as DcoumentID, "
              Sql &= "  dmisg140.t_revn as DocumentRev  "
              Sql &= "  from tdmisg169200 as dmisg168  "
              Sql &= "  inner join tdmisg167200 as dmisg167 on (dmisg168.t_pwfd=dmisg167.t_wfid or dmisg168.t_wfid=dmisg167.t_wfid) "
              Sql &= "  inner join tdmisg140200 as dmisg140 on dmisg167.t_docn=dmisg140.t_docn "
              Sql &= "  inner join ttccom001200 as cr_tccom001 on dmisg168.t_user=cr_tccom001.t_emno "
              Sql &= "  inner join ttccom001200 as by_tccom001 on dmisg168.t_bpid=by_tccom001.t_emno "
              Sql &= "  where  "
              Sql &= "      dmisg168.t_stat <> 'Enquiry in progress'  "
              Sql &= "  and dmisg140.t_cprj='" & MetaData.t_cprj & "' "
              Sql &= "  and dmisg140.t_iref='" & MetaData.t_iref & "' "
              Sql &= "  order by (case when t_pwfd=0 then str(dmisg168.t_wfid) else str(dmisg168.t_pwfd) end)+'|'+str(dmisg168.t_wfid) "
            Case "CT_POAPPROVED", "CT_POSENTFORAPPROVAL"
              Sql &= " select distinct      "
              Sql &= " tdpur400.t_ccon as Buyer,  "
              Sql &= " tdpur400.t_otbp as SupplierCode, "
              Sql &= " tccom100.t_nama as SupplierName,    "
              Sql &= " by_tccom001.t_nama as BuyerName,    "
              Sql &= " tdisg002.t_orno As PurchaseOrder,  "
              Sql &= " (case tdpur400.t_hdst  "
              Sql &= " when 5 then 'Created'  "
              Sql &= " when 10 then 'Approved'  "
              Sql &= " when 15 then 'Sent'  "
              Sql &= " when 20 then 'In Process' "
              Sql &= " when 25 then 'Closed' "
              Sql &= " when 30 then 'Cancelled' "
              Sql &= " when 35 then 'Modified' "
              Sql &= " when 40 then 'N/A' "
              Sql &= " when 45 then 'Released' "
              Sql &= " end) as POStatus, "
              Sql &= " tdisg002.t_pono as PurchaseOrderLine, "
              Sql &= " tdisg002.t_item As ItemCode,     "
              Sql &= " tdisg002.t_desc as ItemDescription,     "
              Sql &= " tdisg002.t_docn as DcoumentID,     "
              Sql &= " tdisg002.t_revi as DocumentRev      "
              Sql &= " from ttdpur400200 as tdpur400     "
              Sql &= " inner join ttccom001200 as by_tccom001 on tdpur400.t_ccon=by_tccom001.t_emno     "
              Sql &= " inner join ttdisg002200 as tdisg002 on tdpur400.t_orno=tdisg002.t_orno      "
              Sql &= " inner join ttccom100200 as tccom100 on tdpur400.t_otbp=tccom100.t_bpid     "
              Sql &= " where tdisg002.t_docn in     "
              Sql &= " ( "
              Sql &= " select t_docn from tdmisg140200  "
              Sql &= " where t_cprj='" & MetaData.t_cprj & "' "
              Sql &= " and t_iref='" & MetaData.t_iref & "' "
              Sql &= " ) "
            Case "CT_ISSUEPO"
            Case "CT_POBANKGUARANTEE"
            Case "CT_FIRSTADVANCERELEASE"
            Case "CT_RESTADVANCERELEASE"
          End Select
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
            If x.ForOrder <> "" Then
              Dim y() As String = x.ForOrder.Split("|".ToCharArray)
              x.WorkFlowID = y(1)
              x.EnquiryID = IIf(y(0) = y(1), "-", y(1))
              x.dWorkFlowID = IIf(y(0) <> y(1), "-", y(1))
            End If
            tmp.Add(x)
          End While
          Reader.Close()
        End Using
      End Using
      If MetaData.t_acty = "RFQ-TO-PO" Then
        Select Case MetaData.t_bohd
          Case "CT_RFQRAISED", "CT_RFQOFFERECEIVED", "CT_RFQCOMMERCIALFINALISED"
            'Populate Indent No From Joomla : Outer Join
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
              Con.Open()
              For Each wf As DetailData In tmp
                Using Cmd As SqlCommand = Con.CreateCommand()
                  Cmd.CommandType = CommandType.Text
                  Cmd.CommandText = "Select isnull(indentno,'') +'|'+ ltrim(str(isnull(IndentLine,'0'))) +'|'+ isnull(SupplierCode,'') +'|'+ isnull(SupplierName,'') +'|'+ isnull(ReceiptNo,'') as x  from wf1_preorder where wfid=" & wf.WorkFlowID
                  Dim x As String = Cmd.ExecuteScalar
                  If x IsNot Nothing Then
                    Dim a() As String = x.Split("|".ToCharArray)
                    wf.IndentNo = a(0)
                    wf.IndentLineNo = a(1)
                    wf.SupplierCode = a(2)
                    wf.SupplierName = a(3)
                    wf.ReceiptNo = a(4)
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
        End Select
      End If
      Return tmp
    End Function
    Public Shared Function GetHeader(ByVal mData As DetailData) As TableHeaderRow
      Dim th As New TableHeaderRow
      th.Attributes.Add("style", "background-color:black;color:white;font-size:14px;")
      th.TableSection = TableRowSection.TableHeader

      Select Case mData.t_acty
        Case "DESIGN"
          For i As Integer = 0 To 8
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
                  .Text = "ACT. FINISH"
                Case 6
                  .Text = "OL. START"
                Case 7
                  .Text = "OL. FINISH"
                Case 8
                  .Text = "ENG.FUNC."
              End Select
              th.Cells.Add(thc)
            End With
          Next
        Case "INDT"
          For i As Integer = 0 To 9
            Dim thc As New TableHeaderCell
            With thc
              .Attributes.Add("style", "text-align:center;")
              .Font.Bold = True
              Select Case i
                Case 0
                  .Text = "INDENT NO."
                Case 1
                  .Text = "INDENT DT."
                Case 2
                  .Text = "INDENTER"
                Case 3
                  .Text = "BUYER"
                Case 4
                  .Text = "DOCUMENT"
                Case 5
                  .Text = "REV."
                Case 6
                  .Text = "ITEM"
                Case 7
                  .Text = "ITEM DESC."
                Case 8
                  .Text = "PO NO"
                Case 9
                  .Text = "PO LINE"
              End Select
              th.Cells.Add(thc)
            End With
          Next
        Case "RFQ-TO-PO"
          Select Case mData.t_bohd
            Case "CT_RFQRAISED", "CT_RFQOFFERECEIVED", "CT_RFQCOMMERCIALFINALISED"
              For i As Integer = -1 To 9
                Dim thc As New TableHeaderCell
                With thc
                  .Attributes.Add("style", "text-align:center;")
                  .Font.Bold = True
                  Select Case i
                    Case -1
                      .Text = "WFID"
                    Case 0
                      .Text = "ENQUIRY"
                    Case 1
                      .Text = "ACTION DATE"
                    Case 2
                      .Text = "ACTION BY"
                    Case 3
                      .Text = "STATUS"
                    Case 4
                      .Text = "BUYER"
                    Case 5
                      .Text = "DOCUMENT"
                    Case 6
                      .Text = "REV."
                    Case 7
                      .Text = "SUPPLIER"
                    Case 8
                      .Text = "PO NO"
                    Case 9
                      .Text = "PO LINE"
                  End Select
                  th.Cells.Add(thc)
                End With
              Next
            Case "CT_POAPPROVED", "CT_POSENTFORAPPROVAL"
              For i As Integer = 0 To 9
                Dim thc As New TableHeaderCell
                With thc
                  .Attributes.Add("style", "text-align:center;")
                  .Font.Bold = True
                  Select Case i
                    Case 0
                      .Text = "PO NO"
                    Case 1
                      .Text = "PO LINE"
                    Case 2
                      .Text = "PO DATE"
                    Case 3
                      .Text = "SUPPLIER"
                    Case 4
                      .Text = "STATUS"
                    Case 5
                      .Text = "BUYER"
                    Case 6
                      .Text = "DOCUMENT"
                    Case 7
                      .Text = "REV."
                    Case 8
                      .Text = "ITEM"
                    Case 9
                      .Text = "ITEM DESC."
                  End Select
                  th.Cells.Add(thc)
                End With
              Next
            Case "CT_ISSUEPO"
            Case "CT_POBANKGUARANTEE"
            Case "CT_FIRSTADVANCERELEASE"
            Case "CT_RESTADVANCERELEASE"
          End Select
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
