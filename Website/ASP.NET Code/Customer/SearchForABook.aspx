<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchForABook.aspx.cs" ValidateRequest="false" Inherits="Customer_SearchForABook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Search For A Book</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function click2(res) {
            var b = document.getElementById("Button3");
            document.getElementById("HiddenBtn").value = res;
            b.click();
        }
        function click3(res, title) {
            title=title.split(" ").join("_");
            var loc = "/Customer/Preview.aspx?isbn=" + res.toString() + "&title=" + title.toString();
            window.location=loc;
        }
    </script>
</head>
<body>
    <script type="text/javascript">
        function handleResponse(response) {
            if (response.totalItems != null) {
                document.getElementById("HiddenTotalItems").value = response.totalItems;
            }
            if (response.items != null) {
                for (var i = 0; i < response.items.length; i++) {
                    var item = response.items[i];
                    if (item.volumeInfo.title != null)
                        document.getElementById("HiddenTitle").value += item.volumeInfo.title + "~";
                    else
                        document.getElementById("HiddenTitle").value += "~";
                    if (item.id != null)
                        document.getElementById("HiddenID").value += item.id + "~";
                    else
                        document.getElementById("HiddenID").value += "~";
                    if (item.volumeInfo.authors != null) {
                        for (var j = 0; j < item.volumeInfo.authors.length; j++) {
                            var aut = item.volumeInfo.authors[j];
                            document.getElementById("HiddenAuthors").value += aut + "%";
                        }
                    }
                    document.getElementById("HiddenAuthors").value += "~";
                    if (item.volumeInfo.description != null) {
                        var ex = item.volumeInfo.description;
                        document.getElementById("HiddenDesc").value += ex + "~";
                    }
                    else
                        document.getElementById("HiddenDesc").value += "~";

                    var control = 0;
                    if (item.volumeInfo.industryIdentifiers != null) {
                        for (var k = 0; k < item.volumeInfo.industryIdentifiers.length; k++) {
                            if (item.volumeInfo.industryIdentifiers[k].type == "ISBN_13") {
                                document.getElementById("HiddenISBN").value += item.volumeInfo.industryIdentifiers[k].identifier + "~";
                                control = 1;
                            }
                        }
                        if (control == 0)
                            document.getElementById("HiddenISBN").value += "~";
                    }
                    if (item.volumeInfo.averageRating != null)
                        document.getElementById("HiddenRating").value += item.volumeInfo.averageRating;
                    else
                        document.getElementById("HiddenRating").value += "";
                    document.getElementById("HiddenRating").value += "~";

                }
                // in production code, item.text should have the HTML entities escaped.
                //document.getElementById("content").innerHTML += "<br>" + item.volumeInfo.title;
            }
            else
                alert("No Such Book Found");
            var btn1 = document.getElementById("btn");
            btn1.click();
        }
    </script>
    <form id="form1" runat="server" autocomplete="off">
    <div id="outer">
        <div id="header">
            <h1>
                Search For A Book</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server"></asp:Label></h2>
                <asp:HiddenField ID="HiddenBtn" runat="server" />
            <asp:HiddenField ID="HiddenTitle" runat="server" />
            <asp:HiddenField ID="HiddenID" runat="server" />
            <asp:HiddenField ID="HiddenSubtitle" runat="server" />
            <asp:HiddenField ID="HiddenRating" runat="server" />
            <asp:HiddenField ID="HiddenAuthors" runat="server" />
            <asp:HiddenField ID="HiddenISBN" runat="server" />
            <asp:HiddenField ID="HiddenDesc" runat="server" />
            <asp:HiddenField ID="HiddenTotalItems" runat="server" />
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Customer/CustomerHome.aspx" accesskey="1" title="">Home</a></li>
                <li><a href="../Customer/BooksIssued.aspx?pg=1" accesskey="2" title="">History</a></li>
                <li><a href="Search.aspx" accesskey="3" title="">Search Book</a></li>
                <li><a href="../Logout.aspx" accesskey="4" title="">Logout</a></li>
            </ul>
        </div>
        <div id="content">
            <div id="xbg1">
            </div>
            <div id="primaryContentContainer">
                <div id="primaryContent">
                    <asp:Label ID="Label1" runat="server" Text="Search" Width="65px"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="space1" runat="server" Text="" Width="10px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="in" Width="30px"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FAE2BF" ForeColor="Black"
                        Width="90px">
                        <asp:ListItem Value="Title" Selected="True">Title</asp:ListItem>
                        <asp:ListItem Value="Author">Author</asp:ListItem>
                        <asp:ListItem Value="ISBN">ISBN</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Space" runat="server" Text="" Width="170px"></asp:Label>
                    <asp:Button ID="Button2" runat="server" Width="60px" CssClass="Button" Text="Search"
                        OnClick="Button2_Click" />
                    <asp:Button ID="btn" runat="server" OnClick="Button3_Click" Height="1px" Width="1px"
                        Text="" CssClass="clickButton" />
                    <br />
                    <br />
                    <div class="divborder">
                    </div>
                </div>
                <asp:Panel ID="PanelPrimary" runat="server">
                </asp:Panel>
                <div id="primaryContent">
                    <div id="divPager" runat="server" style="float: left;">
                    </div>
                </div>
            </div>
            <div id="secondaryContent">
                <div style="height: 102px">
                </div>
                <asp:Panel ID="PanelSecondary" runat="server">
                </asp:Panel>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="footer">
            <p>
                <asp:Button ID="Button3" OnClick="Button3_Click1"  runat="server" Text="Button" CssClass="clickButton" />
                Automated Library Project &copy Developed by<br />
                Amiraj Dhawan, Rohit Jha, Soumya Sharma & Divya Mahajan</p>
        </div>
    </div>
    </form>
</body>
</html>
