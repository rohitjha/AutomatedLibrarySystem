using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class About : System.Web.UI.Page
{
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
    protected SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();

    int pageIndex;
    int startIndex;
    int endIndex;
    int pageSize = 1;
    int totPages;

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
    }

    private void BindGrid()
    {
        string cmd = "SELECT username [UserName],hash [Password Hash], auth_level [Authentication Level] FROM LOGIN";
        DataSet ds = new DataSet();
        SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
        SqlConnection.Open();
        SqlCommand = new SqlCommand(cmd, SqlConnection);
        SqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(SqlCommand);

        SqlDataAdapter.Fill(ds, "tblMain");
        int totRecs = ds.Tables["tblMain"].Rows.Count;
        SqlDataAdapter.Fill(ds, startIndex, pageSize, "t1");
        
        GridView1.DataSource = ds.Tables["t1"];
        GridView1.DataBind();
        SqlDataAdapter.Dispose();
        SqlCommand.Dispose();

        System.Text.StringBuilder sbPager = new System.Text.StringBuilder();
        for (int i = 1; i <= totPages; i++)
        {
            sbPager.Append("<a href=\"About.aspx?pg=").Append(i.ToString()).Append("\">").Append(i.ToString()).Append("</a>");
            sbPager.Append("&nbsp;|&nbsp;");
        }

        divPager.InnerHtml = sbPager.ToString();
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}