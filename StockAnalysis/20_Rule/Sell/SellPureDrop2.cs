using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class SellPureDrop2 : Sell
    {   
        protected override Boolean GetSell(StockData stock, int index)
        {
            StockItem[] items = stock.items;

            int times = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Convert.ToDouble(items[index - i].attributes[StockAttribute.RIZE]) < -0.03) times++;               
            }
            if (times >= 2 && items[index].end < (double)items[index].attributes[StockAttribute.AVE10]
                && items[index - 1].end < (double)items[index - 1].attributes[StockAttribute.AVE10]) return true;
            return false;
        }
        public override string ToString()
        {
            return "SellPureDrop2";
        }
    }
}
