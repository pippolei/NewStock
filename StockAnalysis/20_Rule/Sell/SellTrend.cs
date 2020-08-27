using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class SellTrend : Sell
    {   
        protected override Boolean GetSell(StockData stock, int index)
        {
            StockItem[] items = stock.items;

            if (Convert.ToDouble(items[index].attributes[StockAttribute.AVE5]) * 1.005 < Convert.ToDouble(items[index].attributes[StockAttribute.AVE10])
                && Convert.ToDouble(items[index].attributes[StockAttribute.AVE10]) * 1.005 < Convert.ToDouble(items[index].attributes[StockAttribute.AVE20])

                )
            {
                return true;
            }

            
            return false;

            
        }
        
    }
}
