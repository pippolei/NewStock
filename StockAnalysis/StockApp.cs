using System;
using System.Collections.Generic;
using System.Text;

using StockAnalysis.Panel;
namespace StockAnalysis
{
    class StockApp
    {
        #region 系统可设参数
        //global parameter
        public static int STOCK_START_DATE = 20070101;
        public static int STOCK_START_DATE_SHITE_MONTH = 12;
        public static int BUY_STOCK_NUM = 5;
        //股票数据起始日       
        public static readonly int END_DATE = 99991231;
        public static int getAnalysisStartDate
        {
            get
            {
                int year = Convert.ToInt32(STOCK_START_DATE.ToString().Substring(0, 4));
                return year * 10000 + 101;
            }
        }
        //文本文件地址
        public static string txtSrc = @"C:\StockAnalysis\test";
        //是否productive使用
        public static bool isProductive = false;
        #endregion

        #region 系统常数, 不可设
        //定义最大最小数
        public static readonly int MAX_VALUE = 99999999;
        public static readonly int MIN_VALUE = -99999999;
        public static readonly double MIN_ZERO = 0.0000001;        
        //最少交易日数, 不然忽略此股票
        //分析股票的起始交易日
        public static readonly int START_ANALYSIS = 160;
        //属性起始日
        public static readonly int START_ATTRIBUTE = 130;  
        //交易手续费
        public static readonly double FEE = 0.001;
        //初始金额
        public static readonly double INIT_VALUE = 100000;
        public static readonly char seperator = '#';
        #endregion


        //各种优化参数
        //交易最大天数,达到后自动卖出
        #region defaultSell设置
        public static readonly string[] DEFAULT_SELLs = new string[] {
            "DEF_SELL_SHORT_", "DEF_SELL_MEDIUM_", "DEF_SELL_LONG_","DEF_SELL_END_"
        };

        public static int MAX_HOLD_DAYS_SHORT = 5;
        public static double HIGH_THRESHOLD_SHORT = 0.05;
        public static double LOW_THRESHOLD_SHORT = 0.03;

        public static int MAX_HOLD_DAYS_MEDIUM = 10;
        public static double HIGH_THRESHOLD_MEDIUM = 0.11;
        public static double LOW_THRESHOLD_MEDIUM = 0.06;

        public static int MAX_HOLD_DAYS_LONG = 20;
        public static double HIGH_THRESHOLD_LONG = 0.15;  //涨幅百分比
        public static double LOW_THRESHOLD_LONG = 0.08;   //跌幅百分比


        public static int MAX_HOLD_DAYS_END = 20;
        public static double HIGH_THRESHOLD_END = 100;
        public static double LOW_THRESHOLD_END = 1;
        #endregion




        //所有股票列表
        public static System.Collections.Hashtable allstock = new System.Collections.Hashtable();       
        
        //买卖列表
        public static System.Collections.ArrayList listbuy = new System.Collections.ArrayList();
        public static System.Collections.ArrayList listsell = new System.Collections.ArrayList();
        
        static StockApp()
        {
            //****************************************
            //****************************************
            
            listbuy.Add(new Buy6RizePreEnd());
            listbuy.Add(new Buy6RizePreEnd_Post4_4());
            //listbuy.Add(new BuyJason1_3());
            //listbuy.Add(new BuyBigWin());
            //listbuy.Add(new Buy15Rize());
           

            //listbuy.Add(new BuyIslandReverse());
            //listbuy.Add(new BuyBelowAVE5());
            //listbuy.Add(new BuyBelow35AVE10());
            
            

            //listbuy.Add(new Buy7Down5Rize());
            //listbuy.Add(new Buy8Down4Rize());
            //listbuy.Add(new Buy8Down5Rize());
            //listbuy.Add(new Buy7Down5Rize_3());
            //listbuy.Add(new Buy8Down4Rize_3());
            //listbuy.Add(new Buy8Down5Rize_3());
                                  
            //****************************************
            //listsell.Add(new SellPureDrop());
            listsell.Add(new SellDefault());
            //listsell.Add(new SellBelowATR2());
        }

        public static Buy GetBuy(string name)
        {
            foreach (Buy buy in listbuy)
            {
                if (name.Equals(buy.ToString()))
                {
                    return buy;
                }
            }
            return null;
        }
        public static Sell GetSell(string name)
        {
            foreach (Sell sell in listsell)
            {
                if (name.Equals(sell.ToString()))
                {
                    return sell;
                }
            }
            return null;
            
        }
        
        
        public static StockData GetStock(string code)
        {
            StockData stock = (StockData)allstock[code];
            if (stock.items == null)
            {
                stock = StockSQL.GetStockDetail_2(code, stock.name);
                allstock[code] = stock;
                UtilLog.AddInfo("StockApp", "Stock " + code + " initialized.");
            }
                
            return stock;
        }
        
        public static void InitStockHeader()
        {
            StockApp.allstock.Clear();
            StockData[] stocks = StockSQL.GetStockHeaders();
            int size = stocks.Length;
            for (int i = 0; i < size; i++)
            {
                StockApp.allstock.Add(stocks[i].code, stocks[i]);
            }
        }

    }
}
