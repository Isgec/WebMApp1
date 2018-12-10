Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class RebuildPredcessors
    'THEME: Pred of Parent Activity is also Pred of selected activity
    Public Shared Function RebuildPred(ByVal t_cprj As String) As String
      Dim mRet As String = ""
      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";TimeOut=900")
        Con.Open()
        Sql &= " delete ttpisg247200 "
        Sql &= " where t_cprj='" & t_cprj & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
        Sql = ""
        Sql &= " insert into ttpisg247200 "
        Sql &= " select * from ttpisg221200 where t_cprj='" & t_cprj & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
        'Process Activity
        Sql = ""
        Sql &= "   Declare @outer int, @inner int                                                                                           "
        Sql &= "   DECLARE @MyCursor CURSOR                                                                                                 "
        Sql &= "   DECLARE @t_cact varchar(50), @t_pact varchar(10)                                                                         "
        Sql &= "   BEGIN                                                                                                                    "
        Sql &= "  	SET @MyCursor = CURSOR FOR    select t_cact,t_pact from ttpisg220200                                                    "
        Sql &= "  	where t_cprj='" & t_cprj & "'"
        Sql &= "  	OPEN @MyCursor                                                                                                          "
        Sql &= "  	FETCH NEXT FROM @MyCursor INTO @t_cact,@t_pact                                                                          "
        Sql &= "  	set @outer = @@FETCH_STATUS                                                                                             "
        Sql &= "  	WHILE @outer = 0                                                                                                        "
        Sql &= "  	BEGIN                                                                                                                   "
        Sql &= "  		if(@t_cact<>@t_pact)                                                                                                  "
        Sql &= "  		begin                                                                                                                 "
        Sql &= "  			declare @tmp cursor                                                                                                 "
        Sql &= "  			declare @tmp_pact varchar(50)                                                                                       "
        Sql &= "  			set @tmp = cursor for        select t_pact from ttpisg221200                                                        "
        Sql &= "  	    where t_cprj='" & t_cprj & "'"
        Sql &= "  			and t_cact=@t_pact                                                                                                  "
        Sql &= "  			open @tmp                                                                                                           "
        Sql &= "  			fetch next from @tmp into @tmp_pact                                                                                 "
        Sql &= "  			set @inner = @@FETCH_STATUS                                                                                         "
        Sql &= "  			while @inner = 0                                                                                                    "
        Sql &= "  			begin                                                                                                               "
        Sql &= "  				begin try                                                                                                         "
        Sql &= "  					insert into ttpisg247200 (t_cprj,t_pcod, t_cact, t_pact, t_sact, t_rltp,t_lelg, t_Refcntd, t_Refcntu)           "
        Sql &= "  					values ('" & t_cprj & "','',@t_cact,@tmp_pact,'',0,0,0,0)                                                               "
        Sql &= "  				end try                                                                                                           "
        Sql &= "  				begin catch                                                                                                       "
        Sql &= "  				end catch                                                                                                         "
        Sql &= "  				fetch next from @tmp into @tmp_pact                                                                               "
        Sql &= "  				set @inner = @@FETCH_STATUS                                                                                       "
        Sql &= "  			end                                                                                                                 "
        Sql &= "  			close @tmp                                                                                                          "
        Sql &= "  			deallocate @tmp                                                                                                     "
        Sql &= "  			declare @h_cact varchar(50), @h_pact varchar(50)                                                                    "
        Sql &= "  			declare @parent int, @pfound int                                                                                    "
        Sql &= "  			set @parent = 0                                                                                                     "
        Sql &= "  			while @parent = 0                                                                                                   "
        Sql &= "  			begin                                                                                                               "
        Sql &= "  				declare @hTmp cursor                                                                                              "
        Sql &= "  				set @hTmp = cursor for select t_cact, t_pact from ttpisg220200                                                    "
        Sql &= "  	      where t_cprj='" & t_cprj & "'"
        Sql &= "  				and t_cact=@t_pact                                                                                                "
        Sql &= "  				open @hTmp                                                                                                        "
        Sql &= "  				fetch next from @hTmp into @h_cact,@h_pact                                                                        "
        Sql &= "  				set @pfound = @@FETCH_STATUS                                                                                      "
        Sql &= "  				if (@pfound<>0)                                                                                                   "
        Sql &= "  					set @parent = -1                                                                                              "
        Sql &= "  				else                                                                                                              "
        Sql &= "  					begin                                                                                                           "
        Sql &= "  						set @tmp = cursor for        select t_pact from ttpisg221200                                                  "
        Sql &= "  	          where t_cprj='" & t_cprj & "'"
        Sql &= "  						and t_cact=@h_pact                                                                                            "
        Sql &= "  						open @tmp                                                                                                     "
        Sql &= "  						fetch next from @tmp into @tmp_pact                                                                           "
        Sql &= "  						set @inner = @@FETCH_STATUS                                                                                   "
        Sql &= "  						while @inner = 0                                                                                              "
        Sql &= "  						begin                                                                                                         "
        Sql &= "  							begin try                                                                                                   "
        Sql &= "  								insert into ttpisg247200 (t_cprj,t_pcod, t_cact, t_pact, t_sact, t_rltp,t_lelg, t_Refcntd, t_Refcntu)     "
        Sql &= "  								values ('" & t_cprj & "','',@t_cact,@tmp_pact,'',0,0,0,0)                                                         "
        Sql &= "  							end try                                                                                                     "
        Sql &= "  							begin catch                                                                                                 "
        Sql &= "  							end catch                                                                                                   "
        Sql &= "  							fetch next from @tmp into @tmp_pact                                                                         "
        Sql &= "  							set @inner = @@FETCH_STATUS                                                                                 "
        Sql &= "  						end                                                                                                           "
        Sql &= "  						close @tmp                                                                                                    "
        Sql &= "  						deallocate @tmp                                                                                               "
        Sql &= "  						if(@h_cact=@h_pact)                                                                                           "
        Sql &= "  							set @parent = -1                                                                                          "
        Sql &= "  						else                                                                                                          "
        Sql &= "  							set @t_pact = @h_pact                                                                                     "
        Sql &= "  					end                                                                                                             "
        Sql &= "  				close @hTmp                                                                                                       "
        Sql &= "  				deallocate @hTmp                                                                                                  "
        Sql &= "  			end                                                                                                                 "
        Sql &= "  		end                                                                                                                   "
        Sql &= "  		FETCH NEXT FROM @MyCursor INTO @t_cact,@t_pact                                                                        "
        Sql &= "  		set @outer = @@FETCH_STATUS                                                                                           "
        Sql &= "  	END                                                                                                                     "
        Sql &= "  	CLOSE @MyCursor                                                                                                         "
        Sql &= "  	DEALLOCATE @MyCursor                                                                                                    "
        Sql &= "  END                                                                                                                       "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 900
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return mRet
    End Function
  End Class
End Namespace