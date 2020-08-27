using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyBelow35AVE10 : Buy
    {
        //低于10日均线
        //且某一日突然大跌
        //大幅下跌后N天内仍然跌了>5
        //第三天再次大幅下跌, 低于10%

        public BuyBelow35AVE10()
        {

        }

        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            for (int i = 0; i < 30; i++)
            {
                if ((double)items[index - i].attributes[StockAttribute.AVE10] <= (double)items[index - i].end)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        
    }
}
