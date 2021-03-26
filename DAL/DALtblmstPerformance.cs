using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstPerformance
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstPerformanceListing objLIBtblmstPerformanceListing = new LIBtblmstPerformanceListing();
//    DALtblmstPerformance objDALtblmstPerformance = new DALtblmstPerformance();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstPerformanceListing[0].id;
////  txt.Text = objLIBtblmstPerformanceListing[0].orgid;
////  txt.Text = objLIBtblmstPerformanceListing[0].LatestPerformance;
////  txt.Text = objLIBtblmstPerformanceListing[0].PerLevel;
//    tp = objDALtblmstPerformance.GettblmstPerformanceDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstPerformanceListing = (LIBtblmstPerformanceListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstPerformanceListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstPerformanceDetails()
{
DataSet ds = new DataSet();
LIBtblmstPerformanceListing objLIBtblmstPerformanceListing = new LIBtblmstPerformanceListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstPerformance");
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
LIBtblmstPerformance oLIBtblmstPerformance = new LIBtblmstPerformance();
objLIBtblmstPerformanceListing.Add(oLIBtblmstPerformance);
objLIBtblmstPerformanceListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstPerformanceListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstPerformanceListing[i].LatestPerformance = ds.Tables[0].Rows[i]["LatestPerformance"].ToString();
objLIBtblmstPerformanceListing[i].PerLevel =(int)ds.Tables[0].Rows[i]["PerLevel"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstPerformanceListing;

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
//    LIBtblmstPerformanceListing objLIBtblmstPerformanceListing = new LIBtblmstPerformanceListing();
//    DALtblmstPerformance objDALtblmstPerformance = new DALtblmstPerformance();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstPerformanceListing[0].id = "";
////  txt.Text = objLIBtblmstPerformanceListing[0].orgid = "";
////  txt.Text = objLIBtblmstPerformanceListing[0].LatestPerformance = "";
////  txt.Text = objLIBtblmstPerformanceListing[0].PerLevel = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstPerformance.GettblmstPerformanceDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstPerformanceListing = (LIBtblmstPerformanceListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstPerformanceListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstPerformanceDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstPerformanceListing objLIBtblmstPerformanceListing = new LIBtblmstPerformanceListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstPerformanceById", objParamList);
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
LIBtblmstPerformance oLIBtblmstPerformance = new LIBtblmstPerformance();

objLIBtblmstPerformanceListing.Add(oLIBtblmstPerformance);
objLIBtblmstPerformanceListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstPerformanceListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstPerformanceListing[i].LatestPerformance = ds.Tables[0].Rows[i]["LatestPerformance"].ToString();
objLIBtblmstPerformanceListing[i].PerLevel =(int)ds.Tables[0].Rows[i]["PerLevel"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstPerformanceListing;

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
//    LIBtblmstPerformance objLIBtblmstPerformance = new LIBtblmstPerformance();
//    DALtblmstPerformance objDALtblmstPerformance = new DALtblmstPerformance();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstPerformance.id = txt.Text;
//    objLIBtblmstPerformance.orgid = txt.Text;
//    objLIBtblmstPerformance.LatestPerformance = txt.Text;
//    objLIBtblmstPerformance.PerLevel = txt.Text;
//    tp.MessagePacket = objLIBtblmstPerformance;
//    tp = objDALtblmstPerformance.InserttblmstPerformance(tp);

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
public MyCLS.TransportationPacket InserttblmstPerformance(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstPerformance objLIBtblmstPerformance = new LIBtblmstPerformance();
objLIBtblmstPerformance = (LIBtblmstPerformance)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstPerformance.id));
objParamList.Add(new SqlParameter("@orgid", objLIBtblmstPerformance.orgid));
objParamList.Add(new SqlParameter("@LatestPerformance", objLIBtblmstPerformance.LatestPerformance));
objParamList.Add(new SqlParameter("@PerLevel", objLIBtblmstPerformance.PerLevel));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstPerformance", objParamList, objParamListOut, ref Result);
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
