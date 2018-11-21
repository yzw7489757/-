namespace QGYHelper
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using System.Configuration;

    /// <summary>
    /// SQLServer���ݿ�������ࣨ��̬������
    /// </summary>
    public abstract class SKYSQLHelper
    {
        /// <summary>
        /// ����������
        /// </summary>
        public static string connectionString = ConfigurationManager.AppSettings["SKYConnString"];

        #region Command������������ֵ��
        

        #region ����Command�������������洢���̣�

        #region ����Command�������������洢���̣�

        /// <summary>
        /// ����Command�������������洢���̣�
        /// </summary>
        /// <param name="connection">���ݿ�����Ӷ���</param>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <returns></returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }
            return command;
        }
        #endregion

        #region ����Command����������������������int�͵Ĳ���ReturnValue�������洢���̣�

        /// <summary>
        /// ����Command����������������������int�͵Ĳ���ReturnValue�������洢���̣�
        /// </summary>
        /// <param name="connection">���ݿ�����Ӷ���</param>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <returns></returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

        #endregion

        #region Ϊ�ֳɵ�Command��Ӳ�����SQL��䣩

        /// <summary>
        /// ΪCommand��Ӳ�����SQL��䣩
        /// </summary>
        /// <param name="cmd">SqlCommand����</param>
        /// <param name="conn">���ݿ�����Ӷ���</param>
        /// <param name="trans">����</param>
        /// <param name="cmdText">SQL���</param>
        /// <param name="cmdParms">����</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #endregion                

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩 ExecuteSql

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩���޲�������������Ӱ�������

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩���޲�������������Ӱ�������
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns></returns>
        public static int ExecuteSql(string SQLString)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    num2 = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    connection.Close();
                    throw exception;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return num2;
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩���в�������������Ӱ�������
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩���в�������������Ӱ�������
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">����</param>
        /// <returns></returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    num2 = num;
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return num2;
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Text�������ݣ���������Ӱ�������
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Text�������ݣ���������Ӱ�������
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">Text��������</param>
        /// <returns></returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText);
                parameter.Value = content;
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num2 = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num2;
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Text�������ݣ������ؽ�����еĵ�һ�е�һ������
        
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Text�������ݣ������ؽ�����еĵ�һ�е�һ������
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText);
                parameter.Value = content;
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return obj3;
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Image�������ݣ���������Ӱ�������
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩����Image�������ݣ���������Ӱ�������
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="fs">Image��������</param>
        /// <returns></returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                SqlParameter parameter = new SqlParameter("@fs", SqlDbType.Image);
                parameter.Value = fs;
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num2 = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num2;
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ������������SQL��䣩�����õȴ��ӷ���������һ�������ʱ�䣩��������Ӱ�������
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������������SQL��䣩�����õȴ��ӷ���������һ�������ʱ�䣩��������Ӱ�������
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="Times">�ȴ��ӷ���������һ�������ʱ��</param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = Times;
                    num2 = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    connection.Close();
                    throw exception;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return num2;
        }
        #endregion

        #endregion

        #region ����ִ��SQL���ExecuteSqlTran

        #region ����ִ��SQL��䣨SQL�����List<string>�����б��У�
        /// <summary>
        /// ����ִ��SQL��䣨SQL�����List<string>�����б��У�
        /// </summary>
        /// <param name="SQLStringList">List<CommandInfo>�����б�SQL���</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<string> SQLStringList)
        {
            int num3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                SqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    int num = 0;
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string str = SQLStringList[i];
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            num += command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    num3 = num;
                }
                catch
                {
                    transaction.Rollback();
                    num3 = 0;
                }
            }
            return num3;
        }
        #endregion 

        #region ����ִ��SQL��䣨SQL�����Hashtable�б��У�
        /// <summary>
        /// ����ִ��SQL��䣨SQL�����Hashtable�б��У�
        /// </summary>
        /// <param name="SQLStringList">Hashtable�����б�SQL���</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[]) entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion  

        #region ����ִ��SQL��䣨ǰһ�������������������һ�����ĸ�ֵ����SQL�����Hashtable�����б��У�
        
        /// <summary>
        /// ����ִ��SQL��䣨ǰһ�������������������һ�����ĸ�ֵ����SQL�����Hashtable�����б��У�
        /// </summary>
        /// <param name="SQLStringList">Hashtable�����б��SQL���</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[]) entry.Value;
                            foreach (SqlParameter parameter in cmdParms)
                            {
                                if (parameter.Direction == ParameterDirection.InputOutput)
                                {
                                    parameter.Value = num;
                                }
                            }
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            foreach (SqlParameter parameter2 in cmdParms)
                            {
                                if (parameter2.Direction == ParameterDirection.Output)
                                {
                                    num = Convert.ToInt32(parameter2.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region ִ����ӡ��޸ġ�ɾ���������洢���̣�
        
        #region ִ����ӡ��޸ġ�ɾ���������洢���̣�

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ���������洢���̣�
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                return command.ExecuteNonQuery();
            }
        }
        #endregion

        #region ִ����ӡ��޸ġ�ɾ���������洢���̣�������ReturnValueֵ
        
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ���������洢���̣�������ReturnValueֵ
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <param name="rowsAffected">������Ӱ������</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                return (int)command.Parameters["ReturnValue"].Value;
            }
        }
        #endregion

        #endregion

        #region �Ƿ���ڼ�¼

        #region �Ƿ���ڼ�¼���޲�����
        
        /// <summary>
        /// �Ƿ���ڼ�¼���޲�����
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            int num;
            object single = GetSingle(strSql);
            if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region �Ƿ���ڼ�¼���в�����
        /// <summary>
        /// �Ƿ���ڼ�¼���в�����
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <param name="cmdParms">����</param>
        /// <returns></returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            int num;
            object single = GetSingle(strSql, cmdParms);
            if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region ��ñ���int�����ֶΣ��Զ�����+1����ֵ
        
        /// <summary>
        /// ��ñ���int�����ֶΣ��Զ�����+1����ֵ
        /// </summary>
        /// <param name="FieldName">int�����ֶ�</param>
        /// <param name="TableName">����</param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            object single = GetSingle("select max(" + FieldName + ")+1 from " + TableName);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
        }
        #endregion

        #region ��ò�ѯ����ĵ�һ�е�һ�е�ֵ

        #region ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���޲�����
        
        /// <summary>
        /// ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���޲�����
        /// </summary>
        /// <param name="SQLString">SQL��ѯ���</param>
        /// <returns></returns>
        public static object GetSingle(string SQLString)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception)
                {
                    connection.Close();
                    throw exception;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return obj3;
        }
        #endregion

        #region ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���в�����
        
        /// <summary>
        /// ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���в�����
        /// </summary>
        /// <param name="SQLString">SQL��ѯ���</param>
        /// <param name="cmdParms">����</param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object objA = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return obj3;
        }

        #endregion

        #region ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���޲��������õȴ��ӷ���������һ�������ʱ�䣩
        
        /// <summary>
        /// ��ò�ѯ����ĵ�һ�е�һ�е�ֵ���޲��������õȴ��ӷ���������һ�������ʱ�䣩
        /// </summary>
        /// <param name="SQLString">SQL��ѯ���</param>
        /// <param name="Times">�ȴ��ӷ���������һ�������ʱ��</param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, int Times)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = Times;
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception)
                {
                    connection.Close();
                    throw exception;
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return obj3;
        }
        #endregion

        #endregion

        #region �Ƿ����ĳ��

        /// <summary>
        /// �Ƿ����ĳ��
        /// </summary>
        /// <param name="TableName">����</param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            int num;
            object single = GetSingle("select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1");
            if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region �жϱ���ĳ�ֶ��Ƿ����

        /// <summary>
        /// �жϱ���ĳ�ֶ��Ƿ����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="columnName">�ֶ���</param>
        /// <returns></returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            object single = GetSingle("select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'");
            if (single == null)
            {
                return false;
            }
            return (Convert.ToInt32(single) > 0);
        }
        #endregion


        #region ��������б�

        #region ���DataSet�����б�


        #region ���DataSet�����б�SQL��䣩

        /// <summary>
        /// ���DataSet�����б�SQL��䣩
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns></returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    
                    new SqlDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }
        #endregion

        #region ���DataSet�����б��в�������SQL��䣩
        /// <summary>
        /// ���DataSet�����б��в�������SQL��䣩
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">����</param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            DataSet set2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(); 
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }
        #endregion

        #region ���DataSet�����б����õȴ��ӷ���������һ�������ʱ�䣩��SQL��䣩
        /// <summary>
        /// ���DataSet�����б����õȴ��ӷ���������һ�������ʱ�䣩��SQL��䣩
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="Times">���õȴ��ӷ���������һ�������ʱ��</param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(SQLString, connection);
                    adapter.SelectCommand.CommandTimeout = Times;
                    adapter.Fill(dataSet, "ds");
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }
        #endregion



        #region ���DataSet�����б��洢���̣�

        /// <summary>
        /// ���DataSet�����б��洢���̣�
        /// </summary>
        /// <param name="storedProcName">�洢��������</param> 
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(connection, storedProcName, (IDataParameter[])null);
                adapter.Fill(dataSet, "a");
                connection.Close();
                return dataSet;
            }
        }
        #endregion

        #region ���DataSet�����б��洢���̣�

        /// <summary>
        /// ���DataSet�����б��洢���̣�
        /// </summary>
        /// <param name="storedProcName">�洢��������</param> 
        /// <param name="tableName">���ر���</param>
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(connection, storedProcName, (IDataParameter[])null);
                adapter.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        #endregion

        #region ���DataSet�����б��洢���̣�
        
        /// <summary>
        /// ���DataSet�����б��洢���̣�
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <param name="tableName">���ر���</param>
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                adapter.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        #endregion

        #region ���DataSet�����б��洢���̣������õȴ��ӷ���������һ�������ʱ�䣩
        
        /// <summary>
        /// ���DataSet�����б��洢���̣������õȴ��ӷ���������һ�������ʱ�䣩
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <param name="tableName">���ر���</param>
        /// <param name="Times">���õȴ��ӷ���������һ�������ʱ��</param>
        /// <returns></returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                adapter.SelectCommand.CommandTimeout = Times;
                adapter.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        #endregion

        #endregion

        #region ���SqlDataReader�����б�SQL��䣩
        
        /// <summary>
        /// ���SqlDataReader�����б�SQL��䣩
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlDataReader reader2;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader2 = command.ExecuteReader();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return reader2;
        }
        #endregion

        #region ���SqlDataReader�����б��в�������SQL��䣩

        /// <summary>
        ///  ���SqlDataReader�����б��в�������SQL��䣩
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">����</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlDataReader reader2;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                reader2 = reader;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return reader2;
        }
        #endregion

        #region ���SqlDataReader�����б��в��������洢���̣�
        
        /// <summary>
        /// ���SqlDataReader�����б��в��������洢���̣�
        /// </summary>
        /// <param name="storedProcName">�洢��������</param>
        /// <param name="parameters">����</param>
        /// <returns></returns>
        public static SqlDataReader RunProcedureReader(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteReader();
            }
        }
        #endregion


        #endregion

        #region �޸�״̬

        /// <summary>
        /// �޸�״̬
        /// </summary>
        /// <param name="table_name">����</param>
        /// <param name="filed_id">��¼ID�ֶ�����</param>
        /// <param name="filed_status">��¼״̬�ֶ�����</param>
        /// <param name="id">IDֵ</param>
        /// <param name="status">״ֵ̬</param>
        /// <returns></returns>
        public static bool UpdateStatus(string table_name, string filed_id, string filed_status, int id, int status)
        {

            System.Text.StringBuilder strSql = new System.Text.StringBuilder();
            strSql.Append("update " + table_name + " set " + filed_status + "=@" + filed_status + "");
            strSql.Append(" where " + filed_id + "=@" + filed_id + "");
            SqlParameter[] parameters = {
					new SqlParameter("@"+filed_id+"", SqlDbType.Int,4),
					new SqlParameter("@"+filed_status+"", SqlDbType.Int,4)
};
            parameters[0].Value = id;
            parameters[1].Value = status;

            int rows = ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
