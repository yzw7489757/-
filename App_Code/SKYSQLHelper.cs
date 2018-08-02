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
    /// SQLServer数据库操作基类（静态方法）
    /// </summary>
    public abstract class SKYSQLHelper
    {
        /// <summary>
        /// 连接字条串
        /// </summary>
        public static string connectionString = ConfigurationManager.AppSettings["SKYConnString"];

        #region Command操作（创建或赋值）
        

        #region 创建Command，并赋参数（存储过程）

        #region 创建Command，并赋参数（存储过程）

        /// <summary>
        /// 创建Command，并赋参数（存储过程）
        /// </summary>
        /// <param name="connection">数据库的连接对象</param>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
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

        #region 创建Command，并赋参数（新增“返回int型的参数ReturnValue”）（存储过程）

        /// <summary>
        /// 创建Command，并赋参数（新增“返回int型的参数ReturnValue”）（存储过程）
        /// </summary>
        /// <param name="connection">数据库的连接对象</param>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

        #endregion

        #region 为现成的Command添加参数（SQL语句）

        /// <summary>
        /// 为Command添加参数（SQL语句）
        /// </summary>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="conn">数据库的连接对象</param>
        /// <param name="trans">事务</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 执行添加、修改、删除操作（单条SQL语句） ExecuteSql

        #region 执行添加、修改、删除操作（单条SQL语句）（无参数），返回受影响的行数

        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（无参数），返回受影响的行数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
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

        #region 执行添加、修改、删除操作（单条SQL语句）（有参数），返回受影响的行数
        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（有参数），返回受影响的行数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 执行添加、修改、删除操作（单条SQL语句）（有Text类型数据），返回受影响的行数
        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（有Text类型数据），返回受影响的行数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">Text类型数据</param>
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

        #region 执行添加、修改、删除操作（单条SQL语句）（有Text类型数据），返回结果集中的第一行第一列数据
        
        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（有Text类型数据），返回结果集中的第一行第一列数据
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

        #region 执行添加、修改、删除操作（单条SQL语句）（有Image类型数据），返回受影响的行数
        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（有Image类型数据），返回受影响的行数
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">Image类型数据</param>
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

        #region 执行添加、修改、删除操作（单条SQL语句）（设置等待从服务器返回一个命令的时间），返回受影响的行数
        /// <summary>
        /// 执行添加、修改、删除操作（单条SQL语句）（设置等待从服务器返回一个命令的时间），返回受影响的行数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Times">等待从服务器返回一个命令的时间</param>
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

        #region 批量执行SQL语句ExecuteSqlTran

        #region 批量执行SQL语句（SQL语句在List<string>类型列表中）
        /// <summary>
        /// 批量执行SQL语句（SQL语句在List<string>类型列表中）
        /// </summary>
        /// <param name="SQLStringList">List<CommandInfo>类型列表SQL语句</param>
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

        #region 批量执行SQL语句（SQL语句在Hashtable列表中）
        /// <summary>
        /// 批量执行SQL语句（SQL语句在Hashtable列表中）
        /// </summary>
        /// <param name="SQLStringList">Hashtable类型列表SQL语句</param>
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

        #region 批量执行SQL语句（前一语句的自增主键，任务后一条语句的父值）（SQL语句在Hashtable类型列表中）
        
        /// <summary>
        /// 批量执行SQL语句（前一语句的自增主键，任务后一条语句的父值）（SQL语句在Hashtable类型列表中）
        /// </summary>
        /// <param name="SQLStringList">Hashtable类型列表的SQL语句</param>
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

        #region 执行添加、修改、删除操作（存储过程）
        
        #region 执行添加、修改、删除操作（存储过程）

        /// <summary>
        /// 执行添加、修改、删除操作（存储过程）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
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

        #region 执行添加、修改、删除操作（存储过程），返回ReturnValue值
        
        /// <summary>
        /// 执行添加、修改、删除操作（存储过程），返回ReturnValue值
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="rowsAffected">返回受影响行数</param>
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

        #region 是否存在记录

        #region 是否存在记录（无参数）
        
        /// <summary>
        /// 是否存在记录（无参数）
        /// </summary>
        /// <param name="strSql">SQL语句</param>
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

        #region 是否存在记录（有参数）
        /// <summary>
        /// 是否存在记录（有参数）
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 获得表中int类型字段（自动增长+1）新值
        
        /// <summary>
        /// 获得表中int类型字段（自动增长+1）新值
        /// </summary>
        /// <param name="FieldName">int类型字段</param>
        /// <param name="TableName">表名</param>
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

        #region 获得查询结果的第一行第一列的值

        #region 获得查询结果的第一行第一列的值（无参数）
        
        /// <summary>
        /// 获得查询结果的第一行第一列的值（无参数）
        /// </summary>
        /// <param name="SQLString">SQL查询语句</param>
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

        #region 获得查询结果的第一行第一列的值（有参数）
        
        /// <summary>
        /// 获得查询结果的第一行第一列的值（有参数）
        /// </summary>
        /// <param name="SQLString">SQL查询语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 获得查询结果的第一行第一列的值（无参数，设置等待从服务器返回一个命令的时间）
        
        /// <summary>
        /// 获得查询结果的第一行第一列的值（无参数，设置等待从服务器返回一个命令的时间）
        /// </summary>
        /// <param name="SQLString">SQL查询语句</param>
        /// <param name="Times">等待从服务器返回一个命令的时间</param>
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

        #region 是否存在某表

        /// <summary>
        /// 是否存在某表
        /// </summary>
        /// <param name="TableName">表名</param>
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

        #region 判断表中某字段是否存在

        /// <summary>
        /// 判断表中某字段是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">字段名</param>
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


        #region 获得数据列表

        #region 获得DataSet数据列表


        #region 获得DataSet数据列表（SQL语句）

        /// <summary>
        /// 获得DataSet数据列表（SQL语句）
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
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

        #region 获得DataSet数据列表（有参数）（SQL语句）
        /// <summary>
        /// 获得DataSet数据列表（有参数）（SQL语句）
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 获得DataSet数据列表（设置等待从服务器返回一个命令的时间）（SQL语句）
        /// <summary>
        /// 获得DataSet数据列表（设置等待从服务器返回一个命令的时间）（SQL语句）
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Times">设置等待从服务器返回一个命令的时间</param>
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



        #region 获得DataSet数据列表（存储过程）

        /// <summary>
        /// 获得DataSet数据列表（存储过程）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param> 
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

        #region 获得DataSet数据列表（存储过程）

        /// <summary>
        /// 获得DataSet数据列表（存储过程）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param> 
        /// <param name="tableName">返回表名</param>
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

        #region 获得DataSet数据列表（存储过程）
        
        /// <summary>
        /// 获得DataSet数据列表（存储过程）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">返回表名</param>
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

        #region 获得DataSet数据列表（存储过程）（设置等待从服务器返回一个命令的时间）
        
        /// <summary>
        /// 获得DataSet数据列表（存储过程）（设置等待从服务器返回一个命令的时间）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">返回表名</param>
        /// <param name="Times">设置等待从服务器返回一个命令的时间</param>
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

        #region 获得SqlDataReader数据列表（SQL语句）
        
        /// <summary>
        /// 获得SqlDataReader数据列表（SQL语句）
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
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

        #region 获得SqlDataReader数据列表（有参数）（SQL语句）

        /// <summary>
        ///  获得SqlDataReader数据列表（有参数）（SQL语句）
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
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

        #region 获得SqlDataReader数据列表（有参数）（存储过程）
        
        /// <summary>
        /// 获得SqlDataReader数据列表（有参数）（存储过程）
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>
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

        #region 修改状态

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="filed_id">记录ID字段名称</param>
        /// <param name="filed_status">记录状态字段名称</param>
        /// <param name="id">ID值</param>
        /// <param name="status">状态值</param>
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
