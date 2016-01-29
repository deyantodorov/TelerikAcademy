<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HW07.FileUpload.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File upload</title>
    <style type="text/css">
        ul > li {
            padding: 10px;
            list-style-type: none;
        }
    </style>
</head>
<body>
    <form id="mf" runat="server" enctype="multipart/form-data">
        <div>
            <ul>
                <li>Choose file: 
                    <asp:FileUpload ID="FileUploadControl" runat="server" /></li>
                <li>
                    <asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" /></li>
                <li>Status:
                    <asp:Literal ID="StatusMessage" runat="server" /></li>
            </ul>
        </div>
    </form>
</body>
</html>
