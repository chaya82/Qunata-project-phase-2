using NDS.LIB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyCLS;

namespace NDS.DAL
{
public class DALtblmstEmployee
{
//PUT IT IN LOAD EVENTS

//MyCLS.strConnStringOLEDB = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;Provider=SQLOLEDB.1";
//MyCLS.strConnStringSQLCLIENT = "Initial Catalog=AB;Data Source=127.0.0.1;UID=sa;PWD=sa123;";

//*******COPY IT TO USE BELOW FUNCTION - SELECT ALL************
//try
//{
//    LIBtblmstEmployeeListing objLIBtblmstEmployeeListing = new LIBtblmstEmployeeListing();
//    DALtblmstEmployee objDALtblmstEmployee = new DALtblmstEmployee();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstEmployeeListing[0].ID;
////  txt.Text = objLIBtblmstEmployeeListing[0].EmpID;
////  txt.Text = objLIBtblmstEmployeeListing[0].DOb;
////  txt.Text = objLIBtblmstEmployeeListing[0].Age;
////  txt.Text = objLIBtblmstEmployeeListing[0].DOJ;
////  txt.Text = objLIBtblmstEmployeeListing[0].Gender;
////  txt.Text = objLIBtblmstEmployeeListing[0].Dept;
////  txt.Text = objLIBtblmstEmployeeListing[0].Desig;
////  txt.Text = objLIBtblmstEmployeeListing[0].Grade;
////  txt.Text = objLIBtblmstEmployeeListing[0].Managerid;
////  txt.Text = objLIBtblmstEmployeeListing[0].LatestPerformance;
////  txt.Text = objLIBtblmstEmployeeListing[0].LastPromotion;
////  txt.Text = objLIBtblmstEmployeeListing[0].Grosspay;
////  txt.Text = objLIBtblmstEmployeeListing[0].currency;
////  txt.Text = objLIBtblmstEmployeeListing[0].createdBy;
////  txt.Text = objLIBtblmstEmployeeListing[0].dt;
////  txt.Text = objLIBtblmstEmployeeListing[0].fYear;
//    tp = objDALtblmstEmployee.GettblmstEmployeeDetails();
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstEmployeeListing = (LIBtblmstEmployeeListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstEmployeeListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstEmployeeDetails()
{
DataSet ds = new DataSet();
LIBtblmstEmployeeListing objLIBtblmstEmployeeListing = new LIBtblmstEmployeeListing();

MyCLS.TransportationPacket Packet = new MyCLS.TransportationPacket();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstEmployee");
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
LIBtblmstEmployee oLIBtblmstEmployee = new LIBtblmstEmployee();
objLIBtblmstEmployeeListing.Add(oLIBtblmstEmployee);
objLIBtblmstEmployeeListing[i].ID =(int)ds.Tables[0].Rows[i]["ID"];
objLIBtblmstEmployeeListing[i].EmpID = ds.Tables[0].Rows[i]["EmpID"].ToString();
objLIBtblmstEmployeeListing[i].DOb = ds.Tables[0].Rows[i]["DOb"].ToString();
objLIBtblmstEmployeeListing[i].Age =(int)ds.Tables[0].Rows[i]["Age"];
objLIBtblmstEmployeeListing[i].DOJ = ds.Tables[0].Rows[i]["DOJ"].ToString();
objLIBtblmstEmployeeListing[i].Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
objLIBtblmstEmployeeListing[i].Dept = ds.Tables[0].Rows[i]["Dept"].ToString();
objLIBtblmstEmployeeListing[i].Desig = ds.Tables[0].Rows[i]["Desig"].ToString();
objLIBtblmstEmployeeListing[i].Grade = ds.Tables[0].Rows[i]["Grade"].ToString();
objLIBtblmstEmployeeListing[i].Managerid = ds.Tables[0].Rows[i]["Managerid"].ToString();
objLIBtblmstEmployeeListing[i].LatestPerformance = ds.Tables[0].Rows[i]["LatestPerformance"].ToString();
objLIBtblmstEmployeeListing[i].LastPromotion = ds.Tables[0].Rows[i]["LastPromotion"].ToString();
objLIBtblmstEmployeeListing[i].Grosspay =(decimal)ds.Tables[0].Rows[i]["Grosspay"];
objLIBtblmstEmployeeListing[i].currency = ds.Tables[0].Rows[i]["currency"].ToString();
objLIBtblmstEmployeeListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblmstEmployeeListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
objLIBtblmstEmployeeListing[i].fYear = ds.Tables[0].Rows[i]["fYear"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstEmployeeListing;

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
//    LIBtblmstEmployeeListing objLIBtblmstEmployeeListing = new LIBtblmstEmployeeListing();
//    DALtblmstEmployee objDALtblmstEmployee = new DALtblmstEmployee();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
//    DataSet ds = new DataSet();

////  txt.Text = objLIBtblmstEmployeeListing[0].ID = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].EmpID = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].DOb = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Age = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].DOJ = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Gender = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Dept = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Desig = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Grade = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Managerid = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].LatestPerformance = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].LastPromotion = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].Grosspay = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].currency = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].createdBy = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].dt = "";
////  txt.Text = objLIBtblmstEmployeeListing[0].fYear = "";
//    tp.MessagePacket = 1;    //ID to be Passed

//    tp = objDALtblmstEmployee.GettblmstEmployeeDetails(tp);
//    if(tp.MessageId == 1)
//{
//        objLIBtblmstEmployeeListing = (LIBtblmstEmployeeListing)tp.MessageResultset;
//        ds = (DataSet)tp.MessageResultsetDS;
//        MessageBox.Show(objLIBtblmstEmployeeListing[0].ToString());
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
public MyCLS.TransportationPacket GettblmstEmployeeDetails(MyCLS.TransportationPacket Packet)
{
DataSet ds = new DataSet();
List<SqlParameter> objParamList = new List<SqlParameter>();
LIBtblmstEmployeeListing objLIBtblmstEmployeeListing = new LIBtblmstEmployeeListing();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();

try
{
objParamList.Add(new SqlParameter("@Id", Packet.MessagePacket));
ds = clsESPSql.ExecuteSPDataSet("SP_GetDetailsFromtblmstEmployeeById", objParamList);
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
LIBtblmstEmployee oLIBtblmstEmployee = new LIBtblmstEmployee();

objLIBtblmstEmployeeListing.Add(oLIBtblmstEmployee);
objLIBtblmstEmployeeListing[i].ID =(int)ds.Tables[0].Rows[i]["ID"];
objLIBtblmstEmployeeListing[i].EmpID = ds.Tables[0].Rows[i]["EmpID"].ToString();
objLIBtblmstEmployeeListing[i].DOb = ds.Tables[0].Rows[i]["DOb"].ToString();
objLIBtblmstEmployeeListing[i].Age =(int)ds.Tables[0].Rows[i]["Age"];
objLIBtblmstEmployeeListing[i].DOJ = ds.Tables[0].Rows[i]["DOJ"].ToString();
objLIBtblmstEmployeeListing[i].Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
objLIBtblmstEmployeeListing[i].Dept = ds.Tables[0].Rows[i]["Dept"].ToString();
objLIBtblmstEmployeeListing[i].Desig = ds.Tables[0].Rows[i]["Desig"].ToString();
objLIBtblmstEmployeeListing[i].Grade = ds.Tables[0].Rows[i]["Grade"].ToString();
objLIBtblmstEmployeeListing[i].Managerid = ds.Tables[0].Rows[i]["Managerid"].ToString();
objLIBtblmstEmployeeListing[i].LatestPerformance = ds.Tables[0].Rows[i]["LatestPerformance"].ToString();
objLIBtblmstEmployeeListing[i].LastPromotion = ds.Tables[0].Rows[i]["LastPromotion"].ToString();
objLIBtblmstEmployeeListing[i].Grosspay =(decimal)ds.Tables[0].Rows[i]["Grosspay"];
objLIBtblmstEmployeeListing[i].currency = ds.Tables[0].Rows[i]["currency"].ToString();
objLIBtblmstEmployeeListing[i].createdBy = ds.Tables[0].Rows[i]["createdBy"].ToString();
objLIBtblmstEmployeeListing[i].dt = ds.Tables[0].Rows[i]["dt"].ToString();
objLIBtblmstEmployeeListing[i].fYear = ds.Tables[0].Rows[i]["fYear"].ToString();
}
Packet.MessageId = 1;
}
else
Packet.MessageId = -1;
}
}
}

Packet.MessageResultsetDS = ds;
Packet.MessageResultset = objLIBtblmstEmployeeListing;

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
//    LIBtblmstEmployee objLIBtblmstEmployee = new LIBtblmstEmployee();
//    DALtblmstEmployee objDALtblmstEmployee = new DALtblmstEmployee();
//    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

//    objLIBtblmstEmployee.ID = txt.Text;
//    objLIBtblmstEmployee.EmpID = txt.Text;
//    objLIBtblmstEmployee.DOb = txt.Text;
//    objLIBtblmstEmployee.Age = txt.Text;
//    objLIBtblmstEmployee.DOJ = txt.Text;
//    objLIBtblmstEmployee.Gender = txt.Text;
//    objLIBtblmstEmployee.Dept = txt.Text;
//    objLIBtblmstEmployee.Desig = txt.Text;
//    objLIBtblmstEmployee.Grade = txt.Text;
//    objLIBtblmstEmployee.Managerid = txt.Text;
//    objLIBtblmstEmployee.LatestPerformance = txt.Text;
//    objLIBtblmstEmployee.LastPromotion = txt.Text;
//    objLIBtblmstEmployee.Grosspay = txt.Text;
//    objLIBtblmstEmployee.currency = txt.Text;
//    objLIBtblmstEmployee.createdBy = txt.Text;
//    objLIBtblmstEmployee.dt = txt.Text;
//    objLIBtblmstEmployee.fYear = txt.Text;
//    tp.MessagePacket = objLIBtblmstEmployee;
//    tp = objDALtblmstEmployee.InserttblmstEmployee(tp);

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
public MyCLS.TransportationPacket InserttblmstEmployee(MyCLS.TransportationPacket Packet)
{
String[] strOutParamValues = new String[10];
List<SqlParameter> objParamList = new List<SqlParameter>();
List<SqlParameter> objParamListOut = new List<SqlParameter>();
MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
int Result=0;
try
{
LIBtblmstEmployee objLIBtblmstEmployee = new LIBtblmstEmployee();
objLIBtblmstEmployee = (LIBtblmstEmployee)Packet.MessagePacket;

objParamList.Add(new SqlParameter("@ID", objLIBtblmstEmployee.ID));
objParamList.Add(new SqlParameter("@EmpID", objLIBtblmstEmployee.EmpID));
objParamList.Add(new SqlParameter("@DOb", objLIBtblmstEmployee.DOb));
objParamList.Add(new SqlParameter("@Age", objLIBtblmstEmployee.Age));
objParamList.Add(new SqlParameter("@DOJ", objLIBtblmstEmployee.DOJ));
objParamList.Add(new SqlParameter("@Gender", objLIBtblmstEmployee.Gender));
objParamList.Add(new SqlParameter("@Dept", objLIBtblmstEmployee.Dept));
objParamList.Add(new SqlParameter("@Desig", objLIBtblmstEmployee.Desig));
objParamList.Add(new SqlParameter("@Grade", objLIBtblmstEmployee.Grade));
objParamList.Add(new SqlParameter("@Managerid", objLIBtblmstEmployee.Managerid));
objParamList.Add(new SqlParameter("@LatestPerformance", objLIBtblmstEmployee.LatestPerformance));
objParamList.Add(new SqlParameter("@LastPromotion", objLIBtblmstEmployee.LastPromotion));
objParamList.Add(new SqlParameter("@Grosspay", objLIBtblmstEmployee.Grosspay));
objParamList.Add(new SqlParameter("@currency", objLIBtblmstEmployee.currency));
objParamList.Add(new SqlParameter("@createdBy", objLIBtblmstEmployee.createdBy));
objParamList.Add(new SqlParameter("@dt", objLIBtblmstEmployee.dt));
objParamList.Add(new SqlParameter("@fYear", objLIBtblmstEmployee.fYear));
objParamList.Add(new SqlParameter("@orgid", objLIBtblmstEmployee.OrgID));
objParamList.Add(new SqlParameter("@status", objLIBtblmstEmployee.Status));
objParamListOut.Add(new SqlParameter("@@ID", SqlDbType.Int));
strOutParamValues = clsESPSql.ExecuteSPNonQueryOutPut("SP_InserttblmstEmployee", objParamList, objParamListOut, ref Result);
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
