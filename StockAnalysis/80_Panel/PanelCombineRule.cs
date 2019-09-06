using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace StockAnalysis.Panel
{
    public partial class PanelCombineRule: UserControl
    {
        private DataManager db = new DataManager();
        //private String TAG = "RuleCombine";
        private static ArrayList list = new ArrayList();

        public PanelCombineRule()
        {
            InitializeComponent();
            list.Add(this);
        }
        //初始化所有需要的规则
        private void PanelCombineRule_Load(object sender, EventArgs e)
        {
            RefreshState();
        }
       
             
        private void LoadState()
        {
            string sql = "";
            lst_buy2.Items.Clear();
            lst_sell2.Items.Clear();
            lst_comb.Items.Clear();
            foreach (Buy rule in StockApp.listbuy)
            {
                this.lst_buy2.Items.Add(rule);
            }
            foreach (Sell rule in StockApp.listsell)
            {
                this.lst_sell2.Items.Add(rule);
            }
            //rulegroup = 1 现在只有这种CASE
            //ruletype 控制室买还是卖
            sql = "SELECT t1.rulename as buyname, t2.rulename as sellname FROM (select * from rule_group where ruletype = '"+Rule.STATUS_BUY+"' and rulegroup = 1) AS t1 join ";
            sql += " (select * from rule_group where ruletype = '" + Rule.STATUS_SELL.ToString() + "' and rulegroup = 1) as t2 on t1.id = t2.id ";
            DataTable dt = db.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string buyname = (string)row["buyname"];
                string sellname = (string)row["sellname"];
                lst_comb.Items.Add(StockAnalysis.combineRule.CombindRuleString(buyname, sellname));
                lst_comb.SelectedItems.Add(StockAnalysis.combineRule.CombindRuleString(buyname, sellname));
            }            
        }
        private static void RefreshState()
        {
            for (int i = 0; i < list.Count; i++)
            {
                PanelCombineRule obj = (PanelCombineRule)list[i];
                obj.LoadState();
            }
        }
 
        public combineRule[] GetSelectedCombGroup()
        {
            int len = lst_comb.Items.Count;
            combineRule[] obj = new combineRule[len];
            for (int i = 0; i < len; i++)
            {
                string s = lst_comb.Items[i].ToString();
                obj[i] = combineRule.getCombRule(s);
            }
            return obj;
        }
        



        private void btn_add_Click(object sender, EventArgs e)
        {
            int len1 = lst_buy2.SelectedItems.Count;
            int len2 = lst_sell2.SelectedItems.Count;

            if (len1 < 1 || len2 < 1) return;

            string sql = "";
            string buyname = lst_buy2.SelectedItems[0].ToString();
            string sellname = lst_sell2.SelectedItems[0].ToString();
            int id = db.GetMaxTableId("Rule_Group"); id++;
            sql += "insert into rule_group values('" + id + "','1','" + Rule.STATUS_BUY + "','" + buyname + "');";
            sql += "insert into rule_group values('" + id + "','1','" + Rule.STATUS_SELL + "','" + sellname + "');";

            db.RunSql(sql);
            RefreshState();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            int len = this.lst_comb.SelectedItems.Count;
            string sql = "";
            for (int i = 0; i < len; i++)
            {
                string s = lst_comb.SelectedItems[i].ToString();
                string[] name = s.Split('-');
                string buyname = name[0];
                string sellname = name[1];
                sql = "select * from ";
                sql += " (select * from rule_group where ruletype = '" + Rule.STATUS_BUY + "' and rulegroup = '1' and rulename = '" + buyname + "') t1 ";
                sql += " join ";
                sql += " (select * from rule_group where ruletype = '" + Rule.STATUS_SELL + "' and rulegroup = '1' and rulename = '" + sellname + "') t2 ";
                sql += " on t1.id = t2.id";
                int id = Convert.ToInt16(db.GetOneValue(sql, "ID").ToString());
                sql = "delete from rule_group where id = " + id + ";";
                db.RunSql(sql);

            }

            RefreshState();
        }




        




        
    }


    
}
