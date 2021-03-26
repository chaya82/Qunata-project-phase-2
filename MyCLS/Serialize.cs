using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCLS
{
    public class Serialize
    {

        public string SerializeObject(object myObject)
        {
            var xmldoc = new System.Xml.XmlDocument();
            try
            {
                var stream = new System.IO.MemoryStream();
                //var stream = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\FS_JPD.txt", System.IO.FileMode.Create);//.MemoryStream();
                var serializer = new System.Xml.Serialization.XmlSerializer(myObject.GetType());
                using (stream)
                {
                    serializer.Serialize(stream, myObject);
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    xmldoc.Load(stream);
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true, "");
            }
            return xmldoc.InnerXml;
        }

        public object DeSerializeObject(object myObject, Type objectType)
        {
            try
            {
                var xmlSerial = new System.Xml.Serialization.XmlSerializer(objectType);
                var xmlStream = new System.IO.StringReader(myObject.ToString());
                return xmlSerial.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true, "");
                return Convert.ChangeType(new object(), objectType);
            }
        }













        public static byte[] StrToByteArray(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string ByteArrayToStr(byte[] barr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(barr, 0, barr.Length);
        }

        public string SerializeDataTable(DataTable myDT)
        {
            //Serialize
            string s = "";
            try
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                bformatter.Serialize(stream, myDT);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true, "");
            }
            return s;
        }

        public object DeSerializeDataTable(String s)
        {
            //deserialise
            DataTable myDT = new DataTable();
            try
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                byte[] d;
                d = StrToByteArray(s);
                stream = new MemoryStream(d);
                myDT = (DataTable)bformatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true, "");
            }
            return myDT;
        }







    }
}
