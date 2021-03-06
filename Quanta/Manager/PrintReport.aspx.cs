using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections;
using System.Text;

namespace Quanta.Manager
{
    public partial class PrintReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //
               
                if (!Page.IsPostBack)
                {
                    string qry = "select top(1) fYear from tblmstemployee where orgid=" + Session["orgid"].ToString() + "  order by fYear desc ";
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    if (dt.Rows.Count > 0)
                    {
                        lblchart2.Text=dt.Rows[0]["fYear"].ToString();
                        lblchart3.Text = dt.Rows[0]["fYear"].ToString();
                        lblchart4.Text = dt.Rows[0]["fYear"].ToString();
                       // lblchart5.Text = dt.Rows[0]["fYear"].ToString();
                        lblchart6.Text = dt.Rows[0]["fYear"].ToString();
                        lblchart7.Text = dt.Rows[0]["fYear"].ToString();
                        lblchart8.Text = dt.Rows[0]["fYear"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
       
       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetYearwise()
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "[dbo].SP_GetRptattrtionOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);


            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();

            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        Dictionary<string, object> childRow;
                        ArrayList arrlabel = new ArrayList();
                        ArrayList arrvalue = new ArrayList();
                        foreach (DataRow row in dt.Rows)
                        {


                            arrlabel.Add(row["fYear"].ToString());
                            arrvalue.Add(row["cnt"]);

                        }
                        childRow = new Dictionary<string, object>();
                        childRow.Add("label", arrlabel);
                        childRow.Add("value", arrvalue);




                        parentRow.Add(childRow);

                    }

                }


            }
            catch (Exception ec)
            {
            }

            return jsSerializer.Serialize(parentRow);


        }

    }
}