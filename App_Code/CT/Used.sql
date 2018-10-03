USE [inforerpdb]
GO

/****** Object:  StoredProcedure [dbo].[spctPUActivityUpdate]    Script Date: 07/07/2018 13:09:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivityUpdate]
  @Original_t_cprj NVarChar(6), 
  @Original_t_atid VarChar(30), 
  @Original_t_srno Int, 
  @t_srno Int,
  @t_plsd DateTime,
  @t_plfd DateTime,
  @t_acsd DateTime,
  @t_aced DateTime,
  @t_puom VarChar(10),
  @t_tpgv Float,
  @t_cpgv Float,
  @t_Refcntd Int,
  @t_gps2 VarChar(100),
  @t_gps4 VarChar(250),
  @t_cron DateTime,
  @t_gps1 VarChar(100),
  @t_gps3 VarChar(100),
  @t_crby VarChar(16),
  @t_otsd DateTime,
  @t_atid VarChar(30),
  @t_cprj NVarChar(6),
  @t_Refcntu Int,
  @t_rmks VarChar(500),
  @t_oted DateTime,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg183200] SET 
   [t_srno] = @t_srno
  ,[t_plsd] = @t_plsd
  ,[t_plfd] = @t_plfd
  ,[t_acsd] = @t_acsd
  ,[t_aced] = @t_aced
  ,[t_puom] = @t_puom
  ,[t_tpgv] = @t_tpgv
  ,[t_cpgv] = @t_cpgv
  ,[t_Refcntd] = @t_Refcntd
  ,[t_gps2] = @t_gps2
  ,[t_gps4] = @t_gps4
  ,[t_cron] = @t_cron
  ,[t_gps1] = @t_gps1
  ,[t_gps3] = @t_gps3
  ,[t_crby] = @t_crby
  ,[t_otsd] = @t_otsd
  ,[t_atid] = @t_atid
  ,[t_cprj] = @t_cprj
  ,[t_Refcntu] = @t_Refcntu
  ,[t_rmks] = @t_rmks
  ,[t_oted] = @t_oted
  WHERE
  [t_cprj] = @Original_t_cprj
  AND [t_atid] = @Original_t_atid
  AND [t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount

GO

/****** Object:  StoredProcedure [dbo].[spctPUActivitySelectListSearch]    Script Date: 07/07/2018 13:09:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivitySelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj NVarChar(6) NOT NULL
 ,t_atid VarChar(30) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_cprj, t_atid, t_srno)
  SELECT [ttpisg183200].[t_cprj], [ttpisg183200].[t_atid], [ttpisg183200].[t_srno] FROM [ttpisg183200]
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg183200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
 WHERE  
   ( 
         STR(ISNULL([ttpisg183200].[t_srno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_puom],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_tpgv], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_crby],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_atid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg2202002].[t_desc],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcmcs0522001].[t_dsca],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_rmks],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [ttpisg183200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttpisg183200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_atid' THEN [ttpisg183200].[t_atid] END,
     CASE @OrderBy WHEN 't_atid DESC' THEN [ttpisg183200].[t_atid] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg183200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg183200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_plsd' THEN [ttpisg183200].[t_plsd] END,
     CASE @OrderBy WHEN 't_plsd DESC' THEN [ttpisg183200].[t_plsd] END DESC,
     CASE @OrderBy WHEN 't_plfd' THEN [ttpisg183200].[t_plfd] END,
     CASE @OrderBy WHEN 't_plfd DESC' THEN [ttpisg183200].[t_plfd] END DESC,
     CASE @OrderBy WHEN 't_acsd' THEN [ttpisg183200].[t_acsd] END,
     CASE @OrderBy WHEN 't_acsd DESC' THEN [ttpisg183200].[t_acsd] END DESC,
     CASE @OrderBy WHEN 't_aced' THEN [ttpisg183200].[t_aced] END,
     CASE @OrderBy WHEN 't_aced DESC' THEN [ttpisg183200].[t_aced] END DESC,
     CASE @OrderBy WHEN 't_otsd' THEN [ttpisg183200].[t_otsd] END,
     CASE @OrderBy WHEN 't_otsd DESC' THEN [ttpisg183200].[t_otsd] END DESC,
     CASE @OrderBy WHEN 't_oted' THEN [ttpisg183200].[t_oted] END,
     CASE @OrderBy WHEN 't_oted DESC' THEN [ttpisg183200].[t_oted] END DESC,
     CASE @OrderBy WHEN 't_rmks' THEN [ttpisg183200].[t_rmks] END,
     CASE @OrderBy WHEN 't_rmks DESC' THEN [ttpisg183200].[t_rmks] END DESC,
     CASE @OrderBy WHEN 't_tpgv' THEN [ttpisg183200].[t_tpgv] END,
     CASE @OrderBy WHEN 't_tpgv DESC' THEN [ttpisg183200].[t_tpgv] END DESC,
     CASE @OrderBy WHEN 't_puom' THEN [ttpisg183200].[t_puom] END,
     CASE @OrderBy WHEN 't_puom DESC' THEN [ttpisg183200].[t_puom] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg183200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg183200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_crby' THEN [ttpisg183200].[t_crby] END,
     CASE @OrderBy WHEN 't_crby DESC' THEN [ttpisg183200].[t_crby] END DESC,
     CASE @OrderBy WHEN 't_gps2' THEN [ttpisg183200].[t_gps2] END,
     CASE @OrderBy WHEN 't_gps2 DESC' THEN [ttpisg183200].[t_gps2] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg183200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg183200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_gps1' THEN [ttpisg183200].[t_gps1] END,
     CASE @OrderBy WHEN 't_gps1 DESC' THEN [ttpisg183200].[t_gps1] END DESC,
     CASE @OrderBy WHEN 't_gps3' THEN [ttpisg183200].[t_gps3] END,
     CASE @OrderBy WHEN 't_gps3 DESC' THEN [ttpisg183200].[t_gps3] END DESC,
     CASE @OrderBy WHEN 't_cron' THEN [ttpisg183200].[t_cron] END,
     CASE @OrderBy WHEN 't_cron DESC' THEN [ttpisg183200].[t_cron] END DESC,
     CASE @OrderBy WHEN 't_gps4' THEN [ttpisg183200].[t_gps4] END,
     CASE @OrderBy WHEN 't_gps4 DESC' THEN [ttpisg183200].[t_gps4] END DESC,
     CASE @OrderBy WHEN 'ttcmcs0522001_t_dsca' THEN [ttcmcs0522001].[t_dsca] END,
     CASE @OrderBy WHEN 'ttcmcs0522001_t_dsca DESC' THEN [ttcmcs0522001].[t_dsca] END DESC,
     CASE @OrderBy WHEN 'ttpisg2202002_t_desc' THEN [ttpisg2202002].[t_desc] END,
     CASE @OrderBy WHEN 'ttpisg2202002_t_desc DESC' THEN [ttpisg2202002].[t_desc] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg183200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca,
    [ttpisg2202002].[t_desc] AS ttpisg2202002_t_desc 
  FROM [ttpisg183200] 
      INNER JOIN #PageIndex
          ON [ttpisg183200].[t_cprj] = #PageIndex.t_cprj COLLATE LATIN1_GENERAL_BIN2
          AND [ttpisg183200].[t_atid] = #PageIndex.t_atid COLLATE LATIN1_GENERAL_BIN2
          AND [ttpisg183200].[t_srno] = #PageIndex.t_srno
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg183200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END

GO

/****** Object:  StoredProcedure [dbo].[spctPUActivitySelectListFilteres]    Script Date: 07/07/2018 13:09:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivitySelectListFilteres]
  @Filter_t_atid VarChar(30),
  @Filter_t_cprj NVarChar(6),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj NVarChar(6) NOT NULL
 ,t_atid VarChar(30) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_cprj'
  SET @LGSQL = @LGSQL + ', t_atid'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg183200].[t_cprj]'
  SET @LGSQL = @LGSQL + ', [ttpisg183200].[t_atid]'
  SET @LGSQL = @LGSQL + ', [ttpisg183200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg183200] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg183200].[t_cprj] = [ttcmcs0522001].[t_cprj]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ttpisg220200] AS [ttpisg2202002]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]'
  SET @LGSQL = @LGSQL + '    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_atid > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg183200].[t_atid] = ''' + @Filter_t_atid + ''' COLLATE LATIN1_GENERAL_BIN2'
  IF (@Filter_t_cprj > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg183200].[t_cprj] = ''' + @Filter_t_cprj + ''' COLLATE LATIN1_GENERAL_BIN2'
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprj' THEN '[ttpisg183200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttpisg183200].[t_cprj] DESC'
                        WHEN 't_atid' THEN '[ttpisg183200].[t_atid]'
                        WHEN 't_atid DESC' THEN '[ttpisg183200].[t_atid] DESC'
                        WHEN 't_srno' THEN '[ttpisg183200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg183200].[t_srno] DESC'
                        WHEN 't_plsd' THEN '[ttpisg183200].[t_plsd]'
                        WHEN 't_plsd DESC' THEN '[ttpisg183200].[t_plsd] DESC'
                        WHEN 't_plfd' THEN '[ttpisg183200].[t_plfd]'
                        WHEN 't_plfd DESC' THEN '[ttpisg183200].[t_plfd] DESC'
                        WHEN 't_acsd' THEN '[ttpisg183200].[t_acsd]'
                        WHEN 't_acsd DESC' THEN '[ttpisg183200].[t_acsd] DESC'
                        WHEN 't_aced' THEN '[ttpisg183200].[t_aced]'
                        WHEN 't_aced DESC' THEN '[ttpisg183200].[t_aced] DESC'
                        WHEN 't_otsd' THEN '[ttpisg183200].[t_otsd]'
                        WHEN 't_otsd DESC' THEN '[ttpisg183200].[t_otsd] DESC'
                        WHEN 't_oted' THEN '[ttpisg183200].[t_oted]'
                        WHEN 't_oted DESC' THEN '[ttpisg183200].[t_oted] DESC'
                        WHEN 't_rmks' THEN '[ttpisg183200].[t_rmks]'
                        WHEN 't_rmks DESC' THEN '[ttpisg183200].[t_rmks] DESC'
                        WHEN 't_tpgv' THEN '[ttpisg183200].[t_tpgv]'
                        WHEN 't_tpgv DESC' THEN '[ttpisg183200].[t_tpgv] DESC'
                        WHEN 't_puom' THEN '[ttpisg183200].[t_puom]'
                        WHEN 't_puom DESC' THEN '[ttpisg183200].[t_puom] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg183200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg183200].[t_Refcntu] DESC'
                        WHEN 't_crby' THEN '[ttpisg183200].[t_crby]'
                        WHEN 't_crby DESC' THEN '[ttpisg183200].[t_crby] DESC'
                        WHEN 't_gps2' THEN '[ttpisg183200].[t_gps2]'
                        WHEN 't_gps2 DESC' THEN '[ttpisg183200].[t_gps2] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg183200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg183200].[t_Refcntd] DESC'
                        WHEN 't_gps1' THEN '[ttpisg183200].[t_gps1]'
                        WHEN 't_gps1 DESC' THEN '[ttpisg183200].[t_gps1] DESC'
                        WHEN 't_gps3' THEN '[ttpisg183200].[t_gps3]'
                        WHEN 't_gps3 DESC' THEN '[ttpisg183200].[t_gps3] DESC'
                        WHEN 't_cron' THEN '[ttpisg183200].[t_cron]'
                        WHEN 't_cron DESC' THEN '[ttpisg183200].[t_cron] DESC'
                        WHEN 't_gps4' THEN '[ttpisg183200].[t_gps4]'
                        WHEN 't_gps4 DESC' THEN '[ttpisg183200].[t_gps4] DESC'
                        WHEN 'ttcmcs0522001_t_dsca' THEN '[ttcmcs0522001].[t_dsca]'
                        WHEN 'ttcmcs0522001_t_dsca DESC' THEN '[ttcmcs0522001].[t_dsca] DESC'
                        WHEN 'ttpisg2202002_t_desc' THEN '[ttpisg2202002].[t_desc]'
                        WHEN 'ttpisg2202002_t_desc DESC' THEN '[ttpisg2202002].[t_desc] DESC'
                        ELSE '[ttpisg183200].[t_cprj],[ttpisg183200].[t_atid],[ttpisg183200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg183200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca,
    [ttpisg2202002].[t_desc] AS ttpisg2202002_t_desc 
  FROM [ttpisg183200] 
      INNER JOIN #PageIndex
          ON [ttpisg183200].[t_cprj] = #PageIndex.t_cprj COLLATE LATIN1_GENERAL_BIN2
          AND [ttpisg183200].[t_atid] = #PageIndex.t_atid COLLATE LATIN1_GENERAL_BIN2
          AND [ttpisg183200].[t_srno] = #PageIndex.t_srno
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg183200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END

GO

/****** Object:  StoredProcedure [dbo].[spctPUActivitySelectByID]    Script Date: 07/07/2018 13:09:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivitySelectByID]
  @LoginID NVarChar(8),
  @t_cprj NVarChar(6),
  @t_atid VarChar(30),
  @t_srno Int 
  AS
  SELECT
    [ttpisg183200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca,
    [ttpisg2202002].[t_desc] AS ttpisg2202002_t_desc 
  FROM [ttpisg183200] 
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg183200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
  WHERE
  [ttpisg183200].[t_cprj] = @t_cprj
  AND [ttpisg183200].[t_atid] = @t_atid
  AND [ttpisg183200].[t_srno] = @t_srno

GO

/****** Object:  StoredProcedure [dbo].[spctPUActivityInsert]    Script Date: 07/07/2018 13:09:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivityInsert]
  @t_srno Int,
  @t_plsd DateTime,
  @t_plfd DateTime,
  @t_acsd DateTime,
  @t_aced DateTime,
  @t_puom VarChar(10),
  @t_tpgv Float,
  @t_cpgv Float,
  @t_Refcntd Int = 0,
  @t_gps2 VarChar(100),
  @t_gps4 VarChar(250),
  @t_cron DateTime,
  @t_gps1 VarChar(100),
  @t_gps3 VarChar(100),
  @t_crby VarChar(16),
  @t_otsd DateTime,
  @t_atid VarChar(30),
  @t_cprj NVarChar(6),
  @t_Refcntu Int =0,
  @t_rmks VarChar(500),
  @t_oted DateTime,
  @Return_t_cprj NVarChar(6) = null OUTPUT, 
  @Return_t_atid VarChar(30) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  BEGIN

  select @t_srno = isnull(max(t_srno),0) + 1 from ttpisg183200  

  INSERT [ttpisg183200]
  (
   [t_srno]
  ,[t_plsd]
  ,[t_plfd]
  ,[t_acsd]
  ,[t_aced]
  ,[t_puom]
  ,[t_tpgv]
  ,[t_cpgv]
  ,[t_Refcntd]
  ,[t_gps2]
  ,[t_gps4]
  ,[t_cron]
  ,[t_gps1]
  ,[t_gps3]
  ,[t_crby]
  ,[t_otsd]
  ,[t_atid]
  ,[t_cprj]
  ,[t_Refcntu]
  ,[t_rmks]
  ,[t_oted]
  )
  VALUES
  (
   @t_srno
  ,@t_plsd
  ,@t_plfd
  ,@t_acsd
  ,@t_aced
  ,@t_puom
  ,@t_tpgv
  ,@t_cpgv
  ,@t_Refcntd
  ,@t_gps2
  ,@t_gps4
  ,@t_cron
  ,@t_gps1
  ,@t_gps3
  ,@t_crby
  ,@t_otsd
  ,UPPER(@t_atid)
  ,UPPER(@t_cprj)
  ,@t_Refcntu
  ,@t_rmks
  ,@t_oted
  )
  SET @Return_t_cprj = @t_cprj
  SET @Return_t_atid = @t_atid
  SET @Return_t_srno = @t_srno
  END

GO

/****** Object:  StoredProcedure [dbo].[spctPUActivityDelete]    Script Date: 07/07/2018 13:09:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPUActivityDelete]
  @Original_t_cprj NVarChar(6),
  @Original_t_atid VarChar(30),
  @Original_t_srno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ttpisg183200]
  WHERE
  [ttpisg183200].[t_cprj] = @Original_t_cprj
  AND [ttpisg183200].[t_atid] = @Original_t_atid
  AND [ttpisg183200].[t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount

GO

/****** Object:  StoredProcedure [dbo].[spctProjectsSelectByID]    Script Date: 07/07/2018 13:09:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctProjectsSelectByID]
  @LoginID NVarChar(8),
  @t_cprj VarChar(6) 
  AS
  SELECT
    [ttcmcs052200].*  
  FROM [ttcmcs052200] 
  WHERE
  [ttcmcs052200].[t_cprj] = @t_cprj

GO

/****** Object:  StoredProcedure [dbo].[spctProjectsAutoCompleteList]    Script Date: 07/07/2018 13:09:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctProjectsAutoCompleteList]
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 =  '%' + LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [ttcmcs052200].[t_dsca]' 
  SET @LGSQL = @LGSQL + ',[ttcmcs052200].[t_cprj]' 
  SET @LGSQL = @LGSQL + ' FROM [ttcmcs052200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttcmcs052200].[t_cprj],'''')) LIKE ''' + @Prefix1 + ''' COLLATE LATIN1_GENERAL_BIN2'
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttcmcs052200].[t_dsca],'''')) LIKE ''' + @Prefix1 + ''' COLLATE LATIN1_GENERAL_BIN2'
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 

GO

/****** Object:  StoredProcedure [dbo].[spctPActivityUpdate]    Script Date: 07/07/2018 13:09:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPActivityUpdate]
  @Original_t_cprj VarChar(9), 
  @Original_t_cact VarChar(30), 
  @t_cprj VarChar(9),
  @t_acty VarChar(9),
  @t_amod VarChar(20),
  @t_dept VarChar(9),
  @t_desc VarChar(256),
  @t_exdo Int,
  @t_outl Int,
  @t_pcbs VarChar(20),
  @t_sub1 VarChar(150),
  @t_sub2 VarChar(150),
  @t_sub3 VarChar(150),
  @t_sub4 VarChar(150),
  @t_vali Int,
  @t_cpgv Float,
  @t_cact VarChar(30),
  @t_pcod VarChar(9),
  @t_sdst DateTime,
  @t_sdfn DateTime,
  @t_acsd DateTime,
  @t_acfn DateTime,
  @t_iref VarChar(50),
  @t_otsd DateTime,
  @t_oted DateTime,
  @t_rmks VarChar(500),
  @t_gps3 VarChar(100),
  @t_gps4 VarChar(100),
  @t_gps2 VarChar(100),
  @t_pred VarChar(200),
  @t_gps1 VarChar(100),
  @t_succ VarChar(200),
  @t_dura Int,
  @t_bcod VarChar(9),
  @t_pact VarChar(30),
  @t_bohd VarChar(20),
  @t_Refcntd Int,
  @t_actp Int,
  @t_schd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg220200] SET 
   [t_cprj] = @t_cprj
  ,[t_acty] = @t_acty
  ,[t_amod] = @t_amod
  ,[t_dept] = @t_dept
  ,[t_desc] = @t_desc
  ,[t_exdo] = @t_exdo
  ,[t_outl] = @t_outl
  ,[t_pcbs] = @t_pcbs
  ,[t_sub1] = @t_sub1
  ,[t_sub2] = @t_sub2
  ,[t_sub3] = @t_sub3
  ,[t_sub4] = @t_sub4
  ,[t_vali] = @t_vali
  ,[t_cpgv] = @t_cpgv
  ,[t_cact] = @t_cact
  ,[t_pcod] = @t_pcod
  ,[t_sdst] = @t_sdst
  ,[t_sdfn] = @t_sdfn
  ,[t_acsd] = @t_acsd
  ,[t_acfn] = @t_acfn
  ,[t_iref] = @t_iref
  ,[t_otsd] = @t_otsd
  ,[t_oted] = @t_oted
  ,[t_rmks] = @t_rmks
  ,[t_gps3] = @t_gps3
  ,[t_gps4] = @t_gps4
  ,[t_gps2] = @t_gps2
  ,[t_pred] = @t_pred
  ,[t_gps1] = @t_gps1
  ,[t_succ] = @t_succ
  ,[t_dura] = @t_dura
  ,[t_bcod] = @t_bcod
  ,[t_pact] = @t_pact
  ,[t_bohd] = @t_bohd
  ,[t_Refcntd] = @t_Refcntd
  ,[t_actp] = @t_actp
  ,[t_schd] = @t_schd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_cprj] = @Original_t_cprj
  AND [t_cact] = @Original_t_cact
  SET @RowCount = @@RowCount

GO

/****** Object:  StoredProcedure [dbo].[spctPActivitySelectListSearch]    Script Date: 07/07/2018 13:09:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPActivitySelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  INSERT INTO #PageIndex (t_cprj, t_cact)
  SELECT [ttpisg220200].[t_cprj], [ttpisg220200].[t_cact] FROM [ttpisg220200]
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  WHERE  
   ( 
        LOWER(ISNULL([ttpisg220200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_acty],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_amod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_dept],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_desc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_exdo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_outl], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pcbs],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_sub4],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_vali], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_cpgv], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_cact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pcod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_iref],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_rmks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps3],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pred],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_gps1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_succ],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_dura], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bcod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bohd],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_actp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_schd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [ttpisg220200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttpisg220200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_acty' THEN [ttpisg220200].[t_acty] END,
     CASE @OrderBy WHEN 't_acty DESC' THEN [ttpisg220200].[t_acty] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttpisg220200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttpisg220200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_dept' THEN [ttpisg220200].[t_dept] END,
     CASE @OrderBy WHEN 't_dept DESC' THEN [ttpisg220200].[t_dept] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttpisg220200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttpisg220200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_exdo' THEN [ttpisg220200].[t_exdo] END,
     CASE @OrderBy WHEN 't_exdo DESC' THEN [ttpisg220200].[t_exdo] END DESC,
     CASE @OrderBy WHEN 't_outl' THEN [ttpisg220200].[t_outl] END,
     CASE @OrderBy WHEN 't_outl DESC' THEN [ttpisg220200].[t_outl] END DESC,
     CASE @OrderBy WHEN 't_pcbs' THEN [ttpisg220200].[t_pcbs] END,
     CASE @OrderBy WHEN 't_pcbs DESC' THEN [ttpisg220200].[t_pcbs] END DESC,
     CASE @OrderBy WHEN 't_sub1' THEN [ttpisg220200].[t_sub1] END,
     CASE @OrderBy WHEN 't_sub1 DESC' THEN [ttpisg220200].[t_sub1] END DESC,
     CASE @OrderBy WHEN 't_sub2' THEN [ttpisg220200].[t_sub2] END,
     CASE @OrderBy WHEN 't_sub2 DESC' THEN [ttpisg220200].[t_sub2] END DESC,
     CASE @OrderBy WHEN 't_sub3' THEN [ttpisg220200].[t_sub3] END,
     CASE @OrderBy WHEN 't_sub3 DESC' THEN [ttpisg220200].[t_sub3] END DESC,
     CASE @OrderBy WHEN 't_sub4' THEN [ttpisg220200].[t_sub4] END,
     CASE @OrderBy WHEN 't_sub4 DESC' THEN [ttpisg220200].[t_sub4] END DESC,
     CASE @OrderBy WHEN 't_vali' THEN [ttpisg220200].[t_vali] END,
     CASE @OrderBy WHEN 't_vali DESC' THEN [ttpisg220200].[t_vali] END DESC,
     CASE @OrderBy WHEN 't_cpgv' THEN [ttpisg220200].[t_cpgv] END,
     CASE @OrderBy WHEN 't_cpgv DESC' THEN [ttpisg220200].[t_cpgv] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttpisg220200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttpisg220200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_pcod' THEN [ttpisg220200].[t_pcod] END,
     CASE @OrderBy WHEN 't_pcod DESC' THEN [ttpisg220200].[t_pcod] END DESC,
     CASE @OrderBy WHEN 't_sdst' THEN [ttpisg220200].[t_sdst] END,
     CASE @OrderBy WHEN 't_sdst DESC' THEN [ttpisg220200].[t_sdst] END DESC,
     CASE @OrderBy WHEN 't_sdfn' THEN [ttpisg220200].[t_sdfn] END,
     CASE @OrderBy WHEN 't_sdfn DESC' THEN [ttpisg220200].[t_sdfn] END DESC,
     CASE @OrderBy WHEN 't_acsd' THEN [ttpisg220200].[t_acsd] END,
     CASE @OrderBy WHEN 't_acsd DESC' THEN [ttpisg220200].[t_acsd] END DESC,
     CASE @OrderBy WHEN 't_acfn' THEN [ttpisg220200].[t_acfn] END,
     CASE @OrderBy WHEN 't_acfn DESC' THEN [ttpisg220200].[t_acfn] END DESC,
     CASE @OrderBy WHEN 't_iref' THEN [ttpisg220200].[t_iref] END,
     CASE @OrderBy WHEN 't_iref DESC' THEN [ttpisg220200].[t_iref] END DESC,
     CASE @OrderBy WHEN 't_otsd' THEN [ttpisg220200].[t_otsd] END,
     CASE @OrderBy WHEN 't_otsd DESC' THEN [ttpisg220200].[t_otsd] END DESC,
     CASE @OrderBy WHEN 't_oted' THEN [ttpisg220200].[t_oted] END,
     CASE @OrderBy WHEN 't_oted DESC' THEN [ttpisg220200].[t_oted] END DESC,
     CASE @OrderBy WHEN 't_rmks' THEN [ttpisg220200].[t_rmks] END,
     CASE @OrderBy WHEN 't_rmks DESC' THEN [ttpisg220200].[t_rmks] END DESC,
     CASE @OrderBy WHEN 't_gps3' THEN [ttpisg220200].[t_gps3] END,
     CASE @OrderBy WHEN 't_gps3 DESC' THEN [ttpisg220200].[t_gps3] END DESC,
     CASE @OrderBy WHEN 't_gps4' THEN [ttpisg220200].[t_gps4] END,
     CASE @OrderBy WHEN 't_gps4 DESC' THEN [ttpisg220200].[t_gps4] END DESC,
     CASE @OrderBy WHEN 't_gps2' THEN [ttpisg220200].[t_gps2] END,
     CASE @OrderBy WHEN 't_gps2 DESC' THEN [ttpisg220200].[t_gps2] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg220200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg220200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_gps1' THEN [ttpisg220200].[t_gps1] END,
     CASE @OrderBy WHEN 't_gps1 DESC' THEN [ttpisg220200].[t_gps1] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg220200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg220200].[t_succ] END DESC,
     CASE @OrderBy WHEN 't_dura' THEN [ttpisg220200].[t_dura] END,
     CASE @OrderBy WHEN 't_dura DESC' THEN [ttpisg220200].[t_dura] END DESC,
     CASE @OrderBy WHEN 't_bcod' THEN [ttpisg220200].[t_bcod] END,
     CASE @OrderBy WHEN 't_bcod DESC' THEN [ttpisg220200].[t_bcod] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg220200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg220200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg220200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg220200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg220200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg220200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg220200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg220200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_schd' THEN [ttpisg220200].[t_schd] END,
     CASE @OrderBy WHEN 't_schd DESC' THEN [ttpisg220200].[t_schd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg220200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg220200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 'ttcmcs0522001_t_dsca' THEN [ttcmcs0522001].[t_dsca] END,
     CASE @OrderBy WHEN 'ttcmcs0522001_t_dsca DESC' THEN [ttcmcs0522001].[t_dsca] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca 
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END

GO

/****** Object:  StoredProcedure [dbo].[spctPActivitySelectListFilteres]    Script Date: 07/07/2018 13:09:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPActivitySelectListFilteres]
  @Filter_t_cprj VarChar(9),
  @Filter_t_cact VarChar(30),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_cprj'
  SET @LGSQL = @LGSQL + ', t_cact'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg220200].[t_cprj]'
  SET @LGSQL = @LGSQL + ', [ttpisg220200].[t_cact]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_cprj > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_cprj] = ''' + @Filter_t_cprj + ''''
  IF (@Filter_t_cact > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_cact] = ''' + @Filter_t_cact + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprj' THEN '[ttpisg220200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttpisg220200].[t_cprj] DESC'
                        WHEN 't_acty' THEN '[ttpisg220200].[t_acty]'
                        WHEN 't_acty DESC' THEN '[ttpisg220200].[t_acty] DESC'
                        WHEN 't_amod' THEN '[ttpisg220200].[t_amod]'
                        WHEN 't_amod DESC' THEN '[ttpisg220200].[t_amod] DESC'
                        WHEN 't_dept' THEN '[ttpisg220200].[t_dept]'
                        WHEN 't_dept DESC' THEN '[ttpisg220200].[t_dept] DESC'
                        WHEN 't_desc' THEN '[ttpisg220200].[t_desc]'
                        WHEN 't_desc DESC' THEN '[ttpisg220200].[t_desc] DESC'
                        WHEN 't_exdo' THEN '[ttpisg220200].[t_exdo]'
                        WHEN 't_exdo DESC' THEN '[ttpisg220200].[t_exdo] DESC'
                        WHEN 't_outl' THEN '[ttpisg220200].[t_outl]'
                        WHEN 't_outl DESC' THEN '[ttpisg220200].[t_outl] DESC'
                        WHEN 't_pcbs' THEN '[ttpisg220200].[t_pcbs]'
                        WHEN 't_pcbs DESC' THEN '[ttpisg220200].[t_pcbs] DESC'
                        WHEN 't_sub1' THEN '[ttpisg220200].[t_sub1]'
                        WHEN 't_sub1 DESC' THEN '[ttpisg220200].[t_sub1] DESC'
                        WHEN 't_sub2' THEN '[ttpisg220200].[t_sub2]'
                        WHEN 't_sub2 DESC' THEN '[ttpisg220200].[t_sub2] DESC'
                        WHEN 't_sub3' THEN '[ttpisg220200].[t_sub3]'
                        WHEN 't_sub3 DESC' THEN '[ttpisg220200].[t_sub3] DESC'
                        WHEN 't_sub4' THEN '[ttpisg220200].[t_sub4]'
                        WHEN 't_sub4 DESC' THEN '[ttpisg220200].[t_sub4] DESC'
                        WHEN 't_vali' THEN '[ttpisg220200].[t_vali]'
                        WHEN 't_vali DESC' THEN '[ttpisg220200].[t_vali] DESC'
                        WHEN 't_cpgv' THEN '[ttpisg220200].[t_cpgv]'
                        WHEN 't_cpgv DESC' THEN '[ttpisg220200].[t_cpgv] DESC'
                        WHEN 't_cact' THEN '[ttpisg220200].[t_cact]'
                        WHEN 't_cact DESC' THEN '[ttpisg220200].[t_cact] DESC'
                        WHEN 't_pcod' THEN '[ttpisg220200].[t_pcod]'
                        WHEN 't_pcod DESC' THEN '[ttpisg220200].[t_pcod] DESC'
                        WHEN 't_sdst' THEN '[ttpisg220200].[t_sdst]'
                        WHEN 't_sdst DESC' THEN '[ttpisg220200].[t_sdst] DESC'
                        WHEN 't_sdfn' THEN '[ttpisg220200].[t_sdfn]'
                        WHEN 't_sdfn DESC' THEN '[ttpisg220200].[t_sdfn] DESC'
                        WHEN 't_acsd' THEN '[ttpisg220200].[t_acsd]'
                        WHEN 't_acsd DESC' THEN '[ttpisg220200].[t_acsd] DESC'
                        WHEN 't_acfn' THEN '[ttpisg220200].[t_acfn]'
                        WHEN 't_acfn DESC' THEN '[ttpisg220200].[t_acfn] DESC'
                        WHEN 't_iref' THEN '[ttpisg220200].[t_iref]'
                        WHEN 't_iref DESC' THEN '[ttpisg220200].[t_iref] DESC'
                        WHEN 't_otsd' THEN '[ttpisg220200].[t_otsd]'
                        WHEN 't_otsd DESC' THEN '[ttpisg220200].[t_otsd] DESC'
                        WHEN 't_oted' THEN '[ttpisg220200].[t_oted]'
                        WHEN 't_oted DESC' THEN '[ttpisg220200].[t_oted] DESC'
                        WHEN 't_rmks' THEN '[ttpisg220200].[t_rmks]'
                        WHEN 't_rmks DESC' THEN '[ttpisg220200].[t_rmks] DESC'
                        WHEN 't_gps3' THEN '[ttpisg220200].[t_gps3]'
                        WHEN 't_gps3 DESC' THEN '[ttpisg220200].[t_gps3] DESC'
                        WHEN 't_gps4' THEN '[ttpisg220200].[t_gps4]'
                        WHEN 't_gps4 DESC' THEN '[ttpisg220200].[t_gps4] DESC'
                        WHEN 't_gps2' THEN '[ttpisg220200].[t_gps2]'
                        WHEN 't_gps2 DESC' THEN '[ttpisg220200].[t_gps2] DESC'
                        WHEN 't_pred' THEN '[ttpisg220200].[t_pred]'
                        WHEN 't_pred DESC' THEN '[ttpisg220200].[t_pred] DESC'
                        WHEN 't_gps1' THEN '[ttpisg220200].[t_gps1]'
                        WHEN 't_gps1 DESC' THEN '[ttpisg220200].[t_gps1] DESC'
                        WHEN 't_succ' THEN '[ttpisg220200].[t_succ]'
                        WHEN 't_succ DESC' THEN '[ttpisg220200].[t_succ] DESC'
                        WHEN 't_dura' THEN '[ttpisg220200].[t_dura]'
                        WHEN 't_dura DESC' THEN '[ttpisg220200].[t_dura] DESC'
                        WHEN 't_bcod' THEN '[ttpisg220200].[t_bcod]'
                        WHEN 't_bcod DESC' THEN '[ttpisg220200].[t_bcod] DESC'
                        WHEN 't_pact' THEN '[ttpisg220200].[t_pact]'
                        WHEN 't_pact DESC' THEN '[ttpisg220200].[t_pact] DESC'
                        WHEN 't_bohd' THEN '[ttpisg220200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg220200].[t_bohd] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg220200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg220200].[t_Refcntd] DESC'
                        WHEN 't_actp' THEN '[ttpisg220200].[t_actp]'
                        WHEN 't_actp DESC' THEN '[ttpisg220200].[t_actp] DESC'
                        WHEN 't_schd' THEN '[ttpisg220200].[t_schd]'
                        WHEN 't_schd DESC' THEN '[ttpisg220200].[t_schd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg220200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg220200].[t_Refcntu] DESC'
                        WHEN 'ttcmcs0522001_t_dsca' THEN '[ttcmcs0522001].[t_dsca]'
                        WHEN 'ttcmcs0522001_t_dsca DESC' THEN '[ttcmcs0522001].[t_dsca] DESC'
                        ELSE '[ttpisg220200].[t_cprj],[ttpisg220200].[t_cact]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca 
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END

GO

/****** Object:  StoredProcedure [dbo].[spctPActivitySelectByID]    Script Date: 07/07/2018 13:09:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPActivitySelectByID]
  @LoginID NVarChar(8),
  @t_cprj VarChar(9),
  @t_cact VarChar(30) 
  AS
  SELECT
    [ttpisg220200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca 
  FROM [ttpisg220200] 
  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]
  WHERE
  [ttpisg220200].[t_cprj] = @t_cprj
  AND [ttpisg220200].[t_cact] = @t_cact

GO

/****** Object:  StoredProcedure [dbo].[spctPActivityAutoCompleteList]    Script Date: 07/07/2018 13:09:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctPActivityAutoCompleteList]
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [ttpisg220200].[t_desc]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cprj]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cact]' 
  SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttpisg220200].[t_cprj],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_desc],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_cact],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 

GO

/****** Object:  StoredProcedure [dbo].[spctHeaderInsert]    Script Date: 07/07/2018 13:09:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctHeaderInsert]
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(50),
  @t_srno Int,
  @t_stat VarChar(20),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_user VarChar(9),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_trdt DateTime = null OUTPUT, 
  @Return_t_bohd VarChar(50) = null OUTPUT, 
  @Return_t_indv VarChar(50) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  INSERT [ttpisg229200]
  (
   [t_trdt]
  ,[t_bohd]
  ,[t_indv]
  ,[t_srno]
  ,[t_stat]
  ,[t_proj]
  ,[t_elem]
  ,[t_user]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   @t_trdt
  ,UPPER(@t_bohd)
  ,UPPER(@t_indv)
  ,@t_srno
  ,@t_stat
  ,@t_proj
  ,@t_elem
  ,@t_user
  ,0
  ,0
  )
  SET @Return_t_trdt = @t_trdt
  SET @Return_t_bohd = @t_bohd
  SET @Return_t_indv = @t_indv
  SET @Return_t_srno = @t_srno

GO

/****** Object:  StoredProcedure [dbo].[spctDetailInsert]    Script Date: 07/07/2018 13:09:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spctDetailInsert]
  @t_trdt DateTime,
  @t_bohd VarChar(50),
  @t_indv VarChar(100),
  @t_srno Int,
  @t_dsno Int,
  @t_stat VarChar(50),
  @t_proj VarChar(9),
  @t_elem VarChar(8),
  @t_dwno VarChar(32),
  @t_pitc Int,
  @t_wght Float,
  @t_atcd VarChar(8),
  @t_scup Int,
  --@t_acdt DateTime,
  --@t_acfh DateTime,
  --@t_pper Real,
  --@t_lupd DateTime,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_trdt DateTime = null OUTPUT, 
  @Return_t_bohd VarChar(50) = null OUTPUT, 
  @Return_t_indv VarChar(100) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT, 
  @Return_t_dsno Int = null OUTPUT 
  AS
  INSERT [ttpisg230200]
  (
   [t_trdt]
  ,[t_bohd]
  ,[t_indv]
  ,[t_srno]
  ,[t_dsno]
  ,[t_stat]
  ,[t_proj]
  ,[t_elem]
  ,[t_dwno]
  ,[t_pitc]
  ,[t_wght]
  ,[t_atcd]
  ,[t_scup]
  ,[t_acdt]
  ,[t_acfh]
  ,[t_pper]
  ,[t_lupd]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   @t_trdt
  ,UPPER(@t_bohd)
  ,UPPER(@t_indv)
  ,@t_srno
  ,@t_dsno
  ,@t_stat
  ,@t_proj
  ,@t_elem
  ,@t_dwno
  ,@t_pitc
  ,@t_wght
  ,''
  ,@t_scup
  ,convert(datetime,'01/01/1975',103)
  ,convert(datetime,'01/01/1975',103)
  ,0
  ,convert(datetime,'01/01/1975',103)
  ,0
  ,0
  )
  SET @Return_t_trdt = @t_trdt
  SET @Return_t_bohd = @t_bohd
  SET @Return_t_indv = @t_indv
  SET @Return_t_srno = @t_srno
  SET @Return_t_dsno = @t_dsno

GO

/****** Object:  StoredProcedure [dbo].[spct_LG_PActivitySelectListFilteres]    Script Date: 07/07/2018 13:09:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spct_LG_PActivitySelectListFilteres]
  @Filter_t_cprj NVarChar(6),
  @Filter_Departments NVarChar(250) = '',
  @LoginID NVarChar(8),
  @StartRowIndex int = 0,
  @MaximumRows int = 99,
  @OrderBy NVarChar(50),
  @KeyWord VarChar(250),
  @IsSearch Bit = 0,
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'

	DECLARE @LGSQL VarChar(8000)
	CREATE TABLE #PageIndex (
	  IndexID INT IDENTITY (1, 1) NOT NULL,
	  t_cprj NVarChar(6) NOT NULL,
	  t_cact VarChar(30) NOT NULL
	)
	SET @LGSQL = 'INSERT INTO #PageIndex (' 
	SET @LGSQL = @LGSQL + 't_cprj'
	SET @LGSQL = @LGSQL + ', t_cact'
	SET @LGSQL = @LGSQL + ')'
	SET @LGSQL = @LGSQL + ' SELECT '
	SET @LGSQL = @LGSQL + '[ttpisg220200].[t_cprj]'
	SET @LGSQL = @LGSQL + ', [ttpisg220200].[t_cact]'
	SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] '
	SET @LGSQL = @LGSQL + '  INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]'
	SET @LGSQL = @LGSQL + '    ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]'
	SET @LGSQL = @LGSQL + '  WHERE [ttpisg220200].[t_acty] != ''PARENT'' AND ([ttpisg220200].[t_bohd] ='''' OR [ttpisg220200].[t_bohd] = ''Mobile_ERP_APP'') '
	IF (@Filter_Departments > '') 
	  SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_dept]  IN (' + @Filter_Departments + ') COLLATE LATIN1_GENERAL_BIN2'
	IF (@Filter_t_cprj > '') 
	  SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_cprj] = ''' + @Filter_t_cprj + ''' COLLATE LATIN1_GENERAL_BIN2'
	IF (@IsSearch = 0) 
	BEGIN
	  SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_acfn] = convert(datetime,''01/01/1753'', 103) '
	  SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_sdst] <= DateAdd(Day,30,GetDate()) '
	END
	IF (@IsSearch = 1) 
	BEGIN
	  SET @LGSQL = @LGSQL + ' AND ( '
	  SET @LGSQL = @LGSQL + ' LOWER(ISNULL([ttpisg220200].[t_cact],'''')) LIKE ''' + @KeyWord1 + ''' COLLATE LATIN1_GENERAL_BIN2'
	  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_iref],'''')) LIKE ''' + @KeyWord1 + ''' COLLATE LATIN1_GENERAL_BIN2'
	  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_desc], '''')) LIKE ''' + @KeyWord1 + ''' COLLATE LATIN1_GENERAL_BIN2'
	  SET @LGSQL = @LGSQL + ' )' 
	END
	SET @LGSQL = @LGSQL + '  ORDER BY '
	SET @LGSQL = @LGSQL + 
	    CASE @OrderBy
            WHEN 't_sdst' THEN '[ttpisg220200].[t_sdst]'
            WHEN 't_sdst DESC' THEN '[ttpisg220200].[t_sdst] DESC'
            WHEN 't_sdfn' THEN '[ttpisg220200].[t_sdfn]'
            WHEN 't_sdfn DESC' THEN '[ttpisg220200].[t_sdfn] DESC'
            WHEN 't_desc' THEN '[ttpisg220200].[t_desc]'
            WHEN 't_desc DESC' THEN '[ttpisg220200].[t_desc] DESC'
            ELSE '[ttpisg220200].[t_cprj],[ttpisg220200].[t_cact]'
        END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].* ,
    [ttcmcs0522001].[t_dsca] AS ttcmcs0522001_t_dsca 
  FROM [ttpisg220200] 
    INNER JOIN #PageIndex
      ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj COLLATE LATIN1_GENERAL_BIN2
      AND [ttpisg220200].[t_cact] = #PageIndex.t_cact COLLATE LATIN1_GENERAL_BIN2 
    INNER JOIN [ttcmcs052200] AS [ttcmcs0522001]
      ON [ttpisg220200].[t_cprj] = [ttcmcs0522001].[t_cprj]
   WHERE
     #PageIndex.IndexID > @StartRowIndex
     AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
   ORDER BY
     #PageIndex.IndexID
  END

GO

/****** Object:  StoredProcedure [dbo].[spct_LG_PActivityAutoCompleteList]    Script Date: 07/07/2018 13:09:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[spct_LG_PActivityAutoCompleteList]
  @LoginID NVarChar(8),
  @ProjectID NVarChar(9),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = '%' + LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [ttpisg220200].[t_desc]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cprj]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cact]' 
  SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  IF(@ProjectID <> '')  
    SET @LGSQL = @LGSQL + ' AND LOWER(ISNULL([ttpisg220200].[t_cprj],'''')) = ''' + LOWER(@ProjectID) + ''''
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttpisg220200].[t_cact],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_desc],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 

GO


