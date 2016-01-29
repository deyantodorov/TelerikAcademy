<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="TodoList.Default"
    ValidateRequest="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDo List</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>
<body>
    <form id="formMain" runat="server">
        <div class="container">
            <hr />
            <h1>Todos</h1>
            <hr />
            <asp:ListView runat="server"
                ID="ListViewTodos"
                ItemType="TodoList.Models.Todo"
                DataKeyNames="Id"
                SelectMethod="GetTodos"
                DeleteMethod="TodoDelete"
                UpdateMethod="TodoUpdate"
                InsertMethod="TodoInsert"
                InsertItemPosition="LastItem"
                OnItemInserting="ListViewTodos_OnItemInserting">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Text</th>
                            <th>Category</th>
                            <th>Last Change</th>
                            <th>Options</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <br />
                    <div class="text-center">
                        <asp:DataPager ID="DataPagerTodos" runat="server" PageSize="4">
                            <Fields>
                                <asp:NumericPagerField
                                    NumericButtonCssClass="btn btn-sm btn-primary"
                                    CurrentPageLabelCssClass="btn btn-sm btn-primary active"
                                    PreviousPageText="&lt;&lt;"
                                    NextPageText="&gt;&gt;"
                                    NextPreviousButtonCssClass="btn btn-sm btn-primary" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Id %></td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.Text %></td>
                        <td><%#: Item.Category.Name %></td>
                        <td><%#: Item.LastChange.ToString("g") %></td>
                        <td>
                            <asp:Button runat="server" ID="ButtonEdit" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                            <asp:Button runat="server" ID="ButtonDelete" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <td><%#: Item.Id %></td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Text %>" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxText" Text="<%#: BindItem.Text %>" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="ButtonEdit" CommandName="Update" Text="Save" CssClass="btn btn-default" />
                        <asp:Button runat="server" ID="ButtonDelete" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" />
                    </td>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxTitle" CssClass="form-control" Text="<%#: BindItem.Title %>"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxText" CssClass="form-control" Text="<%#: BindItem.Text %>"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList runat="server" 
                                ID="DropDownListCategories" 
                                CssClass="form-control"
                                AppendDataBoundItems="True"
                                DataTextField="Name"
                                DataValueField="Id">
                                <Items>
                                    <asp:ListItem Value="-1">Select Country</asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="TodoInsert" CssClass="btn btn-success" CommandName="Insert" Text="Save" />
                            <asp:Button runat="server" ID="TodoCancel" CssClass="btn btn-default" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="5">No results found...</td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>
            <hr />
            <h1>Categories</h1>
            <div class="pull-right">
            </div>
            <hr />
            <asp:ListView runat="server" ID="ListViewCategories"
                ItemType="TodoList.Models.Category"
                DataKeyNames="Id"
                SelectMethod="GetCategories"
                DeleteMethod="CategoryDelete"
                UpdateMethod="CategoryUpdate"
                InsertMethod="CategoryInsert"
                InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <tr class="table table-bordered">
                            <th>Id</th>
                            <th>Name</th>
                            <th>Options</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <br />
                    <div class="text-center">
                        <asp:DataPager ID="DataPagerCategories" runat="server" PageSize="4">
                            <Fields>
                                <asp:NumericPagerField
                                    NumericButtonCssClass="btn btn-sm btn-primary"
                                    CurrentPageLabelCssClass="btn btn-sm btn-primary active"
                                    PreviousPageText="&lt;&lt;"
                                    NextPageText="&gt;&gt;"
                                    NextPreviousButtonCssClass="btn btn-sm btn-primary" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <EmptyItemTemplate>
                </EmptyItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Id %></td>
                        <td><%#: Item.Name %></td>
                        <td>
                            <asp:Button runat="server" ID="CategoryEdit" CssClass="btn btn-default" CommandName="Edit" Text="Edit" />
                            <asp:Button runat="server" ID="CategoryDelete" CssClass="btn btn-danger" CommandName="Delete" Text="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="CategoryEdit" CssClass="btn btn-default" CommandName="Update" Text="Save" />
                            <asp:Button runat="server" ID="CategoryDelete" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <td></td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="CategoryInsert" CssClass="btn btn-success" CommandName="Insert" Text="Save" />
                        <asp:Button runat="server" ID="CategoryCancel" CssClass="btn btn-default" CommandName="Cancel" Text="Cancel" />
                    </td>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
</body>
</html>
