using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class Default3 : System.Web.UI.Page
{
    string username;
    int password, confirmpass;
    int type = 0;
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
    protected SqlDataReader SqlDataReader = null;
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
            RadioButtonList1.SelectedIndex = 0;
        }
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        type = RadioButtonList1.SelectedIndex + 1;
        ViewState["Type"] = type;
        if (type == 1)
            confirmed();
        else
            if (type == 2 && HiddenConfirm.Value == "1")
                confirmed();
            else
                Response.Redirect("/Staff/AddUser.aspx");
    }
    protected void confirmed()
    {
        Label1.Visible = true;
        username = UsernameTextbox.Text;
        password = PasswordTextbox.Text.GetHashCode();
        confirmpass = ConfirmPasswordTextbox.Text.GetHashCode();
        if (confirmpass != password)
            Response.Write("Password and Confirm Password are not Same");
        else
        {
            ViewState["username"] = username;
            ViewState["password"] = password;
            string cmd = "INSERT INTO LOGIN VALUES('" + username + "'," + (int)password + "," + (int)ViewState["Type"] + ")";
            try
            {
                SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
                SqlConnection.Open();
                SqlCommand = new SqlCommand(cmd, SqlConnection);
                SqlCommand.ExecuteNonQuery();
                string cmd1 = "INSERT INTO Card Values('"+usRFIDText.Text+"','"+ViewState["username"]+"',0)";
                SqlCommand.Dispose();
                SqlCommand=new SqlCommand(cmd1,SqlConnection);
                SqlCommand.ExecuteNonQuery();
                string cmd2 = "INSERT INTO UserDetails Values('"+ViewState["username"]+"','"+NameTextBox.Text+"','"+AddressTextBox.Text+"','"+PhoneTextBox.Text+"','"+MailTextBox.Text+"','"+DOBTextBox.Text+"')";
                SqlCommand.Dispose();
                SqlCommand = new SqlCommand(cmd2, SqlConnection);
                SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se.Message.Replace("'", "") + "');", true);
            }

        }
    }
    protected void getrfid_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("C:\\WindowsFormsApplication2.exe");
    }
}