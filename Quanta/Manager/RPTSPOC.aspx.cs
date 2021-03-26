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
    public partial class RPTSPOC : System.Web.UI.Page
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
        public static string GetOrgWise()
        {


          





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "[dbo].SP_GetRptSPOCOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
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
        public static string GetDistdeptWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
          
            List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            List<Dictionary<string, object>> parentRowSeries = new List<Dictionary<string, object>>();
            try
            {
                string qryorg = "[dbo].SP_GetRptSPOCOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
                MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                DataTable dtorg = clsESPSql.ExecQuery(qryorg);

                string qry = "SP_GetRptSPOCDeptwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
           
                DataTable dt = clsESPSql.ExecQuery(qry);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtdept = dt.DefaultView.ToTable(true, "dept");
                      
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        dtorg.DefaultView.RowFilter = "fyear='" + yr + "'";
                        decimal orgavg = Convert.ToDecimal(dtorg.DefaultView[0]["cnt"]);
                            ArrayList arrdata = new ArrayList();
                            ArrayList arrdataorg = new ArrayList();
                            foreach (DataRow row1 in dtdept.Rows)
                            {
                                string deptname = row1["dept"].ToString();
                               
                                    arrdept.Add(deptname);
                               

                                dt.DefaultView.RowFilter = "";
                                dt.DefaultView.RowFilter = "dept='" + deptname + "'" ;
                                DataView dv = dt.DefaultView;
                                if (dv.Count > 0)
                                {
                                    arrdata.Add(dv[0]["cnt"]);
                                }

                                arrdataorg.Add(orgavg);
                            }
                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("name", "Deparment Avg. SPOC");
                            childRowdept.Add("type", "column");
                            childRowdept.Add("data", arrdata);
                           


                            parentRowSeries.Add(childRowdept);

                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("name", "Organizational Average");
                            childRowdept.Add("type", "line");
                            childRowdept.Add("data", arrdataorg);
                           

                           
                            parentRowSeries.Add(childRowdept);
                       
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
        public static string GetDistLevelWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            //List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();
            List<Dictionary<string, object>> parentRowSeries = new List<Dictionary<string, object>>();
            try
            {
                string qryorg = "[dbo].SP_GetRptSPOCOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
                MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                DataTable dtorg = clsESPSql.ExecQuery(qryorg);

                string qry = "SP_GetRptSPOCLevelwise " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";

                DataTable dt = clsESPSql.ExecQuery(qry);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtdept = dt.DefaultView.ToTable(true, "grade");

                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        dtorg.DefaultView.RowFilter = "fyear='" + yr + "'";
                        decimal orgavg = Convert.ToDecimal(dtorg.DefaultView[0]["cnt"]);
                        ArrayList arrdata = new ArrayList();
                        ArrayList arrdataorg = new ArrayList();
                        foreach (DataRow row1 in dtdept.Rows)
                        {
                            string deptname = row1["grade"].ToString();

                            arrdept.Add(deptname);


                            dt.DefaultView.RowFilter = "";
                            dt.DefaultView.RowFilter = "grade='" + deptname + "'";
                            DataView dv = dt.DefaultView;
                            if (dv.Count > 0)
                            {
                                arrdata.Add(dv[0]["cnt"]);
                            }

                            arrdataorg.Add(orgavg);
                        }
                        childRowdept = new Dictionary<string, object>();
                        childRowdept.Add("name", "Level Avg. SPOC");
                        childRowdept.Add("type", "column");
                        childRowdept.Add("data", arrdata);
                       


                        parentRowSeries.Add(childRowdept);


                        childRowdept = new Dictionary<string, object>();
                        childRowdept.Add("name", "Organizational Average");
                        childRowdept.Add("type", "line");
                        childRowdept.Add("data", arrdataorg);
                        


                        parentRowSeries.Add(childRowdept);

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
        public static string GetGenderDistrByFyear(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetOrgGenderDiversityByFyear " + HttpContext.Current.Session["orgid"].ToString() + ",'" + yr + "'";
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
                        DataTable dtdept = dt.DefaultView.ToTable(true, "gender", "cnt");

                        Dictionary<string, object> childRowdept;
                        ArrayList arrdept = new ArrayList();
                        ArrayList arryear = new ArrayList();
                        foreach (DataRow row in dtdept.Rows)
                        {
                            childRowdept = new Dictionary<string, object>();
                            childRowdept.Add("value", row["cnt"]);
                            childRowdept.Add("name", row["gender"].ToString());

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
    }
}