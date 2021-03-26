using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDS.DAL;
using System.Web.Security;
namespace Quanta.Account
{
    public partial class Verificationnew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Mobile"] = "9910204114";

        }

        protected void btnresend_Click(object sender, EventArgs e)
        {
            
            if (Session["mailtxt"] != null)
            {
                DALCommon cmn = new DALCommon();
                cmn.SendHtmlFormattedEmail(Session["email"].ToString(), "Verification Code", Session["mailtxt"].ToString());
            }
        }

        protected void btnsendOTP_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "sendmsg", "<SCRIPT LANGUAGE='javascript'>javascript:phoneAuth('" + Session["Mobile"].ToString() + "');</script>");
        }
    }
}