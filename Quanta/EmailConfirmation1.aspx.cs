using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Quanta
{
    public partial class EmailConfirmation1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid newUserId = new Guid(Request.QueryString["ID"]);
            MembershipUser newUser = Membership.GetUser(newUserId);


            if (newUser == null)
            {
                lblMessage.Text = "User Account not found";
            }
            else
            {
                newUser.IsApproved = true;
                Membership.UpdateUser(newUser);
                lblMessage.Text = "Account Approved, please <a href='Account/Login.aspx'> Login</a> to continue";
            }
        }
    }
}