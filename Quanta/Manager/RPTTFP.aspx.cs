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
    public partial class RPTTFP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string qry = "select distinct fYear,cur=(select top 1 currency from tblmstOrgInfo where orgid=tblmstemployee.orgid )  from tblmstemployee where orgid=" + Session["orgid"].ToString() + "  order by fYear ";
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    rptlistyr.DataSource = dt;
                    rptlistyr.DataBind();
                    rptlistyr1.DataSource = dt;
                    rptlistyr1.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        lblcur.Text = dt.Rows[0]["cur"].ToString();
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
            string qry = "[dbo].SP_GetRptTFPOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
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

        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetAgeDistdeptWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetRptTFPDeptwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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
                       
                       
                      
                            
                            foreach (DataRow row1 in dt.Rows)
                            {
                                string deptname = row1["dept"].ToString();
                                childRowdept = new Dictionary<string, object>();
                                childRowdept.Add("name", deptname);
                                ArrayList arrdata = new ArrayList();
                                arrdata.Add(row1["cnt"]);
                                childRowdept.Add("data", arrdata);


                                //arryear.Add(row["cnt"]);
                                parentRowSeries.Add(childRowdept);

                            }
                           
                       
                        List<Dictionary<string, object>> parentRowdata = new List<Dictionary<string, object>>();
                         Dictionary<string, object> childRowdata = new Dictionary<string, object>();
                         arrdept.Add(yr);
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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetAgeDistLevelWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetRptTFPLevelwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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




                        foreach (DataRow row1 in dt.Rows)
                        {
                            string deptname = row1["grade"].ToString();
                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("name", deptname);
                            ArrayList arrdata = new ArrayList();
                            arrdata.Add(row1["cnt"]);
                            childRowdept.Add("data", arrdata);


                            //arryear.Add(row["cnt"]);
                            parentRowSeries.Add(childRowdept);

                        }


                        List<Dictionary<string, object>> parentRowdata = new List<Dictionary<string, object>>();
                        Dictionary<string, object> childRowdata = new Dictionary<string, object>();
                        arrdept.Add(yr);
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