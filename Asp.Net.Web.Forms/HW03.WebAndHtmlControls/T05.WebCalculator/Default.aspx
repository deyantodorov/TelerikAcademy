<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T05.WebCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .wrap {
            width: 610px;
            margin: 0 auto;
            text-align: center;
        }

        table {
            width: 600px;
            border: 5px solid #000;
        }

            table button {
                cursor: pointer;
            }

            table tbody td button {
                font-size: 2em;
                height: 50px;
                width: 24%;
            }

            table thead input {
                font-size: 2em;
                padding: 10px;
                width: 550px;
                height: 30px;
                line-height: 30px;
                text-align: right;
            }

            table tfoot button {
                font-size: 2em;
                width: 570px;
            }

            #RegularExpressionValidatorNumber,
            #RequiredFieldValidatorNumber {
                color: red;
                font-size: 2em;
            }
    </style>
</head>
<body>
    <form id="calculator" runat="server">
        <div class="wrap">
            <table>
                <thead>
                    <tr>
                        <th>
                            <asp:TextBox ID="tbNumber" runat="server" />

                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidatorNumber"
                                runat="server" Display="Dynamic"
                                ErrorMessage="Invalid number!"
                                ControlToValidate="tbNumber" EnableClientScript="False"
                                ValidationExpression="^[0-9\.\,]*$">
                            </asp:RegularExpressionValidator>

                            <input type="hidden" value="0" runat="server" id="prevValue" />
                            <input type="hidden" value="" runat="server" id="operation" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <button runat="server" id="num1" onserverclick="Num1_Click">1</button>
                            <button runat="server" id="num2" onserverclick="Num2_Click">2</button>
                            <button runat="server" id="num3" onserverclick="Num3_Click">3</button>
                            <button runat="server" id="plus" onserverclick="Plus_Click">+</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button runat="server" id="num4" onserverclick="Num4_Click">4</button>
                            <button runat="server" id="num5" onserverclick="Num5_Click">5</button>
                            <button runat="server" id="num6" onserverclick="Num6_Click">6</button>
                            <button runat="server" id="minus" onserverclick="Minus_Click">-</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button runat="server" id="num7" onserverclick="Num7_Click">7</button>
                            <button runat="server" id="num8" onserverclick="Num8_Click">8</button>
                            <button runat="server" id="num9" onserverclick="Num9_Click">9</button>
                            <button runat="server" id="multiply" onserverclick="Multiply_Click">X</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button runat="server" id="clear" onserverclick="Clear_Click">Clear</button>
                            <button runat="server" id="num0" onserverclick="Num0_Click">0</button>
                            <button runat="server" id="divide" onserverclick="Divide_Click">/</button>
                            <button runat="server" id="root" onserverclick="Root_Click">&radic;</button>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td>
                            <button runat="server" id="equal" onserverclick="Equal_Click">=</button>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </form>
</body>
</html>
