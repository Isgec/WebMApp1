SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivitySelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivitySelectList]
GO
 
CREATE PROCEDURE [dbo].[spctMActivitySelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [ttpisg200200].*  
  FROM [ttpisg200200] 
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 't_cprd' THEN [ttpisg200200].[t_cprd] END,
     CASE @OrderBy WHEN 't_cprd DESC' THEN [ttpisg200200].[t_cprd] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttpisg200200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttpisg200200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttpisg200200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttpisg200200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_pcbs' THEN [ttpisg200200].[t_pcbs] END,
     CASE @OrderBy WHEN 't_pcbs DESC' THEN [ttpisg200200].[t_pcbs] END DESC,
     CASE @OrderBy WHEN 't_acty' THEN [ttpisg200200].[t_acty] END,
     CASE @OrderBy WHEN 't_acty DESC' THEN [ttpisg200200].[t_acty] END DESC,
     CASE @OrderBy WHEN 't_dept' THEN [ttpisg200200].[t_dept] END,
     CASE @OrderBy WHEN 't_dept DESC' THEN [ttpisg200200].[t_dept] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttpisg200200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttpisg200200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_iref' THEN [ttpisg200200].[t_iref] END,
     CASE @OrderBy WHEN 't_iref DESC' THEN [ttpisg200200].[t_iref] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg200200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg200200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg200200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg200200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_exdo' THEN [ttpisg200200].[t_exdo] END,
     CASE @OrderBy WHEN 't_exdo DESC' THEN [ttpisg200200].[t_exdo] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg200200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg200200].[t_succ] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg200200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg200200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg200200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg200200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_sub2' THEN [ttpisg200200].[t_sub2] END,
     CASE @OrderBy WHEN 't_sub2 DESC' THEN [ttpisg200200].[t_sub2] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg200200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg200200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg200200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg200200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_outl' THEN [ttpisg200200].[t_outl] END,
     CASE @OrderBy WHEN 't_outl DESC' THEN [ttpisg200200].[t_outl] END DESC,
     CASE @OrderBy WHEN 't_vali' THEN [ttpisg200200].[t_vali] END,
     CASE @OrderBy WHEN 't_vali DESC' THEN [ttpisg200200].[t_vali] END DESC,
     CASE @OrderBy WHEN 't_sub1' THEN [ttpisg200200].[t_sub1] END,
     CASE @OrderBy WHEN 't_sub1 DESC' THEN [ttpisg200200].[t_sub1] END DESC,
     CASE @OrderBy WHEN 't_sub4' THEN [ttpisg200200].[t_sub4] END,
     CASE @OrderBy WHEN 't_sub4 DESC' THEN [ttpisg200200].[t_sub4] END DESC,
     CASE @OrderBy WHEN 't_sub3' THEN [ttpisg200200].[t_sub3] END,
     CASE @OrderBy WHEN 't_sub3 DESC' THEN [ttpisg200200].[t_sub3] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivityAutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivityAutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[spctMActivityAutoCompleteList]
  @DF_t_cprd VarChar(9),
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
  SET @LGSQL = @LGSQL + ' [ttpisg200200].[t_desc]' 
  SET @LGSQL = @LGSQL + ',[ttpisg200200].[t_cprd]' 
  SET @LGSQL = @LGSQL + ',[ttpisg200200].[t_cact]' 
  SET @LGSQL = @LGSQL + ' FROM [ttpisg200200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttpisg200200].[t_cprd],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg200200].[t_cact],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg200200].[t_desc],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  IF (@DF_t_cprd > '') 
    SET @LGSQL = @LGSQL + ' AND LOWER([ttpisg200200].[t_cprd]) = ''' + LOWER(@DF_t_cprd) + ''''
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivitySelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivitySelectByID]
GO
 
CREATE PROCEDURE [dbo].[spctMActivitySelectByID]
  @LoginID NVarChar(8),
  @t_cprd VarChar(9),
  @t_cact VarChar(30) 
  AS
  SELECT
    [ttpisg200200].*  
  FROM [ttpisg200200] 
  WHERE
  [ttpisg200200].[t_cprd] = @t_cprd
  AND [ttpisg200200].[t_cact] = @t_cact
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivitySelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivitySelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spctMActivitySelectListSearch]
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
 ,t_cprd VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  INSERT INTO #PageIndex (t_cprd, t_cact)
  SELECT [ttpisg200200].[t_cprd], [ttpisg200200].[t_cact] FROM [ttpisg200200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg200200].[t_cprd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_cact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_desc],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_pcbs],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_acty],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_dept],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_amod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_iref],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_exdo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_succ],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_pact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_pred],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_sub2],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_actp], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_bohd],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_outl], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg200200].[t_vali], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_sub1],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_sub4],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg200200].[t_sub3],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprd' THEN [ttpisg200200].[t_cprd] END,
     CASE @OrderBy WHEN 't_cprd DESC' THEN [ttpisg200200].[t_cprd] END DESC,
     CASE @OrderBy WHEN 't_cact' THEN [ttpisg200200].[t_cact] END,
     CASE @OrderBy WHEN 't_cact DESC' THEN [ttpisg200200].[t_cact] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttpisg200200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttpisg200200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_pcbs' THEN [ttpisg200200].[t_pcbs] END,
     CASE @OrderBy WHEN 't_pcbs DESC' THEN [ttpisg200200].[t_pcbs] END DESC,
     CASE @OrderBy WHEN 't_acty' THEN [ttpisg200200].[t_acty] END,
     CASE @OrderBy WHEN 't_acty DESC' THEN [ttpisg200200].[t_acty] END DESC,
     CASE @OrderBy WHEN 't_dept' THEN [ttpisg200200].[t_dept] END,
     CASE @OrderBy WHEN 't_dept DESC' THEN [ttpisg200200].[t_dept] END DESC,
     CASE @OrderBy WHEN 't_amod' THEN [ttpisg200200].[t_amod] END,
     CASE @OrderBy WHEN 't_amod DESC' THEN [ttpisg200200].[t_amod] END DESC,
     CASE @OrderBy WHEN 't_iref' THEN [ttpisg200200].[t_iref] END,
     CASE @OrderBy WHEN 't_iref DESC' THEN [ttpisg200200].[t_iref] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg200200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg200200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg200200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg200200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_exdo' THEN [ttpisg200200].[t_exdo] END,
     CASE @OrderBy WHEN 't_exdo DESC' THEN [ttpisg200200].[t_exdo] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg200200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg200200].[t_succ] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg200200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg200200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg200200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg200200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_sub2' THEN [ttpisg200200].[t_sub2] END,
     CASE @OrderBy WHEN 't_sub2 DESC' THEN [ttpisg200200].[t_sub2] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg200200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg200200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg200200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg200200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_outl' THEN [ttpisg200200].[t_outl] END,
     CASE @OrderBy WHEN 't_outl DESC' THEN [ttpisg200200].[t_outl] END DESC,
     CASE @OrderBy WHEN 't_vali' THEN [ttpisg200200].[t_vali] END,
     CASE @OrderBy WHEN 't_vali DESC' THEN [ttpisg200200].[t_vali] END DESC,
     CASE @OrderBy WHEN 't_sub1' THEN [ttpisg200200].[t_sub1] END,
     CASE @OrderBy WHEN 't_sub1 DESC' THEN [ttpisg200200].[t_sub1] END DESC,
     CASE @OrderBy WHEN 't_sub4' THEN [ttpisg200200].[t_sub4] END,
     CASE @OrderBy WHEN 't_sub4 DESC' THEN [ttpisg200200].[t_sub4] END DESC,
     CASE @OrderBy WHEN 't_sub3' THEN [ttpisg200200].[t_sub3] END,
     CASE @OrderBy WHEN 't_sub3 DESC' THEN [ttpisg200200].[t_sub3] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg200200].*  
  FROM [ttpisg200200] 
      INNER JOIN #PageIndex
          ON [ttpisg200200].[t_cprd] = #PageIndex.t_cprd
          AND [ttpisg200200].[t_cact] = #PageIndex.t_cact
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivitySelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivitySelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spctMActivitySelectListFilteres]
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
 ,t_cprd VarChar(9) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_cprd'
  SET @LGSQL = @LGSQL + ', t_cact'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg200200].[t_cprd]'
  SET @LGSQL = @LGSQL + ', [ttpisg200200].[t_cact]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg200200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprd' THEN '[ttpisg200200].[t_cprd]'
                        WHEN 't_cprd DESC' THEN '[ttpisg200200].[t_cprd] DESC'
                        WHEN 't_cact' THEN '[ttpisg200200].[t_cact]'
                        WHEN 't_cact DESC' THEN '[ttpisg200200].[t_cact] DESC'
                        WHEN 't_desc' THEN '[ttpisg200200].[t_desc]'
                        WHEN 't_desc DESC' THEN '[ttpisg200200].[t_desc] DESC'
                        WHEN 't_pcbs' THEN '[ttpisg200200].[t_pcbs]'
                        WHEN 't_pcbs DESC' THEN '[ttpisg200200].[t_pcbs] DESC'
                        WHEN 't_acty' THEN '[ttpisg200200].[t_acty]'
                        WHEN 't_acty DESC' THEN '[ttpisg200200].[t_acty] DESC'
                        WHEN 't_dept' THEN '[ttpisg200200].[t_dept]'
                        WHEN 't_dept DESC' THEN '[ttpisg200200].[t_dept] DESC'
                        WHEN 't_amod' THEN '[ttpisg200200].[t_amod]'
                        WHEN 't_amod DESC' THEN '[ttpisg200200].[t_amod] DESC'
                        WHEN 't_iref' THEN '[ttpisg200200].[t_iref]'
                        WHEN 't_iref DESC' THEN '[ttpisg200200].[t_iref] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg200200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg200200].[t_Refcntu] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg200200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg200200].[t_Refcntd] DESC'
                        WHEN 't_exdo' THEN '[ttpisg200200].[t_exdo]'
                        WHEN 't_exdo DESC' THEN '[ttpisg200200].[t_exdo] DESC'
                        WHEN 't_succ' THEN '[ttpisg200200].[t_succ]'
                        WHEN 't_succ DESC' THEN '[ttpisg200200].[t_succ] DESC'
                        WHEN 't_pact' THEN '[ttpisg200200].[t_pact]'
                        WHEN 't_pact DESC' THEN '[ttpisg200200].[t_pact] DESC'
                        WHEN 't_pred' THEN '[ttpisg200200].[t_pred]'
                        WHEN 't_pred DESC' THEN '[ttpisg200200].[t_pred] DESC'
                        WHEN 't_sub2' THEN '[ttpisg200200].[t_sub2]'
                        WHEN 't_sub2 DESC' THEN '[ttpisg200200].[t_sub2] DESC'
                        WHEN 't_actp' THEN '[ttpisg200200].[t_actp]'
                        WHEN 't_actp DESC' THEN '[ttpisg200200].[t_actp] DESC'
                        WHEN 't_bohd' THEN '[ttpisg200200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg200200].[t_bohd] DESC'
                        WHEN 't_outl' THEN '[ttpisg200200].[t_outl]'
                        WHEN 't_outl DESC' THEN '[ttpisg200200].[t_outl] DESC'
                        WHEN 't_vali' THEN '[ttpisg200200].[t_vali]'
                        WHEN 't_vali DESC' THEN '[ttpisg200200].[t_vali] DESC'
                        WHEN 't_sub1' THEN '[ttpisg200200].[t_sub1]'
                        WHEN 't_sub1 DESC' THEN '[ttpisg200200].[t_sub1] DESC'
                        WHEN 't_sub4' THEN '[ttpisg200200].[t_sub4]'
                        WHEN 't_sub4 DESC' THEN '[ttpisg200200].[t_sub4] DESC'
                        WHEN 't_sub3' THEN '[ttpisg200200].[t_sub3]'
                        WHEN 't_sub3 DESC' THEN '[ttpisg200200].[t_sub3] DESC'
                        ELSE '[ttpisg200200].[t_cprd],[ttpisg200200].[t_cact]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg200200].*  
  FROM [ttpisg200200] 
      INNER JOIN #PageIndex
          ON [ttpisg200200].[t_cprd] = #PageIndex.t_cprd
          AND [ttpisg200200].[t_cact] = #PageIndex.t_cact
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctMActivityUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctMActivityUpdate]
GO
 
CREATE PROCEDURE [dbo].[spctMActivityUpdate]
  @Original_t_cprd VarChar(9), 
  @Original_t_cact VarChar(30), 
  @t_cprd VarChar(9),
  @t_cact VarChar(30),
  @t_desc VarChar(256),
  @t_pcbs VarChar(20),
  @t_acty VarChar(9),
  @t_dept VarChar(9),
  @t_amod VarChar(20),
  @t_iref VarChar(20),
  @t_Refcntu Int,
  @t_Refcntd Int,
  @t_exdo Int,
  @t_succ VarChar(200),
  @t_pact VarChar(30),
  @t_pred VarChar(200),
  @t_sub2 VarChar(150),
  @t_actp Int,
  @t_bohd VarChar(20),
  @t_outl Int,
  @t_vali Int,
  @t_sub1 VarChar(150),
  @t_sub4 VarChar(150),
  @t_sub3 VarChar(150),
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg200200] SET 
   [t_cprd] = @t_cprd
  ,[t_cact] = @t_cact
  ,[t_desc] = @t_desc
  ,[t_pcbs] = @t_pcbs
  ,[t_acty] = @t_acty
  ,[t_dept] = @t_dept
  ,[t_amod] = @t_amod
  ,[t_iref] = @t_iref
  ,[t_Refcntu] = @t_Refcntu
  ,[t_Refcntd] = @t_Refcntd
  ,[t_exdo] = @t_exdo
  ,[t_succ] = @t_succ
  ,[t_pact] = @t_pact
  ,[t_pred] = @t_pred
  ,[t_sub2] = @t_sub2
  ,[t_actp] = @t_actp
  ,[t_bohd] = @t_bohd
  ,[t_outl] = @t_outl
  ,[t_vali] = @t_vali
  ,[t_sub1] = @t_sub1
  ,[t_sub4] = @t_sub4
  ,[t_sub3] = @t_sub3
  WHERE
  [t_cprd] = @Original_t_cprd
  AND [t_cact] = @Original_t_cact
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivitySelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivitySelectList]
GO
 
CREATE PROCEDURE [dbo].[spctPActivitySelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [ttpisg220200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2002002].[t_desc] AS ttpisg2002002_t_desc 
  FROM [ttpisg220200] 
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg200200] AS [ttpisg2002002]
    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]
    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [ttpisg220200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttpisg220200].[t_cprj] END DESC,
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
     CASE @OrderBy WHEN 't_schd' THEN [ttpisg220200].[t_schd] END,
     CASE @OrderBy WHEN 't_schd DESC' THEN [ttpisg220200].[t_schd] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg220200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg220200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg220200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg220200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_dura' THEN [ttpisg220200].[t_dura] END,
     CASE @OrderBy WHEN 't_dura DESC' THEN [ttpisg220200].[t_dura] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg220200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg220200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_bcod' THEN [ttpisg220200].[t_bcod] END,
     CASE @OrderBy WHEN 't_bcod DESC' THEN [ttpisg220200].[t_bcod] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg220200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg220200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg220200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg220200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg220200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg220200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg220200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg220200].[t_succ] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects1_Description' THEN [IDM_Projects1].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects1_Description DESC' THEN [IDM_Projects1].[Description] END DESC,
     CASE @OrderBy WHEN 'ttpisg2002002_t_desc' THEN [ttpisg2002002].[t_desc] END,
     CASE @OrderBy WHEN 'ttpisg2002002_t_desc DESC' THEN [ttpisg2002002].[t_desc] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivityAutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivityAutoCompleteList]
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
  SET @LGSQL = @LGSQL + ' [ttpisg220200].[t_iref]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cprj]' 
  SET @LGSQL = @LGSQL + ',[ttpisg220200].[t_cact]' 
  SET @LGSQL = @LGSQL + ' FROM [ttpisg220200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([ttpisg220200].[t_cprj],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_cact],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([ttpisg220200].[t_iref],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivitySelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivitySelectByID]
GO
 
CREATE PROCEDURE [dbo].[spctPActivitySelectByID]
  @LoginID NVarChar(8),
  @t_cprj NVarChar(6),
  @t_cact VarChar(30) 
  AS
  SELECT
    [ttpisg220200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2002002].[t_desc] AS ttpisg2002002_t_desc 
  FROM [ttpisg220200] 
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg200200] AS [ttpisg2002002]
    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]
    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]
  WHERE
  [ttpisg220200].[t_cprj] = @t_cprj
  AND [ttpisg220200].[t_cact] = @t_cact
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivitySelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivitySelectListSearch]
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
 ,t_cprj NVarChar(6) NOT NULL
 ,t_cact VarChar(30) NOT NULL
  )
  INSERT INTO #PageIndex (t_cprj, t_cact)
  SELECT [ttpisg220200].[t_cprj], [ttpisg220200].[t_cact] FROM [ttpisg220200]
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg200200] AS [ttpisg2002002]
    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]
    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg220200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_cact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pcod],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_iref],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_schd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pred],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bohd],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_dura], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_pact],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_bcod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_actp], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg220200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg220200].[t_succ],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [ttpisg220200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttpisg220200].[t_cprj] END DESC,
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
     CASE @OrderBy WHEN 't_schd' THEN [ttpisg220200].[t_schd] END,
     CASE @OrderBy WHEN 't_schd DESC' THEN [ttpisg220200].[t_schd] END DESC,
     CASE @OrderBy WHEN 't_pred' THEN [ttpisg220200].[t_pred] END,
     CASE @OrderBy WHEN 't_pred DESC' THEN [ttpisg220200].[t_pred] END DESC,
     CASE @OrderBy WHEN 't_bohd' THEN [ttpisg220200].[t_bohd] END,
     CASE @OrderBy WHEN 't_bohd DESC' THEN [ttpisg220200].[t_bohd] END DESC,
     CASE @OrderBy WHEN 't_dura' THEN [ttpisg220200].[t_dura] END,
     CASE @OrderBy WHEN 't_dura DESC' THEN [ttpisg220200].[t_dura] END DESC,
     CASE @OrderBy WHEN 't_pact' THEN [ttpisg220200].[t_pact] END,
     CASE @OrderBy WHEN 't_pact DESC' THEN [ttpisg220200].[t_pact] END DESC,
     CASE @OrderBy WHEN 't_bcod' THEN [ttpisg220200].[t_bcod] END,
     CASE @OrderBy WHEN 't_bcod DESC' THEN [ttpisg220200].[t_bcod] END DESC,
     CASE @OrderBy WHEN 't_actp' THEN [ttpisg220200].[t_actp] END,
     CASE @OrderBy WHEN 't_actp DESC' THEN [ttpisg220200].[t_actp] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg220200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg220200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg220200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg220200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_succ' THEN [ttpisg220200].[t_succ] END,
     CASE @OrderBy WHEN 't_succ DESC' THEN [ttpisg220200].[t_succ] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects1_Description' THEN [IDM_Projects1].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects1_Description DESC' THEN [IDM_Projects1].[Description] END DESC,
     CASE @OrderBy WHEN 'ttpisg2002002_t_desc' THEN [ttpisg2002002].[t_desc] END,
     CASE @OrderBy WHEN 'ttpisg2002002_t_desc DESC' THEN [ttpisg2002002].[t_desc] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2002002].[t_desc] AS ttpisg2002002_t_desc 
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg200200] AS [ttpisg2002002]
    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]
    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivitySelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivitySelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spctPActivitySelectListFilteres]
  @Filter_t_cprj NVarChar(6),
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
 ,t_cprj NVarChar(6) NOT NULL
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
  SET @LGSQL = @LGSQL + '  INNER JOIN [IDM_Projects] AS [IDM_Projects1]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ttpisg200200] AS [ttpisg2002002]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]'
  SET @LGSQL = @LGSQL + '    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_cprj > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_cprj] = ''' + @Filter_t_cprj + ''''
  IF (@Filter_t_cact > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg220200].[t_cact] = ''' + @Filter_t_cact + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprj' THEN '[ttpisg220200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttpisg220200].[t_cprj] DESC'
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
                        WHEN 't_schd' THEN '[ttpisg220200].[t_schd]'
                        WHEN 't_schd DESC' THEN '[ttpisg220200].[t_schd] DESC'
                        WHEN 't_pred' THEN '[ttpisg220200].[t_pred]'
                        WHEN 't_pred DESC' THEN '[ttpisg220200].[t_pred] DESC'
                        WHEN 't_bohd' THEN '[ttpisg220200].[t_bohd]'
                        WHEN 't_bohd DESC' THEN '[ttpisg220200].[t_bohd] DESC'
                        WHEN 't_dura' THEN '[ttpisg220200].[t_dura]'
                        WHEN 't_dura DESC' THEN '[ttpisg220200].[t_dura] DESC'
                        WHEN 't_pact' THEN '[ttpisg220200].[t_pact]'
                        WHEN 't_pact DESC' THEN '[ttpisg220200].[t_pact] DESC'
                        WHEN 't_bcod' THEN '[ttpisg220200].[t_bcod]'
                        WHEN 't_bcod DESC' THEN '[ttpisg220200].[t_bcod] DESC'
                        WHEN 't_actp' THEN '[ttpisg220200].[t_actp]'
                        WHEN 't_actp DESC' THEN '[ttpisg220200].[t_actp] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg220200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg220200].[t_Refcntu] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg220200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg220200].[t_Refcntd] DESC'
                        WHEN 't_succ' THEN '[ttpisg220200].[t_succ]'
                        WHEN 't_succ DESC' THEN '[ttpisg220200].[t_succ] DESC'
                        WHEN 'IDM_Projects1_Description' THEN '[IDM_Projects1].[Description]'
                        WHEN 'IDM_Projects1_Description DESC' THEN '[IDM_Projects1].[Description] DESC'
                        WHEN 'ttpisg2002002_t_desc' THEN '[ttpisg2002002].[t_desc]'
                        WHEN 'ttpisg2002002_t_desc DESC' THEN '[ttpisg2002002].[t_desc] DESC'
                        ELSE '[ttpisg220200].[t_cprj],[ttpisg220200].[t_cact]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg220200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2002002].[t_desc] AS ttpisg2002002_t_desc 
  FROM [ttpisg220200] 
      INNER JOIN #PageIndex
          ON [ttpisg220200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg220200].[t_cact] = #PageIndex.t_cact
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg220200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg200200] AS [ttpisg2002002]
    ON [ttpisg220200].[t_pcod] = [ttpisg2002002].[t_cprd]
    AND [ttpisg220200].[t_cact] = [ttpisg2002002].[t_cact]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPActivityUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPActivityUpdate]
