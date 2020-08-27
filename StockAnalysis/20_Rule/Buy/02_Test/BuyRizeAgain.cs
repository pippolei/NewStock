using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyRizeAgain : Buy
    {
        public BuyRizeAgain()
        {
            //this.defaultSell = StockApp.DEFAULT_SELLs[1];
        }

        protected override Boolean GetBuy(StockData stock, int index)
        {
            int n = 0;
            StockItem today = stock.items[index];
            StockItem item = stock.items[index - n];
            StockItem yes1 = stock.items[index - 1 - n];
            StockItem yes2 = stock.items[index - 2 - n];
            StockItem yes3 = stock.items[index - 3 - n];
            StockItem yes4 = stock.items[index - 4 - n];
            StockItem yes5 = stock.items[index - 5 - n];
            StockItem yes6 = stock.items[index - 6 - n];
            StockItem yes7 = stock.items[index - 7 - n];

            //if (stock.code == "s600277" && stock.items[index].index == 1428)
            //{
            //    int abc;
            //    abc = 3;
            //}
            if (//(item.end >= yes1.end || item.end >= item.start)
                //&& (yes1.end >= yes2.end || yes1.end >= yes1.start)
                //&& (yes2.end >= yes3.end || yes2.end >= yes2.start)
                Convert.ToDouble(item.attributes[StockAttribute.HIGH130]) > 1.75 *　Convert.ToDouble(item.attributes[StockAttribute.LOW130])
                //&& Convert.ToDouble(item.attributes[StockAttribute.HIGH130]) > Convert.ToDouble(item.attributes[StockAttribute.HIGH20])
                && item.end < Convert.ToDouble(item.attributes[StockAttribute.HIGH130]) * 0.75
                && item.end > Convert.ToDouble(item.attributes[StockAttribute.LOW130]) * 1.25

                && Convert.ToDouble(today.attributes[StockAttribute.AVE5]) - Convert.ToDouble(yes1.attributes[StockAttribute.AVE5]) > StockApp.MIN_ZERO
                && Convert.ToDouble(today.attributes[StockAttribute.AVE5]) - Convert.ToDouble(today.attributes[StockAttribute.AVE10]) > StockApp.MIN_ZERO
                && Convert.ToBoolean(today.kpi[StockKPI.CROSS_AVE_5])

                )
            {
                return true;
            }

            return false;
        }



    }
}
