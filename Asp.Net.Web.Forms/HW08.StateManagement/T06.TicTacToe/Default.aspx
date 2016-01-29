<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T04.TicTacToe.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .row {
            width: 600px;
            margin: 0 auto;
            text-align: center;
        }

            .row table {
                width: 100%;
                border: 1px solid #000;
            }

                .row table td {
                    border: 1px solid #000;
                }

                    .row table td button {
                        font-size: 3em;
                        min-width: 100px;
                        min-height: 100px;
                        line-height: 100px;
                        padding: 10px;
                        cursor: pointer;
                    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <h1>Tic-Tac-Toe Game</h1>
            <table class="bordered">
                <tr>
                    <td>
                        <button class="title" runat="server" id="c1" OnServerClick="C1_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c2" OnServerClick="C2_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c3" OnServerClick="C3_Click"></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="title" runat="server" id="c4" OnServerClick="C4_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c5" OnServerClick="C5_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c6" OnServerClick="C6_Click"></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button class="title" runat="server" id="c7" OnServerClick="C7_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c8" OnServerClick="C8_Click"></button>
                    </td>
                    <td>
                        <button class="title" runat="server" id="c9" OnServerClick="C9_Click"></button>
                    </td>
                </tr>
            </table>
            <h2 id="result" runat="server" Visible="False"></h2>
        </div>
    </form>
</body>
</html>
