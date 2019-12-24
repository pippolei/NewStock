using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class Buy15Rize : Buy
    {
        private string stockcode = "";
        private double num_rize = 0;
        private int checksize = 20;
        protected override void Prepare(StockData stock, int index)
        {
            StockItem[] items = stock.items;

            if (stockcode != stock.code)
            {
                stockcode = stock.code;
                num_rize = 0;
                for (int i = 0; i < checksize; i++)
                {
                    StockItem item = items[index - i - 1];
                    StockItem pre = items[index - i - 2];
                    if (item.end - item.start > StockApp.MIN_ZERO)
                    {
                        num_rize++;
                    }                    
                }
            }
        }

        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            
            if (items[index - 1].end - items[index - 1].start > StockApp.MIN_ZERO)
            {
                num_rize++;
            }
            //去除20天前的涨幅值
            if (items[index - checksize].end - items[index - checksize - 1].start > StockApp.MIN_ZERO)
            {
                num_rize--;
            }
            if (num_rize >= 15
                && items[index].end - items[index - checksize].end * 1.2 <= StockApp.MIN_ZERO
                && items[index - checksize].end - Convert.ToDouble(items[index - checksize].attributes[StockAttribute.AVE20]) <= StockApp.MIN_ZERO
                && Convert.ToDouble(items[index].attributes[StockAttribute.RIZE]) - 0.02 > StockApp.MIN_ZERO
                )
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Buy15Rize";
        }
        
       
    }
}
