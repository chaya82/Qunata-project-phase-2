using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Quanta.Account
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("YourGmailUserName@gmail.com", "YourGmailPassword");
            //smtp.EnableSsl = true;
            //smtp.Send(e.Message);
            //Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
            //lblmsg.Text = "verification URL sent on your register mailid, kindly verify";
            //lblmsg.ForeColor = System.Drawing.Color.Red;
            if (!Roles.IsUserInRole("Manager"))
            {
                if (!Roles.RoleExists("Manager"))
                {
                    Roles.CreateRole("Manager");
                    Roles.AddUserToRole(RegisterUser.UserName, "Manager");
                }
                else
                {
                    Roles.AddUserToRole(RegisterUser.UserName, "Manager");
                }

            }
        }

        protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {

        }

        protected void RegisterUser_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

        }

        protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
        {

        }
    }
}