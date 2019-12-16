using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy6RizePreEndVolume : Buy
    {
        //连续6日小阳线
        //且这6日中小阳线产生金叉
        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem item = stock.items[index];
            StockItem yes1 = stock.items[index - 1];
            StockItem yes2 = stock.items[index - 2];
            StockItem yes3 = stock.items[index - 3];
            

            if (item.end >= yes1.end
                || yes1.end >= yes2.end       //连跌两天
                || yes2.end < yes2.start || Convert.ToDouble(yes2.attributes[StockAttribute.RIZE]) < 0.03 //两天前大涨
                || (yes2.end - yes3.end) >= 2 * (yes2.end - item.end)
                || item.end <= yes3.end     //调整两天但不跌破上涨幅度
                || yes2.volume <= yes1.volume
                || yes2.volume <= item.volume   //两天前大涨那天是放量的
                )
            {
                return false;
            }

            int rizenum = 0;
            for (int i = 0; i < 6; i++)
            {
                StockItem a1 = stock.items[index - 2 - i];
                StockItem a2 = stock.items[index - 3 - i];
                if (a1.end >= a2.end) rizenum++;
            }
            if (rizenum < 6) return false;

            return true;
        }
        public override string ToString()
        {
            return "Buy6RizePreEndVolume";
        }
        
       
    }
}
