using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstOrgInfo
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstOrgInfoListing objLIBtblmstOrgInfoListing = new LIBtblmstOrgInfoListing();
//    DALtblmstOrgInfo objDALtblmstOrgInfo = new DALtblmstOrgInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstOrgInfoListing[0].id;
////  txt.Text = objLIBtblmstOrgInfoListing[0].orgid;
////  txt.Text = objLIBtblmstOrgInfoListing[0].year;
////  txt.Text = objLIBtblmstOrgInfoListing[0].turnover;
////  txt.Text = objLIBtblmstOrgInfoListing[0].HeadCount;
////  txt.Text = objLIBtblmstOrgInfoListing[0].Profit;
////  txt.Text = objLIBtblmstOrgInfoListing[0].WageBill;
////  txt.Text = objLIBtblmstOrgInfoListing[0].Attrtion;
////  txt.Text = objLIBtblmstOrgInfoListing[0].createdBy;
////  txt.Text = objLIBtblmstOrgInfoListing[0].dt;
//    tp = objDALtblmstOrgInfo.GettblmstOrgInfoDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstOrgInfoListing = (LIBtblmstOrgInfoListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstOrgInfoListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstOrgInfoDetails()
{
DataSet ds = new DataSet();
LIBtblmstOrgInfoListing objLIBtblmstOrgInfoListing = new LIBtblmstOrgInfoListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstOrgInfo");
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
LIBtblmstOrgInfo oLIBtblmstOrgInfo = new LIBtblmstOrgInfo();
objLIBtblmstOrgInfoListing.Add(oLIBtblmstOrgInfo);
objLIBtblmstOrgInfoListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstOrgInfoListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstOrgInfoListing[i].year = ds.Tables[0].Rows[i]["year"].ToString();
objLIBtblmstOrgInfoListing[i].turnover =(decimal)ds.Tables[0].Rows[i]["turnover"];
objLIBtblmstOrgInfoListing[i].HeadCount =(decimal)ds.Tables[0].Rows[i]["HeadCount"];
objLIBtblmstOrgInfoListing[i].Profit =(decimal)ds.Tables[0].Rows[i]["Profit"];
objLIBtblmstOrgInfoListing[i].WageBill =(decimal)ds.Tables[0].Rows[i]["WageBill"];
objLIBtblmstOrgInfoListing[i].Attrtion =(decimal)ds.Tables[0].Rows[i]["Attrtion"];
objLIBtblmstOrgInfoListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblmstOrgInfoListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstOrgInfoListing;

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
//    LIBtblmstOrgInfoListing objLIBtblmstOrgInfoListing = new LIBtblmstOrgInfoListing();
//    DALtblmstOrgInfo objDALtblmstOrgInfo = new DALtblmstOrgInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstOrgInfoListing[0].id = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].orgid = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].year = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].turnover = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].HeadCount = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].Profit = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].WageBill = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].Attrtion = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].createdBy = "";
////  txt.Text = objLIBtblmstOrgInfoListing[0].dt = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstOrgInfo.GettblmstOrgInfoDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstOrgInfoListing = (LIBtblmstOrgInfoListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstOrgInfoListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstOrgInfoDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstOrgInfoListing objLIBtblmstOrgInfoListing = new LIBtblmstOrgInfoListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstOrgInfoById", objParamList);
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
LIBtblmstOrgInfo oLIBtblmstOrgInfo = new LIBtblmstOrgInfo();

objLIBtblmstOrgInfoListing.Add(oLIBtblmstOrgInfo);
objLIBtblmstOrgInfoListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstOrgInfoListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstOrgInfoListing[i].year = ds.Tables[0].Rows[i]["year"].ToString();
objLIBtblmstOrgInfoListing[i].turnover =(decimal)ds.Tables[0].Rows[i]["turnover"];
objLIBtblmstOrgInfoListing[i].HeadCount =(decimal)ds.Tables[0].Rows[i]["HeadCount"];
objLIBtblmstOrgInfoListing[i].Profit =(decimal)ds.Tables[0].Rows[i]["Profit"];
objLIBtblmstOrgInfoListing[i].WageBill =(decimal)ds.Tables[0].Rows[i]["WageBill"];
objLIBtblmstOrgInfoListing[i].Attrtion =(decimal)ds.Tables[0].Rows[i]["Attrtion"];
objLIBtblmstOrgInfoListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblmstOrgInfoListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstOrgInfoListing;

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
//    LIBtblmstOrgInfo objLIBtblmstOrgInfo = new LIBtblmstOrgInfo();
//    DALtblmstOrgInfo objDALtblmstOrgInfo = new DALtblmstOrgInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstOrgInfo.id = txt.Text;
//    objLIBtblmstOrgInfo.orgid = txt.Text;
//    objLIBtblmstOrgInfo.year = txt.Text;
//    objLIBtblmstOrgInfo.turnover = txt.Text;
//    objLIBtblmstOrgInfo.HeadCount = txt.Text;
//    objLIBtblmstOrgInfo.Profit = txt.Text;
//    objLIBtblmstOrgInfo.WageBill = txt.Text;
//    objLIBtblmstOrgInfo.Attrtion = txt.Text;
//    objLIBtblmstOrgInfo.createdBy = txt.Text;
//    objLIBtblmstOrgInfo.dt = txt.Text;
//    tp.MessagePacket = objLIBtblmstOrgInfo;
//    tp = objDALtblmstOrgInfo.InserttblmstOrgInfo(tp);

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
public MyCLS.TransportationPacket InserttblmstOrgInfo(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstOrgInfo objLIBtblmstOrgInfo = new LIBtblmstOrgInfo();
objLIBtblmstOrgInfo = (LIBtblmstOrgInfo)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstOrgInfo.id));
objParamList.Add(new SqlParameter("@orgid", objLIBtblmstOrgInfo.orgid));
objParamList.Add(new SqlParameter("@year", objLIBtblmstOrgInfo.year));
objParamList.Add(new SqlParameter("@turnover", objLIBtblmstOrgInfo.turnover));
objParamList.Add(new SqlParameter("@HeadCount", objLIBtblmstOrgInfo.HeadCount));
objParamList.Add(new SqlParameter("@Profit", objLIBtblmstOrgInfo.Profit));
objParamList.Add(new SqlParameter("@WageBill", objLIBtblmstOrgInfo.WageBill));
objParamList.Add(new SqlParameter("@Attrtion", objLIBtblmstOrgInfo.Attrtion));
objParamList.Add(new SqlParameter("@createdBy", objLIBtblmstOrgInfo.createdBy));
objParamList.Add(new SqlParameter("@dt", objLIBtblmstOrgInfo.dt));
objParamList.Add(new SqlParameter("@Currency", objLIBtblmstOrgInfo.Currency));
objParamList.Add(new SqlParameter("@industry", objLIBtblmstOrgInfo.Industry));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstOrgInfo", objParamList, objParamListOut, ref Result);
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
