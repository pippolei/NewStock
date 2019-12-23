using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy4Week : Buy
    {
        public Buy4Week()
        {

        }
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes10 = stock.items[index - 10];
            StockItem yes5 = stock.items[index - 5];

            //今天收盘价>昨日20日最高价

            if (item.end > (double)yes1.attributes[StockAttribute.HIGH20]
                && (double)item.attributes[StockAttribute.AVE20] > (double)item.attributes[StockAttribute.AVE60]
                && (double)yes10.attributes[StockAttribute.AVE20] < (double)yes10.attributes[StockAttribute.AVE60]
                && yes5.end < (double)yes5.attributes[StockAttribute.AVE5]
                )
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "4Week";
        }
        
       
    }
}
