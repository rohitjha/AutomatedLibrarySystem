using System;
using System.IO;
using System.Net;


public partial class _Default : System.Web.UI.Page 
{
    string IDirectory;
    string max = null, ISBN = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        IDirectory="Pictures\\";
        Session["IDirectory"] = IDirectory;
        Image1.ImageUrl =IDirectory + "noImage.jpg";
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        Session["ISBN"] = (string)textBox1.Text;
        ISBN =(string) Session["ISBN"];
        if (File.Exists(Request.PhysicalApplicationPath+ IDirectory + ISBN + ".jpg"))
        {
            button2.Visible = false;
            Image1.Dispose();
            Image1.ImageUrl = IDirectory + ISBN + ".jpg";
        }
        else
        {
            string final = "http://books.google.com/books?vid=ISBN" + ISBN + "&printsec=frontcover";
            try
            {
                WebRequest myWebRequest = WebRequest.Create(final);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                Stream es = myWebResponse.GetResponseStream();
                StreamReader str = new StreamReader(es);
                String data = str.ReadToEnd();
                int z = data.Length;
                int x = data.LastIndexOf("<img src=\"") + 10;
                int y = data.LastIndexOf("\" alt=\"Front Cover\"", x + 300);
                max = data.Substring(x, y - x);
            }
            catch (Exception)
            {
                Image1.Dispose();
                Image1.ImageUrl = IDirectory + "noImage.jpg";
            }
            if (max != null)
            {
                try
                {
                    WebClient wb = new WebClient();
                    wb.DownloadFile(max, Request.PhysicalApplicationPath +"Temporary Files\\temp.jpg");
                    Image1.Dispose();
                    Image1.ImageUrl = "Temporary Files\\temp.jpg";
                    button2.Visible = true;
                }
                catch (WebException ex)
                {
                    Response.Write(ex.Message);
                    Image1.Dispose();
                    Image1.ImageUrl = IDirectory + "noImage.jpg";
                }
            }
        }

    }
    protected void button2_Click(object sender, EventArgs e)
    {
        ISBN = (string)Session["ISBN"];
        File.Move(Request.PhysicalApplicationPath + "Temporary Files\\temp.jpg", Request.PhysicalApplicationPath + IDirectory + ISBN + ".jpg");
        Image1.ImageUrl = IDirectory + ISBN + ".jpg";
        button2.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoogleAPIDetails.aspx");
    }
}