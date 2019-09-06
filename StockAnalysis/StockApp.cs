using System;
using System.Collections.Generic;
using System.Text;

using StockAnalysis.Panel;
namespace StockAnalysis
{
    class StockApp
    {
        #region ϵͳ�������
        //global parameter
        public static int STOCK_START_DATE = 20070101;
        public static int STOCK_START_DATE_SHITE_MONTH = 15;
        //��Ʊ������ʼ��       
        public static readonly int END_DATE = 99991231;
        public static int getAnalysisStartDate
        {
            get
            {
                int year = Convert.ToInt32(STOCK_START_DATE.ToString().Substring(0, 4));
                return year * 10000 + 101;
            }
        }
        //�ı��ļ���ַ
        public static string txtSrc = @"C:\StockAnalysis\test";
        //�Ƿ�productiveʹ��
        public static bool isProductive = false;
        #endregion

        #region ϵͳ����, ������
        //���������С��
        public static readonly int MAX_VALUE = 99999999;
        public static readonly int MIN_VALUE = -99999999;
        public static readonly double MIN_ZERO = 0.00000001;        
        //���ٽ�������, ��Ȼ���Դ˹�Ʊ
        //������Ʊ����ʼ������
        public static readonly int START_ANALYSIS = 160;
        //������ʼ��
        public static readonly int START_ATTRIBUTE = 130;  
        //����������
        public static readonly double FEE = 0.001;
        //��ʼ���
        public static readonly double INIT_VALUE = 100000;
        public static readonly char seperator = '#';
        #endregion


        //�����Ż�����
        //�����������,�ﵽ���Զ�����
        #region defaultSell����
        public static readonly string[] DEFAULT_SELLs = new string[] {
            "DEF_SELL_SHORT_", "DEF_SELL_MEDIUM_", "DEF_SELL_LONG_", "DEF_SELL_END_"
        };
        public static int MAX_HOLD_DAYS_LONG = 60;
        public static double HIGH_THRESHOLD_LONG = 0.42;
        public static double LOW_THRESHOLD_LONG = 0.25;

        public static int MAX_HOLD_DAYS_MEDIUM = 20;
        public static double HIGH_THRESHOLD_MEDIUM = 0.31;
        public static double LOW_THRESHOLD_MEDIUM = 0.18;
        
        public static int MAX_HOLD_DAYS_SHORT = 20;
        public static double HIGH_THRESHOLD_SHORT = 2;
        public static double LOW_THRESHOLD_SHORT = 0.93;

        public static int MAX_HOLD_DAYS_END = 600;
        public static double HIGH_THRESHOLD_END = 100;
        public static double LOW_THRESHOLD_END = 0.99;
        #endregion




        //���й�Ʊ�б�
        public static System.Collections.Hashtable allstock = new System.Collections.Hashtable();       
        
        //�����б�
        public static System.Collections.ArrayList listbuy = new System.Collections.ArrayList();
        public static System.Collections.ArrayList listsell = new System.Collections.ArrayList();
        
        static StockApp()
        {
            //****************************************
            //****************************************
            //listbuy.Add(new BuyRandom());
            listbuy.Add(new Buy6Rize());
            listbuy.Add(new BuyIslandReverse());

            //listbuy.Add(new Buy4Week());
            //listbuy.Add(new BuyBelowAVE5());
            //listbuy.Add(new BuyBelow35AVE10());
            //listbuy.Add(new BuyBigWin());
            
            //listbuy.Add(new BuyLong());
            //listbuy.Add(new BuyLong2());
            
            listbuy.Add(new Buy7Down5Rize());
            //listbuy.Add(new Buy8Down4Rize());
            //listbuy.Add(new Buy8Down5Rize());
            //listbuy.Add(new Buy7Down5Rize_3());
            //listbuy.Add(new Buy8Down4Rize_3());
            //listbuy.Add(new Buy8Down5Rize_3());
                                  
            //****************************************
            listsell.Add(new SellPureDrop());
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
