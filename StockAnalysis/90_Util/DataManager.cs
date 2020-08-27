using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
namespace StockAnalysis
{
    /// <summary>
    /// 数据库操作基类
    /// 实现对Sql数据库的各种操作
    /// 创建时间：2007-11-5
    /// </summary>
    public class DataManager
    {
        public static string database = "Live";
        public static string user = "sa";
        public static string server = "localhost";
        public static string password = "Welcome1!";
        private static string SqlConnectionString = "user id="+user+";password="+password+";initial catalog=" + database + ";Server="+server+";Connect Timeout=0";

        #region not usually changed
        public static void changeDB(string server, string db, string user, string pwd)
        {
            DataManager.server = server;
            DataManager.database = db;
            DataManager.user = user;
            DataManager.password = pwd;
            SqlConnectionString = "user id=" + user + ";password=" + password + ";initial catalog=" + database + ";Server=" + server + ";Connect Timeout=0";

        }
        private SqlConnection cn;   //创建SQL连接
        private SqlDataAdapter sda;//创建SQL数据适配器
        private SqlCommand cmd;    //创建SQL命令对象
        // private OleDbParameter param;     //创建SQL参数
        private DataSet ds;     //创建数据集
        //private DataView dv;    //创建视图       

        private void Open()
        {
            #region   
            cn = new SqlConnection(SqlConnectionString);
            cn.Open();
            #endregion
        }

        private void Close()
        {
            #region
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
            #endregion
        }
        
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        public void RunSql(System.Collections.ArrayList sqllist)
        {
            Open();
            string sql;
            int size = sqllist.Count;
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 0;
            for (int i = 0; i < size; i++)
            {
                sql = (string)sqllist[i];
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            Close();
        }
        public void RunSql(string[] sqllist)
        {
            Open();
            string sql;
            int size = sqllist.Length;
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 0;
            for (int i = 0; i < size; i++)
            {
                sql = sqllist[i];
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            Close();
        }        
        public void RunSql(string strSql)
        {
            if (strSql.Length == 0)
            {
                return;
            }
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
            
            #endregion
        }
        /// 返回DataSet数据集
        private DataSet GetDs(string strSql)
        {
            #region
            Open();
            sda = new SqlDataAdapter(strSql, cn);
            sda.SelectCommand.CommandTimeout = 0;
            ds = new DataSet();
            sda.Fill(ds);
            Close();
            return ds;
            #endregion
        }
        /// 获得DataTable对象
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }
        #endregion
        //得到第一行
        public DataRow GetFirstRow(string sql)
        {
            DataTable table = GetTable(sql);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.Rows[0];
        }
        //得到第一行的指定列
        public object GetOneValue(string sql, string colume)
        {
            DataRow row = GetFirstRow(sql);
            if (row == null)
            {
                return null;
            }
            return row[colume];
        }
        //得到第一个指定列的值
        public object GetOneValue(string sql)
        {
            DataRow row = GetFirstRow(sql);
            return row[0];
        }
        //得到指定列的值
        public ArrayList GetColumnToList(string sql, string column)
        {
            DataTable dt = GetTable(sql);
            ArrayList list = new ArrayList();
            int size = dt.Rows.Count;

            for (int i = 0; i < size; i++)
            {
                DataRow dr = dt.Rows[i];
                string item = dr[column].ToString();
                list.Add(item);
            }
            return list;

        }
        public ArrayList GetColumnsToList(string sql, string[] columns)
        {
            DataTable dt = GetTable(sql);
            ArrayList list = new ArrayList();
            int size = dt.Rows.Count;
            int col_len = columns.Length;
            for (int i = 0; i < size; i++)
            {
                DataRow dr = dt.Rows[i];
                string[] items = new string[col_len];
                for (int j = 0; j < col_len; j++)
                {
                    items[j] = dr[columns[j]].ToString();
                }
                list.Add(items);
            }
            return list;

        }
        
        
        //判断数据库中是否存在数据
        public int GetSqlCount(string sql)
        {
            DataTable table = GetTable(sql);
            return table.Rows.Count;
        }
        //从数据库中得到最大的ID值来保证不重复
        public int GetMaxTableId(string tablename)
        {
            string sql = "select isnull(max(id), 0) as id from " + tablename + ";";
            int id = (int)GetOneValue(sql, "id");
            return id;
        }
        
        

        #region not used
        
        #endregion


    }

}


