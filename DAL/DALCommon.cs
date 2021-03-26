
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
//using Microsoft.Web.Administration;
using System.Diagnostics;
using MyCLS;
//using System.Drawing;
using System.Web;
using System.IO;
using System.Net.Mail;
using System.Configuration;
//using System.Web.UI;

namespace NDS.DAL
{
   
    public class DALCommon
    {
        public DataSet FillData(string whrCon, string procedureName)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

            try
            {
                objParamList.Add(new SqlParameter("@whrCon", whrCon));
               
                ds = clsESPSql.ExecuteSPDataSet(procedureName, objParamList);
                return ds;
            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public static TimeSpan GetOffSetTime(string date)
        {
            DateTime d = Convert.ToDateTime(date);
            TimeZone zone = TimeZone.CurrentTimeZone;
            var x = zone.ToUniversalTime(d);
            TimeSpan local = zone.GetUtcOffset(d);
            return local;
        }
       
        public int DeleteSYData(string AppId, string tableNm)
        {
            DataSet ds = new DataSet();
            int rCount = 0;
            List<SqlParameter> objParamList = new List<SqlParameter>();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

            try
            {
                objParamList.Add(new SqlParameter("@whrCon", AppId));
                objParamList.Add(new SqlParameter("@tableName", tableNm));

                rCount = clsESPSql.ExecuteSPNonQuery("Sp_DeleteTableData", objParamList);

            }
            catch (Exception ex)
            {


            }


            return rCount;

        }
        public int ExNonQuery(string Query)
        {
            DataSet ds = new DataSet();
            int rCount = 0;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

            try
            {

                objParamList.Add(new SqlParameter("@Query", Query));

                rCount = clsESPSql.ExecuteSPNonQuery("SP_QueryExec", objParamList);

            }
            catch (Exception ex)
            {


            }


            return rCount;

        }
        public DataSet ExQuery(string Query)
        {
            DataSet ds = new DataSet();
            int rCount = 0;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

            try
            {

                objParamList.Add(new SqlParameter("@Query", Query));

                ds = clsESPSql.ExecuteSPDataSet("SP_QueryExec", objParamList);

            }
            catch (Exception ex)
            {


            }


            return ds;

        }
        public  string prcFindInString(string strString, string strFind, string strReplace)
        {

            string strModified = "";
            try
            {
                StringReader FR = new StringReader(strString);
                while (FR.Peek() != -1)
                {
                    strModified = strModified + FR.ReadLine();
                }
                strModified = strModified.Replace(strFind, strReplace);
                FR.Close();
                return strModified;
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                return strModified;
            }
        }
        public  string prcFindInFile(string strFilePath, string strFind, string strReplace)
        {
            string strFile = "";
            try
            {
                //MyCLS.clsHandleException.HandleEx(new Exception("FindInFile Exception"), System.Reflection.MethodBase.GetCurrentMethod().ToString(), true, strFind, strReplace);

                System.IO.StreamReader FR = null;
                FR = File.OpenText(strFilePath);

                while (!FR.EndOfStream)
                {
                    strFile = FR.ReadToEnd();
                }
                //MsgBox(Len(strFile) & vbCrLf & strFile)
                //MsgBox("<a href=""#"">")            
                strFile = strFile.Replace(strFind, strReplace);
                //MsgBox(Len(strFile) & vbCrLf & strFile)
                FR.Close();
                return strFile;
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                return strFile;
            }
        }
        public DataSet importComboDataFill(string _IdField, string _Desc, string _tableNm, string _whrCon)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

            try
            {
                objParamList.Add(new SqlParameter("@IdField", _IdField));
                objParamList.Add(new SqlParameter("@FieldDESC", _Desc));
                objParamList.Add(new SqlParameter("@tableName", _tableNm));
                objParamList.Add(new SqlParameter("@whrCon", _whrCon));
                ds = clsESPSql.ExecuteSPDataSet("importComboData", objParamList);

            }
            catch (Exception ex)
            {
                return null;

            }


            return ds;
        }

        public string GenerateOTP(string typ="*",int len=12)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (typ == "*")
            {
                characters += alphabets + small_alphabets + numbers;
            }
          
            int length = len;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        public void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("inQsights_Op<" + ConfigurationManager.AppSettings["UserName"].ToString() + ">");
                    mailMessage.Bcc.Add(ConfigurationManager.AppSettings["Bcc"].ToString());
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}