using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockAnalysis
{
    class UtilStock
    {
        //price 不一定需要严格大于，只需要近似超过就行
        public static bool RoughRizePrice(double price1, double price2)
        {
            if (price1 > 0.98 * price2 + StockApp.MIN_ZERO)
            {
                return true;
            }
            return false;
        }

        public static int GetIndexFromDate(StockData stock, int date)
        {
            int size = stock.items.Length;
            for (int i = 0; i < size; i++)
            {
                if (stock.items[i].date == date)
                    return i;
            }
            return 0;
        }
    }
}
