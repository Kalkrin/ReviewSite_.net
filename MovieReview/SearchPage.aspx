<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="ProjectSearch.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="SearchPage.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="banner" align="center" style="font-size: 26px; font-style: normal; font-family: Arial; font-weight: bold">
    
        <br />
        <span class="auto-style1">The Ultimate
        Review Website</span></div>
    <div id="search" align="center">

        <br />
        <br />
        <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 0px" Width="465px" BackColor="#FFCC99"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br />
        <br />
        <br />
        <asp:RadioButton ID="rdoMovie" runat="server" AutoPostBack="True" Checked="True" GroupName="mediaSelection" OnCheckedChanged="rdoMovie_CheckedChanged" Text="Movie" Font-Bold="True" ForeColor="#003366" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rdoBook" runat="server" AutoPostBack="True" GroupName="mediaSelection" OnCheckedChanged="rdoBook_CheckedChanged" Text="Book" Font-Bold="True" ForeColor="#003366" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rdoSong" runat="server" AutoPostBack="True" GroupName="mediaSelection" OnCheckedChanged="rdoSong_CheckedChanged" Text="Song" Font-Bold="True" ForeColor="#003366" />
        <br />
        <br />

    </div>
    <div style="margin: auto; border-style: solid none none none; border-width: 2px; border-color: black; text-align: left; float: none;">
        <asp:Label ID="lblTop" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
    </div>
    <div id="topRated" style="margin: auto; border-style: none; border-width: 2px; border-color: black; text-align: center;" >

        
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="img1" runat="server" Height="180px" OnClick="ImageButton1_Click" Width="150px" />
&nbsp;<asp:Label ID="lblTitle1" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
&nbsp;<asp:Label ID="lblRating1" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="img2" runat="server" Height="180px" OnClick="img2_Click" Width="150px" />
&nbsp;<asp:Label ID="lblTitle2" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
&nbsp;<asp:Label ID="lblRating2" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </div>

    </form>
</body>
</html>
