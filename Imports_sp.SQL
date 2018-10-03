SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spntNotesSelectByID]
  @LoginID NVarChar(8),
  @NotesId VarChar(200) 
  AS
  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Notes].[UserId] = [aspnet_users1].[LoginID]
  WHERE
  [Note_Notes].[NotesId] = @NotesId
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spntNotesSelectListSearch]
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
 ,NotesId VarChar(200) NOT NULL
  )
  INSERT INTO #PageIndex (NotesId)
  SELECT [Note_Notes].[NotesId] FROM [Note_Notes]
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Notes].[UserId] = [aspnet_users1].[LoginID]
 WHERE  
   ( 
         STR(ISNULL([Note_Notes].[Notes_RunningNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[NotesId],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[NotesHandle],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[IndexValue],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[Title],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[Description],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[UserId],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[SendEmailTo],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'Notes_RunningNo' THEN [Note_Notes].[Notes_RunningNo] END,
     CASE @OrderBy WHEN 'Notes_RunningNo DESC' THEN [Note_Notes].[Notes_RunningNo] END DESC,
     CASE @OrderBy WHEN 'NotesId' THEN [Note_Notes].[NotesId] END,
     CASE @OrderBy WHEN 'NotesId DESC' THEN [Note_Notes].[NotesId] END DESC,
     CASE @OrderBy WHEN 'NotesHandle' THEN [Note_Notes].[NotesHandle] END,
     CASE @OrderBy WHEN 'NotesHandle DESC' THEN [Note_Notes].[NotesHandle] END DESC,
     CASE @OrderBy WHEN 'IndexValue' THEN [Note_Notes].[IndexValue] END,
     CASE @OrderBy WHEN 'IndexValue DESC' THEN [Note_Notes].[IndexValue] END DESC,
     CASE @OrderBy WHEN 'Title' THEN [Note_Notes].[Title] END,
     CASE @OrderBy WHEN 'Title DESC' THEN [Note_Notes].[Title] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [Note_Notes].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [Note_Notes].[Description] END DESC,
     CASE @OrderBy WHEN 'UserId' THEN [Note_Notes].[UserId] END,
     CASE @OrderBy WHEN 'UserId DESC' THEN [Note_Notes].[UserId] END DESC,
     CASE @OrderBy WHEN 'Created_Date' THEN [Note_Notes].[Created_Date] END,
     CASE @OrderBy WHEN 'Created_Date DESC' THEN [Note_Notes].[Created_Date] END DESC,
     CASE @OrderBy WHEN 'SendEmailTo' THEN [Note_Notes].[SendEmailTo] END,
     CASE @OrderBy WHEN 'SendEmailTo DESC' THEN [Note_Notes].[SendEmailTo] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
      INNER JOIN #PageIndex
          ON [Note_Notes].[NotesId] = #PageIndex.NotesId
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Notes].[UserId] = [aspnet_users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spntNotesSelectListFilteres]
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
 ,NotesId VarChar(200) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'NotesId'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[Note_Notes].[NotesId]'
  SET @LGSQL = @LGSQL + ' FROM [Note_Notes] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [Note_Notes].[UserId] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'Notes_RunningNo' THEN '[Note_Notes].[Notes_RunningNo]'
                        WHEN 'Notes_RunningNo DESC' THEN '[Note_Notes].[Notes_RunningNo] DESC'
                        WHEN 'NotesId' THEN '[Note_Notes].[NotesId]'
                        WHEN 'NotesId DESC' THEN '[Note_Notes].[NotesId] DESC'
                        WHEN 'NotesHandle' THEN '[Note_Notes].[NotesHandle]'
                        WHEN 'NotesHandle DESC' THEN '[Note_Notes].[NotesHandle] DESC'
                        WHEN 'IndexValue' THEN '[Note_Notes].[IndexValue]'
                        WHEN 'IndexValue DESC' THEN '[Note_Notes].[IndexValue] DESC'
                        WHEN 'Title' THEN '[Note_Notes].[Title]'
                        WHEN 'Title DESC' THEN '[Note_Notes].[Title] DESC'
                        WHEN 'Description' THEN '[Note_Notes].[Description]'
                        WHEN 'Description DESC' THEN '[Note_Notes].[Description] DESC'
                        WHEN 'UserId' THEN '[Note_Notes].[UserId]'
                        WHEN 'UserId DESC' THEN '[Note_Notes].[UserId] DESC'
                        WHEN 'Created_Date' THEN '[Note_Notes].[Created_Date]'
                        WHEN 'Created_Date DESC' THEN '[Note_Notes].[Created_Date] DESC'
                        WHEN 'SendEmailTo' THEN '[Note_Notes].[SendEmailTo]'
                        WHEN 'SendEmailTo DESC' THEN '[Note_Notes].[SendEmailTo] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        ELSE '[Note_Notes].[NotesId]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
      INNER JOIN #PageIndex
          ON [Note_Notes].[NotesId] = #PageIndex.NotesId
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Notes].[UserId] = [aspnet_users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesInsert]
GO
 
CREATE PROCEDURE [dbo].[spntNotesInsert]
  @Notes_RunningNo Int,
  @NotesId VarChar(200),
  @NotesHandle VarChar(200),
  @IndexValue VarChar(200),
  @Title VarChar(500),
  @Description VarChar(20000),
  @UserId NVarChar(8),
  @Created_Date DateTime,
  @SendEmailTo VarChar(500),
  @Return_NotesId VarChar(200) = null OUTPUT 
  AS
  INSERT [Note_Notes]
  (
   [Notes_RunningNo]
  ,[NotesId]
  ,[NotesHandle]
  ,[IndexValue]
  ,[Title]
  ,[Description]
  ,[UserId]
  ,[Created_Date]
  ,[SendEmailTo]
  )
  VALUES
  (
   @Notes_RunningNo
  ,UPPER(@NotesId)
  ,@NotesHandle
  ,@IndexValue
  ,@Title
  ,@Description
  ,@UserId
  ,@Created_Date
  ,@SendEmailTo
  )
  SET @Return_NotesId = @NotesId
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesUpdate]
GO
 
CREATE PROCEDURE [dbo].[spntNotesUpdate]
  @Original_NotesId VarChar(200), 
  @Notes_RunningNo Int,
  @NotesId VarChar(200),
  @NotesHandle VarChar(200),
  @IndexValue VarChar(200),
  @Title VarChar(500),
  @Description VarChar(20000),
  @UserId NVarChar(8),
  @Created_Date DateTime,
  @SendEmailTo VarChar(500),
  @RowCount int = null OUTPUT
  AS
  UPDATE [Note_Notes] SET 
   [Notes_RunningNo] = @Notes_RunningNo
  ,[NotesId] = @NotesId
  ,[NotesHandle] = @NotesHandle
  ,[IndexValue] = @IndexValue
  ,[Title] = @Title
  ,[Description] = @Description
  ,[UserId] = @UserId
  ,[Created_Date] = @Created_Date
  ,[SendEmailTo] = @SendEmailTo
  WHERE
  [NotesId] = @Original_NotesId
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntNotesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntNotesDelete]
GO
 
