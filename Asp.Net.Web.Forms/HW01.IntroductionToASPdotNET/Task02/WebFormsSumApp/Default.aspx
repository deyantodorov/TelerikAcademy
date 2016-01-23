<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSumApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Sum numbers</h1>

    <h2 id="ErrorField" runat="server"></h2>

    <div class="container">
        <div class="row">
            <div class="form-group">
                <asp:Label ID="FirstNumber" runat="server" Text="First number: "></asp:Label>
                <asp:TextBox ID="FirstNumberInput" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="SecondNumber" runat="server" Text="Second number: "></asp:Label>
                <asp:TextBox ID="SecondNumberInput" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Result" runat="server" Text="Sum of numbers"></asp:Label>
                <asp:TextBox ID="ResultInput" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="SumNumbers" runat="server" OnClick="SumNumbers_Click" Text="Sum numbers" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
