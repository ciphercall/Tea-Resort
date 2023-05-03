using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;
using DynamicMenu.WebSitePanel.DataAccess;
using DynamicMenu.WebSitePanel.Interface;

namespace DynamicMenu.WebSitePanel.UI
{
    public partial class NewsFeed : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        WebSiteDataAccess dob = new WebSiteDataAccess();
        WebSiteInterface iob = new WebSiteInterface();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                string formLink = "/WebSitePanel/UI/NewsFeed.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission)
                {

                }
                else
                {
                    Response.Redirect("../../DeshBoard/UI/Default.aspx");
                }
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<NewsFedd> ShowNewsFeed()
        {
            List<NewsFedd> lst = new List<NewsFedd>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand objSqlcommand = new SqlCommand(@"SELECT TOP 20   NEWSID, CONVERT(NVARCHAR, NEWSDT,103) NEWSDT, 
            NHEAD, NTITLE, DESCRIPTION, IMGPATH FROM RES_NEWS ORDER BY NEWSID DESC", conn))
            {
                conn.Open();
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string newsid = objResult["NEWSID"].ToString().TrimEnd();
                    string date = objResult["NEWSDT"].ToString().TrimEnd();
                    string head = objResult["NHEAD"].ToString().TrimEnd();
                    string title = objResult["NTITLE"].ToString().TrimEnd();
                    string description = objResult["DESCRIPTION"].ToString().TrimEnd();
                    string img = objResult["IMGPATH"].ToString().TrimEnd();
                    lst.Add(new NewsFedd { NewsId = newsid, Date = date, HeadName = head, Title = title, Descrition = description, FileName = img });
                }
                var q = lst.ToList();
                return q;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string DeleteNewsFeed(string id)
        {
            var filepath = $@"SELECT IMGPATH FROM RES_NEWS WHERE NEWSID='{id}'";
            var s=DbFunctions.ExecuteCommand($@"DELETE FROM RES_NEWS wHERE NEWSID='{id}'");
            if (s == "")
            {
                string path = @"~"+ filepath;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                return "done";
            }
            else
                return "server error";
        }
       
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                iob.LotiLenInsUpd = Session["Location"].ToString();
                iob.IpAddressInsUpd = Session["IpAddress"].ToString();
                iob.UserIdInsUpd = Convert.ToInt64(Session["USERID"].ToString());
                iob.UserPcInsUpd = DbFunctions.UserPc();
                iob.InTimeInsUpd = DbFunctions.Timezone(DateTime.Now);

                iob.HeadName = txtHead.Text;
                iob.Title = txtTitle.Text;
                iob.Descrition = txtDescription.Text;
                iob.NewsId = DbFunctions.StringData("SELECT ISNULL(MAX(NEWSID),0)+1 FROM RES_NEWS");
                iob.FileName = ImageUpload(fileUpload, iob.NewsId);

                var s = dob.INSERT_RES_NEWS(iob);
                if (s == "")
                {
                    Refresh();
                }
            }
        }

        private void Refresh()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtHead.Text = "";
        }

        public string ImageUpload(FileUpload fd, string fileNmunique)
        {
            string img = "";
            try
            {
                if (fd.HasFile)
                {
                    string fileName = fd.FileName;
                    string exten = Path.GetExtension(fileName);

                    if (fd.FileBytes.Length > 600000)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Upload Image to large! file must be less then 512kb";
                    }
                    else
                    {
                        lblMsg.Visible = false;

                        //here we have to restrict file type            
                        if (exten != null)
                        {
                            exten = exten.ToLower();
                            var acceptedFileTypes = new string[4];
                            acceptedFileTypes[0] = ".jpg";
                            acceptedFileTypes[1] = ".jpeg";
                            acceptedFileTypes[2] = ".gif";
                            acceptedFileTypes[3] = ".png";
                            bool acceptFile = false;
                            for (int i = 0; i <= 3; i++)
                            {
                                if (exten == acceptedFileTypes[i])
                                {
                                    acceptFile = true;
                                }
                            }
                            if (!acceptFile)
                            {
                                lblMsg.Visible = true;
                                lblMsg.Text = "Upload Image is not a permitted file type!";
                                fd.Focus();
                            }
                            else
                            {
                                //upload the file onto the server                   
                                fd.SaveAs(Server.MapPath("~/UploadImage/NewsFeedImg/" + fileNmunique + fileName));
                                img = "/UploadImage/NewsFeedImg/" + fileNmunique + fileName;
                            }
                        }
                    }
                }
                else
                    img = "";
            }
            catch (Exception)
            {
                img = "";
            }


            return img;
        }
    }
}