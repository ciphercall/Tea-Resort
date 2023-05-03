using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;
using DynamicMenu.LogData;

namespace DynamicMenu.WebSitePanel.UI
{
    public partial class RoomInfoEntry : System.Web.UI.Page
    {
        //DynamicMenu.Stock.DataAccess.StockData_Access dob = new DynamicMenu.Stock.DataAccess.StockData_Access();
        //DynamicMenu.Stock.Interface.Stock_Interface iob = new DynamicMenu.Stock.Interface.Stock_Interface();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                string formLink = "/WebSitePanel/UI/RoomInfoEntry.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!Page.IsPostBack)
                    {
                        ShowGrid_Room();
                        lblMaxStID.Visible = false;
                        lblSTID.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/DashBoard/UI/Default.aspx");
                }
            }
        }

        protected void ShowGrid_Room()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from RM_ROOM", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                TextBox txtROOMNM = (TextBox)gvDetails.FooterRow.FindControl("txtROOMNM");
                txtROOMNM.Focus();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                int columncount = gvDetails.Rows[0].Cells.Count;
                gvDetails.Rows[0].Cells.Clear();
                gvDetails.Rows[0].Cells.Add(new TableCell());
                gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                TextBox txtROOMNM = (TextBox)gvDetails.FooterRow.FindControl("txtROOMNM");
                txtROOMNM.Focus();
            }
        }

        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            ShowGrid_Room();
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string USERID = HttpContext.Current.Session["USERID"].ToString();
            string Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
            string UserPC = HttpContext.Current.Session["PCName"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "";
            SqlCommand comm = new SqlCommand(query, conn);



            if (e.CommandName.Equals("AddNew"))
            {
                string STID;
                STID = gvDetails.FooterRow.Cells[0].Text;
                TextBox txtROOMNM = (TextBox)gvDetails.FooterRow.FindControl("txtROOMNM");
                TextBox txtROOMDTL = (TextBox)gvDetails.FooterRow.FindControl("txtROOMDTL");
                TextBox txtROOMQTY = (TextBox)gvDetails.FooterRow.FindControl("txtROOMQTY");
                TextBox txtROOMRT = (TextBox)gvDetails.FooterRow.FindControl("txtROOMRT");
                TextBox txtMaxPeople = (TextBox)gvDetails.FooterRow.FindControl("txtMaxPeople");
                DateTime inTM =DbFunctions.Timezone(DateTime.Now);


                query = ("insert into RM_ROOM(ROOMID, ROOMNM, ROOMDTL, ROOMQTY, ROOMRT, USERPC, INSUSERID, INSIPNO,INSTIME,MAXPEOPLE) " +
                         "values(@STID,'" + txtROOMNM.Text + "','" + txtROOMDTL.Text + "','" + txtROOMQTY.Text + "','" + txtROOMRT.Text + "',@USERPC,@USERID,@INSIPNO,@INSTIME,'"+ txtMaxPeople.Text+"')");

                comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@STID", STID);
                comm.Parameters.AddWithValue("@USERID", USERID);
                comm.Parameters.AddWithValue("@USERPC", UserPC);
                comm.Parameters.AddWithValue("@INSIPNO", Ipaddress);
                comm.Parameters.AddWithValue("@INSTIME", inTM);

                conn.Open();
                int result = comm.ExecuteNonQuery();
                conn.Close();
                ShowGrid_Room();
            }
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            Label lblROOMID = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblROOMID");

            //var txtIp = (TextBox)Master.FindControl("txtIp");
            //var txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
            //iob.IpAddressInsert = txtIp.Text;
            //iob.UserIdInsert = Convert.ToInt64(Session["USERID"].ToString());
            //iob.UserPcInsert = DbFunctions.UserPc();
            //iob.LatiLongTudeInsert = txtLotiLongTude.Text;
            //iob.InTimeInsert = DbFunctions.Timezone(DateTime.Now);


            //// logdata add start //
            //Label lblLogData = new Label();
            //string lotileng = iob.LatiLongTudeInsert;
            //DbFunctions.LblAdd(@"SELECT STOREID+' '+STORENM+' '+ISNULL(ADDRESS,'NULL')+' '++' '+ISNULL(CONTACTNO,'NULL')+' '+ISNULL(REMARKS,'NULL')
            //                    +' '+ISNULL(USERPC,'NULL')+' '+ISNULL(USERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),ACTDTI),'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')
            //                    +' '+ISNULL(IPADDRESS,'NULL')+' '+ISNULL(INSLTUDE,'NULL')+' '+ISNULL(UPDUSERPC,'NULL')
            //                    +' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL')+' '+ISNULL(UPDLTUDE,'NULL')
            //                    FROM STK_STORE WHERE STOREID = '" + lblSTID.Text + "'", lblLogData);
            //string logid = "DELETE";
            //string tableid = "STK_STORE";
            //LogDataFunction.InsertLogData(lotileng, logid, tableid, lblLogData.Text, txtIp.Text);
            //// logdata add start //

            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM RM_ROOM where ROOMID = '" + lblROOMID.Text + "'", conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            if (result == 1)
            {
                ShowGrid_Room();
            }
        }

        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            ShowGrid_Room();
        }

        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string userName = HttpContext.Current.Session["UserName"].ToString();

            string USERID = HttpContext.Current.Session["USERID"].ToString();
            string Ipaddress = HttpContext.Current.Session["IpAddress"].ToString();
          
           // string UserPC = HttpContext.Current.Session["PCName"].ToString();
            DateTime upTM = DbFunctions.Timezone(DateTime.Now);

            //var txtIp = (TextBox)Master.FindControl("txtIp");
            //var txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
            //iob.IpAddressInsert = txtIp.Text;
            //iob.UserIdInsert = Convert.ToInt64(Session["USERID"].ToString());
            //iob.UserPcInsert = dbFunctions.UserPc();
            //iob.LatiLongTudeInsert = txtLotiLongTude.Text;
            //iob.InTimeInsert = dbFunctions.Timezone(DateTime.Now);

            Label lblROOMIDEdit = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblROOMIDEdit");
            TextBox txtROOMNMEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtROOMNMEdit");
            TextBox txtROOMDTLEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtROOMDTLEdit");
            TextBox txtROOMQTYEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtROOMQTYEdit");
            TextBox txtROOMRTEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtROOMRTEdit");
            TextBox txtMaxPeopleEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMaxPeopleEdit");


            //// logdata add start //
            //Label lblLogData = new Label();
            //string lotileng = iob.LatiLongTudeInsert;
            //dbFunctions.lblAdd(@"SELECT STOREID+' '+STORENM+' '+ISNULL(ADDRESS,'NULL')+' '++' '+ISNULL(CONTACTNO,'NULL')+' '+ISNULL(REMARKS,'NULL')
            //                    +' '+ISNULL(USERPC,'NULL')+' '+ISNULL(USERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),ACTDTI),'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),INTIME),'NULL')
            //                    +' '+ISNULL(IPADDRESS,'NULL')+' '+ISNULL(INSLTUDE,'NULL')+' '+ISNULL(UPDUSERPC,'NULL')
            //                    +' '+ISNULL(UPDUSERID,'NULL')+' '+ISNULL(CONVERT(NVARCHAR(20),UPDTIME),'NULL')+' '+ISNULL(UPDIPADDRESS,'NULL')+' '+ISNULL(UPDLTUDE,'NULL')
            //                    FROM STK_STORE WHERE STOREID = '" + lblSTID.Text + "'", lblLogData);
            //string logid = "UPDATE";
            //string tableid = "STK_STORE";
            //LogDataFunction.InsertLogData(lotileng, logid, tableid, lblLogData.Text, txtIp.Text);
            //// logdata add start //

            conn.Open();
            SqlCommand cmd = new SqlCommand("update RM_ROOM set ROOMNM='" + txtROOMNMEdit.Text + "', ROOMDTL='" + txtROOMDTLEdit.Text + "', ROOMQTY='" + txtROOMQTYEdit.Text + "', ROOMRT = '" + txtROOMRTEdit.Text + "', UPDUSERID = '" + USERID + "',UPDTIME = '" + upTM + "',UPDIPNO = '" + Ipaddress + "',MAXPEOPLE='" + txtMaxPeopleEdit.Text + "' where ROOMID = '" + lblROOMIDEdit.Text + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvDetails.EditIndex = -1;
            ShowGrid_Room();
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DbFunctions.LblAdd(@"select MAX(ROOMID) from RM_ROOM", lblMaxStID);

                if (lblMaxStID.Text == "")
                {
                    lblSTID.Text = "101";
                }
                else
                {
                    string MaxSTID = lblMaxStID.Text;
                    int ID = int.Parse(MaxSTID);
                    int CID = ID + 1;
                    string FID = CID.ToString();
                    lblSTID.Text = FID;
                }
                e.Row.Cells[0].Text = lblSTID.Text;
            }
        }
    }
}