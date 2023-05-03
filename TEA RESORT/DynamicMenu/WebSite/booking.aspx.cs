using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.WebSite
{
    public partial class booking : System.Web.UI.Page
    {
        SqlConnection conn;
        HttpCookie CookiesData = HttpContext.Current.Request.Cookies["indexCookies"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var CheckinDt = "";
                //CheckinDt = Session["CheckinDt"].ToString();
                //var Night = "";
                //Night = Session["Night"].ToString();
                //var CheckoutDt = "";
                //CheckoutDt = Session["CheckoutDt"].ToString();
                //var Adults = "";
                //Adults = Session["Adults"].ToString();
                //var Children = "";
                //Children = Session["Children"].ToString(); 
                //TextBox txtRoomSelect = (TextBox)repeater.FindControl("txtRoomSelect");

                //Repeater repeater = (Repeater) sender(NamingContainer);
                //Repeater rp = ((Repeater)((TextBox)sender).NamingContainer);
                //TextBox txtRoomSelect = (TextBox)rp.FindControl("txtRoomSelect");
                //TextBox txtRoomSelect = (TextBox)(repeater.Items[0].FindControl("txtRoomSelect"));




                var CheckinDt = CookiesData["CKCheckinDt"].ToString();
                var Night = CookiesData["CKNight"].ToString();
                var CheckoutDt = CookiesData["CKCheckoutDt"].ToString();
                var Adults = CookiesData["CKAdults"].ToString();
                var Children = CookiesData["CKhildren"].ToString();
                var roomQty = CookiesData["CKRoomQty"].ToString();
                var roomchngeqty = CookiesData["CKRoomQty"].ToString();


                txtcheckinDt.Text = CheckinDt.ToString();
                txtnight.Text = Night.ToString();
                txtAdults.Text = Adults.ToString();
                txtchildren.Text = Children.ToString();
                txtcheckOutdt.Text = CheckoutDt.ToString();
                txtrooms.Text = roomQty.ToString();

               



                DbFunctions.RepeaterAdd(repeater, "SELECT DISTINCT C.ROOMNM,C.ROOMRT,IMGURL,B.IMGID,B.ROOMID FROM(" +
                                   "SELECT DISTINCT MIN(IMGID) IMGID FROM RM_ROOMIMG GROUP BY SUBSTRING(CONVERT(NVARCHAR(10), IMGID, 103), 1, 3))" +
                                   "A LEFT OUTER JOIN RM_ROOMIMG B ON A.IMGID = B.IMGID LEFT OUTER JOIN RM_ROOM C ON B.ROOMID = C.ROOMID AND IMGURL LIKE('%' + IMGURL + '%')");
                foreach (RepeaterItem rptItem in repeater.Items)
                {
                    TextBox txtRoomSelect = (TextBox)rptItem.FindControl("txtRoomSelect");
                    txtRoomSelect.Text = roomchngeqty.ToString();
                }

            }
        }

        //public void showRepeter()
        //{
        //    HttpCookie CookiesData = HttpContext.Current.Request.Cookies["UserInfo"];//Output Data
        //    string UI = CookiesData["UserName"].ToString();
        //    if (UI == "rokon@eastport.com.bd")
        //    {
        //        if (Session["data"] != null)
        //        {
        //            ArrayList Data = new ArrayList();
        //            Data = (ArrayList)Session["data"];
        //            //for (int i = 0; i < Data.Count; i++)
        //            // {
        //            //     this.ListBox1.Items.Add(new ListItem(cities[i].ToString(), cities[i].ToString()));
        //            repeater.DataSource = Data;
        //            repeater.DataBind();
        //            //}
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("/permission.aspx");
        //    }

        //}
        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            conn = new SqlConnection(DbFunctions.Connection);

            Label lblROOMID = (Label)e.Item.FindControl("lblROOMID");

            SqlCommand cmd = new SqlCommand($@" SELECT TOP (6) FSTP+' :'+FSDATA FS FROM RM_ROOMFS WHERE ROOMID='{lblROOMID.Text}'", conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DATA", lblROOMID.Text);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            GridView GridView3 = (GridView)(e.Item.FindControl("GridView3"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView3.DataSource = ds;
                GridView3.DataBind();
                GridView3.Visible = true;
            }
            else
            {
                GridView3.DataSource = ds;
                GridView3.DataBind();
                GridView3.Visible = false;
            }
        }
    }
}