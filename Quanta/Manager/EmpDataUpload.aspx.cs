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

namespace Quanta.Manager
{
    public partial class EmpDataUpload : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    getRatingndGrade();
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
                DataTable dt1 = clsESPSql.ExecQuery("select * from tblmstPerformance where orgid=" + Session["orgid"].ToString());
                ViewState["dtRating"] = dt1;
                DataTable dt = clsESPSql.ExecQuery("select * from tblmstgrade where orgid=" + Session["orgid"].ToString());
                ViewState["dtGrade"] = dt;
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
               

                dtNew.Columns.Add("Remarks", typeof(string));

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

            if (FileUpload1.HasFile)
            {
                string FilePath = "";

                try
                {
                    string FileName = FileUpload1.PostedFile.FileName;
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    FilePath = Path.Combine(Request.PhysicalApplicationPath, "Manager//ExcelFile");
                    string filename = FileName;
                    filename = filename + Extension;
                    FilePath = Path.Combine(FilePath, FileName);
                    FileUpload1.SaveAs(FilePath);
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
                    conStr = String.Format(conStr, FilePath, "no");
                    OleDbConnection connExcel = new OleDbConnection();

                    connExcel.ConnectionString = conStr;
                    DataSet dstbl = new DataSet();
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

                            ocmd.CommandText = "select  *  from " + excelsheetname + " ";

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
                    #region read excel
                    if (dstbl != null)
                    {
                        if (dstbl.Tables != null)
                        {
                            try
                            {
                                DataTable dtinstruct = clsESPSql.ExecQuery("select * from tblmstInstruction where orgid=" + Session["orgid"].ToString());
                                string strdob = "";
                                string strcurrency = "";
                                if (dtinstruct != null)
                                {
                                    strdob = dtinstruct.Rows[0]["dob"].ToString();
                                    strcurrency = dtinstruct.Rows[0]["currency"].ToString();
                                }
                                DataSet dsCorrect = createdatatabel();
                                DataSet dsRemarks = createdatatabel2();
                                DataTable dtGrade = (DataTable)ViewState["dtGrade"];
                                DataTable dtRating = (DataTable)ViewState["dtRating"];
                                StringBuilder sb = new StringBuilder();
                                for (int k = 0; k < dstbl.Tables[0].Rows.Count; k++)
                                {
                                    bool flag_agedob = true;
                                   
                                    bool flag_grade = true;
                                    bool flag_rating = true;
                                    bool flag_salary = true;
                                    string age="";
                                    string dob="";
                                    string empid = dstbl.Tables[0].Rows[k][0].ToString();
                                    string age_dob = dstbl.Tables[0].Rows[k][1].ToString();
                                    string doj = dstbl.Tables[0].Rows[k][2].ToString();
                                    string gender = dstbl.Tables[0].Rows[k][3].ToString();
                                    string dept = dstbl.Tables[0].Rows[k][4].ToString();
                                    string Grade = dstbl.Tables[0].Rows[k][5].ToString();
                                    string mangerid = dstbl.Tables[0].Rows[k][6].ToString();
                                    string rating = dstbl.Tables[0].Rows[k][7].ToString();
                                    string lastPromo = dstbl.Tables[0].Rows[k][8].ToString();
                                    string salary = dstbl.Tables[0].Rows[k][9].ToString();
                                    if (empid != "")
                                    {
                                        #region DOB
                                        if (strdob.ToLower() == "age")
                                        {
                                            try
                                            {
                                                Convert.ToInt32(age_dob);
                                                age=age_dob;
                                            }
                                            catch(Exception ex)
                                            {
                                                flag_agedob = false;
                                                sb.Append("Age should be numeric");
                                            }
                                        }
                                        else
                                        {
                                             dob = validateDate(age_dob);
                                            if (dob == "")
                                            {
                                                flag_agedob = false;
                                                sb.Append("Invail Date of DOB");
                                                
                                            }
                                        }
                        #endregion
                                        #region DOJ
                                        bool isValiddoj = true;

                                        doj = validateDate(doj);
                                        if (doj=="")
                                            {
                                                isValiddoj = false;
                                                sb.Append("Invalid Date of Joining Date.");
                                            }

                                       
                                        #endregion
                                        #region
                                        if (dtGrade != null)
                                        {
                                            dtGrade.DefaultView.RowFilter = "Grade='"+Grade+"'";
                                            if (dtGrade.DefaultView.Count == 0)
                                            {
                                                flag_grade = false;
                                                sb.Append("Grade not Availabe");
                                            }
                                        }
                                        #endregion
                                        #region
                                        if (dtRating != null)
                                        {
                                            dtRating.DefaultView.RowFilter = "LatestPerformance='" + rating + "'";
                                            if (dtRating.DefaultView.Count == 0)
                                            {
                                                flag_rating = false;
                                                sb.Append("Rating not Availabe");
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
                                            sb.Append("Salary should be numeric");
                                        }
                                        #endregion
                                        string firstLetterGender = new string(gender.Take(1).ToArray());
                                        if (firstLetterGender.ToLower() == "f")
                                        {
                                            gender = "Female";
                                        }
                                        if (firstLetterGender.ToLower() == "m")
                                        {
                                            gender = "Male";
                                        }
                                        if (firstLetterGender.ToLower() == "n")
                                        {
                                            gender = "Non Binary";
                                        }
                                        if (flag_agedob == true && flag_grade == true && isValiddoj == true && flag_rating == true && flag_salary == true)
                                        {
                                            dsCorrect.Tables[0].Rows.Add(empid, dob, age, doj, gender, dept, Grade, mangerid, rating, lastPromo, salary, strcurrency);
                                            dsCorrect.AcceptChanges();
                                        }
                                        else
                                        {
                                            dsRemarks.Tables[0].Rows.Add(empid, sb.ToString());

                                        }

                                    }
                                }
                                int total = dstbl.Tables[0].Rows.Count;
                                int totRemarks = dsRemarks.Tables[0].Rows.Count;
                                int totCorrect = dsCorrect.Tables[0].Rows.Count;

                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    #endregion




                    if (file.Exists)
                    {
                        file.Delete();
                    }


                }
                catch (Exception er1)
                { }
            }
            else
            {
                //  lblStatus.Text = "Plase attach file";
            }

        }
        protected string validateDate(string str)
        {
            string strdate = "";

            DateTime dt;
            if (DateTime.TryParseExact(str, "dd-MMM-yy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "dd-MMM-yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            if (DateTime.TryParseExact(str, "d-MMM-yy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "d-MMM-yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
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
            if (DateTime.TryParseExact(str, "MM/dd/yy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "MM/dd/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            if (DateTime.TryParseExact(str, "MM/dd/yyyy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            if (DateTime.TryParseExact(str, "dd/MM/yy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "dd/MM/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            if (DateTime.TryParseExact(str, "dd/MM/yyyy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            if (DateTime.TryParseExact(str, "d/MM/yy", null, DateTimeStyles.None, out dt) == true)
            {
                strdate = DateTime.ParseExact(str, "d/MM/yy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
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


            return strdate;
        }
    }
}