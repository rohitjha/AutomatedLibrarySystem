using System;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class Staff_ConfirmNewBookDetails : System.Web.UI.Page
{
    protected string Book_Id = null;
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
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
        //BookId = (string)Session["AddBookID"];
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                Book_Id = (Request.QueryString["id"]).ToString();
            }
            else
            {
                Book_Id = "";
            }
            // temp.Text = book_id;
            Welcome.Text = "Welcome " + (string)Session["Username"];
            try
            {
                StringBuilder volumeDetails = new StringBuilder("<script  src=\"");
                volumeDetails.Append("https://www.googleapis.com/books/v1/volumes/");
                volumeDetails.Append(Book_Id);
                volumeDetails.Append("?&callback=handleResponse");
                volumeDetails.Append("\"></script>");
                ConfirmNewBookDetailsPanel.Controls.Add(new LiteralControl(volumeDetails.ToString()));
            }
            catch (Exception e1)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + e1.Message.Replace("'", "") + "');", true);
            }
        }
    }

    protected void forJavaScriptButton_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder imageLink = new StringBuilder("http://bks2.books.google.com/books?id=");
            imageLink.Append(Request.QueryString["id"].ToString());
            imageLink.Append("&printsec=frontcover&img=1&zoom=1&source=gbs_api");
            secondaryContent.InnerHtml = "<br/><br/><br/><br/></br><img class=\"image\" src=\"" + imageLink + "\" />";
            TextBox1.Text = Request.QueryString["id"].ToString();
        }
        catch (Exception e2)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + e2.Message.Replace("'", "") + "');", true);
        }
        TextBox2.Text = HiddenTitle.Value;
        if (HiddenSubtit.Value == "" || HiddenSubtit.Value == null)
            subtit.ReadOnly = false;
        else
            subtit.Text = HiddenSubtit.Value;
        string[] auth = (HiddenAuthors.Value).Split('%');
        authors.InnerHtml = "";
        for (int i = 0; i < auth.Length - 1; i++)
        {
            authors.InnerHtml += "<span style=\"display:inline-block;height:20px;width:80px;\"></span><input class=\"TextBox\" type=\"text\" name=\"auth" + i + "\" value=\"" + auth[i] + "\" readonly=\"readonly\" /><br/>";
        }
        TextBox4.Text = HiddenPublisher.Value;
        TextBox5.Text = HiddenDesc.Value;
        TextBox6.Text = HiddenISBN.Value;
        string[] cate = HiddenCategories.Value.Split('~');
        cat.InnerHtml = "";
        for (int i = 0; i < cate.Length - 1; i++)
        {
            cat.InnerHtml += "<span style=\"display:inline-block;height:20px;width:80px;\"></span><input class=\"TextBox\" type=\"text\" name=\"category" + i + "\" value=\"" + cate[i] + "\" readonly=\"readonly\" /><br/>";
        }
        string[] x = HiddenRatings.Value.Split('~');
        TextBox8.Text = x[0];
        nr.Text = x[1];
        if (HiddenPage.Value == "" || HiddenPage.Value == null)
            pc.ReadOnly = false;
        else
            pc.Text = HiddenPage.Value;
    }
    protected void btn1_click(object sender, EventArgs e)
    {
        int x = 0;
        StringBuilder cmd = new StringBuilder();
        string[] pub = HiddenPublisher.Value.Split('~');
        string[] y = HiddenRatings.Value.Split('~');
        try
        {
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            cmd.Append("Select count(*) from BookInfo where Book_id='" + Request.QueryString["id"].ToString() + "'");
            SqlCommand = new SqlCommand(cmd.ToString(), SqlConnection);
            x = Convert.ToInt16(SqlCommand.ExecuteScalar());
        }
        catch (SqlException se1)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se1.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            SqlCommand.Dispose();
        }
        if (x == 0)
        {
            string cateo = HiddenCategories.Value;
            if (cateo.Length > 2000)
                cateo = cateo.Substring(0, 1999);
            string desci = HiddenDesc.Value;
            if (desci.Length>8000)
                desci = desci.Substring(0, 7990) + "...";
            cmd = new StringBuilder("INSERT INTO BookInfo VALUES ('" + Request.QueryString["id"].ToString().Replace("'", "") + "','" + TextBox6.Text.Replace("'", "") + "','" + TextBox2.Text.Replace("'", "") + "','" + subtit.Text.Replace("'", "") + "','" + HiddenAuthors.Value.Replace("'", "") + "','" + pub[0].Replace("'", "") + "','" + pub[1].Replace("'", "") + "','" + HiddenPage.Value.Replace("'", "") + "','" + cateo.Replace("'", "") + "'," + y[0].Replace("'", "") + "," + y[1].Replace("'", "") + ",'" + desci.Replace("'", "") + "')");
            try
            {
                SqlCommand = new SqlCommand(cmd.ToString(), SqlConnection);
                SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException se2)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se2.Message.Replace("'", "") + "');", true);
            }
        }
        try
        {
            cmd = new StringBuilder("INSERT INTO Book VALUES ('" + Request.QueryString["id"].ToString() + "','" + rfidtext.Text + "')");
            SqlCommand.Dispose();
            SqlCommand = new SqlCommand(cmd.ToString(), SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Confirm.Visible = true;
        }
        catch (SqlException se3)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se3.Message.Replace("'", "") + "');", true);
        }
    }
    protected void Rfidbtn_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("C:\\WindowsFormsApplication2.exe");
    }
}