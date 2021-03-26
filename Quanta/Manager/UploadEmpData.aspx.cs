using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using NDS.LIB;
using NDS.DAL;
using System.Web.Security;

namespace Quanta.Manager
{
    public partial class UploadEmpData : System.Web.UI.Page
    {
        protected static string strcorrect;
        protected static string strwrong;
        protected static string strcorrectNo;
        protected static string strwrongNo;
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable dt = new DataTable();
                    dt = clsESPSql.ExecQuery("SP_Gettop3Year " + Session["orgid"].ToString());
                    rptFile.DataSource = dt;
                    rptFile.DataBind();

                 
                    getRatingndGrade();
                    lblCurrency.Text = Session["cur"].ToString();

                    DataTable dtinstruct = (DataTable)Session["dtinst"];
                    string strdob = "";
                   
                    if (dtinstruct != null)
                    {
                        strdob = dtinstruct.Rows[0]["dob"].ToString();
                        if (strdob.ToLower() == "age")
                        {
                            hrfExcel.HRef = "ExcelFile\\Format\\Age\\2019.xls";
                            rdoAge.Checked = true;
                        }
                        else
                        {
                            hrfExcel.HRef = "ExcelFile\\Format\\DOB\\2019.xls";
                            rdoDOB.Checked = true;
                        }
                       
                    }
                    //if(Session["remarks"]==null)
                    //{
                    DataSet dsCorrect = new DataSet();
                    DataSet dsRemarks = new DataSet();

