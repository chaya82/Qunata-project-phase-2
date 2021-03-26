using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Summary description for MUtility
/// </summary>
/// 
namespace MyCLS
{
    public class IntegrationKit_libfuncs
    {

        public string getchecksum(string MerchantId, string OrderId, string Amount, string redirectUrl, string WorkingKey)
        {
            string str = null;
            long adler = 0;
            str = ((((MerchantId + "|") + OrderId + "|") + Amount + "|") + redirectUrl + "|") + WorkingKey;
            adler = 1;
            return adler32(adler, str);
        }

        private string adler32(long adler, string strPattern)
        {
            long BASE = 0;
            long s1 = 0;
            long s2 = 0;
            char[] testchar = null;
            long intTest = 0;

            BASE = 65521;
            s1 = andop(adler, 65535);
            s2 = andop(cdec(rightshift(cbin(adler), 16)), 65535);

            for (int n = 0; n <= strPattern.Length - 1; n++)
            {
                testchar = (strPattern.Substring(n, 1)).ToCharArray();
                //intTest = CLng(testchar(0))
                intTest = Convert.ToInt32(testchar[0]);

                s1 = (s1 + intTest) % BASE;
                s2 = (s2 + s1) % BASE;
            }
            return (cdec(leftshift(cbin(s2), 16)) + s1).ToString();
        }

        private long power(long num)
        {
            long result = 1;
            for (int i = 1; i <= num; i++)
            {
                result = result * 2;
            }
            return result;
        }


        private long andop(long op1, long op2)
        {
            string op = null;
            string op3 = null;
            string op4 = null;
            op = "";

            op3 = cbin(op1);
            op4 = cbin(op2);

            for (int i = 0; i <= 31; i++)
            {
                op = (op + "") + ((long.Parse(op3.Substring(i, 1))) & (long.Parse(op4.Substring(i, 1))));
            }
            return cdec(op);
        }

        private string cbin(long num)
        {
            string bin = "";
            do
            {
                bin = (((num % 2)) + bin).ToString();
                num = Convert.ToInt64(Math.Floor(Convert.ToDouble(num / 2)));
            } while (!(num == 0));

            long tempCount = 32 - bin.Length;

            for (int i = 1; i <= tempCount; i++)
            {
                bin = "0" + bin;
            }
            return bin;
        }

        private string leftshift(string str, long num)
        {
            long tempCount = 32 - str.Length;

            for (int i = 1; i <= tempCount; i++)
            {
                str = "0" + str;
            }

            for (int i = 1; i <= num; i++)
            {
                str = str + "0";
                str = str.Substring(1, str.Length - 1);
            }
            return str;
        }

        private string rightshift(string str, long num)
        {
            for (int i = 1; i <= num; i++)
            {
                str = "0" + str;
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private long cdec(string strNum)
        {
            long dec = 0;
            for (int n = 0; n <= strNum.Length - 1; n++)
            {
                dec = dec + Convert.ToInt64((long.Parse(strNum.Substring(n, 1)) * power(strNum.Length - (n + 1))));
            }
            return dec;
        }

        public string verifychecksum(string MerchantId, string OrderId, string Amount, string AuthDesc, string WorkingKey, string checksum)
        {
            string str = null;
            string retval = null;
            string adlerResult = null;
            long adler = 0;
            str = ((((MerchantId + "|") + OrderId + "|") + Amount + "|") + AuthDesc + "|") + WorkingKey;
            adler = 1;
            adlerResult = adler32(adler, str);

            if (string.Compare(adlerResult, checksum, true) == 0)
            {
                retval = "true";
            }
            else
            {
                retval = "false";
            }
            return retval;
        }

    }
}
