using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.WebSite
{
    public partial class room_details : System.Web.UI.Page
    {
        HttpCookie CookiesData = HttpContext.Current.Request.Cookies["indexCookies"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    var roomId = CookiesData["CKRmID"].ToString();
                    DbFunctions.RepeaterAdd(repChildImg, $@"SELECT IMGURL FROM RM_ROOMIMG WHERE ROOMID='{roomId}'");

                    DbFunctions.RepeaterAdd(rpterFac, $@"SELECT FSTP,FSDATA FROM RM_ROOMFS WHERE ROOMID = '{roomId}'");

                    txtcheckinDt.Text = CookiesData["CKCheckinDt"].ToString();
                    txtnight.Text = CookiesData["CKNight"].ToString();
                    txtcheckOutdt.Text = CookiesData["CKCheckoutDt"].ToString();
                    txtAdults.Text = CookiesData["CKAdults"].ToString();
                    txtchildren.Text = CookiesData["CKhildren"].ToString();
                    txtrooms.Text = CookiesData["CKRoomQty"].ToString();
                  
                }
                catch (Exception ex)
                {

                }

            }
        }


        protected void OnserverClick_bookNow(object sender, EventArgs e)
        {
            try
            {
                if (txtcheckinDt.Text == "")
                {
                    Response.Write("<script>alert('Select check in Date.');</script>");
                    txtcheckinDt.Focus();
                }
                else if (txtcheckOutdt.Text == "")
                {
                    Response.Write("<script>alert('Select check Out Date.');</script>");
                    txtcheckOutdt.Focus();
                }
                else if (txtcheckOutdt.Text == "")
                {
                    Response.Write("<script>alert('Select check Out Date.');</script>");
                    txtcheckOutdt.Focus();
                }
                else if (txtrooms.Text == "")
                {
                    Response.Write("<script>alert('Select room quantity.');</script>");
                    txtrooms.Focus();
                }
                else if (txtnight.Text == "")
                {
                    Response.Write("<script>alert('Select total Night.');</script>");
                    txtnight.Focus();
                }
                else if (txtAdults.Text == "")
                {
                    Response.Write("<script>alert('Select adult people.');</script>");
                    txtAdults.Focus();
                }
                else if (txtchildren.Text == "")
                {
                    Response.Write("<script>alert('Select children.');</script>");
                    txtchildren.Focus();
                }

                else
                {
                    Response.Redirect("booking.aspx");
                }
            }
            catch (Exception ex)
            {
                Exception E = ex;
            }
        }

    }
}