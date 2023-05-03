using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlchemyAccounting;

namespace DynamicMenu.ASLCompany.UI
{
    public partial class MenuUpdate : System.Web.UI.Page
    {
        private IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);

        private DataAccess.ASLDataAccess dob = new DataAccess.ASLDataAccess();
        private Interface.ASLInterface iob = new Interface.ASLInterface();

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
                    DbFunctions.StringData("SELECT MODULENM FROM ASL_MENUMST WHERE MODULENM='" + txtModuleName.Text +
                                           "'");
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
                    DbFunctions.LblAdd("SELECT MODULEID FROM ASL_MENUMST WHERE MODULENM='" + txtModuleName.Text + "'",
                        lblModuleID);
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

        protected void btnUpdateMenu_Click(object sender, EventArgs e)
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
            else if (txtMenuLink.Text == "")
            {
                lblMsg.Text = "Write Menu Link.";
                lblMsg.Visible = true;
                txtMenuLink.Text = "";
                txtMenuLink.Focus();
            }
            
            else
            {
                iob.IpAddressUpdate = DbFunctions.IpAddress();
                iob.UserIdUpdate = Convert.ToInt64(Session["USERID"].ToString());
                iob.UserPcUpdate = DbFunctions.UserPc();
                iob.InTimeUpdate = DbFunctions.Timezone(DateTime.Now);

                iob.ModuleId = lblModuleID.Text;
                iob.MenuId = lblMenuID.Text;
                iob.MenuLink = txtMenuLink.Text;
                iob.MenuName = txtMenuName.Text;

                string s=dob.UPDATE_ASL_MENU(iob);
                if (s == "")
                {
                    lblMsg.Text = "Updated Succesfully.";
                    lblMsg.Visible = true;
                }
                else
                {
                    lblMsg.Text = "Data not Updated.";
                    lblMsg.Visible = true;
                }
                txtMenuName.Text = "";
                txtMenuLink.Text = "";
                lblMenuID.Text = "";
                txtMenuName.Focus();

            }
        }



    }
} ;