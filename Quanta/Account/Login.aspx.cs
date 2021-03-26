using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace Quanta.Account
{
    public partial class Login : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
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
                    ds = clsESPSql.ExecQuery("select * from tblOrgBasicInfo where username= '" + tstUserName.Text + "'");
                    if (ds.Rows.Count > 0)
                    {

                        
                       Session["orgid"] = ds.Rows[0]["id"].ToString();
                    }
                    Response.Redirect("~/Manager/Default.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            try{
           
            DataTable ds = new DataTable();
            ds = clsESPSql.ExecQuery("select * from aspnet_Users where username= '" + tstUserName.Text + "' or mobilealias='" + tstUserName.Text + "'");
            if (ds.Rows.Count > 0)
            {
                
                pnlFind.Visible = false;
                pnlLogin.Visible=true;
                TextBox txtUsername = (TextBox)LoginUser.FindControl("UserName");
                txtUsername.Text = ds.Rows[0]["username"].ToString();
            }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
