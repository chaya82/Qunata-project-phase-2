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
    public partial class RPTGenderDist : System.Web.UI.Page
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
        public static string GetgenderDistOrgWise()
        {


          


            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetOrgGenderDiversity " + HttpContext.Current.Session["orgid"].ToString() + "";
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
                        DataTable dtdept = dt.DefaultView.ToTable(true, "fyear");
                        dt.DefaultView.Sort = "gender asc";
                        DataTable dtgender = dt.DefaultView.ToTable(true, "gender");
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        //foreach (DataRow row in dtgender.Rows)
                        for (int i = 0; i < dtgender.Rows.Count; i++)
                        {
                            ArrayList arrdata = new ArrayList();
                            foreach (DataRow row1 in dtdept.Rows)
                            {
                                string deptname = row1["fyear"].ToString();
                                if (i == 0)
                                {
                                    arrdept.Add(deptname);
                                }

                                dt.DefaultView.RowFilter = "";
                                dt.DefaultView.RowFilter = "fyear='" + deptname + "' and gender='" + dtgender.Rows[i]["gender"].ToString() + "'";
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
                            childRowdept.Add("name", dtgender.Rows[i]["gender"].ToString());
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
        public static string GetGenderDistdeptWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetOrgGenderDiversityDept " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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
                        dt.DefaultView.Sort = "gender asc";
                        DataTable dtgender = dt.DefaultView.ToTable(true, "gender");
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
                        for (int i = 0; i < dtgender.Rows.Count; i++)
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
                                dt.DefaultView.RowFilter = "dept='" + deptname + "' and gender='" + dtgender.Rows[i]["gender"].ToString() + "'";
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
                            childRowdept.Add("name", dtgender.Rows[i]["gender"].ToString());
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
        public static string GetgenderDistLevelWise(string yr)
        {





            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string qry = "SP_GetOrgGenderDiversityLevel " + HttpContext.Current.Session["orgid"].ToString() + ", '" + yr + "'";
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
                        dt.DefaultView.Sort = "gender asc";
                        DataTable dtgender = dt.DefaultView.ToTable(true, "gender");
                        Dictionary<string, object> childRowdept;

                        ArrayList arrdept = new ArrayList();

                        Dictionary<string, object> childRow1 = new Dictionary<string, object>();
                        childRow1.Add("show", true);
                        childRow1.Add("position", "insideRight");
                        Dictionary<string, object> childRow2 = new Dictionary<string, object>();
                        childRow2.Add("label", childRow1);
                        Dictionary<string, object> childRow3 = new Dictionary<string, object>();
                        childRow3.Add("normal", childRow2);
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
                                dt.DefaultView.RowFilter = "grade='" + deptname + "' and gender='" + dtgender.Rows[i]["gender"].ToString() + "'";
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
                            childRowdept.Add("name", dtgender.Rows[i]["gender"].ToString());
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