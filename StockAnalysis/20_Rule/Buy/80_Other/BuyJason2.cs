using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyJason2 : Buy
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
            StockItem yes10 = stock.items[index - 10];

            //跳空高开3%
            if (item.start - yes1.end * 1.03 < StockApp.MIN_ZERO) return false;
            //T-1日被五日均线压制
            if (Convert.ToDouble(yes1.attributes[StockAttribute.AVE5]) - yes1.end < StockApp.MIN_ZERO) return false;

            //10日均线没有大涨
            if (Convert.ToDouble(yes10.attributes[StockAttribute.AVE10]) * 1.1 - Convert.ToDouble(item.attributes[StockAttribute.AVE10]) < StockApp.MIN_ZERO) return false;        
            return true;
        }
        
       
       
    }
}
