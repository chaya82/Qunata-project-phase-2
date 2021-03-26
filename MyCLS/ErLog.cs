using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MyCLS
{
    [Serializable]
    public class LIBErLog
    {
        private Int32 _Id;
        public Int32 Id
        {
            get;
            set;
        }
        private DateTime _Dt;
        public DateTime Dt
        {
            get;
            set;
        }
        private String _StackTrace;
        public String StackTrace
        {
            get;
            set;
        }
        private String _MethodName;
        public String MethodName
        {
            get;
            set;
        }
        private String _Username;
        public String Username
        {
            get;
            set;
        }
        private String _Msg;
        public String Msg
        {
            get;
            set;
        }
        private String _Source;
        public String Source
        {
            get;
            set;
        }
        private String _TargetSite;
        public String TargetSite
        {
            get;
            set;
        }
        private String _Data;
        public String Data
        {
            get;
            set;
        }
        private String _InnerEx;
        public String InnerEx
        {
            get;
            set;
        }
        private String _FullMsg;
        public String FullMsg
        {
            get;
            set;
        }
    }

    [Serializable]
    public class LIBErLogListing : List<LIBErLog>
    {

    }

    public class DALErLog
    {
        //PUT IT IN LOAD EVENTS

        //strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
        //strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

        //*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
        //try
        //{
        //    LIBErLogListing objLIBErLogListing = new LIBErLogListing();
        //    DALErLog objDALErLog = new DALErLog();
        //    TransportationPacket tp = new TransportationPacket();
        //    Dateset ds = new Dataset();

        ////  txt.Text = objLIBErLogListing[0].Id;
        ////  txt.Text = objLIBErLogListing[0].Dt;
        ////  txt.Text = objLIBErLogListing[0].StackTrace;
        ////  txt.Text = objLIBErLogListing[0].MethodName;
        ////  txt.Text = objLIBErLogListing[0].Username;
        ////  txt.Text = objLIBErLogListing[0].Msg;
        ////  txt.Text = objLIBErLogListing[0].Source;
        ////  txt.Text = objLIBErLogListing[0].TargetSite;
        ////  txt.Text = objLIBErLogListing[0].Data;
        ////  txt.Text = objLIBErLogListing[0].FullMsg;
        //    tp = objDALErLog.GetErLogDetails();
        //    if(tp.MessageId == 1)
        //{
        //        objLIBErLogListing = (LIBErLogListing)tp.MessageResultset;
        //        ds = (Dateset)tp.MessageResultsetDS;
        //        MessageBox.Show(objLIBErLogListing[0].ToString());
        //    }
        //}
        //catch(Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}

        /// <summary>
        /// Accepts=Nothing, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public TransportationPacket GetErLogDetails()
        {
            DataSet ds = new DataSet();
            LIBErLogListing objLIBErLogListing = new LIBErLogListing();

            TransportationPacket Packet = new TransportationPacket();
            clsExecuteStoredProcSql clsESPSql = new clsExecuteStoredProcSql();

            try
            {
                ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromErLog");
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    LIBErLog oLIBErLog = new LIBErLog();
                                    objLIBErLogListing.Add(oLIBErLog);
                                    objLIBErLogListing[i].Id = (int)ds.Tables[0].Rows[i]["Id"];
                                    objLIBErLogListing[i].Dt = (DateTime)ds.Tables[0].Rows[i]["Dt"];
                                    objLIBErLogListing[i].StackTrace = ds.Tables[0].Rows[i]["StackTrace"].ToString();
                                    objLIBErLogListing[i].MethodName = ds.Tables[0].Rows[i]["MethodName"].ToString();
                                    objLIBErLogListing[i].Username = ds.Tables[0].Rows[i]["Username"].ToString();
                                    objLIBErLogListing[i].Msg = ds.Tables[0].Rows[i]["Msg"].ToString();
                                    objLIBErLogListing[i].Source = ds.Tables[0].Rows[i]["Source"].ToString();
                                    objLIBErLogListing[i].TargetSite = ds.Tables[0].Rows[i]["TargetSite"].ToString();
                                    objLIBErLogListing[i].Data = ds.Tables[0].Rows[i]["Data"].ToString();
                                    objLIBErLogListing[i].InnerEx = ds.Tables[0].Rows[i]["InnerEx"].ToString();
                                    objLIBErLogListing[i].FullMsg = ds.Tables[0].Rows[i]["FullMsg"].ToString();
                                }
                                Packet.MessageId = 1;
                            }
                            else
                                Packet.MessageId = -1;
                        }
                    }
                }

                Packet.MessageResultsetDS = ds;
                Packet.MessageResultset = objLIBErLogListing;

            }
            catch (Exception ex)
            {
                Packet.MessageId = -1;
                clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
            }
            return Packet;
        }


        //*******COPY IT TO USE BELOW FUNCTION - SELECT BY ID************
        //try
        //{
        //    LIBErLogListing objLIBErLogListing = new LIBErLogListing();
        //    DALErLog objDALErLog = new DALErLog();
        //    TransportationPacket tp = new TransportationPacket();
        //    Dateset ds = new Dataset();
        //    tp.MessagePacket = 1;    //ID to be Passed

        ////  txt.Text = objLIBErLogListing[0].Id = "";
        ////  txt.Text = objLIBErLogListing[0].Dt = "";
        ////  txt.Text = objLIBErLogListing[0].StackTrace = "";
        ////  txt.Text = objLIBErLogListing[0].MethodName = "";
        ////  txt.Text = objLIBErLogListing[0].Username = "";
        ////  txt.Text = objLIBErLogListing[0].Msg = "";
        ////  txt.Text = objLIBErLogListing[0].Source = "";
        ////  txt.Text = objLIBErLogListing[0].TargetSite = "";
        ////  txt.Text = objLIBErLogListing[0].Data = "";
        ////  txt.Text = objLIBErLogListing[0].FullMsg = "";
        //    tp = objDALErLog.GetErLogDetails(tp);
        //    if(tp.MessageId == 1)
        //{
        //        objLIBErLogListing = (LIBErLogListing)tp.MessageResultset;
        //        ds = (Dateset)tp.MessageResultsetDS;
        //        MessageBox.Show(objLIBErLogListing[0].ToString());
        //    }
        //    }
        //catch(Exception ex)
        //    {
        //    MessageBox.Show(ex.Message);
        //    }

        /// <summary>
        /// Accepts=TransportationPacket, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public TransportationPacket GetErLogDetails(TransportationPacket Packet)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            LIBErLogListing objLIBErLogListing = new LIBErLogListing();
            clsExecuteStoredProcSql clsESPSql = new clsExecuteStoredProcSql();

            try
            {
                objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
                ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromErLogById", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    LIBErLog oLIBErLog = new LIBErLog();

                                    objLIBErLogListing.Add(oLIBErLog);
                                    objLIBErLogListing[i].Id = (int)ds.Tables[0].Rows[i]["Id"];
                                    objLIBErLogListing[i].Dt = (DateTime)ds.Tables[0].Rows[i]["Dt"];
                                    objLIBErLogListing[i].StackTrace = ds.Tables[0].Rows[i]["StackTrace"].ToString();
                                    objLIBErLogListing[i].MethodName = ds.Tables[0].Rows[i]["MethodName"].ToString();
                                    objLIBErLogListing[i].Username = ds.Tables[0].Rows[i]["Username"].ToString();
                                    objLIBErLogListing[i].Msg = ds.Tables[0].Rows[i]["Msg"].ToString();
                                    objLIBErLogListing[i].Source = ds.Tables[0].Rows[i]["Source"].ToString();
                                    objLIBErLogListing[i].TargetSite = ds.Tables[0].Rows[i]["TargetSite"].ToString();
                                    objLIBErLogListing[i].Data = ds.Tables[0].Rows[i]["Data"].ToString();
                                    objLIBErLogListing[i].InnerEx = ds.Tables[0].Rows[i]["InnerEx"].ToString();
                                    objLIBErLogListing[i].FullMsg = ds.Tables[0].Rows[i]["FullMsg"].ToString();
                                }
                                Packet.MessageId = 1;
                            }
                            else
                                Packet.MessageId = -1;
                        }
                    }
                }

                Packet.MessageResultsetDS = ds;
                Packet.MessageResultset = objLIBErLogListing;

            }
            catch (Exception ex)
            {
                Packet.MessageId = -1;
                clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
            }
            return Packet;
        }


        //*******COPY IT TO USE BELOW FUNCTION - INSERT************
        //try
        //{
        //    LIBErLog objLIBErLog = new LIBErLog();
        //    DALErLog objDALErLog = new DALErLog();
        //    TransportationPacket tp = new TransportationPacket();

        //    objLIBErLog.Id = txt.Text;
        //    objLIBErLog.Dt = txt.Text;
        //    objLIBErLog.StackTrace = txt.Text;
        //    objLIBErLog.MethodName = txt.Text;
        //    objLIBErLog.Username = txt.Text;
        //    objLIBErLog.Msg = txt.Text;
        //    objLIBErLog.Source = txt.Text;
        //    objLIBErLog.TargetSite = txt.Text;
        //    objLIBErLog.Data = txt.Text;
        //    objLIBErLog.FullMsg = txt.Text;
        //    tp.MessagePacket = objLIBErLog;
        //    tp = objDALErLog.InsertErLog(tp);

        //    if(tp.MessageId > -1)
        //{
        //        string[] strOutParamValues = (string[])tp.MessageResultset;
        //        MessageBox.Show(strOutParamValues[0].ToString());
        //    }
        //    }
        //catch(Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}

        /// <summary>
        /// Accepts=Packet, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
        /// </summary>
        /// <param name="Packet"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public TransportationPacket InsertErLog(TransportationPacket Packet)
        {
            String[] strOutParamValues = new String[10];
            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();
            clsExecuteStoredProcSql clsESPSql = new clsExecuteStoredProcSql();
            int Result = 0;
            try
            {
                LIBErLog objLIBErLog = new LIBErLog();
                objLIBErLog = (LIBErLog)Packet.MessagePacket;

                objParamList.Add(new SqlParameter("@Id", objLIBErLog.Id));
                //objParamList.Add(new SqlParameter("@Dt", objLIBErLog.Dt));
                objParamList.Add(new SqlParameter("@StackTrace", objLIBErLog.StackTrace));
                objParamList.Add(new SqlParameter("@MethodName", objLIBErLog.MethodName));
                objParamList.Add(new SqlParameter("@Username", objLIBErLog.Username));
                objParamList.Add(new SqlParameter("@Msg", objLIBErLog.Msg));
                objParamList.Add(new SqlParameter("@Source", objLIBErLog.Source));
                objParamList.Add(new SqlParameter("@TargetSite", objLIBErLog.TargetSite));
                objParamList.Add(new SqlParameter("@Data", objLIBErLog.Data));
                objParamList.Add(new SqlParameter("@InnerEx", objLIBErLog.InnerEx));
                objParamList.Add(new SqlParameter("@FullMsg", objLIBErLog.FullMsg));
                objParamListOut.Add(new SqlParameter("@@Id", SqlDbType.Int));
                //strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InsertErLog", objParamList, objParamListOut);
                strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InsertErLog", objParamList, objParamListOut, ref Result);
                //Result = clsESPSql.ExecuteSPNonQuery("SP_InsertErLog", objParamList);
                Packet.MessageId = Result;
                Packet.MessageResultset = strOutParamValues;
            }
            catch (Exception ex)
            {
                Packet.MessageId = -1;
                clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
            }
            return Packet;
        }
    }
}