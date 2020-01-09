Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.CT
  <DataObject()>
  Public Class costChart
    Private Class ctData
      Implements ICloneable

      Public Property ValX As DateTime = Nothing
      Public Property biY As Decimal = 0.00
      Public Property aiY As Decimal = 0.00
      Public Property oiY As Decimal = 0.00
      Public Property boY As Decimal = 0.00
      Public Property aoY As Decimal = 0.00
      Public Property ooY As Decimal = 0.00


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
    Public Property CountOfXValuesToBeShown As Integer = 30
    Public Property IntervalX As Integer = 30
    Public Property MinimumX As DateTime = Nothing
    Public Property MaximumX As DateTime = Nothing
    Public Property ContractID As String = ""
    Public Property ActivityType As String = ""
    Public Property OverallX As DateTime()
    Public Property PlannedX As DateTime()
    Public Property PlannedY As Decimal()
    Public Property ActualX As DateTime()
    Public Property ActualY As Decimal()
    Public Property OutlookX As DateTime()
    Public Property OutlookY As Decimal()

    Public Property OPlannedX As DateTime()
    Public Property OPlannedY As Decimal()
    Public Property OActualX As DateTime()
    Public Property OActualY As Decimal()
    Public Property OOutlookX As DateTime()
    Public Property OOutlookY As Decimal()

    Public Property LastUpdatedOn As DateTime = Nothing
    Public Property LastUpdatedIndex As Integer = 0
    Public Property LastProcessed As DateTime
    Public Property TBI As Decimal = 0
    Public Property TAI As Decimal = 0
    Public Property TBO As Decimal = 0
    Public Property TAO As Decimal = 0
    Public Property BN As Decimal = 0
    Public Property AN As Decimal = 0
    Public Function GetDataTableInflow(Optional Cumulative As Boolean = False, Optional Comp As String = "200", Optional ByRef cChart As costChart = Nothing) As String
      'Get Overall X
      Dim mRet As New costChart
      Dim Sql As String = ""
      Dim aData As List(Of ctData) = Nothing
      Sql = ""
      Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX,t_amti as biY, t_cmti as aiY, t_oami as oiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
      aData = New List(Of ctData)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.OverallX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) Math.Round(x.biY, 2)).ToArray
        mRet.ActualY = aData.Select(Function(x) Math.Round(x.aiY, 2)).ToArray
        mRet.OutlookY = aData.Select(Function(x) Math.Round(x.oiY, 2)).ToArray
        If Cumulative Then
          Dim OutlookIStarted As Boolean = False
          For I As Integer = 0 To mRet.OverallX.Length - 2
            mRet.PlannedY(I + 1) += mRet.PlannedY(I)
            If Not OutlookIStarted Then
              If mRet.OutlookY(I + 1) > 0 Then
                OutlookIStarted = True
              End If
            End If
            If Not OutlookIStarted Then
              mRet.ActualY(I + 1) += mRet.ActualY(I)
            Else
              mRet.OutlookY(I + 1) += (mRet.OutlookY(I) + mRet.ActualY(I))
            End If
          Next
        End If
      End Using
      cChart = mRet
      Dim mStr As String = ""
      Try
        Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
        Dim row2 As String = "<td><b>BUDGETED</b></td>"
        Dim row3 As String = "<td><b>ACTUAL</b></td>"
        Dim row4 As String = "<td><b>OUTLOOK</b></td>"
        Dim row5 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
        For I As Integer = 0 To mRet.OverallX.Length - 1
          Dim isCurrent As Boolean = False
          If mRet.OverallX(I).Date = LastProcessed.Date Then
            isCurrent = True
          End If
          row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & mRet.OverallX(I).ToString("MMM-yyyy") & "</td>"
          Dim tmpP As Decimal = 0.00
          Dim tmpA As Double = 0.00
          Dim tmpO As Double = 0.00
          Dim tmpV As Double = 0.00
          Dim sTmp As String = ""
          Try
            tmpP = mRet.PlannedY(I)
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
            tmpA = mRet.ActualY(I)
          Catch ex As Exception
            tmpA = 0
          End Try
          If tmpA > 1 Or tmpA < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpA, 0))
          Else
            sTmp = Math.Round(tmpA, 2)
          End If
          row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpO = mRet.OutlookY(I)
          Catch ex As Exception
            tmpO = 0
          End Try
          If tmpO > 1 Or tmpO < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpO, 0))
          Else
            sTmp = Math.Round(tmpO, 2)
          End If
          row4 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          tmpV = (tmpA + tmpO) - tmpP
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

    Public Function GetDataTableOutflow(Optional Cumulative As Boolean = False, Optional Comp As String = "200", Optional ByRef cChart As costChart = Nothing) As String
      'Get Overall X
      Dim mRet As New costChart
      Dim Sql As String = ""
      Dim aData As List(Of ctData) = Nothing
      Sql = ""
      Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX,t_amto as boY,t_cmto as aoY,t_oamo as ooY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
      aData = New List(Of ctData)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.OverallX = aData.Select(Function(x) x.ValX).ToArray
        mRet.OPlannedY = aData.Select(Function(x) Math.Round(x.boY, 2)).ToArray
        mRet.OActualY = aData.Select(Function(x) Math.Round(x.aoY, 2)).ToArray
        mRet.OOutlookY = aData.Select(Function(x) Math.Round(x.ooY, 2)).ToArray
        If Cumulative Then
          Dim OutlookOStarted As Boolean = False

          For I As Integer = 0 To mRet.OverallX.Length - 2
            mRet.OPlannedY(I + 1) += mRet.OPlannedY(I)
            If Not OutlookOStarted Then
              If mRet.OOutlookY(I + 1) > 0 Then
                OutlookOStarted = True
              End If
            End If
            If Not OutlookOStarted Then
              mRet.OActualY(I + 1) += mRet.OActualY(I)
            Else
              mRet.OOutlookY(I + 1) += (mRet.OOutlookY(I) + mRet.OActualY(I))
            End If
          Next
        End If
      End Using
      cChart = mRet
      Dim mStr As String = ""
      Try
        Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
        Dim orow2 As String = "<td><b>BUDGETED</b></td>"
        Dim orow3 As String = "<td><b>ACTUAL</b></td>"
        Dim orow4 As String = "<td><b>OUTLOOK</b></td>"
        Dim orow5 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
        For I As Integer = 0 To mRet.OverallX.Length - 1
          Dim isCurrent As Boolean = False
          If mRet.OverallX(I).Date = LastProcessed.Date Then
            isCurrent = True
          End If
          row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & mRet.OverallX(I).ToString("MMM-yyyy") & "</td>"
          Dim tmpP As Decimal = 0.00
          Dim tmpA As Double = 0.00
          Dim tmpO As Double = 0.00
          Dim tmpV As Double = 0.00
          Dim sTmp As String = ""
          Try
            tmpP = mRet.OPlannedY(I)
          Catch ex As Exception
            tmpP = 0
          End Try
          If tmpP > 1 Or tmpP < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpP, 0))
          Else
            sTmp = Math.Round(tmpP, 2)
          End If
          orow2 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpA = mRet.OActualY(I)
          Catch ex As Exception
            tmpA = 0
          End Try
          If tmpA > 1 Or tmpA < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpA, 0))
          Else
            sTmp = Math.Round(tmpA, 2)
          End If
          orow3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpO = mRet.OOutlookY(I)
          Catch ex As Exception
            tmpO = 0
          End Try
          If tmpO > 1 Or tmpO < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpO, 0))
          Else
            sTmp = Math.Round(tmpO, 2)
          End If
          orow4 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          tmpV = (tmpA + tmpO) - tmpP
          If tmpV > 1 Or tmpV < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpV, 0))
          Else
            sTmp = Math.Round(tmpV, 2)
          End If
          orow5 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow", "color:white") & ";'>" & sTmp & "</td>"
        Next

        mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
        mStr &= "<tr>" & row1 & "</tr>"
        mStr &= "<tr>" & orow2 & "</tr>"
        mStr &= "<tr>" & orow3 & "</tr>"
        mStr &= "<tr>" & orow4 & "</tr>"
        mStr &= "<tr>" & orow5 & "</tr>"
        mStr &= "</table>"
      Catch ex As Exception
        mStr = ex.Message
      End Try
      Return mStr
    End Function
    Public Function GetDataTableNet(Optional Cumulative As Boolean = False, Optional Comp As String = "200", Optional ByRef cChart As costChart = Nothing) As String
      'Get Overall X
      Dim mRet As New costChart
      Dim Sql As String = ""
      Dim aData As List(Of ctData) = Nothing
      Sql = ""
      Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_namt as biY,t_cnmt as aiY,t_oamn as oiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
      aData = New List(Of ctData)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.OverallX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) Math.Round(x.biY, 2)).ToArray
        mRet.ActualY = aData.Select(Function(x) Math.Round(x.aiY, 2)).ToArray
        mRet.OutlookY = aData.Select(Function(x) Math.Round(x.oiY, 2)).ToArray
        If Cumulative Then
          Dim OutlookStarted As Boolean = False
          For I As Integer = 0 To mRet.OverallX.Length - 2
            'If mRet.PlannedY(I + 1) <> 0 Then mRet.PlannedY(I + 1) += mRet.PlannedY(I)
            'If mRet.ActualY(I + 1) <> 0 Then mRet.ActualY(I + 1) += mRet.ActualY(I)
            'If mRet.OutlookY(I + 1) > 0 Then mRet.OutlookY(I + 1) += (mRet.OutlookY(I) + mRet.ActualY(I))
            mRet.PlannedY(I + 1) += mRet.PlannedY(I)
            If Not OutlookStarted Then
              If mRet.OutlookY(I + 1) > 0 Then
                OutlookStarted = True
              End If
            End If
            If Not OutlookStarted Then
              mRet.ActualY(I + 1) += mRet.ActualY(I)
            Else
              mRet.OutlookY(I + 1) += (mRet.OutlookY(I) + mRet.ActualY(I))
            End If
          Next
        End If
      End Using
      cChart = mRet
      Dim mStr As String = ""
      Try
        Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
        Dim row2 As String = "<td><b>BUDGETED</b></td>"
        Dim row3 As String = "<td><b>ACTUAL</b></td>"
        Dim row4 As String = "<td><b>OUTLOOK</b></td>"
        Dim row5 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
        For I As Integer = 0 To mRet.OverallX.Length - 1
          Dim isCurrent As Boolean = False
          If mRet.OverallX(I).Date = LastProcessed.Date Then
            isCurrent = True
          End If
          row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & mRet.OverallX(I).ToString("MMM-yyyy") & "</td>"
          Dim tmpP As Decimal = 0.00
          Dim tmpA As Double = 0.00
          Dim tmpO As Double = 0.00
          Dim tmpV As Double = 0.00
          Dim sTmp As String = ""
          Try
            tmpP = mRet.PlannedY(I)
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
            tmpA = mRet.ActualY(I)
          Catch ex As Exception
            tmpA = 0
          End Try
          If tmpA > 1 Or tmpA < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpA, 0))
          Else
            sTmp = Math.Round(tmpA, 2)
          End If
          row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          Try
            tmpO = mRet.OutlookY(I)
          Catch ex As Exception
            tmpO = 0
          End Try
          If tmpO > 1 Or tmpO < -1 Then
            sTmp = Math.Truncate(Math.Round(tmpO, 0))
          Else
            sTmp = Math.Round(tmpO, 2)
          End If
          row4 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & sTmp & "</td>"
          tmpV = (tmpA + tmpO) - tmpP
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

    Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal dt As costChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
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

        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
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
        .Points.DataBindXY(dt.ActualX, dt.ActualY)
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
        .Points.DataBindXY(dt.OutlookX, dt.OutlookY)
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
      dateLine.AnchorX = Convert.ToDateTime("01/" & (Now.Month).ToString.PadLeft(2, "0") & "/" & Now.Year).AddMonths(-1).ToOADate()
      dateLine.AnchorY = 0
      dateLine.ClipToChartArea = "ChartArea1"
      dateLine.IsInfinitive = True
      Chart1.Annotations.Add(dateLine)

      Return Chart1
    End Function
    Public Shared Function GetCostChart(ByVal ContractID As String, Comp As String, Optional ByVal ActivityType As String = "", Optional countOfX As Integer = 30) As costChart
      If ContractID = "" Then Return Nothing
      Dim mRet As New costChart
      mRet.ContractID = ContractID
      mRet.ActivityType = ActivityType
      mRet.CountOfXValuesToBeShown = countOfX

      mRet.LastUpdatedOn = Convert.ToDateTime("01/" & (Now.Month).ToString.PadLeft(2, "0") & "/" & Now.Year).AddMonths(-1)
      mRet.LastProcessed = mRet.LastUpdatedOn

      Dim Sql As String = ""
      Dim aData As List(Of ctData) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        'Get Budgted
        Sql = ""
        Select Case ActivityType
          Case "I", "IC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_amti as biY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
          Case "O", "OC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_amto as biY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
          Case "NET", "NETC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_namt as biY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
        End Select
        aData = New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          Dim xL As New ctData
          While (Reader.Read())
            Dim x As New ctData(Reader)
            Select Case ActivityType
              Case "NETC", "IC", "OC"
                With xL
                  .biY += x.biY
                End With
                x.biY = xL.biY
            End Select
            aData.Add(x)
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) Math.Round(x.biY, 2)).ToArray



        'Get Outlook
        Sql = ""
        Select Case ActivityType
          Case "I", "IC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_oami as oiY from ttpisg089" & Comp & "  where t_ccod='" & ContractID & "'"
          Case "O", "OC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_oamo as oiY from ttpisg089" & Comp & "  where t_ccod='" & ContractID & "'"
          Case "NET", "NETC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_oamn as oiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
        End Select
        Dim outlookaData = New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As New ctData(Reader)
            outlookaData.Add(x)
          End While
          Reader.Close()
        End Using
        Dim Found As Boolean = False
        For i As Integer = outlookaData.Count - 1 To 0 Step -1
          If Found Then
            If outlookaData(i).oiY = 0 Then
              outlookaData.RemoveAt(i)
            End If
          Else
            If outlookaData(i).oiY <> 0 Then
              Found = True
            End If
          End If
        Next
        'Do not put outlook values
        '===================================
        'Get Actual upto start Month of Outlook
        Dim FirstOutlook As ctData = outlookaData(0).Clone
        Sql = ""
        Select Case ActivityType
          Case "I", "IC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_cmti as aiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
          Case "O", "OC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_cmto as aiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
          Case "NET", "NETC"
            Sql &= " select convert(datetime, '01/'+right('00'+ltrim(str(t_mnth)),2)+'/'+str(t_year), 103 ) as ValX, t_cnmt as aiY from ttpisg089" & Comp & " where t_ccod='" & ContractID & "'"
        End Select
        Sql &= " and ((t_year=" & FirstOutlook.ValX.Year & " and t_mnth<" & FirstOutlook.ValX.Month & ") or (t_year<" & FirstOutlook.ValX.Year & "))"
        aData = New List(Of ctData)
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
        'Cumulative Value
        Select Case ActivityType
          Case "IC", "OC", "NETC"
            For i = 1 To aData.Count - 1
              aData(i).aiY = aData(i).aiY + aData(i - 1).aiY
            Next
        End Select
        'End Cumulative
        mRet.ActualX = aData.Select(Function(x) x.ValX).ToArray
        mRet.ActualY = aData.Select(Function(x) Math.Round(x.aiY, 2)).ToArray

        'Put outlook values now
        Dim lastActual As ctData = aData.Last.Clone
        lastActual.oiY = lastActual.aiY
        aData = New List(Of ctData)
        aData.Add(lastActual)
        aData.AddRange(outlookaData)
        'Cumulative Value
        Select Case ActivityType
          Case "IC", "OC", "NETC"
            For i = 1 To aData.Count - 1
              aData(i).oiY = aData(i).oiY + aData(i - 1).oiY
            Next
        End Select
        'End Cumulative
        mRet.OutlookX = aData.Select(Function(x) x.ValX).ToArray
        mRet.OutlookY = aData.Select(Function(x) Math.Round(x.oiY, 2)).ToArray

      End Using
      Return mRet
    End Function
  End Class
