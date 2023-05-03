using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicMenu
{
    public partial class Backup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            //IF SQL Server Authentication then Connection String  
            //con.ConnectionString = @"Server=MyPC\SqlServer2k8;database=" + YourDBName + ";uid=sa;pwd=password;";  

            //IF Window Authentication then Connection String  
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            string backupDIR = "C:\\BackUp";
            if (!System.IO.Directory.Exists(backupDIR))
            {
                System.IO.Directory.CreateDirectory(backupDIR);
            }
            try
            {
                con.Open();
                sqlcmd = new SqlCommand("BACKUP DATABASE asl_accountsdbt TO DISK='" + backupDIR + "\\AlchemyAccount" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                lblError.Text = "Backup database successfully";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
            }
        }
    }
}