using System;
using System.Collections.Generic;
using StockAnalysis;
using System.Text;

namespace StockAnalysis
{
    //比较stockopeitem顺序
    class newsCompare: IComparer<StockAnalysis.StockOpeItem>
    {
        int IComparer<StockOpeItem>.Compare(StockOpeItem x, StockOpeItem y)
        {
            //排列次序:日期大的在后面
            if (x.buydate > y.buydate)
            {
                return 1;
            }
            else if (x.buydate < y.buydate)
            {
                return -1;
            }
            //排列次序:分数高大的在前面
            else if (x.grade > y.grade)
            {
                return -1;
            }
            else if (x.grade < y.grade)
            {
                return 1;
            }
            //排列次序:价格低的在前面
            else if (x.buyprice < y.buyprice)
            {
                return -1;
            }
            else if (x.buyprice > y.buyprice)
            {
                return 1;
            }
            return 0;
            
        }
    }
    
    class StockAnalysisSQL
    {
        private static DataManager db = new DataManager();
        //2018-03-20
        //如果没有卖出数据,会把最后一天的价格强制卖出
        public static StockOpeItem[] CalculateSave2Analysis2(int startdate, int enddate, string buyname, string sellname, int buytype)
        {
            string sql;
            //tmp2得到所有的卖出信息以及最后一天的信息
            sql = "select * into #tmp2 from ";
            sql+= " (select rulename, stockcode,[DATE],[INDEX],price from Ope_Analysis where date >= '" + startdate.ToString() + "' and date <= '" + enddate.ToString() + "'  and rulename = '" + sellname + "' and type = '" + Rule.STATUS_SELL + "' ";
            sql += " union ";
            sql += "SELECT '" + sellname + "' as rulename, T7.code as stockcode, T7.[date] as [date],t7.[index] as [index],t7.[end] as price FROM Stock_Item T7 join ";
            sql += " (select code, MAX([index]) as [index],MAX([date]) as [date] from Stock_Item where ";
            sql += " [DATE] <= '" + enddate.ToString() + "' group by code) T8 on t7.code = t8.code and t7.[index] = t8.[index]";
            sql += " ) T2;";
            sql += " select * into #tmp1 from (select * from Ope_Analysis where date >= '" + startdate.ToString() + "' and date <= '" + enddate.ToString() + "' and rulename = '" + buyname + "' and type = '" +  buytype + "') T1;  ";
            sql += "SELECT * FROM ( ";
            sql += "SELECT T1.stockcode, T1.rulename as buyname, t1.[date] as buydate, t1.[index] as buyindex, t1.price as buyprice, t1.pregrade, t1.grade,  t1.kpis, t1.dapan, ";
            sql += "T2.rulename as sellname, t2.[date] as selldate, t2.[index] as sellindex, t2.price as sellprice, ";
            sql += "RANK() OVER (PARTITION BY t1.stockcode, t1.[date] order by t2.[date]) AS SEQUENCE FROM ";
            sql += "#TMP1 AS T1 LEFT OUTER JOIN ";
            sql += " #tmp2 as t2 ";
            sql += "ON T1.stockcode = T2.stockcode ";
            sql += "WHERE T1.date <= T2.date ) T3 ";
            sql += "WHERE T3.SEQUENCE = 1 ";
            sql += "ORDER BY stockcode, BUYDATE; ";

            System.Data.DataTable table = db.GetTable(sql);
            System.Collections.ArrayList sqllist = new System.Collections.ArrayList();

            int size = table.Rows.Count;
            StockOpeItem[] items = new StockOpeItem[size];

            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockOpeItem();
                items[i].type = buytype;
                items[i].buyrule = (string)row["buyname"];
                items[i].sellrule = (string)row["sellname"];
                items[i].stockcode = (string)row["stockcode"];
                items[i].buydate = (int)row["buydate"];
                items[i].buyindex = (int)row["buyindex"];
                items[i].buyprice = (double)row["buyprice"];
                //items[i].grade = RuleScore.GetRuleScore(items[i].buyrule, items[i].buydate / 100);
                items[i].grade = (double)row["grade"];
                items[i].selldate = (int)row["selldate"];
                items[i].sellindex = (int)row["sellindex"];
                items[i].sellprice = (double)row["sellprice"];
            }
            return items;
        }
        //2018-03-18 保存至数据库
        public static void SaveToDB_Analysis2(System.Collections.ArrayList list)
        {
            string sql;
            sql = "truncate table Ope_Analysis2;";
            db.RunSql(sql);

            System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
            SQLMassImport rulefile = new SQLMassImport("Analysis2SQL");
            for (int i = 0; i < list.Count; i++)
            {
                StockOpeItem item = (StockOpeItem)list[i];
                string[] attristrs = new string[11];
                attristrs[0] = item.type.ToString();
                attristrs[1] = item.stockcode;
                attristrs[2] = item.buyrule;
                attristrs[3] = item.sellrule.ToString();
                attristrs[4] = item.buydate.ToString();
                attristrs[5] = item.buyindex.ToString();
                attristrs[6] = item.buyprice.ToString();
                attristrs[7] = item.grade.ToString();
                attristrs[8] = item.selldate.ToString();
                attristrs[9] = item.sellindex.ToString();
                attristrs[10] = item.sellprice.ToString();
                rulefile.AddRow(attristrs);
            }
            rulefile.ImportClose(db, StockSQL.TABLE_ANALYZE2);
        }
       