End Namespace
'Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal dt As costChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
'  Dim ca As ChartArea = Chart1.ChartAreas(0)
'  With ca
'    With .AxisX
'      .MinorTickMark.Enabled = True
'      .IntervalOffset = 0
'      .IntervalOffsetType = DateTimeIntervalType.Months
'      .IsLabelAutoFit = True
'      .LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont
'      .LabelStyle.Format = "MMM-yyyy"
'      .MajorGrid.LineColor = Drawing.Color.LightGray
'      .MajorGrid.LineWidth = 1
'    End With
'    With .AxisY
'      .MajorGrid.LineColor = Drawing.Color.LightGray
'      .MajorGrid.LineWidth = 1
'    End With
'  End With
'  Dim s As Series = Nothing
'  '=====================================
'  s = New Series("Budgeted-Outflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.PlannedX, dt.OPlannedY)
'    .ChartArea = "ChartArea1"
'    .BorderWidth = Border
'    .Color = Drawing.Color.FromArgb(233, 22, 64)
'    .ToolTip = "#VALY"
'  End With
'  s = New Series("Actual-Outflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.ActualX, dt.OActualY)
'    .ChartArea = "ChartArea1"
'    .BorderWidth = Border
'    .Color = System.Drawing.Color.FromArgb(248, 185, 198)
'    .ToolTip = "#VALY"
'  End With
'  s = New Series("Outlook-Outflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.OutlookX, dt.OOutlookY)
'    .ChartArea = "ChartArea1"
'    .BorderDashStyle = ChartDashStyle.DashDotDot
'    .BorderWidth = Border
'    .Color = System.Drawing.Color.FromArgb(248, 185, 198)
'    .ToolTip = "#VALY"
'  End With
'  Dim dateLine As New VerticalLineAnnotation()
'  dateLine.AxisX = Chart1.ChartAreas(0).AxisX
'  dateLine.AxisY = Chart1.ChartAreas(0).AxisY
'  dateLine.LineColor = Drawing.Color.Red
'  dateLine.LineWidth = 5
'  dateLine.LineDashStyle = ChartDashStyle.Dot
'  dateLine.AnchorX = Convert.ToDateTime("01/" & (Now.Month).ToString.PadLeft(2, "0") & "/" & Now.Year).AddMonths(-1).ToOADate()
'  dateLine.AnchorY = 0
'  dateLine.ClipToChartArea = "ChartArea1"
'  dateLine.IsInfinitive = True
'  Chart1.Annotations.Add(dateLine)
'  For Each xPoint As DataPoint In s.Points
'    If xPoint.YValues(0) = 0 Then xPoint.IsEmpty = True
'  Next
'  s = New Series("Budgeted-Inflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
'    .ChartArea = "ChartArea1"
'    .BorderWidth = Border
'    .Color = Drawing.Color.Blue
'    .ToolTip = "#VALY"
'    '.IsValueShownAsLabel = True
'    '.MarkerSize = 15
'    '.MarkerStyle = MarkerStyle.Diamond
'    'With .SmartLabelStyle
'    '  .Enabled = True
'    '  .CalloutStyle = LabelCalloutStyle.Box
'    '  .CalloutLineColor = Drawing.Color.Goldenrod
'    '  .CalloutLineDashStyle = ChartDashStyle.Solid
'    '  .CalloutLineWidth = 3
'    '  .CalloutLineAnchorCapStyle = LineAnchorCapStyle.Arrow
'    '  .MinMovingDistance = 20
'    '  .MaxMovingDistance = 100
'    '  .MovingDirection = LabelAlignmentStyles.TopRight
'    'End With
'  End With



'  s = New Series("Actual-Inflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.ActualX, dt.ActualY)
'    .ChartArea = "ChartArea1"
'    .BorderWidth = Border
'    .Color = System.Drawing.Color.LightBlue
'    .ToolTip = "#VALY"
'  End With
'  s = New Series("Outlook-Inflow")
'  Chart1.Series.Add(s)
'  With s
'    .ChartType = SeriesChartType.Spline
'    .Points.DataBindXY(dt.OutlookX, dt.OutlookY)
'    .ChartArea = "ChartArea1"
'    .BorderDashStyle = ChartDashStyle.DashDotDot
'    .BorderWidth = Border
'    .Color = Drawing.Color.SkyBlue
'    .ToolTip = "#VALY"
'  End With

'  Return Chart1
'End Function
