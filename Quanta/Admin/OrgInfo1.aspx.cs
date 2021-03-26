using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Quanta.Admin
{
    public partial class OrgInfo1 : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable ds = new DataTable();
                    ds = clsESPSql.ExecQuery("select * from tblmstNatureofBussiness");
                    chknetureList.DataSource = ds;
                    chknetureList.DataTextField = "name";
                    chknetureList.DataValueField = "id";
                    chknetureList.DataBind();

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}