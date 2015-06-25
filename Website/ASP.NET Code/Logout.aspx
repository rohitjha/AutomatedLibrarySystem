<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
     <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server"  autocomplete="off">
    <div id="outer">
        <div id="header">
            <h1>
                Logout</h1>
            <h2>
                For Automated Library</h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="/About.aspx" accesskey="3" title="">About</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <br />
                    <br />
                    <p>Successfully Loged out.</p>
                    <a href="../Login.aspx">Continue to Login?</a>
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
