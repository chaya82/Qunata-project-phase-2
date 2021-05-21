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
    public partial class RPT2SPOC : System.Web.UI.Page
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
        public static string GetSPOCData()
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetRptSPOCLatesty_level2 " + HttpContext.Current.Session["orgid"].ToString();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);
            List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            List<Dictionary<string, object>> parentRowSeries = new List<Dictionary<string, object>>();
            try
            {

                ArrayList arrdept = new ArrayList();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                       

                         Dictionary<string, object> childRowdept;
                       arrdept.Add("test");
                         for (int i = 0; i < dt.Rows.Count; i++)
                        {
                        
                            childRowdept = new Dictionary<string, object>();
                          ArrayList arrdata = new ArrayList();
                          arrdata.Add(dt.Rows[i]["value"]);
                          childRowdept.Add("name", dt.Rows[i]["name"].ToString());
                               childRowdept.Add("data", arrdata);
                              parentRowSeries.Add(childRowdept);
                         }

                            //arryear.Add(row["cnt"]);
                           
                    }
                        List<Dictionary<string, object>> parentRowdata = new List<Dictionary<string, object>>();
                        Dictionary<string, object> childRowdata = new Dictionary<string, object>();
                        childRowdata.Add("cat", arrdept);
                        parentRowdata.Add(childRowdata);
                        parentRow.Add(parentRowSeries);
                        parentRow.Add(parentRowdata);





                    }
               



            }
            catch (Exception ec)
            {
            }

            return jsSerializer.Serialize(parentRow);


        }
       

    }
}