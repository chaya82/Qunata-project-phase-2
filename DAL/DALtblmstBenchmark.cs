using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstBenchmark
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstBenchmarkListing objLIBtblmstBenchmarkListing = new LIBtblmstBenchmarkListing();
//    DALtblmstBenchmark objDALtblmstBenchmark = new DALtblmstBenchmark();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstBenchmarkListing[0].id;
////  txt.Text = objLIBtblmstBenchmarkListing[0].industryid;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm1_1;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm1_2;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm2_1;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm2_2;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm3_1;
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm3_2;
////  txt.Text = objLIBtblmstBenchmarkListing[0].currency;
//    tp = objDALtblmstBenchmark.GettblmstBenchmarkDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstBenchmarkListing = (LIBtblmstBenchmarkListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstBenchmarkListing[0].ToString());
//    }
//}
//catch(Exception ex)
//{
//    MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
//}

/// <summary>
/// Accepts=Nothing, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
/// </summary>
/// <returns></returns>
/// <remarks></remarks>
public MyCLS.TransportationPacket GettblmstBenchmarkDetails()
{
DataSet ds = new DataSet();
LIBtblmstBenchmarkListing objLIBtblmstBenchmarkListing = new LIBtblmstBenchmarkListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstBenchmark");
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
LIBtblmstBenchmark oLIBtblmstBenchmark = new LIBtblmstBenchmark();
objLIBtblmstBenchmarkListing.Add(oLIBtblmstBenchmark);
objLIBtblmstBenchmarkListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstBenchmarkListing[i].industryid =(int)ds.Tables[0].Rows[i]["industryid"];
objLIBtblmstBenchmarkListing[i].bm1_1 =(decimal)ds.Tables[0].Rows[i]["bm1_1"];
objLIBtblmstBenchmarkListing[i].bm1_2 =(decimal)ds.Tables[0].Rows[i]["bm1_2"];
objLIBtblmstBenchmarkListing[i].bm2_1 =(decimal)ds.Tables[0].Rows[i]["bm2_1"];
objLIBtblmstBenchmarkListing[i].bm2_2 =(decimal)ds.Tables[0].Rows[i]["bm2_2"];
objLIBtblmstBenchmarkListing[i].bm3_1 =(decimal)ds.Tables[0].Rows[i]["bm3_1"];
objLIBtblmstBenchmarkListing[i].bm3_2 =(decimal)ds.Tables[0].Rows[i]["bm3_2"];
objLIBtblmstBenchmarkListing[i].currency = ds.Tables[0].Rows[i]["currency"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstBenchmarkListing;

}
catch (Exception ex)
{
Packet.MessageId = -1;
Packet.ex = ex;
MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
}
return Packet;
}


//*******COPY IT TO USE BELOW FUNCTION - SELECT BY ID************
//try
//{
//    LIBtblmstBenchmarkListing objLIBtblmstBenchmarkListing = new LIBtblmstBenchmarkListing();
//    DALtblmstBenchmark objDALtblmstBenchmark = new DALtblmstBenchmark();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstBenchmarkListing[0].id = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].industryid = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm1_1 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm1_2 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm2_1 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm2_2 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm3_1 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].bm3_2 = "";
////  txt.Text = objLIBtblmstBenchmarkListing[0].currency = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstBenchmark.GettblmstBenchmarkDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstBenchmarkListing = (LIBtblmstBenchmarkListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstBenchmarkListing[0].ToString());
//    }
//    }
//catch(Exception ex)
//    {
//    MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
//    }

/// <summary>
/// Accepts=TransportationPacket, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
/// </summary>
/// <returns></returns>
/// <remarks></remarks>
public MyCLS.TransportationPacket GettblmstBenchmarkDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstBenchmarkListing objLIBtblmstBenchmarkListing = new LIBtblmstBenchmarkListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstBenchmarkById", objParamList);
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
LIBtblmstBenchmark oLIBtblmstBenchmark = new LIBtblmstBenchmark();

