using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace Quanta
{
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                   
                    // string strpwd = newUser.GetPassword();
                    bool isValid = true;
                    if (isValid)
                    {
                        try
                        {
                            if (Roles.IsUserInRole(newUser.UserName, "Admin"))
                            {
                                Response.Redirect("~/Admin/Default.aspx");
                            }
                            else if (Roles.IsUserInRole(newUser.UserName, "Manager"))
                            {
                                DataTable ds = new DataTable();
                                ds = clsESPSql.ExecQuery("select * from tblOrgBasicInfo where username= '" + newUser.UserName + "'");
                                if (ds.Rows.Count > 0)
                                {

                                    //IdentityHelper.SignIn(manager, user, isPersistent: false);
                                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                                    Session["orgid"] = ds.Rows[0]["id"].ToString();
                                }
                                FormsAuthentication.RedirectFromLoginPage(newUser.UserName.ToString(), true);
                                AuthenticateEventArgs auth = new AuthenticateEventArgs();
                                auth.Authenticated = true;
                                LoginUser_Authenticate(this, auth);

                              
                                //if (Page.User.Identity.IsAuthenticated)
                                //{
                                //    // Roles.AddUserToRole(newUser.UserName, "Manager");
                                
                                //    Response.Redirect("~/Manager/DataEntry1.aspx");
                                //}
                            }
                            else
                            {
                                lblMessage.Text = "User Account not found";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        lblMessage.Text = "User Account not found";
                    }
                    //Membership.v
                    //FormsAuthentication.SignOut();
                    //Roles.DeleteCookie();
                    //Session.Clear();
                    //FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "User Account not found";
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {

              
                   
                    e.Authenticated = true;
                    Response.Redirect("~/Manager/dashboard.aspx");
                

            }
            catch (Exception ex)
            {
            }
        }

        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            
        }
    }
}