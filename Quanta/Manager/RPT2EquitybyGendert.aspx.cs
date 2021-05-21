using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Quanta.Manager
{
    public partial class RPT2EquitybyGendert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string qry = "Sp_GetTFPInternalEquitybyGender " + Session["orgid"].ToString();
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

        protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdncal = (HiddenField)e.Row.FindControl("hdncal");

                if (hdncal.Value=="1")
                {
                    e.Row.Cells[0].BackColor = Color.Red;
                }
                
            }
        } 
        
    }
}