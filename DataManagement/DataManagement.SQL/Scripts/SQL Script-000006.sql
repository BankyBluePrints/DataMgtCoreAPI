--Script to get user by Id
USE [DataManagement]
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 12/24/2016 8:57:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUserById]
@UserId	int
AS
BEGIN

	SET NOCOUNT ON;

 select * from Users where UserId=@UserId and IsDeleted = 0;

END


GO


