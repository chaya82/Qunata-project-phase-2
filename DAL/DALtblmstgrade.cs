using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstgrade
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstgradeListing objLIBtblmstgradeListing = new LIBtblmstgradeListing();
//    DALtblmstgrade objDALtblmstgrade = new DALtblmstgrade();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstgradeListing[0].id;
////  txt.Text = objLIBtblmstgradeListing[0].orgid;
////  txt.Text = objLIBtblmstgradeListing[0].Grade;
////  txt.Text = objLIBtblmstgradeListing[0].GLevel;
//    tp = objDALtblmstgrade.GettblmstgradeDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstgradeListing = (LIBtblmstgradeListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstgradeListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstgradeDetails()
{
DataSet ds = new DataSet();
LIBtblmstgradeListing objLIBtblmstgradeListing = new LIBtblmstgradeListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstgrade");
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
LIBtblmstgrade oLIBtblmstgrade = new LIBtblmstgrade();
objLIBtblmstgradeListing.Add(oLIBtblmstgrade);
objLIBtblmstgradeListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstgradeListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstgradeListing[i].Grade = ds.Tables[0].Rows[i]["Grade"].ToString();
objLIBtblmstgradeListing[i].GLevel =(int)ds.Tables[0].Rows[i]["GLevel"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstgradeListing;

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
//    LIBtblmstgradeListing objLIBtblmstgradeListing = new LIBtblmstgradeListing();
//    DALtblmstgrade objDALtblmstgrade = new DALtblmstgrade();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstgradeListing[0].id = "";
////  txt.Text = objLIBtblmstgradeListing[0].orgid = "";
////  txt.Text = objLIBtblmstgradeListing[0].Grade = "";
////  txt.Text = objLIBtblmstgradeListing[0].GLevel = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstgrade.GettblmstgradeDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstgradeListing = (LIBtblmstgradeListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstgradeListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstgradeDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstgradeListing objLIBtblmstgradeListing = new LIBtblmstgradeListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstgradeById", objParamList);
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
LIBtblmstgrade oLIBtblmstgrade = new LIBtblmstgrade();

objLIBtblmstgradeListing.Add(oLIBtblmstgrade);
objLIBtblmstgradeListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstgradeListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
objLIBtblmstgradeListing[i].Grade = ds.Tables[0].Rows[i]["Grade"].ToString();
objLIBtblmstgradeListing[i].GLevel =(int)ds.Tables[0].Rows[i]["GLevel"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstgradeListing;

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
//    LIBtblmstgrade objLIBtblmstgrade = new LIBtblmstgrade();
//    DALtblmstgrade objDALtblmstgrade = new DALtblmstgrade();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstgrade.id = txt.Text;
//    objLIBtblmstgrade.orgid = txt.Text;
//    objLIBtblmstgrade.Grade = txt.Text;
//    objLIBtblmstgrade.GLevel = txt.Text;
//    tp.MessagePacket = objLIBtblmstgrade;
//    tp = objDALtblmstgrade.Inserttblmstgrade(tp);

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
public MyCLS.TransportationPacket Inserttblmstgrade(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstgrade objLIBtblmstgrade = new LIBtblmstgrade();
objLIBtblmstgrade = (LIBtblmstgrade)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstgrade.id));
objParamList.Add(new SqlParameter("@orgid", objLIBtblmstgrade.orgid));
objParamList.Add(new SqlParameter("@Grade", objLIBtblmstgrade.Grade));
objParamList.Add(new SqlParameter("@GLevel", objLIBtblmstgrade.GLevel));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_Inserttblmstgrade", objParamList, objParamListOut, ref Result);
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
