<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="BookDetails.aspx.cs"
    Inherits="Customer_BookDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Details</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <script type="text/javascript">
        function handleResponse(item) {
            if (item.volumeInfo.title != null)
                document.getElementById("HiddenTitle").value = item.volumeInfo.title;
            else
                document.getElementById("HiddenTitle").value = "";
            if (item.volumeInfo.authors != null) {
                for (var j = 0; j < item.volumeInfo.authors.length; j++) {
                    if (j == 0)
                        document.getElementById("HiddenAuthors").value = "";
                    var aut = item.volumeInfo.authors[j];
                    document.getElementById("HiddenAuthors").value += aut + "%";
                }
            }
            var control = 0;
            if (item.volumeInfo.industryIdentifiers != null) {
                for (var k = 0; k < item.volumeInfo.industryIdentifiers.length; k++) {
                    if (item.volumeInfo.industryIdentifiers[k].type == "ISBN_13") {
                        document.getElementById("HiddenISBN").value = item.volumeInfo.industryIdentifiers[k].identifier;
                        control = 1;
                    }
                }
                if (control == 0)
                    document.getElementById("HiddenISBN").value = "";
            }
            if (item.volumeInfo.publisher != null)
                document.getElementById("HiddenPublisher").value = item.volumeInfo.publisher;
            else
                document.getElementById("HiddenPublisher").value = "";
            document.getElementById("HiddenPublisher").value += "~";
            if (item.volumeInfo.publishedDate != null)
                document.getElementById("HiddenPublisher").value += item.volumeInfo.publishedDate;
            else
                document.getElementById("HiddenPublisher").value += "";
            if (item.volumeInfo.description != null) {
                document.getElementById("HiddenDesc").value = item.volumeInfo.description;
                document.getElementById("HiddenDesc").value = document.getElementById("HiddenDesc").value.replace(/\u003cp/gi, "~");
                document.getElementById("HiddenDesc").value = document.getElementById("HiddenDesc").value.replace(/\u003e/gi, "~");
            }
            else
                document.getElementById("HiddenDesc").value = "";
            if (item.volumeInfo.averageRating != null)
                document.getElementById("HiddenRatings").value = item.volumeInfo.averageRating;
            else
                document.getElementById("HiddenRatings").value = "";
            document.getElementById("HiddenRatings").value += "~";
            if (item.volumeInfo.ratingsCount != null)
                document.getElementById("HiddenRatings").value += item.volumeInfo.ratingsCount;
            else
                document.getElementById("HiddenRatings").value += "";
            if (item.volumeInfo.categories != null) {
                for (var k = 0; k < item.volumeInfo.categories.length; k++) {
                    if (k == 0)
                        document.getElementById("HiddenCategories").value = "";
                    if (item.volumeInfo.categories[k] != null)
                        document.getElementById("HiddenCategories").value += item.volumeInfo.categories[k];
                    else
                        document.getElementById("HiddenCategories").value += "";
                    document.getElementById("HiddenCategories").value += "~";
                }
            }
            else
                document.getElementById("HiddenCategories").value = "";
            var butn = document.getElementById("forJavaScriptButton");
            butn.click();
        } 
    </script>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="header">
            <h1>
                Book Details</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label></h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Customer/CustomerHome.aspx" accesskey="1" title="">Home</a></li>
                <li><a href="BooksIssued.aspx?pg=1" accesskey="2" title="">History</a></li>
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
                    <h2>
                        Book Details</h2>
                    <br />
                    <asp:HiddenField ID="HiddenTitle" runat="server" />
                    <asp:HiddenField ID="HiddenAuthors" runat="server" />
                    <asp:HiddenField ID="HiddenISBN" runat="server" />
                    <asp:HiddenField ID="HiddenPublisher" runat="server" />
                    <asp:HiddenField ID="HiddenDesc" runat="server" />
                    <asp:HiddenField ID="HiddenRatings" runat="server" />
                    <asp:HiddenField ID="HiddenCategories" runat="server" />
                    <asp:Button ID="forJavaScriptButton" OnClick="get_value" runat="server" CssClass="clickButton"
                        Text="" />
                    <asp:Panel ID="PanelPrimary" runat="server">
                    </asp:Panel>
                    <asp:Button ID="preview" runat="server" Text="Preview" CssClass="Button" OnClick="preview_Click" />
                </div>
            </div>
            <div id="secondaryContent">
                <div style="height: 80px">
                </div>
                <asp:Panel ID="PanelSecondary" runat="server">
                </asp:Panel>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="footer">
        <p>
            Automated Library Project &copy Developed by<br />
            Amiraj Dhawan, Rohit Jha, Soumya Sharma & Divya Mahajan</p>
    </div>
    </form>
</body>
</html>
