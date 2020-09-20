using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    class SimulateManager
    {
        //ͬʱ������Ʊ����,�����Ʊ����
        private int totalnum;
        private int startdate, enddate;
        //ʣ���ʽ�
        double leftmoney = StockApp.INIT_VALUE;
        private Hashtable hsallitems = new Hashtable(); //���пɽ��׵Ľ��׼�¼�б�
        private ArrayList record_opeitems = new ArrayList(); //���м�¼�Ľ���
        private ArrayList holditems = new ArrayList(); //���ڳ��еĹ�Ʊ
        private DataManager db = new DataManager();

        
        //��ʼ��
        public SimulateManager(int start, int end, int holdstocknum)
        {
            totalnum = holdstocknum;
            leftmoney = StockApp.INIT_VALUE;
            holditems.Capacity = holdstocknum;
            startdate = start;
            enddate = end;
        }
        //������������
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
            //grade�ߵ���ǰ��
            newsCompare comp = new newsCompare();
            list.Sort(comp);
            hsallitems[date] = list;
        }
        
        //�Ƿ��������
        private bool checkBuy(StockOpeItem item)
        {
            //�����ǰ����, ��������
            if (holditems.Count >= totalnum)
            {
                return false;
            }
            //�����Ʊ�ѱ�����, ��������
            foreach (StockSimulateItem nowitem in holditems)
            {
                if (nowitem.stockcode == item.stockcode)
                {
                    return false;
                }
            }
            return true;
        }
        //ĳһ���Ƿ�������
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
            //ʣ���ʽ���Ҫ���ָ���Ҫ��Ĺ�Ʊ����
            double buymoney = leftmoney / (totalnum - holditems.Count);
            //�����������
            int buyvolume = (int)(buymoney / (100 * item.buyprice));
            //ʵ�ʿ�����Ĺ�Ʊ��
            smitem.buyvolume = buyvolume * 100;
            //ʣ���ʽ�: ��Ҫ����������
            leftmoney = leftmoney - smitem.buyvolume * item.buyprice * (1 + StockApp.FEE);
            holditems.Add(smitem);
            smitem.holdstocknum = holditems.Count;
            smitem.totalstockvalue = getHoldStockValue();
            smitem.leftmoney = leftmoney;
            record_opeitems.Add(smitem);
        }
        //�õ���ǰ���еĹ�Ʊ����ֵ, ������ǰ���ǰ�������ۼ�����ֵ
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
                    //��ȥ������
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
                //���������������
                if (checkSell(curentdate))
                {
                    doSell(curentdate);
                }
                object list = hsallitems[curentdate.ToString()];
                //�������û����Ҫ�����Ĺ�Ʊ,��ת����һ��
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
