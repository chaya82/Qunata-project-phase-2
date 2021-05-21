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

namespace Quanta.Admin
{
    public partial class user : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // bool flg1 = Membership.DeleteUser("chaya.pandey@gmail.com", true);


                if (!Page.IsPostBack)
                {
                    DataTable dtInd = clsESPSql.ExecQuery("select * from tblmstIndustry ");
                  
                    Industry.DataSource = dtInd;
                    Industry.DataTextField = "id";
                    Industry.DataTextField = "name";
                    Industry.DataBind();
                    Industry.Items.Insert(0, new ListItem("Select Industry", ""));

                    DataTable dt = clsESPSql.ExecQuery("SP_GetManager");
                   
                    rptuserlist.DataSource = dt;
                    
                    rptuserlist.DataBind();
                    ViewState["dt"] = dt;
                    CreateUserButton.Visible = true;
                    UpdateUser.Visible = false; 
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
              string  Password= GeneratePWD();
                        MembershipUser newUser = Membership.CreateUser(Email.Text, Password, Email.Text, null, null, true, out status);

                        //if (!Roles.IsUserInRole("Manager"))
                        //{
                        string role = "Manager";
                        if (!Roles.RoleExists(role))
                        {
                            Roles.CreateRole(role);
                            Roles.AddUserToRole(Email.Text, role);
                        }
                        else
                        {
                              //Roles.RemoveUserFromRole(Email.Text, role);
                           
                                Roles.AddUserToRole(Email.Text, role);
                            
                        }
                          clsESPSql.ExecNonQuery("update aspnet_Users set pwd='" + Password + "', mobilealias='" + Mobile.Text + "' where username='" + Email.Text + "'");
                    

                  
                    try
                    {
                        LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
                        DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
                        MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                        objLIBtblOrgBasicInfo.id = -1;
                        objLIBtblOrgBasicInfo.username = Email.Text;
                        objLIBtblOrgBasicInfo.Name = Name.Text;
                        objLIBtblOrgBasicInfo.Email =Email.Text;
                        objLIBtblOrgBasicInfo.phone = Mobile.Text;
                        objLIBtblOrgBasicInfo.designation = Designation.Text;
                        objLIBtblOrgBasicInfo.OrgName = Orgnaisation.Text;
                        objLIBtblOrgBasicInfo.industry = Industry.SelectedItem.Text;
                        objLIBtblOrgBasicInfo.Orglevel = ddlLevel.SelectedValue;
                        objLIBtblOrgBasicInfo.dt = DateTime.Now.ToShortDateString();
                        tp.MessagePacket = objLIBtblOrgBasicInfo;
                        tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);
                  
                        DataTable dt = clsESPSql.ExecQuery("SP_GetManager ");

                        rptuserlist.DataSource = dt;

                        rptuserlist.DataBind();
                        ViewState["dt"] = dt;
                    }
                    catch (Exception ex)
                    {
                        MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                    }
                   DALCommon cmn = new DALCommon();
                   string strBody = cmn.prcFindInFile(Server.MapPath("mail.html").ToString(), "#UserName#", Email.Text);
                   strBody = cmn.prcFindInString(strBody, "#Password#", Password);

