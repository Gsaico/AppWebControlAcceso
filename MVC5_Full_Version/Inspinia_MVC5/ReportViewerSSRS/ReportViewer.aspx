<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="Inspinia_MVC5.ReportViewerSSRS.ReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">  
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
    <div>  
        <rsweb:ReportViewer id="rptViewer" runat="server" height="922px" width="1874px" DocumentMapWidth="100%">  
        </rsweb:ReportViewer>  
    </div> 
</form> 
</body>
</html>
