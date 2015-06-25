<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Image Search</title>
    <link rel="Stylesheet" type="text/css" href="CSS/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="header">
        <h1>Google Book Image Search</h1>
        <h2>By Authors</h2>
        </div>
        <div id="menu">
		<ul>
			<li class="first"><a href="#" accesskey="1" title="">Home</a></li>
			<li><a href="#" accesskey="2" title="">About Us</a></li>
			<li><a href="#" accesskey="3" title="">Products</a></li>
			<li><a href="#" accesskey="4" title="">Services</a></li>
			<li><a href="#" accesskey="5" title="">Contact Us</a></li>
		</ul>
	    </div>
        <div id="content">
	    <div id="xbg1"></div>
		<div id="primaryContentContainer">
			<div id="primaryContent">
		    
        <asp:Image ID="Image1" runat="server"   Height="300px" style="margin-right: 0px" 
            Width="300px" />
        <asp:Button ID="button2" runat="server" Text="Button" Visible="False" 
            onclick="button2_Click" CssClass="Button" />
        <br />
        <asp:TextBox ID="textBox1" runat="server" Width="311px"></asp:TextBox>
        <asp:Button ID="button1" runat="server" onclick="button1_Click" Text="Button" 
            Width="93px" CssClass="Button" />
         <asp:Button ID="Button3" class="Button" runat="server" Text="Next page" 
        onclick="Button3_Click"  />
        </div>  
    </div>
    </div>
    <div class="clear"></div>
    <div id="footer">
		<p>Copyright &copy; 2006 Sitename.com. Designed by <a href="http://www.csstemplatesforfree.com">CSS Templates For Free</a></p>
	</div>
    </div>
    </form>
</body>
</html>
