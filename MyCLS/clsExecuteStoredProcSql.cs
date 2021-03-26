using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace MyCLS
{
    #region "Execute using Sql"
    public class clsExecuteStoredProcSql
    {
        SqlConnection m_sqlConnection;

        #region Open Database
        /// <summary>
        /// This is the Internal Function to be invoked from the DBConnection
        /// The purpose of the function 'OpenDatabase' is to open the XML File and have all the values in the class
        /// object through Serialization. This is static function of the class and can be invoked without any instance.
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenDatabase()
        {
            string strConnectionString = "";
            ConnectionInfo objConnectionConfig = new ConnectionInfo();
            SqlConnection objConnection = null;
            try
            {
                
                strConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
                strConnectionString = strConnectionString.Replace("Provider=SQLOLEDB.1", "");

                if (strConnectionString != string.Empty)
                {
                    objConnection = new SqlConnection(strConnectionString);
                    objConnection.Open();
                }
            }
            catch (SqlException exSQL)
            {
                clsHandleException.HandleEx(exSQL, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
                throw new Exception("DataBase Not Connecting...");
            }
            catch (Exception ex)
            {
                clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
                throw new Exception("DataBase Not Connecting...");
            }
            finally
            {
                m_sqlConnection = objConnection;                
            }

            return objConnection;
        }
        #endregion

        #region Close Database
        /// <summary>
        /// This is the Internal Function to be invoked from the DBConnection
        /// The purpose of the function 'CloseDatabase' is to close the existing open connection of the Database. 
        /// It shall automatically check the State of the SQL Connection used and will act accordingly.
        /// This shall return  true / false based on the success of the completion of the tasks.
        /// </summary>
        /// <returns></returns>
        public bool CloseDatabase()
        {
            bool blnReturnValue = true;
            try
            {
                if (m_sqlConnection != null)
                {
                    if (m_sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        m_sqlConnection.Close();
                        m_sqlConnection.Dispose();
                        m_sqlConnection = null;
                    }
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                blnReturnValue = false;
                throw;
            }
            finally
            {
            }
            return blnReturnValue;
        }
        #endregion

        #region Execute Stored Procedures

        #region ExecuteNonQuery
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public int ExecuteSPNonQuery(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                m_intReturnValue = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return m_intReturnValue;
        }

        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public int ExecuteSPNonQueryMultiRowInsert(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.AddWithValue(ParameterList[intLoop].ParameterName, ParameterList[intLoop].Value);
                    }
                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                m_intReturnValue = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return m_intReturnValue;
        }
        #endregion
        public DataSet ExecuteSPDataSetWithoutParameters(string SPName)
        {
            DataSet m_dsReturnValue = new DataSet();
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                m_cmdStoredProcedure.CommandTimeout = 100000;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(m_dsReturnValue);
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                m_dsReturnValue = null;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return m_dsReturnValue;
        }
        #region ExecuteNonQuery OutPut
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public string[] ExecuteSPNonQueryOutPut(string SPName, List<SqlParameter> ParameterList, List<SqlParameter> OutParameterList, ref int m_intReturnValue)
        {
            m_intReturnValue = 0;
            string[] OutParameterArray = new string[OutParameterList.Count];
            SqlCommand m_cmdStoredProcedure = new SqlCommand();
            try
            {
                
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }

                    for (int intLoop = 0; intLoop < OutParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(OutParameterList[intLoop]);
                        OutParameterList[intLoop].Direction = ParameterDirection.Output;
                    }

                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();

                    CloseDatabase();
                    for (int intLoop = 0; intLoop < OutParameterList.Count; intLoop++)
                    {
                        OutParameterArray[intLoop] = m_cmdStoredProcedure.Parameters[OutParameterList[intLoop].ParameterName].Value.ToString();
                    }
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false);
                m_intReturnValue = -1;                
                throw;
            }
            finally
            {
                m_cmdStoredProcedure.Parameters.Clear();
                CloseDatabase();
            }
            return OutParameterArray;
        }

        public int ExecuteSPNonQueryReturnValue(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            int intReturnValues = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter = new SqlParameter("RETURNVALUE", SqlDbType.Int);
                    objReturnParameter.Direction = ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value);

                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                intReturnValues = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return intReturnValues + m_intReturnValue;
        }

        public int ExecuteNonQueryReturnValueWithoutAdd(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            int intReturnValues = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter = new SqlParameter("RETURNVALUE", SqlDbType.Int);
                    objReturnParameter.Direction = ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value); CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                intReturnValues = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return intReturnValues;
        }


        public decimal ExecuteNonQueryDecimal(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            decimal intReturnValues = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter = new SqlParameter("RETURNVALUE", SqlDbType.Decimal);
                    objReturnParameter.Direction = ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToDecimal(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value);

                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                intReturnValues = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return intReturnValues;
        }
        #endregion
        #region ExecuteSPDataSet
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteReader 
        /// or the method of filling up the DataSet.
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public DataSet ExecuteSPDataSet(string SPName, List<SqlParameter> ParameterList)
        {
            DataSet m_dsReturnValue = new DataSet();
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                m_cmdStoredProcedure.CommandTimeout = 100000;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }

                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(m_dsReturnValue);
                    CloseDatabase();                    
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                m_dsReturnValue = null;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return m_dsReturnValue;
        }

        public DataSet ExecuteSPDataSet(string SPName)
        {
            DataSet m_dsReturnValue = new DataSet();
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                m_cmdStoredProcedure.CommandTimeout = 100000;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection.State != ConnectionState.Open)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(m_dsReturnValue);
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                m_dsReturnValue = null;
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                //HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
                throw exObj;
                //clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(),true);
            }
            finally
            {
                CloseDatabase();
            }
            return m_dsReturnValue;
        }
        #endregion
        public DataSet importComboDataFill(string _IdField, string _Desc, string _tableNm, string _whrCon)
        {
            DataSet ds = new DataSet();


            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@IdField", _IdField));
                objParamList.Add(new SqlParameter("@FieldDESC", _Desc));
                objParamList.Add(new SqlParameter("@tableName", _tableNm));
                objParamList.Add(new SqlParameter("@whrCon", _whrCon));
                ds = ExecuteSPDataSet("sp_importComboData", objParamList);

            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        public DataTable ExecQuery(string Qry)
        {
            DataTable dtRec = new DataTable();

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = Qry;
                m_cmdStoredProcedure.CommandType = CommandType.Text;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;

                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(dtRec);
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                dtRec = null;

            }

            return dtRec;
        }
        public DataSet ExecQueryDS(string Qry)
        {
            DataSet dtRec = new DataSet();

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = Qry;
                m_cmdStoredProcedure.CommandType = CommandType.Text;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;

                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(dtRec);
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                dtRec = null;

            }

            return dtRec;
        }
        public int ExecNonQuery(string Qry)
        {
            int m_intReturnValue = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = Qry;
                m_cmdStoredProcedure.CommandType = CommandType.Text;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;

                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery(); ;
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {


            }

            return m_intReturnValue;
        }
        public int DeleteSYData(string AppId, string tableNm)
        {
            DataSet ds = new DataSet();
            int rCount = 0;

            List<SqlParameter> objParamList = new List<SqlParameter>();


            try
            {

                objParamList.Add(new SqlParameter("@tableName", tableNm));
                objParamList.Add(new SqlParameter("@whrCon", AppId));
                rCount = ExecuteSPNonQuery("sp_DeleteTableData", objParamList);

            }
            catch (Exception ex)
            {


            }


            return rCount;

        }
        public int ExecuteSPScalar(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    m_intReturnValue = Convert.ToInt32(m_cmdStoredProcedure.ExecuteScalar());
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
                m_intReturnValue = -1;
                throw;
            }
            finally
            {
                CloseDatabase();
            }
            return m_intReturnValue;
        }

        public DataSet FillData(string whrCon, string strWhereOther, string procedureName)
        {
            DataSet ds = new DataSet();


            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@strWhereOther", strWhereOther));
                objParamList.Add(new SqlParameter("@whrCon", whrCon));
                ds = ExecuteSPDataSet(procedureName, objParamList);

            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        #endregion
    }
    #endregion




    #region ConnectionInfo
    public class ConnectionInfo
    {
        string m_strServerName;
        string m_strPassword;
        string m_strDatabase;
        string m_strUserID;

        public string ServerName
        {
            get
            {
                return m_strServerName;
            }
            set
            {
                m_strServerName = value;
            }

        }

        public string Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value;
            }
        }

        public string Database
        {
            get
            {
                return m_strDatabase;
            }
            set
            {
                m_strDatabase = value;
            }
        }

        public string UserID
        {
            get
            {
                return m_strUserID;
            }
            set
            {
                m_strUserID = value;
            }
        }
    }
    #endregion


    #region XML Related
    public class SerializeXML
    {
        public object ConvertXML(string FilePath, EXMLContextTypes XMLContext, bool Encrypted, string EncryptedString)
        {
            object objSerialClassObject = null;
            XmlSerializer objXMLSerializer = null;
            FileStream objStream = null;
            XmlReader objXMLReader = null;
            try
            {
                switch (XMLContext)
                {
                    case EXMLContextTypes.ClientDBConnection:
                        {
                            objXMLSerializer = new XmlSerializer(typeof(ConnectionInfo));
                            break;
                        }

                    //case EXMLContextTypes.SearchInfo:
                    //    {
                    //        objXMLSerializer = new XmlSerializer(typeof(SearchInfo));
                    //        break;
                    //    }
                    default:
                        break;
                }

                if (objXMLSerializer == null)
                {
                    return objSerialClassObject;
                }

                objStream = new FileStream(FilePath, FileMode.Open);
                objXMLReader = new XmlTextReader(objStream);

                objSerialClassObject = objXMLSerializer.Deserialize(objXMLReader);
            }
            catch (Exception exObj)
            {
                clsHandleException.HandleEx(exObj, System.Reflection.MethodBase.GetCurrentMethod().ToString(), false); ;
            }
            finally
            {
                if (objStream != null)
                {
                    objStream.Close();
                }
                objStream = null;
                if (objXMLReader != null)
                {
                    objXMLReader.Close();
                }
                objXMLReader = null;
            }
            return objSerialClassObject;
        }
    }
    #endregion
}