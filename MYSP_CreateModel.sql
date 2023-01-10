Create procedure [dbo].[MYSP_CreateModel]
	@objname varchar(776) = NULL
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
			'prop' = ''
			
			--Annotation [Key]
			--+(case when (name = (select col_name(@objid, column_id) from sys.identity_columns where object_id = @objid)) 
			--	Then '[Key] ' 
			--	else ''
			--	end)

			--Annotation [Required]
			+(case when is_nullable = 0 then '[Required] ' else '' end)

			--varchar/nvarchar Maxlength
			+(case when (type_name(user_type_id) = 'varchar' OR type_name(user_type_id) = 'nvarchar') 
				then ('[MaxLength(' + convert(varchar(10), max_length) + ')] ')
				else ''
				end)
			
			--Annotation decimal precision and scale
			+(case when (type_name(user_type_id) = 'decimal') 
				then ('[Column(TypeName = "decimal(' + convert(char(2),ColumnProperty(object_id, name, 'precision')) +','+ convert(char(2),OdbcScale(system_type_id,scale)) +')")] ')
				else ''
				end)
			
			+ 'public' + ' '

			+ (case when (is_nullable = 1)  then ([dbo].[MYSVF_GetDotNetDataType](type_name(user_type_id))+'?') 
				else [dbo].[MYSVF_GetDotNetDataType](type_name(user_type_id)) end) + ' '

			+ name + ' '
			
			+ '{ get; set; }'
			
		from sys.all_columns where object_id = @objid;
	end
END

