<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="T02.Chat.Default"
    MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />

    <asp:UpdatePanel runat="server" ID="UpdatePanelChat" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <h1>Chat App</h1>
            <hr />
            <asp:ListView runat="server" ID="ListViewChatMessages"
                ItemType="T02.Chat.Models.ChatMessage"
                DataKeyNames="Id"
                SelectMethod="GetMessages">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <tr>
                            <th>Id</th>
                            <th>Chat Message</th>
                            <th>Created On</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <%--<div class="text-center">
                        <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewChatMessages" PageSize="5">
                            <Fields>
                                <asp:NumericPagerField NumericButtonCssClass="btn btn-sm btn-primary" CurrentPageLabelCssClass="btn btn-sm btn-primary active" PreviousPageText="<<" NextPageText=">>" NextPreviousButtonCssClass="btn btn-sm btn-primary" />
                            </Fields>
                        </asp:DataPager>
                    </div>--%>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Id %></td>
                        <td><%#: Item.Text %></td>
                        <td><%#: Item.CreatedOn.ToString("G") %></td>
                    </tr>
                </ItemTemplate>
                <EmptyItemTemplate>
                    <tr>
                        <td colspan="3">No messages yet...</td>
                    </tr>
                </EmptyItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table class="table table-responsive">
        <tr>
            <td colspan="2">
                <asp:TextBox runat="server" ID="TextBoxMessageText" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton runat="server" ID="LinkButtonAddMessage" Text="Add Message" OnClick="LinkButtonAddMessage_OnClick" CssClass="btn btn-lg btn-success" />
            </td>
        </tr>
    </table>

    <div class="text-center">
        <br />
        <br />
        <br />
        <a href="~/PhotoAlbum.aspx" runat="server" class="btn-lg btn-default">Go To Photo Album</a>
    </div>
</asp:Content>
