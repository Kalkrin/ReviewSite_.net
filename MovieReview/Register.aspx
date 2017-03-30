<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MediaProject.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Register.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 71%;
        }
        .auto-style4 {
            width: 292px;
        }
        .auto-style8 {
            width: 337px;
        }
        .auto-style9 {
            width: 292px;
            text-align: right;
            height: 30px;
        }
        .auto-style10 {
            width: 337px;
            height: 30px;
        }
        .auto-style15 {
            width: 292px;
            text-align: right;
            height: 32px;
        }
        .auto-style16 {
            width: 337px;
            height: 32px;
        }
        .auto-style18 {
            color: #003366;
            width: 292px;
            text-align: right;
            height: 30px;
        }
        .auto-style19 {
            color: #003366;
            width: 292px;
            text-align: right;
            height: 32px;
        }
        #Reset1 {
            width: 63px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 align="center"> Create Your Media Account!</h2>
    </div>
        <p class="auto-style2">

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;</p>
        <table align="center" class="auto-style3">
            <tr>
                <td class="auto-style19">First Name:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtFName" runat="server" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="First Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Last Name:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtLName" runat="server" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLName" ErrorMessage="Last Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Email:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtEmail" runat="server" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter vaild email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Username:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtUsername" runat="server" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Password:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style18">Confirm Password:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="150px" Height="16px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <br />
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" style="text-align: center" Text="Register" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkLoginPage_Click" CausesValidation="false" ForeColor="Red">Login Page</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
