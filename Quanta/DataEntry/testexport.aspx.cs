using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace Quanta.DataEntry
{
    public partial class testexport : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DataSet dsRemarks = (DataSet)Session["remarks"];
                    DataTable dtinstruct = (DataTable)Session["dtinst"];
                    string strdob = "";



                
                    dsRemarks.Tables[0].DefaultView.RowFilter = "";
                 
                    dsRemarks.Tables[0].DefaultView.RowFilter = " fyear='" + Request.QueryString["yr"].ToString() + "'";
                    DataTable dt = new DataTable();
                    if (dtinstruct != null)
                    {
                        strdob = dtinstruct.Rows[0]["dob"].ToString();
                        if (strdob.ToLower() == "age")
                        {
                            dt = dsRemarks.Tables[0].DefaultView.ToTable(true, "EmpID", "Age", "DOJ", "Gender", "Dept", "Grdae", "ManagerID", "PerfRating", "TFP", "Remarks");
                        }
                        else
                        {
                            dt = dsRemarks.Tables[0].DefaultView.ToTable(true, "EmpID", "DOB", "DOJ", "Gender", "Dept", "Grdae", "ManagerID", "PerfRating", "TFP", "Remarks");
                        }
                        dt.Columns[1].ColumnName = "DOB/Age";
                    }
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.AcceptChanges();

                    rptincorrect.DataSource = ds;
                    rptincorrect.DataBind();
                    ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:xport();</script>");
                }
                catch (Exception ex)
                {
                }
            }

        }
       
        
        
    }
}
