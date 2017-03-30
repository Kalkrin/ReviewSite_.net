<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="MediaProject.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Member.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 115px;
            text-align: left;
        }
        .auto-style3 {
            width: 115px;
            text-align: left;
            height: 50px;
        }
        .auto-style4 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
    
    &nbsp;
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;<asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" causesvalidation="false" style="height: 26px" Text="Logout" />
&nbsp;&nbsp;<br />
&nbsp;</div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderColor="Snow" ForeColor="Red" HeaderText="Please correct the following:" />
        <h1>Write A Review</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Username:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="tbUsername" runat="server" ReadOnly="True"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Summary Title:</td>
                <td>
                    <asp:TextBox ID="tbSummaryTitle" runat="server"></asp:TextBox>
                &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbSummaryTitle" ErrorMessage="Enter Vaild Summary Title" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Rating:</td>
                <td>
                    <asp:DropDownList ID="ddlRating" runat="server" Width="105px">
                    </asp:DropDownList>
&nbsp;out of 10&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style2">Media Type:</td>
                <td>
                    <asp:RadioButton ID="rbMovie" runat="server" Text="  Movie" />
&nbsp;
                    <asp:RadioButton ID="rbBook" runat="server" Text="  Book" />
&nbsp;
                    <asp:RadioButton ID="rbSong" runat="server" Text="  Song" />
                </td>
            </tr>
        </table>
        <p>
            Review:
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbReview" ErrorMessage="Enter Valid Review" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbReview" runat="server" Height="236px" TextMode="MultiLine" Width="384px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </p>
        <p>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </p>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
