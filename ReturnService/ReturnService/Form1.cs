using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReturnService
{
    public partial class Form1 : Form
    {
        static Dictionary<string, DateTime> rfid = new Dictionary<string, DateTime>();
        static char[] temp = new char[12];
        static string tempstring = null;
        SqlConnection sqlcon = new SqlConnection("server=AMIRAJ-LAPTOP;uid=amirajdhawan;pwd=amiraj2590;database=DBAutomated_Library;");
        SqlCommand sqlcmd = null;
        string userRFID = null;

        public Form1()
        {
            InitializeComponent();
            try
            {
                serialPort1.Open();
            }
            catch (System.Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int x = serialPort1.Read(temp, 0, 12);
            tempstring = (new string(temp)).Trim();

            if (x == 12 && !rfid.ContainsKey(tempstring) && tempstring != "000000000000")
            {
                if (checkMem(tempstring) && x == 12)
                {
                    userRFID = tempstring;
                }
                else
                {
                    if (x == 12)
                    {
                        string cmd1 = "INSERT INTO ReturnTemp Values('" + tempstring + "','" + userRFID + "')";
                        try
                        {
                            sqlcon.Open();
                            sqlcmd = new SqlCommand(cmd1, sqlcon);
                            sqlcmd.ExecuteNonQuery();
                        }
                        catch (Exception es)
                        {
                            MessageBox.Show("SQL " + es.Message);
                        }
                        finally
                        {
                            sqlcon.Close();
                        }
                    }
                }
                rfid.Add(tempstring, DateTime.Now);
                foreach (KeyValuePair<string, DateTime> kvp in rfid)
                {
                    if (textBox2.InvokeRequired)
                    {
                        textBox2.Invoke(new MethodInvoker(delegate { textBox2.Text = kvp.Key; }));
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ex = DateTime.Now;
            try
            {
                foreach (KeyValuePair<string, DateTime> kvp1 in Form1.rfid)
                {
                    if (DateTime.Compare(kvp1.Value.AddMinutes(1), ex) < 0)
                    {
                        Form1.rfid.Remove(kvp1.Key);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private Boolean checkMem(string str)
        {
            sqlcon.Open();
            //sqlcmd.Dispose();
            string cmd2 = "SELECT COUNT(*) FROM CARD WHERE Num='" + str + "'";
            sqlcmd = new SqlCommand(cmd2, sqlcon);
            int x = Convert.ToInt32(sqlcmd.ExecuteScalar());
            if (x == 1)
            {
                sqlcon.Close();
                return true;
            }
            else
            {
                sqlcon.Close();
                return false;
            }
        }

    }
}