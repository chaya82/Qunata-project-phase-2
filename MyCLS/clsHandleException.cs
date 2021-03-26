using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace MyCLS
{
    public class clsHandleException
    {
        const string vbTab = "\t";
        static string strLogin = "Guest";

        public static void HandleEx(Exception ex, string MethodName, bool toDB, String LoggedinUserName = "Guest",String IP="")
        {
            try
            {
                string strErrorString = "";
                strLogin = LoggedinUserName;
                //***For JPDBetaTesting - Comment after use***
                //strLogin = "NDSTesting";

                //if (!String.IsNullOrEmpty(WebMatrix.WebData.WebSecurity.CurrentUserName))
                //{
                //    strLogin = WebMatrix.WebData.WebSecurity.CurrentUserName;
                //}
                //else
                //{
                //    strLogin = "Guest";
                //}                
                                                                                

                if (ex.Message != null)
                {
                    strErrorString = strErrorString + "Desc : " + vbTab + vbTab + vbTab + ex.Message.ToString() + System.Environment.NewLine;
                }
                else
                {
                    strErrorString = strErrorString + "Desc : " + vbTab + vbTab + vbTab + "NULL" + System.Environment.NewLine;
                }
                if (ex.StackTrace != null)
                {
                    strErrorString = strErrorString + "StackTrace : " + ex.StackTrace.ToString() + System.Environment.NewLine;
                }
                else
                {
                    strErrorString = strErrorString + "StackTrace : " + "NULL" + System.Environment.NewLine;
                }
                strErrorString = strErrorString + "MethodName : " + vbTab + MethodName + System.Environment.NewLine;
                strErrorString = strErrorString + "Username : " + vbTab + vbTab + strLogin + System.Environment.NewLine;
                if (ex.Source != null)
                {                    
                    strErrorString = strErrorString + "Source : " + vbTab + vbTab + ex.Source.ToString() + System.Environment.NewLine;
                }
                else
                {
                    strErrorString = strErrorString + "Source : " + vbTab + vbTab + "NULL" + System.Environment.NewLine;
                }                                
                if (ex.TargetSite != null)
                {
                    strErrorString = strErrorString + "TargetSite : " + vbTab + ex.TargetSite.ToString() + System.Environment.NewLine;
                }
                else
                {
                    strErrorString = strErrorString + "TargetSite : " + vbTab + "NULL" + System.Environment.NewLine;
                }
                if (ex.Data != null)
                {                    
                    strErrorString = strErrorString + "Data : " + vbTab + vbTab + vbTab + ex.Data.ToString() + System.Environment.NewLine;
                }
                else
                {
                    strErrorString = strErrorString + "Data : " + vbTab + vbTab + vbTab + "NULL" + System.Environment.NewLine;
                }
                if (ex.InnerException != null)
                {
                    strErrorString = strErrorString + "InnerException: " + ex.InnerException.ToString();
                }
                else
                {
                    strErrorString = strErrorString + "InnerException: ";
                }
                if ((toDB) && (ex.Message != "DataBase Not Connecting..."))
                    HandleEx2DB(ex, MethodName, strErrorString,IP);
                else
                    fnWrite2LOG(strErrorString);

                //clsMail.SendMail("dreamsoftserv@gmail.com", "JPD - Exception", strErrorString.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;"));
            }
            catch (Exception ex1)
            {
                //???
            }
        }

        public static void HandleEx2DB(Exception ex, string MethodName, string fullMSG,String IP="")
        {
            try
            {
                LIBErLog objLIBErLog = new LIBErLog();
                DALErLog objDALErLog = new DALErLog();
                TransportationPacket tp = new TransportationPacket();                

                objLIBErLog.Id = -1;
                //objLIBErLog.Dt = txt.Text;
                objLIBErLog.StackTrace = ex.StackTrace == null ? "NULL" : ex.StackTrace.ToString();
                objLIBErLog.MethodName = MethodName;
                objLIBErLog.Username = strLogin;
                objLIBErLog.Msg = ex.Message == null ? "NULL" : ex.Message.ToString();
                objLIBErLog.Source = ex.Source == null ? "NULL" : ex.Source.ToString();
                objLIBErLog.TargetSite = ex.TargetSite == null ? "NULL" : ex.TargetSite.ToString();
                
                if (IP == "")       //***CAPTURE IP IF SENT WHILE FUNCTION CALLED***
                    objLIBErLog.Data = ex.Data == null ? "NULL" : ex.Data.ToString();
                else
                    objLIBErLog.Data = IP;

                if (ex.InnerException != null)
                    objLIBErLog.InnerEx = ex.InnerException.ToString();
                else
                    objLIBErLog.InnerEx = "NULL";

                objLIBErLog.FullMsg = fullMSG;
                //objLIBErLog.FullMsg = fullMsg(ex, MethodName, strLogin);      //fullMsg Method not in USE

                tp.MessagePacket = objLIBErLog;
                tp = objDALErLog.InsertErLog(tp);

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                }
            }
            catch (Exception ex1)
            {
                //???
            }
        }        

        public static void LogINSERTQuery(List<SqlParameter> ParamList, string MethodName)
        {
            try
            {
                string strLOG = "";
                for (Int16 i = 0; i <= ParamList.Count - 1; i++)
                {
                    strLOG = strLOG + ParamList[i].ParameterName + " : " + ParamList[i].Value + Environment.NewLine;
                }
                fnWrite2LOG(MethodName + "(Method) : " + strLOG);
            }
            catch (Exception ex)
            {
            }
        }

        //private static string fullMsg(Exception ex, string MethodName, string strLogin)
        //{
        //    string strErrorString = "";
        //    try
        //    {
        //        strErrorString = "StackTrace : " + ex.StackTrace.ToString() + System.Environment.NewLine;
        //        strErrorString = strErrorString + "MethodName : " + vbTab + MethodName + System.Environment.NewLine;
        //        strErrorString = strErrorString + "Username : " + vbTab + vbTab + strLogin + System.Environment.NewLine;
        //        strErrorString = strErrorString + "Desc : " + vbTab + vbTab + vbTab + ex.Message.ToString() + System.Environment.NewLine;
        //        strErrorString = strErrorString + "Source : " + vbTab + vbTab + ex.Source.ToString() + System.Environment.NewLine;
        //        strErrorString = strErrorString + "TargetSite : " + vbTab + ex.TargetSite.ToString() + System.Environment.NewLine;
        //        strErrorString = strErrorString + "Data : " + vbTab + vbTab + vbTab + ex.Data.ToString() + System.Environment.NewLine;
        //        if (ex.InnerException != null)
        //        {
        //            strErrorString = strErrorString + "InnerException: " + ex.InnerException.ToString();
        //        }
        //        else
        //        {
        //            strErrorString = strErrorString + "InnerException: ";
        //        }
        //    }
        //    catch (Exception ex1)
        //    {
        //        throw;
        //    }
        //    return strErrorString;
        //}

        public static void fnWrite2LOG(string ErrMSG)
        {
            try
            {
                if (ErrMSG.ToString().Contains("Thread was being aborted") == true)
                    return;

                //System.IO.File oFile = null;
                System.IO.StreamWriter oWrite = null;
                string strfilename = null;
                strfilename = "C:\\_Logs\\Err_Proj_WB " + System.DateTime.Now.ToShortDateString() + ".log";
                strfilename = strfilename.Replace("/", "-");
                oWrite = new System.IO.StreamWriter(strfilename, true);
                //oWrite = oFile.AppendText(strfilename);

                //oWrite.WriteLine(vbCrLf & "***" & Format(Now(), "MM/dd/yyyy hh:mm:ss tt") & "********************" & vbCrLf & ErrMSG)
                oWrite.WriteLine("**********" + System.Environment.NewLine + "Reported on : " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + System.Environment.NewLine + "----------------------------------------" + System.Environment.NewLine + ErrMSG + System.Environment.NewLine + "*The End*");

                oWrite.Close();
                //oFile = null;
            }
            catch (Exception ex)
            {
                //???
            }
        }

        /// <summary>
        /// To write text to any file at Location [C:\\MyCLSLog].
        /// </summary>
        /// <param name="FileName">FileName (With Extention).</param>
        /// <param name="txtMSG">Text to be written.</param>
        public static void fnWrite2File(string FileExt, string FileName, string txtMSG)
        {
            try
            {
                if (txtMSG.ToString().Contains("Thread was being aborted") == true)
                    return;

                System.IO.StreamWriter oWrite = null;
                string strfilename = null;
                //strfilename = "C:\\_MyCLSLog\\" + FileName + System.DateTime.Now.ToShortDateString() + "." + FileExt;
                strfilename = "C:\\_MyCLSLog\\" + FileName + "." + FileExt;
                strfilename = strfilename.Replace("/", "-");
                oWrite = new System.IO.StreamWriter(strfilename, true);

                //oWrite.WriteLine("**********" + System.Environment.NewLine + "Reported on : " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + System.Environment.NewLine + "----------------------------------------" + System.Environment.NewLine + txtMSG + System.Environment.NewLine + "*The End*");
                oWrite.WriteLine(txtMSG);

                oWrite.Close();
            }
            catch (Exception ex)
            {
                //???
            }
        }
    }
}