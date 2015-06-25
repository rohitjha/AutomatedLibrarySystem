<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Customer_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div id="outer">
        <div id="header">
            <h1>
                Search</h1>
            <h2>
                For Automated Library</h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Customer/CustomerHome.aspx" accesskey="1" title="">Home</a></li>
                <li><a href="../Customer/BooksIssued.aspx?pg=1" accesskey="2" title="">History</a></li>
                <li><a href="Search.aspx" accesskey="3" title="">Search Book</a></li>
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
                    <a href="BookSearch.aspx" title=""><h3>Search for a Book in Library</h3></a><br /><br />
                    <a href="SearchForABook.aspx" title=""><h3>Search for a Book on Google with preview</h3></a>
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
