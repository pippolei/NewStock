﻿using System;
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


            if (Convert.ToDouble(item.attributes[StockAttribute.RIZE]) > 0.03
                && yes3.end < item.end && yes3.start > yes3.end
                && yes2.end < item.end && yes2.start > yes2.end
                && yes1.end < item.end && yes1.start > yes1.end
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
