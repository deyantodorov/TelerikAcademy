<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationWithClientAndServerValidation.aspx.cs" Inherits="ValidationControls.RegistrationWithClientAndServerValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" />
            <asp:Panel ID="PanelLogonInfo" runat="server">
                <h1>Logon Info</h1>
                <p>
                    USER NAME:
                    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfUserName"
                        runat="server"
                        ControlToValidate="tbUserName"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="USER NAME field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="LogonInfo" />
                </p>
                <p>
                    PASSWORD:
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfPassword"
                        runat="server"
                        ControlToValidate="tbPassword"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="PASSWORD field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="LogonInfo" />
                </p>
                <p>
                    REPEAT PASSWORD:
                    <asp:TextBox ID="tbRepeatPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfRepeatPassword"
                        runat="server"
                        ControlToValidate="tbRepeatPassword"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="REPEAT PASSWORD field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="LogonInfo" />
                </p>
                <p>
                    <asp:CompareValidator
                        ID="CompareValidatorPassword"
                        runat="server"
                        ControlToCompare="tbPassword"
                        ControlToValidate="tbRepeatPassword"
                        Display="Dynamic"
                        ErrorMessage="Password doesn't match!"
                        ForeColor="Red"
                        EnableClientScript="True" />
                </p>
            </asp:Panel>
            <p>
                <asp:Button ID="ButtonSubmitPersonalInfo" runat="server" Text="Personal Info" ValidationGroup="LogonInfo" />
            </p>
            <asp:Panel ID="PanelPersonalInfo" runat="server">
                <h1>Personal Info</h1>
                <p>
                    FIRST NAME:
                    <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfFirstName"
                        runat="server"
                        ControlToValidate="tbFirstName"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="FIRST NAME field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="PersonalInfo" />
                </p>
                <p>
                    LAST NAME:
                    <asp:TextBox ID="tbLastName"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfLastName"
                        runat="server"
                        ControlToValidate="tbLastName"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="LAST NAME field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="PersonalInfo" />
                </p>
                <p>
                    AGE:
                    <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfAge"
                        runat="server"
                        ControlToValidate="tbAge"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="AGE field is required"
                        ForeColor="Red"
                        EnableClientScript="True"
                        ValidationGroup="PersonalInfo" />
                    <asp:RangeValidator
                        ID="RangeValidatorAge"
                        runat="server"
                        MinimumValue="18"
                        MaximumValue="81"
                        ControlToValidate="tbAge"
                        ErrorMessage="Invalid age range"
                        ForeColor="Red"
                        Display="Dynamic"
                        EnableClientScript="True"
                        ValidationGroup="PersonalInfo" />
                </p>
                 <p>
                    SEX:
                    <asp:RadioButtonList runat="server" ID="rblSex"
                        SelectMethod="GetSex"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="rblSex_OnSelectedIndexChanged" />

                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorSex"
                        runat="server"
                        ControlToValidate="rblSex"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="SEX field is required"
                        ForeColor="Red"
                        EnableClientScript="false"
                        ValidationGroup="PersonalInfo" />

                    <asp:DropDownList runat="server" ID="DropDownListSex" Visible="False" />
                </p>
                <p>
                    <asp:Button ID="ButtonPersonalInfoSubmit" runat="server" Text="Personal Info" ValidationGroup="PersonalInfo" />
                </p>
            </asp:Panel>

            <asp:Panel ID="PanelAddressInfo" runat="server">
                <h1>Address Info</h1>
                <p>
                    EMAIL:
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfEmail"
                        runat="server"
                        ControlToValidate="tbAge"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="EMAIL field is required"
                        ForeColor="Red"
                        EnableClientScript="True" ValidationGroup="AddressInfo" />
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidatorEmail"
                        runat="server"
                        ForeColor="Red"
                        Display="Dynamic"
                        ErrorMessage="Email address is incorrect!"
                        ControlToValidate="tbEmail"
                        EnableClientScript="True"
                        ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
                </p>
                <p>
                    LOCAL ADDRESS:
                <asp:TextBox ID="tbLocalAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorAddress"
                        runat="server"
                        ControlToValidate="tbAge"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="LOCAL ADDRESS field is required"
                        ForeColor="Red"
                        EnableClientScript="True" ValidationGroup="AddressInfo" />
                </p>
                <p>
                    PHONE:
                    <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfPhone"
                        runat="server"
                        ControlToValidate="tbPhone"
                        Display="Dynamic"
                        Text="Required field"
                        ErrorMessage="PHONE field is required"
                        ForeColor="Red"
                        EnableClientScript="True" ValidationGroup="AddressInfo" />
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionPhone"
                        runat="server"
                        ForeColor="Red"
                        Display="Dynamic"
                        ErrorMessage="Phone is incorrect!"
                        ControlToValidate="tbPhone"
                        EnableClientScript="True"
                        ValidationExpression="[0-9]{2,20}" />
                </p>
                <p>
                    I ACCEPT:
                    <asp:CheckBox ID="chAccept" runat="server" ValidationGroup="AddressInfo" />
                </p>
            </asp:Panel>
            <p>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Address Info" ValidationGroup="AddressInfo" />
            </p>
        </div>
    </form>
</body>
</html>
