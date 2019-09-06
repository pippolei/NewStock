using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StockAnalysis
{
    class RuleScore
    {
        private static DataManager db = new DataManager();
        //设定每个rule的按月平均表现值
        //rulescore和stockstock相互独立
        //实际选股时,先按照rule store选择使用哪个rule,然后按照stock store选择买入那个股票
        public static void SetRuleScore()
        {
            string sql = "IF OBJECT_ID('[Rule_Score]', 'U') IS NOT NULL drop table [Rule_Score];";
            db.RunSql(sql);
            sql = @"SELECT rulename, intdate, AVG(grade) as 'grade'  into Rule_Score FROM 
                (select *, [DATE]/100 as intdate from Rule_Buy) T1 group by rulename,  intdate";
            db.RunSql(sql);
        }
        public static double GetRuleScore(string rulename, int buymonth)
        {
            object ret = null;
            int newperiod = buymonth;
            int times = 0;
            while (ret == null)
            {
                newperiod = Util.lastMonth(newperiod * 100 + 1);
                string sql = "select * from rule_score where rulename = '" + rulename + "' and intdate = " + newperiod + ";";
                ret = db.GetOneValue(sql, "grade");
                times++;
                if (times > 3) break;
            }


            if (ret == null)
            {
                return StockApp.MIN_ZERO;
            }
            return Convert.ToDouble(ret.ToString());
        }

        public static void SetAllPreScore()
        {
            string sql = "select * from Rule_Buy";
            DataTable dt = db.GetTable(sql);
            int size = dt.Rows.Count;
            ArrayList sqls = new ArrayList();
            for (int i = 0; i < size; i++)
            {
                DataRow dr = dt.Rows[i];
                int id = Convert.ToInt32(dr["id"]);
                int date = Convert.ToInt32(dr["date"]);
                string rulename = (string)dr["rulename"];
                double prescore = GetRuleScore(rulename, date);
                sqls.Add("update [Rule_Buy] set pregrade = '" + prescore + "' where id = " + id + ";");
            }
            db.RunSql(sqls);
        }
    }
}
