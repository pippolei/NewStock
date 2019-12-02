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
                ABOVE_AVE_10, // ���̼۴���10�վ���
                ABOVE_AVE_20,
                ABOVE_AVE_60,
                A10_ABOVE_20,
                A10_ABOVE_60,
                A20_ABOVE_60
                //ABOVE_HALF_130_4,  BELOW_HALF_130_5  //�ɼ۸��ڽ���130�ߵ��60%���ߵ���35%
                //,GOOD_MACD
            };

            NUM_KPIs = new string[] { 
                MACD1, MACD2,
                AVG_VOLUME,
                RIZE1,//������ߵ������̼۵��Ƿ�
                RIZE2 //�������̼�����͵���Ƿ�
                
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
        //NUM_KPI����
        public static readonly string DAPAN1 = "DAPAN1";
        public static readonly string DAPAN2 = "DAPAN2";
        public static readonly string DAPAN_RIZE = "DAPAN_RIZE";
        public static readonly string MACD1 = "MACD1";
        public static readonly string MACD2 = "MACD2";
        public static readonly string AVG_VOLUME = "AVG_VOLUME";
        public static readonly string RIZE1 = "RIZE1";
        public static readonly string RIZE2 = "RIZE2";


        public void InitNUM_KPI()
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                items[i].kpi[MACD1] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.DEA]),4);
                items[i].kpi[MACD2] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.DIF]),4);
                items[i].kpi[AVG_VOLUME] = Math.Round(Convert.ToDouble(items[i].attributes[StockAttribute.AVE_VOLUME20]),4);
                items[i].kpi[RIZE1] = Math.Round((items[i].high - items[i].end) / items[i].end,4);
                items[i].kpi[RIZE2] = Math.Round((items[i].end - items[i].low) / items[i].end,4);
            }
            
        }
        #endregion
        #region PURE_KPI
        //��ʼ����Ʊ������Ϣ
        public void InitKPI()
        {
            //��ѡ����
            //���û�д���ֹӯֹ��, ��N���Զ�����
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[0], StockApp.MAX_HOLD_DAYS_SHORT, StockApp.HIGH_THRESHOLD_SHORT, StockApp.LOW_THRESHOLD_SHORT);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[1], StockApp.MAX_HOLD_DAYS_MEDIUM, StockApp.HIGH_THRESHOLD_MEDIUM, StockApp.LOW_THRESHOLD_MEDIUM);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[2], StockApp.MAX_HOLD_DAYS_LONG, StockApp.HIGH_THRESHOLD_LONG, StockApp.LOW_THRESHOLD_LONG);
            Init_Default_Sell2(StockApp.DEFAULT_SELLs[3], StockApp.MAX_HOLD_DAYS_END, StockApp.HIGH_THRESHOLD_END, StockApp.LOW_THRESHOLD_END);
            //���̼ۺ;��߱Ƚ�
            Init_ABOVE_AVE(ABOVE_AVE_10, StockAttribute.AVE10);
            Init_ABOVE_AVE(ABOVE_AVE_20, StockAttribute.AVE20);
            Init_ABOVE_AVE(ABOVE_AVE_60, StockAttribute.AVE60);
            //����֮��Ƚ�
            Init_ABOVE_AVE(A10_ABOVE_20, StockAttribute.AVE10, StockAttribute.AVE20);
            Init_ABOVE_AVE(A10_ABOVE_60, StockAttribute.AVE10, StockAttribute.AVE60);
            Init_ABOVE_AVE(A20_ABOVE_60, StockAttribute.AVE20, StockAttribute.AVE60);
            //ͻ�ƽ��ڸߵ�

            //�ɼ۴�����߼۵�60%
            //ABOVE_Half130High(0.60);
            //�ɼ۵�����߼۵�40%
            //BELOW_Half130High(0.45);
            //MACD�;������ںõ�����,�õ����ƾ��Ƕ�ͷ��ɢ����
            //Init_GOOD_TREND(GOOD_MACD);
            InitNUM_KPI();
        }

        #region ��ѡ����
        //���߶�ͷ����
        //���߶�ͷ
        public static readonly string ABOVE_AVE_10 = "0_ABOVE_AVE_10";
        public static readonly string ABOVE_AVE_20 = "0_ABOVE_AVE_20";
        public static readonly string ABOVE_AVE_60 = "0_ABOVE_AVE_60"; 
        private void Init_ABOVE_AVE(string name, string attribute)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (items[i].end > Convert.ToDouble(items[i].attributes[attribute]))
                {
                    items[i].kpi[name] = 1;
                }
                else
                {
                    items[i].kpi[name] = 0;
                }

            }
        }
        //����֮��ıȽ�
        public static readonly string A10_ABOVE_20 = "A10_ABOVE_20";
        public static readonly string A10_ABOVE_60 = "A10_ABOVE_60";
        public static readonly string A20_ABOVE_60 = "A20_ABOVE_60";
        private void Init_ABOVE_AVE(string name, string attribute1, string attribute2)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                if (Convert.ToDouble(items[i].attributes[attribute1]) > Convert.ToDouble(items[i].attributes[attribute2]))
                {
                    items[i].kpi[name] = 1;
                }
                else
                {
                    items[i].kpi[name] = 0;
                }

            }
        }
        //n���Զ�����,����������ָߵ���ߵ͵�,��ֹӯ����ֹ��
  
        //����ֹ��
        public void Init_Default_Sell2(string sellname, int sellday, double high_threshold, double low_threshold)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size - sellday; i++)
            {
                double now = items[i].end;
                DefaultSell sellitem = new DefaultSell();
                sellitem.sellindex = i + sellday;
                sellitem.sellprice = items[i + sellday].end;
                sellitem.selldate = items[i + sellday].date;

                for (int j = i + 1; j < i + sellday; j++)
                {
                    double later = items[j].end;
                    if (later > now * (1 + high_threshold)
                        || later < now * (1 - low_threshold))
                    {
                        sellitem.sellindex = j;
                        sellitem.sellprice = later;
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
        
        //����130�߼۵�60%
        public static readonly string ABOVE_HALF_130_4 = "4_ABOVE_HALF_120";
        private void ABOVE_Half130High(double percentage)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                StockItem item = items[i];
                string s = item.attributes[StockAttribute.HIGH130].ToString();
                if (item.end < Convert.ToDouble(s) * percentage)
                {
                    items[i].kpi[ABOVE_HALF_130_4] = 0;
                }
                else
                {
                    items[i].kpi[ABOVE_HALF_130_4] = 1;
                }
            }
        }
        //С��130�߼۵�35%
        public static readonly string BELOW_HALF_130_5 = "5_BELOW_HALF_120";
        private void BELOW_Half130High(double percentage)
        {
            int size = stock.items.Length;
            for (int i = StockApp.START_ATTRIBUTE; i < size; i++)
            {
                StockItem item = items[i];
                string s = item.attributes[StockAttribute.HIGH130].ToString();
                if (item.end > Convert.ToDouble(s) * percentage)
                {
                    items[i].kpi[BELOW_HALF_130_5] = 0;
                }
                else
                {
                    items[i].kpi[BELOW_HALF_130_5] = 1;
                }
            }
        }

        //MACD���߾��߿�ʼ�����п�ʼ��ɢ
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
