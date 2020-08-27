using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyBigWin : Buy
    {
        //阳线后产生3小跌
        //然后大阳线包住3小跌
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes4 = stock.items[index - 4];
            StockItem yes19 = stock.items[index - 19];


            if (Convert.ToDouble(yes4.attributes[StockAttribute.RIZERATE]) - 0.03 > StockApp.MIN_ZERO
                && yes3.end < yes4.end 
                && yes2.end < yes3.end
                && yes1.end < yes2.end
                && item.end > yes1.end && (item.end - yes1.end) > 0.8 * (yes4.end - yes1.end)
                && yes4.end > 1.1 * yes19.end
                && item.end < yes19.end * 1.2
                && yes19.end < Convert.ToDouble(yes4.attributes[StockAttribute.AVE10])
               )
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "BuyBigWin";
        }
       
       
    }
}
