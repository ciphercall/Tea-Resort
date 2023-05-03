﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.Accounts.Report.UI
{
    public partial class RptReceiptsPayStatSeleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERID"] == null)
                Response.Redirect("~/Login/UI/Login.aspx");
            else
            {
                const string formLink = "/Accounts/Report/UI/RptReceiptsPayStatSeleted.aspx";
                bool permission = UserPermissionChecker.checkParmit(formLink, "STATUS");
                if (permission == true)
                {
                    if (!IsPostBack)
                    {
                        DateTime today = DbFunctions.Timezone(DateTime.Today.Date);
                        string td = DbFunctions.Dayformat(today);
                        txtFrom.Text = td;
                        txtTo.Text = td;
                        DbFunctions.DropDownAddTextWithValue(ddlHeadName, @"SELECT ACCOUNTNM , ACCOUNTCD  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102') and STATUSCD='P'");
                        ddlHeadName.Focus();
                    }
                }
                else
                {
                    Response.Redirect("../../../DeshBoard/UI/Default.aspx");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                Response.Write("<script>alert('Fill Required Data');</script>");
            }
            else
            {
                Session["HeadCD"] = ddlHeadName.SelectedValue;
                Session["HeadNM"] = ddlHeadName.SelectedItem.Text;
                Session["From"] = txtFrom.Text;
                Session["To"] = txtTo.Text;
                Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('../Report/rptReceiptPaymentStateSelected.aspx','_newtab');", true);
                // Response.Redirect("../Report/rptReceiptPaymentStateSelected.aspx");
            }
        }
    }
}