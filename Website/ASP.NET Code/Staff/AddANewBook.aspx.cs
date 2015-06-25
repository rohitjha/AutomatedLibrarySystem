using System;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class Staff_AddANewBook : System.Web.UI.Page
{
    int startIndex = 0;
    int pageIndex;
    int endIndex;
    int pageSize = 10;
    int totPages;


    protected void Page_PreInit(Object sender, EventArgs e)
    {
        try
        {
            if ((int)Session["Auth"] != 2)
                Response.Redirect("/Login.aspx");
        }
        catch (Exception)
        {
            Response.Redirect("/Login.aspx");
        }
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.SelectedIndex = 0;
            if (Request.QueryString["pg"] != null)
            {
                pageIndex = Convert.ToInt32(Request.QueryString["pg"]);
            }
            else
            {
                pageIndex = 1;
            }
            startIndex = (pageIndex - 1) * pageSize;
            endIndex = startIndex + pageSize - 1;
            try
            {
                if (Session["controlsanb"] != null)
                {
                    if ((int)Session["controlsanb"] == 1)
                        putScript();
                }
            }
            catch (Exception)
            {
            }
        }
        Welcome.Text = "Welcome " + (string)Session["Username"];
    }
    //main.Append("<script type=\"text/javascript\">");
    //main.Append("function handleResponse(response) {");
    //main.Append("for (var i = 0; i < response.items.length; i++) {");
    //main.Append("var item = response.items[i];");
    //main.Append("document.getElementById(\"content\").innerHTML += \"<br>\" + item.volumeInfo.title;}}");
    //main.Append("</script>");


    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["drop"] = (int)DropDownList1.SelectedIndex;
        Session["controlsanb"] = (int)1;
        Session["search"] = (string)TextBox2.Text.Replace(" ", "+");
        putScript();
    }
    protected void putScript()
    {
        int b = (int)Session["drop"];
        StringBuilder main = new StringBuilder();
        main.Append("<script  src=\"");
        main.Append("https://www.googleapis.com/books/v1/volumes?q=");
        switch (b)
        {
            case 1:
                main.Append("intitle:");
                break;
            case 2:
                main.Append("inauthor:");
                break;
            case 0:
                main.Append("isbn:");
                break;
        }
        main.Append((string)Session["search"] + "&startIndex=" + startIndex.ToString() + "&callback=handleResponse");
        main.Append("\"></script>");
        PanelPrimary.Controls.Add(new LiteralControl(main.ToString()));
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string[] fintitle = HiddenTitle.Value.Split('~');
        string[] finid = HiddenID.Value.Split('~');
        string[] authors = HiddenAuthors.Value.Split('~');
        string[] isbn = HiddenISBN.Value.Split('~');
        Session["totalItems"] = (int)Convert.ToInt32(HiddenTotalItems.Value);
        if (fintitle != null)
        {
            for (int i = 0; i < fintitle.Length - 1; i++)
            {
                StringBuilder ima = new StringBuilder("http://bks2.books.google.com/books?id=");
                ima.Append(finid[i]);
                ima.Append("&printsec=frontcover&img=1&zoom=1&source=gbs_api");
                string[] localauth = authors[i].Split('%');
                PanelSecondary.Controls.Add(new LiteralControl("<img class=\"image\" src=\"" + ima + "\" /><br/><br/><div class=\"divborder\"></div><br/>"));
                PanelPrimary.Controls.Add(new LiteralControl("<div id=\"primaryContent\" style=\"height:173px\">"));
                if (isbn[i] != "")
                    PanelPrimary.Controls.Add(new LiteralControl("<span style=\"display:inline-block;height:20px;width:80px;\">ISBN:</span>" + isbn[i]));
                PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Title:</span>" + fintitle[i]));
                for (int j = 0; j < localauth.Length - 1; j++)
                {
                    if (j == 0)
                        PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Authors:</span>" + localauth[j]));
                    else
                        PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\"></span>" + localauth[j]));
                }
                PanelPrimary.Controls.Add(new LiteralControl("<br/><br/><span style=\"display:inline-block;height:20px;width:280px;\"></span><INPUT TYPE=\"button\" CLASS=\"Button\" NAME=\"book" + finid[i] + "\" Value=\"Add This Book\" onClick=\"click1('book" + finid[i] + "');\" /> </div><div id=\"primaryContent\"><div class=\"divborder\"></div></div>"));
            }
        }
        HiddenID.Value = null;
        HiddenTitle.Value = null;
        HiddenAuthors.Value = null;
        HiddenISBN.Value = null;
        pager();
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        string str = HiddenBtnID.Value;
        str = str.Replace("book", "");
        //Session["AddBookID"] = (string)str;
        Response.Redirect("/Staff/ConfirmNewBookDetails.aspx?id="+str);
    }

    protected void pager()
    {
        int totRecs = (int)Session["totalItems"];
        totPages = totRecs / pageSize;

        if (totRecs % pageSize != 0)
            totPages = totPages + 1;
        System.Text.StringBuilder sbPager = new System.Text.StringBuilder();
        for (int i = 1; i <= totPages; i++)
        {
            sbPager.Append("<a href=\"AddANewBook.aspx?pg=").Append(i.ToString()).Append("\">").Append(i.ToString()).Append("</a>");
            sbPager.Append("&nbsp;|&nbsp;");
            if (i % 15 == 0)
                sbPager.Append("<br />");
        }
        divPager.InnerHtml = sbPager.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["drop"] = DropDownList1.SelectedIndex;
    }
}