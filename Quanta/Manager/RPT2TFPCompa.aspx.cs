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
    public partial class RPT2TFPCompa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Getdata()
        {


          


            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetTFPCompaRatio " + HttpContext.Current.Session["orgid"].ToString() + "";
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);
            List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            List<Dictionary<string, object>> parentRowSeries = new List<Dictionary<string, object>>();
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtdept = dt.DefaultView.ToTable(true, "grade");

                        DataTable dtgender = dt.DefaultView.ToTable(true, "rangeratio");
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                                             
                        //foreach (DataRow row in dtgender.Rows)
                        for (int i = 0; i < dtgender.Rows.Count; i++)
                        {
                            ArrayList arrdata = new ArrayList();
                            foreach (DataRow row1 in dtdept.Rows)
                            {
                                string deptname = row1["grade"].ToString();
                                if (i == 0)
                                {
                                    arrdept.Add(deptname);
                                }

                                dt.DefaultView.RowFilter = "";
                                dt.DefaultView.RowFilter = "grade='" + deptname + "' and rangeratio='" + dtgender.Rows[i]["rangeratio"].ToString() + "'";
                                DataView dv = dt.DefaultView;
                                if (dv.Count > 0)
                                {
                                    arrdata.Add(dv[0]["cnt"]);
                                }
                                else
                                {
                                    arrdata.Add(0);
                                }

                            }
                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("name", dtgender.Rows[i]["rangeratio"].ToString());
                         
                            childRowdept.Add("data", arrdata);


                            //arryear.Add(row["cnt"]);
                            parentRowSeries.Add(childRowdept);
                        }
                        List<Dictionary<string, object>> parentRowdata = new List<Dictionary<string, object>>();
                        Dictionary<string, object> childRowdata = new Dictionary<string, object>();
                        childRowdata.Add("cat", arrdept);
                        parentRowdata.Add(childRowdata);
                        parentRow.Add(parentRowSeries);
                        parentRow.Add(parentRowdata);





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