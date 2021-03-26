using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblOrgNatureofBussiness
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblOrgNatureofBussinessListing objLIBtblOrgNatureofBussinessListing = new LIBtblOrgNatureofBussinessListing();
//    DALtblOrgNatureofBussiness objDALtblOrgNatureofBussiness = new DALtblOrgNatureofBussiness();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].id;
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].orgid;
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].natureid;
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].createdBy;
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].dt;
//    tp = objDALtblOrgNatureofBussiness.GettblOrgNatureofBussinessDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblOrgNatureofBussinessListing = (LIBtblOrgNatureofBussinessListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblOrgNatureofBussinessListing[0].ToString());
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
public MyCLS.TransportationPacket GettblOrgNatureofBussinessDetails()
{
DataSet ds = new DataSet();
LIBtblOrgNatureofBussinessListing objLIBtblOrgNatureofBussinessListing = new LIBtblOrgNatureofBussinessListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblOrgNatureofBussiness");
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
LIBtblOrgNatureofBussiness oLIBtblOrgNatureofBussiness = new LIBtblOrgNatureofBussiness();
objLIBtblOrgNatureofBussinessListing.Add(oLIBtblOrgNatureofBussiness);
objLIBtblOrgNatureofBussinessListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblOrgNatureofBussinessListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblOrgNatureofBussinessListing[i].natureid =(int)ds.Tables[0].Rows[i]["natureid"];
objLIBtblOrgNatureofBussinessListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblOrgNatureofBussinessListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblOrgNatureofBussinessListing;

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
//    LIBtblOrgNatureofBussinessListing objLIBtblOrgNatureofBussinessListing = new LIBtblOrgNatureofBussinessListing();
//    DALtblOrgNatureofBussiness objDALtblOrgNatureofBussiness = new DALtblOrgNatureofBussiness();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].id = "";
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].orgid = "";
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].natureid = "";
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].createdBy = "";
////  txt.Text = objLIBtblOrgNatureofBussinessListing[0].dt = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblOrgNatureofBussiness.GettblOrgNatureofBussinessDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblOrgNatureofBussinessListing = (LIBtblOrgNatureofBussinessListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblOrgNatureofBussinessListing[0].ToString());
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
public MyCLS.TransportationPacket GettblOrgNatureofBussinessDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblOrgNatureofBussinessListing objLIBtblOrgNatureofBussinessListing = new LIBtblOrgNatureofBussinessListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblOrgNatureofBussinessById", objParamList);
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
LIBtblOrgNatureofBussiness oLIBtblOrgNatureofBussiness = new LIBtblOrgNatureofBussiness();

objLIBtblOrgNatureofBussinessListing.Add(oLIBtblOrgNatureofBussiness);
objLIBtblOrgNatureofBussinessListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblOrgNatureofBussinessListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblOrgNatureofBussinessListing[i].natureid =(int)ds.Tables[0].Rows[i]["natureid"];
objLIBtblOrgNatureofBussinessListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblOrgNatureofBussinessListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblOrgNatureofBussinessListing;

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
//    LIBtblOrgNatureofBussiness objLIBtblOrgNatureofBussiness = new LIBtblOrgNatureofBussiness();
//    DALtblOrgNatureofBussiness objDALtblOrgNatureofBussiness = new DALtblOrgNatureofBussiness();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblOrgNatureofBussiness.id = txt.Text;
//    objLIBtblOrgNatureofBussiness.orgid = txt.Text;
//    objLIBtblOrgNatureofBussiness.natureid = txt.Text;
//    objLIBtblOrgNatureofBussiness.createdBy = txt.Text;
//    objLIBtblOrgNatureofBussiness.dt = txt.Text;
//    tp.MessagePacket = objLIBtblOrgNatureofBussiness;
//    tp = objDALtblOrgNatureofBussiness.InserttblOrgNatureofBussiness(tp);

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
public MyCLS.TransportationPacket InserttblOrgNatureofBussiness(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblOrgNatureofBussiness objLIBtblOrgNatureofBussiness = new LIBtblOrgNatureofBussiness();
objLIBtblOrgNatureofBussiness = (LIBtblOrgNatureofBussiness)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblOrgNatureofBussiness.id));
objParamList.Add(new SqlParameter("@orgid", objLIBtblOrgNatureofBussiness.orgid));
objParamList.Add(new SqlParameter("@natureid", objLIBtblOrgNatureofBussiness.natureid));
objParamList.Add(new SqlParameter("@createdBy", objLIBtblOrgNatureofBussiness.createdBy));
objParamList.Add(new SqlParameter("@dt", objLIBtblOrgNatureofBussiness.dt));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblOrgNatureofBussiness", objParamList, objParamListOut, ref Result);
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
