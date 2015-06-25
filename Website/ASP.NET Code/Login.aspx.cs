using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;

public partial class _Default : System.Web.UI.Page
{
    protected string username, password;
    protected int passhash;
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
    protected Boolean result = false;

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["Auth"] != null)
        {

            if ((int)Session["Auth"] == 2)
                Response.Redirect("/Staff/StaffHome.aspx");
            else
                if ((int)Session["Auth"] == 1)
                    Response.Redirect("/Customer/CustomerHome.aspx");

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Auth"] = (int)0;
        }
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserNameError.Visible = false;
        PasswordError.Visible = false;
        UserPassWrong.Visible = false;
        int p = 0;
        if (UserNameTextbox.Text == null || UserNameTextbox.Text == "")
            UserNameError.Visible = true;
        if (PasswordTextBox.Text == null || PasswordTextBox.Text == "")
            PasswordError.Visible = true;
        if (!(UserNameTextbox.Text == null || UserNameTextbox.Text == "") && !(PasswordTextBox.Text == null || PasswordTextBox.Text == ""))
        {
            username = UserNameTextbox.Text;
            password = PasswordTextBox.Text;
            passhash = password.GetHashCode();
            p = is_auth(username, passhash);
            //Response.Write(p);
            if (p == 0)
            {
                UserPassWrong.Visible = true;
                Label2.Visible = true;
            }
            else
            {
                Session["Username"] = (string)username;
                Session["PassHash"] = (string)passhash.ToString();
                if (p == 1)
                {
                    Session["Auth"] = (int)1;
                    Response.Redirect("/Customer/CustomerHome.aspx");
                }
                else
                    if (p == 2)
                    {
                        Session["Auth"] = (int)2;
                        Response.Redirect("/Staff/StaffHome.aspx");
                    }
            }
        }
    }
    protected int is_auth(string user_name, int passwordhash)
    {
        int x = 0, authlevel = 0;
        int passhashstring = 0;
        try
        {
            passhashstring = passwordhash;
            string cmd = "SELECT COUNT(*) FROM LOGIN WHERE username='" + (string)user_name + "' and hash=" + (int)passhashstring;
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            SqlCommand = new SqlCommand(cmd, SqlConnection);
            x = (int)SqlCommand.ExecuteScalar();
            if (x > 0)
            {
                cmd = "SELECT auth_level FROM LOGIN WHERE username='" + (string)user_name + "' and hash=" + (int)passhashstring;
                SqlCommand = new SqlCommand(cmd, SqlConnection);
                authlevel = (int)SqlCommand.ExecuteScalar();
                //Response.Write(authlevel);
                /*
                 * If Exists(SELECT AuthLevel FROM T1 WHERE username='' and hash='')
                 *      SELECT AuthLevel FROM T1 WHERE username='' and hash=''
                 * else
                 *      Select 0
                 */
            }
        }
        catch (SqlException se)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            SqlConnection.Close();
            SqlConnection.Dispose();
            SqlCommand.Dispose();
        }
        if (x > 0 && (authlevel == 2))
            //Response.Write(authlevel);
            return 2;
        else
            if (x > 0 && (authlevel == 1))
                return 1;
            else
                return 0;
    }
}