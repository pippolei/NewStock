using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    class DefaultSell
    {
        public int sellindex;
        public double sellprice;
        public int selldate;

    }
    public class StockKPI
    {
        private StockData stock;
        private StockItem[] items;
        public static object[] KPIs;
        public static string[] PURE_KPIs;
        public static string[] NUM_KPIs;

        public static readonly string default_index = "index";
        public static readonly string default_date = "date";
        public static readonly string default_price = "price";


        
        public StockKPI(StockData _stock)
        {
            stock = _stock;
            items = stock.items;
        }

        
        static StockKPI()
        {   
            PURE_KPIs = new string[] { 
                END_ABOVE_AVE_10, // 收盘价大于10日均线
                END_ABOVE_AVE_20,
                END_ABOVE_AVE_60,
                A10_ABOVE_20, //10日均线大于20日均线
                A10_ABOVE_60,
                A20_ABOVE_60,
                A10V_ABOVE_60V,
                
                END_FAR_ABOVE_05, //收盘>5日
                END_FAR_BELOW_05, 
                END_ABOVE_HIGH_60, 
                END_BELOW_LOW_60,

                CROSS_AVE_5,   //收盘价横跨超越５日线
                CROSS_AVE_10,　//收盘价横跨超越１０日线　
                CROSS_AVE_20,　//收盘价横跨超越２０日线　
                CROSS_AVE_60,　//收盘价横跨超越６０日线

                START_RIZE,     //较
                START_RIZE_BIG,
                END_RIZE_START,

                IS_BIG_RIZE, //当日涨幅>4%
                IS_MEDIUM_RIZE //当日涨幅>2%
                //ABOVE_HALF_130_4,  BELOW_HALF_130_5  //股价高于近期130高点的60%或者低于35%
                //,GOOD_MACD
            };

            NUM_KPIs = new string[] { 
                RIZE1,
                RIZE2,
                RIZE3,
                RIZE4,
                RIZE5
                
            };

            ArrayList list = new ArrayList();
            foreach (string s in PURE_KPIs)
            {
                list.Add(s);
            }
            foreach (string s in NUM_KPIs)
            {
                list.Add(s);
            }

            
            for (int i = 0; i < StockApp.DEFAULT_SELLs.Length; i++)
            {
                list.Add(StockApp.DEFAULT_SELLs[i] + default_index);
                list.Add(StockApp.DEFAULT_SELLs[i] + default_date);
                list.Add(StockApp.DEFAULT_SELLs[i] + default_price);
            }

            KPIs = list.ToArray();
        }
        #region NUM_KPI
        //NUM_KPI属性
        public static readonly string DAPAN1 = "DAPAN1";
        public static readonly string DAPAN2 = "DAPAN2";
        public static readonly string DAPAN_RIZE = "DAPAN_RIZE";
        public static readonly string MACD1 = "MACD1";
        public static readonly string MACD2 = "MACD2";
        public static readonly string AVG_VOLUME = "AVG_VOLUME";
        public static readonly string ATR2 = "ATR2"; //日波动>2%
        public static readonly string ATR3 = "ATR3"; //日波动>3%

        public static readonly string RIZE1 = "RIZE1";
        public static readonly string RIZE2 = "RIZE2";
        public static readonly string RIZE3 = "RIZE3";
        public static readonly string RIZE4 = "RIZE4";
        public static readonly string RIZE5 = "RIZE5";


        public void InitNUM_KPI()
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                //items[i].kpi[MACD1] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.DEA]),4);
                //items[i].kpi[MACD2] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.DIF]),4);
                //items[i].kpi[AVG_VOLUME] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.AVE_VOLUME20]),4);
                //items[i].kpi[RIZE1] = Math.Round((items[i].high - items[i].end) / items[i].end, 8);
                items[i].kpi[RIZE1] = 0;
                items[i].kpi[RIZE2] = 0;
                items[i].kpi[RIZE3] = 0;
                items[i].kpi[RIZE4] = 0;
                items[i].kpi[RIZE5] = 0;
                if (items[i].end < 0.97 * items[i - 1].end)
                {
                    items[i].kpi[RIZE1] = 1;
                }
                else if (items[i].end < 0.99 * items[i - 1].end)
                {
                    items[i].kpi[RIZE2] = 1;
                }
                else if (items[i].end < 1.01 * items[i - 1].end)
                {
                    items[i].kpi[RIZE3] = 1;
                }
                else if (items[i].end < 1.03 * items[i - 1].end)
                {
                    items[i].kpi[RIZE4] = 1;
                }
                else
                {
                    items[i].kpi[RIZE5] = 1;
                }
            }
            
        }
        #endregion

        //考虑止损
        public void Init_Default_Sell2(string sellname, int sellday, double high_threshold, double low_threshold)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size - sellday; i++)
            {

                double now = items[i].end;
                DefaultSell sellitem = new DefaultSell();
                sellitem.sellindex = i + sellday;
                //sellitem.sellprice = items[i + sellday].end;
                sellitem.sellprice = (i + sellday < size - 1) ? stock.items[i + sellday + 1].start : items[i + sellday].end;
                sellitem.selldate = items[i + sellday].date;

                for (int j = i + 1; j < i + sellday; j++)
                {
                    double later = items[j].end;
                    if (later - now * (1 + high_threshold) > StockApp.MIN_ZERO
                        || now * (1 - low_threshold) - later > StockApp.MIN_ZERO)
                    {
                        sellitem.sellindex = j;
                        sellitem.sellprice = (j < size - 1) ? stock.items[j + 1].start : items[j].end;
                        sellitem.selldate = items[j].date;
                        break;
                    }
                }
                items[i].kpi[sellname + default_index] = sellitem.sellindex;
                items[i].kpi[sellname + default_date] = sellitem.selldate;
                items[i].kpi[sellname + default_price] = sellitem.sellprice;

            }
            for (int i = Math.Max(size - sellday, 0); i < size; i++)
            {
                DefaultSell sellitem = new DefaultSell();
                sellitem.sellindex = size - 1;
                sellitem.sellprice = items[size - 1].end;
                sellitem.selldate = items[size - 1].date;
                items[i].kpi[sellname + default_index] = sellitem.sellindex;
                items[i].kpi[sellname + default_date] = sellitem.selldate;
                items[i].kpi[sellname + default_price] = sellitem.sellprice;
            }
        }

        //初始化股票均线信息
        public void InitKPI()
        {
            //必选属性
            //如果没有触发止盈止损, 则N日自动卖出
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[0], StockApp.MAX_HOLD_DAYS_SHORT, StockApp.HIGH_THRESHOLD_SHORT, StockApp.LOW_THRESHOLD_SHORT);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[1], StockApp.MAX_HOLD_DAYS_MEDIUM, StockApp.HIGH_THRESHOLD_MEDIUM, StockApp.LOW_THRESHOLD_MEDIUM);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[2], StockApp.MAX_HOLD_DAYS_LONG, StockApp.HIGH_THRESHOLD_LONG, StockApp.LOW_THRESHOLD_LONG);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[3], StockApp.MAX_HOLD_DAYS_END, StockApp.HIGH_THRESHOLD_END, StockApp.LOW_THRESHOLD_END);
            //收盘价和均线比较
            Init_END_ABOVE_AVE(END_ABOVE_AVE_10, StockAttribute.AVE10);
            Init_END_ABOVE_AVE(END_ABOVE_AVE_20, StockAttribute.AVE20);
            Init_END_ABOVE_AVE(END_ABOVE_AVE_60, StockAttribute.AVE60);

            //收盘价横跨均线
            Init_END_CROSS_AVE(CROSS_AVE_5, StockAttribute.AVE5);
            Init_END_CROSS_AVE(CROSS_AVE_10, StockAttribute.AVE10);
            Init_END_CROSS_AVE(CROSS_AVE_20, StockAttribute.AVE20);
            Init_END_CROSS_AVE(CROSS_AVE_60, StockAttribute.AVE60);
            //均线之间比较
            Init_AVE_COMPARISON(A10_ABOVE_20, StockAttribute.AVE10, StockAttribute.AVE20);
            Init_AVE_COMPARISON(A10_ABOVE_60, StockAttribute.AVE10, StockAttribute.AVE60);
            Init_AVE_COMPARISON(A20_ABOVE_60, StockAttribute.AVE20, StockAttribute.AVE60);
            //成交量均线
            Init_AVE_COMPARISON(A10V_ABOVE_60V, StockAttribute.AVE_VOLUME10, StockAttribute.AVE_VOLUME60, 1.0, 1.5);

            //收盘价与均线比例的比较
            Init_FAR_ABOVE_BELOW_AVE(END_FAR_ABOVE_05, StockAttribute.AVE5, 1.06);
            Init_FAR_ABOVE_BELOW_AVE(END_FAR_BELOW_05, StockAttribute.AVE5, 0.94);

            Init_FAR_ABOVE_BELOW_AVE(END_ABOVE_HIGH_60, StockAttribute.HIGH60, 0.85);
            Init_FAR_ABOVE_BELOW_AVE(END_BELOW_LOW_60, StockAttribute.LOW60, 1.35);

            
            //其它KPI属性
            Init_Other_Attribute();
            //股价大于最高价的60%
            //ABOVE_Half130High(0.60);
            //股价低于最高价的40%
            //BELOW_Half130High(0.45);
            //MACD和均线属于好的趋势,好的趋势就是多头发散排列
            //Init_GOOD_TREND(GOOD_MACD);
            InitNUM_KPI();
        }

        

        #region PURE_KPI
        

        #region 必选属性
        //当日穿均XIAnn
        public static readonly string CROSS_AVE_5 = "CROSS_AVE_5";
        public static readonly string CROSS_AVE_10 = "CROSS_AVE_10";
        public static readonly string CROSS_AVE_20 = "CROSS_AVE_20";
        public static readonly string CROSS_AVE_60 = "CROSS_AVE_60";
        private void Init_END_CROSS_AVE(string name, string attribute)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (items[i].end - Convert.ToDouble(items[i].attributes[attribute]) > StockApp.MIN_ZERO
                    && items[i - 1].end - Convert.ToDouble(items[i].attributes[attribute]) < StockApp.MIN_ZERO
                    )
                {
                    items[i].kpi[name] = 1;
                }
                else
                {
                    items[i].kpi[name] = 0;
                }

            }
        }
        //均线多头排列
        //均线多头
        public static readonly string END_ABOVE_AVE_10 = "END_ABOVE_AVE_10";
        public static readonly string END_ABOVE_AVE_20 = "END_ABOVE_AVE_20";
        public static readonly string END_ABOVE_AVE_60 = "END_ABOVE_AVE_60"; 
        private void Init_END_ABOVE_AVE(string name, string attribute)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (items[i].end - Convert.ToDouble(items[i].attributes[attribute]) > StockApp.MIN_ZERO)
                {
                    items[i].kpi[name] = 1;
                }
                else
                {
                    items[i].kpi[name] = 0;
                }

            }
        }
        //均线之间的比较
        public static readonly string A10_ABOVE_20 = "A10_ABOVE_20";
        public static readonly string A10_ABOVE_60 = "A10_ABOVE_60";
        public static readonly string A20_ABOVE_60 = "A20_ABOVE_60";
        public static readonly string A10V_ABOVE_60V = "A10V_ABOVE_60V";

        private void Init_AVE_COMPARISON(string name, string attribute1, string attribute2, double factor1 = 1, double factor2 = 1)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (Convert.ToDouble(items[i].attributes[attribute1]) * factor1 - Convert.ToDouble(items[i].attributes[attribute2]) * factor2 > StockApp.MIN_ZERO)
                {
                    items[i].kpi[name] = 1;
                }
                else
                {
                    items[i].kpi[name] = 0;
                }

            }
        }
        //收盘价大幅高于均线
        public static readonly string END_FAR_ABOVE_05 = "END_FAR_ABOVE_05";
        public static readonly string END_FAR_BELOW_05 = "END_FAR_BELOW_05";
        public static readonly string END_ABOVE_HIGH_60 = "END_ABOVE_HIGH_60";
        public static readonly string END_BELOW_LOW_60 = "END_BELOW_LOW_60";
        private void Init_FAR_ABOVE_BELOW_AVE(string name, string attribute, double factor)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (factor > 1)
                {
                    if (items[i].end - Convert.ToDouble(items[i].attributes[attribute]) * factor > StockApp.MIN_ZERO)
                    {
                        items[i].kpi[name] = 1;
                    }
                    else
                    {
                        items[i].kpi[name] = 0;
                    }
                }
                else
                {
                    if (items[i].end - Convert.ToDouble(items[i].attributes[attribute]) * factor < StockApp.MIN_ZERO)
                    {
                        items[i].kpi[name] = 1;
                    }
                    else
                    {
                        items[i].kpi[name] = 0;
                    }
                }
                
                
            }
        }
        //n日自动卖出,当初如果出现高点或者低点,则止盈或者止损
        
        


        public static readonly string IS_BIG_RIZE = "IS_BIG_RIZE";
        public static readonly string IS_MEDIUM_RIZE = "IS_MEDIUM_RIZE";
        public static readonly string START_RIZE = "START_RIZE";
        public static readonly string END_RIZE_START = "END_RIZE_START";
        public static readonly string START_RIZE_BIG = "START_RIZE_BIG";

        private void Init_Other_Attribute()
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (Convert.ToDouble(items[i].attributes[StockAttribute.RIZERATE]) - 0.04 > StockApp.MIN_ZERO)
                {
                    items[i].kpi[IS_BIG_RIZE] = 1;
                }
                else
                {
                    items[i].kpi[IS_BIG_RIZE] = 0;
                }
                if (Convert.ToDouble(items[i].attributes[StockAttribute.RIZERATE]) - 0.02 > StockApp.MIN_ZERO)
                {
                    items[i].kpi[IS_MEDIUM_RIZE] = 1;
                }
                else
                {
                    items[i].kpi[IS_MEDIUM_RIZE] = 0;
                }
                if (items[i - 1].end < items[i].start)
                {
                    items[i].kpi[START_RIZE] = 1;
                }
                else
                {
                    items[i].kpi[START_RIZE] = 0;
                }
                if (items[i - 1].end * 1.02 < items[i].start)
                {
                    items[i].kpi[START_RIZE_BIG] = 1;
                }
                else
                {
                    items[i].kpi[START_RIZE_BIG] = 0;
                }
                if (items[i].end - items[i].start > StockApp.MIN_ZERO)
                {
                    items[i].kpi[END_RIZE_START] = 1;
                }
                else
                {
                    items[i].kpi[END_RIZE_START] = 0;
                }
            }
            
        }


        
       

        //MACD或者均线开始上扬切开始发散
        public static readonly string GOOD_MACD = "GOOD_MACD";
        private void Init_GOOD_TREND(string key)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                double v1 = Convert.ToDouble(items[i].attributes[StockAttribute.DIF]);
                double v2 = Convert.ToDouble(items[i].attributes[StockAttribute.DEA]);

                if (v1 > v2)
                {
                    items[i].kpi[key] = 1;
                }
                else
                {
                    items[i].kpi[key] = 0;
                }
                
            }
        }        
        #endregion
        #endregion
        #region not used

        #endregion


















    }
}
