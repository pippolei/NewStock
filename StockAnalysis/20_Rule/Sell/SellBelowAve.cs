using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class SellBelowAve : Sell
    {   
        protected override Boolean GetSell(StockData stock, int index)
        {
            StockItem[] items = stock.items;


            if (Convert.ToDouble(items[index].attributes[StockAttribute.AVE13]) * 0.98 > items[index].end
                && Convert.ToDouble(items[index - 1].attributes[StockAttribute.AVE13]) * 0.98 > items[index - 1].end)
            {
                return true;
            }
            return false;

            
        }
        
    }
}
