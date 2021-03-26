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
    public partial class RPTAgeSpread : System.Web.UI.Page
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
                    rptlistyr1.DataSource = dt;
                    rptlistyr1.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetdeptWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = " [dbo].SP_GetOrgoverallAgeDept " + HttpContext.Current.Session["orgid"].ToString() + ",'" + yr + "'";
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);
          
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
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


                            arrlabel.Add(row["dept"].ToString());
                            arrvalue.Add(row["cnt"]);

                        }
                        childRow = new Dictionary<string, object>();
                        childRow.Add("label", arrlabel);
                        childRow.Add("value", arrvalue);




                        parentRow.Add(childRow);
                        //DataTable dtdept = dt.DefaultView.ToTable(true, "dept", "cnt");

                        //Dictionary<string, object> childRowdept;
                        //ArrayList arrdept = new ArrayList();
                        //ArrayList arryear = new ArrayList();
                        //foreach (DataRow row in dtdept.Rows)
                        //{
                        //    childRowdept = new Dictionary<string, object>();
                        //    childRowdept.Add("value", row["cnt"]);
                        //    childRowdept.Add("name", row["dept"].ToString());

                        //    //string deptname = row["dept"].ToString();
                        //    //arrdept.Add(row["dept"].ToString());
                        //    //arryear.Add(row["cnt"]);
                        //    parentRowdept.Add(childRowdept);
                        //}




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
        public static string GetgradeWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = " [dbo].SP_GetOrgoverallAgeLevel " + HttpContext.Current.Session["orgid"].ToString() + ",'" + yr + "'";
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


                            arrlabel.Add(row["grade"].ToString());
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
        public static string GetYearwise()
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "[dbo].SP_GetOrgoverallAge " + HttpContext.Current.Session["orgid"].ToString() + "";
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
            string qry = "SP_GetAgegroupDeptwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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
                        DataTable dtdept = dt.DefaultView.ToTable(true, "dept");
                        dt.DefaultView.Sort = "age_range asc";
                        DataTable dtage_range = dt.DefaultView.ToTable(true, "age_range");
                        Dictionary<string, object> childRowdept;
                       
                        ArrayList arrdept = new ArrayList();
                       
                        Dictionary<string, object> childRow1=new Dictionary<string,object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        for (int i = 0; i < dtage_range.Rows.Count; i++)
                        {
                            ArrayList arrdata = new ArrayList();
                            foreach (DataRow row1 in dtdept.Rows)
                            {
                                string deptname = row1["dept"].ToString();
                                if (i == 0)
                                {
                                    arrdept.Add(deptname);
                                }

                                dt.DefaultView.RowFilter = "";
                                dt.DefaultView.RowFilter = "dept='" + deptname + "' and age_range='" + dtage_range.Rows[i]["age_range"].ToString() + "'";
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
                            childRowdept.Add("name", dtage_range.Rows[i]["age_range"].ToString());
                            childRowdept.Add("type", "bar");
                            childRowdept.Add("stack", "Stack");
                            childRowdept.Add("itemStyle", childRow3);
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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetAgeDistLevelWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetAgegroupLevelwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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
                        dt.DefaultView.Sort = "age_range asc";
                        DataTable dtage_range = dt.DefaultView.ToTable(true, "age_range");
                        
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();
                     
                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        //foreach (DataRow row in dtage_range.Rows)
                        for(int i=0;i<dtage_range.Rows.Count;i++)
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
                                dt.DefaultView.RowFilter = "grade='" + deptname + "' and age_range='" + dtage_range.Rows[i]["age_range"].ToString() + "'";
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
                            childRowdept.Add("name", dtage_range.Rows[i]["age_range"].ToString());
                            childRowdept.Add("type", "bar");
                            childRowdept.Add("stack", "Stack");
                            childRowdept.Add("itemStyle", childRow3);
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