using System;
using System.Collections.Generic;

using System.Text;

namespace StockAnalysis
{
    class StockSimulateSQL
    {
        private static DataManager db = new DataManager();
        private static readonly string TAG = "UtilSimulateSql";
        //public static readonly string simu_buyname = "buy";
        //public static readonly string simu_sellname = "sell";
        //删除数据库此时间段的记录
        public static void ClearDB(int type, int startdate, int enddate, string buyrule, string sellrule)
        {
            //foreach (int type in Rule.rulebuy_list)
            {
                string sql = "select id from Ope_Simulate where type = " + type + " and startdate = '" + startdate + "' and enddate = '" + enddate + "' and buyrule = '" + buyrule + "' and sellrule = '" + sellrule + "';";
                object id = db.GetOneValue(sql, "id");
                if (id != null)
                {
                    sql = "delete from Ope_Simulate_Item where id = '" + id.ToString() + "';";
                    sql += "delete from Ope_Simulate where id = '" + id.ToString() + "';";
                    db.RunSql(sql);
                }

            }
            
        }
        //保存至数据库
        public static void SaveToDB(int type, int startdate, int enddate, string buyrule, string sellrule, System.Collections.ArrayList list)
        {
            ClearDB(type, startdate, enddate, buyrule, sellrule);

            string sql = "insert into Ope_Simulate values(" + type + ",'" + startdate + "','" + enddate + "','" + buyrule + "','" + sellrule + "');";
            db.RunSql(sql);
            int maxid = db.GetMaxTableId("Ope_Simulate");
            //有可能是上次没删干净的记录
            sql = "delete from Ope_Simulate_Item where id = '" + maxid.ToString() + "';";
            db.RunSql(sql);
            System.Collections.ArrayList sqllist = new System.Collections.ArrayList();


            SQLMassImport rulefile = new SQLMassImport("Simulate");
            for(int i = 0; i < list.Count; i++)
            {
                StockSimulateItem item = (StockSimulateItem)list[i];
                string[] strs = new string[18];
                strs[0] = maxid.ToString();
                strs[1] = item.type.ToString();
                strs[2] = item.buyrule;
                strs[3] = item.sellrule;
                strs[4] = item.stockcode;
                strs[5] = item.buydate.ToString();
                strs[6] = item.buyindex.ToString();
                strs[7] = item.buyprice.ToString();
                strs[8] = item.selldate.ToString();
                strs[9] = item.sellindex.ToString();
                strs[10] = item.sellprice.ToString();
                strs[11] = item.buyvolume.ToString();
                strs[12] = item.stockvalue.ToString();
                strs[13] = item.winvalue.ToString();
                strs[14] = item.holdstocknum.ToString();
                strs[15] = item.totalstockvalue.ToString();
                strs[16] = item.leftmoney.ToString();
                strs[17] = item.totalamount.ToString();
                rulefile.AddRow(strs);
            }

            rulefile.ImportClose(db, StockSQL.TABLE_SIMULATE_ITEM);           
        }
        
