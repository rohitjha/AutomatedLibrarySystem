using System;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class Customer_BookDetails : System.Web.UI.Page
{
    protected string book_id = null;
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
            putScript();
        }
    }
    protected void get_value(object sender, EventArgs e)
    {
        PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Title:</span>" + HiddenTitle.Value));
        string[] auth = HiddenAuthors.Value.Split('%');
        if (auth[0] != null)
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Authors:</span>" + auth[0]));
        for (int i = 1; i < auth.Length - 1; i++)
        {
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\"></span>" + auth[i]));
        }
        if (HiddenISBN.Value != null || HiddenISBN.Value != "")
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">ISBN:</span>" + HiddenISBN.Value));
        string[] pub = HiddenPublisher.Value.Split('~');
        if (pub[0] != null || pub[0] != "")
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Publisher:</span>" + pub[0]));
        if (pub[1] != null || pub[1] != "")
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Published Date:</span>" + pub[1]));
        if (HiddenDesc.Value != null || HiddenDesc.Value != "")
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Description:</span><p style=\"width:400px;word-wrap:break-word;white-space:pre-line;\">" + HiddenDesc.Value+"</p>"));
        /*if (HiddenDesc.Value != null || HiddenDesc.Value != "")
        {
            if (HiddenDesc.Value.Length < 100)
                PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Description:</span>" + HiddenDesc.Value));
            else
            {
                PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Description:</span>" + HiddenDesc.Value.Substring(0, 100)));
                int i = 100;
                while (i < HiddenDesc.Value.Length-100)
                {
                    PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\"></span>" + HiddenDesc.Value.Substring(i, 100)));
                    i += 100;
                }
                PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\"></span>" + HiddenDesc.Value.Substring(i, HiddenDesc.Value.Length - i)));
            }
        }*/
        string[] ratings = HiddenRatings.Value.Split('~');
        if (ratings[0] != null || ratings[1] != "")
        {
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">Ratings:</span>" + ratings[0]));
            PanelPrimary.Controls.Add(new LiteralControl("<br/><span style=\"display:inline-block;height:20px;width:100px;\">No of Ratings:</span>" + ratings[1]));
        }
        StringBuilder ima = new StringBuilder("http://bks2.books.google.com/books?id=");
        ima.Append(Request.QueryString["id"].ToString());
        ima.Append("&printsec=frontcover&img=1&zoom=1&source=gbs_api");
        PanelSecondary.Controls.Add(new LiteralControl("</br><img class=\"image\" src=\"" + ima + "\" /><br /><br /><div class=\"divBorder\" />"));
    }
    protected void putScript()
    {
        StringBuilder main = new StringBuilder();
        main.Append("<script  src=\"");
        main.Append("https://www.googleapis.com/books/v1/volumes/");
        main.Append(Request.QueryString["id"].ToString() + "?&callback=handleResponse");
        main.Append("\"></script>");
        PanelPrimary.Controls.Add(new LiteralControl(main.ToString()));
    }
    protected void preview_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Customer/Preview.aspx?isbn="+ HiddenISBN.Value+"&title="+HiddenTitle.Value.ToString().Replace(' ','_'));
    }
}