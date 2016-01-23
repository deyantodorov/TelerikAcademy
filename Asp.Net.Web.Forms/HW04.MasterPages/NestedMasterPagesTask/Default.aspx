<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="NestedMasterPagesTask.Default"
    MasterPageFile="~/Site.Master"
    Title="International Company" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="center">
        <h1 class="title">International Company</h1>
        <asp:HyperLink runat="server" NavigateUrl="~/bg-BG/Default.aspx" CssClass="btn-large">Български</asp:HyperLink>
        <asp:HyperLink runat="server" NavigateUrl="~/en-US/Default.aspx" CssClass="btn-large">English</asp:HyperLink>
    </div>
</asp:Content>
