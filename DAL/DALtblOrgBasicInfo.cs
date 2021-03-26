using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblOrgBasicInfo
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblOrgBasicInfoListing objLIBtblOrgBasicInfoListing = new LIBtblOrgBasicInfoListing();
//    DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblOrgBasicInfoListing[0].id;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].username;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].Name;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].Email;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].phone;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].designation;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].OrgName;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].industry;
////  txt.Text = objLIBtblOrgBasicInfoListing[0].dt;
//    tp = objDALtblOrgBasicInfo.GettblOrgBasicInfoDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblOrgBasicInfoListing = (LIBtblOrgBasicInfoListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblOrgBasicInfoListing[0].ToString());
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
public MyCLS.TransportationPacket GettblOrgBasicInfoDetails()
{
DataSet ds = new DataSet();
LIBtblOrgBasicInfoListing objLIBtblOrgBasicInfoListing = new LIBtblOrgBasicInfoListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblOrgBasicInfo");
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
LIBtblOrgBasicInfo oLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
objLIBtblOrgBasicInfoListing.Add(oLIBtblOrgBasicInfo);
objLIBtblOrgBasicInfoListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblOrgBasicInfoListing[i].username = ds.Tables[0].Rows[i]["username"].ToString();
objLIBtblOrgBasicInfoListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblOrgBasicInfoListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblOrgBasicInfoListing[i].phone = ds.Tables[0].Rows[i]["phone"].ToString();
objLIBtblOrgBasicInfoListing[i].designation = ds.Tables[0].Rows[i]["designation"].ToString();
objLIBtblOrgBasicInfoListing[i].OrgName = ds.Tables[0].Rows[i]["OrgName"].ToString();
objLIBtblOrgBasicInfoListing[i].industry = ds.Tables[0].Rows[i]["industry"].ToString();
objLIBtblOrgBasicInfoListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblOrgBasicInfoListing;

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
//    LIBtblOrgBasicInfoListing objLIBtblOrgBasicInfoListing = new LIBtblOrgBasicInfoListing();
//    DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblOrgBasicInfoListing[0].id = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].username = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].Name = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].Email = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].phone = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].designation = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].OrgName = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].industry = "";
////  txt.Text = objLIBtblOrgBasicInfoListing[0].dt = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblOrgBasicInfo.GettblOrgBasicInfoDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblOrgBasicInfoListing = (LIBtblOrgBasicInfoListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblOrgBasicInfoListing[0].ToString());
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
public MyCLS.TransportationPacket GettblOrgBasicInfoDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblOrgBasicInfoListing objLIBtblOrgBasicInfoListing = new LIBtblOrgBasicInfoListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblOrgBasicInfoById", objParamList);
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
LIBtblOrgBasicInfo oLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();

objLIBtblOrgBasicInfoListing.Add(oLIBtblOrgBasicInfo);
objLIBtblOrgBasicInfoListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblOrgBasicInfoListing[i].username = ds.Tables[0].Rows[i]["username"].ToString();
objLIBtblOrgBasicInfoListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblOrgBasicInfoListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblOrgBasicInfoListing[i].phone = ds.Tables[0].Rows[i]["phone"].ToString();
objLIBtblOrgBasicInfoListing[i].designation = ds.Tables[0].Rows[i]["designation"].ToString();
objLIBtblOrgBasicInfoListing[i].OrgName = ds.Tables[0].Rows[i]["OrgName"].ToString();
objLIBtblOrgBasicInfoListing[i].industry = ds.Tables[0].Rows[i]["industry"].ToString();
objLIBtblOrgBasicInfoListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblOrgBasicInfoListing;

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
//    LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
//    DALtblOrgBasicInfo objDALtblOrgBasicInfo = new DALtblOrgBasicInfo();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblOrgBasicInfo.id = txt.Text;
//    objLIBtblOrgBasicInfo.username = txt.Text;
//    objLIBtblOrgBasicInfo.Name = txt.Text;
//    objLIBtblOrgBasicInfo.Email = txt.Text;
//    objLIBtblOrgBasicInfo.phone = txt.Text;
//    objLIBtblOrgBasicInfo.designation = txt.Text;
//    objLIBtblOrgBasicInfo.OrgName = txt.Text;
//    objLIBtblOrgBasicInfo.industry = txt.Text;
//    objLIBtblOrgBasicInfo.dt = txt.Text;
//    tp.MessagePacket = objLIBtblOrgBasicInfo;
//    tp = objDALtblOrgBasicInfo.InserttblOrgBasicInfo(tp);

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
public MyCLS.TransportationPacket InserttblOrgBasicInfo(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblOrgBasicInfo objLIBtblOrgBasicInfo = new LIBtblOrgBasicInfo();
objLIBtblOrgBasicInfo = (LIBtblOrgBasicInfo)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblOrgBasicInfo.id));
objParamList.Add(new SqlParameter("@username", objLIBtblOrgBasicInfo.username));
objParamList.Add(new SqlParameter("@Name", objLIBtblOrgBasicInfo.Name));
objParamList.Add(new SqlParameter("@Email", objLIBtblOrgBasicInfo.Email));
objParamList.Add(new SqlParameter("@phone", objLIBtblOrgBasicInfo.phone));
objParamList.Add(new SqlParameter("@designation", objLIBtblOrgBasicInfo.designation));
objParamList.Add(new SqlParameter("@OrgName", objLIBtblOrgBasicInfo.OrgName));
objParamList.Add(new SqlParameter("@industry", objLIBtblOrgBasicInfo.industry));
objParamList.Add(new SqlParameter("@dt", objLIBtblOrgBasicInfo.dt));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblOrgBasicInfo", objParamList, objParamListOut, ref Result);
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
