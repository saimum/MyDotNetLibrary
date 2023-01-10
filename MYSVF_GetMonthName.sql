ALTER FUNCTION [dbo].[MYSVF_GetMonthName] 
(
@MonthSerial int
)
RETURNS varchar(10)
AS
BEGIN
declare @MonthName varchar(10);


IF (@MonthSerial =  1) BEGIN SET  @MonthName= 'January'  END
ELSE IF (@MonthSerial =  2) BEGIN SET  @MonthName= 'February' END 
ELSE IF (@MonthSerial =  3) BEGIN SET  @MonthName= 'March'  	 END
ELSE IF (@MonthSerial =  4) BEGIN SET  @MonthName= 'April'  	 END
ELSE IF (@MonthSerial =  5) BEGIN SET  @MonthName= 'May'  	 END
ELSE IF (@MonthSerial =  6) BEGIN SET  @MonthName= 'June'  	 END
ELSE IF (@MonthSerial =  7) BEGIN SET  @MonthName= 'July'  	 END
ELSE IF (@MonthSerial =  8) BEGIN SET  @MonthName= 'August'   END
ELSE IF (@MonthSerial =  9) BEGIN SET  @MonthName= 'September'END  
ELSE IF (@MonthSerial = 10) BEGIN SET  @MonthName= 'October'  END
ELSE IF (@MonthSerial = 11) BEGIN SET  @MonthName= 'November' END 
ELSE IF (@MonthSerial = 12) BEGIN SET  @MonthName= 'December' END
ELSE BEGIN SET  @MonthName= '' END

return @MonthName;
END