GO
 
CREATE PROCEDURE [dbo].[spctPActivityUpdate]
  @Original_t_cprj NVarChar(6), 
  @Original_t_cact VarChar(30), 
  @t_cprj NVarChar(6),
  @t_cact VarChar(30),
  @t_pcod VarChar(9),
  @t_sdst DateTime,
  @t_sdfn DateTime,
  @t_acsd DateTime,
  @t_acfn DateTime,
  @t_iref VarChar(50),
  @t_schd Int,
  @t_pred VarChar(200),
  @t_bohd VarChar(20),
  @t_dura Int,
  @t_pact VarChar(30),
  @t_bcod VarChar(9),
  @t_actp Int,
  @t_Refcntu Int,
  @t_Refcntd Int,
  @t_succ VarChar(200),
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttpisg220200] SET 
   [t_cprj] = @t_cprj
  ,[t_cact] = @t_cact
  ,[t_pcod] = @t_pcod
  ,[t_sdst] = @t_sdst
  ,[t_sdfn] = @t_sdfn
  ,[t_acsd] = @t_acsd
  ,[t_acfn] = @t_acfn
  ,[t_iref] = @t_iref
  ,[t_schd] = @t_schd
  ,[t_pred] = @t_pred
  ,[t_bohd] = @t_bohd
  ,[t_dura] = @t_dura
  ,[t_pact] = @t_pact
  ,[t_bcod] = @t_bcod
  ,[t_actp] = @t_actp
  ,[t_Refcntu] = @t_Refcntu
  ,[t_Refcntd] = @t_Refcntd
  ,[t_succ] = @t_succ
  WHERE
  [t_cprj] = @Original_t_cprj
  AND [t_cact] = @Original_t_cact
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivitySelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivitySelectByID]
GO
 
