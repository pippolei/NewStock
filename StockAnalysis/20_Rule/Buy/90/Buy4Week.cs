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
            StockItem yes20 = stock.items[index - 20];

            if (item.end > (double)yes1.attributes[StockAttribute.HIGH20]
                && (double) item.attributes[StockAttribute.AVE60] > (double) item.attributes[StockAttribute.AVE120]
                && (double)yes20.attributes[StockAttribute.AVE60] < (double)yes20.attributes[StockAttribute.AVE120]
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
