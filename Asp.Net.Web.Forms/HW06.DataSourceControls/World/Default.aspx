<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="World.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Continents</h1>
            <asp:EntityDataSource
                ID="EntityDataSourceForContinent"
                runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Continents"
                EnableInsert="True"
                EnableUpdate="True"
                EnableDelete="True">
            </asp:EntityDataSource>

            <asp:ListBox
                ID="ListBoxContinent"
                runat="server"
                DataSourceID="EntityDataSourceForContinent"
                DataTextField="ContinentName"
                DataValueField="Id"
                AutoPostBack="true"
                Rows="10"></asp:ListBox>

            <br />
            <h2>Choose continents to see countries</h2>
            <asp:EntityDataSource
                ID="EntityDataSourceForContries"
                runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Countries"
                Include="Continent, Language"
                Where="it.ContinentId=@CurrentId"
                EnableDelete="True"
                EnableInsert="True"
                EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter
                        ControlID="ListBoxContinent"
                        Name="CurrentId"
                        PropertyName="SelectedValue"
                        Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:EntityDataSource
                ID="EntityDataSourceForCountriesModify"
                runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Countries">
            </asp:EntityDataSource>

            <asp:GridView
                ID="GridViewContry"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                DataSourceID="EntityDataSourceForContries"
                AllowPaging="True"
                AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" HtmlEncode="true" />
                    <asp:BoundField DataField="CountryName" HeaderText="CountryName" SortExpression="CountryName" HtmlEncode="true" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" HtmlEncode="true" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="10px" Width="10px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Language.LanguageName" HeaderText="Language" SortExpression="Language.LanguageName" HtmlEncode="true" />
                    <asp:BoundField DataField="Continent.ContinentName" HeaderText="Continent Name" SortExpression="Continent.ContinentName" HtmlEncode="true" />
                </Columns>
            </asp:GridView>

            <br />

            <h3>Select country to see cities:</h3>

            <asp:EntityDataSource
                ID="EntityDataSourceTowns"
                runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Towns"
                Include="Country"
                Where="it.CountryId=@CurrentId"
                EnableDelete="True"
                EnableInsert="True"
                EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter
                        ControlID="GridViewContry"
                        Name="CurrentId"
                        PropertyName="SelectedValue"
                        Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:ListView
                ID="ListViewTowns"
                runat="server"
                DataKeyNames="Id"
                DataSourceID="EntityDataSourceTowns"
                InsertItemPosition="LastItem"
                ItemType="World.Town">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%# BindItem.TownName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: BindItem.Population %>' />
                        </td>
                        <td>
                            <asp:DropDownList
                                ID="DropDownListForCountry"
                                runat="server"
                                DataSourceID="EntityDataSourceForCountriesModify"
                                DataValueField="Id"
                                DataTextField="CountryName"
                                SelectedValue="<%#: BindItem.CountryId %>">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="TownNameTextBox" runat="server" Text='<%#: BindItem.TownName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: BindItem.Population %>' />
                        </td>
                        <td>
                            <asp:DropDownList
                                ID="DropDownListForCountry"
                                runat="server"
                                DataSourceID="EntityDataSourceForCountriesModify"
                                DataValueField="Id"
                                DataTextField="CountryName"
                                SelectedValue="<%#: BindItem.CountryId %>">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%#: Item.Id %>' />
                        </td>
                        <td>
                            <asp:Label ID="TownNameLabel" runat="server" Text='<%#: Item.TownName %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Item.Population %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#: Item.Country.CountryName %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Id</th>
                                        <th runat="server">TownName</th>
                                        <th runat="server">Population</th>
                                        <th runat="server">Country</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <br />

            <h4>Editing Continents:</h4>
            <asp:ListView
                ID="ListViewContinents"
                runat="server"
                DataKeyNames="Id"
                DataSourceID="EntityDataSourceForContinent"
                InsertItemPosition="LastItem"
                ItemType="World.Continent">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel1" runat="server" Text='<%#: Item.Id %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ContinentNameTextBox" runat="server" Text='<%#: BindItem.ContinentName %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="ContinentNameTextBox" runat="server" Text='<%#: BindItem.ContinentName %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%#: Item.Id %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContinentNameLabel" runat="server" Text='<%#: Item.ContinentName %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Id</th>
                                        <th runat="server">ContinentName</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
