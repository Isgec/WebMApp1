Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.CT
  <DataObject()>
  Public Class outstandingChart
    Private Class ctData
      Implements ICloneable

      Public Property ValX As DateTime = Nothing
      Public Property TotalY As Double = 0.00
      Public Property NotDueY As Double = 0.00
      Public Property Slab1Y As Double = 0.00
      Public Property Slab2Y As Double = 0.00
      Public Property Slab3Y As Double = 0.00
      Public Property Slab4Y As Double = 0.00
      Public Property Slab5Y As Double = 0.00

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

      Public Function Clone() As Object Implements ICloneable.Clone
        Return DirectCast(MemberwiseClone(), ctData)
      End Function
    End Class
    Public Class Contracts
      Public Property ContractID As String = ""
      Public Property ContractName As String = ""
      Public Property Division As String = ""
      Sub New(id As String, nm As String, dv As String)
        ContractID = id
        ContractName = nm
        Select Case dv
          Case "EU200", "C200"
            Division = "BOILER"
          Case "EU210", "C210"
            Division = "EPC"
          Case "EU220", "C220"
            Division = "PC"
          Case "EU230", "C230"
            Division = "SMD"
          Case "EU240", "C240"
            Division = "APC"
        End Select
      End Sub
    End Class
    Public Property ContractID As String = ""
    Public Property OverallX As DateTime()
    Public Property TotalY As Double()
    Public Property NotDueY As Double()
    Public Property Slab1Y As Double()
    Public Property Slab2Y As Double()
    Public Property Slab3Y As Double()
    Public Property Slab4Y As Double()
    Public Property Slab5Y As Double()
    Public Property CurrentDate As DateTime = Now
    Public Property ContractList As New List(Of Contracts)
    Public Property MainContract As Contracts = Nothing

    Public Shared Function GetDataTable(mRet As outstandingChart, Optional Comp As String = "200") As String
      Dim mStr As String = ""
      Try
        Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
        Dim row2 As String = "<td><b>TOTAL OUTSTANDING</b></td>"
        Dim row3 As String = "<td><b>NOT DUE</b></td>"
        Dim row4 As String = "<td><b>&lt;1 Month</b></td>"
        Dim row5 As String = "<td><b>&gt;1 and &lt;6 Months</b></td>"
        Dim row6 As String = "<td><b>&gt;6 and &lt;12 Months</b></td>"
        Dim row7 As String = "<td><b>&gt;12 and &lt;24 Months</b></td>"
        Dim row8 As String = "<td><b>&gt;24 Months</b></td>"
        For I As Integer = 0 To mRet.OverallX.Length - 1
          Dim isCurrent As Boolean = False
          row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & mRet.OverallX(I).ToString("MMM-yyyy") & "</td>"
          Dim tmpP As Decimal = 0.00
          Dim sTmp As String = ""
          Try
            tmpP = mRet.TotalY(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row2 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.NotDueY(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.Slab1Y(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row4 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.Slab2Y(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row5 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.Slab3Y(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row6 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.Slab4Y(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row7 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpP = mRet.Slab5Y(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          row8 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
        Next

        mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
        mStr &= "<tr>" & row1 & "</tr>"
        mStr &= "<tr>" & row2 & "</tr>"
        mStr &= "<tr>" & row3 & "</tr>"
        mStr &= "<tr>" & row4 & "</tr>"
        mStr &= "<tr>" & row5 & "</tr>"
        mStr &= "<tr>" & row6 & "</tr>"
        mStr &= "<tr>" & row7 & "</tr>"
        mStr &= "<tr>" & row8 & "</tr>"
        mStr &= "</table>"
      Catch ex As Exception
        mStr = ex.Message
      End Try
      Return mStr
    End Function
    Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal bc As outstandingChart) As Chart
      Dim Border As Integer = 3 'Line Width
      Dim ca As ChartArea = Chart1.ChartAreas(0)
      With ca
        With .AxisX
          .MinorTickMark.Enabled = True
          .IntervalOffset = 0
          .IntervalOffsetType = DateTimeIntervalType.Months
          .IsLabelAutoFit = True
          .LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont
          .LabelStyle.Format = "MMM-yyyy"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
          '.IsMarginVisible = False
        End With
        With .AxisY
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With
      Dim s As Series = Nothing

      'Add Series to the Chart.
      s = New Series("Total Outstanding")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.TotalY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.OrangeRed
      End With
      s = New Series("Not Due")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.NotDueY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.Blue
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.Blue
      End With
      s = New Series("<1 Month")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.Slab1Y)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.Magenta
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.Magenta
      End With
      s = New Series(">1 and <6 Months")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.Slab2Y)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.Purple
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.Purple
      End With
      s = New Series(">6 and <12 Months")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.Slab3Y)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.LawnGreen
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.LawnGreen
      End With
      s = New Series(">12 and <24 Months")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.Slab4Y)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.Olive
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.Olive
      End With
      s = New Series(">24 Months")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OverallX, bc.Slab5Y)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.CadetBlue
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.CadetBlue
      End With

      Return Chart1
    End Function
    Public Shared Function GetChart(ByVal ContractID As String, Comp As String) As outstandingChart
      If ContractID = "" Then Return Nothing
      Dim isExport As Boolean = False
      Dim mRet As New outstandingChart
      mRet.ContractID = ContractID
      mRet.CurrentDate = Convert.ToDateTime("01/" & (Now.Month).ToString.PadLeft(2, "0") & "/" & Now.Year).AddMonths(-1)

      Dim Sql As String = ""

      Dim aData As New List(Of ctData)

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        'Get Lead Contract
        Sql = ""
        Sql &= " select top 1 aa.t_ccod, aa.t_ccno, aa.t_lddn from ttpisg087" & Comp & " as aa where aa.t_ccod = (select bb.t_ccod from ttpisg088" & Comp & " as bb where bb.t_cprj=(select cc.t_lprj from ttpisg087" & Comp & " as cc where cc.t_ccod ='" & ContractID & "'))"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            mRet.MainContract = (New Contracts(Reader("t_ccod"), Reader("t_ccno"), Reader("t_lddn")))
          End While
          Reader.Close()
        End Using
        'Get Contract List
        mRet.ContractList.Add(New Contracts(ContractID, "", ""))
        Sql = ""
        Sql &= " select aa.t_ccod, aa.t_ccno, aa.t_lddn from ttpisg087" & Comp & " as aa inner join ttpisg088" & Comp & " as bb on bb.t_cprj=aa.t_lprj where bb.t_ccod ='" & ContractID & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            mRet.ContractList.Add(New Contracts(Reader("t_ccod"), Reader("t_ccno"), Left(Reader("t_ccod"), 4)))
          End While
          Reader.Close()
        End Using
        'Create IN List of contract ID
        Dim ccodStr As String = ""
        For Each str As Contracts In mRet.ContractList
          If ccodStr = "" Then
            ccodStr = "('" & str.ContractID & "'"
          Else
            ccodStr &= ",'" & str.ContractID & "'"
          End If
        Next
        ccodStr &= ")"
        Dim LastSixMonths As String = Now.AddDays(-1 * (Now.Day - 1)).AddMonths(-6).ToString("dd/MM/yyyy")
        Sql = ""
        Sql &= " select t_ddte as ValX, sum(t_tdte) as TotalY, sum(t_notd) as NotDueY, sum(t_sla1) as Slab1Y, sum(t_sla2) as Slab2Y, sum(t_sla3) as Slab3Y, sum(t_sla4) as Slab4Y, sum(t_sla5) as Slab5Y from ttfisg016" & Comp & " where t_ddte >= convert(datetime,'" & LastSixMonths & "',103)  and t_cprj in (select t_cprj from ttpisg088" & Comp & " where t_ccod IN " & ccodStr & ") group by t_ddte"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As New ctData(Reader)
            aData.Add(x)
          End While
          Reader.Close()
        End Using
      End Using
      'convert Date to Startof Month
      For Each x As ctData In aData
        x.ValX = x.ValX.AddDays(-1 * (x.ValX.Day - 1))
      Next
      mRet.OverallX = aData.Select(Function(x) x.ValX).ToArray
      mRet.TotalY = aData.Select(Function(x) x.TotalY).ToArray
      mRet.NotDueY = aData.Select(Function(x) x.NotDueY).ToArray
      mRet.Slab1Y = aData.Select(Function(x) x.Slab1Y).ToArray
      mRet.Slab2Y = aData.Select(Function(x) x.Slab2Y).ToArray
      mRet.Slab3Y = aData.Select(Function(x) x.Slab3Y).ToArray
      mRet.Slab4Y = aData.Select(Function(x) x.Slab4Y).ToArray
      mRet.Slab5Y = aData.Select(Function(x) x.Slab5Y).ToArray
      Return mRet
    End Function
  End Class
End Namespace