objLIBtblmstBenchmarkListing.Add(oLIBtblmstBenchmark);
objLIBtblmstBenchmarkListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstBenchmarkListing[i].industryid =(int)ds.Tables[0].Rows[i]["industryid"];
objLIBtblmstBenchmarkListing[i].bm1_1 =(decimal)ds.Tables[0].Rows[i]["bm1_1"];
objLIBtblmstBenchmarkListing[i].bm1_2 =(decimal)ds.Tables[0].Rows[i]["bm1_2"];
objLIBtblmstBenchmarkListing[i].bm2_1 =(decimal)ds.Tables[0].Rows[i]["bm2_1"];
objLIBtblmstBenchmarkListing[i].bm2_2 =(decimal)ds.Tables[0].Rows[i]["bm2_2"];
objLIBtblmstBenchmarkListing[i].bm3_1 =(decimal)ds.Tables[0].Rows[i]["bm3_1"];
objLIBtblmstBenchmarkListing[i].bm3_2 =(decimal)ds.Tables[0].Rows[i]["bm3_2"];
objLIBtblmstBenchmarkListing[i].currency = ds.Tables[0].Rows[i]["currency"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstBenchmarkListing;

}
catch (Exception ex)
{
Packet.MessageId = -1;
Packet.ex = ex;
MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
}
return Packet;
}


//*******COPY IT TO USE BELOW FUNCTION - INSERT************
//try
//{
//    LIBtblmstBenchmark objLIBtblmstBenchmark = new LIBtblmstBenchmark();
//    DALtblmstBenchmark objDALtblmstBenchmark = new DALtblmstBenchmark();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstBenchmark.id = txt.Text;
//    objLIBtblmstBenchmark.industryid = txt.Text;
//    objLIBtblmstBenchmark.bm1_1 = txt.Text;
//    objLIBtblmstBenchmark.bm1_2 = txt.Text;
//    objLIBtblmstBenchmark.bm2_1 = txt.Text;
//    objLIBtblmstBenchmark.bm2_2 = txt.Text;
//    objLIBtblmstBenchmark.bm3_1 = txt.Text;
//    objLIBtblmstBenchmark.bm3_2 = txt.Text;
//    objLIBtblmstBenchmark.currency = txt.Text;
//    tp.MessagePacket = objLIBtblmstBenchmark;
//    tp = objDALtblmstBenchmark.InserttblmstBenchmark(tp);

//    if(tp.MessageId > -1)
//{
//        string[] strOutParamValues = (string[])tp.MessageResultset;
//        MessageBox.Show(strOutParamValues[0].ToString());
//    }
//    }
//catch(Exception ex)
//{
//    MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
//}

/// <summary>
/// Accepts=Packet, Return=Packet, Result=Packet.MessageId, Return Values=Packet.MessageResultset
/// </summary>
/// <param name="Packet"></param>
/// <returns></returns>
/// <remarks></remarks>
public MyCLS.TransportationPacket InserttblmstBenchmark(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstBenchmark objLIBtblmstBenchmark = new LIBtblmstBenchmark();
objLIBtblmstBenchmark = (LIBtblmstBenchmark)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstBenchmark.id));
objParamList.Add(new SqlParameter("@industryid", objLIBtblmstBenchmark.industryid));
objParamList.Add(new SqlParameter("@bm1_1", objLIBtblmstBenchmark.bm1_1));
objParamList.Add(new SqlParameter("@bm1_2", objLIBtblmstBenchmark.bm1_2));
objParamList.Add(new SqlParameter("@bm2_1", objLIBtblmstBenchmark.bm2_1));
objParamList.Add(new SqlParameter("@bm2_2", objLIBtblmstBenchmark.bm2_2));
objParamList.Add(new SqlParameter("@bm3_1", objLIBtblmstBenchmark.bm3_1));
objParamList.Add(new SqlParameter("@bm3_2", objLIBtblmstBenchmark.bm3_2));
objParamList.Add(new SqlParameter("@currency", objLIBtblmstBenchmark.currency));
objParamList.Add(new SqlParameter("@metric", objLIBtblmstBenchmark.metric));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstBenchmark", objParamList, objParamListOut, ref Result);
Packet.MessageId = Result;
Packet.MessageResultset = strOutParamValues;

}
catch (Exception ex)
{
Packet.MessageId = -1;
Packet.ex = ex;
MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
}
return Packet;
}

}
}