CREATE PROCEDURE [dbo].[spntNotesDelete]
  @Original_NotesId VarChar(200),
  @RowCount int = null OUTPUT
  AS
  DELETE [Note_Notes]
  WHERE
  [Note_Notes].[NotesId] = @Original_NotesId
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spntReminderSelectByID]
  @LoginID NVarChar(8),
  @ReminderID Int 
  AS
  SELECT
    [Note_Reminder].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Reminder] 
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Reminder].[User] = [aspnet_users1].[LoginID]
  WHERE
  [Note_Reminder].[ReminderID] = @ReminderID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spntReminderSelectListSearch]
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
 ,ReminderID Int NOT NULL
  )
  INSERT INTO #PageIndex (ReminderID)
  SELECT [Note_Reminder].[ReminderID] FROM [Note_Reminder]
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Reminder].[User] = [aspnet_users1].[LoginID]
 WHERE  
   ( 
         STR(ISNULL([Note_Reminder].[ReminderID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Reminder].[NotesId],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Reminder].[ReminderTo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Reminder].[Status],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Reminder].[User],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ReminderID' THEN [Note_Reminder].[ReminderID] END,
     CASE @OrderBy WHEN 'ReminderID DESC' THEN [Note_Reminder].[ReminderID] END DESC,
     CASE @OrderBy WHEN 'NotesId' THEN [Note_Reminder].[NotesId] END,
     CASE @OrderBy WHEN 'NotesId DESC' THEN [Note_Reminder].[NotesId] END DESC,
     CASE @OrderBy WHEN 'ReminderTo' THEN [Note_Reminder].[ReminderTo] END,
     CASE @OrderBy WHEN 'ReminderTo DESC' THEN [Note_Reminder].[ReminderTo] END DESC,
     CASE @OrderBy WHEN 'ReminderDateTime' THEN [Note_Reminder].[ReminderDateTime] END,
     CASE @OrderBy WHEN 'ReminderDateTime DESC' THEN [Note_Reminder].[ReminderDateTime] END DESC,
     CASE @OrderBy WHEN 'Status' THEN [Note_Reminder].[Status] END,
     CASE @OrderBy WHEN 'Status DESC' THEN [Note_Reminder].[Status] END DESC,
     CASE @OrderBy WHEN 'CreatedDate' THEN [Note_Reminder].[CreatedDate] END,
     CASE @OrderBy WHEN 'CreatedDate DESC' THEN [Note_Reminder].[CreatedDate] END DESC,
     CASE @OrderBy WHEN 'User' THEN [Note_Reminder].[User] END,
     CASE @OrderBy WHEN 'User DESC' THEN [Note_Reminder].[User] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [Note_Reminder].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Reminder] 
      INNER JOIN #PageIndex
          ON [Note_Reminder].[ReminderID] = #PageIndex.ReminderID
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Reminder].[User] = [aspnet_users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spntReminderSelectListFilteres]
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
 ,ReminderID Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ReminderID'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[Note_Reminder].[ReminderID]'
  SET @LGSQL = @LGSQL + ' FROM [Note_Reminder] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [Note_Reminder].[User] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ReminderID' THEN '[Note_Reminder].[ReminderID]'
                        WHEN 'ReminderID DESC' THEN '[Note_Reminder].[ReminderID] DESC'
                        WHEN 'NotesId' THEN '[Note_Reminder].[NotesId]'
                        WHEN 'NotesId DESC' THEN '[Note_Reminder].[NotesId] DESC'
                        WHEN 'ReminderTo' THEN '[Note_Reminder].[ReminderTo]'
                        WHEN 'ReminderTo DESC' THEN '[Note_Reminder].[ReminderTo] DESC'
                        WHEN 'ReminderDateTime' THEN '[Note_Reminder].[ReminderDateTime]'
                        WHEN 'ReminderDateTime DESC' THEN '[Note_Reminder].[ReminderDateTime] DESC'
                        WHEN 'Status' THEN '[Note_Reminder].[Status]'
                        WHEN 'Status DESC' THEN '[Note_Reminder].[Status] DESC'
                        WHEN 'CreatedDate' THEN '[Note_Reminder].[CreatedDate]'
                        WHEN 'CreatedDate DESC' THEN '[Note_Reminder].[CreatedDate] DESC'
                        WHEN 'User' THEN '[Note_Reminder].[User]'
                        WHEN 'User DESC' THEN '[Note_Reminder].[User] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        ELSE '[Note_Reminder].[ReminderID]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [Note_Reminder].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Reminder] 
      INNER JOIN #PageIndex
          ON [Note_Reminder].[ReminderID] = #PageIndex.ReminderID
  INNER JOIN [aspnet_users] AS [aspnet_users1]
    ON [Note_Reminder].[User] = [aspnet_users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderInsert]
