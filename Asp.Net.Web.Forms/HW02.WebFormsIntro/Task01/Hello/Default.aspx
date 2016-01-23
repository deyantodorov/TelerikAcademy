<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hello._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="jumbotron">
                    <h1 runat="server" ID="txtGreet">Welcome</h1>
                </div>
                <h1></h1>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblName">Type your name:</asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="Submit_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
