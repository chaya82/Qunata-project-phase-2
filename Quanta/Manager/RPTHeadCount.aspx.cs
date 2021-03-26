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
    public partial class RPTHeadCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string qry = "select distinct fYear from tblmstemployee where orgid=" + Session["orgid"].ToString() + "  order by fYear ";
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    rptlistyr.DataSource = dt;
                    rptlistyr.DataBind();
                    //rptlistyr1.DataSource = dt;
                    //rptlistyr1.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetHC_deptWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "[dbo].SP_GetRptHeadCountDeptWise " + HttpContext.Current.Session["orgid"].ToString() + ",'" + yr + "'";
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);
            List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            List<Dictionary<string, object>> parentRowdept = new List<Dictionary<string, object>>();
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtdept = dt.DefaultView.ToTable(true, "dept","cnt");
                      
                        Dictionary<string, object> childRowdept;
                        ArrayList arrdept = new ArrayList();
                        ArrayList arryear = new ArrayList();
                        foreach (DataRow row in dtdept.Rows)
                        {
                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("value", row["cnt"]);
                           childRowdept.Add("name", row["dept"].ToString());
                           
                            //string deptname = row["dept"].ToString();
                            //arrdept.Add(row["dept"].ToString());
                            //arryear.Add(row["cnt"]);
                           parentRowdept.Add(childRowdept);
                        }
                       
                      

                       
                      
                       
                    }
                }



            }
            catch (Exception ec)
            {
            }

            return jsSerializer.Serialize(parentRowdept);


        }
       
        public class GraphData
        {
            public string country { get; set; }
            public int visits { get; set; }
           
        }
         [WebMethod]
         [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetHC_Yearwise()
        {



           

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "select fYear,count(*) as cnt from tblmstemployee where orgid=" + HttpContext.Current.Session["orgid"].ToString() + " group by fYear order by fYear ";
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