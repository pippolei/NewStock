using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyBelowAVE5 : Buy
    {
        //低于10日均线
        //且某一日突然大跌
        //大幅下跌后N天内仍然跌了>5
        //第三天再次大幅下跌, 低于10%

        public BuyBelowAVE5()
        {

        }

        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            if (Convert.ToDouble(items[index].attributes[StockAttribute.RIZE]) < 0.03 && items[index].longXiaoYing
                    && items[index - 1].end < (double)items[index - 1].attributes[StockAttribute.AVE10]
                    && items[index - 2].end < (double)items[index - 2].attributes[StockAttribute.AVE10]
                    && items[index - 3].end < (double)items[index - 3].attributes[StockAttribute.AVE10]
                && items[index - 4].end < (double)items[index - 4].attributes[StockAttribute.AVE10]
                && items[index - 5].end < (double)items[index - 5].attributes[StockAttribute.AVE10])
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "BelowAVE5";
        }
        
    }
}
