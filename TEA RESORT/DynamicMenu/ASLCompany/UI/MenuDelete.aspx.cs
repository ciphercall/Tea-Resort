using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.ASLCompany.UI
{
    public partial class MenuDelete : System.Web.UI.Page
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);

        readonly DataAccess.ASLDataAccess dob = new DataAccess.ASLDataAccess();
        readonly Interface.ASLInterface iob = new Interface.ASLInterface();
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
                    txtModuleName.Focus();
                    lblMsg.Visible = false;
                }
            }
        }

        protected void txtModuleName_TextChanged(object sender, EventArgs e)
        {
            if (txtModuleName.Text != "")
            {
                string checkModuleNmFromDb =
                       DbFunctions.StringData("SELECT MODULENM FROM ASL_MENUMST WHERE MODULENM='" + txtModuleName.Text + "'");
                if (checkModuleNmFromDb == "")
                {
                    lblMsg.Text = "Module name not present.";
                    lblMsg.Visible = true;
                    txtModuleName.Text = "";
                    lblModuleID.Text = "";
                    Session["ModuleId"] = null;
                    txtModuleName.Focus();
                }
                else
                {
                    lblModuleID.Text = "";
                    DbFunctions.LblAdd("SELECT MODULEID FROM ASL_MENUMST WHERE MODULENM='" + txtModuleName.Text + "'", lblModuleID);
                    Session["ModuleId"] = lblModuleID.Text;
                    lblMsg.Visible = false;
                    txtMenuName.Focus();
                }
            }
            else
            {
                lblMsg.Text = "Write Module Name.";
                lblMsg.Visible = true;
                txtModuleName.Text = "";
                txtModuleName.Focus();
            }
        }

        protected void txtMenuName_TextChanged(object sender, EventArgs e)
        {
            if (txtMenuName.Text != "")
            {
                if (lblModuleID.Text == "")
                {
                    lblMsg.Text = "Write Module Name.";
                    lblMsg.Visible = true;
                    txtModuleName.Text = "";
                    txtModuleName.Focus();
                }
                else
                {
                    string checkMenuNmFromDb =
                       DbFunctions.StringData("Select MENUID from ASL_MENU WHERE MODULEID ='" + lblModuleID.Text + "' AND MENUNM='" + txtMenuName.Text.Trim() + "'");
                    if (checkMenuNmFromDb == "")
                    {
                        lblMsg.Text = "Menu name not present.";
                        lblMsg.Visible = true;
                        txtMenuName.Text = "";
                        lblMenuID.Text = "";
                        txtMenuName.Focus();
                    }
                    else
                    {
                        lblMenuID.Text = checkMenuNmFromDb;
                        lblMsg.Visible = false;
                        btnDeleteMenu.Focus();
                    }
                }
            }
            else
            {
                lblMsg.Text = "Write Menu Name.";
                lblMsg.Visible = true;
                txtMenuName.Text = "";
                txtMenuName.Focus();
            }
        }
        protected void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (lblModuleID.Text == "")
            {
                lblMsg.Text = "Write Module Name.";
                lblMsg.Visible = true;
                lblModuleID.Text = "";
                lblModuleID.Focus();
            }
            else if (lblMenuID.Text == "")
            {
                lblMsg.Text = "Write Menu Name.";
                lblMsg.Visible = true;
                txtMenuName.Text = "";
                txtMenuName.Focus();
            }
            else
            {
                iob.ModuleId = lblModuleID.Text;
                iob.MenuId = lblMenuID.Text;
                int countMenu =
                    Convert.ToInt16(DbFunctions.StringData("Select count(MENUID) As MENUID from ASL_MENU WHERE MODULEID ='" + iob.ModuleId + "'"));
                if (countMenu > 1)
                {
                    dob.DELETE_ASL_MENU(iob);
                    lblMsg.Text = "Menu Delete Successfully.";
                    lblMsg.Visible = true;
                    txtMenuName.Text = "";
                    lblMenuID.Text = "";
                    txtMenuName.Focus();
                }
                else
                {
                    dob.DELETE_ASL_MENU(iob);
                    dob.DELETE_ASL_MENUMST(iob);
                    lblMsg.Text = "Menu And Module Delete Successfully.";
                    lblMsg.Visible = true;
                    txtModuleName.Text = "";
                    txtMenuName.Text = "";
                    lblMenuID.Text = "";
                    lblModuleID.Text = "";
                    txtModuleName.Focus();
                }
            }
        }

        protected void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMenuType.SelectedValue == "S")
            {
                
            }
            else
            {
                Session["MenuType"] = ddlMenuType.SelectedValue;
            }
        }

    }
}