using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    public class StockAttribute
    {
        private StockData stock;
        private StockItem[] items;
        private int ATTR_CALC_STARTINDEX;
        public StockAttribute(StockData _stock)
        {
            stock = _stock;
            items = stock.items;
            ATTR_CALC_STARTINDEX = StockApp.START_ATTRIBUTE - 60;
        }
        private static ArrayList attrList = new ArrayList();
        static StockAttribute()
        {
            attrList.Add(StockAttribute.RIZE);           
            attrList.Add(AVE5);
            attrList.Add(AVE10);
            attrList.Add(AVE20);
            attrList.Add(AVE30);
            attrList.Add(AVE60);

            //attrList.Add(AVE_VOLUME10);
            //attrList.Add(AVE_VOLUME20);

            attrList.Add(LOW10);
            attrList.Add(LOW20);

            attrList.Add(HIGH10);
            attrList.Add(HIGH20);
            attrList.Add(HIGH60);
 
            attrList.Add(DIF);
            attrList.Add(DEA);
            //attrList.Add(MACD);

            attrList.Add(POST1);
            attrList.Add(POST2);
            attrList.Add(POST3);
            attrList.Add(POST4);
            attrList.Add(POST5);
        }
        //得到所有计算的股票技术属性
        public static string[] attributes
        {
            get { return (string[])attrList.ToArray(typeof(string)); }
        }
        
        //初始化股票属性信息
        //比较重要属性
        //CANBUY: 第二天是否能够买入
        //SELLPRICE:卖出价格
        public void InitAttribute()
        {   
            initRize();
            initPost(POST1, 1); //定义当前价之后的几天价格
            initPost(POST2, 2);
            initPost(POST3, 3);
            initPost(POST4, 4);
            initPost(POST5, 5);
            //必选属性
            InitAverage(AVE5, 5);
            InitAverage(AVE10, 10);
            InitAverage(AVE20, 20);
            InitAverage(AVE30, 30);
            InitAverage(AVE60, 60);

            //InitAveVolume(AVE_VOLUME10, 10);
            //InitAveVolume(AVE_VOLUME20, 20);

            InitLowEnd(LOW10, 10);
            InitLowEnd(LOW20, 20);

            InitHighEnd(HIGH10, 10);
            InitHighEnd(HIGH20, 20);
            InitHighEnd(HIGH60, 60);

            //macd
            InitEMA(EMA12, 12);
            InitEMA(EMA26, 26);
            InitMACD(EMA12, EMA26, 9);
        }

        #region reviewed
        //当前价格之后5日内的价格
        private void initPost(string key, int days)
        {
            int size = items.Length;
            for (int i = ATTR_CALC_STARTINDEX; i < size - days; i++)
            {
                StockItem item = items[i];
                items[i].attributes[key] = (items[i + days].end - item.end) / item.end;
                
            }
            for (int i = size - days; i < size; i++)
            {
                StockItem item = items[i];
                items[i].attributes[key] = (items[size - 1].end - item.end) / item.end;
                
            }
            
        }
        
        //是否上升
        private void initRize()
        {
            int size = items.Length;
            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                StockItem item = items[i];
                item.attributes[StockAttribute.RIZE] = (item.end - items[i - 1].end) / items[i - 1].end;
            }
        }
        
        //初始化平均值
        private void InitAverage(string key, int days)
        {
            int size = stock.items.Length;
            double total = 0;
            
            for (int i = ATTR_CALC_STARTINDEX - days; i < ATTR_CALC_STARTINDEX; i++)
            {
                total = total + stock.items[i].end;
            }

            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                total = total + stock.items[i].end - stock.items[i - days].end;
                stock.items[i].attributes[key] = (total / days).ToString();
            }
        }
       
        //20日最高收盘价
        private void InitHighEnd(string key, int days)
        {

            int size = stock.items.Length;
            double high = 0;
            int highindex = 0;
            StockItem[] items = stock.items;

            for (int i = ATTR_CALC_STARTINDEX - days; i < ATTR_CALC_STARTINDEX; i++)
            {
                if (high < items[i].end)
                {
                    high = items[i].end;
                    highindex = i;
                }
            }
            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                //最高点过期
                if (i == highindex + days)
                {
                    high = 0;
                    for (int j = highindex + 1; j <= i; j++)
                    {
                        if (high < items[j].end)
                        {
                            high = items[j].end;
                            highindex = j;
                        }
                    }
                }
                else
                {
                    if (high < items[i].end)
                    {
                        high = items[i].end;
                        highindex = i;
                    }
                }
                items[i].attributes[key] = high.ToString();
            }

        }

        //10日最低收盘价
        private void InitLowEnd(string key, int days)
        {

            int size = stock.items.Length;
            double low = StockApp.MAX_VALUE;
            int lowindex = 0;
            StockItem[] items = stock.items;

            for (int i = ATTR_CALC_STARTINDEX - days; i < ATTR_CALC_STARTINDEX; i++)
            {
                if (low > items[i].end)
                {
                    low = items[i].end;
                    lowindex = i;
                }
            }
            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                //最高点过期
                if (i == lowindex + days)
                {
                    low = StockApp.MAX_VALUE;
                    for (int j = lowindex + 1; j <= i; j++)
                    {
                        if (low > items[j].end)
                        {
                            low = items[j].end;
                            lowindex = j;
                        }
                    }
                }
                else
                {
                    if (low > items[i].end)
                    {
                        low = items[i].end;
                        lowindex = i;
                    }
                }
                items[i].attributes[key] = low.ToString();
            }

        }
        #endregion 
        
        

        public static readonly string RIZE = "RIZE";  //涨幅
        public static readonly string AVE5 = "AVE5";
        public static readonly string AVE10 = "AVE10";
        public static readonly string AVE20 = "AVE20";
        public static readonly string AVE30 = "AVE30";
        public static readonly string AVE60 = "AVE60";
        public static readonly string AVE120 = "AVE120";
 
        public static readonly string AVE_VOLUME10 = "AVE_VOLUME10";
        public static readonly string AVE_VOLUME20 = "AVE_VOLUME20";
        public static readonly string HIGH10 = "HIGH10";
        public static readonly string HIGH20 = "HIGH20";
        public static readonly string HIGH60 = "HIGH60";
        public static readonly string HIGH130 = "HIGH130";   
        public static readonly string LOW10 = "LOW10";
        public static readonly string LOW20 = "LOW20";
        public static readonly string LOW130 = "LOW130";
        private static readonly string EMA12 = "EMA12";
        private static readonly string EMA26 = "EMA26";
        public static readonly string DIF = "DIF";
        public static readonly string DEA = "DEA";
        public static readonly string MACD = "MACD";

        public static readonly string POST1 = "POST1";
        public static readonly string POST2 = "POST2";
        public static readonly string POST3 = "POST3";
        public static readonly string POST4 = "POST4";
        public static readonly string POST5 = "POST5";
        
        




        private void InitEMA(string key, int days)
        {   
            int size = items.Length;
            
            double temp = 0;
            for (int i = 0; i < days; i++)
            {
                temp += items[i].end;
            }
            items[days - 1].attributes[key] = temp / days;
            for (int i = days; i < size; i++)
            {
                double a = (days - 1) * Convert.ToDouble(items[i - 1].attributes[key]) + 2 * items[i].end;
                items[i].attributes[key] = Math.Round(((days - 1) * Convert.ToDouble(items[i - 1].attributes[key]) + 2 * items[i].end) / (days + 1), 6);                
            }
        }
        private void InitMACD(string key1, string key2, int day)
        {
            int size = items.Length;

            items[11].attributes[DEA] = 0;
            for (int i = 12; i < size; i++)
            {
                double diff, dea;
                diff = Convert.ToDouble(items[i].attributes[key1]) - Convert.ToDouble(items[i].attributes[key2]);

                dea = Math.Round(((day - 1) * Convert.ToDouble(items[i - 1].attributes[DEA]) + 2 * diff) / (day + 1), 6);
                items[i].attributes[DIF] = diff;
                items[i].attributes[DEA] = dea;
                items[i].attributes[MACD] = 2 * (diff - dea);
            }
        }

        

        #region not used
        /*
        //RSI:相对强弱数据
        //RSI=100-[100/（1+RS）]
        //其中 RS=n天内收市价上涨数之和的平均值/n天内收市价下跌数之和的平均值
        //涨跌为 收盘价比较
        private void InitRS()
        {
            for (int i = StockApp.START_ATTRIBUTE - 30; i < items.Length; i++)
            {
                items[i].attributes[RS] = items[i].end - items[i - 1].end;
            }  
        }
         //成交量均线
        //值为今日成交量与过去N日均量之比
        private void InitAveVolume(string key, int days)
        {
            int size = stock.items.Length;
            double total = 0;
            for (int i = ATTR_CALC_STARTINDEX - days; i < ATTR_CALC_STARTINDEX; i++)
            {
                total = total + stock.items[i].volume;
            }

            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                total = total + stock.items[i].volume - stock.items[i - days].volume;
                stock.items[i].attributes[key] = (stock.items[i].volume * days / total).ToString();
            }
        }
        //默认第二天开盘价就卖,但是如果跌停,则计算卖出价格
        private void initSellPrice(string name)
        {
            int size = items.Length;
            for (int i = ATTR_CALC_STARTINDEX; i < size; i++)
            {
                StockItem item = items[i];
                items[i].attributes[name] = item.end;
                for (int j = i + 1; j < size; j++)
                {
                    if (items[j].start >= items[j - 1].end * 0.9 || items[j].high >= items[j - 1].end * 0.9)
                    {
                        items[i].attributes[name] = items[j].start;
                        break;
                    }
                    
                }
            }
        }
        private void InitRSI(string key, int days)
        {
            
            //rsi计算公式
            //double rs = rswin / rsloss;
            //items[days].attributes[key] = 100 - 100 / (1 + rs);
            //RSI(n)=n日内收盘价涨数平均值÷（n日内收盘价涨数平均值+n日内收盘价跌数平均值）×100
            double rswin = 0, rsloss = 0;
            for (int i = StockApp.START_ATTRIBUTE - days; i < StockApp.START_ATTRIBUTE; i++)
            {
                double rs = (double)items[i].attributes[RS];
                
                if (rs > 0)
                {
                    rswin += rs;
                }
                else 
                {
                    rsloss += rs;
                }
            }
            rswin = rswin / days;
            rsloss = rsloss / days;

            for (int i = StockApp.START_ATTRIBUTE; i < items.Length; i++)
            {
                double rs = (double)items[i].attributes[RS];
                if (rs > 0)
                {
                    rswin = (rswin * (days - 1) + rs) / days;
                    rsloss = rsloss * (days - 1) / days;
                }
                else
                {
                    rswin = (rswin * (days - 1)) / days;
                    rsloss = (rsloss * (days - 1) + rs)/ days;
                }
                //rsloss是负数
                items[i].attributes[key] = 100 * rswin / (rswin - rsloss);            
            }
        }
        //n日平均真实波幅
        //TR=Max（︱现在最高价-现在最低价 ︳，︳现在最高价-上一个的收盘价 ︳，︳现在最低价-上一个的收盘价︳）
        //ATR t=[ATRt-1×(N-1)＋ATR t]÷N
        private void InitTrueRange()
        {   
            for (int i = StockApp.START_ATTRIBUTE - 70; i < items.Length; i++)
            {
                double v1 = items[i].high - items[i].low;
                double v2 = System.Math.Abs(items[i].high - items[i-1].end);
                double v3 = System.Math.Abs(items[i].low - items[i-1].end);
                items[i].attributes[TR] = System.Math.Max(v1, System.Math.Max(v2, v3)) ;
            }
        }
        private void InitTrueRange(string key, int days)
        {
            int size = stock.items.Length;
            double total = 0;
            for (int i = StockApp.START_ATTRIBUTE - days; i < StockApp.START_ATTRIBUTE; i++)
            {
                total = total + (double)items[i].attributes[TR];
            }

            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                total = total + (double)items[i].attributes[TR] - (double)items[i - days].attributes[TR];
                stock.items[i].attributes[key] = (total / days).ToString();
            }
        }
        */
        #endregion



    }
}
