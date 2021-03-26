using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstInstruction
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstInstructionListing objLIBtblmstInstructionListing = new LIBtblmstInstructionListing();
//    DALtblmstInstruction objDALtblmstInstruction = new DALtblmstInstruction();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstInstructionListing[0].ID;
////  txt.Text = objLIBtblmstInstructionListing[0].DOb/Age;
////  txt.Text = objLIBtblmstInstructionListing[0].currency;
//    tp = objDALtblmstInstruction.GettblmstInstructionDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstInstructionListing = (LIBtblmstInstructionListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstInstructionListing[0].ToString());
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


//*******COPY IT TO USE BELOW FUNCTION - SELECT BY ID************
//try
//{
//    LIBtblmstInstructionListing objLIBtblmstInstructionListing = new LIBtblmstInstructionListing();
//    DALtblmstInstruction objDALtblmstInstruction = new DALtblmstInstruction();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstInstructionListing[0].ID = "";
////  txt.Text = objLIBtblmstInstructionListing[0].DOb/Age = "";
////  txt.Text = objLIBtblmstInstructionListing[0].currency = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstInstruction.GettblmstInstructionDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstInstructionListing = (LIBtblmstInstructionListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstInstructionListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstInstructionDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstInstructionListing objLIBtblmstInstructionListing = new LIBtblmstInstructionListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstInstructionById", objParamList);
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
LIBtblmstInstruction oLIBtblmstInstruction = new LIBtblmstInstruction();

objLIBtblmstInstructionListing.Add(oLIBtblmstInstruction);
objLIBtblmstInstructionListing[i].ID =(int)ds.Tables[0].Rows[i]["ID"];
objLIBtblmstInstructionListing[i].DOb_Age = ds.Tables[0].Rows[i]["DOb_Age"].ToString();
objLIBtblmstInstructionListing[i].currency = ds.Tables[0].Rows[i]["currency"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstInstructionListing;

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
//    LIBtblmstInstruction objLIBtblmstInstruction = new LIBtblmstInstruction();
//    DALtblmstInstruction objDALtblmstInstruction = new DALtblmstInstruction();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstInstruction.ID = txt.Text;
//    objLIBtblmstInstruction.DOb/Age = txt.Text;
//    objLIBtblmstInstruction.currency = txt.Text;
//    tp.MessagePacket = objLIBtblmstInstruction;
//    tp = objDALtblmstInstruction.InserttblmstInstruction(tp);

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
public MyCLS.TransportationPacket InserttblmstInstruction(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstInstruction objLIBtblmstInstruction = new LIBtblmstInstruction();
objLIBtblmstInstruction = (LIBtblmstInstruction)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@ID", objLIBtblmstInstruction.ID));
objParamList.Add(new SqlParameter("@DOB", objLIBtblmstInstruction.DOb_Age));
objParamList.Add(new SqlParameter("@currency", objLIBtblmstInstruction.currency));
objParamListOut.Add(new SqlParameter("@@ID", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstInstruction", objParamList, objParamListOut, ref Result);
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
