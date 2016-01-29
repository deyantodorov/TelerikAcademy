<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T01.SearchingForCars.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="DropDownListProducer"
                ErrorMessage="Producer required"
                ForeColor="Red" EnableClientScript="false" InitialValue="-1" />

            <asp:Label runat="server" ID="LabelProducer">Producer</asp:Label>
            <asp:DropDownList runat="server" ID="DropDownListProducer"
                AutoPostBack="True"
                ItemType="T01.SearchingForCars.Models.Producer"
                DataValueField="Id"
                DataTextField="Name"
                OnSelectedIndexChanged="DropDownListProducer_OnSelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div>
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="DropDownListCarModel"
                ErrorMessage="Car Model required"
                ForeColor="Red" EnableClientScript="False" />

            <asp:Label runat="server" ID="LabelCarModel">Car Model</asp:Label>
            <asp:DropDownList runat="server" ID="DropDownListCarModel"
                ItemType="T01.SearchingForCars.Models.Car"
                DataValueField="Id"
                DataTextField="Model" />
        </div>
        <div>
            <asp:Label runat="server" ID="LableExtra">Extras:</asp:Label>
            <asp:CheckBoxList runat="server" ID="CheckBoxExtra"
                ItemType="T01.SearchingForCars.Models.Extra"
                DataValueField="Id"
                DataTextField="Name" />
        </div>
        <div>
            <asp:RequiredFieldValidator runat="server"
                ControlToValidate="RadioButtonListEngineType"
                ErrorMessage="Engine type"
                ForeColor="Red" EnableClientScript="False" />

            <asp:Label runat="server" ID="LabelEngineType">Engine type:</asp:Label>
            <asp:RadioButtonList runat="server"
                ID="RadioButtonListEngineType" />
        </div>
        <div>
            <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" Text="Submit" />
        </div>
        <div>
            <asp:Literal runat="server" ID="SubmitInformation" />
        </div>
    </form>
</body>
</html>
