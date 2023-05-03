﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.Accounts.Report.UI
{
    public partial class RptNotesAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
                Response.Redirect("~/Login/UI/Login.aspx");
            else
            {
                const string formLink = "/Accounts/Report/UI/RptNotesAcc.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        DateTime today = DbFunctions.Timezone(DateTime.Today.Date);
                        string td = DbFunctions.Dayformat(today);
                        txtFrom.Text = td;
                        txtTo.Text = td;
                        ddlLevelID.Focus();
                    }
                }
                else
                {
                    Response.Redirect("../../../DeshBoard/UI/Default.aspx");
                }
            }
        }

        protected void ddlLevelID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddlLevelID"] = "";
            if (ddlLevelID.Text == "1")
            {
                Session["ddlLevelID"] = ddlLevelID.Text;
                Session["LevelCD"] = "";
                Session["AccNM"] = "";
            }
            else if (ddlLevelID.Text == "2")
            {
                Session["ddlLevelID"] = ddlLevelID.Text;
                Session["LevelCD"] = "";
                Session["AccNM"] = "";
            }
            else if (ddlLevelID.Text == "3")
            {
                Session["ddlLevelID"] = ddlLevelID.Text;
                Session["LevelCD"] = "";
                Session["AccNM"] = "";
            }
            else if (ddlLevelID.Text == "4")
            {
                Session["ddlLevelID"] = ddlLevelID.Text;
                Session["LevelCD"] = "";
                Session["AccNM"] = "";
            }
            txtHeadNM.Text = "";
            txtAccHeadCD.Text = "";
            txtHeadNM.Focus();
        }

       

        protected void txtHeadNM_TextChanged(object sender, EventArgs e)
        {
            Session["LevelCD"] = "";
            Session["AccNM"] = "";
            if (txtHeadNM.Text != "")
            {
                string txtHDNM = txtHeadNM.Text;
                string trimHDNM = txtHDNM.Substring(0, txtHDNM.Length - 8);
                int Lvl = txtHDNM.LastIndexOf(" (");
                string l = txtHDNM.Substring(Lvl);
                string Level = l.Substring(6, 1);

                Session["AccNM"] = trimHDNM;
                Session["LevelCD"] = Level;

                txtAccHeadCD.Text = "";

                DbFunctions.TxtAdd("Select ACCOUNTCD from GL_ACCHART where LEVELCD= '" + Level + "' and ACCOUNTNM = '" + trimHDNM + "'", txtAccHeadCD);
            }
            else
                txtHeadNM.Text = "";
            txtHeadNM.Focus();

            btnSearch.Focus();
        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Focus();
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlLevelID.Text == "SELECT")
            {
                Response.Write("<script>alert('Select Transaction Type.');</script>");
                ddlLevelID.Focus();
            }
            else if (txtHeadNM.Text == "")
            {
                Response.Write("<script>alert('Select Account Head.');</script>");
                txtHeadNM.Focus();
            }
            else if (txtFrom.Text == "")
            {
                Response.Write("<script>alert('Select From Date.');</script>");
            }
            else if (txtTo.Text == "")
            {
                Response.Write("<script>alert('Select To Date.');</script>");
            }
            else
            {
                string txtHDNM = txtHeadNM.Text;
                string trimHDNM = txtHDNM.Substring(0, txtHDNM.Length - 8);
                int Lvl = txtHDNM.LastIndexOf(" (");
                string l = txtHDNM.Substring(Lvl);
                string Level = l.Substring(6, 1);

                Session["AccNM"] = trimHDNM;
                Session["LevelCD"] = Level;

                Session["TransLevel"] = ddlLevelID.Text;
                Session["AccCode"] = txtAccHeadCD.Text;
                Session["From"] = txtFrom.Text;
                Session["To"] = txtTo.Text;

                Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('../Report/rptNotesAccount.aspx','_newtab');", true);
            }
        }
    }
}