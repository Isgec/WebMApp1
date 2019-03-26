SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg302SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg302SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg302SelectByID]
  @LoginID NVarChar(8),
  @t_ccod VarChar(9),
  @t_srno Int 
  AS
  SELECT
    [ttpisg302200].*  
  FROM [ttpisg302200] 
  WHERE
  [ttpisg302200].[t_ccod] = @t_ccod
  AND [ttpisg302200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg302SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg302SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg302SelectListSearch]
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_ccod, t_srno)
  SELECT [ttpisg302200].[t_ccod], [ttpisg302200].[t_srno] FROM [ttpisg302200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg302200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg302200].[t_paym],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_samt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_camt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_eamt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_srcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_crcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_ercd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg302200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg302200].[t_srno], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg302200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg302200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_paym' THEN [ttpisg302200].[t_paym] END,
     CASE @OrderBy WHEN 't_paym DESC' THEN [ttpisg302200].[t_paym] END DESC,
     CASE @OrderBy WHEN 't_samt' THEN [ttpisg302200].[t_samt] END,
     CASE @OrderBy WHEN 't_samt DESC' THEN [ttpisg302200].[t_samt] END DESC,
     CASE @OrderBy WHEN 't_camt' THEN [ttpisg302200].[t_camt] END,
     CASE @OrderBy WHEN 't_camt DESC' THEN [ttpisg302200].[t_camt] END DESC,
     CASE @OrderBy WHEN 't_eamt' THEN [ttpisg302200].[t_eamt] END,
     CASE @OrderBy WHEN 't_eamt DESC' THEN [ttpisg302200].[t_eamt] END DESC,
     CASE @OrderBy WHEN 't_srcd' THEN [ttpisg302200].[t_srcd] END,
     CASE @OrderBy WHEN 't_srcd DESC' THEN [ttpisg302200].[t_srcd] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttpisg302200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttpisg302200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ercd' THEN [ttpisg302200].[t_ercd] END,
     CASE @OrderBy WHEN 't_ercd DESC' THEN [ttpisg302200].[t_ercd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg302200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg302200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg302200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg302200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg302200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg302200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg302200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg302200].[t_updt] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg302200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg302200].[t_srno] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg302200].*  
  FROM [ttpisg302200] 
      INNER JOIN #PageIndex
          ON [ttpisg302200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg302200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg302SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg302SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg302SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_ccod'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg302200].[t_ccod]'
  SET @LGSQL = @LGSQL + ', [ttpisg302200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg302200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg302200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg302200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg302200].[t_user] DESC'
                        WHEN 't_paym' THEN '[ttpisg302200].[t_paym]'
                        WHEN 't_paym DESC' THEN '[ttpisg302200].[t_paym] DESC'
                        WHEN 't_samt' THEN '[ttpisg302200].[t_samt]'
                        WHEN 't_samt DESC' THEN '[ttpisg302200].[t_samt] DESC'
                        WHEN 't_camt' THEN '[ttpisg302200].[t_camt]'
                        WHEN 't_camt DESC' THEN '[ttpisg302200].[t_camt] DESC'
                        WHEN 't_eamt' THEN '[ttpisg302200].[t_eamt]'
                        WHEN 't_eamt DESC' THEN '[ttpisg302200].[t_eamt] DESC'
                        WHEN 't_srcd' THEN '[ttpisg302200].[t_srcd]'
                        WHEN 't_srcd DESC' THEN '[ttpisg302200].[t_srcd] DESC'
                        WHEN 't_crcd' THEN '[ttpisg302200].[t_crcd]'
                        WHEN 't_crcd DESC' THEN '[ttpisg302200].[t_crcd] DESC'
                        WHEN 't_ercd' THEN '[ttpisg302200].[t_ercd]'
                        WHEN 't_ercd DESC' THEN '[ttpisg302200].[t_ercd] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg302200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg302200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg302200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg302200].[t_Refcntu] DESC'
                        WHEN 't_ccod' THEN '[ttpisg302200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg302200].[t_ccod] DESC'
                        WHEN 't_updt' THEN '[ttpisg302200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg302200].[t_updt] DESC'
                        WHEN 't_srno' THEN '[ttpisg302200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg302200].[t_srno] DESC'
                        ELSE '[ttpisg302200].[t_ccod],[ttpisg302200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg302200].*  
  FROM [ttpisg302200] 
      INNER JOIN #PageIndex
          ON [ttpisg302200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg302200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg303SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg303SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg303SelectByID]
  @LoginID NVarChar(8),
  @t_ccod VarChar(9),
  @t_srno Int 
  AS
  SELECT
    [ttpisg303200].*  
  FROM [ttpisg303200] 
  WHERE
  [ttpisg303200].[t_ccod] = @t_ccod
  AND [ttpisg303200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg303SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg303SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg303SelectListSearch]
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_ccod, t_srno)
  SELECT [ttpisg303200].[t_ccod], [ttpisg303200].[t_srno] FROM [ttpisg303200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg303200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg303200].[t_paym],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_samt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_camt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_eamt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_srcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_crcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_ercd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg303200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg303200].[t_srno], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg303200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg303200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_paym' THEN [ttpisg303200].[t_paym] END,
     CASE @OrderBy WHEN 't_paym DESC' THEN [ttpisg303200].[t_paym] END DESC,
     CASE @OrderBy WHEN 't_samt' THEN [ttpisg303200].[t_samt] END,
     CASE @OrderBy WHEN 't_samt DESC' THEN [ttpisg303200].[t_samt] END DESC,
     CASE @OrderBy WHEN 't_camt' THEN [ttpisg303200].[t_camt] END,
     CASE @OrderBy WHEN 't_camt DESC' THEN [ttpisg303200].[t_camt] END DESC,
     CASE @OrderBy WHEN 't_eamt' THEN [ttpisg303200].[t_eamt] END,
     CASE @OrderBy WHEN 't_eamt DESC' THEN [ttpisg303200].[t_eamt] END DESC,
     CASE @OrderBy WHEN 't_srcd' THEN [ttpisg303200].[t_srcd] END,
     CASE @OrderBy WHEN 't_srcd DESC' THEN [ttpisg303200].[t_srcd] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttpisg303200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttpisg303200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ercd' THEN [ttpisg303200].[t_ercd] END,
     CASE @OrderBy WHEN 't_ercd DESC' THEN [ttpisg303200].[t_ercd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg303200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg303200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg303200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg303200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg303200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg303200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg303200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg303200].[t_updt] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg303200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg303200].[t_srno] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg303200].*  
  FROM [ttpisg303200] 
      INNER JOIN #PageIndex
          ON [ttpisg303200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg303200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg303SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg303SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg303SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_ccod'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg303200].[t_ccod]'
  SET @LGSQL = @LGSQL + ', [ttpisg303200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg303200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg303200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg303200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg303200].[t_user] DESC'
                        WHEN 't_paym' THEN '[ttpisg303200].[t_paym]'
                        WHEN 't_paym DESC' THEN '[ttpisg303200].[t_paym] DESC'
                        WHEN 't_samt' THEN '[ttpisg303200].[t_samt]'
                        WHEN 't_samt DESC' THEN '[ttpisg303200].[t_samt] DESC'
                        WHEN 't_camt' THEN '[ttpisg303200].[t_camt]'
                        WHEN 't_camt DESC' THEN '[ttpisg303200].[t_camt] DESC'
                        WHEN 't_eamt' THEN '[ttpisg303200].[t_eamt]'
                        WHEN 't_eamt DESC' THEN '[ttpisg303200].[t_eamt] DESC'
                        WHEN 't_srcd' THEN '[ttpisg303200].[t_srcd]'
                        WHEN 't_srcd DESC' THEN '[ttpisg303200].[t_srcd] DESC'
                        WHEN 't_crcd' THEN '[ttpisg303200].[t_crcd]'
                        WHEN 't_crcd DESC' THEN '[ttpisg303200].[t_crcd] DESC'
                        WHEN 't_ercd' THEN '[ttpisg303200].[t_ercd]'
                        WHEN 't_ercd DESC' THEN '[ttpisg303200].[t_ercd] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg303200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg303200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg303200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg303200].[t_Refcntu] DESC'
                        WHEN 't_ccod' THEN '[ttpisg303200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg303200].[t_ccod] DESC'
                        WHEN 't_updt' THEN '[ttpisg303200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg303200].[t_updt] DESC'
                        WHEN 't_srno' THEN '[ttpisg303200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg303200].[t_srno] DESC'
                        ELSE '[ttpisg303200].[t_ccod],[ttpisg303200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg303200].*  
  FROM [ttpisg303200] 
      INNER JOIN #PageIndex
          ON [ttpisg303200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg303200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg304SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg304SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg304SelectByID]
  @LoginID NVarChar(8),
  @t_ccod VarChar(9),
  @t_srno Int 
  AS
  SELECT
    [ttpisg304200].*  
  FROM [ttpisg304200] 
  WHERE
  [ttpisg304200].[t_ccod] = @t_ccod
  AND [ttpisg304200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg304SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg304SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg304SelectListSearch]
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_ccod, t_srno)
  SELECT [ttpisg304200].[t_ccod], [ttpisg304200].[t_srno] FROM [ttpisg304200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg304200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg304200].[t_paym],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_samt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_camt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_eamt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_srcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_crcd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_ercd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg304200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg304200].[t_srno], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg304200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg304200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_paym' THEN [ttpisg304200].[t_paym] END,
     CASE @OrderBy WHEN 't_paym DESC' THEN [ttpisg304200].[t_paym] END DESC,
     CASE @OrderBy WHEN 't_samt' THEN [ttpisg304200].[t_samt] END,
     CASE @OrderBy WHEN 't_samt DESC' THEN [ttpisg304200].[t_samt] END DESC,
     CASE @OrderBy WHEN 't_camt' THEN [ttpisg304200].[t_camt] END,
     CASE @OrderBy WHEN 't_camt DESC' THEN [ttpisg304200].[t_camt] END DESC,
     CASE @OrderBy WHEN 't_eamt' THEN [ttpisg304200].[t_eamt] END,
     CASE @OrderBy WHEN 't_eamt DESC' THEN [ttpisg304200].[t_eamt] END DESC,
     CASE @OrderBy WHEN 't_srcd' THEN [ttpisg304200].[t_srcd] END,
     CASE @OrderBy WHEN 't_srcd DESC' THEN [ttpisg304200].[t_srcd] END DESC,
     CASE @OrderBy WHEN 't_crcd' THEN [ttpisg304200].[t_crcd] END,
     CASE @OrderBy WHEN 't_crcd DESC' THEN [ttpisg304200].[t_crcd] END DESC,
     CASE @OrderBy WHEN 't_ercd' THEN [ttpisg304200].[t_ercd] END,
     CASE @OrderBy WHEN 't_ercd DESC' THEN [ttpisg304200].[t_ercd] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg304200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg304200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg304200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg304200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg304200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg304200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg304200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg304200].[t_updt] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttpisg304200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttpisg304200].[t_srno] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg304200].*  
  FROM [ttpisg304200] 
      INNER JOIN #PageIndex
          ON [ttpisg304200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg304200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg304SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg304SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg304SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_ccod VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_ccod'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg304200].[t_ccod]'
  SET @LGSQL = @LGSQL + ', [ttpisg304200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg304200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg304200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg304200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg304200].[t_user] DESC'
                        WHEN 't_paym' THEN '[ttpisg304200].[t_paym]'
                        WHEN 't_paym DESC' THEN '[ttpisg304200].[t_paym] DESC'
                        WHEN 't_samt' THEN '[ttpisg304200].[t_samt]'
                        WHEN 't_samt DESC' THEN '[ttpisg304200].[t_samt] DESC'
                        WHEN 't_camt' THEN '[ttpisg304200].[t_camt]'
                        WHEN 't_camt DESC' THEN '[ttpisg304200].[t_camt] DESC'
                        WHEN 't_eamt' THEN '[ttpisg304200].[t_eamt]'
                        WHEN 't_eamt DESC' THEN '[ttpisg304200].[t_eamt] DESC'
                        WHEN 't_srcd' THEN '[ttpisg304200].[t_srcd]'
                        WHEN 't_srcd DESC' THEN '[ttpisg304200].[t_srcd] DESC'
                        WHEN 't_crcd' THEN '[ttpisg304200].[t_crcd]'
                        WHEN 't_crcd DESC' THEN '[ttpisg304200].[t_crcd] DESC'
                        WHEN 't_ercd' THEN '[ttpisg304200].[t_ercd]'
                        WHEN 't_ercd DESC' THEN '[ttpisg304200].[t_ercd] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg304200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg304200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg304200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg304200].[t_Refcntu] DESC'
                        WHEN 't_ccod' THEN '[ttpisg304200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg304200].[t_ccod] DESC'
                        WHEN 't_updt' THEN '[ttpisg304200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg304200].[t_updt] DESC'
                        WHEN 't_srno' THEN '[ttpisg304200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttpisg304200].[t_srno] DESC'
                        ELSE '[ttpisg304200].[t_ccod],[ttpisg304200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg304200].*  
  FROM [ttpisg304200] 
      INNER JOIN #PageIndex
          ON [ttpisg304200].[t_ccod] = #PageIndex.t_ccod
          AND [ttpisg304200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg305SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg305SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg305SelectByID]
  @LoginID NVarChar(8),
  @t_csdc VarChar(100),
  @t_ccod VarChar(9) 
  AS
  SELECT
    [ttpisg305200].*  
  FROM [ttpisg305200] 
  WHERE
  [ttpisg305200].[t_csdc] = @t_csdc
  AND [ttpisg305200].[t_ccod] = @t_ccod
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg305SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg305SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg305SelectListSearch]
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_csdc, t_ccod)
  SELECT [ttpisg305200].[t_csdc], [ttpisg305200].[t_ccod] FROM [ttpisg305200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg305200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg305200].[t_csdc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_bdgd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_aled], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg305200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_cbda], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_cycn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_sson], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_stcs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_cysc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_coco], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg305200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg305200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg305200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_csdc' THEN [ttpisg305200].[t_csdc] END,
     CASE @OrderBy WHEN 't_csdc DESC' THEN [ttpisg305200].[t_csdc] END DESC,
     CASE @OrderBy WHEN 't_bdgd' THEN [ttpisg305200].[t_bdgd] END,
     CASE @OrderBy WHEN 't_bdgd DESC' THEN [ttpisg305200].[t_bdgd] END DESC,
     CASE @OrderBy WHEN 't_aled' THEN [ttpisg305200].[t_aled] END,
     CASE @OrderBy WHEN 't_aled DESC' THEN [ttpisg305200].[t_aled] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg305200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg305200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_cbda' THEN [ttpisg305200].[t_cbda] END,
     CASE @OrderBy WHEN 't_cbda DESC' THEN [ttpisg305200].[t_cbda] END DESC,
     CASE @OrderBy WHEN 't_cycn' THEN [ttpisg305200].[t_cycn] END,
     CASE @OrderBy WHEN 't_cycn DESC' THEN [ttpisg305200].[t_cycn] END DESC,
     CASE @OrderBy WHEN 't_sson' THEN [ttpisg305200].[t_sson] END,
     CASE @OrderBy WHEN 't_sson DESC' THEN [ttpisg305200].[t_sson] END DESC,
     CASE @OrderBy WHEN 't_stcs' THEN [ttpisg305200].[t_stcs] END,
     CASE @OrderBy WHEN 't_stcs DESC' THEN [ttpisg305200].[t_stcs] END DESC,
     CASE @OrderBy WHEN 't_cysc' THEN [ttpisg305200].[t_cysc] END,
     CASE @OrderBy WHEN 't_cysc DESC' THEN [ttpisg305200].[t_cysc] END DESC,
     CASE @OrderBy WHEN 't_coco' THEN [ttpisg305200].[t_coco] END,
     CASE @OrderBy WHEN 't_coco DESC' THEN [ttpisg305200].[t_coco] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg305200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg305200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg305200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg305200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg305200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg305200].[t_updt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg305200].*  
  FROM [ttpisg305200] 
      INNER JOIN #PageIndex
          ON [ttpisg305200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg305200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg305SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg305SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg305SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_csdc'
  SET @LGSQL = @LGSQL + ', t_ccod'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg305200].[t_csdc]'
  SET @LGSQL = @LGSQL + ', [ttpisg305200].[t_ccod]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg305200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg305200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg305200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg305200].[t_user] DESC'
                        WHEN 't_csdc' THEN '[ttpisg305200].[t_csdc]'
                        WHEN 't_csdc DESC' THEN '[ttpisg305200].[t_csdc] DESC'
                        WHEN 't_bdgd' THEN '[ttpisg305200].[t_bdgd]'
                        WHEN 't_bdgd DESC' THEN '[ttpisg305200].[t_bdgd] DESC'
                        WHEN 't_aled' THEN '[ttpisg305200].[t_aled]'
                        WHEN 't_aled DESC' THEN '[ttpisg305200].[t_aled] DESC'
                        WHEN 't_ccod' THEN '[ttpisg305200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg305200].[t_ccod] DESC'
                        WHEN 't_cbda' THEN '[ttpisg305200].[t_cbda]'
                        WHEN 't_cbda DESC' THEN '[ttpisg305200].[t_cbda] DESC'
                        WHEN 't_cycn' THEN '[ttpisg305200].[t_cycn]'
                        WHEN 't_cycn DESC' THEN '[ttpisg305200].[t_cycn] DESC'
                        WHEN 't_sson' THEN '[ttpisg305200].[t_sson]'
                        WHEN 't_sson DESC' THEN '[ttpisg305200].[t_sson] DESC'
                        WHEN 't_stcs' THEN '[ttpisg305200].[t_stcs]'
                        WHEN 't_stcs DESC' THEN '[ttpisg305200].[t_stcs] DESC'
                        WHEN 't_cysc' THEN '[ttpisg305200].[t_cysc]'
                        WHEN 't_cysc DESC' THEN '[ttpisg305200].[t_cysc] DESC'
                        WHEN 't_coco' THEN '[ttpisg305200].[t_coco]'
                        WHEN 't_coco DESC' THEN '[ttpisg305200].[t_coco] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg305200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg305200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg305200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg305200].[t_Refcntu] DESC'
                        WHEN 't_updt' THEN '[ttpisg305200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg305200].[t_updt] DESC'
                        ELSE '[ttpisg305200].[t_csdc],[ttpisg305200].[t_ccod]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg305200].*  
  FROM [ttpisg305200] 
      INNER JOIN #PageIndex
          ON [ttpisg305200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg305200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg306SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg306SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg306SelectByID]
  @LoginID NVarChar(8),
  @t_csdc VarChar(100),
  @t_ccod VarChar(9) 
  AS
  SELECT
    [ttpisg306200].*  
  FROM [ttpisg306200] 
  WHERE
  [ttpisg306200].[t_csdc] = @t_csdc
  AND [ttpisg306200].[t_ccod] = @t_ccod
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg306SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg306SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg306SelectListSearch]
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_csdc, t_ccod)
  SELECT [ttpisg306200].[t_csdc], [ttpisg306200].[t_ccod] FROM [ttpisg306200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg306200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg306200].[t_csdc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_bdgd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_aled], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg306200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_cbda], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_cycn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_sson], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_stcs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_cysc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_coco], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg306200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg306200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg306200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_csdc' THEN [ttpisg306200].[t_csdc] END,
     CASE @OrderBy WHEN 't_csdc DESC' THEN [ttpisg306200].[t_csdc] END DESC,
     CASE @OrderBy WHEN 't_bdgd' THEN [ttpisg306200].[t_bdgd] END,
     CASE @OrderBy WHEN 't_bdgd DESC' THEN [ttpisg306200].[t_bdgd] END DESC,
     CASE @OrderBy WHEN 't_aled' THEN [ttpisg306200].[t_aled] END,
     CASE @OrderBy WHEN 't_aled DESC' THEN [ttpisg306200].[t_aled] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg306200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg306200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_cbda' THEN [ttpisg306200].[t_cbda] END,
     CASE @OrderBy WHEN 't_cbda DESC' THEN [ttpisg306200].[t_cbda] END DESC,
     CASE @OrderBy WHEN 't_cycn' THEN [ttpisg306200].[t_cycn] END,
     CASE @OrderBy WHEN 't_cycn DESC' THEN [ttpisg306200].[t_cycn] END DESC,
     CASE @OrderBy WHEN 't_sson' THEN [ttpisg306200].[t_sson] END,
     CASE @OrderBy WHEN 't_sson DESC' THEN [ttpisg306200].[t_sson] END DESC,
     CASE @OrderBy WHEN 't_stcs' THEN [ttpisg306200].[t_stcs] END,
     CASE @OrderBy WHEN 't_stcs DESC' THEN [ttpisg306200].[t_stcs] END DESC,
     CASE @OrderBy WHEN 't_cysc' THEN [ttpisg306200].[t_cysc] END,
     CASE @OrderBy WHEN 't_cysc DESC' THEN [ttpisg306200].[t_cysc] END DESC,
     CASE @OrderBy WHEN 't_coco' THEN [ttpisg306200].[t_coco] END,
     CASE @OrderBy WHEN 't_coco DESC' THEN [ttpisg306200].[t_coco] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg306200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg306200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg306200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg306200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg306200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg306200].[t_updt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg306200].*  
  FROM [ttpisg306200] 
      INNER JOIN #PageIndex
          ON [ttpisg306200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg306200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg306SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg306SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg306SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_csdc'
  SET @LGSQL = @LGSQL + ', t_ccod'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg306200].[t_csdc]'
  SET @LGSQL = @LGSQL + ', [ttpisg306200].[t_ccod]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg306200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg306200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg306200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg306200].[t_user] DESC'
                        WHEN 't_csdc' THEN '[ttpisg306200].[t_csdc]'
                        WHEN 't_csdc DESC' THEN '[ttpisg306200].[t_csdc] DESC'
                        WHEN 't_bdgd' THEN '[ttpisg306200].[t_bdgd]'
                        WHEN 't_bdgd DESC' THEN '[ttpisg306200].[t_bdgd] DESC'
                        WHEN 't_aled' THEN '[ttpisg306200].[t_aled]'
                        WHEN 't_aled DESC' THEN '[ttpisg306200].[t_aled] DESC'
                        WHEN 't_ccod' THEN '[ttpisg306200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg306200].[t_ccod] DESC'
                        WHEN 't_cbda' THEN '[ttpisg306200].[t_cbda]'
                        WHEN 't_cbda DESC' THEN '[ttpisg306200].[t_cbda] DESC'
                        WHEN 't_cycn' THEN '[ttpisg306200].[t_cycn]'
                        WHEN 't_cycn DESC' THEN '[ttpisg306200].[t_cycn] DESC'
                        WHEN 't_sson' THEN '[ttpisg306200].[t_sson]'
                        WHEN 't_sson DESC' THEN '[ttpisg306200].[t_sson] DESC'
                        WHEN 't_stcs' THEN '[ttpisg306200].[t_stcs]'
                        WHEN 't_stcs DESC' THEN '[ttpisg306200].[t_stcs] DESC'
                        WHEN 't_cysc' THEN '[ttpisg306200].[t_cysc]'
                        WHEN 't_cysc DESC' THEN '[ttpisg306200].[t_cysc] DESC'
                        WHEN 't_coco' THEN '[ttpisg306200].[t_coco]'
                        WHEN 't_coco DESC' THEN '[ttpisg306200].[t_coco] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg306200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg306200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg306200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg306200].[t_Refcntu] DESC'
                        WHEN 't_updt' THEN '[ttpisg306200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg306200].[t_updt] DESC'
                        ELSE '[ttpisg306200].[t_csdc],[ttpisg306200].[t_ccod]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg306200].*  
  FROM [ttpisg306200] 
      INNER JOIN #PageIndex
          ON [ttpisg306200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg306200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg307SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg307SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg307SelectByID]
  @LoginID NVarChar(8),
  @t_csdc VarChar(100),
  @t_ccod VarChar(9) 
  AS
  SELECT
    [ttpisg307200].*  
  FROM [ttpisg307200] 
  WHERE
  [ttpisg307200].[t_csdc] = @t_csdc
  AND [ttpisg307200].[t_ccod] = @t_ccod
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg307SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg307SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg307SelectListSearch]
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_csdc, t_ccod)
  SELECT [ttpisg307200].[t_csdc], [ttpisg307200].[t_ccod] FROM [ttpisg307200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg307200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg307200].[t_csdc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_bdgd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_aled], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg307200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_cbda], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_cycn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_sson], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_stcs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_cysc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_coco], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg307200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg307200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg307200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_csdc' THEN [ttpisg307200].[t_csdc] END,
     CASE @OrderBy WHEN 't_csdc DESC' THEN [ttpisg307200].[t_csdc] END DESC,
     CASE @OrderBy WHEN 't_bdgd' THEN [ttpisg307200].[t_bdgd] END,
     CASE @OrderBy WHEN 't_bdgd DESC' THEN [ttpisg307200].[t_bdgd] END DESC,
     CASE @OrderBy WHEN 't_aled' THEN [ttpisg307200].[t_aled] END,
     CASE @OrderBy WHEN 't_aled DESC' THEN [ttpisg307200].[t_aled] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg307200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg307200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_cbda' THEN [ttpisg307200].[t_cbda] END,
     CASE @OrderBy WHEN 't_cbda DESC' THEN [ttpisg307200].[t_cbda] END DESC,
     CASE @OrderBy WHEN 't_cycn' THEN [ttpisg307200].[t_cycn] END,
     CASE @OrderBy WHEN 't_cycn DESC' THEN [ttpisg307200].[t_cycn] END DESC,
     CASE @OrderBy WHEN 't_sson' THEN [ttpisg307200].[t_sson] END,
     CASE @OrderBy WHEN 't_sson DESC' THEN [ttpisg307200].[t_sson] END DESC,
     CASE @OrderBy WHEN 't_stcs' THEN [ttpisg307200].[t_stcs] END,
     CASE @OrderBy WHEN 't_stcs DESC' THEN [ttpisg307200].[t_stcs] END DESC,
     CASE @OrderBy WHEN 't_cysc' THEN [ttpisg307200].[t_cysc] END,
     CASE @OrderBy WHEN 't_cysc DESC' THEN [ttpisg307200].[t_cysc] END DESC,
     CASE @OrderBy WHEN 't_coco' THEN [ttpisg307200].[t_coco] END,
     CASE @OrderBy WHEN 't_coco DESC' THEN [ttpisg307200].[t_coco] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg307200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg307200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg307200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg307200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg307200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg307200].[t_updt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg307200].*  
  FROM [ttpisg307200] 
      INNER JOIN #PageIndex
          ON [ttpisg307200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg307200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg307SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg307SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg307SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_csdc'
  SET @LGSQL = @LGSQL + ', t_ccod'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg307200].[t_csdc]'
  SET @LGSQL = @LGSQL + ', [ttpisg307200].[t_ccod]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg307200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg307200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg307200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg307200].[t_user] DESC'
                        WHEN 't_csdc' THEN '[ttpisg307200].[t_csdc]'
                        WHEN 't_csdc DESC' THEN '[ttpisg307200].[t_csdc] DESC'
                        WHEN 't_bdgd' THEN '[ttpisg307200].[t_bdgd]'
                        WHEN 't_bdgd DESC' THEN '[ttpisg307200].[t_bdgd] DESC'
                        WHEN 't_aled' THEN '[ttpisg307200].[t_aled]'
                        WHEN 't_aled DESC' THEN '[ttpisg307200].[t_aled] DESC'
                        WHEN 't_ccod' THEN '[ttpisg307200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg307200].[t_ccod] DESC'
                        WHEN 't_cbda' THEN '[ttpisg307200].[t_cbda]'
                        WHEN 't_cbda DESC' THEN '[ttpisg307200].[t_cbda] DESC'
                        WHEN 't_cycn' THEN '[ttpisg307200].[t_cycn]'
                        WHEN 't_cycn DESC' THEN '[ttpisg307200].[t_cycn] DESC'
                        WHEN 't_sson' THEN '[ttpisg307200].[t_sson]'
                        WHEN 't_sson DESC' THEN '[ttpisg307200].[t_sson] DESC'
                        WHEN 't_stcs' THEN '[ttpisg307200].[t_stcs]'
                        WHEN 't_stcs DESC' THEN '[ttpisg307200].[t_stcs] DESC'
                        WHEN 't_cysc' THEN '[ttpisg307200].[t_cysc]'
                        WHEN 't_cysc DESC' THEN '[ttpisg307200].[t_cysc] DESC'
                        WHEN 't_coco' THEN '[ttpisg307200].[t_coco]'
                        WHEN 't_coco DESC' THEN '[ttpisg307200].[t_coco] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg307200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg307200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg307200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg307200].[t_Refcntu] DESC'
                        WHEN 't_updt' THEN '[ttpisg307200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg307200].[t_updt] DESC'
                        ELSE '[ttpisg307200].[t_csdc],[ttpisg307200].[t_ccod]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg307200].*  
  FROM [ttpisg307200] 
      INNER JOIN #PageIndex
          ON [ttpisg307200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg307200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg308SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg308SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg308SelectByID]
  @LoginID NVarChar(8),
  @t_csdc VarChar(100),
  @t_ccod VarChar(9) 
  AS
  SELECT
    [ttpisg308200].*  
  FROM [ttpisg308200] 
  WHERE
  [ttpisg308200].[t_csdc] = @t_csdc
  AND [ttpisg308200].[t_ccod] = @t_ccod
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg308SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg308SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg308SelectListSearch]
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_csdc, t_ccod)
  SELECT [ttpisg308200].[t_csdc], [ttpisg308200].[t_ccod] FROM [ttpisg308200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg308200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg308200].[t_csdc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_bdgd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_aled], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg308200].[t_ccod],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_cbda], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_cycn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_sson], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_stcs], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_cysc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_coco], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg308200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg308200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg308200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_csdc' THEN [ttpisg308200].[t_csdc] END,
     CASE @OrderBy WHEN 't_csdc DESC' THEN [ttpisg308200].[t_csdc] END DESC,
     CASE @OrderBy WHEN 't_bdgd' THEN [ttpisg308200].[t_bdgd] END,
     CASE @OrderBy WHEN 't_bdgd DESC' THEN [ttpisg308200].[t_bdgd] END DESC,
     CASE @OrderBy WHEN 't_aled' THEN [ttpisg308200].[t_aled] END,
     CASE @OrderBy WHEN 't_aled DESC' THEN [ttpisg308200].[t_aled] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg308200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg308200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_cbda' THEN [ttpisg308200].[t_cbda] END,
     CASE @OrderBy WHEN 't_cbda DESC' THEN [ttpisg308200].[t_cbda] END DESC,
     CASE @OrderBy WHEN 't_cycn' THEN [ttpisg308200].[t_cycn] END,
     CASE @OrderBy WHEN 't_cycn DESC' THEN [ttpisg308200].[t_cycn] END DESC,
     CASE @OrderBy WHEN 't_sson' THEN [ttpisg308200].[t_sson] END,
     CASE @OrderBy WHEN 't_sson DESC' THEN [ttpisg308200].[t_sson] END DESC,
     CASE @OrderBy WHEN 't_stcs' THEN [ttpisg308200].[t_stcs] END,
     CASE @OrderBy WHEN 't_stcs DESC' THEN [ttpisg308200].[t_stcs] END DESC,
     CASE @OrderBy WHEN 't_cysc' THEN [ttpisg308200].[t_cysc] END,
     CASE @OrderBy WHEN 't_cysc DESC' THEN [ttpisg308200].[t_cysc] END DESC,
     CASE @OrderBy WHEN 't_coco' THEN [ttpisg308200].[t_coco] END,
     CASE @OrderBy WHEN 't_coco DESC' THEN [ttpisg308200].[t_coco] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg308200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg308200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg308200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg308200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg308200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg308200].[t_updt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg308200].*  
  FROM [ttpisg308200] 
      INNER JOIN #PageIndex
          ON [ttpisg308200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg308200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg308SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg308SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg308SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_csdc VarChar(100) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_csdc'
  SET @LGSQL = @LGSQL + ', t_ccod'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg308200].[t_csdc]'
  SET @LGSQL = @LGSQL + ', [ttpisg308200].[t_ccod]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg308200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg308200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg308200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg308200].[t_user] DESC'
                        WHEN 't_csdc' THEN '[ttpisg308200].[t_csdc]'
                        WHEN 't_csdc DESC' THEN '[ttpisg308200].[t_csdc] DESC'
                        WHEN 't_bdgd' THEN '[ttpisg308200].[t_bdgd]'
                        WHEN 't_bdgd DESC' THEN '[ttpisg308200].[t_bdgd] DESC'
                        WHEN 't_aled' THEN '[ttpisg308200].[t_aled]'
                        WHEN 't_aled DESC' THEN '[ttpisg308200].[t_aled] DESC'
                        WHEN 't_ccod' THEN '[ttpisg308200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg308200].[t_ccod] DESC'
                        WHEN 't_cbda' THEN '[ttpisg308200].[t_cbda]'
                        WHEN 't_cbda DESC' THEN '[ttpisg308200].[t_cbda] DESC'
                        WHEN 't_cycn' THEN '[ttpisg308200].[t_cycn]'
                        WHEN 't_cycn DESC' THEN '[ttpisg308200].[t_cycn] DESC'
                        WHEN 't_sson' THEN '[ttpisg308200].[t_sson]'
                        WHEN 't_sson DESC' THEN '[ttpisg308200].[t_sson] DESC'
                        WHEN 't_stcs' THEN '[ttpisg308200].[t_stcs]'
                        WHEN 't_stcs DESC' THEN '[ttpisg308200].[t_stcs] DESC'
                        WHEN 't_cysc' THEN '[ttpisg308200].[t_cysc]'
                        WHEN 't_cysc DESC' THEN '[ttpisg308200].[t_cysc] DESC'
                        WHEN 't_coco' THEN '[ttpisg308200].[t_coco]'
                        WHEN 't_coco DESC' THEN '[ttpisg308200].[t_coco] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg308200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg308200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg308200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg308200].[t_Refcntu] DESC'
                        WHEN 't_updt' THEN '[ttpisg308200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg308200].[t_updt] DESC'
                        ELSE '[ttpisg308200].[t_csdc],[ttpisg308200].[t_ccod]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg308200].*  
  FROM [ttpisg308200] 
      INNER JOIN #PageIndex
          ON [ttpisg308200].[t_csdc] = #PageIndex.t_csdc
          AND [ttpisg308200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg309SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg309SelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptpisg309SelectByID]
  @LoginID NVarChar(8),
  @t_mnyr VarChar(20),
  @t_ccod VarChar(9) 
  AS
  SELECT
    [ttpisg309200].*  
  FROM [ttpisg309200] 
  WHERE
  [ttpisg309200].[t_mnyr] = @t_mnyr
  AND [ttpisg309200].[t_ccod] = @t_ccod
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg309SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg309SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptpisg309SelectListSearch]
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
 ,t_mnyr VarChar(20) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_mnyr, t_ccod)
  SELECT [ttpisg309200].[t_mnyr], [ttpisg309200].[t_ccod] FROM [ttpisg309200]
 WHERE  
   ( 
         LOWER(ISNULL([ttpisg309200].[t_user],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg309200].[t_mnyr],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_sybd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_syac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_syvr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_erbd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_erac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_ervr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_clbd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_clac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_clvr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_debd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_deac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_devr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_osbd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_osac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_osvr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_tlbd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_tlac], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_tlvr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttpisg309200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttpisg309200].[t_ccod],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_user' THEN [ttpisg309200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [ttpisg309200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_mnyr' THEN [ttpisg309200].[t_mnyr] END,
     CASE @OrderBy WHEN 't_mnyr DESC' THEN [ttpisg309200].[t_mnyr] END DESC,
     CASE @OrderBy WHEN 't_sybd' THEN [ttpisg309200].[t_sybd] END,
     CASE @OrderBy WHEN 't_sybd DESC' THEN [ttpisg309200].[t_sybd] END DESC,
     CASE @OrderBy WHEN 't_syac' THEN [ttpisg309200].[t_syac] END,
     CASE @OrderBy WHEN 't_syac DESC' THEN [ttpisg309200].[t_syac] END DESC,
     CASE @OrderBy WHEN 't_syvr' THEN [ttpisg309200].[t_syvr] END,
     CASE @OrderBy WHEN 't_syvr DESC' THEN [ttpisg309200].[t_syvr] END DESC,
     CASE @OrderBy WHEN 't_erbd' THEN [ttpisg309200].[t_erbd] END,
     CASE @OrderBy WHEN 't_erbd DESC' THEN [ttpisg309200].[t_erbd] END DESC,
     CASE @OrderBy WHEN 't_erac' THEN [ttpisg309200].[t_erac] END,
     CASE @OrderBy WHEN 't_erac DESC' THEN [ttpisg309200].[t_erac] END DESC,
     CASE @OrderBy WHEN 't_ervr' THEN [ttpisg309200].[t_ervr] END,
     CASE @OrderBy WHEN 't_ervr DESC' THEN [ttpisg309200].[t_ervr] END DESC,
     CASE @OrderBy WHEN 't_clbd' THEN [ttpisg309200].[t_clbd] END,
     CASE @OrderBy WHEN 't_clbd DESC' THEN [ttpisg309200].[t_clbd] END DESC,
     CASE @OrderBy WHEN 't_clac' THEN [ttpisg309200].[t_clac] END,
     CASE @OrderBy WHEN 't_clac DESC' THEN [ttpisg309200].[t_clac] END DESC,
     CASE @OrderBy WHEN 't_clvr' THEN [ttpisg309200].[t_clvr] END,
     CASE @OrderBy WHEN 't_clvr DESC' THEN [ttpisg309200].[t_clvr] END DESC,
     CASE @OrderBy WHEN 't_debd' THEN [ttpisg309200].[t_debd] END,
     CASE @OrderBy WHEN 't_debd DESC' THEN [ttpisg309200].[t_debd] END DESC,
     CASE @OrderBy WHEN 't_deac' THEN [ttpisg309200].[t_deac] END,
     CASE @OrderBy WHEN 't_deac DESC' THEN [ttpisg309200].[t_deac] END DESC,
     CASE @OrderBy WHEN 't_devr' THEN [ttpisg309200].[t_devr] END,
     CASE @OrderBy WHEN 't_devr DESC' THEN [ttpisg309200].[t_devr] END DESC,
     CASE @OrderBy WHEN 't_osbd' THEN [ttpisg309200].[t_osbd] END,
     CASE @OrderBy WHEN 't_osbd DESC' THEN [ttpisg309200].[t_osbd] END DESC,
     CASE @OrderBy WHEN 't_osac' THEN [ttpisg309200].[t_osac] END,
     CASE @OrderBy WHEN 't_osac DESC' THEN [ttpisg309200].[t_osac] END DESC,
     CASE @OrderBy WHEN 't_osvr' THEN [ttpisg309200].[t_osvr] END,
     CASE @OrderBy WHEN 't_osvr DESC' THEN [ttpisg309200].[t_osvr] END DESC,
     CASE @OrderBy WHEN 't_tlbd' THEN [ttpisg309200].[t_tlbd] END,
     CASE @OrderBy WHEN 't_tlbd DESC' THEN [ttpisg309200].[t_tlbd] END DESC,
     CASE @OrderBy WHEN 't_tlac' THEN [ttpisg309200].[t_tlac] END,
     CASE @OrderBy WHEN 't_tlac DESC' THEN [ttpisg309200].[t_tlac] END DESC,
     CASE @OrderBy WHEN 't_tlvr' THEN [ttpisg309200].[t_tlvr] END,
     CASE @OrderBy WHEN 't_tlvr DESC' THEN [ttpisg309200].[t_tlvr] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttpisg309200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttpisg309200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttpisg309200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttpisg309200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_ccod' THEN [ttpisg309200].[t_ccod] END,
     CASE @OrderBy WHEN 't_ccod DESC' THEN [ttpisg309200].[t_ccod] END DESC,
     CASE @OrderBy WHEN 't_updt' THEN [ttpisg309200].[t_updt] END,
     CASE @OrderBy WHEN 't_updt DESC' THEN [ttpisg309200].[t_updt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttpisg309200].*  
  FROM [ttpisg309200] 
      INNER JOIN #PageIndex
          ON [ttpisg309200].[t_mnyr] = #PageIndex.t_mnyr
          AND [ttpisg309200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptpisg309SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptpisg309SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptpisg309SelectListFilteres]
  @Filter_t_ccod VarChar(9),
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
 ,t_mnyr VarChar(20) NOT NULL
 ,t_ccod VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_mnyr'
  SET @LGSQL = @LGSQL + ', t_ccod'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttpisg309200].[t_mnyr]'
  SET @LGSQL = @LGSQL + ', [ttpisg309200].[t_ccod]'
  SET @LGSQL = @LGSQL + ' FROM [ttpisg309200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_ccod > '') 
    SET @LGSQL = @LGSQL + ' AND [ttpisg309200].[t_ccod] = ''' + @Filter_t_ccod + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_user' THEN '[ttpisg309200].[t_user]'
                        WHEN 't_user DESC' THEN '[ttpisg309200].[t_user] DESC'
                        WHEN 't_mnyr' THEN '[ttpisg309200].[t_mnyr]'
                        WHEN 't_mnyr DESC' THEN '[ttpisg309200].[t_mnyr] DESC'
                        WHEN 't_sybd' THEN '[ttpisg309200].[t_sybd]'
                        WHEN 't_sybd DESC' THEN '[ttpisg309200].[t_sybd] DESC'
                        WHEN 't_syac' THEN '[ttpisg309200].[t_syac]'
                        WHEN 't_syac DESC' THEN '[ttpisg309200].[t_syac] DESC'
                        WHEN 't_syvr' THEN '[ttpisg309200].[t_syvr]'
                        WHEN 't_syvr DESC' THEN '[ttpisg309200].[t_syvr] DESC'
                        WHEN 't_erbd' THEN '[ttpisg309200].[t_erbd]'
                        WHEN 't_erbd DESC' THEN '[ttpisg309200].[t_erbd] DESC'
                        WHEN 't_erac' THEN '[ttpisg309200].[t_erac]'
                        WHEN 't_erac DESC' THEN '[ttpisg309200].[t_erac] DESC'
                        WHEN 't_ervr' THEN '[ttpisg309200].[t_ervr]'
                        WHEN 't_ervr DESC' THEN '[ttpisg309200].[t_ervr] DESC'
                        WHEN 't_clbd' THEN '[ttpisg309200].[t_clbd]'
                        WHEN 't_clbd DESC' THEN '[ttpisg309200].[t_clbd] DESC'
                        WHEN 't_clac' THEN '[ttpisg309200].[t_clac]'
                        WHEN 't_clac DESC' THEN '[ttpisg309200].[t_clac] DESC'
                        WHEN 't_clvr' THEN '[ttpisg309200].[t_clvr]'
                        WHEN 't_clvr DESC' THEN '[ttpisg309200].[t_clvr] DESC'
                        WHEN 't_debd' THEN '[ttpisg309200].[t_debd]'
                        WHEN 't_debd DESC' THEN '[ttpisg309200].[t_debd] DESC'
                        WHEN 't_deac' THEN '[ttpisg309200].[t_deac]'
                        WHEN 't_deac DESC' THEN '[ttpisg309200].[t_deac] DESC'
                        WHEN 't_devr' THEN '[ttpisg309200].[t_devr]'
                        WHEN 't_devr DESC' THEN '[ttpisg309200].[t_devr] DESC'
                        WHEN 't_osbd' THEN '[ttpisg309200].[t_osbd]'
                        WHEN 't_osbd DESC' THEN '[ttpisg309200].[t_osbd] DESC'
                        WHEN 't_osac' THEN '[ttpisg309200].[t_osac]'
                        WHEN 't_osac DESC' THEN '[ttpisg309200].[t_osac] DESC'
                        WHEN 't_osvr' THEN '[ttpisg309200].[t_osvr]'
                        WHEN 't_osvr DESC' THEN '[ttpisg309200].[t_osvr] DESC'
                        WHEN 't_tlbd' THEN '[ttpisg309200].[t_tlbd]'
                        WHEN 't_tlbd DESC' THEN '[ttpisg309200].[t_tlbd] DESC'
                        WHEN 't_tlac' THEN '[ttpisg309200].[t_tlac]'
                        WHEN 't_tlac DESC' THEN '[ttpisg309200].[t_tlac] DESC'
                        WHEN 't_tlvr' THEN '[ttpisg309200].[t_tlvr]'
                        WHEN 't_tlvr DESC' THEN '[ttpisg309200].[t_tlvr] DESC'
                        WHEN 't_Refcntd' THEN '[ttpisg309200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttpisg309200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttpisg309200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttpisg309200].[t_Refcntu] DESC'
                        WHEN 't_ccod' THEN '[ttpisg309200].[t_ccod]'
                        WHEN 't_ccod DESC' THEN '[ttpisg309200].[t_ccod] DESC'
                        WHEN 't_updt' THEN '[ttpisg309200].[t_updt]'
                        WHEN 't_updt DESC' THEN '[ttpisg309200].[t_updt] DESC'
                        ELSE '[ttpisg309200].[t_mnyr],[ttpisg309200].[t_ccod]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttpisg309200].*  
  FROM [ttpisg309200] 
      INNER JOIN #PageIndex
          ON [ttpisg309200].[t_mnyr] = #PageIndex.t_mnyr
          AND [ttpisg309200].[t_ccod] = #PageIndex.t_ccod
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
