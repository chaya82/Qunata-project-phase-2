using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstContact
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstContactListing objLIBtblmstContactListing = new LIBtblmstContactListing();
//    DALtblmstContact objDALtblmstContact = new DALtblmstContact();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstContactListing[0].id;
////  txt.Text = objLIBtblmstContactListing[0].Name;
////  txt.Text = objLIBtblmstContactListing[0].Email;
////  txt.Text = objLIBtblmstContactListing[0].phone;
////  txt.Text = objLIBtblmstContactListing[0].designation;
////  txt.Text = objLIBtblmstContactListing[0].OrgName;
////  txt.Text = objLIBtblmstContactListing[0].dt;
//    tp = objDALtblmstContact.GettblmstContactDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstContactListing = (LIBtblmstContactListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstContactListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstContactDetails()
{
DataSet ds = new DataSet();
LIBtblmstContactListing objLIBtblmstContactListing = new LIBtblmstContactListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstContact");
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
LIBtblmstContact oLIBtblmstContact = new LIBtblmstContact();
objLIBtblmstContactListing.Add(oLIBtblmstContact);
objLIBtblmstContactListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstContactListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblmstContactListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblmstContactListing[i].phone = ds.Tables[0].Rows[i]["phone"].ToString();
objLIBtblmstContactListing[i].designation = ds.Tables[0].Rows[i]["designation"].ToString();
objLIBtblmstContactListing[i].OrgName = ds.Tables[0].Rows[i]["OrgName"].ToString();
objLIBtblmstContactListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstContactListing;

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
//    LIBtblmstContactListing objLIBtblmstContactListing = new LIBtblmstContactListing();
//    DALtblmstContact objDALtblmstContact = new DALtblmstContact();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstContactListing[0].id = "";
////  txt.Text = objLIBtblmstContactListing[0].Name = "";
////  txt.Text = objLIBtblmstContactListing[0].Email = "";
////  txt.Text = objLIBtblmstContactListing[0].phone = "";
////  txt.Text = objLIBtblmstContactListing[0].designation = "";
////  txt.Text = objLIBtblmstContactListing[0].OrgName = "";
////  txt.Text = objLIBtblmstContactListing[0].dt = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstContact.GettblmstContactDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstContactListing = (LIBtblmstContactListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstContactListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstContactDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstContactListing objLIBtblmstContactListing = new LIBtblmstContactListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstContactById", objParamList);
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
LIBtblmstContact oLIBtblmstContact = new LIBtblmstContact();

objLIBtblmstContactListing.Add(oLIBtblmstContact);
objLIBtblmstContactListing[i].id =(int)ds.Tables[0].Rows[i]["id"];
objLIBtblmstContactListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
objLIBtblmstContactListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
objLIBtblmstContactListing[i].phone = ds.Tables[0].Rows[i]["phone"].ToString();
objLIBtblmstContactListing[i].designation = ds.Tables[0].Rows[i]["designation"].ToString();
objLIBtblmstContactListing[i].OrgName = ds.Tables[0].Rows[i]["OrgName"].ToString();
objLIBtblmstContactListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstContactListing;

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
//    LIBtblmstContact objLIBtblmstContact = new LIBtblmstContact();
//    DALtblmstContact objDALtblmstContact = new DALtblmstContact();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstContact.id = txt.Text;
//    objLIBtblmstContact.Name = txt.Text;
//    objLIBtblmstContact.Email = txt.Text;
//    objLIBtblmstContact.phone = txt.Text;
//    objLIBtblmstContact.designation = txt.Text;
//    objLIBtblmstContact.OrgName = txt.Text;
//    objLIBtblmstContact.dt = txt.Text;
//    tp.MessagePacket = objLIBtblmstContact;
//    tp = objDALtblmstContact.InserttblmstContact(tp);

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
public MyCLS.TransportationPacket InserttblmstContact(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstContact objLIBtblmstContact = new LIBtblmstContact();
objLIBtblmstContact = (LIBtblmstContact)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@id", objLIBtblmstContact.id));
objParamList.Add(new SqlParameter("@Name", objLIBtblmstContact.Name));
objParamList.Add(new SqlParameter("@Email", objLIBtblmstContact.Email));
objParamList.Add(new SqlParameter("@phone", objLIBtblmstContact.phone));
objParamList.Add(new SqlParameter("@designation", objLIBtblmstContact.designation));
objParamList.Add(new SqlParameter("@OrgName", objLIBtblmstContact.OrgName));
objParamList.Add(new SqlParameter("@INTREST", objLIBtblmstContact.INTREST));
objParamList.Add(new SqlParameter("@dt", objLIBtblmstContact.dt));
objParamListOut.Add(new SqlParameter("@@id", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstContact", objParamList, objParamListOut, ref Result);
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
