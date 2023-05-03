using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using AlchemyAccounting;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;
using DynamicMenu.Accounts.DataAccess;
using DynamicMenu.Accounts.Interface;

namespace DynamicMenu.Accounts.UI
{
    public partial class Process : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        AccountDataAccess dob = new AccountDataAccess();
        AccountInterface iob = new AccountInterface();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                string formLink = "/Accounts/UI/Process.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    try
                    {
                        if (!IsPostBack)
                        {
                            lblSerial_Mrec.Visible = false;
                            lblSerial_Mpay.Visible = false;
                            lblSerial_Jour.Visible = false;
                            lblSerial_Cont.Visible = false;
                            DateTime today = DateTime.Today.Date;
                            string td = DbFunctions.Dayformat(today);
                            txtDate.Text = td;
                            btnProcess.Focus();
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    Response.Redirect("../../DeshBoard/UI/Default.aspx");
                }
            }
        }




        public void ShowGrid_SigleVoucher()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(" SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, SERIALNO, TRANSFOR, COSTPID, TRANSMODE, DEBITCD, CREDITCD, CHEQUENO, convert(nvarchar(20),CHEQUEDT,103) as CHEQUEDT, AMOUNT, REMARKS, USERPC, USERID, ACTDTI, INTIME, IPADDRESS " +
                                            " FROM dbo.GL_STRANS where TRANSDT = '" + p_Date + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridSingleVoucher.DataSource = ds;
                gridSingleVoucher.DataBind();
                gridSingleVoucher.Visible = false;
            }
            else
            {
                gridSingleVoucher.DataSource = ds;
                gridSingleVoucher.DataBind();
                gridSingleVoucher.Visible = false;
                //Response.Write("<script>alert('No Data Found');</script>");
                //GridView1.Visible = false;
            }
        }

        public void ShowGrid_Multiple()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(" SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, SERIALNO, TRANSFOR, COSTPID, TRANSMODE, DEBITCD, CREDITCD, CHEQUENO, convert(nvarchar(20),CHEQUEDT,103) as CHEQUEDT, AMOUNT, REMARKS, USERPC, USERID, ACTDTI, INTIME, IPADDRESS " +
                                            " FROM GL_MTRANS where TRANSDT = '" + p_Date + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridMultiple.DataSource = ds;
                gridMultiple.DataBind();
                gridMultiple.Visible = false;
            }
            else
            {
                gridMultiple.DataSource = ds;
                gridMultiple.DataBind();
                gridMultiple.Visible = false;
                //Response.Write("<script>alert('No Data Found');</script>");
                //GridView1.Visible = false;
            }
        }

        public void ShowGrid_Purchase()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY AND 
                         dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO
WHERE        (dbo.STK_TRANS.TRANSDT = @TRANSDT) AND (dbo.STK_TRANS.TRANSTP = 'BUY')
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridBuy.DataSource = ds;
                gridBuy.DataBind();
                gridBuy.Visible = false;
            }
            else
            {
                gridBuy.DataSource = ds;
                gridBuy.DataBind();
                gridBuy.Visible = false;
            }
        }

        public void ShowGrid_Purchase_Ret()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO AND 
                         dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY
