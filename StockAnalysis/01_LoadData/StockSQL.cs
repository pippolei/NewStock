using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace StockAnalysis
{
    class StockSQL
    {     
        private static DataManager db = new DataManager();
        //private static String TAG = "StockSQL";
        public static readonly string TABLE_RULE_BUY0 = "Rule_Buy0";
        public static readonly string TABLE_RULE_BUY = "Rule_Buy";

        public static readonly string TABLE_STOCK_ITEM = "Stock_Item";
        public static readonly string TABLE_STOCK_ATTRI = "Stock_Attribute";
        public static readonly string TABLE_STOCK_KPI = "Stock_KPI";
        public static readonly string TABLE_ANALYZE = "Ope_Analysis";
        public static readonly string TABLE_ANALYZE2 = "Ope_Analysis2";
        public static readonly string TABLE_SIMULATE_ITEM = "Ope_Simulate_Item";

        //得到所有股票基本信息
        public static StockData[] GetStockHeaders()
        {
            string sql = "select * from Stock_header order by code";
            System.Data.DataTable table = db.GetTable(sql);
            int size = table.Rows.Count;
            StockData[] header = new StockData[size];
            for (int i = 0; i < size; i++)
            {
                DataRow row = table.Rows[i];
                StockData stock = new StockData();
                stock.name = (string)row["name"];
                stock.code = (string)row["code"];
                header[i] = stock;
            }
            return header;
        }
        //更新Stock数据
        public static void InsertStockWithItem(StockData stock)
        {
            int size = stock.items.Length;
            string code = stock.code;
            StockItem[] items = stock.items;
            SQLMassImport itemfile = new SQLMassImport("Item");
            SQLMassImport attrifile = new SQLMassImport("Attribute");
            SQLMassImport kpifile = new SQLMassImport("KPI");


            StockItem lastitem = stock.items[stock.items.Length - 1];
            string sql = "insert into stock_header(code, name, lastindex, lastprice) values('";
            sql += stock.code + "','" + stock.name + "','" + lastitem.index;
            sql += "', '" + lastitem.end + "');";
            db.RunSql(sql);

            for (int i = 0; i < size; i++)
            {
                StockItem item = items[i];
                string[] filestrs = new string[8];
                filestrs[0] = code;
                filestrs[1] = i.ToString();
                filestrs[2] = item.date.ToString();
                filestrs[3] = item.start.ToString();
                filestrs[4] = item.high.ToString();
                filestrs[5] = item.low.ToString();
                filestrs[6] = item.end.ToString();
                filestrs[7] = item.volume.ToString();
                itemfile.AddRow(filestrs);

                foreach (object key in items[i].attributes.Keys)
                {
                    string[] attristrs = new string[4];
                    attristrs[0] = code;
                    attristrs[1] = i.ToString();
                    attristrs[2] = key.ToString();
                    attristrs[3] = items[i].attributes[key].ToString();
                    attrifile.AddRow(attristrs);
                }

                foreach (object key in items[i].kpi.Keys)
                {
                    string[] attristrs = new string[5];
                    attristrs[0] = code;
                    attristrs[1] = i.ToString();
                    attristrs[2] = item.date.ToString();
                    attristrs[3] = key.ToString();
                    attristrs[4] = items[i].kpi[key].ToString();
                    kpifile.AddRow(attristrs);
                }

                
            }
            itemfile.ImportClose(db, TABLE_STOCK_ITEM);
            attrifile.ImportClose(db, TABLE_STOCK_ATTRI);
            kpifile.ImportClose(db, TABLE_STOCK_KPI);

        }

        

        //清空数据库股票数据
        public static void DeleteStock()
        {
            db.RunSql("truncate table stock_header;");
            db.RunSql("truncate table Stock_Item;");
            db.RunSql("truncate table Stock_Attribute;");
            db.RunSql("truncate table Stock_KPI;");            
            try
            {
                db.RunSql("truncate table Stock_DaPan");
                db.RunSql("truncate table Stock_Score");
                db.RunSql("truncate table stock_score_period");
                db.RunSql("truncate table Stock_Full");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
        //清空数据库买卖数据
        public static void DeleteRule()
        {
            db.RunSql("truncate table  Rule_Buy0;");
            db.RunSql("truncate table  Rule_Buy;");
        }

        public static void DeleteRuleFilter()
        {
            db.RunSql("truncate table  Rule_Filter;");
            db.RunSql("truncate table  Rule_Filter_Dapan;");

        }
        public static void DeleteAnalysis()
        {
            db.RunSql("truncate table  Ope_Analysis;");
            db.RunSql("truncate table  Ope_Analysis2;");
        }
        public static void DeleteSimulate()
        {
            db.RunSql("truncate table Ope_Simulate");
            db.RunSql("truncate table Ope_Simulate_Item");
        }

        private static System.Collections.Hashtable stock_score = new System.Collections.Hashtable();
        private static System.Collections.Hashtable stock_KPI = new System.Collections.Hashtable();
        
        //通过ID值得到stock score2里面的KPI值
        public static string[] getStockScoreKPI(int index)
        {
            if (stock_KPI.Count == 0)
            {
                string sql = "select * from stock_score_period";
                DataTable table = db.GetTable(sql);
                int col_len = table.Columns.Count;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    int key = Convert.ToInt32(row[0]);
                    string[] vals = new string[col_len - 1];
                    for (int j = 1; j < col_len; j++)
                    {
                        vals[j - 1] = row[j].ToString();
                    }
                    stock_KPI[key] = vals;
                }
            }
            
            try
            {
                string[] ret = (string[])stock_KPI[index];
                return ret;
            }
            catch
            {
                return new string[0];
            }

        }
        
        
        //2018-03-18 得到所有股票详细信息
        public static StockData GetStockDetail_2(string code, string name)
        {
            StockData stock = new StockData();
            stock.code = code;
            stock.name = name;

            string sql = "select * from stock_Full where code = '" + code + "' order by [index];";
            System.Data.DataTable table = db.GetTable(sql);

            int size = table.Rows.Count;
            StockItem[] items = new StockItem[size];
            stock.items = items;
            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockItem();
                items[i].code = code;
                items[i].date = (int)row["date"];
                items[i].index = (int)row["index"];
                items[i].start = (double)row["start"];
                items[i].high = (double)row["high"];
                items[i].low = (double)row["low"];
                items[i].end = (double)row["end"];
                items[i].volume = (long)row["volume"];

                if (i >= StockApp.START_ATTRIBUTE)
                {
                    foreach (string attri in StockAttribute.attributes)
                    {
                        items[i].attributes[attri] = row[attri];
                    }
                    foreach (string kpi in StockKPI.KPIs)
                    {
                        items[i].kpi[kpi] = row[kpi];
                    }
                    
                }

            }
            return stock;
        }

       
        

        
        

        

        #region not used
        /*
        public static void ExportStock(Stock stock)
        {
            int size = stock.items.Length;
            string code = stock.code;
            StockItem[] items = stock.items;
            SQLMassImport itemfile = new SQLMassImport("Stock\\" + code);

            int attr_size = StockAttribute.attributes.Length;
            int kpi_size = StockKPI.KPIs.Length;
            

            string[] header = new string[8 + attr_size + kpi_size];
            header[0] = "code";
            header[1] = "index";
            header[2] = "date";
            header[3] = "start";
            header[4] = "high";
            header[5] = "low";
            header[6] = "end";
            header[7] = "volume";
            for (int j = 0; j < attr_size; j++)
            {
                object key = StockAttribute.attributes[j];
                header[8 + j] = key.ToString();
            }
            for (int j = 0; j < kpi_size; j++)
            {
                object key = StockKPI.KPIs[j];
                header[8 + attr_size + j] = key.ToString();
            }
            for (int j = 0; j < kpi_size; j++)
            {
                object key = StockKPI.KPIs[j];
                header[8 + attr_size + kpi_size + j] = key.ToString();
            }
            itemfile.AddRow(header);

            for (int i = 0; i < size; i++)
            {
                StockItem item = items[i];
                string[] filestrs = new string[8 + attr_size + kpi_size];
                filestrs[0] = code;
                filestrs[1] = i.ToString();
                filestrs[2] = item.date.ToString();
                filestrs[3] = item.start.ToString();
                filestrs[4] = item.high.ToString();
                filestrs[5] = item.low.ToString();
                filestrs[6] = item.end.ToString();
                filestrs[7] = item.volume.ToString();

                if (i >= StockApp.START_ATTRIBUTE)
                {
                    for (int j = 0; j < attr_size; j++)
                    {
                        object key = StockAttribute.attributes[j];
                        filestrs[8 + j] = item.attributes[key].ToString();

                    }
                    for (int j = 0; j < kpi_size; j++)
                    {
                        object key = StockKPI.KPIs[j];
                        filestrs[8 + attr_size + j] = item.kpi[key].ToString();
                    }
                    
                }
                itemfile.AddRow(filestrs);
            }
        }
        //得到在stock score2表里的ID值
        public static int getStockScoreIndex(int intdate, int[] val)
        {
            int length = val.Length;
            //一次性初始化stock_score
            if (stock_score.Count == 0)
            {                
                string sql = "select * from stock_score_period";
                DataTable table = db.GetTable(sql);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    //第一列是日期
                    string key = Convert.ToString(row[1]);
                    //将每个KPI的值都放入key
                    for (int j = 0; j < length; j++)
                    {
                        key += "-" + row[StockKPI.PURE_KPIs[j]];                        
                    }
                    stock_score[key] = row[0];
                    UtilLog.AddInfo(TAG, "stock_score: " + key + "  value: " + row[0].ToString());
                }
            }
            
            string search = intdate.ToString();
            for (int j = 0; j < length; j++)
            {
                search += "-" + val[j];
            }
            try
            {
                object obj = stock_score[search];
                if (obj != null)
                {
                    return (int)obj;
                }
                //如果没找到上一个时间段的score,使用default表的score
                else
                {
                    search = "999912";
                    for (int j = 0; j < length; j++)
                    {
                        search += "-" + val[j];
                    }
                    obj = stock_score[search];
                }
                return (int)obj;
            }
            catch
            {
                UtilLog.AddError(TAG, "getStockScoreIndex: No score for search " + search);
                return -1;
            }
            
        } 
        public static Stock GetStockDetail(string code, string name)
        {
            Stock stock = new Stock();
            stock.code = code;
            stock.name = name;

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

            string sql = "select [index],[date],start,high,low,[end],volume, ";
            sql += attrisql + " into #tmp_stock_detail from ";
            sql += " (select code,item.[index],[date],start,high,low,[end],volume,attribute,[value] from ";
            sql += " Stock_item item left join stock_attribute attr on (item.code = attr.stockcode and item.[index]=attr.[index]) where code = '" + code + "' ";
            sql += " union ";
            sql += "select code,item.[index],[date],start,high,low,[end],volume,KPI as attribute,[value] from ";
            sql += " Stock_item item left join stock_KPI attr on (item.code = attr.stockcode and item.[index]=attr.[index]) where code = '" + code + "' ";
            sql += " ) AS stock ";
            sql += " PIVOT (max([value]) For attribute in(" + attrisql + ")) as p; select * from #tmp_stock_detail order by [index];";
            System.Data.DataTable table = db.GetTable(sql);

            size = table.Rows.Count;
            StockItem[] items = new StockItem[size];
            stock.items = items;
            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockItem();
                items[i].date = (int)row["date"];
                items[i].index = (int)row["index"];
                items[i].start = (double)row["start"];
                items[i].high = (double)row["high"];
                items[i].low = (double)row["low"];
                items[i].end = (double)row["end"];
                items[i].volume = (long)row["volume"];

                if (i >= StockApp.START_ATTRIBUTE)
                {
                    foreach (string attri in StockAttribute.attributes)
                    {
                        items[i].attributes[attri] = row[attri];
                    }
                    foreach (string kpi in StockKPI.KPIs)
                    {
                        items[i].kpi[kpi] = row[kpi];
                    }
                }

            }
            return stock;
        }
        
        public static double getPureKPI(string code, string kpi)
        {
            string sql = "select avg(value) from (select top 60 * from Stock_KPI where stockcode = '" + code + "' and KPI = '" + kpi + "' and value < 50 order by [index] desc) A;";
            DataRow dr = db.GetFirst(sql);
            double value;
            try
            {
                value = (double)dr[0];
            }
            catch(Exception)
            {
                value = 0;
            }
            return value;


        }
        public static Stock GetStockWithKPI(string code, string name)
        {
            Stock stock = new Stock();
            stock.code = code;
            stock.name = name;

            string sql = "select * from stock_Full where code = '" + code + "' order by [index];";
            System.Data.DataTable table = db.GetTable(sql);

            int size = table.Rows.Count;
            StockItem[] items = new StockItem[size];
            stock.items = items;
            for (int i = 0; i < size; i++)
            {
                System.Data.DataRow row = table.Rows[i];
                items[i] = new StockItem();
                items[i].date = (int)row["date"];
                items[i].index = (int)row["index"];
                items[i].start = (double)row["start"];
                items[i].high = (double)row["high"];
                items[i].low = (double)row["low"];
                items[i].end = (double)row["end"];
                items[i].volume = (long)row["volume"];

                if (i >= StockApp.START_ATTRIBUTE)
                {
                    foreach (string kpi in StockKPI.KPIs)
                    {
                        items[i].kpi[kpi] = row[kpi];
                    }
                }

            }
            return stock;
        }
        public static StockItem GetItemFromIndex(string code, int index)
        {
            string sql = "select top 1 * from stock_item where code = '" + code + "'";
            sql += " and [index] <= '" + index + "' order by [index] desc; ";

            System.Data.DataRow row = db.GetFirst(sql);
            if (row == null)
            {
                UtilLog.AddWarn(TAG, "GetItemFromIndex: NO result for " + code + " at " + index);
                return null;
            }
            return GetItemFromRecord(row);
        }
        //从数据库中生成Item
        private static StockItem GetItemFromRecord(DataRow row)
        {
            StockItem item = new StockItem();
            item.start = (double)row["start"];
            item.high = (double)row["high"];
            item.low = (double)row["low"];
            item.end = (double)row["end"];
            item.volume = (long)row["volume"];
            item.index = (int)row["index"];
            item.date = (int)row["date"];
            return item;
        }
        public static StockItem GetItemBeforeDate(string code, int date)
        {
            string sql = "select top 1 * from stock_item where code = '" + code + "'";
            sql += " and date <= '" + date + "'  order by [index] desc";

            System.Data.DataRow row = db.GetFirst(sql);
            if (row == null)
            {
                UtilLog.AddWarn(TAG, "GetItemBeforeDate: NO result for " + code + " before " + date);
                return null;
            }
            return GetItemFromRecord(row);
        }
        public static StockItem GetItemAfterDate(string code, int date)
        {
            string sql = "select top 1 * from stock_item where code = '" + code + "'";
            sql += " and date >= '" + date + "'  order by [index]";

            System.Data.DataRow row = db.GetFirst(sql);
            if (row == null)
            {
                UtilLog.AddWarn(TAG, "GetItemAfterDate: NO result for " + code + " after " + date);
                return null;
            }
            return GetItemFromRecord(row);
        }
        

        public static StockItem GetItemAttributeFromIndex_2(string code, int index)
        {   
            string sql = "select * from stock_Full where code = '" + code + "' and [index] = '" + index + "';";
            System.Data.DataRow row = db.GetFirst(sql);
            if (row == null)
            {
                UtilLog.AddWarn(TAG, "GetItemAttributeFromIndex: NO result for " + code + " at " + index);
                return null;
            }
            StockItem item = new StockItem();
            item.start = (double)row["start"];
            item.high = (double)row["high"];
            item.low = (double)row["low"];
            item.end = (double)row["end"];
            item.volume = (long)row["volume"];
            item.index = (int)row["index"];
            item.date = (int)row["date"];
            foreach (string s in StockAttribute.attributes)
            {
                item.attributes[s] = row[s];
            }
            foreach (string s in StockKPI.KPIs)
            {
                item.kpi[s] = row[s];
            }
            foreach (string s in StockNextItem.NEXT_KPIs)
            {
                item.nexts[s] = row[s];
            }
            return item;
        }*/



        
        /*
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
        /*
        public static void SetStockAll()
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
        */
        #endregion






    }
}
