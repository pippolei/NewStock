using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyJason1_20 : Buy
    {
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes4 = stock.items[index - 4];
            StockItem yes5 = stock.items[index - 5];
            StockItem yes6 = stock.items[index - 6];

            //跳空高开3%
            if (item.start - yes1.end * 1.03 < StockApp.MIN_ZERO) return false;
            //收盘价需要大于开盘价
            if (item.end - item.start < StockApp.MIN_ZERO) return false;
            //涨幅不超过5%
            if (Convert.ToDouble(item.attributes[StockAttribute.RIZE]) > 0.05) return false;
            //长上影
            if (item.longShangYing) return false;

            if (index + 1 < stock.items.Length)
            {
                if (Convert.ToInt32(stock.items[index + 1].attributes[StockAttribute.CANBUY]) == 0)
                {
                    return false;
                }
            }
            //T-1日被五日均线压制
            if (Convert.ToDouble(yes1.attributes[StockAttribute.AVE20]) - yes1.end < StockApp.MIN_ZERO) return false;
                        
            //double high = -100, low = 100;
            //T-6日到T-1日最高价与最低价不大于5%
            /*for (int i = 1; i <= 6; i++)
            {
                StockItem temp = stock.items[index - i];
                if (high < temp.high) high = temp.high;
                if (low > temp.low) low = temp.low;
            }
            if (high - low * 1.05 > StockApp.MIN_ZERO) return false;           
            */return true;
        }
        
       
       
    }
}
