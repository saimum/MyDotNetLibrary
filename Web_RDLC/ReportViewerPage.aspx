<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerPage.aspx.cs" Inherits="Web_RDLC.ReportViewerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="formCustomerReport" runat="server">  
    <div>  
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
<rsweb:ReportViewer ID="CustomerListReportViewer" runat="server" Width="100%"></rsweb:ReportViewer>  
    </div>  
</form>
</body>
</html>
