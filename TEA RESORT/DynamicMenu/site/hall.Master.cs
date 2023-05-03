using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPenalWatchCtg.site
{
    public partial class hall : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    HttpCookie PU_Read = HttpContext.Current.Request.Cookies["PUBLICUSER"];//Output Data
                    if (PU_Read != null)
                    {
                        //string id = MyFunctions.DecryptString(PU_Read["USERID_PUBLIC"].ToString());
                        //UserNM.Text = MyFunctions.GetData("SELECT NAME FROM PUBLICUSRREG WHERE ID='" + id + "'");
                    }
                }
                catch { }
            }
        }
    }
}