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
    public partial class LoginNew : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // bool flg1 = Membership.DeleteUser("chaya.pandey@gmail.com", true);

              //  RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];


                DataTable dt = clsESPSql.ExecQuery("select * from tblmstIndustry ");
               
                Industry.DataSource = dt;
                Industry.DataTextField = "id";
                Industry.DataTextField = "name";
                Industry.DataBind();


            }
            catch (Exception ex)
            {
            }
        }

        //protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        //{
        //    try
        //    {
        //        RegisterUser.UserName = RegisterUser.Email;
        //        string password = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password")).Text;

        //        Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
        //        string Mobile = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Mobile")).Text;

               


        //            TextBox txtVerificationCode = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("txtVerificationCode");
        //            DALCommon cmn = new DALCommon();
        //            DataTable ds = new DataTable();
        //            ds = clsESPSql.ExecQuery("select * from aspnet_Users where username= '" + RegisterUser.Email + "' or mobilealias='" + Mobile + "'");
        //            if (ds.Rows.Count > 0)
        //            {

        //                lblmsg.Text = "Email/Mobile already registerd !";
        //                lblmsg.ForeColor = System.Drawing.Color.Red;

        //                e.Cancel = true;
        //            }
        //            else
        //            {
        //                //CheckBox chkTerm = (CheckBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("chkTerms");
        //                //CheckBox chkPrv = (CheckBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("chkPrivacy");
        //                //if (chkTerm.Checked && chkPrv.Checked)
        //                //{
        //                //    if (txtVerificationCode.Text.ToLower() == Session["CaptchaVerify"].ToString())
        //                //    {

        //                //    }
        //                //    else
        //                //    {

        //                //        lblmsg.Text = "Please enter correct captcha !";
        //                //        lblmsg.ForeColor = System.Drawing.Color.Red;


        //                //        e.Cancel = true;
        //                //    }
        //                //}
        //                //else
        //                //{

        //                //    lblmsg.Text = "Please Accept Terms of Use and Terms of Privacy";
        //                //    lblmsg.ForeColor = System.Drawing.Color.Red;

        //                //    e.Cancel = true;

        //                //}


        //            }
              



        //    }

        //    catch
        //    {
        //    }
        //}

        //protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!Roles.IsUserInRole("Manager"))
        //        {
        //            if (!Roles.RoleExists("Manager"))
        //            {
        //                Roles.CreateRole("Manager");
        //                Roles.AddUserToRole(RegisterUser.UserName, "Manager");
        //            }
        //            else
        //            {
        //                Roles.AddUserToRole(RegisterUser.UserName, "Manager");
        //            }

        //        }
        //        // FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);


        //        Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
        //        string Name = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Name")).Text;
        //        string Designation = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Designation")).Text;
        //        string Mobile = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Mobile")).Text;
        //        string Industry = ((DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Industry")).Text;
        //        string Orgnaisation = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Orgnaisation")).Text;

        //        clsESPSql.ExecNonQuery("update aspnet_Users set mobilealias='" + Mobile + "' where username='" + RegisterUser.UserName + "'");
        //        try
        //        {
        //            LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
        //            DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
        //            MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

        //            objLIBtblOrgBasicInfo.id = -1;
        //            objLIBtblOrgBasicInfo.username = RegisterUser.UserName;
        //            objLIBtblOrgBasicInfo.Name = Name;
        //            objLIBtblOrgBasicInfo.Email = RegisterUser.UserName;
        //            objLIBtblOrgBasicInfo.phone = Mobile;
        //            objLIBtblOrgBasicInfo.designation = Designation;
        //            objLIBtblOrgBasicInfo.OrgName = Orgnaisation;
        //            objLIBtblOrgBasicInfo.industry = Industry;
        //            objLIBtblOrgBasicInfo.dt = DateTime.Now.ToShortDateString();
        //            tp.MessagePacket = objLIBtblOrgBasicInfo;
        //            tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);

        //            //if (tp.MessageId > -1)
        //            //{
        //            //    string[] strOutParamValues = (string[])tp.MessageResultset;

        //            //    Response.Redirect("~/Manager/Default.aspx", false);
        //            //}


        //            RegisterUser.LoginCreatedUser = false;
        //            // lblmsg.Text = " An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
        //        }
        //        catch (Exception ex)
        //        {
        //            MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
        //{
        //    MembershipUser newUserAccount = Membership.GetUser(RegisterUser.UserName);
        //    Guid newUserAccountId = (Guid)newUserAccount.ProviderUserKey;
        //    string domainName = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
        //    string confirmationPage = "EmailConfirmation.aspx?ID=" + newUserAccountId.ToString();
        //    string url = domainName + confirmationPage;
        //    e.Message.Body = e.Message.Body.Replace("<%VerificationUrl%>", url);
        //    DALCommon cmn = new DALCommon();
        //    cmn.SendHtmlFormattedEmail(RegisterUser.Email, "Verification Code", e.Message.Body);
        //    //SmtpClient smtp = new SmtpClient();
        //    //smtp.Host = "smtp.gmail.com";
        //    //smtp.Port = 587;
        //    //smtp.UseDefaultCredentials = false;
        //    //smtp.Credentials = new System.Net.NetworkCredential("YourGmailUserName@gmail.com", "YourGmailPassword");
        //    //smtp.EnableSsl = true;
        //    //smtp.Send(e.Message);
        //    //Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
        //    //lblmsg.Text = "verification URL sent on your register mailid, kindly verify";
        //    //lblmsg.ForeColor = System.Drawing.Color.Red;
        //    RegisterUser.CompleteSuccessText = "An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
        //    e.Cancel = true;

        //}

      

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create new user.
                MembershipCreateStatus status;
                MembershipUser newUser = Membership.CreateUser(Email.Text, Password.Text,Email.Text,null,null,false,out status );
                

                try
                {
                    if (!Roles.IsUserInRole("Manager"))
                    {
                        if (!Roles.RoleExists("Manager"))
                        {
                            Roles.CreateRole("Manager");
                            Roles.AddUserToRole(Email.Text, "Manager");
                        }
                        else
                        {
                            Roles.AddUserToRole(Email.Text, "Manager");
                        }

                    }
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
                        string strBody = "Hello " + Name.Text + "!. You or someone with your id signed up at this site, Your new account is almost ready, but before you can login you need to confirm your email id by visitng the link below: http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString() + " Once you have visited the verification URL, your account will be activated. If you have any problems or questions, please reply to this email. Thanks!";
                        cmn.SendHtmlFormattedEmail(Email.Text, "Verification Code", strBody);
                    
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

                Response.Redirect("login.aspx");
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
       
    }
}