using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    //���߽���ϵͳ
    //�ȴ�����������(��130��߼ۻ�ͼ۵Ĵ���) ��ʱʹ����߼� ��ͼ�
    //������ȥ20�콻������߼�����ͼ�֮��ļ۲�(��������) ��ʱʹ�����̼�
    //�۲�����������̼�, ��Ϊ�����
    //�۲����������̼�, ��Ϊ������
    //������µ�130��߼ۻ�ͼ�, ���ظ�ǰ�沽��
    //���µ�����������ǰ�����,����������
    //���µ������������ǰ������,�����������
    public class BuyLong: Buy
    {
        public BuyLong()
        {
            this.defaultSell = StockApp.DEFAULT_SELLs[3];
        }
        private string stockcode = "";
        private double buyprice = 10000, sellprice = 0;
        
        //Ŀǰ����߻����ֵ��ɵ���������
        //0δ����, 1�ȴ�����, -1�ȴ�����
        private int lststatus = 0;

        private void ReGeneratePrice(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            //�����ȥ20��ĸߵͼ�
            double localhigh = (double)stock.items[index].attributes[StockAttribute.HIGH20];
            double locallow = (double)stock.items[index].attributes[StockAttribute.LOW20];

            //�жϵ�ǰ�Ǵ��߼ۻ��Ǵ��ͼ�
            int nowstatus = 0;
            //���¸�, �ȴ�����
            if (items[index - 1].high + 0.0001 > (double)(items[index - 1].attributes[StockAttribute.HIGH60]))
            {
                nowstatus = Rule.STATUS_SELL;
            }
            //���µ�, �ȴ�����
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

            //����Ϊ130��߼ۻ�ͼ۵Ĵ���

            //��Ϊ130��߼�, ���ȥ�۲�Ϊ������
            /*if (items[index - 1].high + 0.0001 >  (double)(items[index - 1].attributes[StockAttribute.HIGH130]))
            {
                ReGeneratePrice(stock, index);
                //UtilLog.AddDebug(this.ToString(), stock.code + "High index = " + (index - 1).ToString());
            }*/
            //��Ϊ130��ͼ�, ����ͼۼ��ϲ��Ϊ�ȴ������, ��ȥ�۲�Ϊ������ֹ���
            if (items[index - 1].low - 0.0001 < (double)(items[index - 1].attributes[StockAttribute.LOW60]))
            {
                
                ReGeneratePrice(stock, index);
                UtilLog.AddDebug(this.ToString(), stock.code + "Low index = " + (index - 1).ToString());
                UtilLog.AddDebug(this.ToString(), stock.code + "buyprice = " + (buyprice).ToString());
            }//if
            //��һ�μ���ù�Ʊ, ��ʼ��
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
