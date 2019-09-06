using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy7Down5Rize : Buy
    {
        protected override Boolean GetBuy(StockData stock, int index)
        {   
            int n1 = 5, n2 = 12, offset = 0;
            StockItem day_new;
            StockItem day_old;
            for (int i = index - offset; i > index - offset - n1; i--)
            {
                day_new = stock.items[i];
                day_old = stock.items[i - 1];
                if ((double)day_old.attributes[StockAttribute.AVE5] > (double)day_new.attributes[StockAttribute.AVE5])
                {
                    return false;
                }
            }
            for (int i = index - offset - n1; i > index - offset - n1 - n2; i--)
            {
                day_new = stock.items[i];
                day_old = stock.items[i - 1];
                if ((double)day_new.attributes[StockAttribute.AVE5] > (double)day_old.attributes[StockAttribute.AVE5])
                {
                    return false;
                }
            }
            
            day_new = stock.items[index - offset];
            day_old = stock.items[index - n1 - offset];
            if ((double)day_new.attributes[StockAttribute.AVE5] <= (double)day_old.attributes[StockAttribute.AVE5] * 1.05)
            {
                return false;
            }
            if ((double)day_new.attributes[StockAttribute.AVE5] >= (double)day_old.attributes[StockAttribute.AVE5] * 1.10)
            {
                return false;
            }

            for (int i = 0; i < offset; i++)
            {
                day_new = stock.items[index - i];
                day_old = stock.items[index - i - 1];
                //出现买入信号后下跌了几天
                if (day_old.end <= day_new.end) return false;
            }

            return true;
        }
        public override string ToString()
        {
            return "Buy7Down5Rize";
        }
        
       
    }
}
