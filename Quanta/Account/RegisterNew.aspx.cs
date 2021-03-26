using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDS.DAL;
using System.Data;
using System.Text.RegularExpressions;
using NDS.LIB;

namespace Quanta.Account
{
    public partial class RegisterNew : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // bool flg1 = Membership.DeleteUser("chaya.pandey@gmail.com", true);


                if (!Page.IsPostBack)
                {
                DataTable dt = clsESPSql.ExecQuery("select * from tblmstIndustry ");
               
                Industry.DataSource = dt;
                Industry.DataTextField = "id";
                Industry.DataTextField = "name";
                Industry.DataBind();
                Industry.Items.Insert(0, new ListItem("Select Industry", ""));
                }


            }
            catch (Exception ex)
            {
            }
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Create new user.
                MembershipCreateStatus status;
                MembershipUser newUser = Membership.CreateUser(Email.Text, Password.Text, Email.Text, null, null, false, out status);


                try
                {
                    //if (!Roles.IsUserInRole("Manager"))
                    //{
                        if (!Roles.RoleExists("Manager"))
                        {
                            Roles.CreateRole("Manager");
                            Roles.AddUserToRole(Email.Text, "Manager");
                        }
                        else
                        {
                            Roles.AddUserToRole(Email.Text, "Manager");
                        }

                    //}
                    // FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);




                    clsESPSql.ExecNonQuery("update aspnet_Users set mobilealias='" + Mobile.Text + "' where username='" + Email.Text + "'");
                    try
                    {
                        LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
                        DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
                        MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                        objLIBtblOrgBasicInfo.id = -1;
                        objLIBtblOrgBasicInfo.username = Email.Text;
                        objLIBtblOrgBasicInfo.Name = Name.Text;
                        objLIBtblOrgBasicInfo.Email = Email.Text;
                        objLIBtblOrgBasicInfo.phone = Mobile.Text;
                        objLIBtblOrgBasicInfo.designation = Designation.Text;
                        objLIBtblOrgBasicInfo.OrgName = Orgnaisation.Text;
                        objLIBtblOrgBasicInfo.industry = Industry.Text;
                        objLIBtblOrgBasicInfo.dt = DateTime.Now.ToShortDateString();
                        tp.MessagePacket = objLIBtblOrgBasicInfo;
                        tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);

                        //if (tp.MessageId > -1)
                        //{
                        //    string[] strOutParamValues = (string[])tp.MessageResultset;

                        //    Response.Redirect("~/Manager/Default.aspx", false);
                        //}
                        MembershipUser userInfo = Membership.GetUser(Email.Text);

                        //Construct the verification URL
                        //  string verifyUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Verify.aspx?ID=" + userInfo.ProviderUserKey.ToString());

                        DALCommon cmn = new DALCommon();
                        string strBody = cmn.prcFindInFile(Server.MapPath("mail.html").ToString(), "#UserName#", Name.Text);
                        strBody = cmn.prcFindInString(strBody, "#VerificationUrl#", "http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString());


                        // strBody = "Hello " + Name.Text + "!. You or someone with your id signed up at this site, Your new account is almost ready, but before you can login you need to confirm your email id by visitng the link below: http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString() + " Once you have visited the verification URL, your account will be activated. If you have any problems or questions, please reply to this email. Thanks!";
                        cmn.SendHtmlFormattedEmail(Email.Text, "Verification Code", strBody);
                        Response.Redirect("Verification.aspx", false);
                        //RegisterUser.LoginCreatedUser = false;
                        // lblmsg.Text = " An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
                    }
                    catch (Exception ex)
                    {
                        MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                    }


                }
                catch (Exception ex)
                {
                }
                // If user created successfully, set password question and answer (if applicable) and 
                // redirect to login page. Otherwise return an error message.

                //if (Membership.RequiresQuestionAndAnswer)
                //{
                //    newUser.ChangePasswordQuestionAndAnswer(Password.Text,
                //                                            PasswordQuestionTextbox.Text,
                //                                            PasswordAnswerTextbox.Text);
                //}

              
            }
            catch (MembershipCreateUserException ex)
            {
                lblErrorMessage.Text = GetErrorMessage(ex.StatusCode);
            }
            catch (HttpException ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that email address already exists. Please enter a different email address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The email address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        //protected void LoginButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (YourValidationFunction(LUserName.Text, LPassword.Text))
        //        {
        //            try
        //            {
        //                bool IsValid = Membership.ValidateUser(LUserName.Text, LPassword.Text);

        //                // e.Authenticated = true;  
        //               if (IsValid)
        //               {
        //                   if (Roles.IsUserInRole(LUserName.Text, "Admin"))
        //                   {
        //                       Response.Redirect("~/Admin/Default.aspx");
        //                   }
        //                   else if (Roles.IsUserInRole(LUserName.Text, "Manager"))
        //                   {
        //                       DataTable ds = new DataTable();
        //                       ds = clsESPSql.ExecQuery("select * from tblOrgBasicInfo where username= '" + LUserName.Text + "'");
        //                       if (ds.Rows.Count > 0)
        //                       {


        //                           Session["orgid"] = ds.Rows[0]["id"].ToString();
        //                       }
        //                       Response.Redirect("~/Manager/Default.aspx");
        //                   }
        //               }
        //               else
        //               {
        //                   FailureText.Text = "Invalid Login Details";
        //                   return;
        //               }

        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //        else
        //        {
        //           FailureText.Text = "Invalid Login Details";
        //            return;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}
        //private bool YourValidationFunction(string UserName, string Password)
        //{
        //    bool boolReturnValue = false;
        //    try
        //    {


        //        DataTable dt = clsESPSql.ExecQuery("select * from aspnet_Users where  (Username='" + UserName + "' or MobileAlias='" + UserName + "') ");

        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {

        //              LUserName.Text = dt.Rows[0]["username"].ToString();

        //                boolReturnValue = true;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return boolReturnValue;
        //}


        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            try
            {


                // e.Authenticated = true;  
                if (Roles.IsUserInRole(LoginUser.UserName, "Admin"))
                {
                    Response.Redirect("~/Admin/Default.aspx");
                }
                else if (Roles.IsUserInRole(LoginUser.UserName, "Manager"))
                {
                    DataTable ds = new DataTable();
                    ds = clsESPSql.ExecQuery("select * from tblOrgBasicInfo where username= '" + LoginUser.UserName + "'");
                    if (ds.Rows.Count > 0)
                    {


                        Session["orgid"] = ds.Rows[0]["id"].ToString();
                    }
                    Response.Redirect("~/Manager/DataEntry1.aspx");
                }

            }
            catch (Exception ex)
            {
            }
        }
        private bool YourValidationFunction(string UserName, string Password)
        {
            bool boolReturnValue = false;
            try
            {


                DataTable dt = clsESPSql.ExecQuery("select * from aspnet_Users where  (Username='" + UserName + "' or MobileAlias='" + UserName + "') ");

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        LoginUser.UserName = dt.Rows[0]["username"].ToString();

                        boolReturnValue = true;

                    }
                }
            }
            catch (Exception ex)
            {
            }

            return boolReturnValue;
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {

                if (YourValidationFunction(LoginUser.UserName, LoginUser.Password))
                {
                    e.Authenticated = true;
                }
                else
                {
                    LoginUser.FailureText = "Invalid Login Details";
                    e.Authenticated = false;
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            try
            {

                //if (YourValidationFunction(LoginUser.UserName, LoginUser.Password))
                //{
                //    // e.Authenticated = true;  

                //}
                //else
                //{
                //    LoginUser.FailureText = "Invalid Login Details";
                //    e.Cancel = true;
                //   //Literal FailureText
                //}

            }
            catch (Exception ex)
            {
            }
        }
    }
}