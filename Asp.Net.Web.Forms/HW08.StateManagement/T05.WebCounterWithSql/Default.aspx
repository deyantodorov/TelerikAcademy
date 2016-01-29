<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T05.WebCounterWithSql.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="mainForm" runat="server">
        <div>
            Counter: <asp:Label
                ID="LabelLoad"
                runat="server"
                Text="" />
        </div>
        <div>
            <asp:Image 
                ID="ImageCounter" 
                runat="server" />
        </div>
        <div>
            <asp:Button
                ID="ButtonAddLoad"
                runat="server"
                Text="Post Back"
                OnClick="ButtonAddLoad_Click" />
        </div>
    </form>
</body>
</html>
