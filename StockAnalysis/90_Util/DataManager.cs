using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
namespace StockAnalysis
{
    /// <summary>
    /// ���ݿ��������
    /// ʵ�ֶ�Sql���ݿ�ĸ��ֲ���
    /// ����ʱ�䣺2007-11-5
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
        private SqlConnection cn;   //����SQL����
        private SqlDataAdapter sda;//����SQL����������
        private SqlCommand cmd;    //����SQL�������
        // private OleDbParameter param;     //����SQL����
        private DataSet ds;     //�������ݼ�
        //private DataView dv;    //������ͼ       

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
        /// ִ��Sql���
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
        /// ����DataSet���ݼ�
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
        /// ���DataTable����
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }
        #endregion
        //�õ���һ��
        public DataRow GetFirstRow(string sql)
        {
            DataTable table = GetTable(sql);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.Rows[0];
        }
        //�õ���һ�е�ָ����
        public object GetOneValue(string sql, string colume)
        {
            DataRow row = GetFirstRow(sql);
            if (row == null)
            {
                return null;
            }
            return row[colume];
        }
        //�õ���һ��ָ���е�ֵ
        public object GetOneValue(string sql)
        {
            DataRow row = GetFirstRow(sql);
            return row[0];
        }
        //�õ�ָ���е�ֵ
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
        
        
        //�ж����ݿ����Ƿ��������
        public int GetSqlCount(string sql)
        {
            DataTable table = GetTable(sql);
            return table.Rows.Count;
        }
        //�����ݿ��еõ�����IDֵ����֤���ظ�
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


