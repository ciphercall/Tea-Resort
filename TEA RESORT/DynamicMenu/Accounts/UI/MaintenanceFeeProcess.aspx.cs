﻿using System;
using System.Web;
using AlchemyAccounting;

namespace DynamicMenu.Accounts.UI
{
    public partial class MaintenanceFeeProcess : System.Web.UI.Page
    {
        readonly IFormatProvider _dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Login/UI/Login.aspx");
            }
            else
            {
                string formLink = "/Accounts/UI/MaintenanceFeeProcess.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission)
                {
                    if (!Page.IsPostBack)
                    {
                        txtDate.Text = DbFunctions.Timezone(DateTime.Now).ToString("dd/MM/yyyy");
                        txtEffectDate.Text = txtDate.Text;

                        DateTime datetrans = DateTime.Parse(txtDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        string mon = datetrans.ToString("MMM").ToUpper();
                        string yr = datetrans.ToString("yy");
                        txtMonthYear.Text = mon + "-" + yr;

                        var date = DateTime.Parse(txtDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        DbFunctions.DropDownAddWithSelect(ddlTransno,
                            @"SELECT TRANSNO FROM GL_MTRANSMST WHERE TRANSTP='" + ddlTransType.SelectedValue + "' AND TRANSDT='" + date + "'");
                        ddlTransno.Focus();

                        DateTime transdate = DateTime.Parse(txtEffectDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                        string month = transdate.ToString("MMM").ToUpper();
                        string years = transdate.ToString("yy");

                        txtEffectMonthYear.Text = month + "-" + years;
                        string maxtransno = DbFunctions.StringData(@"Select max(TRANSNO) FROM GL_MTRANSMST where TRANSMY='" + txtEffectMonthYear.Text +
                            "' and TRANSTP = '" + ddlTransType.Text + "'");
                        if (maxtransno == "")
                        {
                            txtEffectTransno.Text = "1";
                        }
                        else
                        {
                            int vNo = int.Parse(maxtransno);
                            int totVno = vNo + 1;
                            txtEffectTransno.Text = totVno.ToString();
                        }
                    }
                }
                else
                {
                    Response.Redirect("../../DeshBoard/UI/Default.aspx");
                }
            }
        }
        protected void txtDate_OnTextChanged(object sender, EventArgs e)
        {
            DateTime datetrans = DateTime.Parse(txtDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string mon = datetrans.ToString("MMM").ToUpper();
            string yr = datetrans.ToString("yy");
            txtMonthYear.Text = mon + "-" + yr;

            var date = DateTime.Parse(txtDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            DbFunctions.DropDownAddWithSelect(ddlTransno,
                @"SELECT TRANSNO FROM GL_MTRANSMST WHERE TRANSTP='" + ddlTransType.SelectedValue + "' AND TRANSDT='" + date + "'");
            ddlTransno.Focus();
        }

        protected void txtEffectDate_OnTextChanged(object sender, EventArgs e)
        {
            DateTime transdate = DateTime.Parse(txtEffectDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            string month = transdate.ToString("MMM").ToUpper();
            string years = transdate.ToString("yy");

            txtEffectMonthYear.Text = month + "-" + years;
            string maxtransno = DbFunctions.StringData(@"Select max(TRANSNO) FROM GL_MTRANSMST where TRANSMY='" + txtEffectMonthYear.Text +
                "' and TRANSTP = '" + ddlTransType.Text + "'");
            if (maxtransno == "")
            {
                txtEffectTransno.Text = "1";
            }
            else
            {
                int vNo = int.Parse(maxtransno);
                int totVno = vNo + 1;
                txtEffectTransno.Text = totVno.ToString();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (ddlTransno.Text == "" || ddlTransno.Text == "--SELECT--")
            {
                lblMsg.Text = "Select transaction no.";
                lblMsg.Visible = true;
                ddlTransno.Focus();
            }
            else if (txtMonthYear.Text == "")
            {
                lblMsg.Text = "Select date.";
                lblMsg.Visible = true;
                txtDate.Focus();
            }
            else if (txtEffectMonthYear.Text == "")
            {
                lblMsg.Text = "Select date.";
                lblMsg.Visible = true;
                txtEffectDate.Focus();
            }
            else
            {
                string transdate = DateTime.Parse(txtDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal).ToString("yyyy-MM-dd");
                DateTime transdateeffect = DateTime.Parse(txtEffectDate.Text, _dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
                string month = transdateeffect.ToString("MMM").ToUpper();
                string years = transdateeffect.ToString("yy");
                txtEffectMonthYear.Text = month + "-" + years;

                string maxtransno = DbFunctions.StringData(@"Select max(TRANSNO) FROM GL_MTRANSMST where TRANSMY='" + txtEffectMonthYear.Text +
                "' and TRANSTP = '" + ddlTransType.Text + "'");
                if (maxtransno == "")
                {
                    txtEffectTransno.Text = "1";
                }
                else
                {
                    int vNo = int.Parse(maxtransno);
                    int totVno = vNo + 1;
                    txtEffectTransno.Text = totVno.ToString();
                }
                string userName = HttpContext.Current.Session["USERID"].ToString();
                string ipAddress = HttpContext.Current.Session["IpAddress"].ToString();
                string pcName = HttpContext.Current.Session["PCName"].ToString();
                string inTm = DbFunctions.Timezone(DateTime.Now).ToString("yyyy-MM-dd hh:mm:ss tt");

                DbFunctions.ExecuteCommand(@"INSERT INTO GL_MTRANSMST(TRANSTP, TRANSDT, TRANSMY, TRANSNO, USERPC, USERID, INTIME, IPADDRESS) 
                VALUES('" + ddlTransType.SelectedValue + "', '" + transdateeffect + "', '" + txtEffectMonthYear.Text + "', '" + txtEffectTransno.Text +
                "', '" + pcName + "', '" + userName + "', '" + inTm + "', '" + ipAddress + "')");

                DbFunctions.ExecuteCommand(@"INSERT INTO GL_MTRANS(TRANSTP, TRANSDT, TRANSMY, TRANSNO, SERIALNO, TRANSFOR, COSTPID, TRANSMODE, DEBITCD, CREDITCD, CHEQUENO, CHEQUEDT, AMOUNT, REMARKS, USERPC, USERID,  INTIME, IPADDRESS)
                SELECT TRANSTP, '" + transdateeffect + "', '" + txtEffectMonthYear.Text + "', " + txtEffectTransno.Text + ", SERIALNO, TRANSFOR, COSTPID, TRANSMODE, DEBITCD, CREDITCD, CHEQUENO, CHEQUEDT, AMOUNT, '" + txtRemarks.Text + "', '" + pcName + "', '" + userName + "', '" + inTm + "', '" + ipAddress + 
                "' FROM            GL_MTRANS WHERE TRANSTP='" + ddlTransType.SelectedValue + "' AND TRANSDT='" + transdate + 
                "' AND TRANSMY='" + txtMonthYear.Text + "' AND TRANSNO='" + ddlTransno.Text + "'");

                lblMsg.Text = "Process Complete.";
                lblMsg.Visible = true;

                maxtransno = DbFunctions.StringData(@"Select max(TRANSNO) FROM GL_MTRANSMST where TRANSMY='" + txtEffectMonthYear.Text +
                "' and TRANSTP = '" + ddlTransType.Text + "'");
                if (maxtransno == "")
                {
                    txtEffectTransno.Text = "1";
                }
                else
                {
                    int vNo = int.Parse(maxtransno);
                    int totVno = vNo + 1;
                    txtEffectTransno.Text = totVno.ToString();
                }

                txtRemarks.Text = "";
                ddlTransno.SelectedIndex = -1;
                ddlTransno.Focus();
            }
        }

    }
}