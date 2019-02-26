USE [SecondSightSouthendEyeCentre]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_GenerateClass]
		@tableName = N'DossListSummary'

SELECT	@return_value as 'Return Value'

GO
