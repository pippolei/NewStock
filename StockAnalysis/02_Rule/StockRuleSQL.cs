using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StockAnalysis
{
    class StockRuleSQL
    {
        private static DataManager db = new DataManager();
        
        //2018-03-18:从数据库得到rule相应的kpi filter
        public static ArrayList GetRuleFilter(string rule)
        {
            string sql = "select * from Rule_Filter where rulename = '" + rule + "';";
            string[] cols = new string[]{"kpiname","kpiindex","kpivalue"};
            ArrayList list = db.GetColumnsToList(sql, cols);
            return list;
        }
        //2014-04-11:从数据库得到rule相应的dapan filter
        public static ArrayList GetDapanFilter(string rule)
        {
            string sql = "select * from Rule_Filter_Dapan where rulename = '" + rule + "';";
            ArrayList list = db.GetColumnToList(sql, "kpiname");
            list.Add("Empty");
            return list;
        }
        private static StockRuleItem[] GetList(string sql)
        {
            System.Data.DataTable table = db.GetTable(sql);

            int size = table.Rows.Count;
            StockRuleItem[] items = new StockRuleItem[size];
            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockRuleItem();
                items[i].id = (int)row["id"];
                items[i].type = Convert.ToInt16(row["type"]);
                items[i].rulename = (string)row["rulename"];
                items[i].stockcode = (string)row["stockcode"];
                items[i].date = (int)row["date"];
                items[i].index = (int)row["index"];
                items[i].price = (double)row["price"];
                items[i].next1 = (double)row["next1"];
                items[i].next2 = (double)row["next2"];
                items[i].next3 = (double)row["next3"];
                items[i].next4 = (double)row["next4"];
                items[i].dapan = (string)row["dapan"];
                items[i].grade = Convert.ToDouble(row["grade"]);
                items[i].pregrade = Convert.ToDouble(row["pregrade"]);
                items[i].kpis = (string)(row["kpis"]);
                items[i].num_kpis = (string)(row["num_kpis"]);
                items[i].post1 = (double)row["post1"];
                items[i].post2 = (double)row["post2"];
                items[i].post3 = (double)row["post3"];
                items[i].post4 = (double)row["post4"];
                items[i].post5 = (double)row["post5"];
            }
            return items;
        }
        public static StockRuleItem[] GetRuleBuy0List(string rulename, int startdate, int enddate)
        {
            string sql = "select * from Rule_Buy0 where rulename = '" + rulename + "' and date >= '" + startdate + "' and date <= '" + enddate + "' order by stockcode,rulename,[index];";
            return GetList(sql);
        }  
        //单个buy list
        public static StockRuleItem[] GetRuleBuyList(string rulename, int startdate, int enddate, int type)
        {
            string sql = "select * from Rule_Buy where type = '" + type + "' and rulename = '" + rulename + "' and date >= '" + startdate + "' and date <= '" + enddate + "' order by stockcode,rulename,[index];";
            return GetList(sql);
        }               
        //单个sell list
        public static StockRuleItem[] GetRuleSellList(string rulename, int startdate,int enddate)
        {
            string sql = "select * from Rule_Buy where type = '" + Rule.STATUS_SELL + "' and rulename = '" + rulename + "' and date >= '" + startdate + "' and date <= '" + enddate + "' order by stockcode,rulename,[index];";
            return GetList(sql);
        }

        
        
        public static void SetAnalysis()
        {
            string sql = "IF OBJECT_ID('[Ope_Analysis]', 'U') IS NOT NULL drop table [Ope_Analysis];";
            db.RunSql(sql);


            sql = @"select * into Ope_Analysis  from rule_buy ; ";
            db.RunSql(sql);

        }
        #region not used        
        private static StockRuleItem[] GetRuleBuyList(string[] rulename, int startdate, int enddate)
        {
            int size = rulename.Length;
            string name = rulename[0];
            for (int i = 1; i < size; i++)
            {
                name += "/" + rulename[i];
            }
            //join
            /*string sql = "select '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.next1,A.next2,A.next3 from ";
            sql += " (SELECT * FROM Rule_Buy where rulename = '" + rulename[0] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') A " ;
            for (int i = 1; i < size; i++)
            {
                sql += " join (SELECT * FROM Rule_Buy where rulename = '" + rulename[i] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') ";
                sql += rulename[i] + " on " + rulename[i] + ".stockcode = A.stockcode and " + rulename[i] + ".[index] = A.[index]  ";
            }
            sql += "  order by A.stockcode,A.rulename,A.[index];";*/

            //union
            string sql = "select * from ";
            sql += "(";
            sql += "select '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.grade,A.next1,A.next2,A.next3,A.next4,A.next5 from ";
            sql += " (SELECT * FROM Rule_Buy where rulename = '" + rulename[0] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') A " ;
            for (int i = 1; i < size; i++)
            {
                sql += " union (SELECT '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.grade,A.next1,A.next2,A.next3,A.next4,A.next5 FROM Rule_Buy A where rulename = '" + rulename[i] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') ";                
            }
            sql += " ) ta order by ta.stockcode, date;";
            
            return GetList(sql);
        }
        private static StockRuleItem[] GetRuleSellList(string[] rulename, int startdate, int enddate)
        {
            int size = rulename.Length;
            string name = rulename[0];
            for (int i = 1; i < size; i++)
            {
                name += "/" + rulename[i];
            }
            //join
            /*
            string sql = "select '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.next1,A.next2,A.next3 from ";
            sql += " (SELECT * FROM Rule_Sell where rulename = '" + rulename[0] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') A ";
            for (int i = 1; i < size; i++)
            {
                sql += " join (SELECT * FROM Rule_Sell where rulename = '" + rulename[i] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') ";
                sql += rulename[i] + " on " + rulename[i] + ".stockcode = A.stockcode and " + rulename[i] + ".[index] = A.[index]  ";
            }
            sql += "  order by A.stockcode,A.rulename,A.[index];";*/
            string sql = "select * from ";
            sql += " ( ";
            sql += "select '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.grade,A.next1,A.next2,A.next3,A.next4,A.next5 from ";
            sql += " (SELECT * FROM Rule_Sell where rulename = '" + rulename[0] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') A ";
            for (int i = 1; i < size; i++)
            {
                sql += " union (SELECT '" + name + "' as rulename, A.stockcode,A.date,A.[index],A.price,A.grade,A.next1,A.next2,A.next3,A.next4,A.next5 FROM Rule_Sell A where rulename = '" + rulename[i] + "' and date >= '" + startdate + "' and date <= '" + enddate + "') ";
            }
            sql += " ) ta order by ta.stockcode, date;";
            
            return GetList(sql);
        }
        #endregion
    }
}
