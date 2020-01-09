Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports AjaxControlToolkit
Imports System.Collections.Generic
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://cloud.isgec.co.in/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class MfgServices
  Inherits System.Web.Services.WebService
  <WebMethod(EnableSession:=True)>
  Public Function GetContractsCashflow(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim Contracts As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= " select distinct * from ( "
    Sql &= "  select distinct aa.t_ccod,bb.t_ccno +' '+ bp.t_nama as t_ccno from ttpisg089200 as aa inner join ttpisg087200 as bb on aa.t_ccod = bb.t_ccod  inner join ttccom100200 as bp on bp.t_bpid=bb.t_cust "
    Sql &= "  union all  "
    Sql &= "  select distinct aa.t_ccod,bb.t_ccno +' '+ bp.t_nama as t_ccno from ttpisg088200 as aa inner join ttpisg087200 as bb on aa.t_ccod = bb.t_ccod inner join ttccom100200 as bp on bp.t_bpid=bb.t_cust where aa.t_cprj in (select t_cprj from ttpisg086200)  "
    Sql &= "  union all  "
    Sql &= "  select distinct aa.t_ccod,bb.t_ccno +' '+ bp.t_nama as t_ccno from ttpisg088200 as aa inner join ttpisg087200 as bb on aa.t_ccod = bb.t_ccod inner join ttccom100200 as bp on bp.t_bpid=bb.t_cust where aa.t_cprj in (select t_cprj from ttfisg016200)  "
    Sql &= "  union all  "
    Sql &= "  select distinct aa.t_ccod,bb.t_ccno +' '+ bp.t_nama as t_ccno from ttpisg088200 as aa inner join ttpisg087200 as bb on aa.t_ccod = bb.t_ccod inner join ttccom100200 as bp on bp.t_bpid=bb.t_cust where aa.t_cprj in (select t_cprj from ttfisg017200) "
    Sql &= "  ) as tmp "
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Contracts.Add(New CascadingDropDownNameValue() With {.name = Reader("t_ccod") & "-" & Reader("t_ccno"), .value = Reader("t_ccod")})
        End While
        Reader.Close()
      End Using
    End Using
    Return Contracts.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetContracts(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim Contracts As New List(Of CascadingDropDownNameValue)
    Dim UserID As String = HttpContext.Current.Session("LoginID")
    Dim tmpCs As List(Of SIS.CT.ctContracts) = SIS.CT.ctContracts.ctProjectsSelectList("")
    For Each tmpP As SIS.CT.ctContracts In tmpCs
      Contracts.Add(New CascadingDropDownNameValue() With {.name = tmpP.t_ccod & "-" & tmpP.t_ccno, .value = tmpP.t_ccod})
    Next
    Return Contracts.ToArray()
  End Function

  <WebMethod(EnableSession:=True)>
  Public Function GetProjects(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim Projects As New List(Of CascadingDropDownNameValue)
    Dim UserID As String = HttpContext.Current.Session("LoginID")
    Dim tmpPs As List(Of SIS.CT.ctUserProject) = SIS.CT.ctUserProject.ctUserProjectSelectList(0, 9999, "", False, "", UserID, "")
    For Each tmpP As SIS.CT.ctUserProject In tmpPs
      Projects.Add(New CascadingDropDownNameValue() With {.name = tmpP.ProjectID & "-" & tmpP.IDM_Projects2_Description, .value = tmpP.ProjectID})
    Next
    Return Projects.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetYNRSuppliers(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim ProjectID As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_cprj")
    Dim Suppliers As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= " select distinct pH.t_otbp + '-' + tc.t_nama, pH.t_otbp + '_' + pD.t_cprj as x_otbp from ttdpur400200 as pH "
    Sql &= " inner join ttdpur401200 as pD on pH.t_orno = pD.t_orno "
    Sql &= " inner join ttccom100200 As tc On pH.t_otbp = tc.t_bpid and tc.t_bpid='SUPI00002'"
    Sql &= " where pD.t_cprj='" & ProjectID & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Suppliers.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return Suppliers.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetSuppliers(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim ProjectID As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_cprj")
    Dim Suppliers As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= " select distinct pH.t_otbp + '-' + tc.t_nama, pH.t_otbp + '_' + pD.t_cprj as x_otbp from ttdpur400200 as pH "
    Sql &= " inner join ttdpur401200 as pD on pH.t_orno = pD.t_orno "
    Sql &= " inner join ttccom100200 As tc On pH.t_otbp = tc.t_bpid "
    Sql &= " where pD.t_cprj='" & ProjectID & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Suppliers.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return Suppliers.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetOrders(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim aVal() As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_bpid").Split("_".ToCharArray)
    Dim SupplierID As String = aVal(0)
    Dim ProjectID As String = aVal(1)
    Dim Orders As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= " select distinct pH.t_orno, pH.t_orno as x_prno from ttdpur400200 as pH "
    Sql &= " inner join ttdpur401200 as pD on pH.t_orno = pD.t_orno "
    Sql &= " where pD.t_cprj='" & ProjectID & "'"
    Sql &= " and pH.t_otbp = '" & SupplierID & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Orders.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return Orders.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetIrefs(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim OrderNo As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_orno")
    Dim Irefs As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= " select distinct t220.t_sub1, t220.t_sub1 + '_' + t220.t_cprj + '_" & OrderNo & "'"
    Sql &= " from ttpisg220200 as t220 "
    Sql &= "     inner join tdmisg140200 as t140 on t220.t_sub1 = t140.t_iref and t220.t_cprj = t140.t_cprj "
    Sql &= "     inner join ttdisg002200 as t002 on t140.t_docn = t002.t_docn "
    Sql &= " where "
    Sql &= "     t220.t_bohd = 'CT_MANUFACTURING' "
    Sql &= "     and t002.t_orno='" & OrderNo & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Irefs.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return Irefs.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetProjectIrefs(knownCategoryValues As String, contextKey As String) As CascadingDropDownNameValue()
    Dim ProjectID As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_cprj")
    Dim Irefs As New List(Of CascadingDropDownNameValue)
    Dim aVal() As String = contextKey.Split("|".ToCharArray)
    Dim Sql As String = ""
    Sql &= " select distinct t220.t_sub1, t220.t_sub1 + '_' + t220.t_cprj  "
    Sql &= " from ttpisg220200 as t220 "
    Sql &= " where "
    If aVal(1) = "CT_YNR" Then
      Sql &= "((t220.t_bohd = 'CT_MANUFACTURING' and t220.t_dept ='ISGYNR') OR (t220.t_bohd = 'CT_INSPECTIONBLACKCONDITION' and t220.t_dept ='PROJ') )"
    Else
      Sql &= "     (t220.t_bohd ='" & aVal(1) & "') "
    End If
    Sql &= "  and t220.t_cprj='" & ProjectID & "'"
    If Not aVal(0).ToLower.Contains("dummy") Then
      aVal(0) = "%" & aVal(0).ToLower & "%"
      Sql &= "  and LOWER(t220.t_sub1) like '" & aVal(0) & "'"
    End If
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Irefs.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return Irefs.ToArray()
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetMfgSubItems(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim aVal() As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_iref").Split("_".ToCharArray)
    Dim ItemRef As String = aVal(0)
    Dim ProjectID As String = aVal(1)
    Dim PoNo As String = aVal(2)
    Dim SubItems As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Dim poType As Integer = GetPOType(PoNo)
    Select Case poType
      Case pakErpPOTypes.ISGECEngineered
        Sql &= " select distinct ttpisg243200.t_sub2 + ' ' + ttpisg243200.t_sub3 + ' ' + ttpisg243200.t_sub4 As t_subx, "
        Sql &= " ttpisg243200.t_sitm   "
        Sql &= " from ttpisg220200, ttpisg243200 , tdmisg140200, ttdisg002200, tdmisg002200 "
        Sql &= " where ttpisg243200.t_iref = ttpisg220200.t_sub1 "
        Sql &= " and ttpisg243200.t_cprd = ttpisg220200.t_pcod   "
        Sql &= " and ttpisg220200.t_sitm = ttpisg243200.t_sitm "
        Sql &= " and ttpisg220200.t_sub1 = tdmisg140200.t_iref and ttpisg220200.t_cprj = tdmisg140200.t_cprj "
        Sql &= " and tdmisg140200.t_docn = ttdisg002200.t_docn "
        Sql &= " and tdmisg002200.t_docn = ttdisg002200.t_docn and tdmisg002200.t_item = ttdisg002200.t_item "
        Sql &= " and ttpisg220200.t_sitm = tdmisg002200.t_sitm  "
        Sql &= " and ttpisg220200.t_bohd = 'CT_MANUFACTURING' "
        Sql &= " and ttpisg220200.t_cprj='" & ProjectID & "'"
        Sql &= " and ttpisg220200.t_sub1='" & ItemRef & "'"
        Sql &= " and ttdisg002200.t_orno='" & PoNo & "'"
      Case Else   ' pakErpPOTypes.Boughtout, pakErpPOTypes.Package
        'It is same as SubItem Function Given Below
        Sql &= "  select distinct t243.t_sub2 + ' ' + t243.t_sub3 + ' ' + t243.t_sub4 As t_subx, t243.t_sitm "
        Sql &= "  from ttpisg243200 as t243 "
        Sql &= "    inner join ttpisg220200 as t220 on t243.t_iref = t220.t_sub1 and t243.t_cprd = t220.t_pcod "
        Sql &= "  where "
        Sql &= "        t220.t_cprj='" & ProjectID & "'"
        Sql &= "    and t220.t_sub1='" & ItemRef & "'"
    End Select
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          SubItems.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return SubItems.ToArray()
  End Function
  Public Enum pakErpPOTypes
    ISGECEngineered = 1
    Package = 2
    Boughtout = 3
  End Enum

  Private Function GetPOType(ByVal PoNo As String) As Integer
    Dim mRet As Integer = 0
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "Select isnull(POTypeID,0) from PAK_PO where PONumber='" & PoNo & "'"
        Cmd.CommandTimeout = 150
        Con.Open()
        mRet = Cmd.ExecuteScalar
      End Using
    End Using
    Return mRet
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function GetSubItems(knownCategoryValues As String) As CascadingDropDownNameValue()
    Dim aVal() As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("t_iref").Split("_".ToCharArray)
    Dim ItemRef As String = aVal(0)
    Dim ProjectID As String = aVal(1)
    Dim SubItems As New List(Of CascadingDropDownNameValue)
    Dim Sql As String = ""
    Sql &= "  select distinct t243.t_sub2 + ' ' + t243.t_sub3 + ' ' + t243.t_sub4 As t_subx, t243.t_sitm "
    Sql &= "  from ttpisg243200 as t243 "
    Sql &= "    inner join ttpisg220200 as t220 on t243.t_iref = t220.t_sub1 and t243.t_cprd = t220.t_pcod "
    Sql &= "  where "
    Sql &= "        t220.t_cprj='" & ProjectID & "'"
    Sql &= "    and t220.t_sub1='" & ItemRef & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 150
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          SubItems.Add(New CascadingDropDownNameValue() With {.name = Reader(0).ToString(), .value = Reader(1).ToString()})
        End While
        Reader.Close()
      End Using
    End Using
    Return SubItems.ToArray()
  End Function

End Class