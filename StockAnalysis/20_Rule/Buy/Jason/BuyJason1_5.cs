using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyJason1_5 : Buy
    {
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            StockItem yes4 = stock.items[index - 4];
            StockItem yes5 = stock.items[index - 5];
            StockItem yes6 = stock.items[index - 6];

            //跳空高开3%
            if (item.start - yes1.end * 1.02 < StockApp.MIN_ZERO) return false;
            //收盘价需要大于开盘价
            if (item.end - item.start < StockApp.MIN_ZERO) return false;
            //涨幅不超过6.5%
            if (Convert.ToDouble(item.attributes[StockAttribute.RIZE]) > 0.065) return false;


            if (index + 1 < stock.items.Length)
            {
                if (Convert.ToInt32(stock.items[index + 1].attributes[StockAttribute.CANBUY]) == 0)
                {
                    return false;
                }
            }
            //T-6日被五日均线压制
            if (Convert.ToDouble(yes6.attributes[StockAttribute.AVE5]) - yes6.end < StockApp.MIN_ZERO) return false;
            
            //连续3天小阳线
            for (int i = 1; i <= 3; i++)
            {
                StockItem temp = stock.items[index - i];
                StockItem pre = stock.items[index - i - 1];
                if (Convert.ToDouble(temp.attributes[StockAttribute.ATR]) - 0.02 > StockApp.MIN_ZERO 
                    || temp.end  - pre.end < StockApp.MIN_ZERO)
                {
                    return false;
                }   
            }
                 
            return true;
        }
        
       
       
    }
}
