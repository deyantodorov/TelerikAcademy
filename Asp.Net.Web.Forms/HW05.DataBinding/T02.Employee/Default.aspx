<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T02.Employee.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Grid View</h1>
        <div>

            <asp:GridView ID="GridView1" runat="server"
                AllowPaging="True"
                PageSize="6"
                AllowSorting="True"
                AutoGenerateColumns="False"
                CellPadding="4"
                DataKeyNames="EmployeeID"
                DataSourceID="SqlServerNorthwind"
                ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Id" SortExpression="EmployeeID">
                        <ItemTemplate>
                            <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("EmployeeID") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                        <ItemTemplate>
                            <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("FirstName") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                        <ItemTemplate>
                            <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("LastName") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlServerNorthwind" runat="server"
                ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT * FROM [Employees]"></asp:SqlDataSource>
        </div>
        
        
        <h1>FormView</h1>
        <asp:FormView runat="server" ID="FormViewEmployee" 
            DataSourceID="SqlServerNorthwind"
            AllowPaging="True" 
            PagerSettings=""
            DataKeyName="EmployeeID"
            OnPageIndexChanging="FormViewEmployee_OnPageIndexChanged">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("EmployeeID") %>
                            </a>
                        </td>
                        <td>
                            <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("FirstName") %>
                            </a>
                        </td>
                        <td>
                             <a runat="server" href='<%#: "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                                <%#: Eval("LastName") %>
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <PagerTemplate>
                  <table>
                    <tr>
                      <td><asp:LinkButton ID="FirstButton" CommandName="Page" CommandArgument="First" Text="<<" RunAt="server"/></td>
                      <td><asp:LinkButton ID="PrevButton"  CommandName="Page" CommandArgument="Prev"  Text="<"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="NextButton"  CommandName="Page" CommandArgument="Next"  Text=">"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="LastButton"  CommandName="Page" CommandArgument="Last"  Text=">>" RunAt="server"/></td>
                    </tr>
                  </table>
                </PagerTemplate>
        </asp:FormView>
    </form>
</body>
</html>
