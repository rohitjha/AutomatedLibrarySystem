using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Web.UI;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected SqlConnection SqlConnection = null;
    protected SqlCommand SqlCommand = null;
    protected string guidResult = null;
    protected int control = 0, mailcon = 0;

    protected void Page_PreInit(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            }
            catch (SqlException se1)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se1.Message.Replace("'", "") + "');", true);

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (checkDetails())
        {
            guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);
            guidResult = guidResult.Substring(0, 8);
            ViewState["new"] = (string)guidResult;
            updateSQL(guidResult);
        }
        int q = 0;
        while (control != 1 && control != 2 && q < 15)
        {
            sendMail(EmailIdText.Text);
            q++;
        }
        mailcon = 0;
        if (control == 1 || q >= 15)
        {
            Label1.Text = "Password Reset Failed";
            updateSQL(((int)ViewState["passhash"]).ToString());
        }
        else
            Label1.Text = "Password Reset Successful!";
    }
    private void updateSQL(string str)
    {
        StringBuilder str1 = new StringBuilder("UPDATE LOGIN SET hash=");
        str1.Append((str.GetHashCode()).ToString()).Append(" WHERE username='").Append(UsernameText.Text).Append("'");
        try
        {
            SqlCommand.Dispose();
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            SqlCommand = new SqlCommand(str1.ToString(), SqlConnection);
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            SqlCommand.Dispose();
            SqlConnection.Dispose();
        }
        catch (SqlException se2)
        {
            control = 1;
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se2.Message.Replace("'", "") + "');", true);
        }
    }
    private Boolean checkDetails()
    {
        int x = 0;
        try
        {
            StringBuilder str = new StringBuilder("SELECT COUNT(*) FROM USERDETAILS WHERE username='");
            str.Append(UsernameText.Text).Append("' and name='").Append(NameText.Text).Append("' and email_addr='").Append(EmailIdText.Text);
            str.Append("' and phone_num='").Append(MobileNumberText.Text).Append("'");
            SqlConnection = new SqlConnection(ConfigurationManager.AppSettings["SQLAddress"]);
            SqlConnection.Open();
            SqlCommand = new SqlCommand(str.ToString(), SqlConnection);
            x = (int)SqlCommand.ExecuteScalar();
            SqlConnection.Close();
            SqlCommand.Dispose();
        }
        catch (SqlException se)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se.Message.Replace("'", "") + "');", true);
        }
        if (x == 1)
        {
            try
            {
                SqlConnection.Open();
                SqlCommand = new SqlCommand("SELECT HASH FROM LOGIN WHERE USERNAME='" + UsernameText.Text + "'", SqlConnection);
                ViewState["passhash"] = (int)SqlCommand.ExecuteScalar();
            }
            catch (SqlException se3)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + se3.Message.Replace("'", "") + "');", true);
            }
            finally
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
                SqlCommand.Dispose();
            }
            return true;
        }
        else
            return false;
    }
    private void sendMail(string Receiver)
    {
        try
        {
            mailcon++;
            SmtpClient SmtpClient = new SmtpClient("smtp.live.com", 25);
            SmtpClient.Credentials = new System.Net.NetworkCredential("automated_lib@live.in", "asp.net");
            SmtpClient.Port = 25;
            SmtpClient.EnableSsl = true;
            MailMessage MailMessage = new MailMessage();
            MailAddress MailAddress = new MailAddress("automated_lib@live.in");
            MailMessage.From = MailAddress;
            MailMessage.To.Add(Receiver);
            MailMessage.Subject = "Password Reset";
            MailMessage.IsBodyHtml = false;
            MailMessage.Body = "Your Password has been changed to Password= " + guidResult;
            SmtpClient.Send(MailMessage);
            control = 2;
        }
        catch (Exception ex)
        {
            if(mailcon==15)
                ClientScript.RegisterClientScriptBlock(typeof(Page), "uniqueOtherKey" + DateTime.Now, "alert('" + ex.Message.Replace("'", "") + "');", true);
        }
    }
}