using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy6Rize2 : Buy
    {
        public Buy6Rize2()
        {
            //this.defaultSell = StockApp.DEFAULT_SELLs[1];
            //this.defaultBuyPrice = StockAttribute.BUYPRICE4;
        }
        //连续6日小阳线
        //且这6日中小阳线产生金叉
        //6天涨幅不超过12%
        //
        protected override Boolean GetBuy(StockData stock, int index)
        {
            int n = 4;
            StockItem today = stock.items[index];
            StockItem item = stock.items[index - n];
            StockItem yes1 = stock.items[index - 1 - n];
            StockItem yes2 = stock.items[index - 2 - n];
            StockItem yes3 = stock.items[index - 3 - n];
            StockItem yes4 = stock.items[index - 4 - n];
            StockItem yes5 = stock.items[index - 5 - n];
            StockItem yes6 = stock.items[index - 6 - n];
            StockItem yes7 = stock.items[index - 7 - n];

            //if (stock.code == "s002146" && stock.items[index].index == stock.items.Length - 1)
            //if (stock.code == "s600410" && stock.items[index].date == 20171116)
            //{
            //    int abc;
            //    abc = 3;
            //}
            if ((item.end >= yes1.end || item.end >= item.start)
                && (yes1.end >= yes2.end || yes1.end >= yes1.start)
                && (yes2.end >= yes3.end || yes2.end >= yes2.start)
                && (yes3.end >= yes4.end || yes3.end >= yes3.start)
                && (yes4.end >= yes5.end || yes4.end >= yes4.start)
                && (yes5.end >= yes6.end || yes5.end >= yes5.start)
                //&& yes6.end * 1.12 > item.end && yes6.end < yes7.end
                //&& 
                &&
                (item.end - Convert.ToDouble(today.attributes[StockAttribute.AVE60]) < StockApp.MIN_ZERO
                //(today.end - Convert.ToDouble(today.attributes[StockAttribute.AVE60]) < StockApp.MIN_ZERO
                || yes6.end * 1.14 > today.end)
                && item.end - Convert.ToDouble(today.attributes[StockAttribute.LOW130]) * 1.3 > StockApp.MIN_ZERO
                && today.end - item.end > StockApp.MIN_ZERO
                && (today.low * 1.01 < today.end && today.high < today.end * 1.03)
                )
            {
                return true;
            }

            return false;
        }



    }
}
