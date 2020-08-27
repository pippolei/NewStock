using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    //长线交易系统
    //等待至隔天收盘(创130天高价或低价的次日) 此时使用最高价 最低价
    //测量过去20天交易日最高价与最低价之间的价差(包含当天) 此时使用收盘价
    //价差加入今天的收盘价, 则为买入点
    //价差被减今天的收盘价, 则为卖出点
    //如果有新的130天高价或低价, 则重复前面步骤
    //若新的买入点低于先前买入点,则更换买入点
    //若新的卖出点高于先前卖出点,则更换卖出点
    public class BuyLong: Buy
    {
        public BuyLong()
        {
            this.defaultSell = StockApp.DEFAULT_SELLs[3];
        }
        private string stockcode = "";
        private double buyprice = 10000, sellprice = 0;
        
        //目前在最高或最低值造成的买入区间
        //0未设置, 1等待买入, -1等待卖出
        private int lststatus = 0;

        private void ReGeneratePrice(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            //计算过去20天的高低价
            double localhigh = (double)stock.items[index].attributes[StockAttribute.HIGH20];
            double locallow = (double)stock.items[index].attributes[StockAttribute.LOW20];

            //判断当前是创高价还是创低价
            int nowstatus = 0;
            //创新高, 等待卖出
            if (items[index - 1].high + 0.0001 > (double)(items[index - 1].attributes[StockAttribute.HIGH60]))
            {
                nowstatus = Rule.STATUS_SELL;
            }
            //创新低, 等待买入
            else
            {
                nowstatus = Rule.STATUS_BUY;
            }

            
            buyprice = stock.items[index].end + localhigh - locallow;
            sellprice = stock.items[index].end - localhigh + locallow;
            
            lststatus = nowstatus;
        }
        protected override void Prepare(StockData stock, int index)
        {
            StockItem[] items = stock.items;

            //今日为130天高价或低价的次日

            //若为130天高价, 则减去价差为卖出价
            /*if (items[index - 1].high + 0.0001 >  (double)(items[index - 1].attributes[StockAttribute.HIGH130]))
            {
                ReGeneratePrice(stock, index);
                //UtilLog.AddDebug(this.ToString(), stock.code + "High index = " + (index - 1).ToString());
            }*/
            //若为130天低价, 则最低价加上差价为等待买入价, 减去价差为买入后的止损价
            if (items[index - 1].low - 0.0001 < (double)(items[index - 1].attributes[StockAttribute.LOW60]))
            {
                
                ReGeneratePrice(stock, index);
                UtilLog.AddDebug(this.ToString(), stock.code + "Low index = " + (index - 1).ToString());
                UtilLog.AddDebug(this.ToString(), stock.code + "buyprice = " + (buyprice).ToString());
            }//if
            //第一次计算该股票, 初始化
            if (!stockcode.Equals(stock.code))
            {
                buyprice = 10000;
                sellprice = 0;
                stockcode = stock.code;
            }
        }
        protected override Boolean GetBuy(StockData stock, int index)
        {

            if (stock.items[index].end > buyprice && lststatus == Rule.STATUS_BUY)
            {
                lststatus = Rule.STATUS_SELL;
                return true;
            }
            return false;
            
        }
       
        protected Boolean GetSell(StockData stock, int index)
        {
            if (stock.items[index].end < sellprice && lststatus == Rule.STATUS_SELL)
            {
                lststatus = Rule.STATUS_BUY;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "BuyLong";
        }
    }
}
