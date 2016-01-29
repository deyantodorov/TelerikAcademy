<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="UserMenu.ascx.cs" 
    Inherits="HW12.UserControls.Controls.Menu.UserMenu" %>

<ul class="userMenu">
    <asp:DataList runat="server" ID="dlUserMenu">
        <ItemTemplate>
            <li>
                <a class="userMenuItem" href='<%# Eval("Url") %>' style='color: <%# Eval("FontColor")  %>'><%# Eval("Name") %></a>
            </li>
        </ItemTemplate>
    </asp:DataList>
</ul>