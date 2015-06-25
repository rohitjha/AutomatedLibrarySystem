using System;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class Customer_SearchForABook : System.Web.UI.Page
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
            if ((int)Session["Auth"] != 1)
            {
                Response.Redirect("/Login.aspx");
            }
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
            //putScript();
            try
            {
                if (Session["controlsfab"] != null)
                {
                    if ((int)Session["controlsfab"] == 1)
                        putScript();
                }
            }
            catch (Exception)
            {
            }
        }
        Welcome.Text = "Welcome " + Session["Username"];
    }
    //main.Append("<script type=\"text/javascript\">");
    //main.Append("function handleResponse(response) {");
    //main.Append("for (var i = 0; i < response.items.length; i++) {");
    //main.Append("var item = response.items[i];");
    //main.Append("document.getElementById(\"content\").innerHTML += \"<br>\" + item.volumeInfo.title;}}");
    //main.Append("</script>");


    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["controlsfab"] = (int)1;
        Session["drop"] = (int)DropDownList1.SelectedIndex;
        Session["search"] = (string)TextBox1.Text.Replace(" ", "+");
        putScript();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //string title = HiddenTitle.Value;
        //string id = HiddenID.Value;
        string[] fintitle = HiddenTitle.Value.Split('~');
        string[] finid = HiddenID.Value.Split('~');
        string[] authors = HiddenAuthors.Value.Split('~');
        string[] isbn = HiddenISBN.Value.Split('~');
        string[] ratings = HiddenRating.Value.Split('~');
        string[] desc = (HiddenDesc.Value.Replace("{}", "")).Split('~');
        Session["totalItems"] = (int)Convert.ToInt32(HiddenTotalItems.Value);
        for (int i = 0; i < fintitle.Length - 1; i++)
        {
            StringBuilder ima = new StringBuilder("http://bks2.books.google.com/books?id=");
            ima.Append(finid[i]);
            ima.Append("&printsec=frontcover&img=1&zoom=1&source=gbs_api");
            string[] localauth = authors[i].Split('%');
            PanelSecondary.Controls.Add(new LiteralControl("<img class=\"image\" src=\"" + ima + "\" /><br/><br/><div class=\"divborder\"></div><br/>"));
            PanelPrimary.Controls.Add(new LiteralControl("<div id=\"primaryContent\" style=\"height:175px\">"));
            PanelPrimary.Controls.Add(new LiteralControl("<span style=\"display:inline-block;height:20px;width:80px;\">Title:</span>" + fintitle[i]));
            if (isbn[i] != "")
                PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">ISBN:</span>" + isbn[i]));
            for (int j = 0; j < localauth.Length - 1; j++)
            {
                if (j == 0)
                    PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Authors:</span>" + localauth[j]));
                else
                    PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\"></span>" + localauth[j]));
            }
            if (desc[i] != "" && desc[i] != null)
            {
                if (desc[i].Length < 97)
                    PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Description:</span>" + desc[i].Substring(0, desc.Length - 1) + "..."));
                else
                    PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Description:</span>" + desc[i].Substring(0, 100) + "..."));
            }
            if (ratings[i] == "" || ratings[i] == null)
                ratings[i] = "NA";
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:80px;\">Rating:</span>" + ratings[i] + "/5"));
            PanelPrimary.Controls.Add(new LiteralControl("<br/><INPUT TYPE=\"button\" CLASS=\"Button\" NAME=\"book" + finid[i] + "\" Value=\"More Details\" onClick=\"click2('btn" + finid[i] + "');\" />"));
            PanelPrimary.Controls.Add(new LiteralControl("<br/><INPUT TYPE=\"button\" CLASS=\"Button\" NAME=\"preview" + isbn[i] + "\" Value=\"Preview\" onClick=\"click3('" + isbn[i] + "','"+fintitle[i]+"');\" />"));
            PanelPrimary.Controls.Add(new LiteralControl("</div><div id=\"primaryContent\"><div class=\"divborder\"></div></div>"));

        }
        HiddenID.Value = null;
        HiddenTitle.Value = null;
        HiddenAuthors.Value = null;
        HiddenISBN.Value = null;
        HiddenTotalItems.Value = null;
        HiddenRating.Value = null;
        pager();
    }
    protected void putScript()
    {
        int b = (int)Session["drop"];
        StringBuilder main = new StringBuilder();
        main.Append("<script  src=\"");
        main.Append("https://www.googleapis.com/books/v1/volumes?q=");
        switch (b)
        {
            case 0:
                main.Append("intitle:");
                break;
            case 1:
                main.Append("inauthor:");
                break;
            case 2:
                main.Append("isbn:");
                break;
        }
        main.Append((string)Session["search"] + "&startIndex=" + startIndex.ToString() + "&callback=handleResponse");
        main.Append("\"></script>");
        //if(search!=null)
        PanelPrimary.Controls.Add(new LiteralControl(main.ToString()));
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
            sbPager.Append("<a href=\"SearchForABook.aspx?pg=").Append(i.ToString()).Append("\">").Append(i.ToString()).Append("</a>");
            sbPager.Append("&nbsp;|&nbsp;");
            if (i % 15 == 0)
                sbPager.Append("<br />");
        }

        divPager.InnerHtml = sbPager.ToString();
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        string forw = HiddenBtn.Value;
        forw = forw.Replace("btn", "");
        Response.Redirect("../Customer/BookDetails.aspx?id=" + forw);
    }
}