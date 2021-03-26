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
    public partial class RPTorgPyramid : System.Web.UI.Page
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
        public static string GetLeveWise()
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = " [dbo].SP_GetRptORGPyramid " + HttpContext.Current.Session["orgid"].ToString();
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
                      
                      
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                       
                      
                        //foreach (DataRow row in dtage_range.Rows)
                        
                            ArrayList arrdata = new ArrayList();
                            ArrayList arrdata1 = new ArrayList();
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string deptname = row1["grade"].ToString();
                               
                                    arrdept.Add(deptname);

                                    int i = - Convert.ToInt32(row1["cnt"]);
                                    arrdata.Add(row1["cnt"]);
                                    arrdata1.Add(i);
                                

                            }

                            Dictionary<string, object> childRow1 = new Dictionary<string, object>();

                            childRow1.Add("name", "Headcount");

                            childRow1.Add("data", arrdata);
                            parentRowSeries.Add(childRow1);

                            Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                            childRow2.Add("name", "Headcount");

                            childRow2.Add("data", arrdata1);
                            //arryear.Add(row["cnt"]);
                            parentRowSeries.Add(childRow2);
                       
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