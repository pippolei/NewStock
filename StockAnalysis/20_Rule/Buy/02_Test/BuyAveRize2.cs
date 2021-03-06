﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyAveRize2 : Buy
    {
        public BuyAveRize2()
        {
            //this.defaultSell = StockApp.DEFAULT_SELLs[1];
            this.defaultBuyPrice = StockAttribute.BUYPRICE2;
        }
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
            StockItem yes30 = stock.items[index - 30];

            if (Convert.ToDouble(yes1.attributes[StockAttribute.AVE5]) - Convert.ToDouble(yes1.attributes[StockAttribute.AVE20]) > StockApp.MIN_ZERO
                && Convert.ToDouble(yes1.attributes[StockAttribute.AVE20]) - Convert.ToDouble(yes1.attributes[StockAttribute.AVE60]) > StockApp.MIN_ZERO

                && Convert.ToDouble(yes30.attributes[StockAttribute.AVE5]) - Convert.ToDouble(yes30.attributes[StockAttribute.AVE20])  < StockApp.MIN_ZERO
                && Convert.ToDouble(yes30.attributes[StockAttribute.AVE20]) - Convert.ToDouble(yes30.attributes[StockAttribute.AVE60])  < StockApp.MIN_ZERO

                && stock.items[index - 1].end - stock.items[index - 4].end < StockApp.MIN_ZERO
                && stock.items[index - 2].end - stock.items[index - 4].end < StockApp.MIN_ZERO
                && stock.items[index - 3].end - stock.items[index - 4].end < StockApp.MIN_ZERO
                && stock.items[index].end - stock.items[index - 1].end > StockApp.MIN_ZERO
                && stock.items[index].end - stock.items[index - 2].end > StockApp.MIN_ZERO
                && item.end  > Convert.ToDouble(item.attributes[StockAttribute.AVE10])
                //&& stock.items[index].end - Convert.ToDouble(stock.items[index].attributes[StockAttribute.AVE10]) > StockApp.MIN_ZERO
                )
            {
                return true;
            }

            return false;
        }
        
       
    }
}
