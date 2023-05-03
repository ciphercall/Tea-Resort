﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.ASLCompany.UI
{
    public partial class UserDelete : System.Web.UI.Page
    {
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
                    if (Session["USERTYPE"].ToString() == "COMPADMIN")
                    {
                        lblCompanyId.Text = Session["COMPANYID"].ToString();
                        DbFunctions.TxtAdd("SELECT COMPNM FROM ASL_COMPANY WHERE COMPID='" + lblCompanyId.Text + "'", txtCompanyName);
                        txtCompanyName.ReadOnly = true;
                    }
                }
            }
        }

        protected void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                lblMsg.Text = "Select Compamy Name.";
                lblMsg.Visible = true;
                Refresh();
            }
            else
            {
                lblCompanyId.Text = "";
                DbFunctions.LblAdd("SELECT COMPID FROM ASL_COMPANY WHERE COMPNM='" + txtCompanyName.Text + "'", lblCompanyId);

                if (lblCompanyId.Text == "")
                {
                    txtCompanyName.Text = "";
                    txtCompanyName.Focus();
                    Refresh();
                }
                else
                {
                    txtUserName.Focus();
                }
            }
        }

        public void Refresh()
        {
            txtUserName.Text = "";
            txtUserName.Focus();
        }
    }
}