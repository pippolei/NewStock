using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StockAnalysis
{
    public class StockData
    {
        //股票基本信息
        public string code;
        public string name;
        public string filename;
        private static DataManager db = new DataManager();
        private double min_value = 0.3;
        //股票每天的数据
        public StockItem[] items;
        private String TAG = "Stock.cs";

        //初始化股票基本信息
        public void Init(string file)
        {
            filename = file;
            StreamReader sr = new StreamReader(file, Encoding.Default);

            String line;
            string[] s;

            if ((line = sr.ReadLine()) != null)
            {
                s = line.Split(' ');
                int size = s.Length;
                if (s.Length < 2)  //从python过来得到的数据
                {
                    code = file.Substring(file.Length - 10, 6);
                    name = code;
                }
                else //从通达信过来的数据
                {
                    code = 's' + s[0];
                    name = s[1]; 
                }
                
            }
            InitItem();
            UtilLog.AddInfo(TAG, code + " init item completed.");
        }
        //初始化股票交易信息
        private void InitItem()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            String line;
            string[] s;
            
            int index = 0;
            while ((line = sr.ReadLine()) != null)
            {

                if (line.Substring(0, 1) != "2") //起始数据应为20XX年, 如果是通达信, 则去除2行, 如果是python, 则去除1行
                {
                    continue;
                }
                s = line.Split('\t');
                try
                {
                    StockItem item = new StockItem();
                    item.index = index;
                    System.Globalization.DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                    dtFormat.ShortDatePattern = "yyyy/Mm/dd";
                    item.date = Convert.ToInt32(Convert.ToDateTime(s[0], dtFormat).ToString("yyyyMMdd"));
                    if (item.date < StockApp.STOCK_START_DATE) continue;
                    item.code = this.code;
                    item.start = Convert.ToDouble(s[1]);
                    item.high = Convert.ToDouble(s[2]);
                    item.low = Convert.ToDouble(s[3]);
                    if (item.low < min_value) min_value = item.low;
                    item.end = Convert.ToDouble(s[4]);
                    item.volume = (int)Convert.ToDouble(s[5]);
                    //股票数据有误
                    if (item.volume < 100 || item.high < 0.3)
                    {
                        continue;
                    }
                    list.Add(item);
                    index++;
                    
                }
                catch 
                {
                    if (line.Trim().Equals("数据来源:通达信")) continue;
                    UtilLog.AddError(TAG, code + " index: " + index.ToString() + " skipped with value " + line);
                }
            }
            items = (StockItem[])list.ToArray(typeof(StockItem));            
        }
        
        //是否把股票列入分析对象
        public bool IsValid()
        {
            //股票交易日期太少
            if (items.Length < StockApp.START_ANALYSIS)
            {
                return false;
            }
            //前复权后股价变为负值
            if (this.min_value < 0.3)
            {
                return false;
            }
            return true;
        }

        

        //将所有股票数据统一存入stock_full
        public static void SetStockFull()
        {
            string sql = "IF OBJECT_ID('[stock_Full]', 'U') IS NOT NULL drop table [stock_Full];";
            db.RunSql(sql);

            int size = StockAttribute.attributes.Length;
            string attrisql = StockAttribute.attributes[0];
            for (int i = 1; i < size; i++)
            {
                attrisql += ",[" + StockAttribute.attributes[i] + "] ";
            }
            size = StockKPI.KPIs.Length;
            for (int i = 0; i < size; i++)
            {
                attrisql += ",[" + StockKPI.KPIs[i] + "] ";
            }


            sql = "select code, [index],[date],start,high,low,[end],volume, ";
            sql += attrisql + " into stock_Full from ";
            sql += " (select code,item.[index],[date],start,high,low,[end],volume,attribute,[value] from ";
            sql += " Stock_item item left join stock_attribute attr on (item.code = attr.stockcode and item.[index]=attr.[index]) ";
            sql += " union ";
            sql += "select code,item.[index],item.[date],start,high,low,[end],volume,KPI as attribute,[value] from ";
            sql += " Stock_item item left join stock_KPI attr on (item.code = attr.stockcode and item.[index]=attr.[index]) ";

            sql += " ) AS stock ";
            sql += " PIVOT (max([value]) For attribute in(" + attrisql + ")) as p;";
            db.RunSql(sql);

        }

        //假设index日买入或者卖出股票, 得到股票之后的表现
        public double getGrade(string type, int index)
        { 
            StockItem item = items[index];
            double sellprice = Convert.ToDouble(item.kpi[type + StockKPI.default_price]);
            return (sellprice - item.end) / item.end;
        }
        //得到当前股票的各种KPI数据
        public string getKPIs(int index)
        {
            StockItem item = items[index];
            string kpis = "";
            foreach (string kpiname in StockKPI.PURE_KPIs)
            {
                kpis += StockApp.seperator.ToString() + item.kpi[kpiname] ;
            }

            return kpis.Substring(1);//去除第一个"-"            
        }
        //得到当前股票的各种KPI数据
        public string getNumKPIs(int index)
        {
            StockItem item = items[index];
            string kpis = "";
            foreach (string kpiname in StockKPI.NUM_KPIs)
            {
                kpis += StockApp.seperator.ToString() + item.kpi[kpiname];
            }

            return kpis.Substring(1);//去除第一个"-"            
        }
        #region not used stock score相关
        /*
        //得到每个股票之后的分析数据
        public double[] getAnalysisValue(int i)
        {
            double[] values = new double[5];
            int stock_length = items.Length;
            int days = StockApp.MAX_HOLD_DAYS_MEDIUM;
            int nextdays;
            if (i + days < stock_length)
            {
                values[0] = items[i + 1].end / items[i].end;
                values[1] = items[i + 2].end / items[i].end;
                nextdays = i + days - 1;                
            }
            else
            {
                values[0] = items[stock_length - 2].end / items[i].end;
                values[1] = items[stock_length - 1].end / items[i].end;
                nextdays = stock_length - 1;                
            }
            values[1] = 0;

            double MFE = ((double)items[nextdays].attributes[StockAttribute.HIGH20] - items[i].end) / items[i].end;
            double MAE = (items[i].end - (double)items[nextdays].attributes[StockAttribute.LOW20]) / items[i].end;
            values[2] = (1 + MFE) * (1 - MAE);
            
            values[3] = Convert.ToDouble(items[nextdays].attributes[StockAttribute.AVE10]) / items[i].end;
            values[4] = items[nextdays].end / items[i].end;
            return values;
        }
        //得到stock score2表的ID
        public static int getScoreIndex(StockData stock, int index)
        {
            int length = StockKPI.PURE_KPIs.Length;
            StockItem[] items = stock.items;
            int[] val = new int[length];
            for (int i = 0; i < length; i++)
            {
                val[i] = (Convert.ToInt32(items[index].kpi[StockKPI.PURE_KPIs[i]]));
            }
            int score = StockSQL.getStockScoreIndex(Util.lastMonth(items[index].date), val);
            return score;
        }
        public static void SetStockScore()
        {
            string sql = "IF OBJECT_ID('[stock_score]', 'U') IS NOT NULL drop table [stock_score];";
            sql += "IF OBJECT_ID('[stock_score2]', 'U') IS NOT NULL drop table [stock_score2];";
            sql += "IF OBJECT_ID('[stock_score_period]', 'U') IS NOT NULL drop table [stock_score_period];";
            sql += "IF OBJECT_ID('[stock_score_all]', 'U') IS NOT NULL drop table [stock_score_all];";
            db.RunSql(sql);

            string[] str = StockKPI.PURE_KPIs;
            sql = "select  *  into Stock_Score from Stock_KPI ";
            sql += " pivot (max([value]) for [KPI] in (GRADE";
            for (int i = 0; i < str.Length; i++)
            {
                sql += " ," + str[i];
            }
            sql += ")) a";
            db.RunSql(sql);
            //sql = "delete from Stock_Score where GRADE > 0.2";
            //db.RunSql(sql);
            string kpi = StockKPI.PURE_KPIs[0];
            for (int i = 1; i < StockKPI.PURE_KPIs.Length; i++)
            {
                kpi += "," + StockKPI.PURE_KPIs[i];
            }
            //按照季度计算stock score
            //sql = "SELECT IDENTITY(int, 1,1) AS ID,CAST(a.intyear AS varchar(4)) + '0' + CAST((1+a.intquarter) AS varchar(1))  as intdate, AVG(GRADE)as GRADE,count(GRADE) as OCCURANCE, " + kpi + " into stock_score_period ";
            //sql += " from   (SELECT *, [DATE]/10000 as intyear, ((([DATE]/100) % 100) - 1) / 3 as intquarter  from Stock_Score)  A  ";
            //sql += " group by a.intyear, a.intquarter, " + kpi;
            //按照月份计算stock score
            sql = "SELECT IDENTITY(int, 1,1) AS ID,T5.* INTO stock_score_period FROM ";
            sql += " (SELECT intdate, AVG(GRADE)as GRADE,count(GRADE) as OCCURANCE, " + kpi;
            sql += "  from   (SELECT *, [DATE]/100 as intdate  from Stock_Score)  T1   ";
            sql += "  group by intdate,  " + kpi;
            sql += "  UNION ";
            sql += "  SELECT 999912 AS intdate, AVG(GRADE)as GRADE,count(GRADE) as OCCURANCE,  " + kpi;
            sql += "  from   Stock_Score  T2   ";
            sql += "  group by " + kpi;
            sql += "  ) T5 order by T5.GRADE desc";
            db.RunSql(sql);






        }
        */
        #endregion
    }
    
}
