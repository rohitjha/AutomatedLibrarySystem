using System;
using System.Web;

public partial class Staff_ManualAddBook : System.Web.UI.Page
{
    int x = 0;
    string authors = null;
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
            ViewState["butncount"] = (int)0;
            if (x == 0)
            {
                string guidResult = System.Guid.NewGuid().ToString();
                guidResult = guidResult.Replace("-", string.Empty);
                guidResult = guidResult.Substring(0, 10);
                ViewState["guid"] = (string)guidResult;
                x++;
            }
            BookID.Text = (string)ViewState["guid"];
            author.InnerHtml += "<span id=\"auths\" style=\"display:inline-block;width:129px;\" />Authors:</span>";
            author.InnerHtml += "<input type=\"text\" class=\"TextBox\" name=\"author0\" />";
        }
        Welcome.Text = "Welcome " + (string)Session["Username"];
    }
    protected void AddAuthor_Click(object sender, EventArgs e)
    {
        int x = (int)ViewState["butncount"] + 1;
        ViewState["butncount"] = (int)x;
        if (authors != null && authors != "")
        {
            string[] aut = authors.Split('~');
            author.InnerHtml += "<br/><span id=\"TitleLabel" + x.ToString() + "\" style=\"display:inline-block;width:129px;\"></span><input type=\"text\" class=\"TextBox\" name=\"author" + x + " value=\"" + aut[x] + "\" />";
        }
        else
        {
            author.InnerHtml += "<br/><span id=\"TitleLabel" + x.ToString() + "\" style=\"display:inline-block;width:129px;\"></span><input type=\"text\" class=\"TextBox\" name=\"author" + x + "\" />";
        }
    }
    protected void Done_Click(object sender, EventArgs e)
    {
        //control = 1;
        RfidError.Visible = false;
        TitleError.Visible = false;
        if ((Rfid.Text == "" || Rfid.Text == null) && (Title.Text == "" || Title.Text == null))
        {
            RfidError.Visible = true;
            TitleError.Visible = true;
        }
        else
            if (Title.Text == "" || Title.Text == null)
                TitleError.Visible = true;
            else
                if (Rfid.Text == "" || Rfid.Text == null)
                    RfidError.Visible = true;
                else
                {
                    author.InnerHtml = "<span id=\"auths\" style=\"display:inline-block;width:129px;\" />Authors:</span>";
                    for (int x = 0; x <= (int)ViewState["butncount"]; x++)
                    {
                        string locauth = Request.Form["author" + x.ToString()];
                        if (locauth != null && locauth != "")
                        {
                            authors += locauth + "~";
                            if (x != 0)
                            {
                                author.InnerHtml += "<span id=\"authspac" + x.ToString() + "\" style=\"display:inline-block;width:129px;\"/></span>";
                            }
                            author.InnerHtml += "<input name=\"author" + x.ToString() + "\" class=\"TextBox\" readonly=\"readonly\" type=\"text\" value=\"" + locauth + "\" /></span><br/>";
                        }
                    }
                    AddAuthor.Visible = false;
                    Done.Visible = false;
                    Rfid.ReadOnly = true;
                    ISBN10.ReadOnly = true;
                    ISBN13.ReadOnly = true;
                    Title.ReadOnly = true;
                    SubTitle.ReadOnly = true;
                    Publisher.ReadOnly = true;
                    PublishedDate.ReadOnly = true;
                    Description.ReadOnly = true;
                    Section.ReadOnly = true;
                    Shelf.ReadOnly = true;
                    Confirm.Visible = true;
                    Change.Visible = true;
                    ViewState["madAuthors"] = (string)authors;
                }
    }
    protected void Confirm_Click(object sender, EventArgs e)
    {

    }
    protected void Change_Click(object sender, EventArgs e)
    {
        author.InnerHtml = "<span id=\"auths\" style=\"display:inline-block;width:129px;\" />Authors:</span>";
        string[] localauth = ((string)ViewState["madAuthors"]).Split('~');
        for (int x = 0; x < localauth.Length - 1; x++)
        {
            if (x != 0)
            {
                author.InnerHtml += "<span id=\"authspac" + x.ToString() + "\" style=\"display:inline-block;width:129px;\"/></span>";
            }
            author.InnerHtml += "<input name=\"author" + x.ToString() + "\" class=\"TextBox\" type=\"text\" value=\"" + localauth[x] + "\" /></span><br/>";
        }
        Done.Visible = true;
        Rfid.ReadOnly = false;
        ISBN10.ReadOnly = false;
        ISBN13.ReadOnly = false;
        Title.ReadOnly = false;
        SubTitle.ReadOnly = false;
        Publisher.ReadOnly = false;
        PublishedDate.ReadOnly = false;
        Description.ReadOnly = false;
        Section.ReadOnly = false;
        Shelf.ReadOnly = false;
        Confirm.Visible = false;
        Change.Visible = false;
        AddAuthor.Visible = true;
    }
}