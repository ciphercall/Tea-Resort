using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicMenu
{
    public partial class webScrep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebRequest wreq = WebRequest.Create("http://www.learn24bd.com");
            WebResponse wRes = wreq.GetResponse();
            StreamReader sR=new StreamReader(wRes.GetResponseStream());
            string sHtml = sR.ReadToEnd();
            sR.Close();
            if (sHtml != string.Empty && sHtml != null)
            {
                literal1.Text = sHtml;
            }
        }
    }
}