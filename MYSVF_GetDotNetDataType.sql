CREATE FUNCTION [dbo].[MYSVF_GetDotNetDataType] 
(
@sqlTypeName varchar(50)
)
RETURNS varchar(50)
AS
BEGIN
declare @dotNetTypeName varchar(50);

IF (@sqlTypeName = 'bigint') BEGIN SET  @dotNetTypeName='Int64' END
ELSE IF (@sqlTypeName = 'binary') BEGIN SET  @dotNetTypeName='Byte[]' END
ELSE IF (@sqlTypeName = 'bit') BEGIN SET  @dotNetTypeName='Boolean' END
ELSE IF (@sqlTypeName = 'char') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'cursor') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'date') BEGIN SET  @dotNetTypeName='DateTime' END
ELSE IF (@sqlTypeName = 'datetime') BEGIN SET  @dotNetTypeName='DateTime' END
ELSE IF (@sqlTypeName = 'datetime2') BEGIN SET  @dotNetTypeName='DateTime' END
ELSE IF (@sqlTypeName = 'DATETIMEOFFSET') BEGIN SET  @dotNetTypeName='DateTimeOffset' END
ELSE IF (@sqlTypeName = 'decimal') BEGIN SET  @dotNetTypeName='Decimal' END
ELSE IF (@sqlTypeName = 'float') BEGIN SET  @dotNetTypeName='Double' END
ELSE IF (@sqlTypeName = 'geography') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = 'geometry') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = 'hierarchyid') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = '') BEGIN SET  @dotNetTypeName='' END
ELSE IF (@sqlTypeName = 'image') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'int') BEGIN SET  @dotNetTypeName='Int32' END
ELSE IF (@sqlTypeName = 'money') BEGIN SET  @dotNetTypeName='Decimal' END
ELSE IF (@sqlTypeName = 'nchar') BEGIN SET  @dotNetTypeName='String' END
ELSE IF (@sqlTypeName = 'ntext') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'numeric') BEGIN SET  @dotNetTypeName='Decimal' END
ELSE IF (@sqlTypeName = 'varchar') BEGIN SET  @dotNetTypeName='String' END
ELSE IF (@sqlTypeName = 'nvarchar(1)') BEGIN SET  @dotNetTypeName='String' END
ELSE IF (@sqlTypeName = 'nchar(1)') BEGIN SET  @dotNetTypeName='String' END
ELSE IF (@sqlTypeName = 'real') BEGIN SET  @dotNetTypeName='Single' END
ELSE IF (@sqlTypeName = 'rowversion') BEGIN SET  @dotNetTypeName='Byte[]' END
ELSE IF (@sqlTypeName = 'smallint') BEGIN SET  @dotNetTypeName='Int16' END
ELSE IF (@sqlTypeName = 'smallmoney') BEGIN SET  @dotNetTypeName='Decimal' END
ELSE IF (@sqlTypeName = 'sql_variant') BEGIN SET  @dotNetTypeName='Object' END
ELSE IF (@sqlTypeName = 'table') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'text') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'time') BEGIN SET  @dotNetTypeName='TimeSpan' END
ELSE IF (@sqlTypeName = 'timestamp') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'tinyint') BEGIN SET  @dotNetTypeName='Byte' END
ELSE IF (@sqlTypeName = 'uniqueidentifier') BEGIN SET  @dotNetTypeName='Guid' END
ELSE IF (@sqlTypeName = 'varbinary') BEGIN SET  @dotNetTypeName='Byte[]' END
ELSE IF (@sqlTypeName = 'varbinary(1), binary(1)') BEGIN SET  @dotNetTypeName='byte[]' END
ELSE IF (@sqlTypeName = 'varchar') BEGIN SET  @dotNetTypeName='None' END
ELSE IF (@sqlTypeName = 'xml') BEGIN SET  @dotNetTypeName='None' END
ELSE BEGIN SET  @dotNetTypeName = 'NO Mapping found for ' + @sqlTypeName END
return @dotNetTypeName;
END
