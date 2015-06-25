<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Default3" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Add a New User</title>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <script type="text/javascript">
        function check() {
            document.getElementById("HiddenConfirm").value = "0";
            listItemArray = document.getElementsByName('<%= RadioButtonList1.ClientID %>');
            var listitem = listItemArray[1];
            if (listitem.checked) {
                alert("Adding as Staff will give Administrator Rights, Confirm again");
                if (confirm("Add as Staff"))
                    document.getElementById("HiddenConfirm").value = "1";
                else
                    document.getElementById("HiddenConfirm").value = "0";
            }
        }
    </script>
    <asp:HiddenField ID="HiddenConfirm" runat="server" />
    <div id="outer">
        <div id="header">
            <h2>
                Add A New User</h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Staff/StaffHome.aspx" accesskey="1" title="">Home</a></li>
                <li><a href="../Staff/AddANewBook.aspx" accesskey="2" title="">Add Book</a></li>
                <li><a href="../ChangePassword.aspx" accesskey="3" title="">Change Password</a></li>
                <li><a href="../Logout.aspx" accesskey="4" title="">Logout</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="usRFID" runat="server" Width="120px" Text="RFID Tag :"></asp:Label>
                        <asp:TextBox ID="usRFIDText" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ttt" runat="server" ErrorMessage="*RFID No Required"
                            ControlToValidate="usRFIDText" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="sp1" runat="server" Width="120px" Text=""></asp:Label>
                        <asp:Button ID="getrfid" CausesValidation="false" runat="server" Text="Get RFID Code"
                            CssClass="Button" OnClick="getrfid_Click" />
                        <br />
                        <br />
                        <asp:Label ID="UsernameLabel" runat="server" Text="User Name :" Width="120px"></asp:Label>
                        <asp:TextBox ID="UsernameTextbox" CssClass="TextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Username Required"
                            ControlToValidate="UsernameTextbox" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="PasswordLabel" runat="server" Text="Password :" Width="120px"></asp:Label>
                        <asp:TextBox ID="PasswordTextbox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Password Required"
                            ControlToValidate="PasswordTextbox"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" Width="120px" Text="Confirm Password:"></asp:Label>
                        <asp:TextBox ID="ConfirmPasswordTextbox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPasswordTextbox"
                            ErrorMessage="*Confirm Password Required"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="NameLabel" runat="server" Width="120px" Text="Name :"></asp:Label>
                        <asp:TextBox ID="NameTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Name Required"
                            ControlToValidate="NameTextbox" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="space4" runat="server" Text="" Width="120px"></asp:Label>
                        <asp:RadioButtonList ID="RadioButtonList1" CssClass="radio" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">Customer</asp:ListItem>
                            <asp:ListItem Value="2">Staff</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <br />
                        <asp:Label ID="AddressLabel" runat="server" Width="120px" Text="Address :"></asp:Label>
                        <asp:TextBox ID="AddressTextBox" runat="server" CssClass="TextBox" MaxLength="1000"
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Address Required"
                            ControlToValidate="AddressTextbox" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="PhoneLabel" runat="server" Width="120px" Text="Phone No :"></asp:Label>
                        <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Contact No. Required"
                            ControlToValidate="PhoneTextbox" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="MailLabel" runat="server" Width="120px" Text="Email Address :"></asp:Label>
                        <asp:TextBox ID="MailTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Email Required"
                            ControlToValidate="MailTextbox" Display="Static"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
                        <asp:Label ID="DOBLabel" runat="server" Width="120px" Text="Date Of Birth     (DD-MM-YYYY):"></asp:Label>
                        <asp:TextBox ID="DOBTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajax:CalendarExtender ID="cal1" runat="server" TargetControlID="DOBTextBox" Format="dd-MM-yyyy" />
                        <br />
                        <br />
                        <asp:Label ID="space3" runat="server" Text="" Width="120px"></asp:Label>
                        <asp:Button ID="Add" runat="server" CssClass="Button" OnClick="Add_Click" OnClientClick="check()"
                            Text="Add User" />
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="User Added!" Visible="False"></asp:Label>
                    </asp:Panel>
                </div>
            </div>
            <div id="secondaryContent">
                <p>
                    To add a new member to the library (new member can be added only by the administrator),
                    fill in the details provided by the user. Click on the “add user” button. A user
                    will be added as a member to the library if all the mandatory details have been
                    filled up accurately.</p>
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
