using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Mail;
using NDS.DAL;

namespace Quanta.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
            //if (!Membership.EnablePasswordRetrieval)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}

            //Msg.Text = "";

            //if (!IsPostBack)
            //{
            //    Msg.Text = "Please supply a username.";
            //}
            //else
            //{
            //    VerifyUsername();
            //}
        }


        public void VerifyUsername()
        {
            MembershipUser u = Membership.GetUser(UsernameTextBox.Text, false);

            if (u == null)
            {
                Msg.Text = "Username " + Server.HtmlEncode(UsernameTextBox.Text) + " not found. Please check the value and re-enter.";

                EmailPasswordButton.Enabled = false;
            }
            else
            {

                EmailPasswordButton.Enabled = true;
            }
        }


        public void EmailPassword_OnClick(object sender, EventArgs args)
        {
            MembershipUser user = Membership.GetUser(UsernameTextBox.Text, false);
            string password;

            if (user != null)
            {
                try
                {
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    System.Data.DataTable dt = clsESPSql.ExecQuery("select * from aspnet_Users where username= '" + UsernameTextBox.Text + "' or mobilealias='" + UsernameTextBox.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        EmailPassword(user.Email, dt.Rows[0]["pwd"].ToString());
                        Msg.Text = "Password sent via email.";
                        
                    }
                    // Attempt to find the user
                    
                        // Unlock them if needed
                      //  user.UnlockUser();

                      //  // They exist, so attempt to reset their password
                      //  user.ResetPassword();

                      //  // Change the user's password
                      //  var newPassword =
                      //      // 0 = Number of non alphanumeric characters
                      //Membership.GeneratePassword(Membership.MinRequiredPasswordLength, 0);
                      //  password = newPassword;
                      //  user.ChangePassword(user.ResetPassword(), newPassword);
                   
                }
                catch (Exception e)
                {
                    Msg.Text = "An exception occurred retrieving your password: " + Server.HtmlEncode(e.Message);
                    return;
                }

               
            }
            else
            {
                Msg.Text = "User name is not valid. Please check the value and try again.";
            }
        }


        private void EmailPassword(string email, string password)
        {
            try
            {
                string strBody = "Your password is: " + Server.HtmlEncode(password);

                DALCommon cmn = new DALCommon();
                cmn.SendHtmlFormattedEmail(email, "Quanta Password", strBody);
               
            }
            catch
            {
                Msg.Text = "An exception occurred sending your password. Please try again.";
            }
        }

    }
}