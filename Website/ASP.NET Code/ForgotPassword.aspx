<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="outer">
        <div id="header">
            <h1>
                Forgot Password</h1>
            <h2>
                For Automated Library</h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="/Login.aspx" accesskey="3" title="">Login</a></li>
                <li><a href="/About.aspx" accesskey="4" title="">About</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <asp:Label ID="UsernameLabel" runat="server" Text="Username:" Width="125px" Height="25px"
                        Font-Size="Medium"></asp:Label>
                    <asp:TextBox ID="UsernameText" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Username Required"
                        ControlToValidate="UsernameText"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="NameLabel" runat="server" Text="Name:" Width="125px" Height="25px"
                        Font-Size="Medium"></asp:Label>
                    <asp:TextBox ID="NameText" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Name Required"
                        ControlToValidate="NameText"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="EmailIdLabel" runat="server" Text="Email ID:" Font-Size="Medium" Height="25px"
                        Width="125px"></asp:Label>
                    <asp:TextBox ID="EmailIdText" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Email ID Required"
                        ControlToValidate="EmailIdText"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="MobileNumberLabel" runat="server" Text="Mobile Number:" Font-Size="Medium"
                        Height="25px" Width="125px"></asp:Label>
                    <asp:TextBox ID="MobileNumberText" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Mobile Number Required"
                        ControlToValidate="MobileNumberText"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="" Width="243px"></asp:Label>
                    <asp:Button ID="Confirm" runat="server" OnClick="Button1_Click" Width="60px" Text="Confirm"
                        CssClass="Button" />
                    <br />
                    <br />
                </div>
            </div>
            <div id="secondaryContent">
                <p>
                    Incase you do not remember your current password and hence are unable to log in;
                    you need to fill in the correct information (Full name, user-id, phone number and
                    email-id) in the respective spaces. Once you click on the “submit” button, a mail
                    containing a random password will be sent to your email-id. You can then log in
                    successfully and hence change your password to a new one.
                </p>
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
