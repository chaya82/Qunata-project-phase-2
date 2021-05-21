using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;
using System.Text;

namespace Quanta.Manager
{
    public partial class RPT2FunHeadCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string qry = "SP_GetRptHeadCountDeptWiseLatestYear_level2 " + Session["orgid"].ToString() ;
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    grdList.DataSource = dt;
                    grdList.DataBind();
                    //rptlistyr1.DataSource = dt;
                    //rptlistyr1.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        

        
    }
}