                   cmn.SendHtmlFormattedEmail(Email.Text, "User Created", strBody);
                  // Response.Redirect("user.aspx", false);
                   UserName.Text = "";
                   Email.Text = "";
                   Mobile.Text = "";
                   Designation.Text = "";
                   Orgnaisation.Text = "";
                   Industry.SelectedIndex = 0;
                   ddlLevel.SelectedIndex = 0;
                   lblErrorMessage.Text = "User Created  successfully";
                   lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                  
                }
               
                
            catch (MembershipCreateUserException ex)
            {
                lblErrorMessage.Text = GetErrorMessage(ex.StatusCode);
            }

        }
        public string GeneratePWD()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;

            characters += alphabets + small_alphabets + numbers;

            int length = 6;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {



            try
            {
                // Create new user.
                
                clsESPSql.ExecNonQuery("update aspnet_Users set  mobilealias='" + Mobile.Text + "' where username='" + Email.Text + "'");



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
                    objLIBtblOrgBasicInfo.industry = Industry.SelectedItem.Text;
                    objLIBtblOrgBasicInfo.dt = DateTime.Now.ToShortDateString();
                    objLIBtblOrgBasicInfo.Orglevel = ddlLevel.SelectedValue;
                    tp.MessagePacket = objLIBtblOrgBasicInfo;
                    tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);

                   

                }
                catch (Exception ex)
                {
                    MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                }
               
                // Response.Redirect("user.aspx", false);
                UserName.Text = "";
                Email.Text = "";
                Mobile.Text = "";
                Designation.Text = "";
                Orgnaisation.Text = "";
                Industry.SelectedIndex = 0;
               
                lblErrorMessage.Text = "user details updated successfully";
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
             
                CreateUserButton.Visible = true;
                UpdateUser.Visible = false;
                DataTable dt = clsESPSql.ExecQuery("SP_GetManager ");

                rptuserlist.DataSource = dt;

                rptuserlist.DataBind();
                ViewState["dt"] = dt;
            }


            catch (MembershipCreateUserException ex)
            {
                //lblErrorMessage.Text = GetErrorMessage(ex.StatusCode);
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
        protected void btnSaveClick(object sender, EventArgs e)
        {
            // Get the value  
            LinkButton gvTemp = (LinkButton)sender;
            LinkButton btnSave = (LinkButton)gvTemp.FindControl("lnkedit");
            HiddenField hdnorgid = (HiddenField)gvTemp.FindControl("hdnorgid");


            try
            {
                bindControls(btnSave.CommandArgument.ToString());

            }
             
            catch (Exception es)
            {
            }
        }

        protected void bindControls(string id)
        {
            try
            {

                DataTable dt = (DataTable)ViewState["dt"];

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.RowFilter = " email='" + id.ToString()+"'";
                    CreateUserButton.Visible=false;
                   UpdateUser.Visible = true;
                    Name.Text = dt.DefaultView[0]["name"].ToString();
                    Email.Text = dt.DefaultView[0]["email"].ToString();
                    Mobile.Text = dt.DefaultView[0]["phone"].ToString();
                    Designation.Text = dt.DefaultView[0]["designation"].ToString();
                    Orgnaisation.Text = dt.DefaultView[0]["OrgName"].ToString();
                    Industry.SelectedIndex = Industry.Items.IndexOf(Industry.Items.FindByValue(dt.DefaultView[0]["industry"].ToString()));
                    ddlLevel.SelectedIndex = ddlLevel.Items.IndexOf(ddlLevel.Items.FindByValue(dt.DefaultView[0]["orglevel"].ToString()));
                    //txtPerlevel.Text = dt.DefaultView[0]["PerLevel"].ToString();

                    //UserType.Enabled = false;
                //    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('modalPerformance');</script>");


                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void editUser(object sender, EventArgs e)
        {
            // Get the value  

            LinkButton gvTemp = (LinkButton)sender;
            LinkButton lnkedit = (LinkButton)gvTemp.FindControl("lnkedit");
            try{
                bindControls(lnkedit.CommandArgument.ToString());

            }
            catch (Exception ex)
            {
            }
        }
        protected void deleteUser(object sender, EventArgs e)
        {
            // Get the value  

            LinkButton gvTemp = (LinkButton)sender;
            LinkButton lnkremove = (LinkButton)gvTemp.FindControl("lnkremove");
            try
            {
              bool isValid=  Membership.DeleteUser(lnkremove.CommandArgument,true);
              if (isValid)
              {
                  if (Roles.IsUserInRole(lnkremove.CommandArgument))
                  {

                      Roles.RemoveUserFromRole(lnkremove.CommandArgument, "DataEntry");
                  }

                  lblErrorMessage.Text = "User Deleted successfully";
                  int res = clsESPSql.DeleteSYData(" where email=" + lnkremove.CommandArgument.ToString(), "tblmstOrgUsers");
                  string strpg = Request.Url.ToString();
                  DataTable dt = clsESPSql.ExecQuery("SP_GetUserByRole 'DataEntry' , " + Session["orgid"].ToString());

                  rptuserlist.DataSource = dt;

                  rptuserlist.DataBind();
                  ViewState["dt"] = dt;
              }
              else
              {
                  lblErrorMessage.Text = "Failed to delete ";
                  lblErrorMessage.ForeColor = System.Drawing.Color.Green;
              }

            }
            catch (Exception ex)
            {
            }
        }
    }
}