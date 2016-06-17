using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace Article.baseUtils
{
    internal class SqlLiteConn
    {
        #region - 变量 -

        private SQLiteConnection conn;

        private SQLiteCommand cmd;

        private static string connstring = "Data Source=" + System.Environment.CurrentDirectory + "\\DB\\acfun";

        #endregion - 变量 -

        #region - 方法 -

        public SQLiteConnection getConn()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(connstring);
                conn.Open();
                return conn;
            }
            else
            {
                conn.Open();
                return conn;
            }
        }

        /// <summary>
        /// 执行插入/删除
        /// </summary>

        public int ExecuteNonQuery(string sql)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = sql;
                    affectedRows = command.ExecuteNonQuery();
                }
            }
            conn.Close();
            return affectedRows;
        }

        /// <summary>
        /// 执行插入/删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteReader(string sql, SQLiteParameter[] parameters)
        {
            SQLiteConnection connection = new SQLiteConnection(connstring);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询
        /// </summary>

        public SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(connstring);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 查询列表
        /// </summary>

        public DataTable ExecuteDataTable(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    connection.Close();
                    return data;
                }
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    connection.Close();
                    return data;
                }
            }
        }

        /// <summary>
        /// 执行单条sql 【userid】 @userid"select UserName from userinfo where [UserID]=@UserID";
        //  SqlParameter par = new SqlParameter("@UserID", id);
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    connection.Close();

                    return data;
                }
            }
        }

        /// <summary>
        /// 执行单条sql 【userid】 @userid"select UserName from userinfo where [UserID]=@UserID";
        //  SqlParameter par = new SqlParameter("@UserID", id);
        /// </summary>
        public Object ExecuteScalar(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    connection.Close();

                    return data;
                }
            }
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public DataTable GetSchema()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connstring))
            {
                connection.Open();
                DataTable data = connection.GetSchema("TABLES");
                connection.Close();
                return data;
            }
        }

        #endregion - 方法 -
    }
}