                    dsCorrect = createdatatabel();
                    dsRemarks = createdatatabel2();
                    Session["remarks"] = dsRemarks;
                    Session["correct"] = dsCorrect;
                    //}
                    //string script = "$(document).ready(function () { $('[id*=btnImport]').click(); });";
                    //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                }
            }
            catch (Exception ex)
            {
            }
        }
      
        protected void getRatingndGrade()
        {
            try
            {
                DataTable dt1 = clsESPSql.ExecQuery("select * from tblmstPerformance where orgid=" + Session["orgid"].ToString() + " order by PerLevel");
                ViewState["dtRating"] = dt1;
                DataTable dt = clsESPSql.ExecQuery("select * from tblmstgrade where orgid=" + Session["orgid"].ToString() + " order by GLevel");
                ViewState["dtGrade"] = dt;

                rptListPer.DataSource = dt1;
                rptListPer.DataBind();

                rptGrade.DataSource = dt;
                rptGrade.DataBind();
            }
            catch (Exception ex1)
            {
            }
        }
        protected DataSet createdatatabel2()
        {
            DataSet ds1 = new DataSet();

            try
            {
                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("EmpID", typeof(string));

                dtNew.Columns.Add("DOB", typeof(string));
                dtNew.Columns.Add("Age", typeof(string));
                dtNew.Columns.Add("DOJ", typeof(string));
                dtNew.Columns.Add("Gender", typeof(string));
                dtNew.Columns.Add("Dept", typeof(string));
                //done

                dtNew.Columns.Add("Grdae", typeof(string));
                dtNew.Columns.Add("ManagerID", typeof(string));

                dtNew.Columns.Add("PerfRating", typeof(string));
                dtNew.Columns.Add("lastPrmo", typeof(string));
                dtNew.Columns.Add("TFP", typeof(string));

                dtNew.Columns.Add("Currency", typeof(string));
                dtNew.Columns.Add("Remarks", typeof(string));
                dtNew.Columns.Add("fyear", typeof(string));
                dtNew.Columns.Add("isDOB", typeof(string));
                dtNew.Columns.Add("isDOJ", typeof(string));
                dtNew.Columns.Add("IsGrdae", typeof(string));
                dtNew.Columns.Add("isPerfRating", typeof(string));
                dtNew.Columns.Add("iSalary", typeof(string));
                ds1.Tables.Add(dtNew);
                ds1.AcceptChanges();
            }
            catch (Exception ex1)
            { }
            return ds1;
            //ds1.AcceptChanges();
            //Session["dstbl"] = ds1;
        }
        protected DataSet createdatatabel()
        {
            DataSet ds1 = new DataSet();

            try
            {
                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("EmpID", typeof(string));
                dtNew.Columns.Add("DOB", typeof(string));
                dtNew.Columns.Add("Age", typeof(string));
                dtNew.Columns.Add("DOJ", typeof(string));
                dtNew.Columns.Add("Gender", typeof(string));
                dtNew.Columns.Add("Dept", typeof(string));
                //done

                dtNew.Columns.Add("Grdae", typeof(string));
                dtNew.Columns.Add("ManagerID", typeof(string));

                dtNew.Columns.Add("PerfRating", typeof(string));
                dtNew.Columns.Add("lastPrmo", typeof(string));
                dtNew.Columns.Add("TFP", typeof(string));

                dtNew.Columns.Add("Currency", typeof(string));

                dtNew.Columns.Add("fyear", typeof(string));
                ds1.Tables.Add(dtNew);
                ds1.AcceptChanges();
            }
            catch (Exception ex1)
            { }
            return ds1;
            //ds1.AcceptChanges();
            //Session["dstbl"] = ds1;
        }
       
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
               // System.Threading.Thread.Sleep(5000);
                DataSet dstbl = new DataSet();
                dstbl = EmpData(rptFile);

                ReadData(dstbl);
                if (Session["remarks"] != null)
                {
                    DataSet dsRemarks = (DataSet)Session["remarks"];
                    DataSet dsCorrect = (DataSet)Session["correct"];
                    #region Creating progress bar and saving data in database
                    DataTable dtprogress = new DataTable();

                 
                            dtprogress.Columns.Add("total", typeof(string));

                            dtprogress.Columns.Add("strcorrect", typeof(string));
                            dtprogress.Columns.Add("strcorrectNo", typeof(string));
                            dtprogress.Columns.Add("strwrong", typeof(string));
                            dtprogress.Columns.Add("strwrongNo", typeof(string));

                            dtprogress.Columns.Add("year", typeof(string));
                       
                 
                   

                    for (int t = 0; t < dstbl.Tables.Count; t++)
                    {
                        dsRemarks.Tables[0].DefaultView.RowFilter = "";
                        dsCorrect.Tables[0].DefaultView.RowFilter = "";
                        int total = dstbl.Tables[t].Rows.Count;
                        dsRemarks.Tables[0].DefaultView.RowFilter = " fyear='" + dstbl.Tables[t].Rows[0]["yr"].ToString() + "'";
                        int totRemarks = dsRemarks.Tables[0].DefaultView.Count;
                        dsCorrect.Tables[0].DefaultView.RowFilter = " fyear='" + dstbl.Tables[t].Rows[0]["yr"].ToString() + "'";
                        int totCorrect = dsCorrect.Tables[0].DefaultView.Count;

                        strcorrect = ((totCorrect * 100) / total).ToString();
                        strwrong = ((totRemarks * 100) / total).ToString();
                        strcorrectNo = totCorrect.ToString();
                        strwrongNo = totRemarks.ToString();
                        dtprogress.Rows.Add(total, strcorrect, strcorrectNo, strwrong, strwrongNo, dstbl.Tables[t].Rows[0]["yr"].ToString());

                        if ((totCorrect * 100) / total >= 80)
                        {
                            DataTable dtupload = dsCorrect.Tables[0].DefaultView.ToTable();
                            for (int i = 0; i < dtupload.Rows.Count; i++)
                            {
                                string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                                fyear = dtupload.Rows[i]["fyear"].ToString();
                                empid = dtupload.Rows[i]["empid"].ToString();
                                dob = dtupload.Rows[i]["dob"].ToString();
                                age = dtupload.Rows[i]["age"].ToString();
                                doj = dtupload.Rows[i]["doj"].ToString();
                                gender = dtupload.Rows[i]["gender"].ToString();
                                dept = dtupload.Rows[i]["dept"].ToString();
                                grade = dtupload.Rows[i]["Grdae"].ToString();
                                managerid = dtupload.Rows[i]["ManagerID"].ToString();
                                performance = dtupload.Rows[i]["PerfRating"].ToString();
                                lastpromo = dtupload.Rows[i]["lastPrmo"].ToString();
                                salary = dtupload.Rows[i]["TFP"].ToString();
                                curency = dtupload.Rows[i]["Currency"].ToString();
                                AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency,true);
                            }
                            DataTable dtRemarks = dsRemarks.Tables[0].DefaultView.ToTable();
                            for (int i = 0; i < dtRemarks.Rows.Count; i++)
                            {
                                string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                                fyear = dtRemarks.Rows[i]["fyear"].ToString();
                                empid = dtRemarks.Rows[i]["empid"].ToString();
                                dob = dtRemarks.Rows[i]["dob"].ToString();
                                age = dtRemarks.Rows[i]["age"].ToString();
                                doj = dtRemarks.Rows[i]["doj"].ToString();
                                gender = dtRemarks.Rows[i]["gender"].ToString();
                                dept = dtRemarks.Rows[i]["dept"].ToString();
                                grade = dtRemarks.Rows[i]["Grdae"].ToString();
                                managerid = dtRemarks.Rows[i]["ManagerID"].ToString();
                                performance = dtRemarks.Rows[i]["PerfRating"].ToString();
                                lastpromo = dtRemarks.Rows[i]["lastPrmo"].ToString();
                                salary = dtRemarks.Rows[i]["TFP"].ToString();
                                curency = dtRemarks.Rows[i]["Currency"].ToString();
                                AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency, false);
                            }
                           

                        }
                        else
                        {
                           
                            lblmsg.Text = "incomplete / incorrect data is more than 20% kindly verify/correct data and upload again.";
                        }
                    }

                   
                    #endregion

                 
                    #region binding list


                    if (Session["dtprogess"] != null)
                    {
                        DataTable dtProgressold = (DataTable)Session["dtprogess"];
                        for (int i = 0; i < dtProgressold.Rows.Count; i++)
                        {
                            DataRow dr = dtProgressold.Rows[i];
                            if (dr["year"].ToString().Trim() != dstbl.Tables[0].Rows[0]["yr"].ToString().Trim())
                            {


                                dtprogress.Rows.Add(dr["total"].ToString(), dr["strcorrect"].ToString(), dr["strcorrectNo"].ToString(), dr["strwrong"].ToString(), dr["strwrongNo"].ToString(), dr["year"].ToString());
                            }
                        }
                        dtprogress.AcceptChanges();
                        rptProgress.DataSource = dtprogress;
                        rptProgress.DataBind();
                        Session["dtprogess"] = dtprogress;
                    }
                    else
                    {
                        rptProgress.DataSource = dtprogress;
                        rptProgress.DataBind();
                        Session["dtprogess"] = dtprogress;
                    }

                    if (rptProgress.Items.Count > 0)
                    {
                        btncontinue.Visible = true;
                    }
                    #endregion
                }
             
            }
            catch (Exception ex)
            {
            }

        }
        protected DataSet EmpData(Repeater rptFile)
        {
            lblmsg.Text = "";
            DataSet dstbl = new DataSet();
            try
            {
                for (int i = 0; i < rptFile.Items.Count; i++)
                {
                    Label lblyear = (Label)rptFile.Items[i].FindControl("lblyear");
                    FileUpload fu = (FileUpload)rptFile.Items[i].FindControl("FileUpload1");
                    if (fu.HasFile)
                    {
                        string FileName = fu.PostedFile.FileName;
                        string Extension = Path.GetExtension(fu.PostedFile.FileName);
                        string FilePath = "";
                        string stryr = new string(lblyear.Text.Take(4).ToArray());
                        if (FileName != stryr + Extension)
                        {
                            lblmsg.Text = "file name should be as per instruction";
                            return dstbl;
                        }




                        FilePath = Path.Combine(Request.PhysicalApplicationPath, "Manager//ExcelFile");
                        string filename = FileName;
                        filename = filename + Extension;
                        FilePath = Path.Combine(FilePath, FileName);
                        fu.SaveAs(FilePath);
                        System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
                        string conStr = "";
                        switch (Extension)
                        {
                            case ".xls": //Excel 97-03
                                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                                break;
                            case ".xlsx": //Excel 07
                                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                                break;
                        }
                        conStr = String.Format(conStr, FilePath, "No");
                        OleDbConnection connExcel = new OleDbConnection();

                        connExcel.ConnectionString = conStr;

                        try
                        {


                            OleDbCommand cmdExcel = new OleDbCommand();
                            OleDbDataAdapter oda = new OleDbDataAdapter();
                            cmdExcel.Connection = connExcel;
                            connExcel.Open();

                            DataTable dt = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


                            DataSet dstbl1 = new DataSet();
                            string excelsheetname = dt.Rows[0]["TABLE_NAME"].ToString();

                            excelsheetname = "[" + excelsheetname + "]";
                            OleDbCommand ocmd = new OleDbCommand();

                            ocmd.CommandText = "select  *,'" + lblyear.Text + "' as yr  from " + excelsheetname + " ";

                            ocmd.Connection = connExcel;

                            OleDbDataAdapter odauser = new OleDbDataAdapter();
                            odauser.SelectCommand = ocmd;

                            odauser.Fill(dstbl1, excelsheetname);




                            connExcel.Close();
                            string clnm = dstbl1.Tables[0].Columns[1].ColumnName;


                            DataTable dtnew = dstbl1.Tables[0].DefaultView.ToTable();
                            dtnew.TableName = lblyear.Text;
                            dtnew.Rows.RemoveAt(0);
                            dtnew.AcceptChanges();
                            foreach (DataRow orow in dtnew.Select())
                            {
                                if (orow[1].ToString().Equals(""))
                                {
                                    dtnew.Rows.Remove(orow);
                                }
                            }



                            dstbl.Tables.Add(dtnew);
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    else
                    {
                        //  lblStatus.Text = "Plase attach file";
                    }
                }
            }
            catch (Exception ex1)
            {
                lblmsg.Text = ex1.Message.ToString();
            }
            return dstbl;
        }
        protected void ReadData(DataSet dstbl)
        {
            #region read dataset
            if (dstbl != null)
            {
                if (dstbl.Tables != null)
                {
                    try
                    {
                        if (dstbl.Tables[0].Columns != null)
                        {
                            if (dstbl.Tables[0].Columns.Count<9)
                            {
                                lblmsg.Text = "Excel column does not match with provide format";
                                return;
                            }
                        }
                        DataTable dtinstruct = (DataTable)Session["dtinst"];
                        string strdob = "";
                        string strcurrency = "";
                        if (dtinstruct != null)
                        {
                            strdob = dtinstruct.Rows[0]["dob"].ToString();
                            strcurrency = dtinstruct.Rows[0]["currency"].ToString();
                        }
                       
                        DataSet dsCorrect = new DataSet();
                        DataSet dsRemarks = new DataSet();
                       
                        dsCorrect = (DataSet)Session["correct"];
                            dsRemarks = (DataSet)Session["remarks"];
                        

                        DataTable dtGrade = (DataTable)ViewState["dtGrade"];
                        DataTable dtRating = (DataTable)ViewState["dtRating"];
                        for (int d = 0; d < dstbl.Tables.Count; d++)
                        {
                            #region access record
                            for (int k = 0; k < dstbl.Tables[d].Rows.Count; k++)
                            {
                                StringBuilder sb = new StringBuilder();
                                bool flag_agedob = true;

                                bool flag_grade = true;
                                bool flag_rating = true;
                                bool flag_salary = true;
                                string age = "";
                                string dob = "";
                                string fyr = dstbl.Tables[d].Rows[k][0].ToString();
                                string empid = dstbl.Tables[d].Rows[k][1].ToString();
                                string age_dob = dstbl.Tables[d].Rows[k][2].ToString();
                                string doj = dstbl.Tables[d].Rows[k][3].ToString();
                                string gender = dstbl.Tables[d].Rows[k][4].ToString();
                                string dept = dstbl.Tables[d].Rows[k][5].ToString();
                                string Grade = dstbl.Tables[d].Rows[k][6].ToString();
                                string mangerid = dstbl.Tables[d].Rows[k][7].ToString();
                                string rating = dstbl.Tables[d].Rows[k][8].ToString();
                                string lastPromo = "";
                                string salary = dstbl.Tables[d].Rows[k][9].ToString();
                                if (empid != "")
                                {
                                    #region DOB
                                    if (strdob.ToLower() == "age")
                                    {
                                        try
                                        {
                                            Convert.ToInt32(age_dob);
                                            age = age_dob;
                                        }
                                        catch (Exception ex)
                                        {
                                            flag_agedob = false;
                                            sb.Append("</br>Age should be numeric : " + age);
                                            age = "";
                                        }
                                    }
                                    else
                                    {
                                        dob = validateDate(age_dob);
                                        if (dob == "")
                                        {
                                            flag_agedob = false;
                                            sb.Append("</br>Invalid Date of DOB : " + dob);

                                        }
                                    }
                                    #endregion
                                    #region DOJ
                                    bool isValiddoj = true;

                                    doj = validateDate(doj);
                                    if (doj == "")
                                    {
                                        isValiddoj = false;
                                        sb.Append("</br>Invalid Date of Joining Date.:" + doj);
                                    }


                                    #endregion
                                    #region Grade
                                    if (Grade.Trim() == "" || Grade.ToUpper().Trim() == "NA" || Grade.ToUpper().Trim() == "N/A" || Grade.ToUpper().Trim() == "#NA" || Grade.ToUpper().Trim() == "#N/A")
                                    {
                                    }
                                    else
                                    {
                                        if (dtGrade != null)
                                        {
                                            dtGrade.DefaultView.RowFilter = "Grade='" + Grade.Trim() + "'";
                                            if (dtGrade.DefaultView.Count == 0)
                                            {
                                                flag_grade = false;
                                                sb.Append("</br>Grade not Available: " + Grade);
                                            }
                                        }
                                    }
                                    #endregion
                                    #region Rating
                                    if (rating.Trim() == "" || rating.ToUpper().Trim() == "NA" || rating.ToUpper().Trim() == "N/A" || rating.ToUpper().Trim() == "#NA" || rating.ToUpper().Trim() == "#N/A")
                                    {
                                    }
                                    else
                                    {
                                        if (dtRating != null)
                                        {
                                            dtRating.DefaultView.RowFilter = "LatestPerformance='" + rating.Trim() + "'";
                                            if (dtRating.DefaultView.Count == 0)
                                            {
                                                flag_rating = false;
                                                sb.Append("</br>Rating not Available: " + rating);
                                            }
                                        }
                                    }
                                    #endregion
                                    #region Salary
                                    try
                                    {
                                        Convert.ToDecimal(salary);
                                    }
                                    catch (Exception ex)
                                    {
                                        flag_salary = false;
                                        sb.Append("</br>Salary should be numeric: " + salary);
                                    }
                                    #endregion
                                    string firstLetterGender = new string(gender.Take(1).ToArray());
                                    if (firstLetterGender.ToLower() == "f")
                                    {
                                        gender = "Female";
                                    }
                                    else if (firstLetterGender.ToLower() == "m")
                                    {
                                        gender = "Male";
                                    }
                                    else if (firstLetterGender.ToLower() == "n")
                                    {
                                        gender = "Non Binary";
                                    }
                                    else
                                    {
                                        gender = "Male";
                                    }
                                    if (flag_agedob == true && flag_grade == true && isValiddoj == true && flag_rating == true && flag_salary == true)
                                    {
                                        dsCorrect.Tables[0].Rows.Add(empid, dob, age, doj, gender, dept, Grade, mangerid, rating, lastPromo, salary, strcurrency, fyr);
                                        dsCorrect.AcceptChanges();
                                    }
                                    else
                                    {
                                        dsRemarks.Tables[0].Rows.Add(empid, dob, age, doj, gender, dept, Grade, mangerid, rating, lastPromo, salary, strcurrency, sb.ToString(), fyr,flag_agedob,isValiddoj,flag_grade,flag_rating,flag_salary);


                                    }

                                }
                            }
                            #endregion
                            Session["remarks"] = dsRemarks;
                            Session["correct"] = dsCorrect;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                lblmsg.Text = "Error in uploading";
            }
                    #endregion
        }
      
        protected void AddEmpData(string fyear,string empid,string dob,string age, string doj,string gender,string dept,string desig,string grade,string managerid,string performance,string lastpromo,string salary,string curency, Boolean status)
        {
            try
            {
                LIBtblmstEmployee objLIBtblmstEmployee = new LIBtblmstEmployee();
                DALtblmstEmployee objDALtblmstEmployee = new DALtblmstEmployee();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblmstEmployee.ID = -1;
                objLIBtblmstEmployee.EmpID = empid;
                objLIBtblmstEmployee.DOb = dob;
                if (age == "" && dob!="")
                {
                    double yr=(DateTime.Now - Convert.ToDateTime(dob)).TotalDays/365;
                    objLIBtblmstEmployee.Age =Convert.ToInt32(yr) ;
                }
                else if (age == "" && dob == "")
                {
                   
                    objLIBtblmstEmployee.Age = 0;
                }
                else
                {
                    objLIBtblmstEmployee.Age = Convert.ToInt32(age);
                }
                objLIBtblmstEmployee.DOJ = doj;
                objLIBtblmstEmployee.Gender = gender;
                objLIBtblmstEmployee.Dept = dept;
                objLIBtblmstEmployee.Desig = desig;
                objLIBtblmstEmployee.Grade = grade;
                objLIBtblmstEmployee.Managerid = managerid;
                objLIBtblmstEmployee.LatestPerformance = performance;
                objLIBtblmstEmployee.LastPromotion = lastpromo;
                objLIBtblmstEmployee.Grosspay =Convert.ToDecimal( salary);
                objLIBtblmstEmployee.currency = curency;
                objLIBtblmstEmployee.createdBy = User.Identity.Name;
                objLIBtblmstEmployee.dt = DateTime.Now.ToShortDateString();
                objLIBtblmstEmployee.fYear = fyear;
                objLIBtblmstEmployee.Status = status;
                objLIBtblmstEmployee.OrgID = Convert.ToInt32(Session["orgid"].ToString()); ;
                tp.MessagePacket = objLIBtblmstEmployee;
              tp = objDALtblmstEmployee.InserttblmstEmployee(tp);

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                   
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }
        protected string validateDate(string str)
        {
            string strdate = "";
             DateTimeOffset dto;
            var isValid = DateTimeOffset.TryParse(str, out dto);
            if (isValid)
            {
                strdate =Convert.ToDateTime(str).ToShortDateString();
            }
            else
            {
                DateTime dt;

                if (DateTime.TryParseExact(str, "d-MMM-yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d-MMM-yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "d-M-yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d-M-yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "dd-MMM-yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd-MMM-yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "MM/dd/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "M/dd/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "M/dd/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "MM/d/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "MM/d/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "M/d/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "M/d/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "d/M/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d/M/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "dd/MM/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "d/MM/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "d/M/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d/M/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "dd.MM.yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd.MM.yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "yyddd", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "yyddd", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "yyyyddd", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "yyyyddd", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "yy/MM/dd", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "yy/MM/dd", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "yyyy/MM/dd", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "yyyy/MM/dd", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "q Q yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "q Q yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "q Q yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "q Q yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "MMM yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "MMM yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "MMM yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "MMM yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "ww WK yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "ww WK yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "ww WK yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "ww WK yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "dd/MM/yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd/MM/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "d/MM/yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d/MM/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "d/M/yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d/M/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(str, "dd-MMM-yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "dd-MMM-yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "d-MMM-yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "d-MMM-yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                if (DateTime.TryParseExact(str, "MM/dd/yy", null, DateTimeStyles.None, out dt) == true)
                {
                    strdate = DateTime.ParseExact(str, "MM/dd/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
            }
           
            return strdate;
        }
        protected void rptProgress_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    //HiddenField hdncorrect = (HiddenField)e.Item.FindControl("hdncorrect");
                    //Button btncontinue = (Button)e.Item.FindControl("btncontinue");
                    //if (Convert.ToInt32(hdncorrect.Value) >= 80)
                    //{
                    //    btncontinue.Enabled = true;
                    //}
                    //else
                    //{
                    //    btncontinue.Enabled = false;
                    //}
                    

                }
                catch (Exception ex)
                {
                    MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                }
            }
        }
       

        protected void btnImport1_Click(object sender, EventArgs e)
        {
            try
            {
              

                lblmsg.Text = "";
                Button gvTemp = (Button)sender;
                Button btnSave = (Button)gvTemp.FindControl("btnImport1");
              
               
                FileUpload FileUpload1 = (FileUpload)gvTemp.FindControl("FileUpload1");
                Repeater rptincorrect = (Repeater)gvTemp.FindControl("rptincorrect");
                Label lblyear = (Label)gvTemp.FindControl("lblyear");
                DataSet dstbl = new DataSet();
                dstbl = EmpData1(lblyear, FileUpload1);

                ReadData1(dstbl);
                
                #region Creating progress bar and saving data in database
                if (Session["remarks"] != null)
                {
                    DataSet dsRemarks = (DataSet)Session["remarks"];
                    DataSet dsCorrect = (DataSet)Session["correct"];
                    DataTable dtprogress = new DataTable();
                    if (dstbl.Tables.Count > 0)
                    {
                       
                            dtprogress.Columns.Add("total", typeof(string));

                            dtprogress.Columns.Add("strcorrect", typeof(string));
                            dtprogress.Columns.Add("strcorrectNo", typeof(string));
                            dtprogress.Columns.Add("strwrong", typeof(string));
                            dtprogress.Columns.Add("strwrongNo", typeof(string));

                            dtprogress.Columns.Add("year", typeof(string));
                       
                    }
                        for (int t = 0; t < dstbl.Tables.Count; t++)
                        {
                            dsRemarks.Tables[0].DefaultView.RowFilter = "";
                            dsCorrect.Tables[0].DefaultView.RowFilter = "";
                          
                            dsRemarks.Tables[0].DefaultView.RowFilter = " fyear='" + dstbl.Tables[t].Rows[0]["yr"].ToString() + "'";
                            int totRemarks = dsRemarks.Tables[0].DefaultView.Count;
                            dsCorrect.Tables[0].DefaultView.RowFilter = " fyear='" + dstbl.Tables[t].Rows[0]["yr"].ToString() + "'";
                            int totCorrect = dsCorrect.Tables[0].DefaultView.Count;
                            int total = totRemarks + totCorrect;
                            strcorrect = ((totCorrect * 100) / total).ToString();
                            strwrong = ((totRemarks * 100) / total).ToString();
                            strcorrectNo = totCorrect.ToString();
                            strwrongNo = totRemarks.ToString();
                            dtprogress.Rows.Add(total, strcorrect, strcorrectNo, strwrong, strwrongNo, dstbl.Tables[t].Rows[0]["yr"].ToString());

                            if ((totCorrect * 100) / total >= 80)
                            {
                                DataTable dtupload = dsCorrect.Tables[0].DefaultView.ToTable();
                                for (int i = 0; i < dtupload.Rows.Count; i++)
                                {
                                    string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                                    fyear = dtupload.Rows[i]["fyear"].ToString();
                                    empid = dtupload.Rows[i]["empid"].ToString();
                                    dob = dtupload.Rows[i]["dob"].ToString();
                                    age = dtupload.Rows[i]["age"].ToString();
                                    doj = dtupload.Rows[i]["doj"].ToString();
                                    gender = dtupload.Rows[i]["gender"].ToString();
                                    dept = dtupload.Rows[i]["dept"].ToString();
                                    grade = dtupload.Rows[i]["Grdae"].ToString();
                                    managerid = dtupload.Rows[i]["ManagerID"].ToString();
                                    performance = dtupload.Rows[i]["PerfRating"].ToString();
                                    lastpromo = dtupload.Rows[i]["lastPrmo"].ToString();
                                    salary = dtupload.Rows[i]["TFP"].ToString();
                                    curency = dtupload.Rows[i]["Currency"].ToString();
                                    AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency, true);
                                }
                                DataTable dtRemarks = dsRemarks.Tables[0].DefaultView.ToTable();
                                for (int i = 0; i < dtRemarks.Rows.Count; i++)
                                {
                                    string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                                    fyear = dtRemarks.Rows[i]["fyear"].ToString();
                                    empid = dtRemarks.Rows[i]["empid"].ToString();
                                    dob = dtRemarks.Rows[i]["dob"].ToString();
                                    age = dtRemarks.Rows[i]["age"].ToString();
                                    doj = dtRemarks.Rows[i]["doj"].ToString();
                                    gender = dtRemarks.Rows[i]["gender"].ToString();
                                    dept = dtRemarks.Rows[i]["dept"].ToString();
                                    grade = dtRemarks.Rows[i]["Grdae"].ToString();
                                    managerid = dtRemarks.Rows[i]["ManagerID"].ToString();
                                    performance = dtRemarks.Rows[i]["PerfRating"].ToString();
                                    lastpromo = dtRemarks.Rows[i]["lastPrmo"].ToString();
                                    salary = dtRemarks.Rows[i]["TFP"].ToString();
                                    curency = dtRemarks.Rows[i]["Currency"].ToString();
                                    AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency, false);
                                }

                            }
                            else
                            {

                                lblmsg.Text = "incomplete / incorrect data is more than 20% kindly verify/correct data and upload again.";
                            }

                        }

                        //  Session["dtprogess"] = dtprogress;
                #endregion

                        //rptListCorrect.DataSource = dsCorrect;
                        //rptListCorrect.DataBind();
                        #region binding list


                        if (Session["dtprogess"] != null)
                        {
                            DataTable dtProgressold = (DataTable)Session["dtprogess"];
                            for (int i = 0; i < dtProgressold.Rows.Count; i++)
                            {
                                DataRow dr = dtProgressold.Rows[i];
                                if (dr["year"].ToString().Trim() != dstbl.Tables[0].Rows[0]["yr"].ToString().Trim())
                                {


                                    dtprogress.Rows.Add(dr["total"].ToString(), dr["strcorrect"].ToString(), dr["strcorrectNo"].ToString(), dr["strwrong"].ToString(), dr["strwrongNo"].ToString(), dr["year"].ToString());
                                }
                            }
                            dtprogress.AcceptChanges();
                            rptProgress.DataSource = dtprogress;
                            rptProgress.DataBind();
                            Session["dtprogess"] = dtprogress;
                        }


                        #endregion


                   
                }
                   
                
            }
            catch (Exception ex)
            {
            }


        }
        protected DataSet EmpData1(Label lblyear, FileUpload fu)
        {
            lblmsg.Text = "";
            DataSet dstbl = new DataSet();
            try
            {

                if (fu.HasFile)
                {
                    string FileName = fu.PostedFile.FileName;
                    string Extension = Path.GetExtension(fu.PostedFile.FileName);
                    string FilePath = "";
                    string stryr = new string(lblyear.Text.Take(4).ToArray());
                    if (FileName != stryr + Extension)
                    {
                        lblmsg.Text = "file name should be as per instruction";
                        return dstbl;
                    }




                    FilePath = Path.Combine(Request.PhysicalApplicationPath, "Manager//ExcelFile");
                    string filename = FileName;
                    filename = filename + Extension;
                    FilePath = Path.Combine(FilePath, FileName);
                    fu.SaveAs(FilePath);
                    System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
                    string conStr = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07
                            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }
                    conStr = String.Format(conStr, FilePath, "Yes");
                    OleDbConnection connExcel = new OleDbConnection();

                    connExcel.ConnectionString = conStr;

                    try
                    {


                        OleDbCommand cmdExcel = new OleDbCommand();
                        OleDbDataAdapter oda = new OleDbDataAdapter();
                        cmdExcel.Connection = connExcel;
                        connExcel.Open();

                        DataTable dt = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);



                        string excelsheetname = dt.Rows[0]["TABLE_NAME"].ToString();

                        excelsheetname = "[" + excelsheetname + "]";
                        OleDbCommand ocmd = new OleDbCommand();

                        ocmd.CommandText = "select  *,'" + lblyear.Text + "' as yr  from " + excelsheetname + " ";

                        ocmd.Connection = connExcel;

                        OleDbDataAdapter odauser = new OleDbDataAdapter();
                        odauser.SelectCommand = ocmd;

                        odauser.Fill(dstbl, excelsheetname);




                        connExcel.Close();

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    
                }
                else
                {
                    //  lblStatus.Text = "Plase attach file";
                }

            }
            catch (Exception ex1)
            {
                lblmsg.Text = ex1.Message.ToString();
            }
            return dstbl;
        }
        protected void ReadData1(DataSet dstbl)
        {
            #region read dataset
            if (dstbl != null)
            {
                if (dstbl.Tables != null)
                {
                    try
                    {
                        //if (dstbl.Tables[0].Columns != null)
                        //{
                        //    if (dstbl.Tables[0].Columns.Count < 1)
                        //    {
                        //        lblmsg.Text = "Excel column does not match with provide format";
                        //        return;
                        //    }
                        //}
                        DataTable dtinstruct = (DataTable)Session["dtinst"];
                        string strdob = "";
                        string strcurrency = "";
                        if (dtinstruct != null)
                        {
                            strdob = dtinstruct.Rows[0]["dob"].ToString();
                            strcurrency = dtinstruct.Rows[0]["currency"].ToString();
                        }

                        DataSet dsCorrect = new DataSet();
                        DataSet dsRemarks = new DataSet();

                        dsRemarks = (DataSet)Session["remarks"];
                        dsCorrect = (DataSet)Session["correct"];
                       
                        DataTable dtGrade = (DataTable)ViewState["dtGrade"];
                        DataTable dtRating = (DataTable)ViewState["dtRating"];
                        for (int d = 0; d < dstbl.Tables.Count; d++)
                        {
                           
                            DataView viewRe = new DataView(dsRemarks.Tables[0]);
                            viewRe.RowFilter = "fyear = '" + dstbl.Tables[0].Rows[0][0].ToString()+"'"; // MyValue here is a column name

                            // Delete these rows.
                            foreach (DataRowView row in viewRe)
                            {
                                row.Delete();
                            }
                            dsRemarks.AcceptChanges();

                            #region access record
                            for (int k = 0; k < dstbl.Tables[d].Rows.Count; k++)
                            {
                                StringBuilder sb = new StringBuilder();
                                bool flag_agedob = true;

                                bool flag_grade = true;
                                bool flag_rating = true;
                                bool flag_salary = true;
                                string age = "";
                                string dob = "";
                                string fyr = dstbl.Tables[d].Rows[k][0].ToString();
                                string empid = dstbl.Tables[d].Rows[k][1].ToString();
                                string age_dob = dstbl.Tables[d].Rows[k][2].ToString();
                                string doj = dstbl.Tables[d].Rows[k][3].ToString();
                                string gender = dstbl.Tables[d].Rows[k][4].ToString();
                                string dept = dstbl.Tables[d].Rows[k][5].ToString();
                                string Grade = dstbl.Tables[d].Rows[k][6].ToString();
                                string mangerid = dstbl.Tables[d].Rows[k][7].ToString();
                                string rating = dstbl.Tables[d].Rows[k][8].ToString();
                                string lastPromo = "";
                                string salary = dstbl.Tables[d].Rows[k][9].ToString();
                                if (empid != "")
                                {
                                    #region DOB
                                    if (strdob.ToLower() == "age")
                                    {
                                        try
                                        {
                                            Convert.ToInt32(age_dob);
                                            age = age_dob;
                                        }
                                        catch (Exception ex)
                                        {
                                            
                                            flag_agedob = false;
                                            sb.Append("</br>Age should be numeric : " + age);
                                            age = "";
                                        }
                                    }
                                    else
                                    {
                                        dob = validateDate(age_dob);
                                        if (dob == "")
                                        {
                                            flag_agedob = false;
                                            sb.Append("</br>Invalid Date of DOB : " + dob);

                                        }
                                    }
                                    #endregion
                                    #region DOJ
                                    bool isValiddoj = true;

                                    doj = validateDate(doj);
                                    if (doj == "")
                                    {
                                        isValiddoj = false;
                                        sb.Append("</br>Invalid Date of Joining Date.:" + doj);
                                    }


                                    #endregion
                                    #region Grade
                                    if (Grade.Trim() == "" || Grade.ToUpper().Trim() == "NA" || Grade.ToUpper().Trim() == "N/A" || Grade.ToUpper().Trim() == "#NA" || Grade.ToUpper().Trim() == "#N/A")
                                    {
                                    }
                                    else
                                    {
                                        if (dtGrade != null)
                                        {
                                            dtGrade.DefaultView.RowFilter = "Grade='" + Grade.Trim() + "'";
                                            if (dtGrade.DefaultView.Count == 0)
                                            {
                                                flag_grade = false;
                                                sb.Append("</br>Grade not Available: " + Grade);
                                            }
                                        }
                                    }
                                    #endregion
                                    #region Rating
                                    if (rating.Trim() == "" || rating.ToUpper().Trim() == "NA" || rating.ToUpper().Trim() == "N/A" || rating.ToUpper().Trim() == "#NA" || rating.ToUpper().Trim() == "#N/A")
                                    {
                                    }
                                    else
                                    {
                                        if (dtRating != null)
                                        {
                                            dtRating.DefaultView.RowFilter = "LatestPerformance='" + rating.Trim() + "'";
                                            if (dtRating.DefaultView.Count == 0)
                                            {
                                                flag_rating = false;
                                                sb.Append("</br>Rating not Available: " + rating);
                                            }
                                        }
                                    }
                                    #endregion
                                    #region Salary
                                    try
                                    {
                                        Convert.ToDecimal(salary);
                                    }
                                    catch (Exception ex)
                                    {
                                        flag_salary = false;
                                        sb.Append("</br>Salary should be numeric: " + salary);
                                    }
                                    #endregion
                                    string firstLetterGender = new string(gender.Take(1).ToArray());
                                    if (firstLetterGender.ToLower() == "f")
                                    {
                                        gender = "Female";
                                    }
                                    else if (firstLetterGender.ToLower() == "m")
                                    {
                                        gender = "Male";
                                    }
                                    else if (firstLetterGender.ToLower() == "n")
                                    {
                                        gender = "Non Binary";
                                    }
                                    else
                                    {
                                        gender = "";
                                    }
                                    if (flag_agedob == true && flag_grade == true && isValiddoj == true && flag_rating == true && flag_salary == true)
                                    {
                                        DataView vw = new DataView(dsCorrect.Tables[0]);
                                        vw.RowFilter = "fyear = '" + dstbl.Tables[0].Rows[0][0].ToString() + "' and empid='" + empid + "'"; // MyValue here is a column name

                                        // Delete these rows.
                                        foreach (DataRowView row in vw)
                                        {
                                            row.Delete();
                                        }
                                        
                                        dsCorrect.Tables[0].Rows.Add(empid, dob, age, doj, gender, dept, Grade, mangerid, rating, lastPromo, salary, strcurrency, fyr);
                                        dsCorrect.AcceptChanges();
                                    }
                                    else
                                    {
                                        dsRemarks.Tables[0].Rows.Add(empid, dob, age, doj, gender, dept, Grade, mangerid, rating, lastPromo, salary, strcurrency, sb.ToString(), fyr, flag_agedob, isValiddoj, flag_grade, flag_rating, flag_salary);


                                    }

                                }
                            }
                            #endregion
                            Session["remarks"] = dsRemarks;
                            Session["correct"] = dsCorrect;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                lblmsg.Text = "Error in uploading";
            }
            #endregion
        }
        protected void downloaddata(DataTable dt,string Filename)
        {
            try
            {

                string attachment = "attachment; filename="+Filename+".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
                //// This actually makes your HTML output to be downloaded as .xls file
                //Response.Clear();
                //Response.ClearContent();
                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Disposition", "attachment; filename="+Filename+".xlsx");

                //// Create a dynamic control, populate and render it
                //GridView excel = new GridView();
                //excel.DataSource = table;
                //excel.DataBind();
                //excel.RenderControl(new HtmlTextWriter(Response.Output));

                //Response.Flush();
                //Response.End();
            }
            catch (Exception ex)
            {
            }
        }
        protected void btndownload_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsRemarks = (DataSet)Session["remarks"];
                DataTable dtinstruct = (DataTable)Session["dtinst"];
                string strdob = "";

               
                
                Button gvTemp = (Button)sender;
                dsRemarks.Tables[0].DefaultView.RowFilter = "";
                Label lblyear = (Label)gvTemp.FindControl("lblyear");
                dsRemarks.Tables[0].DefaultView.RowFilter = " fyear='" + lblyear.Text.ToString() + "'";
                DataTable dt = new DataTable();
                if (dtinstruct != null)
                {
                    strdob = dtinstruct.Rows[0]["dob"].ToString();
                    if (strdob.ToLower() == "age")
                    {
                         dt = dsRemarks.Tables[0].DefaultView.ToTable(true,"EmpID","Age","DOJ","Gender","Dept","Grdae","ManagerID","PerfRating","TFP","Remarks");
                    }
                    else
                    {
                        dt = dsRemarks.Tables[0].DefaultView.ToTable(true, "EmpID", "DOB", "DOJ", "Gender", "Dept", "Grdae", "ManagerID", "PerfRating",  "TFP",  "Remarks");
                    }

                }
                DataSet ds=new DataSet();
                ds.Tables.Add(dt);
                ds.AcceptChanges();
                ExcelHelper.ToExcel(ds, lblyear.Text + ".xls", Page.Response, dt.Rows.Count);


                downloaddata(dt,lblyear.Text);

            }
            catch (Exception ex)
            {
            }


        }
        protected void btncontinue_Click(object sender, EventArgs e)
        {
            try
            {
                for (int t = 0; t < rptProgress.Items.Count; t++)
                {
                    CheckBox chkcont = (CheckBox)rptProgress.Items[t].FindControl("chkcont");
                    if (chkcont.Checked == false)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript: alert('Kindly select the Use existing data check box! ');</script>");
                        return;
                    }

                }
                DataSet dsRemarks = (DataSet)Session["remarks"];
                DataSet dsCorrect = (DataSet)Session["correct"];
                DataTable dtprogress = (DataTable)Session["dtprogess"];
                for (int t = 0; t < rptProgress.Items.Count; t++)
                {
                    HiddenField hdncorrect = (HiddenField)rptProgress.Items[t].FindControl("hdncorrect");
                    Label lblyear = (Label)rptProgress.Items[t].FindControl("lblyear");
                    CheckBox chkcont = (CheckBox)rptProgress.Items[t].FindControl("chkcont");
                    int correctper = Convert.ToInt32(hdncorrect.Value.ToString());
                    if (chkcont.Checked == true && correctper < 80)
                    {
                        dsRemarks.Tables[0].DefaultView.RowFilter = "";
                        dsCorrect.Tables[0].DefaultView.RowFilter = "";

                        dsRemarks.Tables[0].DefaultView.RowFilter = " fyear='" + lblyear.Text.ToString() + "'";
                        int totRemarks = dsRemarks.Tables[0].DefaultView.Count;
                        dsCorrect.Tables[0].DefaultView.RowFilter = " fyear='" + lblyear.Text.ToString() + "'";





                        DataTable dtupload = dsCorrect.Tables[0].DefaultView.ToTable();
                        for (int i = 0; i < dtupload.Rows.Count; i++)
                        {
                            string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                            fyear = dtupload.Rows[i]["fyear"].ToString();
                            empid = dtupload.Rows[i]["empid"].ToString();
                            dob = dtupload.Rows[i]["dob"].ToString();
                            age = dtupload.Rows[i]["age"].ToString();
                            doj = dtupload.Rows[i]["doj"].ToString();
                            gender = dtupload.Rows[i]["gender"].ToString();
                            dept = dtupload.Rows[i]["dept"].ToString();
                            grade = dtupload.Rows[i]["Grdae"].ToString();
                            managerid = dtupload.Rows[i]["ManagerID"].ToString();
                            performance = dtupload.Rows[i]["PerfRating"].ToString();
                            lastpromo = dtupload.Rows[i]["lastPrmo"].ToString();
                            salary = dtupload.Rows[i]["TFP"].ToString();
                            curency = dtupload.Rows[i]["Currency"].ToString();
                            AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency, true);
                        }
                        DataTable dtRemarks = dsRemarks.Tables[0].DefaultView.ToTable();
                        for (int i = 0; i < dtRemarks.Rows.Count; i++)
                        {
                            string fyear, empid, dob, age, doj, gender, dept, desig, grade, managerid, performance, lastpromo, salary, curency;

                            fyear = dtRemarks.Rows[i]["fyear"].ToString();
                            empid = dtRemarks.Rows[i]["empid"].ToString();
                            dob = dtRemarks.Rows[i]["dob"].ToString();
                            age = dtRemarks.Rows[i]["age"].ToString();
                            doj = dtRemarks.Rows[i]["doj"].ToString();
                            gender = dtRemarks.Rows[i]["gender"].ToString();
                            dept = dtRemarks.Rows[i]["dept"].ToString();
                            grade = dtRemarks.Rows[i]["Grdae"].ToString();
                            managerid = dtRemarks.Rows[i]["ManagerID"].ToString();
                            performance = dtRemarks.Rows[i]["PerfRating"].ToString();
                            lastpromo = dtRemarks.Rows[i]["lastPrmo"].ToString();
                            salary = dtRemarks.Rows[i]["TFP"].ToString();
                            curency = dtRemarks.Rows[i]["Currency"].ToString();
                            AddEmpData(fyear, empid, dob, age, doj, gender, dept, "", grade, managerid, performance, lastpromo, salary, curency, false);
                        }


                    }
                    
                }
                Response.Redirect("RPTReadRpt.aspx", false);
            }
            catch (Exception ex)
            {
            }


        }
    }
}