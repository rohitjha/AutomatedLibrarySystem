using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class ChangePassword : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
    StringBuilder cmd = null;
    int x = 0;
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        try
        {
            if ((int)Session["Auth"] != 2 && (int)Session["Auth"] != 1)
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
        str.Append("<a href=");
        if ((int)Session["Auth"] == 1)
        {
            str.Append("\"../Customer/CustomerHome.aspx\"");
        }
        else if ((int)Session["Auth"] == 2)
        {
            str.Append("\"../Staff/StaffHome.aspx\"");
        }
        str.Append("accesskey=\"2\" title=\"\">Home</a>");
        temp.InnerHtml = str.ToString();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = "Welcome " + (string)Session["Username"];
    }
    protected void Next_Click(object sender, EventArgs e)
    {
        Confirm.Visible = false;
        if (ConfirmPasswordText.Text != NewPasswordText.Text)
        {
            Confirm.Text = "New and Confirm Password should Match";
            Confirm.Visible = true;
        }
        else
            if (check())
                updateSQL();
    }
    private Boolean check()
    {
        try
        {
            cmd = new StringBuilder("SELECT COUNT(*) FROM LOGIN WHERE username='");
            cmd.Append((string)Session["Username"]).Append("' and hash=").Append(((int)OldPasswordText.Text.GetHashCode()).ToString());
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            SqlCommand = new SqlCommand(cmd.ToString(), SqlConnection);
            x = (int)SqlCommand.ExecuteScalar();
        }
        catch (SqlException se)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            SqlConnection.Close();
            SqlCommand.Dispose();
            SqlConnection.Dispose();
        }
        if (x != 1)
        {
            Confirm.Text = "Old Password is Wrong";
            Confirm.Visible = true;
            return false;
        }
        else
            return true;
    }
    private void updateSQL()
    {
        try
        {
            cmd = new StringBuilder("UPDATE LOGIN SET HASH=");
            cmd.Append(((int)NewPasswordText.Text.GetHashCode()).ToString()).Append(" WHERE username='").Append((string)Session["Username"]).Append("'");
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            SqlCommand = new SqlCommand(cmd.ToString(), SqlConnection);
            SqlCommand.ExecuteNonQuery();
            Confirm.Text = "Password Changed Successfully!";
            Confirm.Visible = true;
        }
        catch (SqlException se1)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se1.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            SqlConnection.Close();
            SqlCommand.Dispose();
            SqlConnection.Dispose();
        }
    }
}