using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace Quanta.Manager
{
    public partial class Inner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["orgid"] == null)
                {
                    Response.Redirect("~/Account/Register.aspx", false);

                }
                else
                {
                    string qry = "select top 1 1 from tblmstemployee where orgid=" + Session["orgid"].ToString();
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    if (dt.Rows != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            RPT.Visible = true;
                        }
                    }
                    //lbluser.Text = User.Identity.Name;
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}