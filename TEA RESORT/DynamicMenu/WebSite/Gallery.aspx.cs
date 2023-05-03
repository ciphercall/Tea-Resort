using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.WebSite
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbFunctions.RepeaterAdd(rpttr1, "SELECT A.ALBAMID,A.IMGID,A.ALBAMNM,B.IMGURL FROM ( " +
                                            " SELECT DISTINCT ALBAMID, ALBAMNM, MIN(IMGID) IMGID FROM RM_GALLERYIMG GROUP BY ALBAMID, ALBAMNM) A  " +
                                            " LEFT OUTER JOIN RM_GALLERYIMG B ON A.IMGID = B.IMGID AND IMGURL LIKE('%' + IMGURL + '%') ORDER BY A.ALBAMNM");
        }

        protected void rpttr1_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BidNow")
            {
              string[] arguments = e.CommandArgument.ToString().Split(new char[] { ',' });
                string albamnm = arguments[0];
                string albamid = arguments[1];
                string imgurl = arguments[2];
                string imgid = arguments[3];
                Session["AlbamNM"] = albamnm.ToString();
                Session["AlbamID"] = albamid.ToString();
                Session["ImgUrl"] = imgurl.ToString();
                Session["ImgID"] = imgid.ToString();
                Response.Redirect("/WebSite/AlbamAllImages.aspx");
            }
        }
    }
}