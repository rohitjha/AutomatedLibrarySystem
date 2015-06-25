<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ConfirmNewBookDetails.aspx.cs"
    Inherits="Staff_ConfirmNewBookDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Confirm New Book Details</title>
</head>
<body>
    <script type="text/javascript">
        function handleResponse(item) {
            if (item.volumeInfo.title != null)
                document.getElementById("HiddenTitle").value = item.volumeInfo.title;
            else
                document.getElementById("HiddenTitle").value = "";
            if (item.volumeInfo.subtitle != null)
                document.getElementById("HiddenSubtit").value = item.volumeInfo.subtitle;
            else
                document.getElementById("HiddenSubtit").value = "";
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
            if (item.volumeInfo.pageCount != null)
                document.getElementById("HiddenPage").value = item.volumeInfo.pageCount;
            else
                document.getElementById("HiddenPage").value = "";
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
            // in production code, item.text should have the HTML entities escaped.
            //document.getElementById("content").innerHTML += "<br>" + item.volumeInfo.title;
            var butn = document.getElementById("forJavaScriptButton");
            butn.click();
            //            return;
        } 
        
    </script>
    <form id="form1" autocomplete="false" runat="server">
    <div id="outer">
        <div id="header">
            <h1>
                Confirm Details For A New Book</h1>
            <h2>
                <asp:Label ID="Welcome" runat="server" Text=""></asp:Label></h2>
        </div>
        <div id="menu">
            <ul>
                <li><a href="../Staff/AddANewBook.aspx" accesskey="1" title="">Add Book</a></li>
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
                    <asp:HiddenField ID="HiddenTitle" runat="server" />
                    <asp:HiddenField ID="HiddenCategories" runat="server" />
                    <asp:HiddenField ID="HiddenAuthors" runat="server" />
                    <asp:HiddenField ID="HiddenISBN" runat="server" />
                    <asp:HiddenField ID="HiddenDesc" runat="server" />
                    <asp:HiddenField ID="HiddenPublisher" runat="server" />
                    <asp:HiddenField ID="HiddenRatings" runat="server" />
                    <asp:HiddenField ID="HiddenSubtit" runat="server" />
                    <asp:HiddenField ID="HiddenPage" runat="server" />
                    <asp:Button ID="forJavaScriptButton" runat="server" Height="1px" CssClass="clickButton"
                        OnClick="forJavaScriptButton_Click" Text="" Width="1px" />
                    <asp:Panel ID="ConfirmNewBookDetailsPanel" runat="server">
                        <asp:Label ID="BookIDLabel" runat="server" Text="Book ID :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" CssClass="TextBox"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="RFID" runat="server" Text="RFID Tag :" Width="80px"></asp:Label>
                        <asp:TextBox ID="rfidtext" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv1" ErrorMessage="*Rfid Tag Required" ControlToValidate="rfidtext"
                            runat="server"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label runat="server" Width="80px"></asp:Label>
                        <asp:Button ID="Rfidbtn" runat="server" Text="Get RFID Code" CssClass="Button" 
                             CausesValidation="false" OnClick="Rfidbtn_Click" />
                        <br />
                        <br />
                        <asp:Label ID="TitleLabel" runat="server" Text="Title :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" CssClass="TextBox"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="Subtitle" runat="server" Text="Sub Title : " Width="80px"></asp:Label>
                        <asp:TextBox ID="subtit" ReadOnly="true" runat="server" CssClass="TextBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="AuthorsLabel" runat="server" Text="Authors :" Width="80px"></asp:Label>
                        <div id="authors" runat="server">
                        </div>
                        <br />
                        <asp:Label ID="PublisherLabel" runat="server" Text="Publisher :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBox"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="DescriptionLabel" runat="server" Text="Description :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" MaxLength="10000" TextMode="MultiLine"
                            Width="300px" Height="40px"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="ISBNLabel" runat="server" Text="ISBN :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="TextBox"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="CategoriesLabel" runat="server" Text="Categories :" Width="80px"></asp:Label>
                        <div id="cat" runat="server">
                        </div>
                        <br />
                        <asp:Label ID="pagecount" runat="server" Text="Page Count :" Width="80px"></asp:Label>
                        <asp:TextBox ID="pc" ReadOnly="true" runat="server" CssClass="TextBox"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="RatingsLabel" runat="server" Text="Ratings :" Width="80px"></asp:Label>
                        <asp:TextBox ID="TextBox8" ReadOnly="true" runat="server" CssClass="TextBox"></asp:TextBox><br />
                        <asp:Label ID="Ratingslab" runat="server" Text="No of Ratings :" Width="80px"></asp:Label>
                        <asp:TextBox ID="nr" ReadOnly="true" runat="server" CssClass="TextBox"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Space" runat="server" Text="" Width="140px"></asp:Label>
                        <asp:Button ID="ConfirmBook" runat="server" Text="Confirm" CssClass="Button" OnClick="btn1_click" />
                        <br />
                        <br />
                        <asp:Label ID="Confirm" runat="server" Text="Book Added Successfully!" Visible="false"></asp:Label>
                    </asp:Panel>
                </div>
            </div>
            <div id="secondaryContent" runat="server">
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
