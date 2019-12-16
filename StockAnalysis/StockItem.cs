using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    public class StockItem
    {
        public string code;
        public int date;
        public int index;
        public double start;
        public double high;
        public double low;
        public double end;
        public double volume;
        public System.Collections.Hashtable attributes = new System.Collections.Hashtable();
        public System.Collections.Hashtable kpi = new System.Collections.Hashtable();

        
        //长下影线
        public bool longXiaoYing
        {
            get
            {
                double v1 = Math.Abs(end - start);
                double v2 = Math.Min(end, start) - low;

                if (v2 > v1 && v2 / end > 0.02)                
                {
                    return true;
                }
                return false;
            }
        } 
        
        public string[] ToRowInfo()
        {
            int size = 8 + StockAttribute.attributes.Length + StockKPI.KPIs.Length ;
            string[] strs = new string[size];
            strs[0] = code;
            strs[1] = (index).ToString();
            strs[2] = date.ToString();
            strs[3] = start.ToString();
            strs[4] = high.ToString();
            strs[5] = low.ToString();
            strs[6] = end.ToString();
            strs[7] = volume.ToString();
            int i = 8;
            foreach (string s in StockAttribute.attributes)
            {
                string value;
                try
                {
                    value = Math.Round((double)attributes[s], 4).ToString();
                }
                catch (Exception e)
                {
                    value = "";
                    Console.WriteLine(e.ToString());
                }
                strs[i] = attributes[s] == null ? "" : value.ToString();
                i++;
            }
            foreach (string s in StockKPI.KPIs)
            {
                object value;
                value = kpi[s];
                strs[i] = kpi[s] == null ? "" : value.ToString();
                i++;
            }

            return strs;
        }
    }

    public class StockRuleItem
    {
        public int id;
        public int type;
        public string rulename;
        public string stockcode;
        public int date;
        public int index;
        public double price;
        public double pregrade;
        public double grade;
        public string kpis;
        public string num_kpis;
        public string dapan;
        public double next1;
        public double next2;
        public double next3;
        public double next4;
        public double post1;
        public double post2;
        public double post3;
        public double post4;
        public double post5;

        public string[] ToRowInfo()
        {
            int size = 20 ;
            string[] strs = new string[size];
            strs[0] = type.ToString();
            strs[1] = stockcode;
            strs[2] = rulename;
            strs[3] = date.ToString();
            strs[4] = index.ToString();
            strs[5] = price.ToString();
            strs[6] = pregrade.ToString();
            strs[7] = grade.ToString();
            strs[8] = kpis.ToString();
            strs[9] = num_kpis.ToString();
            strs[10] = dapan.ToString();
            strs[11] = Math.Round(next1,4).ToString();
            strs[12] = Math.Round(next2,4).ToString();
            strs[13] = Math.Round(next3,4).ToString();
            strs[14] = Math.Round(next4,4).ToString();
            strs[15] = Math.Round(post1, 4).ToString();
            strs[16] = Math.Round(post2, 4).ToString();
            strs[17] = Math.Round(post3, 4).ToString();
            strs[18] = Math.Round(post4, 4).ToString();
            strs[19] = Math.Round(post5, 4).ToString();
            return strs;
        }
    }

    public class StockOpeItem
    {
        //public static readonly string SELL_NORMAL;
        //public static readonly string SELL_APPLY_DEFAULT;
        //public static readonly string SELL_PERIOD_END;
        public int type;
        public string buyrule;
        public string sellrule;
        public string stockcode;
        public int buydate;
        public int buyindex;
        public double buyprice;
        public int selldate;
        public int sellindex;
        public double sellprice;
        public double grade;
        //public string sellreason;
        

        public object[] ToRowInfo()
        {
            object[] strs = new object[9];
            strs[0] = stockcode;
            strs[1] = buyrule;
            strs[2] = sellrule;
            strs[3] = buydate.ToString();
            strs[4] = buyprice.ToString();
            strs[5] = (double)grade;
            strs[6] = selldate.ToString();
            strs[7] = sellprice.ToString();
            strs[8] = type.ToString();
            return strs;
        }
    }

    public class StockSimulateItem
    {
        public int type;
        public string buyrule;
        public string sellrule;
        public string stockcode;
        public int buydate;
        public int buyindex;
        public double buyprice;
        public int selldate;
        public int sellindex;
        public double sellprice;
        public int buyvolume;
        
        public double stockvalue
        {
            get
            {
                return buyvolume * buyprice;
            }
        }
        public double winvalue
        {
            get
            {
                if (type == Rule.STATUS_BUY) return 0;
                return buyvolume * (sellprice - buyprice);
            }
        }
        public int holdstocknum;
        public double totalstockvalue;
        public double leftmoney;
        public double totalamount
        {
            get
            {
                return totalstockvalue + leftmoney;
            }
        }

        public StockSimulateItem Copy()
        {
            StockSimulateItem item = new StockSimulateItem();
            item.type = type;
            item.buyrule = buyrule;
            item.sellrule = sellrule;
            item.stockcode = stockcode;
            item.buydate = buydate;
            item.buyindex = buyindex;
            item.buyprice = buyprice;
            item.selldate = selldate;
            item.sellindex = sellindex;
            item.sellprice = sellprice;
            item.buyvolume = buyvolume;
            item.holdstocknum = holdstocknum;
            item.totalstockvalue = totalstockvalue;
            item.leftmoney = leftmoney;

            return item;
        }
        public StockSimulateItem()
        {
        }
        public StockSimulateItem(StockOpeItem item)
        {
            buyrule = item.buyrule;
            sellrule = item.sellrule;
            stockcode = item.stockcode;
            buydate = item.buydate;
            buyindex = item.buyindex;
            buyprice = item.buyprice;
            selldate = item.selldate;
            sellindex = item.sellindex;
            sellprice = item.sellprice;
        }
        public string[] ToRowInfo()
        {
            string[] strs = new string[17];
            strs[0] = type.ToString();
            strs[1] = buyrule;
            strs[2] = sellrule;
            strs[3] = stockcode;
            strs[4] = buydate.ToString();
            strs[5] = buyindex.ToString();
            strs[6] = buyprice.ToString();
            strs[7] = selldate.ToString();
            strs[8] = sellindex.ToString();
            strs[9] = sellprice.ToString();
            strs[10] = buyvolume.ToString();
            strs[11] = stockvalue.ToString();
            strs[12] = winvalue.ToString();
            strs[13] = holdstocknum.ToString();
            strs[14] = totalstockvalue.ToString();
            strs[15] = leftmoney.ToString();
            strs[16] = totalamount.ToString();
            return strs;
        


        
        
       
       
        }
    }
    
    
}
