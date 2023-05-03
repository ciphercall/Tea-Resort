﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;
using DynamicMenu.LogData;

namespace DynamicMenu
{
    public partial class Dynamic : System.Web.UI.MasterPage
    {
        ASLCompany.DataAccess.ASLDataAccess dob = new ASLCompany.DataAccess.ASLDataAccess();
        ASLCompany.Interface.ASLInterface iob = new ASLCompany.Interface.ASLInterface();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string companyId = Session["COMPANYID"].ToString();

                    DbFunctions.LblAdd(@"SELECT ASL_COMPANY.COMPNM FROM ASL_COMPANY INNER JOIN
                      ASL_USERCO ON ASL_COMPANY.COMPID = ASL_USERCO.COMPID WHERE ASL_USERCO.COMPID='" + companyId + "'", lblCompanyName);

                    if (txtIp.Text != "")
                        Session["IpAddress"] = txtIp.Text;
                }
                catch (Exception)
                {
                    //ignore
                }
                if (Session["USERID"] == null || Session["COMPANYID"] == null)
                {
                    Response.Redirect("~/LogIn/UI/LogIn.aspx");
                }
                else
                {
                    try
                    {
                        lblUserName.Text = Session["USERNAME"].ToString();
                        string usertype = Session["USERTYPE"].ToString();
                        if (usertype == "SUPERADMIN")
                            lblAdmin.Text = "Super Admin";
                        else if (usertype == "COMPADMIN")
                            lblAdmin.Text = "Company Admin";
                        else if (usertype == "USERADMIN")
                            lblAdmin.Text = "User Admin";
                        else
                            lblAdmin.Text = "User";

                        string companyId = Session["COMPANYID"].ToString();

                        DbFunctions.LblAdd(@"SELECT ASL_COMPANY.COMPNM FROM ASL_COMPANY INNER JOIN
                      ASL_USERCO ON ASL_COMPANY.COMPID = ASL_USERCO.COMPID WHERE ASL_USERCO.COMPID='" + companyId + "'", lblCompanyName);


                    }
                    catch (Exception)
                    {
                        //ignore
                    }

                }
            }
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            // logdata add start //
            string lotileng = txtLotiLongTude.Text;
            string logdata = "User Name: " + Session["USERID"] + ", User Type: " + Session["USERTYPE"];
            string logid = "LOGOUT";
            string tableid = "ASL_USERCO";
            LogDataFunction.InsertLogData(lotileng, logid, tableid, logdata, txtIp.Text);
            // logdata add start //

            Session.RemoveAll();

            var httpCookie = Response.Cookies["USERID"];
            if (httpCookie != null) httpCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/LogIn/UI/LogIn.aspx");
        }
    }
}