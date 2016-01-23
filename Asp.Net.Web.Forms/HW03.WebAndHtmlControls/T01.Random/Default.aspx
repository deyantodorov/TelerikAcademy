<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T01.Random.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random numbers</title>
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />
</head>
<body>
    <div class="row">
        <form id="form1" runat="server" class="col s12">
            <h1 class="title">HTML server controls</h1>

            <div class="row">
                <div class="input-field col s6">
                    <input placeholder="Minimal value" id="minValue" type="text" runat="server" />
                    <label for="minValue">Minimal value</label>
                </div>
                <div class="input-field col s6">
                    <input placeholder="Maximal value" id="maxValue" type="text" runat="server" />
                    <label for="maxValue">Maximal value</label>
                </div>
            </div>

            <div class="row">
                <button
                    class="btn btn-large"
                    runat="server"
                    onserverclick="Generate_Click">
                    Generate random value</button>
            </div>

            <div class="row">
                <h2 class="title" id="randomValue" runat="server"></h2>
            </div>

            <h1 class="title">Web server controls</h1>

            <div class="row">
                <div class="input-field col s6">
                    <asp:TextBox runat="server" ID="minValue2" />
                    <asp:Label runat="server">Minimal value</asp:Label>
                </div>
                <div class="input-field col s6">
                    <asp:TextBox runat="server" ID="maxValue2" />
                    <asp:Label runat="server">Maximal value</asp:Label>
                </div>
            </div>

            <div class="row">
                <asp:Button
                    runat="server"
                    CssClass="btn btn-large"
                    OnClick="GenerateRandomValue_Click" Text="Generate random value" />
            </div>

            <div class="row">
                <h2 class="title" id="randomValue2" runat="server"></h2>
            </div>
        </form>
    </div>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
</body>
</html>