CREATE PROCEDURE [dbo].[spctPUActivitySelectByID]
  @LoginID NVarChar(8),
  @t_cprj NVarChar(6),
  @t_atid VarChar(30),
  @t_srno Int 
  AS
  SELECT
    [ttpisg183200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2202002].[t_iref] AS ttpisg2202002_t_iref 
  FROM [ttpisg183200] 
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg183200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
  WHERE
  [ttpisg183200].[t_cprj] = @t_cprj
  AND [ttpisg183200].[t_atid] = @t_atid
  AND [ttpisg183200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivitySelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivitySelectListSearch]
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
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg183200].[t_cprj] = [IDM_Projects1].[ProjectID]
  INNER JOIN [ttpisg220200] AS [ttpisg2202002]
    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]
    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]
 WHERE  
   ( 
         STR(ISNULL([ttpisg183200].[t_srno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_puom],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_tpgv], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_crby],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps3],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps2],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps1],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg183200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_atid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg183200].[t_gps4],'')) LIKE @KeyWord1
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
     CASE @OrderBy WHEN 't_gps4' THEN [ttpisg183200].[t_gps4] END,
     CASE @OrderBy WHEN 't_gps4 DESC' THEN [ttpisg183200].[t_gps4] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg183200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg183200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_gps3' THEN [ttpisg183200].[t_gps3] END,
     CASE @OrderBy WHEN 't_gps3 DESC' THEN [ttpisg183200].[t_gps3] END DESC,
     CASE @OrderBy WHEN 't_crby' THEN [ttpisg183200].[t_crby] END,
     CASE @OrderBy WHEN 't_crby DESC' THEN [ttpisg183200].[t_crby] END DESC,
     CASE @OrderBy WHEN 't_gps1' THEN [ttpisg183200].[t_gps1] END,
     CASE @OrderBy WHEN 't_gps1 DESC' THEN [ttpisg183200].[t_gps1] END DESC,
     CASE @OrderBy WHEN 't_cron' THEN [ttpisg183200].[t_cron] END,
     CASE @OrderBy WHEN 't_cron DESC' THEN [ttpisg183200].[t_cron] END DESC,
     CASE @OrderBy WHEN 't_gps2' THEN [ttpisg183200].[t_gps2] END,
     CASE @OrderBy WHEN 't_gps2 DESC' THEN [ttpisg183200].[t_gps2] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg183200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg183200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects1_Description' THEN [IDM_Projects1].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects1_Description DESC' THEN [IDM_Projects1].[Description] END DESC,
     CASE @OrderBy WHEN 'ttpisg2202002_t_iref' THEN [ttpisg2202002].[t_iref] END,
     CASE @OrderBy WHEN 'ttpisg2202002_t_iref DESC' THEN [ttpisg2202002].[t_iref] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg183200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2202002].[t_iref] AS ttpisg2202002_t_iref 
  FROM [ttpisg183200] 
      INNER JOIN #PageIndex
          ON [ttpisg183200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg183200].[t_atid] = #PageIndex.t_atid
          AND [ttpisg183200].[t_srno] = #PageIndex.t_srno
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg183200].[t_cprj] = [IDM_Projects1].[ProjectID]
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivitySelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivitySelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spctPUActivitySelectListFilteres]
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
  SET @LGSQL = @LGSQL + '  INNER JOIN [IDM_Projects] AS [IDM_Projects1]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg183200].[t_cprj] = [IDM_Projects1].[ProjectID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ttpisg220200] AS [ttpisg2202002]'
  SET @LGSQL = @LGSQL + '    ON [ttpisg183200].[t_cprj] = [ttpisg2202002].[t_cprj]'
  SET @LGSQL = @LGSQL + '    AND [ttpisg183200].[t_atid] = [ttpisg2202002].[t_cact]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
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
                        WHEN 't_gps4' THEN '[ttpisg183200].[t_gps4]'
                        WHEN 't_gps4 DESC' THEN '[ttpisg183200].[t_gps4] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg183200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg183200].[t_Refcntd] DESC'
                        WHEN 't_gps3' THEN '[ttpisg183200].[t_gps3]'
                        WHEN 't_gps3 DESC' THEN '[ttpisg183200].[t_gps3] DESC'
                        WHEN 't_crby' THEN '[ttpisg183200].[t_crby]'
                        WHEN 't_crby DESC' THEN '[ttpisg183200].[t_crby] DESC'
                        WHEN 't_gps1' THEN '[ttpisg183200].[t_gps1]'
                        WHEN 't_gps1 DESC' THEN '[ttpisg183200].[t_gps1] DESC'
                        WHEN 't_cron' THEN '[ttpisg183200].[t_cron]'
                        WHEN 't_cron DESC' THEN '[ttpisg183200].[t_cron] DESC'
                        WHEN 't_gps2' THEN '[ttpisg183200].[t_gps2]'
                        WHEN 't_gps2 DESC' THEN '[ttpisg183200].[t_gps2] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg183200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg183200].[t_Refcntu] DESC'
                        WHEN 'IDM_Projects1_Description' THEN '[IDM_Projects1].[Description]'
                        WHEN 'IDM_Projects1_Description DESC' THEN '[IDM_Projects1].[Description] DESC'
                        WHEN 'ttpisg2202002_t_iref' THEN '[ttpisg2202002].[t_iref]'
                        WHEN 'ttpisg2202002_t_iref DESC' THEN '[ttpisg2202002].[t_iref] DESC'
                        ELSE '[ttpisg183200].[t_cprj],[ttpisg183200].[t_atid],[ttpisg183200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg183200].* ,
    [IDM_Projects1].[Description] AS IDM_Projects1_Description,
    [ttpisg2202002].[t_iref] AS ttpisg2202002_t_iref 
  FROM [ttpisg183200] 
      INNER JOIN #PageIndex
          ON [ttpisg183200].[t_cprj] = #PageIndex.t_cprj
          AND [ttpisg183200].[t_atid] = #PageIndex.t_atid
          AND [ttpisg183200].[t_srno] = #PageIndex.t_srno
  INNER JOIN [IDM_Projects] AS [IDM_Projects1]
    ON [ttpisg183200].[t_cprj] = [IDM_Projects1].[ProjectID]
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivityInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivityInsert]
GO
 