GO
 
CREATE PROCEDURE [dbo].[spntReminderInsert]
  @ReminderID Int,
  @NotesId VarChar(200),
  @ReminderTo VarChar(500),
  @ReminderDateTime DateTime,
  @Status VarChar(10),
  @CreatedDate DateTime,
  @User NVarChar(8),
  @Return_ReminderID Int = null OUTPUT 
  AS
  INSERT [Note_Reminder]
  (
   [ReminderID]
  ,[NotesId]
  ,[ReminderTo]
  ,[ReminderDateTime]
  ,[Status]
  ,[CreatedDate]
  ,[User]
  )
  VALUES
  (
   @ReminderID
  ,@NotesId
  ,@ReminderTo
  ,@ReminderDateTime
  ,@Status
  ,@CreatedDate
  ,@User
  )
  SET @Return_ReminderID = @ReminderID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderUpdate]
GO
 
CREATE PROCEDURE [dbo].[spntReminderUpdate]
  @Original_ReminderID Int, 
  @ReminderID Int,
  @NotesId VarChar(200),
  @ReminderTo VarChar(500),
  @ReminderDateTime DateTime,
  @Status VarChar(10),
  @CreatedDate DateTime,
  @User NVarChar(8),
  @RowCount int = null OUTPUT
  AS
  UPDATE [Note_Reminder] SET 
   [ReminderID] = @ReminderID
  ,[NotesId] = @NotesId
  ,[ReminderTo] = @ReminderTo
  ,[ReminderDateTime] = @ReminderDateTime
  ,[Status] = @Status
  ,[CreatedDate] = @CreatedDate
  ,[User] = @User
  WHERE
  [ReminderID] = @Original_ReminderID
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spntReminderDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spntReminderDelete]
GO
 
CREATE PROCEDURE [dbo].[spntReminderDelete]
  @Original_ReminderID Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [Note_Reminder]
  WHERE
  [Note_Reminder].[ReminderID] = @Original_ReminderID
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
