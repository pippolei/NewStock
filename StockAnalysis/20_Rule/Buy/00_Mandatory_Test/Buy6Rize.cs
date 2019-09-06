using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy6Rize : Buy
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
            
            if (Convert.ToBoolean(item.attributes[StockAttribute.IS_RIZE])
                && Convert.ToBoolean(yes1.attributes[StockAttribute.IS_RIZE]) 
                && Convert.ToBoolean(yes2.attributes[StockAttribute.IS_RIZE]) 
                && Convert.ToBoolean(yes3.attributes[StockAttribute.IS_RIZE]) 
                && Convert.ToBoolean(yes4.attributes[StockAttribute.IS_RIZE])
                && Convert.ToBoolean(yes5.attributes[StockAttribute.IS_RIZE]) 
                && yes6.end * 1.12 > item.end && !Convert.ToBoolean(yes6.attributes[StockAttribute.IS_RIZE])
                )
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "6rize";
        }
        
       
    }
}