CREATE PROCEDURE [dbo].[spctPUActivityInsert]
  @t_srno Int,
  @t_plsd DateTime,
  @t_plfd DateTime,
  @t_acsd DateTime,
  @t_aced DateTime,
  @t_puom VarChar(10),
  @t_tpgv Float,
  @t_crby VarChar(16),
  @t_gps3 VarChar(100),
  @t_Refcntu Int,
  @t_gps2 VarChar(100),
  @t_gps1 VarChar(100),
  @t_cron DateTime,
  @t_Refcntd Int,
  @t_otsd DateTime,
  @t_atid VarChar(30),
  @t_cprj NVarChar(6),
  @t_gps4 VarChar(100),
  @t_rmks VarChar(500),
  @t_oted DateTime,
  @Return_t_cprj NVarChar(6) = null OUTPUT, 
  @Return_t_atid VarChar(30) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  INSERT [ttpisg183200]
  (
   [t_srno]
  ,[t_plsd]
  ,[t_plfd]
  ,[t_acsd]
  ,[t_aced]
  ,[t_puom]
  ,[t_tpgv]
  ,[t_crby]
  ,[t_gps3]
  ,[t_Refcntu]
  ,[t_gps2]
  ,[t_gps1]
  ,[t_cron]
  ,[t_Refcntd]
  ,[t_otsd]
  ,[t_atid]
  ,[t_cprj]
  ,[t_gps4]
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
  ,@t_crby
  ,@t_gps3
  ,@t_Refcntu
  ,@t_gps2
  ,@t_gps1
  ,@t_cron
  ,@t_Refcntd
  ,@t_otsd
  ,UPPER(@t_atid)
  ,UPPER(@t_cprj)
  ,@t_gps4
  ,@t_rmks
  ,@t_oted
  )
  SET @Return_t_cprj = @t_cprj
  SET @Return_t_atid = @t_atid
  SET @Return_t_srno = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivityUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivityUpdate]
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
  @t_crby VarChar(16),
  @t_gps3 VarChar(100),
  @t_Refcntu Int,
  @t_gps2 VarChar(100),
  @t_gps1 VarChar(100),
  @t_cron DateTime,
  @t_Refcntd Int,
  @t_otsd DateTime,
  @t_atid VarChar(30),
  @t_cprj NVarChar(6),
  @t_gps4 VarChar(100),
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
  ,[t_crby] = @t_crby
  ,[t_gps3] = @t_gps3
  ,[t_Refcntu] = @t_Refcntu
  ,[t_gps2] = @t_gps2
  ,[t_gps1] = @t_gps1
  ,[t_cron] = @t_cron
  ,[t_Refcntd] = @t_Refcntd
  ,[t_otsd] = @t_otsd
  ,[t_atid] = @t_atid
  ,[t_cprj] = @t_cprj
  ,[t_gps4] = @t_gps4
  ,[t_rmks] = @t_rmks
  ,[t_oted] = @t_oted
  WHERE
  [t_cprj] = @Original_t_cprj
  AND [t_atid] = @Original_t_atid
  AND [t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spctPUActivityDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spctPUActivityDelete]
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

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
