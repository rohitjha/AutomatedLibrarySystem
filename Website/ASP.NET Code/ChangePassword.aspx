<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>About</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="header">
            <h1>
                Change Password</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label>
            </h2>
        </div>
        <div id="menu">
            <ul>
                <li id="temp" runat="server"></li>
                <li><a href="../Customer/BooksIssued.aspx?pg=1" accesskey="2" title="">History</a></li>
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
                    <asp:Label ID="OldPasswordLabel" runat="server" Text="Old Password:" CssClass="Labels"
                        Width="135px" Height="25px"></asp:Label>
                    <asp:TextBox ID="OldPasswordText" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Old Password Required"
                        ControlToValidate="OldPasswordText"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="NewPasswordLabel" runat="server" Text="New Password:" CssClass="Labels"
                        Width="135px" Height="25px"></asp:Label>
                    <asp:TextBox ID="NewPasswordText" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*New Password Required"
                        ControlToValidate="NewPasswordText"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password:" CssClass="Labels"
                        Width="135px" Height="25px"></asp:Label>
                    <asp:TextBox ID="ConfirmPasswordText" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Confirm Password Required"
                        ControlToValidate="ConfirmPasswordText"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Space" runat="server" Text="" Width="255px"></asp:Label>
                    <asp:Button ID="Next" runat="server" Text="Next" Width="60px" CssClass="Button" OnClick="Next_Click" />
                    <br />
                    <asp:Label ID="Confirm" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div id="secondaryContent">
                <p>
                    To change your current password to a new one, you have to first enter the current
                    password in the respective space provided. Then enter a new password in the corresponding
                    space. Make sure that your new password does not match with any of your previous
                    passwords. Re-enter your new password to confirm it and then click on the “change“
                    button. A confirmation mail will be sent immediately to your e-mail id stating that
                    the password has been changed successfully.
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
