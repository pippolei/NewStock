using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace StockAnalysis
{
    class DaPanItem
    {
        public int seq;
        public int date;
        public double rize;
        public int num_rize;
        public int num_down;
        public double avg1 = 0;
        public double avg2 = 0;
        public double avg3 = 0;
        public double avg4 = 0;
        public double avg5 = 0;
        public string grade = "";
    }
    class StockDapan
    {
        private static DataManager db = new DataManager();
        public static readonly string STATUS_BIG_GOOD = "BIG_GOOD";
        public static readonly string STATUS_GOOD = "GOOD";
        public static readonly string STATUS_BAD = "BAD";
        public static readonly string STATUS_BIG_BAD = "BIG_BAD";
        public static readonly string STATUS_NEUTRAL = "NEUTRAL";
        public static readonly string[] namelist = new string[] {
            STATUS_BIG_GOOD, STATUS_GOOD, STATUS_NEUTRAL, STATUS_BAD, STATUS_BIG_BAD
        };
        //给出某一日大盘的评分
        public static string GetDaPanScore(int intdate)
        {
            string kpis = "";
            string sql = "select * from [stock_DaPan] where [date] = " + intdate + ";";
            //object ret = db.GetOneValue(sql, "dapan");
            /*return ret.ToString().Replace("\t","");*/
            DataTable dt = db.GetTable(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = db.GetFirstRow(sql);

                double rize = Math.Round((double)dr["rize"], 4);
                double up = Convert.ToDouble(dr["NUM_RIZE"]);
                double down = Convert.ToDouble(dr["NUM_DOWN"]);
                double ave1 = Convert.ToDouble(dr["ave1"]);
                double ave2 = Convert.ToDouble(dr["ave2"]);
                double ave3 = Convert.ToDouble(dr["ave3"]);
                double ave4 = Convert.ToDouble(dr["ave4"]);
                double ave5 = Convert.ToDouble(dr["ave5"]);
                kpis = rize.ToString();
                kpis += StockApp.seperator.ToString() + Math.Round(up / (up + down), 4);
                kpis += StockApp.seperator.ToString() + Math.Round(down / (up + down), 4);
                //kpis += StockApp.seperator.ToString() + Math.Round(ave1, 4);
                //kpis += StockApp.seperator.ToString() + Math.Round(ave2, 4);
                //kpis += StockApp.seperator.ToString() + Math.Round(ave3, 4);
                //kpis += StockApp.seperator.ToString() + Math.Round(ave4, 4);
                //kpis += StockApp.seperator.ToString() + Math.Round(ave5, 4);
            }
            return kpis;//去除第一个"-"  
        }

        
        
        //设置所有股票的统计数据
        public static void InsertStockDaPan()
        {
            string sql = "IF OBJECT_ID('[stock_DaPan]', 'U') IS NOT NULL drop table [stock_DaPan];";
            db.RunSql(sql);

            sql = "SELECT RANK() over(order by [date]) as seq,[date], isnull(1 + AVG(RIZERATE),0)  as rize, ";
            sql += " isnull(SUM(case when ([RIZERATE] > 0) THEN 1 END),0) AS NUM_RIZE, ";
            sql += " isnull(SUM(case when ([RIZERATE] <= 0) THEN 1 END),0) AS NUM_DOWN, ";
            sql += StockApp.MIN_ZERO + " as ave1, " + StockApp.MIN_ZERO + " as ave2, " + StockApp.MIN_ZERO + " as ave3, " + StockApp.MIN_ZERO + " as ave4, " + +StockApp.MIN_ZERO + " as ave5,  '                       ' as dapan ";
            sql += " into stock_DaPan ";
            sql += " FROM [stock_Full] ";
            sql += " GROUP BY [date] order by [date]";

            db.RunSql(sql);
            UpdateDaPan();
        }
        //更新大盘分数
        private static void UpdateDaPan()
        {
            SQLMassImport itemfile = new SQLMassImport("Overall");

            //从数据库读入基本大盘数据
            string sql = "select * from [stock_DaPan] order by seq";
            System.Data.DataTable table = db.GetTable(sql);
            int size = table.Rows.Count;
            DaPanItem[] dapan_items = new DaPanItem[size];
            
            //初始化overallitem
            for (int i = 0; i < size; i++)
            {
                DataRow row = table.Rows[i];
                DaPanItem item = new DaPanItem();
                item.seq = Convert.ToInt32(row["seq"]);
                item.grade = STATUS_NEUTRAL;
                item.num_rize = Convert.ToInt32(row["num_rize"]);
                item.num_down = Convert.ToInt32(row["num_down"]);
                item.avg1 = 0; 
                item.avg2 = 0;
                item.avg3 = 0;
                item.avg4 = 0;
                item.avg5 = 0;

                item.date = Convert.ToInt32(row["date"]);
                item.rize = Convert.ToDouble(row["RIZE"]) + 1000 * StockApp.MIN_ZERO; //防止为0
                                
                dapan_items[i] = item;                
            }
            //计算平均值
            double[] avg1 = InitAverage(dapan_items, 5);
            double[] avg2 = InitAverage(dapan_items, 10);
            double[] avg3 = InitAverage(dapan_items, 30);
            double[] avg4 = InitAverage(dapan_items, 60);
            double[] avg5 = InitAverage(dapan_items, 100);
            for (int i = 0; i < size; i++)
            {
                DaPanItem item = dapan_items[i];
                item.avg1 = avg1[i];
                item.avg2 = avg2[i];
                item.avg3 = avg3[i];
                item.avg4 = avg4[i];
                item.avg5 = avg5[i];
            }
            //grade默认为NEUTRAL,此处许需要更新
            /*string[] grade = new string[]{STATUS_NEUTRAL};
            for (int i = 0; i < size; i++)
            {
                DaPanItem item = dapan_items[i];
                item.grade = grade[i];
            }*/

            //准备导入数据
            for (int i = 0; i < size; i++)
            {
                string[] filestrs = new string[11];
                DaPanItem item = dapan_items[i];
                filestrs[0] = item.seq.ToString();
                filestrs[1] = item.date.ToString();
                filestrs[2] = item.rize.ToString(); //每日的涨幅
                filestrs[3] = item.num_rize.ToString();
                filestrs[4] = item.num_down.ToString();
                filestrs[5] = Math.Round(item.avg1, 8).ToString();
                filestrs[6] = Math.Round(item.avg2, 8).ToString();
                filestrs[7] = Math.Round(item.avg3, 8).ToString();
                filestrs[8] = Math.Round(item.avg4, 8).ToString();
                filestrs[9] = Math.Round(item.avg5, 8).ToString();
                filestrs[10] = item.grade.ToString();
                itemfile.AddRow(filestrs);
            }
            sql = "truncate table stock_DaPan;";
            db.RunSql(sql);
            itemfile.ImportClose(db, "stock_DaPan");
            
        }
        public double GetRize(int startdate, int enddate)
        {
            string sql = "select * from [stock_DaPan] where [date] >= " + startdate.ToString() + " and [date] <= " + enddate.ToString() + " order by seq";
            System.Data.DataTable table = db.GetTable(sql);
            int size = table.Rows.Count;
            double ret = 1.0;
            for (int i = 0; i < size; i++)
            {
                DataRow dr = table.Rows[i];
                ret = ret * Convert.ToDouble(dr["RIZERATE"]);
            }
            return ret;
            
        }
        
        //更新大盘均线
        //初始化平均值
        private static double[] InitAverage(DaPanItem[] items, int days)
        {
            int size = items.Length;
            double[] ret = new double[size];
            double total = 1.0;

            for (int i = StockApp.START_ATTRIBUTE - days; i < StockApp.START_ATTRIBUTE; i++)
            {
                total = total * items[i].rize;
            }

            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                ret[i] = total * items[i].rize / items[i - days].rize;                 
            }
            return ret;
        }
        //给出大盘的状态, 获得namelist中的位置
        public static int GetGradeIndex(string kpiname)
        {
            for (int i = 0; i < namelist.Length; i++)
            {
                if (namelist[i].Equals(kpiname))
                    return i;
            }
            return -1;
        }

        public static int GetLastDate()
        {
            string sql = "select top 1 [date] from stock_full order by [date] desc";
            int id = Convert.ToInt32(db.GetOneValue(sql));
            return id;
        }
        #region not used
        //没有使用,永远为NEUTRAL
        private static string[] GetGrade(DaPanItem[] items)
        {
            string cur_status = STATUS_NEUTRAL;
            int size = items.Length;
            string[] ret = new string[size];
            for (int i = 0; i < size; i++)
            {
                ret[i] = cur_status;
            }
            return ret;
        }
        //给出某一日大盘的评分
        public static double[] GetDaPanStat(int intdate)
        {
            string sql = "select * from [stock_DaPan] where [date] = " + intdate + ";";
            DataRow dr = db.GetFirstRow(sql);
            double[] ret = new double[3];
            ret[0] = Convert.ToDouble(dr["RIZERATE"]);
            int num_rize = Convert.ToInt32(dr["num_rize"]);
            int num_down = Convert.ToInt32(dr["num_down"]);
            ret[1] = (num_rize + 0.00000001) / (num_rize + num_down + 0.00000001);
            ret[2] = (num_down + 0.00000001) / (num_rize + num_down + 0.00000001);
            return ret;
        }
        #endregion
    }
}
