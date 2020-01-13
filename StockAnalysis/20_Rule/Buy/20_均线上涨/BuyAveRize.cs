using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyAveRize : Buy
    {
        //连续6日小阳线
        //且这6日中小阳线产生金叉
        protected override Boolean GetBuy(StockData stock, int index)
        {
            int n = 3;
            StockItem item = stock.items[index - n];
            StockItem yes1 = stock.items[index - 1 - n];
            StockItem yes2 = stock.items[index - 2 - n];
            StockItem yes3 = stock.items[index - 3 - n];
            StockItem yes4 = stock.items[index - 4 - n];
            StockItem yes5 = stock.items[index - 5 - n];
            StockItem yes6 = stock.items[index - 6 - n];
            StockItem yes7 = stock.items[index - 7 - n];
            StockItem yes20 = stock.items[index - 20 - n];

            if (Convert.ToDouble(item.attributes[StockAttribute.AVE5]) - Convert.ToDouble(item.attributes[StockAttribute.AVE10])*1.01 >= StockApp.MIN_ZERO
                && Convert.ToDouble(item.attributes[StockAttribute.AVE10]) - Convert.ToDouble(item.attributes[StockAttribute.AVE20]) * 1.01 >= StockApp.MIN_ZERO
                && Convert.ToDouble(item.attributes[StockAttribute.AVE20]) - Convert.ToDouble(item.attributes[StockAttribute.AVE30]) * 1.01 >= StockApp.MIN_ZERO
                && Convert.ToDouble(yes20.attributes[StockAttribute.AVE30]) - Convert.ToDouble(yes20.attributes[StockAttribute.AVE20]) >= StockApp.MIN_ZERO
                && Convert.ToDouble(yes20.attributes[StockAttribute.AVE20]) - Convert.ToDouble(yes20.attributes[StockAttribute.AVE10]) >= StockApp.MIN_ZERO
                && Convert.ToDouble(yes20.attributes[StockAttribute.AVE10]) - Convert.ToDouble(yes20.attributes[StockAttribute.AVE5]) >= StockApp.MIN_ZERO
                && (yes1.end - yes2.end < StockApp.MIN_ZERO
                    || yes2.end - yes3.end < StockApp.MIN_ZERO
                    || yes3.end - yes4.end < StockApp.MIN_ZERO
                    || yes4.end - yes5.end < StockApp.MIN_ZERO
                    )                
                && stock.items[index].end - stock.items[index - 1].end < StockApp.MIN_ZERO
                && stock.items[index - 1].end - stock.items[index - 2].end < StockApp.MIN_ZERO
                && stock.items[index].end - Convert.ToDouble(stock.items[index].attributes[StockAttribute.AVE5]) < StockApp.MIN_ZERO
                )
            {
                return true;
            }

            return false;
        }
        
        
       
    }
}
