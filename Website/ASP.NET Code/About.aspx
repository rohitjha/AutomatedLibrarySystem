<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="header">
            <h1>
                About</h1>
            <h2>
                For Automated Library</h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Login.aspx" accesskey="3" title="">Login</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <br />
                    <asp:Button ID="Button1" Visible="false" runat="server" CssClass="Button" Text="Button" 
                        onclick="Button1_Click" />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" Visible="false" GridLines="None" AllowPaging="True" CssClass="table" >
                        <RowStyle CssClass="rowA" />
                        <AlternatingRowStyle CssClass="rowB" />
                    </asp:GridView>
                    <br />
                    <div id="divPager" runat="server" visible="false" style="float: left;">
                    </div>
                    <br />
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
