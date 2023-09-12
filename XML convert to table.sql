DECLARE @h int  
DECLARE @xmldoc VARCHAR(1000) = 
'<root>   
	<student FirstName="Ravi" ID="1" Technology="DotNet"></student>   
	<student FirstName="Avdesh" ID="2" Technology="DotNet"></student>
</root>';
  
EXEC sp_xml_preparedocument @h OUTPUT, @xmldoc;
  
SELECT * FROM OpenXML(@h,'/root/student')   
WITH (
FirstName varchar(20),
Technology varchar(20),
ID varchar(20)
) as t
--where t.ID =  '1';
EXEC sp_xml_removedocument @h;
