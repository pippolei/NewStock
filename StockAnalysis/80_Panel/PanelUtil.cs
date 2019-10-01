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

        private void btn_importrule_Click(object sender, EventArgs e)
        {
            string filename = "ml_rule.txt";
            string sql = "";
            if (File.Exists(UtilLog.LOG_FOLDER + filename))
            {
                sql += "delete from Rule_Buy0 where type = " + Rule.STATUS_BUY_ML + ";";
                sql += "BULK INSERT " + StockSQL.TABLE_RULE_BUY0 + " FROM '" + UtilLog.LOG_FOLDER + filename + "';";
            }
            filename = "ml_rule_test.txt";
            if (File.Exists(UtilLog.LOG_FOLDER + filename))
            {
                sql += "delete from Rule_Buy0 where type = " + Rule.STATUS_BUY_ML_TEST + ";";
                sql += "BULK INSERT " + StockSQL.TABLE_RULE_BUY0 + " FROM '" + UtilLog.LOG_FOLDER + filename + "';";
            }
            db.RunSql(sql);
            MessageBox.Show("Done");
        }

        private void btn_rulesell_Click(object sender, EventArgs e)
        {
            string sql = "select * from rule_buy0 where type in ('" + Rule.STATUS_BUY + "','" + Rule.STATUS_SELL + "') order by [id] ;";
            Export_To_CSV(sql, "C:/StockAnalysis/py/rule_withsell.csv");
        }


    }
}
