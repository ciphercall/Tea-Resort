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
    public partial class RoomFeatures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                string formLink = "/WebSitePanel/UI/RoomFeatures.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!Page.IsPostBack)
                    {
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
            SqlCommand cmd = new SqlCommand($@"Select * from RM_ROOMFS WHERE ROOMID='{txtRoomId.Text}'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                TextBox txtFSTP = (TextBox)gvDetails.FooterRow.FindControl("txtFSTP");
                txtFSTP.Focus();
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
                TextBox txtFSTP = (TextBox)gvDetails.FooterRow.FindControl("txtFSTP");
                txtFSTP.Focus();
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
                string FSID;
                FSID = gvDetails.FooterRow.Cells[0].Text;
                TextBox txtFSID = (TextBox)gvDetails.FooterRow.FindControl("txtFSID");
                TextBox txtFSTP = (TextBox)gvDetails.FooterRow.FindControl("txtFSTP");
                TextBox txtFSDATA = (TextBox)gvDetails.FooterRow.FindControl("txtFSDATA");
                DateTime inTM = DbFunctions.Timezone(DateTime.Now);


                query = ("insert into RM_ROOMFS(ROOMID, FSID, FSTP, FSDATA, USERPC, INSUSERID, INSIPNO,INSTIME) " +
                         "values('" + txtRoomId.Text + "',@RMID,'" + txtFSTP.Text + "','" + txtFSDATA.Text + "',@USERPC,@USERID,@INSIPNO,@INSTIME)");

                comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@RMID", FSID);
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

            Label lblFSID = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblFSID");

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
            SqlCommand cmd = new SqlCommand($@"DELETE FROM RM_ROOMFS where ROOMID = '{txtRoomId.Text}' AND FSID= '{lblFSID.Text}' ", conn);
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
            TextBox txtFSTPEdit = (TextBox)gvDetails.Rows[e.NewEditIndex].FindControl("txtFSTPEdit");
            txtFSTPEdit.Focus();
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

            Label lblFSIDEdit = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblFSIDEdit");
            TextBox txtFSDATAEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtFSDATAEdit");
            TextBox txtFSTPEdit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtFSTPEdit");


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
            SqlCommand cmd = new SqlCommand("update RM_ROOMFS set FSTP='" + txtFSTPEdit.Text + "', FSDATA='" + txtFSDATAEdit.Text + "', UPDUSERID = '" + USERID + "',UPDTIME = '" + upTM + "',UPDIPNO = '" + Ipaddress + "' where ROOMID = '" + txtRoomId.Text + "' AND FSID='" + lblFSIDEdit.Text + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvDetails.EditIndex = -1;
            ShowGrid_Room();

        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DbFunctions.LblAdd($@"select MAX(FSID) from RM_ROOMFS WHERE ROOMID='{txtRoomId.Text}'", lblMaxStID);

                if (lblMaxStID.Text == "")
                {
                    lblSTID.Text = txtRoomId.Text + "01";
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

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (txtRoomNM.Text == "")
            {
                Response.Write("<script>alert('Please Select Room');</script>");
            }
            else if (txtRoomId.Text == "")
            {
                Response.Write("<script>alert('Please Select Room');</script>");
            }
            else
            {
                ShowGrid_Room();
            }
        }
    }
}