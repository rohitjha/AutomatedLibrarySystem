using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace FinalService
{
    public partial class Form1 : Form
    {
        static Dictionary<string, DateTime> rfid = new Dictionary<string, DateTime>();
        static char[] temp = new char[12];
        static string tempstring = null;
        SqlConnection sqlcon = new SqlConnection("server=AMIRAJ-LAPTOP;uid=amirajdhawan;pwd=amiraj2590;database=DBAutomated_Library;");
        SqlCommand sqlcmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter da=new SqlDataAdapter();
        string userRFID = "00000000";

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
                    string ncmd1 = "SELECT bid FROM ReturnTemp WHERE num='"+userRFID+"'";
                    try
                    {
                        sqlcon.Open();
                        sqlcmd = new SqlCommand(ncmd1, sqlcon);
                        da = new SqlDataAdapter(sqlcmd);
                        da.Fill(dt);
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show("SQL " + se.Message);
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                    if (dt.Rows.Count >= 1)
                    {
                        try
                        {
                            sqlcon.Open();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string incmd1 = "UPDATE Checkout SET until=getDate() WHERE num='" + userRFID + "' AND bid='" + dt.Rows[i]["bid"].ToString() + "'";
                                try
                                {
                                    sqlcmd = new SqlCommand(incmd1, sqlcon);
                                    sqlcmd.ExecuteNonQuery();
                                }
                                catch (SqlException se)
                                {
                                    MessageBox.Show("SQL " + se.Message);
                                }
                            }
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show("SQL " + se.Message);
                        }
                        finally
                        {
                            sqlcon.Close();
                        }
                        string rcmd = "DELETE FROM ReturnTemp WHERE num='" + userRFID + "'";
                        try
                        {
                            sqlcon.Open();
                            sqlcmd = new SqlCommand(rcmd, sqlcon);
                            sqlcmd.ExecuteNonQuery();
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show("SQL " + se.Message);
                        }
                        finally
                        {
                            sqlcon.Close();
                        }
                    }
                    userRFID = tempstring;
                }
                else
                {
                    if (x == 12)
                    {
                        if (checkReturn(tempstring, userRFID))
                        {
                            string icmd1 = "UPDATE Checkout SET until=getDate() WHERE Num='" + userRFID + "' AND BID='" + tempstring + "'";
                            try
                            {
                                sqlcon.Open();
                                sqlcmd = new SqlCommand(icmd1, sqlcon);
                                sqlcmd.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("SQL " + se.Message);
                            }
                            finally
                            {
                                sqlcon.Close();
                            }
                            string icmd2 = "DELETE FROM ReturnTemp WHERE num='" + userRFID + "' AND bid='" + tempstring + "'";
                            try
                            {
                                sqlcon.Open();
                                sqlcmd = new SqlCommand(icmd2, sqlcon);
                                sqlcmd.ExecuteNonQuery();
                            }
                            catch (SqlException se)
                            {
                                MessageBox.Show("SQL " + se.Message);
                            }
                            finally
                            {
                                sqlcon.Close();
                            }
                        }
                        string cmd1 = "INSERT INTO Checkout Values('" + tempstring + "','" + userRFID + "',getDate(),null)";
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
        private Boolean checkReturn(string bstr, string ustr)
        {
            sqlcon.Open();
            string cmd3 = "SELECT COUNT(*) FROM ReturnTemp WHERE bid='" + bstr + "' AND num='" + ustr + "'";
            try
            {
                sqlcmd = new SqlCommand(cmd3, sqlcon);
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
            catch(SqlException se)
            {
                MessageBox.Show("SQL " + se.Message);
                return false;
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