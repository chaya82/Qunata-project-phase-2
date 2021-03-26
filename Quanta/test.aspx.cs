using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;


namespace Quanta
{
    public partial class test : System.Web.UI.Page
    {
        
        public static class SpellChecker
        {
            public static String DidYouMean(string word)
            {
                string retValue = string.Empty;
                try
                {
                    string uri = "https://www.google.com/tbproxy/spell?lang=en:";
                    using (WebClient webclient = new WebClient())
                    {
                        string postData = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><spellrequest textalreadyclipped=\"0\" ignoredups=\"0\" ignoredigits=\"1\" "
                        + "ignoreallcaps=\"1\"><text>{0}</text></spellrequest>", word);

                        webclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        byte[] bytes = Encoding.ASCII.GetBytes(postData);
                        byte[] response = webclient.UploadData(uri, "POST", bytes);
                        string data = Encoding.ASCII.GetString(response);
                        if (data != string.Empty)
                        {
                            retValue = Regex.Replace(data, @"<(.|\n)*?>", string.Empty).Split('\t')[0];
                        }
                    }
                }
                catch (Exception exp)
                {

                }
                return retValue;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string firstFivChar = new string("Female".Take(1).ToArray());
        }

        protected bool CheckDate(String date)
        {

            try
            {

                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch
            {

                return false;

            }

        }
        protected string validateDate(string str)
        {
            string strdate = "";
            DateTimeOffset dto;
            var isValid = DateTimeOffset.TryParse(str, out dto);
            if (isValid)
            {
                strdate = str;
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            ////Verify whether date entered in dd/MM/yyyy format.
            //bool isValid = regex.IsMatch(txtdate.Text.Trim());

            ////Verify whether entered date is Valid date.
            //DateTime dt;
            //isValid = DateTime.TryParseExact(txtdate.Text, "MM/dd/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            //if (!isValid)
            //{
            //    lblmsg.Text="Invalid Date.";
            //    bool isValid1 = DateTime.TryParseExact(txtdate.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            //    if (!isValid1)
            //    {
            //        lblmsg.Text = "Invalid Date.";
            //    }
            //    else
            //    {
            //      lblmsg.Text=  DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            //            .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);    
            //    }
            //}
            //DateTime dt;
            //if (!DateTime.TryParse(txtdate.Text, out dt))
            //{
            //    lblmsg.Text = validateDate(txtdate.Text);
            //}
            //else
            //{
            //    lblmsg.Text = dt.ToShortDateString();
            //}

            validateDate(txtdate.Text);
        }
    }
}