using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy6RizeAgStart : Buy
    {
        //连续6日小阳线
        //且这6日中小阳线产生金叉
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes4 = stock.items[index - 4];
            StockItem yes5 = stock.items[index - 5];
            StockItem yes6 = stock.items[index - 6];
            StockItem yes7 = stock.items[index - 7];
            
            if (item.end >= item.start
                && yes1.end >= yes1.start
                && yes2.end >= yes2.start
                && yes3.end >= yes3.start
                && yes4.end >= yes4.start
                && yes5.end >= yes5.start
                && yes6.end * 1.12 > item.end && yes6.end < yes6.start
                )
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "Buy6RizeAgStart";
        }
        
       
    }
}
