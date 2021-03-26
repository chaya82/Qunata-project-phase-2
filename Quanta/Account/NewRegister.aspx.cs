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
    public partial class NewRegister : System.Web.UI.Page
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
                    DropDownList ddlindustry = (DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Industry");
                    ddlindustry.DataSource = dt;
                    ddlindustry.DataTextField = "id";
                    ddlindustry.DataTextField = "name";
                    ddlindustry.DataBind();
                    ddlindustry.Items.Insert(0, new ListItem("Select Industry", ""));
                }

                
            }
            catch(Exception ex)
            {
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {

            try
            {
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
               FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
               
               
                Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
                string Name = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Name")).Text;
                string Designation = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Designation")).Text;
                string Mobile = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Mobile")).Text;
                string Industry = ((DropDownList)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Industry")).Text;
                string Orgnaisation = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Orgnaisation")).Text;
                string pwd = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password")).Text;
                clsESPSql.ExecNonQuery("update aspnet_Users set pwd='" + pwd + "', mobilealias='" + Mobile + "' where username='" + RegisterUser.UserName + "'");
                try
                {
                    LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
                    DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
                    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                    objLIBtblOrgBasicInfo.id = -1;
                    objLIBtblOrgBasicInfo.username = RegisterUser.UserName;
                    objLIBtblOrgBasicInfo.Name = Name;
                    objLIBtblOrgBasicInfo.Email = RegisterUser.UserName;
                    objLIBtblOrgBasicInfo.phone = Mobile;
                    objLIBtblOrgBasicInfo.designation = Designation;
                    objLIBtblOrgBasicInfo.OrgName = Orgnaisation;
                    objLIBtblOrgBasicInfo.industry = Industry;
                    objLIBtblOrgBasicInfo.dt = DateTime.Now.ToShortDateString();
                    tp.MessagePacket = objLIBtblOrgBasicInfo;
                    tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);
                  
                    //if (tp.MessageId > -1)
                    //{
                    //    string[] strOutParamValues = (string[])tp.MessageResultset;
                    //
                    Session["Mobile"] = Mobile;
                    MembershipUser newUserAccount = Membership.GetUser(RegisterUser.UserName);
                    Guid newUserAccountId = (Guid)newUserAccount.ProviderUserKey;
                    Session["ID"] = newUserAccountId.ToString(); 
                    Response.Redirect("Verificationnew.aspx", false);
                    //}

                   // Page.ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:   document.getElementById('ahrfcreate').click();</script>");
                  RegisterUser.LoginCreatedUser = true;
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
            
        }

        protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            try
            {
                RegisterUser.UserName = RegisterUser.Email;
                string password = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password")).Text;

                Label lblmsg = (Label)RegisterUserWizardStep.ContentTemplateContainer.FindControl("lblErrorMessage");
                string Mobile = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Mobile")).Text;


                    
                    TextBox txtVerificationCode = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("txtVerificationCode");
                    DALCommon cmn = new DALCommon();
                    DataTable ds = new DataTable();
                    ds = clsESPSql.ExecQuery("select * from aspnet_Users where username= '" + RegisterUser.Email + "' or mobilealias='" + Mobile + "'");
                    if (ds.Rows.Count > 0)
                    {
                        
                        lblmsg.Text = "Email/Mobile already registerd !";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        Page.ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:   document.getElementById('ahrfcreate').click();</script>");
                        e.Cancel = true;
                    }
                    else
                    {
                        CheckBox chkTerm = (CheckBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("chkTerms");
                     
                        if (chkTerm.Checked )
                        {
                           
                        }
                        else
                        {

                            lblmsg.Text = "Please Accept Terms of Use and Terms of Privacy";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            Page.ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:   document.getElementById('ahrfcreate').click();</script>");
                            e.Cancel = true;

                        }


                    }
               


            }

            catch
            {
            }
        }
        protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
        {
            MembershipUser newUserAccount = Membership.GetUser(RegisterUser.UserName);
            Guid newUserAccountId = (Guid)newUserAccount.ProviderUserKey;
            string domainName = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            string confirmationPage = "EmailConfirmation.aspx?ID=" + newUserAccountId.ToString();
            string url = domainName + confirmationPage;
            string Name = ((TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Name")).Text;
            e.Message.Body = e.Message.Body.Replace("<%VerificationUrl%>", url);
            e.Message.Body = e.Message.Body.Replace(" <%Name%>", Name);
           
            DALCommon cmn = new DALCommon();
            cmn.SendHtmlFormattedEmail(RegisterUser.Email, "Verification Code", e.Message.Body);

            Session["mailtxt"] = e.Message.Body.ToString();
            Session["email"]=RegisterUser.Email;
            Page.ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:   document.getElementById('ahrfcreate').click();</script>");
            RegisterUser.CompleteSuccessText = "An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
            e.Cancel = true;
        }
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            try
            {
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
                    Response.Redirect("~/Manager/dashboard.aspx");
                }
                else if (Roles.IsUserInRole(LoginUser.UserName, "DataEntry"))
                {
                    DataTable ds = new DataTable();
                    ds = clsESPSql.ExecQuery("select * from tblmstorgusers where email= '" + LoginUser.UserName + "'");
                    if (ds.Rows.Count > 0)
                    {


                        Session["orgid"] = ds.Rows[0]["orgid"].ToString();
                    }
                    Response.Redirect("~/DataEntry/DataEntry1.aspx");
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
                    if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password))
                    {
                        e.Authenticated = true;
                    }
                    else
                    {
                        LoginUser.FailureText = "Invalid Login Details";
                        e.Authenticated = false;
                    }
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
    }
}
