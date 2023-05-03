using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.WebSite
{
    public partial class AlbamAllImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var albamnm = Session["AlbamNM"].ToString();
                var albamid = Session["AlbamID"].ToString();
                var imgurl = Session["ImgUrl"].ToString();
                var imgid = Session["ImgID"].ToString();
                DbFunctions.RepeaterAdd(rpttr1, $@"SELECT IMGURL FROM RM_GALLERYIMG WHERE ALBAMID='{albamid}'");

            }
        }
    }
}