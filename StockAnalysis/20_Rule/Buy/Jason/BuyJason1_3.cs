using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyJason1_3 : Buy
    {
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes4 = stock.items[index - 4];
            StockItem yes5 = stock.items[index - 5];

            
            if (item.start > Convert.ToDouble(item.attributes[StockAttribute.AVE10])) return false;
            if (item.start > Convert.ToDouble(item.attributes[StockAttribute.AVE30])) return false;

            if (item.end < Convert.ToDouble(item.attributes[StockAttribute.AVE5])) return false;
            if (item.end < Convert.ToDouble(item.attributes[StockAttribute.AVE10])) return false;
            if (item.end < Convert.ToDouble(item.attributes[StockAttribute.AVE30])) return false;

            //T-1日被五日均线压制
            if (Convert.ToDouble(yes1.attributes[StockAttribute.AVE5]) < yes1.end) return false;
            double high = -100, low = 100;
            //T-6日到T-1日最高价与最低价不大于5%
            for (int i = 1; i <= 6; i++)
            {
                StockItem temp = stock.items[index - i];
                if (high < temp.high) high = temp.high;
                if (low > temp.low) low = temp.low;
            }
            if (high - low * 1.08 > StockApp.MIN_ZERO) return false;           
            return true;
        }
        public override string ToString()
        {
            return "BuyJason1_3";
        }
       
       
    }
}
