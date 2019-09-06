using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class SellPureDrop : Sell
    {   
        protected override Boolean GetSell(StockData stock, int index)
        {
            StockItem[] items = stock.items;


            if (Convert.ToDouble(items[index].attributes[StockAttribute.RIZE]) < -0.03
                && Convert.ToDouble(items[index - 1].attributes[StockAttribute.RIZE]) < -0.03)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "SellPureDrop";
        }
    }
}
