<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BooksIssued.aspx.cs" Inherits="Customer_BooksIssued" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="header">
            <h1>
                Books Issued</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label></h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Customer/CustomerHome.aspx" accesskey="1" title="">Home</a></li>
                <li><a href="BooksIssued.aspx?pg=1" accesskey="2" title="">History</a></li>
                <li><a href="../Customer/Search.aspx" accesskey="3" title="">Search Book</a></li>
                <li><a href="../ChangePassword.aspx" accesskey="4" title="">Change Password</a></li>
                <li><a href="../Logout.aspx" accesskey="5" title="">Logout</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <br />
                    <br />
                    <div id="backtable" runat="server">
                    </div>
                    <div id="divPager" runat="server">
                    </div>
                </div>
            </div>
            <div id="secondaryContent" runat="server">
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="footer">
            <p>
                Automated Library Project &copy Developed by<br />
                Amiraj Dhawan, Rohit Jha, Soumya Sharma & Divya Mahajan</p>
        </div>
    </div>
    </form>
</body>
</html>
