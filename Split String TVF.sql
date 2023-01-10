Create FUNCTION [dbo].[MYTVF_STRING_SPLIT]
(
    @string NVARCHAR(MAX),
    @delimiter CHAR(10),
	@index int
)
RETURNS @output TABLE(
    RowIndex int,
	RowData NVARCHAR(MAX)
)
BEGIN
    DECLARE @start INT, @end INT, @_index INT = 0
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string)

    WHILE @start < LEN(@string) + 1 BEGIN
        IF @end = 0 
            SET @end = LEN(@string) + 1
		IF(@_index = @index)
			INSERT INTO @output (RowIndex,RowData) 
			VALUES(@_index,SUBSTRING(@string, @start, @end - @start))
        SET @start = @end + 1
        SET @end = CHARINDEX(@delimiter, @string, @start)
		SET @_index = @_index+1;
    END
    RETURN
END
GO
--SELECT * FROM [master].dbo.[MYTVF_STRING_SPLIT]('John,Jeremy,Jack',',',0) 