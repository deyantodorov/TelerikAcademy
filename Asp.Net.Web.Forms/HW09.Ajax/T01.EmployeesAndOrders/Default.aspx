<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T01.EmployeesAndOrders.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind</title>
</head>
<body>
  <form id="mainForm" runat="server">

        <asp:ScriptManager ID="ScriptManagerNorthwind" runat="server" />

        <div>
            <asp:SqlDataSource
                ID="SqlDataSourceEmployee"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:NorthwindDbContext %>" 
                SelectCommand="select * from employees">
            </asp:SqlDataSource>

            <h1>Employees</h1>

            <asp:GridView
                ID="GridViewEmployees"
                runat="server"
                AllowSorting="True"
                AutoGenerateColumns="False"
                DataKeyNames="EmployeeID"
                DataSourceID="SqlDataSourceEmployee"
                PageSize="5" 
                OnSelectedIndexChanging="GridViewEmployees_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                    <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                    <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                    <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo" />
                    <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath" />
                </Columns>
            </asp:GridView>

            <asp:UpdateProgress 
                ID="UpdateProgressOption" 
                runat="server">
                <ProgressTemplate>
                    <h2>Updatting...</h2>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:SqlDataSource
                ID="SqlDataSourceOrders"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:NorthwindDbContext %>"
                SelectCommand="SELECT DISTINCT * FROM [Orders] WHERE ([EmployeeID] = @EmployeeID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridViewEmployees" Name="EmployeeID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <h2>Client orders:</h2>
            <br />
            <asp:UpdatePanel
                ID="UpdatePanelOrders"
                UpdateMode="Conditional"
                runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger 
                        ControlID="GridViewEmployees" 
                        EventName="SelectedIndexChanging" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="GridViewOrders" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourceOrders">
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