WHERE        (dbo.STK_TRANS.TRANSDT = @TRANSDT) AND (dbo.STK_TRANS.TRANSTP = 'IRTB')
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridPurchase_Ret.DataSource = ds;
                gridPurchase_Ret.DataBind();
                gridPurchase_Ret.Visible = false;
            }
            else
            {
                gridPurchase_Ret.DataSource = ds;
                gridPurchase_Ret.DataBind();
                gridPurchase_Ret.Visible = false;
            }
        }




        /// <summary>
        /// ************************************** Sale ***************************************
        /// ************************************** Sale ***************************************
        /// ************************************** Sale ***************************************
        /// ************************************** Sale ***************************************
        /// ************************************** Sale ***************************************
        /// </summary>
        public void ShowGrid_Sale()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT STK_TRANS.TRANSTP, STK_TRANS.TRANSDT, STK_TRANS.TRANSMY, STK_TRANS.TRANSNO, STK_TRANS.UNITFR, STK_TRANS.UNITTO, STK_TRANS.PSID, STK_TRANSMST.REMARKS, SUM(STK_TRANS.AMOUNT) 
                AS AMOUNT, ISNULL(STK_TRANSMST.ALLOWANCP,0) ALLOWANCP
                FROM STK_TRANS INNER JOIN
                STK_TRANSMST ON STK_TRANS.TRANSTP = STK_TRANSMST.TRANSTP AND STK_TRANS.TRANSMY = STK_TRANSMST.TRANSMY AND STK_TRANS.TRANSNO = STK_TRANSMST.TRANSNO
                WHERE (STK_TRANS.TRANSDT = @TRANSDT) AND (STK_TRANS.TRANSTP = 'SALE')
                GROUP BY STK_TRANS.TRANSTP, STK_TRANS.TRANSDT, STK_TRANS.TRANSMY, STK_TRANS.TRANSNO, STK_TRANS.UNITFR, STK_TRANS.UNITTO, STK_TRANS.PSID, STK_TRANSMST.REMARKS, 
                STK_TRANSMST.ALLOWANCP", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridSale.DataSource = ds;
                gridSale.DataBind();
                gridSale.Visible = false;
            }
            else
            {
                gridSale.DataSource = ds;
                gridSale.DataBind();
                gridSale.Visible = false;
            }
        }
        public void Sale_process()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridSale.Rows)
            {
                try
                {
                    DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
                    if (lblSerial_SALE.Text == "")
                    {
                        serialNo = "12000";
                        iob.Serial_SALE = serialNo;
                    }
                    else
                    {
                        sl = int.Parse(lblSerial_SALE.Text);
                        serial = sl + 1;

                        iob.Serial_SALE = serial.ToString();
                    }

                    iob.Transtp = "JOUR";
                    iob.Debitcd = grid.Cells[6].Text;
                    iob.Creditcd = "301010100001";
                    iob.Transdt = Transdt;
                    iob.Monyear = grid.Cells[2].Text;
                    iob.TransNo = grid.Cells[3].Text;
                    iob.StoreFrom = grid.Cells[4].Text;
                    iob.StoreTo = grid.Cells[5].Text;
                    iob.PsID = grid.Cells[6].Text;
                    string Remarks = grid.Cells[7].Text;
                    iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                    if (Remarks == "&nbsp;")
                    {
                        iob.Remarks = "SALE";
                    }
                    else
                        iob.Remarks = "SALE  " + Remarks;
                    iob.Allowance = Convert.ToDecimal(grid.Cells[9].Text);
                    iob.AllowanceAmount = ((iob.Amount * iob.Allowance) / 100);

                    dob.doProcess_SALE(iob);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }


        /// <summary>
        /// ************************************** Wastage ***************************************
        /// ************************************** Wastage ***************************************
        /// ************************************** Wastage ***************************************
        /// ************************************** Wastage ***************************************
        /// ************************************** Wastage ***************************************
        /// </summary>

        public void ShowGrid_Wastage()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO AND 
                         dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY
WHERE        (dbo.STK_TRANS.TRANSTP = 'IWTG') AND (dbo.STK_TRANS.TRANSDT = @TRANSDT)
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridWastage.DataSource = ds;
                gridWastage.DataBind();
                gridWastage.Visible = false;
            }
            else
            {
                gridWastage.DataSource = ds;
                gridWastage.DataBind();
                gridWastage.Visible = false;
            }
        }

        public void Wastage_process()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridWastage.Rows)
            {
                try
                {
                    DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
                    if (lblSerial_SALE.Text == "")
                    {
                        serialNo = "21000";
                        iob.Serial_SALE = serialNo;
                    }
                    else
                    {
                        sl = int.Parse(lblSerial_SALE.Text);
                        serial = sl + 1;

                        iob.Serial_SALE = serial.ToString();
                    }

                    iob.Transtp = "JOUR";
                    iob.Debitcd = "40201290001";
                    iob.Creditcd = "102060100001";
                    iob.Transdt = Transdt;
                    iob.Monyear = grid.Cells[2].Text;
                    iob.TransNo = grid.Cells[3].Text;
                    iob.StoreFrom = grid.Cells[4].Text;
                    iob.StoreTo = grid.Cells[5].Text;
                    iob.PsID = grid.Cells[6].Text;
                    string Remarks = grid.Cells[7].Text;
                    iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                    if (Remarks == "&nbsp;")
                    {
                        iob.Remarks = "WASTAGE";
                    }
                    else
                        iob.Remarks = "WASTAGE  " + Remarks;

                    dob.doProcess_WASTAGE(iob);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }


        /// <summary>
        /// ************************************** Sub Contract Receive *******************************
        /// ************************************** Sub Contract Receive *******************************
        /// ************************************** Sub Contract Receive *******************************
        /// ************************************** Sub Contract Receive *******************************
        /// ************************************** Sub Contract Receive *******************************
        /// </summary>

        public void ShowGrid_SubContractReceive()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO AND 
                         dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY
WHERE        (dbo.STK_TRANS.TRANSTP = 'SREC') AND (dbo.STK_TRANS.TRANSDT = @TRANSDT)
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridSubContractReceive.DataSource = ds;
                gridSubContractReceive.DataBind();
                gridSubContractReceive.Visible = false;
            }
            else
            {
                gridSubContractReceive.DataSource = ds;
                gridSubContractReceive.DataBind();
                gridSubContractReceive.Visible = false;
            }
        }

        public void SubContractReceive_process()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridSubContractReceive.Rows)
            {
                try
                {
                    DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
                    if (lblSerial_SALE.Text == "")
                    {
                        serialNo = "22000";
                        iob.Serial_SALE = serialNo;
                    }
                    else
                    {
                        sl = int.Parse(lblSerial_SALE.Text);
                        serial = sl + 1;

                        iob.Serial_SALE = serial.ToString();
                    }

                    iob.Transtp = "JOUR";
                    iob.Debitcd = "102060100001";
                    iob.Creditcd = grid.Cells[6].Text;
                    iob.Transdt = Transdt;
                    iob.Monyear = grid.Cells[2].Text;
                    iob.TransNo = grid.Cells[3].Text;
                    iob.StoreFrom = grid.Cells[4].Text;
                    iob.StoreTo = "";
                    iob.PsID = grid.Cells[6].Text;
                    string Remarks = grid.Cells[7].Text;
                    iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                    if (Remarks == "&nbsp;")
                    {
                        iob.Remarks = "RECEIVE-SUB-CONTRACT";
                    }
                    else
                        iob.Remarks = "RECEIVE-SUB-CONTRACT  " + Remarks;

                    dob.doProcess_WASTAGE(iob);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }




        /// <summary>
        /// ************************************** Sub Contract Issue *******************************
        /// ************************************** Sub Contract Issue *******************************
        /// ************************************** Sub Contract Issue *******************************
        /// ************************************** Sub Contract Issue *******************************
        /// ************************************** Sub Contract Issue *******************************
        /// </summary>

        public void ShowGrid_SubContractIssue()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO AND 
                         dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY
WHERE        (dbo.STK_TRANS.TRANSTP = 'SISS') AND (dbo.STK_TRANS.TRANSDT = @TRANSDT)
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANS.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridSubContractIssue.DataSource = ds;
                gridSubContractIssue.DataBind();
                gridSubContractIssue.Visible = false;
            }
            else
            {
                gridSubContractIssue.DataSource = ds;
                gridSubContractIssue.DataBind();
                gridSubContractIssue.Visible = false;
            }
        }

        public void SubContractIssue_process()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridSubContractIssue.Rows)
            {
                try
                {
                    DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
                    if (lblSerial_SALE.Text == "")
                    {
                        serialNo = "23000";
                        iob.Serial_SALE = serialNo;
                    }
                    else
                    {
                        sl = int.Parse(lblSerial_SALE.Text);
                        serial = sl + 1;

                        iob.Serial_SALE = serial.ToString();
                    }

                    iob.Transtp = "JOUR";
                    iob.Debitcd = grid.Cells[6].Text;
                    iob.Creditcd = "102060100001";
                    iob.Transdt = Transdt;
                    iob.Monyear = grid.Cells[2].Text;
                    iob.TransNo = grid.Cells[3].Text;
                    iob.StoreFrom = grid.Cells[4].Text;
                    iob.StoreTo = "";
                    iob.PsID = grid.Cells[6].Text;
                    string Remarks = grid.Cells[7].Text;
                    iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                    if (Remarks == "&nbsp;")
                    {
                        iob.Remarks = "ISSUE-SUB-CONTRACT";
                    }
                    else
                        iob.Remarks = "ISSUE-SUB-CONTRACT  " + Remarks;

                    dob.doProcess_WASTAGE(iob);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }



        //public void ShowGrid_Receive()
        //{

        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, UNITFR, UNITTO, PSID, REMARKS, sum(AMOUNT)as AMOUNT " +
        //                                    " from STK_TRANS where TRANSDT='" + p_Date + "' and TRANSTP='IREC' " +
        //                                    " group by TRANSTP, TRANSDT, TRANSMY, TRANSNO, UNITFR, UNITTO, PSID, REMARKS ", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gridReceive.DataSource = ds;
        //        gridReceive.DataBind();
        //        gridReceive.Visible = false;
        //    }
        //    else
        //    {
        //        gridReceive.DataSource = ds;
        //        gridReceive.DataBind();
        //        gridReceive.Visible = false;
        //    }
        //}

        //public void Receive_process()
        //{
        //    string userName = HttpContext.Current.Session["USERID"].ToString();
        //    string serialNo = "";
        //    int sl, serial;

        //    iob.Username = userName;

        //    DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
        //    string trans_DT = Transdt.ToString("yyyy/MM/dd");

        //    foreach (GridViewRow grid in gridReceive.Rows)
        //    {
        //        try
        //        {
        //            dbFunctions.lblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
        //            if (lblSerial_SALE.Text == "")
        //            {
        //                serialNo = "12000";
        //                iob.Serial_SALE = serialNo;
        //            }
        //            else
        //            {
        //                sl = int.Parse(lblSerial_SALE.Text);
        //                serial = sl + 1;

        //                iob.Serial_SALE = serial.ToString();
        //            }

        //            iob.Transtp = "IREC";
        //            iob.Debitcd = "";
        //            iob.Creditcd = "301010100001";
        //            iob.Transdt = Transdt;
        //            iob.Monyear = grid.Cells[2].Text;
        //            iob.TransNo = grid.Cells[3].Text;
        //            iob.StoreFrom = grid.Cells[4].Text;
        //            iob.StoreTo = grid.Cells[5].Text;
        //            iob.PsID = grid.Cells[6].Text;
        //            string Remarks = grid.Cells[7].Text;
        //            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
        //            if (Remarks == "&nbsp;")
        //            {
        //                iob.Remarks = "";
        //            }
        //            else
        //                iob.Remarks = Remarks;

        //            dob.doProcess_Receive(iob);
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //    }
        //}

        //public void ShowGrid_Issue()
        //{

        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, UNITFR, UNITTO, PSID, REMARKS, sum(AMOUNT)as AMOUNT " +
        //                                    " from STK_TRANS where TRANSDT='" + p_Date + "' and TRANSTP='IISS' " +
        //                                    " group by TRANSTP, TRANSDT, TRANSMY, TRANSNO, UNITFR, UNITTO, PSID, REMARKS ", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gridIssue.DataSource = ds;
        //        gridIssue.DataBind();
        //        gridIssue.Visible = false;
        //    }
        //    else
        //    {
        //        gridIssue.DataSource = ds;
        //        gridIssue.DataBind();
        //        gridIssue.Visible = false;
        //    }
        //}

        //public void Issue_process()
        //{
        //    string userName = HttpContext.Current.Session["USERID"].ToString();
        //    string serialNo = "";
        //    int sl, serial;

        //    iob.Username = userName;

        //    DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
        //    string trans_DT = Transdt.ToString("yyyy/MM/dd");

        //    foreach (GridViewRow grid in gridReceive.Rows)
        //    {
        //        try
        //        {
        //            dbFunctions.lblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP IN ('JOUR','MREC') and SERIALNO like '12%'", lblSerial_SALE);
        //            if (lblSerial_SALE.Text == "")
        //            {
        //                serialNo = "12000";
        //                iob.Serial_SALE = serialNo;
        //            }
        //            else
        //            {
        //                sl = int.Parse(lblSerial_SALE.Text);
        //                serial = sl + 1;

        //                iob.Serial_SALE = serial.ToString();
        //            }

        //            iob.Transtp = "IISS";
        //            iob.Debitcd = "";
        //            iob.Creditcd = "301010100001";
        //            iob.Transdt = Transdt;
        //            iob.Monyear = grid.Cells[2].Text;
        //            iob.TransNo = grid.Cells[3].Text;
        //            iob.StoreFrom = grid.Cells[4].Text;
        //            iob.StoreTo = grid.Cells[5].Text;
        //            iob.PsID = grid.Cells[6].Text;
        //            string Remarks = grid.Cells[7].Text;
        //            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
        //            if (Remarks == "&nbsp;")
        //            {
        //                iob.Remarks = "";
        //            }
        //            else
        //                iob.Remarks = Remarks;

        //            dob.doProcess_Issue(iob);
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //    }
        //}


        //public void ShowGrid_Sale_Discount()
        //{

        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(" SELECT * FROM " +
        //                                        " (SELECT A.TRANSTP, A.TRANSDT, A.TRANSMY, A.TRANSNO, A.UNITFR, A.PSID, A.REMARKS, (A.DISCAMT+STK_TRANSMST.DISAMT) AS DISAMT " +
        //                                        " FROM  (SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, INVREFNO, UNITFR, UNITTO, PSID, SUM(DISCAMT) AS DISCAMT, REMARKS " +
        //                                                " FROM          STK_TRANS " +
        //                                                " WHERE (TRANSTP = 'SALE') AND (TRANSDT = '" + p_Date + "') " +
        //                                                " GROUP BY TRANSTP, TRANSDT, TRANSMY, TRANSNO, INVREFNO, UNITFR, UNITTO, PSID,REMARKS) AS A INNER JOIN " +
        //                                    " STK_TRANSMST ON A.TRANSTP = STK_TRANSMST.TRANSTP AND A.TRANSDT = STK_TRANSMST.TRANSDT AND A.TRANSMY = STK_TRANSMST.TRANSMY AND " +
        //                                    " A.TRANSNO = STK_TRANSMST.TRANSNO AND A.INVREFNO = STK_TRANSMST.INVREFNO AND A.UNITFR = STK_TRANSMST.UNITFR AND " +
        //                                    " A.UNITTO = STK_TRANSMST.UNITTO AND A.PSID = STK_TRANSMST.PSID) AS B WHERE B.DISAMT<>0", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        GridView4.DataSource = ds;
        //        GridView4.DataBind();
        //        GridView4.Visible = false;
        //    }
        //    else
        //    {
        //        GridView4.DataSource = ds;
        //        GridView4.DataBind();
        //        GridView4.Visible = false;
        //    }
        //}

        //public void ShowGrid_Sale_New()
        //{

        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(" SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, UNITFR, UNITTO, PSID, REMARKS, (TOTAMT-DISAMT) AS AMOUNT " +
        //               " from STK_TRANSMST where TRANSDT='" + p_Date + "' and TRANSTP='SALE'", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gridSale.DataSource = ds;
        //        gridSale.DataBind();
        //        gridSale.Visible = false;
        //    }
        //    else
        //    {
        //        gridSale.DataSource = ds;
        //        gridSale.DataBind();
        //        gridSale.Visible = false;
        //    }
        //}

        public void ShowGrid_Sale_Ret()
        {

            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS, SUM(dbo.STK_TRANS.AMOUNT) AS AMOUNT
FROM            dbo.STK_TRANS INNER JOIN
                         dbo.STK_TRANSMST ON dbo.STK_TRANS.TRANSTP = dbo.STK_TRANSMST.TRANSTP AND dbo.STK_TRANS.TRANSNO = dbo.STK_TRANSMST.TRANSNO AND 
                         dbo.STK_TRANS.TRANSMY = dbo.STK_TRANSMST.TRANSMY
WHERE        (dbo.STK_TRANS.TRANSTP = 'IRTS') AND (dbo.STK_TRANS.TRANSDT = @TRANSDT)
GROUP BY dbo.STK_TRANS.TRANSTP, dbo.STK_TRANS.TRANSDT, dbo.STK_TRANS.TRANSMY, dbo.STK_TRANS.TRANSNO, dbo.STK_TRANS.UNITFR, dbo.STK_TRANS.UNITTO, dbo.STK_TRANS.PSID, 
                         dbo.STK_TRANSMST.REMARKS", conn);
            cmd.Parameters.AddWithValue("@TRANSDT", p_Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridSale_Ret.DataSource = ds;
                gridSale_Ret.DataBind();
                gridSale_Ret.Visible = false;
            }
            else
            {
                gridSale_Ret.DataSource = ds;
                gridSale_Ret.DataBind();
                gridSale_Ret.Visible = false;
            }
        }
        public void ShowGridLC()
        {
            DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string p_Date = Pdate.ToString("yyyy/MM/dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(" SELECT TRANSTP, TRANSDT, TRANSMY, TRANSNO, LCCD, CNBCD, AMOUNT, (CASE WHEN LCINVNO = '' THEN REMARKS WHEN REMARKS = '' THEN LCINVNO ELSE (REMARKS + ' - ' + LCINVNO)END)AS REMARKS FROM LC_EXPENSE " +
                                            " WHERE (TRANSDT = '" + p_Date + "')", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridLC.DataSource = ds;
                gridLC.DataBind();
                gridLC.Visible = false;
            }
            else
            {
                gridLC.DataSource = ds;
                gridLC.DataBind();
                gridLC.Visible = false;
            }
        }
        //public void ShowGridMicroCreditCollection()
        //{
        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(" SELECT 'MREC' AS TRANSTP, MC_COLLECT_MST.TRANSDT, MC_COLLECT_MST.TRANSMY, MC_COLLECT_MST.TRANSNO, MC_COLLECT_MST.SCHEME_ID, " +
        //              " SUM(MC_COLLECT.COLLECTAMT) AS AMOUNT, MC_COLLECT_MST.REMARKS, MC_SCHEME.SCH_TP, MC_SCHEME.ACC_CD FROM MC_COLLECT_MST INNER JOIN " +
        //              " MC_COLLECT ON MC_COLLECT_MST.TRANSMY = MC_COLLECT.TRANSMY AND MC_COLLECT_MST.TRANSNO = MC_COLLECT.TRANSNO INNER JOIN MC_SCHEME ON MC_COLLECT_MST.SCHEME_ID = MC_SCHEME.SCHEME_ID " +
        //              " WHERE (MC_COLLECT_MST.TRANSDT = '" + p_Date + "') GROUP BY MC_COLLECT_MST.TRANSDT, MC_COLLECT_MST.TRANSMY, MC_COLLECT_MST.TRANSNO, MC_COLLECT_MST.SCHEME_ID, MC_COLLECT_MST.REMARKS, " +
        //              " MC_SCHEME.SCH_TP, MC_SCHEME.ACC_CD", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gvMicCollection.DataSource = ds;
        //        gvMicCollection.DataBind();
        //        gvMicCollection.Visible = false;
        //    }
        //    else
        //    {
        //        gvMicCollection.DataSource = ds;
        //        gvMicCollection.DataBind();
        //        gvMicCollection.Visible = false;
        //    }
        //}

        //public void ShowGridMicroCreditCollectionMember()
        //{
        //    DateTime Pdate = DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
        //    string p_Date = Pdate.ToString("yyyy/MM/dd");

        //    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(" SELECT 'MREC' AS TRANSTP, MC_COLLECT_MST.TRANSDT, MC_COLLECT_MST.TRANSMY, MC_COLLECT_MST.TRANSNO, MC_COLLECT_MST.SCHEME_ID, " +
        //              " SUM(MC_COLLECT.COLLECTAMT) AS AMOUNT, MC_COLLECT_MST.REMARKS, MC_COLLECT.MEMBERID, MC_COLLECT.INTERNALID, MC_SCHEME.SCH_TP, MC_SCHEME.ACC_CD " +
        //              " FROM MC_COLLECT_MST INNER JOIN MC_COLLECT ON MC_COLLECT_MST.TRANSMY = MC_COLLECT.TRANSMY AND MC_COLLECT_MST.TRANSNO = MC_COLLECT.TRANSNO INNER JOIN " +
        //              " MC_SCHEME ON MC_COLLECT_MST.SCHEME_ID = MC_SCHEME.SCHEME_ID WHERE (MC_COLLECT_MST.TRANSDT = '" + p_Date + "') GROUP BY MC_COLLECT_MST.TRANSDT, MC_COLLECT_MST.TRANSMY, MC_COLLECT_MST.TRANSNO, MC_COLLECT_MST.SCHEME_ID, MC_COLLECT_MST.REMARKS, " +
        //              " MC_COLLECT.MEMBERID, MC_COLLECT.INTERNALID, MC_SCHEME.SCH_TP, MC_SCHEME.ACC_CD", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        gvMicCollectionMember.DataSource = ds;
        //        gvMicCollectionMember.DataBind();
        //        gvMicCollectionMember.Visible = false;
        //    }
        //    else
        //    {
        //        gvMicCollectionMember.DataSource = ds;
        //        gvMicCollectionMember.DataBind();
        //        gvMicCollectionMember.Visible = false;
        //    }
        //}

        public void Buy_process()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridBuy.Rows)
            {
                try
                {
                    if (grid.Cells[0].Text == "BUY")
                    {
                        DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' and SERIALNO like '11%' ", lblSerial_BUY);
                        if (lblSerial_BUY.Text == "")
                        {
                            serialNo = "11000";
                            iob.Serial_BUY = serialNo;
                        }
                        else
                        {
                            sl = int.Parse(lblSerial_BUY.Text);
                            serial = sl + 1;

                            iob.Serial_BUY = serial.ToString();
                        }

                        if (grid.Cells[6].Text == "202020100001") ////////// CASH SUPPLIER  (CASH PURCHASE-CHITTAGONG)
                        {
                            iob.Transtp = "MPAY";
                            iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
                            iob.Monyear = grid.Cells[2].Text;
                            iob.TransNo = grid.Cells[3].Text;
                            iob.StoreTo = grid.Cells[5].Text;

                            iob.Debitcd = "102060100001";
                            iob.Creditcd = "102010100001";
                            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                            string Remarks = grid.Cells[7].Text;
                            if (Remarks == "&nbsp;")
                            {
                                iob.Remarks = "PURCHASE";
                            }
                            else
                                iob.Remarks = "PURCHASE  " + Remarks;

                            dob.doProcess_BUY(iob);
                        }
                        else
                        {
                            iob.Transtp = "JOUR";
                            iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
                            iob.Monyear = grid.Cells[2].Text;
                            iob.TransNo = grid.Cells[3].Text;
                            iob.StoreTo = grid.Cells[5].Text;

                            iob.Debitcd = "102060100001";
                            iob.Creditcd = grid.Cells[6].Text;
                            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                            string Remarks = grid.Cells[7].Text;
                            if (Remarks == "&nbsp;")
                            {
                                iob.Remarks = "PURCHASE";
                            }
                            else
                                iob.Remarks = "PURCHASE  " + Remarks;

                            dob.doProcess_BUY(iob);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }

        public void Buy_process_Ret()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridPurchase_Ret.Rows)
            {
                try
                {
                    if (grid.Cells[0].Text == "IRTB")
                    {
                        DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' and SERIALNO like '14%' ", lblSerial_BUY);
                        if (lblSerial_BUY.Text == "")
                        {
                            serialNo = "14000";
                            iob.Serial_BUY = serialNo;
                        }
                        else
                        {
                            sl = int.Parse(lblSerial_BUY.Text);
                            serial = sl + 1;

                            iob.Serial_BUY = serial.ToString();
                        }
                        if (grid.Cells[6].Text == "202020100005") ////////// CASH SUPPLIER
                        {
                            iob.Transtp = "MREC";
                            iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
                            iob.Monyear = grid.Cells[2].Text;
                            iob.TransNo = grid.Cells[3].Text;
                            iob.StoreFrom = grid.Cells[5].Text;

                            iob.Debitcd = "102010100001";
                            iob.Creditcd = "102060100001";
                            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                            string Remarks = grid.Cells[7].Text;
                            if (Remarks == "&nbsp;")
                            {
                                iob.Remarks = "PURCHASE RETURN";
                            }
                            else
                                iob.Remarks = "PURCHASE RETURN  " + Remarks;

                            dob.doProcess_SALE(iob);
                        }
                        else
                        {
                            iob.Transtp = "JOUR";
                            iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
                            iob.Monyear = grid.Cells[2].Text;
                            iob.TransNo = grid.Cells[3].Text;
                            iob.StoreFrom = grid.Cells[5].Text;

                            iob.Debitcd = grid.Cells[6].Text;
                            iob.Creditcd = "102060100001";
                            iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                            string Remarks = grid.Cells[7].Text;
                            if (Remarks == "&nbsp;")
                            {
                                iob.Remarks = "PURCHASE RETURN";
                            }
                            else
                                iob.Remarks = "PURCHASE RETURN  " + Remarks;



                            dob.doProcess_BUY_Ret(iob);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }



        //public void Sale_Discount_process()
        //{
        //    string userName = HttpContext.Current.Session["USERID"].ToString();
        //    AlchemyAccounting.Accounts.DataAccess.SingleVoucher dob = new DataAccess.SingleVoucher();
        //    AlchemyAccounting.Accounts.Interface.SingleVoucher iob = new Interface.SingleVoucher();
        //    string serialNo = "";
        //    int sl, serial;

        //    iob.Username = userName;

        //    DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
        //    string trans_DT = Transdt.ToString("yyyy/MM/dd");

        //    foreach (GridViewRow grid in GridView4.Rows)
        //    {
        //        try
        //        {
        //            if (grid.Cells[0].Text == "SALE")
        //            {
        //                Global.lblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' and SERIALNO like '13%'", lblSlSale_Dis);
        //                if (lblSlSale_Dis.Text == "")
        //                {
        //                    serialNo = "13000";
        //                    iob.Sl_Sale_dis = serialNo;
        //                }
        //                else
        //                {
        //                    sl = int.Parse(lblSlSale_Dis.Text);
        //                    serial = sl + 1;

        //                    iob.Sl_Sale_dis = serial.ToString();
        //                }

        //                iob.Transtp = "JOUR";
        //                iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
        //                iob.Monyear = grid.Cells[2].Text;
        //                iob.TransNo = grid.Cells[3].Text;
        //                iob.UNITFRom = grid.Cells[4].Text;

        //                iob.Debitcd = "401030100001";
        //                iob.Creditcd = grid.Cells[5].Text;
        //                iob.Amount = Convert.ToDecimal(grid.Cells[7].Text);
        //                string Remarks = grid.Cells[6].Text;
        //                if (Remarks == "&nbsp;")
        //                {
        //                    iob.Remarks = "";
        //                }
        //                else
        //                    iob.Remarks = Remarks;



        //                dob.doProcess_SALE_DisCount(iob);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex.Message);
        //        }
        //    }
        //}

        public void Sale_process_Ret()
        {
            string userName = HttpContext.Current.Session["USERID"].ToString();
            string serialNo = "";
            int sl, serial;

            iob.Username = userName;

            DateTime Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
            string trans_DT = Transdt.ToString("yyyy/MM/dd");

            foreach (GridViewRow grid in gridSale_Ret.Rows)
            {
                try
                {
                    if (grid.Cells[0].Text == "IRTS")
                    {
                        DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' and SERIALNO like '15%'", lblSerial_SALE);
                        if (lblSerial_SALE.Text == "")
                        {
                            serialNo = "15000";
                            iob.Serial_SALE = serialNo;
                        }
                        else
                        {
                            sl = int.Parse(lblSerial_SALE.Text);
                            serial = sl + 1;

                            iob.Serial_SALE = serial.ToString();
                        }

                        iob.Transtp = "JOUR";
                        iob.Transdt = DateTime.Parse(grid.Cells[1].Text);
                        iob.Monyear = grid.Cells[2].Text;
                        iob.TransNo = grid.Cells[3].Text;
                        iob.StoreTo = grid.Cells[4].Text;
                        iob.Debitcd = "301010100001";
                        iob.Creditcd = grid.Cells[6].Text;
                        iob.Amount = Convert.ToDecimal(grid.Cells[8].Text);
                        string Remarks = grid.Cells[7].Text;
                        if (Remarks == "&nbsp;")
                        {
                            iob.Remarks = "SALE RETURN";
                        }
                        else
                            iob.Remarks = "SALE RETURN  " + Remarks;



                        dob.doProcess_SALE_Ret(iob);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }



        protected void txtDate_TextChanged(object sender, EventArgs e)
        {

            //ShowGridLC();
            //StockTransactionShowGrid();

            //ShowGridMicroCreditCollection();
            //ShowGridMicroCreditCollectionMember();
            btnProcess.Focus();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                if (txtDate.Text == "")
                {
                    Response.Write("<script>alert('Select a Date want to process?');</script>");
                }
                else
                {
                    string userName = HttpContext.Current.Session["USERID"].ToString();

                    string serialNo = "";
                    int sl, serial;


                    StockTransactionShowGrid();

                    iob.Transdt = (DateTime.Parse(txtDate.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal));
                    string trans_DT = iob.Transdt.ToString("yyyy/MM/dd");
                    iob.Username = userName;

                    string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from GL_MASTER where TRANSDT='" + trans_DT + "' and TABLEID = 'GL_STRANS' and TRANSTP <> 'OPEN'", conn);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Delete from GL_MASTER where TRANSDT='" + trans_DT + "' and TABLEID = 'GL_MTRANS' and TRANSTP <> 'OPEN'", conn);
                    cmd3.ExecuteNonQuery();

                    //SqlCommand cmd1 = new SqlCommand("Delete from GL_MASTER where TRANSDT='" + trans_DT + "' and TABLEID = 'STK_TRANS' and TRANSTP IN ('JOUR','MREC')", conn);
                    //cmd1.ExecuteNonQuery();

                    //SqlCommand cmd2 = new SqlCommand("Delete from GL_MASTER where TRANSDT='" + trans_DT + "' and TABLEID = 'LC_EXPENSE' and TRANSTP='MPAY'", conn);
                    //cmd2.ExecuteNonQuery();

                    //SqlCommand cmd4 = new SqlCommand("Delete from GL_MASTER where TRANSDT='" + trans_DT + "' and TABLEID = 'MC_COLLECT' and TRANSTP='MREC'", conn);
                    //cmd4.ExecuteNonQuery();

                    //SqlCommand cmd5 = new SqlCommand("Delete from MC_MLEDGER where TRANSDT='" + trans_DT + "' and TABLEID = 'MC_COLLECT' and TRANSTP='MREC'", conn);
                    //cmd5.ExecuteNonQuery();

                    conn.Close();

                    foreach (GridViewRow grid in gridSingleVoucher.Rows)
                    {
                        try
                        {
                            if (grid.Cells[0].Text == "MREC")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'MREC' ", lblSerial_Mrec);
                                if (lblSerial_Mrec.Text == "")
                                {
                                    serialNo = "1000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Mrec.Text);
                                    serial = sl + 1;

                                    iob.SerialNo_MREC = serial.ToString();
                                }

                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                //if (grid.Cells[10].Text == "&nbsp;")
                                //{
                                //    iob.Chequeno = null;
                                //}
                                //else
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;



                                dob.doProcess_MREC(iob);
                            }
                            else if (grid.Cells[0].Text == "MPAY")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'MPAY' ", lblSerial_Mpay);
                                if (lblSerial_Mpay.Text == "")
                                {
                                    serialNo = "2000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Mpay.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;

                                dob.doProcess_MPAY(iob);
                            }
                            else if (grid.Cells[0].Text == "JOUR")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' ", lblSerial_Jour);
                                if (lblSerial_Jour.Text == "")
                                {
                                    serialNo = "3000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Jour.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;

                                dob.doProcess_JOUR(iob);
                            }
                            else if (grid.Cells[0].Text == "CONT")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'CONT' ", lblSerial_Cont);
                                if (lblSerial_Cont.Text == "")
                                {
                                    serialNo = "4000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Cont.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;


                                dob.doProcess_CONT(iob);

                            }



                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }

                    foreach (GridViewRow grid in gridMultiple.Rows)
                    {
                        try
                        {
                            if (grid.Cells[0].Text == "MREC")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'MREC' AND TABLEID='GL_MTRANS'", lblSerial_Mrec);
                                if (lblSerial_Mrec.Text == "")
                                {
                                    serialNo = "40000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Mrec.Text);
                                    serial = sl + 1;

                                    iob.SerialNo_MREC = serial.ToString();
                                }

                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                //if (grid.Cells[10].Text == "&nbsp;")
                                //{
                                //    iob.Chequeno = null;
                                //}
                                //else
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;



                                dob.doProcess_MREC_Multiple(iob);
                            }
                            else if (grid.Cells[0].Text == "MPAY")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'MPAY' AND TABLEID='GL_MTRANS'", lblSerial_Mpay);
                                if (lblSerial_Mpay.Text == "")
                                {
                                    serialNo = "45000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Mpay.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;

                                dob.doProcess_MPAY_Multiple(iob);
                            }
                            else if (grid.Cells[0].Text == "JOUR")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'JOUR' AND TABLEID='GL_MTRANS'", lblSerial_Jour);
                                if (lblSerial_Jour.Text == "")
                                {
                                    serialNo = "50000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Jour.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;

                                dob.doProcess_JOUR_Multiple(iob);
                            }
                            else if (grid.Cells[0].Text == "CONT")
                            {
                                DbFunctions.LblAdd(@"Select max(SERIALNO) FROM  GL_MASTER where TRANSDT = '" + trans_DT + "' and TRANSTP = 'CONT' AND TABLEID='GL_MTRANS'", lblSerial_Cont);
                                if (lblSerial_Cont.Text == "")
                                {
                                    serialNo = "55000";
                                    iob.SerialNo_MREC = serialNo;
                                }
                                else
                                {
                                    sl = int.Parse(lblSerial_Cont.Text);
                                    serial = sl + 1;
                                    iob.SerialNo_MREC = serial.ToString();
                                }
                                iob.Transtp = grid.Cells[0].Text;
                                iob.Monyear = grid.Cells[2].Text;
                                iob.TransNo = grid.Cells[3].Text;
                                iob.Transfor = grid.Cells[5].Text;
                                iob.Costpid = grid.Cells[6].Text;
                                iob.Transmode = grid.Cells[7].Text;
                                iob.Debitcd = grid.Cells[8].Text;
                                iob.Creditcd = grid.Cells[9].Text;
                                iob.Chequeno = grid.Cells[10].Text;
                                iob.Chequedt = DateTime.Parse(grid.Cells[11].Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                                iob.Amount = Convert.ToDecimal(grid.Cells[12].Text);
                                string Remarks = grid.Cells[13].Text;
                                if (Remarks == "&nbsp;")
                                {
                                    iob.Remarks = "";
                                }
                                else
                                    iob.Remarks = Remarks;

                                dob.doProcess_CONT_Multiple(iob);
                            }


                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }


                    //StkTransaction();

                    Response.Write("<script>alert('Process Completed.');</script>");
                }
            }
        }


        public void StockTransactionShowGrid()
        {
            ShowGrid_SigleVoucher();
            ShowGrid_Multiple();

            //ShowGrid_Purchase();
            //ShowGrid_Purchase_Ret();
            //ShowGrid_Sale();
            //ShowGrid_Sale_Ret();
            //ShowGrid_Wastage();
            //ShowGrid_SubContractIssue();
            //ShowGrid_SubContractReceive();
        }

        public void StkTransaction()
        {
            //Buy_process();
            //Buy_process_Ret();
            //Sale_process();
            //Sale_process_Ret();
            //Wastage_process();
            //SubContractIssue_process();
            //SubContractReceive_process();
        }




    }
}