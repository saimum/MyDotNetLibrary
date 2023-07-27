ALTER PROCEDURE [dbo].[USP_StudentInvoice_Transectional_GetByCriteria] (
@ClassId int = null,
@GroupId int = null,
@ShiftId int = null,
@SectionId int = null,
@StudentId int = null,
@RegistrationNumber varchar(30) = null,
@EffectiveYearAndMonthSeeialFrom varchar(10) = null,
@EffectiveYearAndMonthSeeialTo varchar(10) = null,
@Status varchar(20) = null,
@PaidDateFrom datetime = null,
@PaidDateTo datetime = null,
@TransectionIdentifier varchar(50) = null,
@TrackingId varchar(50) = null
)
	
AS
BEGIN

	select  --top 1 
	0 as FirstColumn,
	
	vw_AllStudents.Id as Student_Id, 
	vw_AllStudents.RegNo as Student_RegistrationNumber, 
	st_Person.NameEng as Student_Name, 
	bs_ClassName.ClassName as Student_Class, 
	bs_Group.GroupName as Student_Group, 
	bs_Shift.Shift as Student_Shift, 
	bs_Section.Section as Student_Section, 
	bs_ClassName.ClassName as Student_Class, 


	ttv_acc_StudentInvoice.Id as StudentInvoice_Id,
	ttv_acc_StudentInvoice.TrackingId as StudentInvoice_TrackingId,
	ttv_acc_StudentInvoice.TransectionIdentifier as StudentInvoice_TransectionIdentifier,
	ttv_acc_StudentInvoice.EffectiveYear as StudentInvoice_EffectiveYear,
	ttv_acc_StudentInvoice.OldBalance as StudentInvoice_OldBalance,
	ttv_acc_StudentInvoice.DepositedAmount as StudentInvoice_DepositedAmount,
	ttv_acc_StudentInvoice.NewBalance as StudentInvoice_NewBalance,
	(ttv_acc_StudentInvoice.NewBalance - ttv_acc_StudentInvoice.RemainingBalance) as StudentInvoice_PaidAmount,
	ttv_acc_StudentInvoice.RemainingBalance as StudentInvoice_RemainingBalance,
	ttv_acc_StudentInvoice.CreatedBy as StudentInvoice_CreatedBy,
	ttv_acc_StudentInvoice.CreatedDate as StudentInvoice_CreatedDate,
	ttv_acc_StudentInvoice.Note as StudentInvoice_Note,
	
	1 as LastColumn
	from ttv_acc_StudentInvoice
	join vw_AllStudents on ttv_acc_StudentInvoice.StudentId = vw_AllStudents.Id
	join st_Person on vw_AllStudents.PersonId =st_Person.Id
	join vw_StudentToClass_Last_AnyYear as studentCurrentInfo on vw_AllStudents.Id = studentCurrentInfo.StudentId
	join bs_ClassName on studentCurrentInfo.ClassId = bs_ClassName.Id
	join bs_Group on studentCurrentInfo.GroupId = bs_Group.Id
	join bs_Shift on studentCurrentInfo.ShiftId = bs_Shift.Id
	join bs_Section on studentCurrentInfo.SectionId = bs_Section.Id
	----left join acc_StudentFeeMapping on studentCurrentInfo.Id = acc_StudentFeeMapping.StudentId AND acc_StudentFeeMapping.IsActive = @StudentFeeMappingIsActive
	
	where 1=1 
	AND (@ClassId is null or (bs_ClassName.Id = @ClassId))
	AND (@GroupId is null or (studentCurrentInfo.GroupId = @GroupId))
	AND (@ShiftId is null or (studentCurrentInfo.ShiftId = @ShiftId))
	AND (@SectionId is null or (studentCurrentInfo.SectionId = @SectionId))
	AND (@StudentId is null or (vw_AllStudents.Id = @StudentId))
	AND (@RegistrationNumber is null or (vw_AllStudents.RegNo like '%'+@RegistrationNumber+'%'))

	
	AND (@Status is null or (ttv_acc_StudentInvoice.Status = @Status))
	AND (@PaidDateFrom is null or (ttv_acc_StudentInvoice.CreatedDate >= @PaidDateFrom))
	AND (@PaidDateTo is null or (ttv_acc_StudentInvoice.CreatedDate < @PaidDateTo))
	AND (@TransectionIdentifier is null or (ttv_acc_StudentInvoice.TransectionIdentifier = @TransectionIdentifier))
	AND (@TrackingId is null or (ttv_acc_StudentInvoice.TrackingId = @TrackingId))
	order by ttv_acc_StudentInvoice.EffectiveYear, ttv_acc_StudentInvoice.Id;

END









