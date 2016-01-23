<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T02.Escaping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <h1 class="title">Your input</h1>
                    <div class="col s6 input-field">
                        <input type="text" value="<script>alert('asfasdf');</script>" id="userInput" runat="server" />
                        <label for="userInput">Your input</label>
                    </div>
                    <div class="col offset-3 s3">
                        <button class="btn-large" id="btnSubmit" runat="server" onserverclick="SubmitUserInput_Click">Submit</button>
                    </div>
                </div>
                <div class="row">
                    <h1 class="title">Escaped</h1>
                    <div class="input-field">
                        <asp:TextBox
                            runat="server"
                            ID="inputResult"
                            Mode="Encode"
                            Visible="False" />
                        <asp:Label
                            runat="server"
                            ID="inputLabel"
                            Mode="Encode"
                            Visible="False" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
</body>
</html>
