using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;
using DynamicMenu.LogData;
using DynamicMenu.LogIn.DataAccess;
using DynamicMenu.LogIn.Interface;

namespace DynamicMenu.LogIn.UI
{
    public partial class LogIn : System.Web.UI.Page
    {
        readonly LogInDataAccess _dob = new LogInDataAccess();
        readonly LogInInterface _iob = new LogInInterface();
        readonly WebClient _chcksmsqtySndSms = new WebClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                var userid = "";
                var httpCookie = Request.Cookies["USERID"];
                if (httpCookie != null)
                {
                    userid = Server.HtmlEncode(httpCookie.Value);
                }

                if (userid != "")
                {
                    var useremail = DbFunctions.StringData("SELECT LOGINID FROM ASL_USERCO WHERE USERID='" + userid + "'");
                    SessionDeclare(useremail);

                    // logdata add start //
                    string lotileng = txtLotiLongTude.Text;
                    string logdata = "Log in Id: " + txtUser.Text + ", User Type: " + Session["USERTYPE"];
                    string logid = "LOGIN";
                    string tableid = "ASL_USERCO";
                    LogDataFunction.InsertLogData(lotileng, logid, tableid, logdata, txtIp.Text);
                    // logdata add start //

                    string urllink = txtlink.Text;
                    if (urllink == "" || urllink == "javascript:__doPostBack('ctl00$lnkLogOut','')" || urllink == "javascript:__doPostBack('ctl00$ContentPlaceHolder1$linkBUpdate','')")
                        Response.Redirect("~/DeshBoard/UI/Default.aspx");
                    else
                        Response.Redirect(urllink);
                }
                else
                {
                    txtUser.Focus();
                }
            }
        }

        public string FieldCheck()
        {
            string checkResult = "";
            if (txtUser.Text == "")
            {
                checkResult = "Please write email of user name.";
                txtUser.Focus();
            }
            else if (txtPassword.Text == "")
            {
                checkResult = "Please write password.";
                txtPassword.Focus();
            }
            else
            {
                checkResult = "true";
            }

            return checkResult;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (FieldCheck() == "true")
            {
                string passByEmial = DbFunctions.StringData("SELECT LOGINPW FROM ASL_USERCO WHERE LOGINID='" + txtUser.Text + "'");

                if (passByEmial != "")
                {

                    if (passByEmial == txtPassword.Text)
                    {
                        string timeFrom = DbFunctions.StringData("SELECT TIMEFR FROM ASL_USERCO WHERE LOGINID='" + txtUser.Text + "'");
                        string timeTo = DbFunctions.StringData("SELECT TIMETO FROM ASL_USERCO WHERE LOGINID='" + txtUser.Text + "'");
                        string userStatus = DbFunctions.StringData("SELECT STATUS FROM ASL_USERCO WHERE LOGINID='" + txtUser.Text + "'");
                        DateTime todayDate = DbFunctions.Timezone(DateTime.Now);
                        TimeSpan logTimeSpan = TimeSpan.Parse(DbFunctions.TimeFormat(todayDate));
                        TimeSpan timeForSpan = TimeSpan.Parse(timeFrom);
                        TimeSpan timeToSpan = TimeSpan.Parse(timeTo);
                        if (timeForSpan <= logTimeSpan && logTimeSpan <= timeToSpan && userStatus == "A")
                        {
                            SessionDeclare(txtUser.Text);

                            // logdata add start //
                            string lotileng = txtLotiLongTude.Text;
                            string logdata = "Log in Id: " + txtUser.Text + ", User Type: " + Session["USERTYPE"];
                            string logid = "LOGIN";
                            string tableid = "ASL_USERCO";
                            LogDataFunction.InsertLogData(lotileng, logid, tableid, logdata, txtIp.Text);
                            // logdata add start //
                            string urllink = txtlink.Text;
                            if (urllink == "" || urllink.Substring(0, 1) == "j")
                                Response.Redirect("~/DeshBoard/UI/Default.aspx");
                            else
                                Response.Redirect(urllink);

                        }
                        else
                        {
                            lblMsg.Text = "Your log in time: " + DateTime.ParseExact(timeFrom, "HH:mm", null).ToString("hh:mm tt") + " to." + DateTime.ParseExact(timeTo, "HH:mm", null).ToString("hh:mm tt") + "";
                            lblMsg.Visible = true;
                        }

                    }
                    else
                    {
                        lblMsg.Text = "Wrong user name & password.";
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "Wrong user name & password.";
                    lblMsg.Visible = true;
                }
            }
            else
            {
                lblMsg.Text = FieldCheck();
                lblMsg.Visible = true;
            }
        }

        public void SessionDeclare(string user)
        {
            SqlConnection con = new SqlConnection(DbFunctions.Connection);
            con.Open();
            string query = "SELECT USERNM, OPTP, COMPID, USERID, BRANCHCD FROM ASL_USERCO WHERE LOGINID='" + user + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Session["USERNAME"] = dr[0].ToString();
                Session["USERTYPE"] = dr[1].ToString();
                Session["USERTYPE"] = dr[1].ToString();
                Session["COMPANYID"] = dr[2].ToString();
                Session["USERID"] = dr[3].ToString();
                Session["BrCD"] = dr[4].ToString();
            }
            dr.Close();
            con.Close();
            Session["LOGINID"] = user;
            Session["Location"] = txtLotiLongTude.Text;

            //string ip =
            //_chcksmsqtySndSms.DownloadString("https://api.ipify.org/");
            string ip = "";
            if (txtIp.Text != "")
                Session["IpAddress"] = txtIp.Text;
            else if (ip != "")
                Session["IpAddress"] = ip;
            else
                Session["IpAddress"] = DbFunctions.IpAddress();

            Session["PCName"] = DbFunctions.UserPc();

            if (checkRememebrMe.Checked)
            {
                var httpCookie = Response.Cookies["USERID"];
                if (httpCookie != null) httpCookie.Value = Session["USERID"].ToString();
                var cookie = Response.Cookies["USERID"];
                if (cookie != null)
                    cookie.Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Request.Cookies.Remove("USERID");
            }
        }

    }
}