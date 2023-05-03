using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.WebSite
{
    public partial class Index : System.Web.UI.Page
    {
        HttpCookie GetData = new HttpCookie("indexCookies");//Input data in cookie
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    DateTime today = DbFunctions.Timezone(DateTime.Now);
                    txtCheckIn.Text = today.ToString("yyyy-MM-dd");
                    txtcheckOut.Text = today.ToString("yyyy-MM-dd");

                    DbFunctions.RepeaterAdd(rpttr1,
                        "SELECT DISTINCT TOP(3) C.ROOMNM,C.ROOMRT,IMGURL,B.IMGID,B.ROOMID FROM(" +
                        "SELECT DISTINCT MIN(IMGID) IMGID FROM RM_ROOMIMG GROUP BY SUBSTRING(CONVERT(NVARCHAR(10), IMGID, 103), 1, 3))" +
                        "A LEFT OUTER JOIN RM_ROOMIMG B ON A.IMGID = B.IMGID LEFT OUTER JOIN RM_ROOM C ON B.ROOMID = C.ROOMID AND IMGURL LIKE('%' + IMGURL + '%')");
                    //GetData["nipu"] = "1";
                    //Response.Cookies.Add(GetData);
                    //GetData.Expires.AddDays(7);
                }
                catch (Exception ex)
                {

                }

            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<TowValue> GetSliderName()
        {
            var lst = new List<TowValue>();
            var conn = new SqlConnection(DbFunctions.Connection);
            using (var objSqlcommand = new SqlCommand(@"SELECT TOP (5) ID, IMGPATH, SL FROM RES_SLIDE 
            WHERE (SL BETWEEN 1 AND 5) ORDER BY SL", conn))
            {
                conn.Open();
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["IMGPATH"].ToString().TrimEnd();
                    string id = objResult["SL"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return q;
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<TowValue> GetRoomImg()
        {
            var lst = new List<TowValue>();
            var conn = new SqlConnection(DbFunctions.Connection);
            using (var objSqlcommand = new SqlCommand(@"SELECT TOP (5) ID, IMGPATH, SL FROM RES_SLIDE 
            WHERE (SL BETWEEN 1 AND 5) ORDER BY SL", conn))
            {
                conn.Open();
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["IMGPATH"].ToString().TrimEnd();
                    string id = objResult["SL"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return q;
            }
        }

        protected void GetRoomDetails_onclick(object sender, EventArgs e)
        {
            //Repeater row = ((Repeater)((Label)sender).NamingContainer);
            Label lbTemp = (Label)rpttr1.FindControl("lblROOMID");

            Label lblROOMID = (Label)rpttr1.FindControl("lblROOMID");
            Label lblIMGURL = (Label)rpttr1.FindControl("lblIMGURL");

            int liEmployeeCode = Convert.ToInt32(Request.QueryString["lblROOMID"]);

            //Session["RmID"] = lblIMGURL.Text;
            //Session["ImgUrl"] = lblIMGURL.Text;


            //var httpCookie = Response.Cookies["ROOMID"];

        }

        protected void rpttr1_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BidNow")
            {
                //Repeater row = ((Repeater)((Label)source).NamingContainer);

                //Label lblROOMID = (Label)row.FindControl("lblROOMID");
                //Label lblIMGURL = (Label)row.FindControl("lblIMGURL");

                string[] arguments = e.CommandArgument.ToString().Split(new char[] { ',' });
                string rmID = arguments[0];

                string rmImgUrl = arguments[1];
                string RmRT = arguments[2];
                string rmNM = arguments[3];

                //Session["RmID"] = rmID.ToString();
                //Session["ImgUrl"] = rmImgUrl.ToString();
                //Session["RmRT"] = RmRT.ToString();
                //Session["RmNM"] = rmNM.ToString();

                GetData["CKRmID"] = rmID.ToString();
                GetData["CKImgUrl"] = rmImgUrl.ToString();
                GetData["CKRmRT"] = RmRT.ToString();
                GetData["CKRmNM"] = rmNM.ToString();

                GetData["CKCheckinDt"] = txtCheckIn.Text;
                GetData["CKNight"] = txtNight.Text;
                GetData["CKCheckoutDt"] = txtcheckOut.Text;
                GetData["CKAdults"] = txtAdults.Text;
                GetData["CKhildren"] = txtChildren.Text;
                GetData["CKRoomQty"] = txtRoomQty.Text;

                Response.Cookies.Add(GetData);
                GetData.Expires.AddDays(7);

                Response.Redirect("/WebSite/room-details.aspx");
            }
        }

        protected void bookNow_onclick(object sender, EventArgs e)
        {
            GetData["CKCheckinDt"] = txtCheckIn.Text;
            GetData["CKNight"] = txtNight.Text;
            GetData["CKCheckoutDt"] = txtcheckOut.Text;
            GetData["CKAdults"] = txtAdults.Text;
            GetData["CKhildren"] = txtChildren.Text;
            GetData["CKRoomQty"] = txtRoomQty.Text;
            Response.Cookies.Add(GetData);
            GetData.Expires.AddDays(7);


            //Session["CheckinDt"] = txtCheckIn.Text;
            //Session["Night"] = txtNight.Text;
            //Session["CheckoutDt"] = txtcheckOut.Text;
            //Session["Adults"] = txtAdults.Text;
            //Session["Children"] = txtChildren.Text;
            Response.Redirect("booking.aspx");
        }





    }
}