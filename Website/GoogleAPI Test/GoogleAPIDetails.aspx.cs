using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class GoogleAPIDetails : System.Web.UI.Page
{
    public HttpWebRequest req = null;
    string ISBN = null;
    XmlTextReader xt = null;
    ArrayList author = new ArrayList();
    String final = null;
    string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ISBN = (string)Session["ISBN"];
            TextBox1.Text = ISBN;
            display_Img();
            getData();
            fillData_title();
            fillData_author();
        }
    }
    
    protected void display_Img()
    {
        string dir=(string) Session["IDirectory"];
        if (File.Exists(Request.PhysicalApplicationPath + dir + ISBN + ".jpg"))
        {
            Image1.ImageUrl = dir + ISBN + ".jpg";
        }
        else
            Image1.ImageUrl = dir + "noImage.jpg";
    }
    protected void fillData_title()
    {
        TextBox title=new TextBox();
        title.Visible = false;
        title.ID = "title";
        string txt=(string) Session["title"];
        if (txt != "")
        {
            title.Visible = true;
            title.Text = txt;
            title.ReadOnly = true;
            Label l = new Label();
            l.ID = "Label_title";
            l.Text = "Title:";
            Panel1.Controls.Add(l);
            Panel1.Controls.Add(title);
            Panel1.Controls.Add(new LiteralControl("<br /><br />"));
        }
    }
    protected void fillData_author()
    {
        ArrayList temp = (ArrayList)Session["author"];
        int count = temp.Count;
        string[] xyz = new string[count];
        temp.CopyTo(xyz);
        for (int i = 0; i < count; i++)
        {
            TextBox tb = new TextBox();
            Label lb = new Label();
            LiteralControl lc = new LiteralControl();
            lc.ID = "lc" + i;
            lc.Text = "<br />";
            tb.ID = "tb" + i;
            lb.Text = "Author " + (i + 1) + ":";
            tb.ReadOnly = true;
            tb.Text = xyz[i];
            Panel1.Controls.Add(lb);
            Panel1.Controls.Add(tb);
            Panel1.Controls.Add(lc);
        }
    }
    protected void getData()
    {
        try
        {
            final = "http://www.google.com/books/feeds/volumes?q=ISBN" + ISBN;
            xt = new XmlTextReader(final);

            while (xt.Read())
            {
                if (xt.Name == "dc:creator")
                {
                    author.Add(xt.ReadString());
                }
                if (xt.Name == "dc:title")
                    title = xt.ReadString();
            }
            //if(author!=null && title!=null && title!="")
            Session["title"] = title;
            Session["author"] = author;
        }
        catch (Exception) { }
    }
    protected void addAuthor_Click(object sender, EventArgs e)
    {

    }
}

        