using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class SellStartBigDrop : Sell
    {   
        protected override Boolean GetSell(StockData stock, int index)
        {
            StockItem[] items = stock.items;

            if (Convert.ToDouble(items[index].start) * 1.03 < Convert.ToDouble(items[index - 1].end))
            {
                return true;
            }

            
            return false;

            
        }
        
    }
}
