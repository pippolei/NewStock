using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StockAnalysis
{
    
    public partial class PanelUtil : UserControl
    {
        private DataManager db = new DataManager();
        public PanelUtil()
        {
            InitializeComponent();
        }
        private void Export_To_CSV(string sql, string filename)
        {
            System.Data.DataTable table = db.GetTable(sql);
            Util.ExportCSV(table, filename);
        }
        private void Export_To_CSV(string sql)
        {
            System.Data.DataTable table = db.GetTable(sql);
            Util.ExportCSV(table);
        }
        private void btn_stockfull_Click(object sender, EventArgs e)
        {
            string sql = "select * from stock_Full  order by code, [index];";
            Export_To_CSV(sql, "C:/StockAnalysis/py/stock_full.csv");            
        }

        private void btn_stockdata_Click(object sender, EventArgs e)
        {
            string sql = "select * from stock_item  order by code, [index];";
            Export_To_CSV(sql, "C:/StockAnalysis/py/stock_item.csv"); 
        }

        private void btn_rulefull_Click(object sender, EventArgs e)
        {
            string sql = "select * from rule_buy0 where type = '"+Rule.STATUS_BUY+"' order by [id] ;";
            Export_To_CSV(sql, "C:/StockAnalysis/py/rule_full.csv");
        }

        


        #region completed
        private void btn_importStockFull_Click(object sender, EventArgs e)
        {
            string sql = "truncate table stock_Full;";
            string filename = "stock_full_py.txt";
            if (File.Exists(UtilLog.LOG_FOLDER + filename))
            {   
                sql += "BULK INSERT " + StockSQL.TABLE_STOCK_FULL + " FROM '" + UtilLog.LOG_FOLDER + filename + "';";
            }
            db.RunSql(sql);
            sql = "select * from Stock_header order by code";
            System.Data.DataTable table = db.GetTable(sql);
            int size = table.Rows.Count;
            if (size == 0)
            {
                sql = @"
                INSERT INTO STOCK_HEADER select T1.code, T2.code AS NAME, T1.[INDEX] AS LASTINDEX, [END] AS LASTPRICE from stock_full t1 
                JOIN
                (
                SELECT DISTINCT CODE, MAX([index]) as [index] 
                FROM stock_Full 
                group by CODE
                ) T2 ON T1.code = T2.code AND T1.[index] = T2.[INDEX]";
                db.RunSql(sql);
            }
            MessageBox.Show("Done");
        }
        #endregion
        private void ImportRule(string filename, int ruleid)
        {
            string sql = "";
            if (File.Exists(UtilLog.LOG_FOLDER + filename))
            {
                sql += "delete from Rule_Buy0 where type = " + ruleid + ";";
                sql += "BULK INSERT " + StockSQL.TABLE_RULE_BUY0 + " FROM '" + UtilLog.LOG_FOLDER + filename + "';";
            }
            db.RunSql(sql);
            
        }
       
        private void btn_importrule_Click(object sender, EventArgs e)
        {
            ImportRule("py_rule.txt", Rule.STATUS_BUY_PY);
            ImportRule("ml_rule.txt", Rule.STATUS_BUY_ML);
            MessageBox.Show("Import Rule Done!");
            
        }


    }
}
