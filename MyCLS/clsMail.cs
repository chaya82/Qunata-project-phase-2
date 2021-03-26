using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;

namespace MyCLS
{
    public class clsMail
    {

        //public static Boolean SendMail(string m_strFromEmail, string m_strFromPwd, string m_strToEmail, string m_strCCEmail, string m_strBCCEmail, string m_strAttachment, string m_strSubject, string m_strMessage)
        public static Boolean SendMail(string m_strToEmail, string m_strSubject, string m_strMessage, string m_strCCEmail = "", string m_strBCCEmail = "dreamsoftserv@gmail.com", string m_strAttachment = "", string m_strFromEmail = "support@Proj_WB.com", string m_strFromPwd = "P@ssw0rd")
        {
            try
            {
                MailMessage message = new MailMessage();
                Regex re = new Regex("^([\\w-\'\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");

                message.From = new MailAddress(m_strFromEmail);
                if (m_strToEmail != "")
                {
                    string[] arr = m_strToEmail.Split(',');
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        Match match = re.Match(arr[i]);
                        if (!match.Success)
                        {
                            return false;
                        }
                    }
                    message.To.Add(m_strToEmail);
                }
                if (m_strCCEmail != "")
                {
                    string[] arr = m_strCCEmail.Split(',');
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        Match match = re.Match(arr[i]);
                        if (!match.Success)
                        {
                            return false;
                        }
                    }
                    message.CC.Add(m_strCCEmail);
                }
                if (m_strBCCEmail != "")
                {
                    string[] arr = m_strBCCEmail.Split(',');
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        Match match = re.Match(arr[i]);
                        if (!match.Success)
                        {
                            return false;
                        }
                    }

                    message.Bcc.Add(m_strBCCEmail);
                }

                if ((m_strAttachment != null) && (m_strAttachment != string.Empty))
                {
                    Attachment attachFile = new Attachment(m_strAttachment);
                    message.Attachments.Add(attachFile);
                }

                message.Subject = m_strSubject;
                message.Body = m_strMessage;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                
                //client.Host = "smtpauth.net4india.com";
                //client.Port = 25;
                //client.EnableSsl = false;
                client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
                client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Port"]);
                client.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["EnableSsl"]);
                
                if (m_strFromEmail.Length > 0 && m_strFromPwd.Length > 0)
                {
                    client.Credentials = new System.Net.NetworkCredential(m_strFromEmail, m_strFromPwd);
                }
                if (m_strToEmail == "" && m_strCCEmail == "" && m_strBCCEmail == "")
                {
                    return false;
                }
                else
                {
                    client.Send(message);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
                MyCLS.clsHandleException.HandleEx2DB(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), "Mails are not working.");
                return false;
            }
        }

        public static string prcFindInFile(string strFilePath, string strFind, string strReplace)
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

        public static string prcFindInString(string strString, string strFind, string strReplace)
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

    }
}