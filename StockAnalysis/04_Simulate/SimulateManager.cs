using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    class SimulateManager
    {
        //同时操作股票数量,买入股票数量
        private int totalnum;
        private int startdate, enddate;
        //剩余资金
        double leftmoney = StockApp.INIT_VALUE;
        private Hashtable hsallitems = new Hashtable(); //所有可交易的交易记录列表
        private ArrayList record_opeitems = new ArrayList(); //所有记录的交易
        private ArrayList holditems = new ArrayList(); //现在持有的股票
        private DataManager db = new DataManager();

        
        //初始化
        public SimulateManager(int start, int end, int holdstocknum)
        {
            totalnum = holdstocknum;
            leftmoney = StockApp.INIT_VALUE;
            holditems.Capacity = holdstocknum;
            startdate = start;
            enddate = end;
        }
        //按照日期排序
        public void AddOpeItem(StockOpeItem item)
        {
            string date = item.buydate.ToString();
            object obj = hsallitems[date];
            if (obj == null)
            {
                obj = new List<StockOpeItem>();
            }
            List<StockOpeItem> list = (List<StockOpeItem>)obj;
            list.Add(item);
            //grade高的在前面
            newsCompare comp = new newsCompare();
            list.Sort(comp);
            hsallitems[date] = list;
        }
        
        //是否可以买入
        private bool checkBuy(StockOpeItem item)
        {
            //如果当前满仓, 则不能买入
            if (holditems.Count >= totalnum)
            {
                return false;
            }
            //如果股票已被买入, 则不能买入
            foreach (StockSimulateItem nowitem in holditems)
            {
                if (nowitem.stockcode == item.stockcode)
                {
                    return false;
                }
            }
            return true;
        }
        //某一天是否有卖出
        private bool checkSell(int date)
        {
            foreach (StockSimulateItem item in holditems)
            {
                if (item.selldate == date)
                {
                    return true;
                }
            }
            return false;
        }
        private void doBuy(StockOpeItem item)
        {
            StockSimulateItem smitem = new StockSimulateItem(item);
            smitem.type = item.type;
            //剩余资金需要均分给需要买的股票数量
            double buymoney = leftmoney / (totalnum - holditems.Count);
            //可以买的手数
            int buyvolume = (int)(buymoney / (100 * item.buyprice));
            //实际可以买的股票数
            smitem.buyvolume = buyvolume * 100;
            //剩余资金: 需要计算手续费
            leftmoney = leftmoney - smitem.buyvolume * item.buyprice * (1 + StockApp.FEE);
            holditems.Add(smitem);
            smitem.holdstocknum = holditems.Count;
            smitem.totalstockvalue = getHoldStockValue();
            smitem.leftmoney = leftmoney;
            record_opeitems.Add(smitem);
        }
        //得到当前持有的股票总市值, 在卖出前总是按照买入价计算市值
        private double getHoldStockValue()
        {
            double value = 0;
            foreach (StockSimulateItem item in holditems)
            {
                value += item.stockvalue;
            }
            return value;
        }
        private void doSell(int date)
        {   
            StockSimulateItem[] items = (StockSimulateItem[])holditems.ToArray(typeof(StockSimulateItem));
            for (int i = 0; i < items.Length; i++)
            {
                StockSimulateItem item = items[i];
                if (item.selldate == date)
                {   
                    //减去手续费
                    holditems.Remove(item);
                    StockSimulateItem sellitem = item.Copy();
                    sellitem.type = Rule.STATUS_SELL;
                    leftmoney = leftmoney + (sellitem.stockvalue + sellitem.winvalue) * (1 - StockApp.FEE);
                    sellitem.holdstocknum = holditems.Count;
                    sellitem.totalstockvalue = getHoldStockValue();
                    sellitem.leftmoney = leftmoney;
                    record_opeitems.Add(sellitem);
                }
            }
            
        }
        public void Simulate(int startdate, int enddate)
        {
            int curentdate;
            for (curentdate = startdate; curentdate <= enddate; curentdate = Util.nextDay(curentdate))
            {
                //if (curentdate == 20180301)
                //{
                //    int abc;
                //    abc = 3;
                //}
                //如果有卖出则卖出
                if (checkSell(curentdate))
                {
                    doSell(curentdate);
                }
                object list = hsallitems[curentdate.ToString()];
                //如果当日没有需要操作的股票,则转入下一日
                if (list == null)
                {
                    continue;
                }
                List<StockOpeItem> newlist = (List<StockOpeItem>)list;

                for (int i = 0; i < newlist.Count; i++)                
                {
                    StockOpeItem item = newlist[i];
                    if (checkBuy(item))
                    {
                        doBuy(item);
                    }
                }
                
            }
        }

        public void SaveToDB(int type, string buyname, string sellname)
        {
            StockSimulateSQL.SaveToDB(type, startdate, enddate, buyname, sellname, record_opeitems);
        }
        
        

        
        
    }
    
}
