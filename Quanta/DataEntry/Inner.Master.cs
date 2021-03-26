using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Quanta.DataEntry
{
    public partial class Inner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["orgid"] == null)
                {
                    Response.Redirect("~/Account/Register.aspx", false);

                }
                else
                {
                 
                    //lbluser.Text = User.Identity.Name;
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}