CREATE procedure [dbo].[MYSP_Help]
	@objname nvarchar(776) = NULL
AS
BEGIN
	set nocount on
	declare	@dbname	sysname ,@no varchar(35), @yes varchar(35), @none varchar(35);
	select @no = 'no', @yes = 'yes', @none = 'none';

	declare @objid int;
	select @objid = object_id from sys.all_objects where object_id = object_id(@objname);

	if exists (select * from sys.all_columns where object_id = @objid)
	begin
		declare @precscaletypes nvarchar(150);
		select @precscaletypes = N'tinyint,smallint,decimal,int,bigint,real,money,float,numeric,smallmoney,date,time,datetime2,datetimeoffset,';
		select
			
			'Column_name'			= name,
			'Type'					= type_name(user_type_id),
			'Nullable'				= case when is_nullable = 0 then @no else @yes end
			
		from sys.all_columns where object_id = @objid
		order by 'Column_name';
	end
	else
	begin
		print 'No table found named as '+ @objname;
	end
END