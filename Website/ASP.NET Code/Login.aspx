<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Log-in Page</title>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="outer">
        <div id="header">
            <h1>
                Login</h1>
            <h2>
                For Automated Library</h2>
        </div>
        <div id="menu">
            <ul>
                <li class="first"><a href="#" accesskey="1" title=""></a></li>
                <li><a href="#" accesskey="2" title=""></a></li>
                <li><a href="/ForgotPassword.aspx" accesskey="3" title="">Forgot Password?</a></li>
                <li><a href="/About.aspx" accesskey="4" title="">About</a></li>
                <li><a href="#" accesskey="5" title=""></a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <asp:Label ID="UserNameLabel" runat="server" Text="Username:" Height="25px" 
                        Width="100px"></asp:Label>
                    <asp:TextBox ID="UserNameTextbox" runat="server" Width="175px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="UserNameError" runat="server" ForeColor="#FD0000" Text="* User Name Required"
                        Visible="False" Width="150px" Font-Size="Small"></asp:Label>
                    <br />
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password:" Height="25px" 
                        Width="100px"></asp:Label>
                    <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server" Width="175px"
                         CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="PasswordError" runat="server" ForeColor="Red" Text="* Password Required"
                        Visible="False" Width="125px" Font-Size="Small"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Visible="false" Width="100px"></asp:Label>
                    <asp:Label ID="UserPassWrong" runat="server" ForeColor="Red" Text="Username or Password Wrong"
                        Visible="False" Font-Size="Small"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Height="20px" Width="210px"></asp:Label>
                    <asp:Button ID="Button1" runat="server" CssClass="Button" OnClick="Button1_Click"
                        Text="Login" Width="70px" Font-Size="Medium" ForeColor="#6F5129" />
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
