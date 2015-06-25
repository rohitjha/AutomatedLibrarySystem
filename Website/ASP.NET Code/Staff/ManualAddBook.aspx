<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualAddBook.aspx.cs" Inherits="Staff_ManualAddBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manually Add a New Book</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function conf(response) {
            alert(response.toString());
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server"  autocomplete="off">
    <div id="outer">
        <div id="header">
            <asp:HiddenField ID="HiddenCount" Value="0" runat="server" />
            <h1>
                Manually Add Book</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server"></asp:Label></h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Staff/AddUser.aspx" accesskey="2" title="">Add User</a></li>
                <li><a href="../ChangePassword.aspx" accesskey="3" title="">Change Password</a></li>
                <li><a href="../Logout.aspx" accesskey="4" title="">Logout</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <asp:Label ID="BookIDLabel" runat="server" Text="Book ID:" Width="125px"></asp:Label>
                    <asp:TextBox ID="BookID" runat="server" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="RfidLabel" runat="server" Text="RFID Tag:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Rfid" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="RfidError" runat="server" Text="*RFID Tag Required" Visible="false"
                        ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="ISBN10Label" runat="server" Text="ISBN 10:" Width="125px"></asp:Label>
                    <asp:TextBox ID="ISBN10" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="ISBN13Label" runat="server" Text="ISBN 13:" Width="125px"></asp:Label>
                    <asp:TextBox ID="ISBN13" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="TitleLabel" runat="server" Text="Title:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Title" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="TitleError" runat="server" Text="*Title Required" Visible="false"
                        ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="SubTitleLabel" runat="server" Text="Sub-Title:" Width="125px"></asp:Label>
                    <asp:TextBox ID="SubTitle" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Space" runat="server" Text="" Width="140px"></asp:Label>
                    <asp:Button ID="AddAuthor" runat="server" Text="Add Author" CssClass="Button" OnClick="AddAuthor_Click" />
                    <br />
                    <div id="author" runat="server">
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="PublisherLabel" runat="server" Text="Publisher Name:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Publisher" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="PublishedDateLabel" runat="server" Text="Published Date:" Width="125px"></asp:Label>
                    <asp:TextBox ID="PublishedDate" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="DescriptionLabel" runat="server" Text="Description:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Description" runat="server" CssClass="TextBox" MaxLength="10000"
                        TextMode="MultiLine" Width="175px" Hseight="80px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="SectionLabel" runat="server" Text="Section:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Section" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="ShelfLabel" runat="server" Text="Shelf:" Width="125px"></asp:Label>
                    <asp:TextBox ID="Shelf" runat="server" CssClass="TextBox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="" Width="140px"></asp:Label>
                    <asp:Button ID="Done" runat="server" Text="Done" CssClass="Button" OnClientClick="conf('Confirm The Details');"
                        OnClick="Done_Click" />
                    <asp:Button ID="Change" runat="server" Text="Make Changes" CssClass="Button" OnClick="Change_Click"
                        Visible="false" />
                    <asp:Button ID="Confirm" runat="server" Text="Confirm" CssClass="Button" Visible="false"
                        OnClick="Confirm_Click" />
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
