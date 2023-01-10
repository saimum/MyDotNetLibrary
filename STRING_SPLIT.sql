CREATE FUNCTION [dbo].[MYTVF_STRING_SPLIT]
(
    @string nvarchar(MAX),
    @delimiter nvarchar(1)
)
RETURNS @output TABLE(
    Serial  int,
	Item NVARCHAR(MAX)
)
BEGIN
    DECLARE @start INT, @end INT, @_index INT = 1
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string)

    WHILE @start < LEN(@string) + 1 BEGIN
        IF @end = 0 
            SET @end = LEN(@string) + 1

        INSERT INTO @output (Serial,Item) 
		VALUES(@_index,SUBSTRING(@string, @start, @end - @start))
        SET @start = @end + 1
        SET @end = CHARINDEX(@delimiter, @string, @start)
		SET @_index = @_index+1;
    END
    RETURN
END