        public static StockSimulateItem[] GetSimulateList(int type, int startdate, int endate, string buyname, string sellname)
        {
            string sql = "select id from Ope_Simulate where type = " + type + " and startdate = '" + startdate + "' and enddate = '" + endate + "' and buyrule = '" + buyname + "' and sellrule = '" + sellname + "';";
            object id = db.GetOneValue(sql, "id");
            StockSimulateItem[] items = new StockSimulateItem[0];
            if (id != null)
            {
                sql = "select * from  Ope_Simulate_Item where id = '" + id.ToString() + "';";
                System.Data.DataTable table = db.GetTable(sql);
                items = new StockSimulateItem[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    System.Data.DataRow row = table.Rows[i];
                    StockSimulateItem item = new StockSimulateItem();
                    item.type = Convert.ToInt32(row["type"]);
                    item.buyrule = (string)row["buyrule"];
                    item.sellrule = (string)row["sellrule"];
                    item.stockcode = (string)row["stockcode"];
                    item.buydate = Convert.ToInt32(row["buydate"]);
                    item.buyindex = Convert.ToInt32(row["buyindex"]);
                    item.buyprice = Convert.ToDouble(row["buyprice"]);
                    item.selldate = Convert.ToInt32(row["selldate"]);
                    item.sellindex = Convert.ToInt32(row["sellindex"]);
                    item.sellprice = Convert.ToDouble(row["sellprice"]);
                    item.buyvolume = Convert.ToInt32(row["buyvolume"]);
                    //item.stockvalue = Convert.ToDouble(row["stockvalue"]);
                    //item.winvalue = Convert.ToDouble(row["winvalue"]);
                    item.holdstocknum = Convert.ToInt32(row["holdstocknum"]);
                    item.totalstockvalue = Convert.ToDouble(row["totalstockvalue"]);
                    item.leftmoney = Convert.ToDouble(row["leftmoney"]);
                    //item.totalamount = Convert.ToDouble(row["totalamount"]);
                    items[i] = item;
                }
            }
            
            return items;
        }
        //得到分析时间段股票本身平均涨幅
        public static double GetAverageGrowth(int startdate, int enddate)
        {
            if (startdate < Util.getIntDate(Util.getDate(StockApp.getAnalysisStartDate).AddMonths(StockApp.STOCK_START_DATE_SHITE_MONTH)))
            {
                startdate = Util.getIntDate(Util.getDate(StockApp.getAnalysisStartDate).AddMonths(StockApp.STOCK_START_DATE_SHITE_MONTH));
            }
            string sql = "select isnull(max(date),0) from stock_full where [date] < " + startdate + ";";
            object ret = db.GetFirstRow(sql)[0];
            int minid = Convert.ToInt32(ret);

            if (enddate < startdate)
            {
                enddate = startdate;
            }
            sql = "select isnull(max(date),0) from stock_full where [date] <= " + enddate + ";";
            ret = db.GetFirstRow(sql)[0];            
            int maxid = Convert.ToInt32(db.GetFirstRow(sql)[0]);
            UtilLog.AddInfo(TAG, "Calculate ave growth start");
            //pivot 用法
            /*
            select code, "20151231", "20180126" from 
            (
            select code,[date], [end] from stock_Full where [DATE] in ('20151231', '20180126') 
            and code in (select code from stock_full group by code having MIN([date])< '20151231')
            ) T1 pivot (MAX([end]) for [date] in ("20151231", "20180126")) as tp;
            */
            sql = "select code, ";
            sql += " isnull(SUM(CASE [date] WHEN " + minid + " THEN [end] END),0) AS 'start', ";
            sql += " isnull(SUM(CASE [date] WHEN " + maxid + " THEN [end] END),0) AS 'end' ";
            sql+= " from ( ";
            sql += " select code,[date], [end] from stock_Full where [DATE] in ('" + minid + "', '" + maxid + "') ";
            sql+= " and code in (select code from stock_full group by code having MIN([date])< '" + minid + "') ";
            sql += " ) T1 group by code ";
            System.Data.DataTable dt = db.GetTable(sql);
            int count = 0;
            double retvalue = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                System.Data.DataRow row = dt.Rows[i];
                
                double start = Convert.ToDouble(row["start"]);
                double end = Convert.ToDouble(row["end"]);
                if (start < 0.1 || end < 0.1) continue;
                count++;
                retvalue += end / start;
            }
            try
            {
                return (retvalue / count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
            finally
            {
                UtilLog.AddInfo(TAG, "Calculate ave growth end");
            }
        }


        public static double GetFinalValue(int type, int startdate, int enddate, string buyrule, string sellrule)
        {
            string sql = "select id from Ope_Simulate where startdate = '" + startdate + "' and enddate = '" + enddate + "' and buyrule = '" + buyrule + "' and sellrule = '" + sellrule + "' and type = " + type + ";";
            object id = db.GetOneValue(sql, "id");
            if (id != null)
            {
                sql = "select * from Ope_Simulate_Item where type = " + type + " and ID = '" + id.ToString() + "'  order by selldate desc , holdstocknum, type ";
                object value = db.GetOneValue(sql, "totalamount");
                return value == null ? 0 : Convert.ToDouble(value);
            }
            return 0;
        }

        #region obsolete
        /*
        //不使用任何卖出策略,仅到时间自动卖出
        public static StockOpeItem[] GetDefaultOperationList(int startdate, int enddate, string buyname, string defaultsell)
        {
            StockRuleItem[] buyitems = new StockRuleItem[0]; // GetSimulateList(startdate, enddate, buyname, true);
            
            int buysize = buyitems.Length;
            UtilLog.AddInfo(TAG, buyname + "****" + defaultsell + ":" + startdate + "~~~" + enddate + " search start");
            StockOpeItem[] items = new StockOpeItem[buysize];
            for (int i = 0; i < buysize; i++)
            {
                items[i] = new StockOpeItem();
                items[i].type = buyitems[i].type;
                items[i].buyrule = buyitems[i].rulename;
                items[i].sellrule = defaultsell;
                items[i].stockcode = buyitems[i].stockcode;
                items[i].buydate = buyitems[i].date;
                items[i].buyindex = buyitems[i].index;
                items[i].buyprice = buyitems[i].price;
                items[i].grade = buyitems[i].grade;
                //如果没有卖出, 默认设为原价值
                items[i].sellprice = buyitems[i].price;

                int buyindex = buyitems[i].index;
                StockItem[] stockitems = StockApp.GetStock(buyitems[i].stockcode).items;
                int sellindex = Convert.ToInt32(stockitems[buyindex].kpi[defaultsell]);

                if (sellindex == 0 || stockitems[sellindex].date > enddate)
                {
                    items[i].selldate = 0;
                    items[i].sellindex = 0;
                }
                else
                {
                    items[i].selldate = stockitems[sellindex].date;
                    items[i].sellindex = sellindex;
                    items[i].sellprice = stockitems[sellindex].end;
                }

            }
            UtilLog.AddInfo(TAG, buyname + "****" + defaultsell + ":" + startdate + "~~~" + enddate + " search end");
            return items;
        }
        //得到分析时间段股票本身平均涨幅
        public static double GetAverageGrowth(int startdate, int enddate)
        {
            string sql = "select sum([end] / start), COUNT(1) from ";
                   sql+= " (select A.code, A.[end] as start from Stock_Item A ";
                   sql+= " join ";
                   sql+= " (select code, MIN([index]) as [index] from stock_item ";
                   sql+= " where date >= '" + startdate + "' ";
                   sql+= " group by code) B ";
                   sql+= " on A.code = b.code and a.[index] = b.[index]) A1 ";
                   sql+= " join ";
                   sql+= " (select A.code, A.[end]  from Stock_Item A ";
                   sql+= " join ";
                   sql+= " (select code, MAX([index]) as [Index] from stock_item ";
                   sql+= " where date <= '" + enddate + "' ";
                   sql+= " group by code) B ";
                   sql+= " on A.code = b.code and a.[index] = b.[index]) A2 ";
                   sql+= " on A1.code = A2.code";
            UtilLog.AddInfo(TAG, "Calculate ave growth start");
            System.Data.DataRow row = db.GetFirst(sql);
            try
            {
                return (double)row[0] / (int)row[1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
            finally
            {
                UtilLog.AddInfo(TAG, "Calculate ave growth end");
            }
           
        }
        //根据日期得到数据 
        private static StockRuleItem[] GetSimulateList(int startdate, int enddate, string rulename, bool goodgrade)
        {
            string sql;
            sql = "select * from Ope_Analysis where date >= '" + startdate + "' ";
            //goodgrade如果选项打开, 只有在score>0时才做选择
            if (goodgrade)
            {
                sql += " and grade >= 0";
            }
            sql += " and date <= '" + enddate + "' and rulename = '" + rulename + "' ";
            sql += " and type <= '" + StockApp.SUS_BUY + "' and type >= '" + Rule.SUS_SELL + "' ";
            sql += " order by stockcode, date;";
            System.Data.DataTable table = db.GetTable(sql);

            System.Collections.ArrayList sqllist = new System.Collections.ArrayList();

            int size = table.Rows.Count;
            StockRuleItem[] items = new StockRuleItem[size];

            for (int i = 0; i < size; i++)
            {

                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockRuleItem();
                items[i].rulename = (string)row["rulename"];
                items[i].stockcode = (string)row["stockcode"];
                items[i].date = (int)row["date"];
                items[i].index = (int)row["index"];
                items[i].price = (double)row["price"];
                //items[i].grade = (double)row["grade"];
                items[i].next3 = (double)row["next3"];
                items[i].next2 = (double)row["next2"];
                items[i].next1 = (double)row["next1"];
                items[i].next4 = (double)row["next4"];
                items[i].dapan = (string)row["dapan"];
                items[i].type = (int)row["type"];
                string[] vals = StockSQL.getStockScoreKPI(Convert.ToInt32(row["grade"]));
                if (vals == null || vals.Length == 0)
                {
                    items[i].kpis = "";
                    items[i].grade = 0;
                }
                else
                {
                    items[i].grade = Convert.ToDouble(vals[1]);
                    items[i].kpis = vals[3];
                    for (int j = 4; j < vals.Length; j++)
                    {
                        items[i].kpis = items[i].kpis + "," + vals[j];
                    }
                }
            }
            return items;
        }

        //根据日期得到数据
        public static StockOpeItem[] GetOperationList(int startdate, int enddate, string buyname, string sellname, bool goodscore)
        {
            StockRuleItem[] buyitems = GetSimulateList(startdate, enddate, buyname, goodscore);
            StockRuleItem[] sellitems = GetSimulateList(startdate, enddate, sellname, false);

            int buysize = buyitems.Length;
            StockOpeItem[] items = new StockOpeItem[buysize];

            int sellcursor = 0;
            int sellsize = sellitems.Length;

            string buycode = "";
            UtilLog.AddInfo(TAG, buyname + "****" + sellname + ":" + startdate + "~~~" + enddate + " search start");
            for (int i = 0; i < buysize; i++)
            {
                items[i] = new StockOpeItem();
                items[i].type = buyitems[i].type;
                items[i].buyrule = buyitems[i].rulename;
                items[i].sellrule = sellname;
                items[i].stockcode = buyitems[i].stockcode;
                items[i].buydate = buyitems[i].date;
                items[i].buyindex = buyitems[i].index;
                items[i].buyprice = buyitems[i].price;
                items[i].grade = buyitems[i].grade;
                //如果没有卖出, 默认设为原价值
                items[i].sellprice = buyitems[i].price;

                buycode = items[i].stockcode;

                int buyindex = buyitems[i].index;
                int j;
                for (j = sellcursor; j < sellsize; j++)
                {
                    //如果股票代码不一致,进行处理                    
                    if (Convert.ToInt32(sellitems[j].stockcode) < Convert.ToInt32(buycode))
                    {
                        continue;
                    }
                    else if (Convert.ToInt32(sellitems[j].stockcode) > Convert.ToInt32(buycode))
                    {
                        setNoSell(items[i]);
                        break;
                    }
                    else
                    {
                        if (buyindex < sellitems[j].index)
                        {
                            sellcursor = j;
                            items[i].sellrule = sellitems[sellcursor].rulename;
                            items[i].selldate = sellitems[sellcursor].date;
                            items[i].sellindex = sellitems[sellcursor].index;
                            items[i].sellprice = sellitems[sellcursor].price;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (j == sellsize)
                {
                    setNoSell(items[i]);
                }
            }
            UtilLog.AddInfo(TAG, buyname + "****" + sellname + ":" + startdate + "~~~" + enddate + " search end");
            return items;
        }
        */
        #endregion


    }
}
