<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerHome.aspx.cs" Inherits="Customer_CustomerHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="outer">
        <div id="header">
            <h1>
                Home</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label></h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Customer/BooksIssued.aspx?pg=1" accesskey="1" title="">History</a></li>
                <li><a href="../Customer/Search.aspx" accesskey="2" title="">Search Book</a></li>
                <li><a href="../ChangePassword.aspx" accesskey="3" title="">Change Password</a></li>
                <li><a href="../Logout.aspx" accesskey="4" title="">Logout</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <br />
                    <br />
                    <br />
                    <p>
                        Enter either the Title/ISBN/Author (use the list down menu to select one option)
                        of a book you are interested in and then click on the “Search” button. If you have
                        entered the correct ISBN, you will get the link to the required book. Whereas if
                        you enter the Title/Author then you obtain a list of books on the click of the “Search”
                        button. You can then choose the appropriate book from the given list or revise your
                        search. Incase you are unable to find the book you need or it is unavailable, go
                        to the request page.
                    </p>
                </div>
            </div>
            <div id="secondaryContent">
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
