using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;
using DynamicMenu.LogIn.DataAccess;
using DynamicMenu.LogIn.Interface;

namespace DynamicMenu.LogIn.UI
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        LogInDataAccess dob = new LogInDataAccess();
        LogInInterface iob = new LogInInterface();
        SqlConnection con = new SqlConnection(DbFunctions.Connection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    Response.Redirect("~/LogIn/UI/LogIn.aspx");
                }
                else
                {
                    txtOldPass.Focus();
                }
            }
        }

        public void Refresh()
        {
            txtOldPass.Text = "";
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
            txtOldPass.Focus();
        }
        public class CheckResultWithMsg
        {
            public string Msg { get; set; }
            public bool CheckResult { get; set; }
        }

        public CheckResultWithMsg FieldCheck()
        {
            bool checkResult = false;
            string msg = "";
            if (txtConfirmPass.Text == "")
            {
                msg = "Fill confirm password field.";
            }
            else if (txtNewPass.Text == "")
            {
                msg = "Fill new password field.";
            }
            else if (txtOldPass.Text == "")
            {
                msg = "Fill old password fiel.";

            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                msg = "Password mismatch.";
            }
            else
            {
                checkResult = true;
            }
            return new CheckResultWithMsg()
            {
                Msg = msg,
                CheckResult = checkResult
            };
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string unm = Session["UserName"].ToString();

            if (FieldCheck().CheckResult == false)
            {
                Response.Write("<script>alert('" + FieldCheck().Msg + "')</script>");
                Refresh();
            }
            else
            {
                string userId = Session["USERID"].ToString();
                string logPassword = DbFunctions.StringData("SELECT LOGINPW FROM ASL_USERCO WHERE  USERID='" + userId + "'");
                if (logPassword == txtOldPass.Text)
                {
                    var txtLotiLongTude = (TextBox)Master.FindControl("txtLotiLongTude");
                    iob.LotiLengTudeUpdate = txtLotiLongTude.Text;
                    iob.IpAddressUpdate = DbFunctions.IpAddress();
                    iob.UserIdUpdate = Convert.ToInt64(Session["USERID"].ToString());
                    iob.UserPcUpdate = DbFunctions.UserPc();
                    iob.InTimeUpdate = DbFunctions.Timezone(DateTime.Now);

                    iob.UserID = Convert.ToInt64(Session["USERID"].ToString());
                    iob.Password = txtNewPass.Text;

                    string s = dob.UPDATE_ASL_PASSWORD(iob);
                    if (s == "")
                        NullSession();
                    else
                    {
                        Response.Write("<script>alert('Passwrod not changed, please try again.')</script>");
                        Refresh();
                    }

                }
                else
                {
                    Response.Write("<script>alert('Old password is wrong')</script>");
                    txtOldPass.Focus();
                    txtOldPass.Text = "";
                }

            }
        }

        public void NullSession()
        {
            Response.Write("<script>alert('Passwrod Change Successfully')</script>");
            Session["UserName"] = null;
            Session["PCName"] = null;
            Session["IpAddress"] = null;
            Session["BrCD"] = null;
            Session["USERTYPE"] = null;
            Response.Redirect("login.aspx");
        }
    }
}
