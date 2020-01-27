Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.CT
  <DataObject()>
  Public Class billingChart
    Private Class ctData
      Implements ICloneable

      Public Property ValX As DateTime = Nothing
      Public Property ValY As Decimal = 0.00

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
    Public Property ContractID As String = ""
    Public Property OverallX As DateTime()

    Public Property BudgetX As DateTime()
    Public Property ActualX As DateTime()
    Public Property OutlookX As DateTime()
    Public Property BudgetY As Decimal()
    Public Property ActualY As Decimal()
    Public Property OutlookY As Decimal()
    Public Property CurrentDate As DateTime = Now
    Public Property TotalBudget As Decimal = 0
    Public Property totalActual As Decimal = 0
    Public Shared Function GetDataTable(mRet As billingChart, Optional Comp As String = "200") As String
      Dim mStr As String = ""
      Try
        'Replace Outlook(Zero)=0
        mRet.OutlookY(0) = 0
        Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
        Dim row2 As String = "<td><b>BUDGETED</b></td>"
        Dim row3 As String = "<td><b>ACTUAL</b></td>"
        Dim row4 As String = "<td><b>OUTLOOK</b></td>"
        Dim row5 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
        For I As Integer = 0 To mRet.OverallX.Length - 1
          Dim isCurrent As Boolean = False
          If mRet.OverallX(I).Date = mRet.CurrentDate Then
            isCurrent = True
          End If
          row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & mRet.OverallX(I).ToString("MMM-yyyy") & "</td>"
          Dim tmpB As Decimal = 0.00
          Dim tmpA As Double = 0.00
          Dim tmpO As Double = 0.00
          Dim tmpV As Double = 0.00
          Dim sTmp As String = ""
          For f As Integer = 0 To mRet.BudgetX.Length - 1
            If mRet.OverallX(I) = mRet.BudgetX(f) Then
              Try
                tmpB = mRet.BudgetY(f)
              Catch ex As Exception
                tmpB = 0
              End Try
              Exit For
            End If
          Next
          If tmpB > 1 Or tmpB < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpB, 0))
          Else
            sTmp = Math.Round(tmpB, 2)
          End If
          row2 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          For f As Integer = 0 To mRet.ActualX.Length - 1
            If mRet.OverallX(I) = mRet.ActualX(f) Then
              Try
                tmpA = mRet.ActualY(f)
              Catch ex As Exception
                tmpA = 0
              End Try
              Exit For
            End If
          Next
          If tmpA > 1 Or tmpA < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpA, 0))
          Else
            sTmp = Math.Round(tmpA, 2)
          End If
          row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          For f As Integer = 0 To mRet.OutlookX.Length - 1
            If mRet.OverallX(I) = mRet.OutlookX(f) Then
              Try
                tmpO = mRet.OutlookY(f)
              Catch ex As Exception
                tmpO = 0
              End Try
              Exit For
            End If
          Next

          If tmpO > 1 Or tmpO < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpO, 0))
          Else
            sTmp = Math.Round(tmpO, 2)
          End If
          row4 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          tmpV = (tmpA + tmpO) - tmpB
          If tmpV > 1 Or tmpV < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpV, 0))
          Else
            sTmp = Math.Round(tmpV, 2)
          End If
          row5 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow", "color:white") & ";'>" & sTmp & "</td>"
        Next

        mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
        mStr &= "<tr>" & row1 & "</tr>"
        mStr &= "<tr>" & row2 & "</tr>"
        mStr &= "<tr>" & row3 & "</tr>"
        mStr &= "<tr>" & row4 & "</tr>"
        mStr &= "<tr>" & row5 & "</tr>"
        mStr &= "</table>"
      Catch ex As Exception
        mStr = ex.Message
      End Try
      Return mStr
    End Function
    Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal bc As billingChart) As Chart
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
        End With
        With .AxisY
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With
      Dim s As Series = Nothing

      'Add Series to the Chart.
      s = New Series("Budgeted")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline

        .Points.DataBindXY(bc.BudgetX, bc.BudgetY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.OrangeRed
      End With
      s = New Series("Actual")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.ActualX, bc.ActualY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = System.Drawing.Color.Blue
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.Blue
      End With
      s = New Series("Outlook")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(bc.OutlookX, bc.OutlookY)
        .ChartArea = "ChartArea1"
        .BorderDashStyle = ChartDashStyle.DashDotDot
        .BorderWidth = Border
        .Color = Drawing.Color.LightBlue
        .ToolTip = "#VALY"
        .IsValueShownAsLabel = True
        .LabelFormat = "###0"
        .LabelForeColor = Drawing.Color.CadetBlue
      End With

      Dim dateLine As New VerticalLineAnnotation()
      dateLine.AxisX = Chart1.ChartAreas(0).AxisX
      dateLine.AxisY = Chart1.ChartAreas(0).AxisY
      dateLine.LineColor = Drawing.Color.Green
      dateLine.LineWidth = 5
      dateLine.LineDashStyle = ChartDashStyle.Dot
      dateLine.AnchorX = bc.CurrentDate.ToOADate()
      dateLine.AnchorY = 0
      dateLine.ClipToChartArea = "ChartArea1"
      dateLine.IsInfinitive = True
      Chart1.Annotations.Add(dateLine)

      Return Chart1
    End Function
    Public Shared Function GetChart(ByVal ContractID As String, Optional Comp As String = "200", Optional Cumulative As Boolean = False) As billingChart
      If ContractID = "" Then Return Nothing
      Dim mRet As New billingChart
      mRet.ContractID = ContractID
      mRet.CurrentDate = Convert.ToDateTime("01/" & (Now.Month).ToString.PadLeft(2, "0") & "/" & Now.Year).AddMonths(-1)

      Dim sysDate As DateTime = Now.AddDays(-1 * (Now.Day - 1))
      Dim ActualTill As String = sysDate.AddMonths(-1).ToString("dd/MM/yyyy")
      Dim OutlookFrom As String = sysDate.ToString("dd/MM/yyyy")

      Dim Sql As String = ""
      Dim aBud As New List(Of ctData)
      Dim aAct As New List(Of ctData)
      Dim aOut As New List(Of ctData)

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        'Get Contract List
        Dim ccodList As New ArrayList
        ccodList.Add(ContractID)
        'Sql = ""
        'Sql &= " select aa.t_ccod from ttpisg087" & Comp & " as aa inner join ttpisg088" & Comp & " as bb on bb.t_cprj=aa.t_lprj where bb.t_ccod ='" & ContractID & "'"
        'Using Cmd As SqlCommand = Con.CreateCommand()
        '  Cmd.CommandType = CommandType.Text
        '  Cmd.CommandText = Sql
        '  Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        '  Dim xL As New ctData
        '  While (Reader.Read())
        '    ccodList.Add(Reader("t_ccod"))
        '  End While
        '  Reader.Close()
        'End Using
        'Create IN List of contract ID
        Dim ccodStr As String = ""
        For Each str As String In ccodList
          If ccodStr = "" Then
            ccodStr = "('" & str & "'"
          Else
            ccodStr &= ",'" & str & "'"
          End If
        Next
        ccodStr &= ")"
        'Get Budgted
        Sql = ""
        Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, sum(t_budg) as ValY from ttpisg086" & Comp & " where t_cprj in (select t_cprj from ttpisg088" & Comp & " where t_ccod IN " & ccodStr & ") group by convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          Dim xL As New ctData
          While (Reader.Read())
            Dim x As New ctData(Reader)
            aBud.Add(x)
          End While
          Reader.Close()
        End Using

        'Get Actual
        Sql = ""
        Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, sum(t_actu) as ValY from ttpisg086" & Comp & " where convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) <= convert(datetime,'" & ActualTill & "',103)  and t_cprj in (select t_cprj from ttpisg088" & Comp & " where t_ccod IN " & ccodStr & ") group by convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          Dim xL As New ctData
          While (Reader.Read())
            Dim x As New ctData(Reader)
            aAct.Add(x)
          End While
          Reader.Close()
        End Using

        'Get Outlook
        Sql = ""
        Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, sum(t_outl) as ValY from ttpisg086" & Comp & " where convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) >= convert(datetime,'" & OutlookFrom & "',103)  and t_cprj in (select t_cprj from ttpisg088" & Comp & " where t_ccod IN " & ccodStr & ") group by convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 )"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          Dim xL As New ctData
          While (Reader.Read())
            Dim x As New ctData(Reader)
            aOut.Add(x)
          End While
          Reader.Close()
        End Using
      End Using

      '- Assign OverallX from any of List
      mRet.OverallX = aBud.Select(Function(x) x.ValX).ToArray
      '- Remove Trailing Zeros from Budget
      For I As Integer = aBud.Count - 1 To 0 Step -1
        If aBud(I).ValY = 0 Then
          aBud.RemoveAt(I)
        Else
          Exit For
        End If
      Next
      Dim lastActual As ctData = aAct.Last.Clone
      aOut.Insert(0, lastActual)

      If Cumulative Then
        For I As Integer = 1 To aBud.Count - 1
          aBud(I).ValY += aBud(I - 1).ValY
        Next
        For I As Integer = 1 To aAct.Count - 1
          aAct(I).ValY += aAct(I - 1).ValY
        Next
        aOut(0).ValY = aAct.Last.ValY
        For I As Integer = 1 To aOut.Count - 1
          aOut(I).ValY += aOut(I - 1).ValY
        Next
      Else
      End If
      mRet.BudgetX = aBud.Select(Function(x) x.ValX).ToArray
      mRet.BudgetY = aBud.Select(Function(x) Math.Round(x.ValY, 2)).ToArray
      mRet.ActualX = aAct.Select(Function(x) x.ValX).ToArray
      mRet.ActualY = aAct.Select(Function(x) Math.Round(x.ValY, 2)).ToArray
      mRet.OutlookX = aOut.Select(Function(x) x.ValX).ToArray
      mRet.OutlookY = aOut.Select(Function(x) Math.Round(x.ValY, 2)).ToArray

      'total amount till current mark line i.e. last month
      For Each tmp As ctData In aBud
        If tmp.ValX <= mRet.CurrentDate Then
          mRet.TotalBudget += tmp.ValY
        End If
      Next
      For Each tmp As ctData In aAct
        If tmp.ValX <= mRet.CurrentDate Then
          mRet.totalActual += tmp.ValY
        End If
      Next

      Return mRet
    End Function
  End Class
End Namespace
