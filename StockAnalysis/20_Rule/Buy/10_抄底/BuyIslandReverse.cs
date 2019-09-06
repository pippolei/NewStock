using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    class BuyIslandReverse : Buy
    {

        private string code = "";
        private int status,con_win,con_loss = 0;
        private string long_ave = StockAttribute.AVE30;
        private string short_ave = StockAttribute.AVE10;
        private void init()
        {
            status = 0;
            con_win = 0;
            con_loss = 0;
        }
        public BuyIslandReverse()
        {
            init();
        }

        protected override void Prepare(StockData stock, int index)
        {
            if (code != stock.code)
            {
                code = stock.code;
                init();
            }
            if ((double)stock.items[index].attributes[short_ave] > (double)stock.items[index - 1].attributes[short_ave])
            {
                if (status == 1) //原先状态就是上涨状态， 
                {
                    con_win++;
                }
                else
                {
                    status = 1;
                    con_win = 1;
                }
            }
            else
            {
                if (status == -1) //原先状态就是下跌状态， 
                {
                    con_loss++;
                }
                else
                {
                    status = -1;
                    con_loss = 1;
                }
            }


        }

        protected override Boolean GetBuy(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            if (status == 1 && items[index].end >= (double)items[index].attributes[long_ave]
                && items[index - 1].end <= (double)items[index - 1].attributes[long_ave]
                && con_win >=5 && con_loss >= 7
                && (double)items[index - con_win - 7].attributes[short_ave] < (double)items[index - con_win - 7].attributes[long_ave]
                )
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "BuyIslandReverse";
        }
        
    }
}
