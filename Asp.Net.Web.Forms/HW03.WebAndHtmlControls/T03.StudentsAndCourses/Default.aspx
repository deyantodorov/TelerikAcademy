<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T03.StudentsAndCourses.Default" %>

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
            <div class="col s9 offset-3">
                <h1 class="title">Registration</h1>
                <div class="input-field">
                    <asp:TextBox runat="server" ID="txtFirstName" />
                    <label for="txtFirstName">First name:</label>
                </div>
                <div class="input-field">
                    <asp:TextBox runat="server" ID="txtLastName" />
                    <label for="txtLastName">Last name</label>
                </div>
                <div class="input-field">
                    <asp:DropDownList runat="server" ID="University" CssClass="browser-default" />
                </div>
                <div class="input-field">
                    <asp:DropDownList runat="server" ID="Specialty" CssClass="browser-default" />
                </div>
                <div class="input-field">
                    <asp:ListBox runat="server" ID="Courses" SelectionMode="Multiple" CssClass="browser-default" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col s9 offset-3">
                <button class="btn-large" runat="server" onserverclick="RegisterUser_Click">Register</button>
            </div>
            <div class="col s9 offset-3" runat="server" id="userRegistrationInfo" visible="False">
            </div>
        </div>
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>
</body>
</html>
