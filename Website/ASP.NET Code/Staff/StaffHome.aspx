<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffHome.aspx.cs" Inherits="Staff_StaffHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label>
            </h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Staff/AddANewBook.aspx" accesskey="1" title="">Add Book</a></li>
                <li><a href="../Staff/AddUser.aspx" accesskey="2" title="">Add User</a></li>
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
                    <br />
                    <p>
                        To add a new book to the database, enter the Title/ISBN/Author of the book by selecting
                        the option from the list down menu. Once you have entered the text, click on the
                        “search” button. The cover page and details of the required book will be extracted
                        from the Google API automatically (only if you have entered the ISBN). If you want
                        to search the book by using the name of the Title/Author then you get a list of
                        related books. Choose the book you want to add and then click on the “Add” button.
                        All the details of the book will be added to the database immediately.
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
