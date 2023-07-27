USE [school]
GO
/****** Object:  StoredProcedure [dbo].[USP_StudentDue_InsertBySystem]    Script Date: 2023-07-27 4:55:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[USP_StudentDue_InsertBySystem] (
 @TransectionIdentifier varchar(50)
,@EffectiveYear	int
,@EffectiveMonthSerial	int
,@StudentId	int
,@FeeHeadId	int
,@DefaultAmount	decimal(18, 2)
,@ConsumptionUnit	decimal(18, 2) = null
,@WaiverPercentage	decimal(5, 2) = null
,@FullAmount	decimal(18, 2)
,@AppliedAmount	decimal(18, 2)
,@ChargeBy	varchar(20)
,@ShortStatus	varchar(20)
,@LongStatus	varchar(50)
,@EntryBy	nvarchar(50)
,@StudentFeeMappingId	int
,@Note	varchar(100)
,@DeveloperNote	varchar(50)	
)	
AS
BEGIN
declare @return_status varchar(50)='OK';
declare @Id int= 0;
declare @return_message varchar(max)='';

BEGIN TRY 
	--Get Validation data
	BEGIN TRAN;
	IF(exists(select 1 from acc_StudentDue_2021_to_2030 where StudentId = @StudentId and FeeHeadId = @FeeHeadId and EffectiveYear = @EffectiveYear AND EffectiveMonthSerial = @EffectiveMonthSerial))
		BEGIN
			set @return_status = 'Validation Failed';
			set @return_message = 'Already Exists';
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[acc_StudentDue_2021_to_2030]
			([TableName]
			,[TransectionIdentifier]
			,[EffectiveYear]
			,[EffectiveMonthSerial]
			,[EffectiveYearAndMonthSerial]
			,[StudentId]
			,[FeeHeadId]
			,[DefaultAmount]
			,[ConsumptionUnit]
			,[WaiverPercentage]
			,[FullAmount]
			,[AppliedAmount]
			,[ChargeBy]
			,[ShortStatus]
			,[LongStatus]
			,[StudentFeeMappingId]
			,[CreatedBy]
			,[CreatedDate]
			,[Note])
			 VALUES
			('acc_StudentDue_2021_to_2030'
			,@TransectionIdentifier
			,@EffectiveYear
			,@EffectiveMonthSerial
			,CONVERT(varchar(4),@EffectiveYear) + '-' +(case when @EffectiveMonthSerial < 10 then '0'+CONVERT(varchar(2),@EffectiveMonthSerial) else CONVERT(varchar(2),@EffectiveMonthSerial) end)
			,@StudentId
			,@FeeHeadId
			,@DefaultAmount
			,@ConsumptionUnit
			,@WaiverPercentage
			,@FullAmount
			,@AppliedAmount
			,@ChargeBy
			,@ShortStatus
			,@LongStatus
			,@StudentFeeMappingId
			,@EntryBy
			,getdate()
			,@Note)
			set @Id = SCOPE_IDENTITY();		
			Commit;
		END
END TRY 
BEGIN CATCH
	ROLLBACK;
	set @return_status = 'Internal Database Error';
	set @return_message = ERROR_MESSAGE(); 
END CATCH  

select @return_status as return_status, @Id as id, @return_message as return_message;

END


