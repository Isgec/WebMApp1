Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.CT
  <DataObject()>
  Public Class CTChart
    Private Class ctData
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
    End Class
    Public Property CountOfXValuesToBeShown As Integer = 30
    Public Property IntervalX As Integer = 30
    Public Property MinimumX As DateTime = Nothing
    Public Property MaximumX As DateTime = Nothing
    Public Property ProjectID As String = ""
    Public Property ActivityType As String = ""
    Public Property PlannedX As DateTime()
    Public Property PlannedY As Decimal()
    Public Property ActualX As DateTime()
    Public Property ActualY As Decimal()
    Public Property OutlookX As DateTime()
    Public Property OutlookY As Decimal()
    Public Property LastUpdatedOn As DateTime = Nothing
    Public Property LastUpdatedIndex As Integer = 0
    Public Property LastProcessed As DateTime
    Public ReadOnly Property GetDataTable As String
      Get
        Dim mStr As String = ""
        Try
          Dim row1 As String = "<td style='width:100px;background-color:black;color:white;'></td>"
          Dim row2 As String = "<td><b>PLANNED %</b></td>"
          Dim row3 As String = "<td><b>ACTUAL / OUTLOOK %</b></td>"
          Dim row4 As String = "<td style='background-color:gray;color:white;'><b>VARIANCE</b></td>"
          For I As Integer = 0 To PlannedX.Length - 1
            Dim isCurrent As Boolean = False
            If PlannedX(I).Date = LastProcessed.Date Then
              isCurrent = True
            End If
            row1 &= "<td style='text-align:center;background-color:black;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & PlannedX(I).ToString("dd-MMM") & "</td>"
            Dim actual As Decimal = 0.00
            Try
              actual = ActualY(I)
            Catch ex As Exception
              actual = 0
            End Try
            If PlannedY(I) > 1 And actual > 1 Then
              row2 &= "<td style='text-align:center;color:maroon;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(PlannedY(I), 0)) & "</td>"
            Else
              row2 &= "<td style='text-align:center;color:maroon;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Round(PlannedY(I), 2) & "</td>"
            End If
            If I > ActualY.Length - 1 Then
              Dim Value As Decimal = 0.00
              Try
                Value = OutlookY(I - ActualY.Length)
              Catch ex As Exception
                Value = 0.00
              End Try
              If Value > 1 Then
                row3 &= "<td style='text-align:center;color:orange;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(Value, 0)) & "</td>"
                row4 &= "<td style='text-align:center;background-color:gray;color:white;'>" & Math.Truncate((Math.Round(PlannedY(I), 0) - Math.Round(Value, 0))) & "</td>"
              Else
                row3 &= "<td style='text-align:center;color:orange;'>" & Math.Round(Value, 2) & "</td>"
                row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & (Math.Round(PlannedY(I), 2) - Math.Round(Value, 2)) & "</td>"
              End If
            Else
              If ActualY(I) > 1 Then
                row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Truncate(Math.Round(ActualY(I), 0)) & "</td>"
                row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & Math.Truncate((Math.Round(PlannedY(I), 0) - Math.Round(ActualY(I), 0))) & "</td>"
              Else
                row3 &= "<td style='text-align:center;color:blue;" & IIf(isCurrent, "background-color:yellow;", "background-color:white;") & "'>" & Math.Round(ActualY(I), 2) & "</td>"
                row4 &= "<td style='text-align:center;background-color:gray;" & IIf(isCurrent, "color:yellow;", "color:white;") & "'>" & (Math.Round(PlannedY(I), 2) - Math.Round(ActualY(I), 2)) & "</td>"
              End If
            End If
          Next
          mStr &= "<table class='table-bordered' style='width:100%;margin:5px 5px 5px 5px;'>"
          mStr &= "<tr>" & row1 & "</tr>"
          mStr &= "<tr>" & row2 & "</tr>"
          mStr &= "<tr>" & row3 & "</tr>"
          mStr &= "<tr>" & row4 & "</tr>"
          mStr &= "</table>"
        Catch ex As Exception
          mStr = ex.Message
        End Try
        Return mStr
      End Get
    End Property
    Public Shared Function RenderChart(ByVal Chart1 As Chart, ByVal dt As CTChart, Optional ByVal IntervalY As Integer = 10, Optional ByVal Border As Integer = 3) As Chart
      Dim ca As ChartArea = Chart1.ChartAreas(0)
      With ca
        With .AxisX
          .Interval = dt.IntervalX
          .Minimum = dt.MinimumX.ToOADate
          .Maximum = dt.MaximumX.ToOADate
          .LabelStyle.Format = "dd-MMM"
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With
        With .AxisY
          .Interval = IntervalY
          .Minimum = 0
          .Maximum = 100
          .MajorGrid.LineColor = Drawing.Color.LightGray
          .MajorGrid.LineWidth = 1
        End With

      End With


      'Add Series to the Chart.
      Dim s As New Series("Planned")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Line
        .Points.DataBindXY(dt.PlannedX, dt.PlannedY)
        .ChartArea = "ChartArea1"
        .BorderWidth = Border
        .Color = Drawing.Color.OrangeRed
        .ToolTip = "#VALY"
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
      End With
      s = New Series("Outlook")
      Chart1.Series.Add(s)
      With s
        .ChartType = SeriesChartType.Spline
        .Points.DataBindXY(dt.OutlookX, dt.OutlookY)
        .ChartArea = "ChartArea1"
        .BorderDashStyle = ChartDashStyle.DashDotDot
        .BorderWidth = Border
        .Color = Drawing.Color.Gold
        .ToolTip = "#VALY"
      End With
      Return Chart1
    End Function
    Public Shared Function GetCTChart(ByVal ProjectID As String, Optional ByVal ActivityType As String = "", Optional countOfX As Integer = 30) As CTChart
      If ProjectID = "" Then Return Nothing
      Dim mRet As New CTChart
      mRet.ProjectID = ProjectID
      mRet.ActivityType = ActivityType
      mRet.CountOfXValuesToBeShown = countOfX
      Dim PPeriod As SIS.CT.tpisg216.ProjectPeriod = SIS.CT.tpisg216.GetProjectPeriod(ProjectID)
      Dim OPeriod As SIS.CT.tpisg216.ProjectPeriod = SIS.CT.tpisg216.GetOutlookPeriod(ProjectID)
      'Calculate Interval
      Dim sDt As DateTime = PPeriod.StDt
      Dim fDt As DateTime = IIf(OPeriod.FnDt > PPeriod.FnDt, OPeriod.FnDt, PPeriod.FnDt)
      Dim TDays As Integer = Convert.ToInt32(fDt.Subtract(sDt).TotalDays)
      Dim Interval As Integer = TDays / mRet.CountOfXValuesToBeShown
      'Correction in Interval
      Interval += 1
      With mRet
        .IntervalX = Interval
        .MinimumX = sDt
        .MaximumX = fDt
      End With

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        '1. Get Last Updated Date
        Sql &= " select top 1 t_limp from ttpisg220200 where t_cprj='" & ProjectID & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim tmp As Object = Cmd.ExecuteScalar
          If Not IsDBNull(tmp) Then
            mRet.LastUpdatedOn = Convert.ToDateTime(tmp)
          End If
        End Using
        '2. Get Planned
        Sql = ""
        Sql &= " declare @LastUpdated Datetime "
        'Sql &= " select top 1 @LastUpdated=convert(date,dateadd(d,-1,getdate()))"  't_limp from ttpisg220200 where t_cprj='" & ProjectID & "'"
        Sql &= " select @LastUpdated=t_curr from ttpisg216200 where t_proa>0"
        If ActivityType = "" Then
          Sql &= " select aa.t_curr as ValX, aa.t_prop as ValY from ttpisg216200 as aa where aa.t_cprj='" & ProjectID & "'"
          Sql &= " and ( (aa.t_curr = (select min(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj and month(dd.t_curr) = month(aa.t_curr) and year(dd.t_curr) = year(aa.t_curr) )) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = @LastUpdated) "
          Sql &= "     ) "
        Else
          Sql &= " select aa.t_date as ValX, aa.t_pprc as ValY from ttpisg214200 as aa where aa.t_cprj='" & ProjectID & "' and aa.t_acty='" & ActivityType & "'"
          Sql &= " and ( (aa.t_date = (select min(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and month(dd.t_date) = month(aa.t_date) and year(dd.t_date) = year(aa.t_date) )) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = @LastUpdated) "
          Sql &= "     ) "
        End If
        Dim aData As New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.PlannedX = aData.Select(Function(x) x.ValX).ToArray
        mRet.PlannedY = aData.Select(Function(x) Math.Round(x.ValY, 2)).ToArray
        '3. Get Actual
        Sql = ""
        Sql &= " declare @LastUpdated Datetime "
        'Sql &= " select top 1 @LastUpdated=convert(date,dateadd(d,-1,getdate()))"  't_limp from ttpisg220200 where t_cprj='" & ProjectID & "'"
        Sql &= " select @LastUpdated=t_curr from ttpisg216200 where t_proa>0"
        If ActivityType = "" Then
          Sql &= " select aa.t_curr as ValX, aa.t_proa as ValY from ttpisg216200 as aa where aa.t_cprj='" & ProjectID & "' and aa.t_curr <= @LastUpdated"
          Sql &= " and ( (aa.t_curr = (select min(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj and dd.t_curr<=@LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj and dd.t_curr <= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg216200 as dd where dd.t_cprj=aa.t_cprj and month(dd.t_curr) = month(aa.t_curr) and year(dd.t_curr) = year(aa.t_curr) and dd.t_curr <= @LastUpdated )) "
          Sql &= "     ) "
        Else
          Sql &= " select aa.t_date as ValX, aa.t_acpr as ValY from ttpisg214200 as aa where aa.t_cprj='" & ProjectID & "' and aa.t_acty='" & ActivityType & "' and aa.t_date <= @LastUpdated"
          Sql &= " and ( (aa.t_date = (select min(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and dd.t_date <= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and dd.t_date <= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg214200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and month(dd.t_date) = month(aa.t_date) and year(dd.t_date) = year(aa.t_date) and dd.t_date <= @LastUpdated )) "
          Sql &= "     ) "
        End If
        aData = New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.ActualX = aData.Select(Function(x) x.ValX).ToArray
        mRet.ActualY = aData.Select(Function(x) Math.Round(x.ValY, 2)).ToArray
        '4. Get Outlook
        Sql = ""
        Sql &= " declare @LastUpdated Datetime "
        Sql &= " select top 1 @LastUpdated=t_limp from ttpisg220200 where t_cprj='" & ProjectID & "'"
        If ActivityType = "" Then
          Sql &= " select aa.t_curr as ValX, aa.t_prop as ValY from ttpisg249200 as aa where aa.t_cprj='" & ProjectID & "' and aa.t_curr >= @LastUpdated"
          Sql &= " and ( (aa.t_curr = (select min(dd.t_curr) from ttpisg249200 as dd where dd.t_cprj=aa.t_cprj and dd.t_curr >= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg249200 as dd where dd.t_cprj=aa.t_cprj and dd.t_curr >= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_curr = (select max(dd.t_curr) from ttpisg249200 as dd where dd.t_cprj=aa.t_cprj and month(dd.t_curr) = month(aa.t_curr) and year(dd.t_curr) = year(aa.t_curr) and dd.t_curr >= @LastUpdated )) "
          Sql &= "     ) "
        Else
          Sql &= " select aa.t_date as ValX, aa.t_pprc as ValY from ttpisg248200 as aa where aa.t_cprj='" & ProjectID & "' and aa.t_acty='" & ActivityType & "' and aa.t_date >= @LastUpdated"
          Sql &= " and ( (aa.t_date = (select min(dd.t_date) from ttpisg248200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and dd.t_date >= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg248200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and dd.t_date >= @LastUpdated)) "
          Sql &= "        or "
          Sql &= " 	  (aa.t_date = (select max(dd.t_date) from ttpisg248200 as dd where dd.t_cprj=aa.t_cprj and dd.t_acty=aa.t_acty and month(dd.t_date) = month(aa.t_date) and year(dd.t_date) = year(aa.t_date) and dd.t_date >= @LastUpdated )) "
          Sql &= "     ) "
        End If
        aData = New List(Of ctData)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aData.Add(New ctData(Reader))
          End While
          Reader.Close()
        End Using
        mRet.OutlookX = aData.Select(Function(x) x.ValX).ToArray
        mRet.OutlookY = aData.Select(Function(x) Math.Round(x.ValY, 2)).ToArray
        'Last Processed
        Sql = ""
        Sql &= " select isnull(max(t_curr),getdate()) from ttpisg216200 where t_proa>0"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.LastProcessed = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
  End Class
End Namespace