        //2018-03-20:以buyrule为主, 这里startdate,endddate只限制buydate, 不在乎卖出时间
        public static StockOpeItem[] GetAnalysis2List(int type, int startdate, int enddate, string buyrule, string sellrule, double goodsccore)
        {
            return GetAnalysis2List(type, startdate, enddate, buyrule, sellrule, goodsccore, 
                true, //apply default sale
                true);
        }
        
        public static StockOpeItem[] GetAnalysis2List(int type, int startdate, int enddate, string buyrule, string sellrule, double goodsccore, bool applyDefaultSell, bool restrict_end_to_sell)
        {
            string sql;
            Buy buy = StockApp.GetBuy(buyrule);


            string d_sellindex = buy.defaultSell + StockKPI.default_index;
            string d_sellprice = buy.defaultSell + StockKPI.default_price;
            string d_selldate = buy.defaultSell + StockKPI.default_date;

            sql = " select T1.*, T5.*," + d_sellindex + "," + d_sellprice + "," + d_selldate + " from ( ";
            sql += "select * from Ope_Analysis2 where buydate >= '" + startdate + "' ";
            //goodgrade如果选项打开, 只有在score>goodscore时才做选择
            sql += " and grade >= '" + goodsccore  + "' ";

            sql += " and buydate <= '" + enddate + "' and buyrule = '" + buyrule + "' and sellrule = '" + sellrule + "' ";
            sql += " and type in (" + type + ","  + Rule.STATUS_SELL + ")) T1 ";
            sql += " join stock_Full T2 on T1.stockcode = T2.code and T1.buyindex = T2.[index] ";
            sql += " join ";
            sql += " (select t3.code,t3.[index] as maxindex,t3.[date] as maxdate,t3.[end] as maxprice from stock_Full t3 join ";
            sql += " (select code, MAX([date]) as intdate from stock_full ";
            sql += " where [date]<= " + enddate ;
            sql += " group by code) t4 on t3.code = t4.code and t3.[date] = t4.intdate) t5 ";
            sql += " on t1.stockcode = t5.code ";
            sql += " order by T1.stockcode, T1.[buydate];";
      
            System.Data.DataTable table = db.GetTable(sql);

            System.Collections.ArrayList sqllist = new System.Collections.ArrayList();

            int size = table.Rows.Count;
            StockOpeItem[] items = new StockOpeItem[size];

            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockOpeItem();
                items[i].type = (int)row["type"];
                items[i].stockcode = (string)row["stockcode"];
                items[i].buyrule = (string)row["buyrule"];
                items[i].sellrule = (string)row["sellrule"];
                items[i].buydate = (int)row["buydate"];
                items[i].buyindex = (int)row["buyindex"];
                items[i].buyprice = (double)row["buyprice"];
                items[i].grade = (double)row["grade"];

                if (applyDefaultSell && (int)row["sellindex"] > Convert.ToInt32(row[d_sellindex]))
                {
                    items[i].selldate = Convert.ToInt32(row[d_selldate]);
                    items[i].sellindex = Convert.ToInt32(row[d_sellindex]);
                    items[i].sellprice = (double)row[d_sellprice];
                }
                else
                {
                    items[i].selldate = (int)row["selldate"];
                    items[i].sellindex = (int)row["sellindex"];
                    items[i].sellprice = (double)row["sellprice"];
                }

                if (restrict_end_to_sell && (int)row["maxindex"] < items[i].sellindex)
                {
                    items[i].selldate = (int)row["maxdate"];
                    items[i].sellindex = (int)row["maxindex"];
                    items[i].sellprice = (double)row["maxprice"];
                }
            }

            return items;
        }
        public static StockOpeItem[] GetAnalysis2List(int type, int startdate, int enddate, string[] buyrules, string[] sellrules, double goodsccore, bool applyDefaultSell, bool restrict_end_to_sell)
        {
            List<StockOpeItem> list = new List<StockOpeItem>();
            for (int i = 0; i < buyrules.Length; i++)
            {
                StockOpeItem[] items = GetAnalysis2List(type, startdate, enddate, buyrules[i], sellrules[i], goodsccore, applyDefaultSell, restrict_end_to_sell);
                for (int j = 0; j < items.Length; j++)
                {
                    list.Add(items[j]);
                }

            }
            newsCompare comp = new newsCompare();
            list.Sort(comp);
            return list.ToArray();
            
        }
    }
}
