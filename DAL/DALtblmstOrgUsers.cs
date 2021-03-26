using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstOrgUsers
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstOrgUsersListing objLIBtblmstOrgUsersListing = new LIBtblmstOrgUsersListing();
//    DALtblmstOrgUsers objDALtblmstOrgUsers = new DALtblmstOrgUsers();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstOrgUsersListing[0].id;
////  txt.Text = objLIBtblmstOrgUsersListing[0].Name;
////  txt.Text = objLIBtblmstOrgUsersListing[0].Email;
////  txt.Text = objLIBtblmstOrgUsersListing[0].Phone;
////  txt.Text = objLIBtblmstOrgUsersListing[0].orgid;
//    tp = objDALtblmstOrgUsers.GettblmstOrgUsersDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstOrgUsersListing = (LIBtblmstOrgUsersListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstOrgUsersListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstOrgUsersDetails()
{
DataSet ds = new DataSet();
LIBtblmstOrgUsersListing objLIBtblmstOrgUsersListing = new LIBtblmstOrgUsersListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstOrgUsers");
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
LIBtblmstOrgUsers oLIBtblmstOrgUsers = new LIBtblmstOrgUsers();
objLIBtblmstOrgUsersListing.Add(oLIBtblmstOrgUsers);
objLIBtblmstOrgUsersListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstOrgUsersListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblmstOrgUsersListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblmstOrgUsersListing[i].Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
objLIBtblmstOrgUsersListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstOrgUsersListing;

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
//    LIBtblmstOrgUsersListing objLIBtblmstOrgUsersListing = new LIBtblmstOrgUsersListing();
//    DALtblmstOrgUsers objDALtblmstOrgUsers = new DALtblmstOrgUsers();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstOrgUsersListing[0].id = "";
////  txt.Text = objLIBtblmstOrgUsersListing[0].Name = "";
////  txt.Text = objLIBtblmstOrgUsersListing[0].Email = "";
////  txt.Text = objLIBtblmstOrgUsersListing[0].Phone = "";
////  txt.Text = objLIBtblmstOrgUsersListing[0].orgid = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstOrgUsers.GettblmstOrgUsersDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstOrgUsersListing = (LIBtblmstOrgUsersListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstOrgUsersListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstOrgUsersDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstOrgUsersListing objLIBtblmstOrgUsersListing = new LIBtblmstOrgUsersListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstOrgUsersById", objParamList);
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
LIBtblmstOrgUsers oLIBtblmstOrgUsers = new LIBtblmstOrgUsers();

objLIBtblmstOrgUsersListing.Add(oLIBtblmstOrgUsers);
objLIBtblmstOrgUsersListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstOrgUsersListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblmstOrgUsersListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblmstOrgUsersListing[i].Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
objLIBtblmstOrgUsersListing[i].orgid =(int)ds.Tables[0].Rows[i]["orgid"];
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstOrgUsersListing;

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
//    LIBtblmstOrgUsers objLIBtblmstOrgUsers = new LIBtblmstOrgUsers();
//    DALtblmstOrgUsers objDALtblmstOrgUsers = new DALtblmstOrgUsers();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstOrgUsers.id = txt.Text;
//    objLIBtblmstOrgUsers.Name = txt.Text;
//    objLIBtblmstOrgUsers.Email = txt.Text;
//    objLIBtblmstOrgUsers.Phone = txt.Text;
//    objLIBtblmstOrgUsers.orgid = txt.Text;
//    tp.MessagePacket = objLIBtblmstOrgUsers;
//    tp = objDALtblmstOrgUsers.InserttblmstOrgUsers(tp);

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
public MyCLS.TransportationPacket InserttblmstOrgUsers(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstOrgUsers objLIBtblmstOrgUsers = new LIBtblmstOrgUsers();
objLIBtblmstOrgUsers = (LIBtblmstOrgUsers)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstOrgUsers.id));
objParamList.Add(new SqlParameter("@Name", objLIBtblmstOrgUsers.Name));
objParamList.Add(new SqlParameter("@Email", objLIBtblmstOrgUsers.Email));
objParamList.Add(new SqlParameter("@Phone", objLIBtblmstOrgUsers.Phone));
objParamList.Add(new SqlParameter("@orgid", objLIBtblmstOrgUsers.orgid));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstOrgUsers", objParamList, objParamListOut, ref Result);
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
