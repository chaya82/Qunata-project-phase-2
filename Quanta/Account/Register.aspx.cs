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
    public partial class Register : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
           
            }
            catch(Exception ex)
            {
            }
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
                        Session["orglevel"] = ds.Rows[0]["orglevel"].ToString();

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
        protected void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                LIBtblmstContact objLIBtblmstContact = new LIBtblmstContact();
                DALtblmstContact objDALtblmstContact = new DALtblmstContact();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblmstContact.id = -1;
                objLIBtblmstContact.Name = txtname.Text;
                objLIBtblmstContact.Email = txtEmail.Text;
                objLIBtblmstContact.phone = txtPHONE.Text;
                objLIBtblmstContact.designation = txtDESIGNATION.Text;
                objLIBtblmstContact.OrgName = txtORGANIZATION.Text;
                objLIBtblmstContact.dt = DateTime.Now.ToShortDateString();
                if (rdoBasic.Checked == true)
                {
                    objLIBtblmstContact.INTREST = rdoBasic.Text;
                }
                if (rdoPro.Checked == true)
                {
                    objLIBtblmstContact.INTREST = rdoPro.Text;
                }
                tp.MessagePacket = objLIBtblmstContact;
                tp = objDALtblmstContact.InserttblmstContact(tp);

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;

                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
            try
            {
                DALCommon cmn = new DALCommon();
                string strBody = cmn.prcFindInFile(Server.MapPath("sendmail.html").ToString(), "#name#", txtname.Text);
                //strBody = cmn.prcFindInString(strBody, "#VerificationUrl#", "http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString());


                // strBody = "Hi " + txtname.Text + ", You or someone with your id signed up at this site, Your new account is almost ready, but before you can login you need to confirm your email id by visitng the link below: http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString() + " Once you have visited the verification URL, your account will be activated. If you have any problems or questions, please reply to this email. Thanks!";
                cmn.SendHtmlFormattedEmail(txtEmail.Text, "Contact  inQsights", strBody);
                ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:alert('Thank you for showing your intrest!');</script>");
            }
            catch (HttpException ex)
            {

            }
        }
    }
}
