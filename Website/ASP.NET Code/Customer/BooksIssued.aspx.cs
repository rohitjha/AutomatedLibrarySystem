using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

public partial class Customer_BooksIssued : System.Web.UI.Page
{
    protected SqlCommand SqlCommand = null;
    protected SqlConnection SqlConnection = null;
    protected SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();

    int startIndex = 0;
    int pageIndex;
    int endIndex;
    int pageSize = 10;
    int totPages;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            if ((int)Session["Auth"] != 1)
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

            if (Request.QueryString["pg"] != null)
                BindGrid();
        }
        Welcome.Text = "Welcome " + (string)Session["Username"];
    }

    private void BindGrid()
    {
        backtable.InnerHtml = "<table><tr><th>Title</th><th>Authors</th><th>Issue Date</th><th>Return Date</th></tr>";
        secondaryContent.InnerHtml = "<br /><br /><br/><br/><br/>";
        try
        {
            DataSet ds = new DataSet();
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            string cmd = "Select num FROM CARD WHERE username='" + (string)Session["Username"] + "'";
            SqlCommand = new SqlCommand(cmd, SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(ds, "temp");
            string st = (ds.Tables["temp"].Rows[0][0]).ToString();
            cmd = "SELECT BI.Book_id, BI.Title, BI.Authors, CONVERT(Varchar(19),CO.since,100) [Since], CONVERT(varchar(19),CO.until,100) [Until] FROM Checkout CO, BookInfo BI, Book B WHERE CO.Num = '" + st + "' AND CO.BID = B.BID AND B.book_id =BI.Book_id order by CO.since desc";
            SqlCommand = new SqlCommand(cmd, SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(ds, "tblMain");
            int totRecs = ds.Tables["tblMain"].Rows.Count;
            totPages = (int)totRecs / pageSize;
            SqlDataAdapter.Fill(ds, startIndex, pageSize, "t1");

            for (int i = 0; i < pageSize && i < totRecs; i++)
            {
                StringBuilder ima = new StringBuilder("http://bks2.books.google.com/books?id=");
                if (ds.Tables["t1"].Rows[i][0] != null)
                    ima.Append((ds.Tables["t1"].Rows[i][0]).ToString());
                ima.Append("&printsec=frontcover&img=1&zoom=1&source=gbs_api");
                secondaryContent.InnerHtml += "<img class=\"image\" src=\"" + ima + "\" /><br/><br/><div class=\"divborder\"></div><br/></img>";
                StringBuilder row = new StringBuilder();
                row.Append("<tr style=\"height:227px\"");
                if (i % 2 == 0)
                    row.Append("class=\"rowA\" >");
                else
                    row.Append("class=\"rowB\" >");
                for (int j = 1; j < 5; j++)
                {
                    row.Append("<td ");
                    if (j == 2)
                    {
                        row.Append("style=\"white-space:no-wrap;\" >");
                        string[] auth = ((ds.Tables["t1"].Rows[i][j]).ToString()).Split('%');
                        for (int x = 0; x < auth.Length - 1; x++)
                            if (auth.Length > 2)
                                row.Append((x + 1) + ". " + auth[x] + "<br/>");
                            else
                                row.Append(auth[x] + "<br/>");
                    }
                    else
                    {
                        row.Append("style=\"white-space:pre-wrap;\">");
                        row.Append(ds.Tables["t1"].Rows[i][j]).Append("</td>");
                    }
                }
                row.Append("</tr>");
                backtable.InnerHtml += row.ToString();
            }
            backtable.InnerHtml += "</table>";
        }
        catch (SqlException se)
        {
        }
        finally
        {
            SqlDataAdapter.Dispose();
            SqlCommand.Dispose();
        }
        System.Text.StringBuilder sbPager = new System.Text.StringBuilder();
        for (int i = 1; i <= totPages; i++)
        {
            sbPager.Append("<a href=\"BooksIssued.aspx?pg=").Append(i.ToString()).Append("\">").Append(i.ToString()).Append("</a>");
            sbPager.Append("&nbsp;|&nbsp;");
        }

        divPager.InnerHtml = sbPager.ToString();
    }
}