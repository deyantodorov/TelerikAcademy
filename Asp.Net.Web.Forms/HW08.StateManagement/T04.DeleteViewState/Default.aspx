<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T04.DeleteViewState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        span {
            cursor: pointer;
            background: red;
            color: white;
            font-weight: bold;
            border: 2px solid #000;
        }
    </style>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script>
        function DeleteViewState() {
            $(".aspNetHidden").remove();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxInput" runat="server" />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
            <span onclick="DeleteViewState()">Delete ViewState</span>
        </div>
        <p><em>I delete ViewState with button, but it's restored on Postback</em></p>
    </form>
</body>
</html>
