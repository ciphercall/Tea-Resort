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
    public partial class SliderImage : System.Web.UI.Page
    {
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
                string formLink = "/WebSitePanel/UI/SliderImage.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission)
                {
                    LoadData();
                }
                else
                {
                    Response.Redirect("../../DeshBoard/UI/Default.aspx");
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                iob.ImageId = txtImgId.Text;
                iob.FileName = ImageUpload(fileUpload, iob.ImageId);

                var s = dob.INSERT_RES_Slide(iob);
                if (s == "")
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = false;
                    Refresh();
                    LoadData();
                }
                else
                {
                    lblMsg.Text = iob.ImageId+" No slide Already Exists.";
                    lblMsg.Visible = true;
                }
            }
        }

        private void LoadData()
        {
            SqlConnection con=new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand(@"SELECT ID, SL, CASE WHEN isnull(IMGPATH, '') = '' THEN '/UploadImage/SliderImage/demo.png' 
            ELSE IMGPATH END AS IMGPATH FROM RES_SLIDE", con);

            cmd.Connection.Open();
            rpt.DataSource = cmd.ExecuteReader();
            rpt.DataBind();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
        private void Refresh()
        {
            txtImgId.Text = "";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string DeleteSlide(string id)
        {
            var filepath = DbFunctions.StringData($@"SELECT IMGPATH FROM RES_SLIDE WHERE ID='{id}'");
            var s = DbFunctions.ExecuteCommand($@"DELETE FROM RES_SLIDE wHERE ID='{id}'");
            if (s == "")
            {
                string path = @"~" + filepath;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                return "done";
            }
            else
                return "server error";
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
                                fd.SaveAs(Server.MapPath("~/UploadImage/SliderImage/" + fileNmunique + fileName));
                                img = "/UploadImage/SliderImage/" + fileNmunique + fileName;
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