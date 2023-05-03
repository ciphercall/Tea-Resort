using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace AdminPenalWatchCtg.site
{
    /// <summary>
    /// Summary description for fight
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class fight : System.Web.Services.WebService
    {
        SqlConnection con;
        SqlCommand cmd;

        public fight()
        {
            con = new SqlConnection(DbFunctions.Connection);
            cmd = new SqlCommand("", con);
        }
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        HttpCookie GetData = new HttpCookie("CommunityID");//Input data
        HttpCookie Inc = new HttpCookie("Inc1");//Input data
        HttpCookie IncRead = HttpContext.Current.Request.Cookies["Inc1"];//Output Data
        HttpCookie CookiesData = HttpContext.Current.Request.Cookies["CommunityID"];//Output Data

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(EnableSession = true)]
        public object UploadFile()
        {
            string result = "false";
            string id = "";
            //if (Session["Inc"] == null)
            //    id = "1";
            //else
            //    id=(Convert.ToInt16(HttpContext.Current.Session["Inc"].ToString())+1).ToString();
            string Community = "";
            if (CookiesData.Value != null)
                Community = CookiesData["Community"].ToString();
            string url = "";
            for (int i = 1; i < 9; i++)
            {

                //HttpContext.Current.Session["ss"] = 2;
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    try
                    {
                        string address = "";
                        // Get the uploaded image from the Files collection
                        var httpPostedFile = HttpContext.Current.Request.Files["Upload" + i];
                        string extn = httpPostedFile.FileName;
                        extn = extn.Substring(extn.Length - 4, 4);
                        address = Community + "-" + i + extn;
                        if (i == 1)
                            url += address;
                        else
                            url += "+" + address;
                        if (httpPostedFile != null)
                        {
                            // Validate the uploaded image(optional) 
                            // Get the complete file path
                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("/site/cover/"), address);
                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(fileSavePath);
                            result = "true";

                        }
                    }
                    catch { }
                }
            }
          //  MyFunctions.Execute("UPDATE COMUREG SET IMAGEURL='" + url + "'  WHERE COMUID='" + Community + "'");
            return result;
        }
    }
}
