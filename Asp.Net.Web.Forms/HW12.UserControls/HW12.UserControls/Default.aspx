<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HW12.UserControls.Default" %>

<%@ Register Src="~/Controls/Menu/UserMenu.ascx" TagPrefix="ucm" TagName="UserMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <div>
            <ucm:UserMenu runat="server" ID="UserMenu" />
        </div>
    </form>
</body>
</html>