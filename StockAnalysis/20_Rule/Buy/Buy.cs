using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    public class BuyGroup
    {
        private ArrayList buys;
        public BuyGroup(ArrayList _buys)
        {
            buys = _buys;
        }
        public static BuyGroup getBuyGroup(string s)
        {
            string[] name = s.Split('/');
            ArrayList list = new ArrayList();
            for (int j = 0; j < name.Length; j++)
            {
                Buy buy = StockApp.GetBuy(name[j]);
                list.Add(buy);
            }
            return new BuyGroup(list);
        }
        //是否应该买
        public bool isBuy(StockData stock, int index)
        {
            //检查是否能够买入 当天涨停不能买入
            if (Convert.ToDouble(stock.items[index].attributes[StockAttribute.RIZE]) > 0.09)
            {
                return false;
            }
            foreach (Buy buy in buys)
            {
                //只要有一个不符合则不买入
                if (!buy.isBuy(stock, index))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string[] strs = GetBuyNames();
            string s = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                s += "/" + strs[i];
            }
            return s;
        }
        public string[] GetBuyNames()
        {
            int length = buys.Count;
            string[] s = new string[length];
            for (int i = 0; i < length; i++)
            {
                s[i] = buys[i].ToString();
            }
            return s;
        }
    }
    public abstract class Buy
    {
        public string defaultSell = StockApp.DEFAULT_SELLs[1];
        public double minumum_grade = -0.99;
        


        public Boolean isBuy(StockData stock, int index)
        {
            //检查是否能够买入
            if (Convert.ToDouble(stock.items[index].attributes[StockAttribute.RIZE]) > 0.09)
            {
                return false;
            }
            Prepare(stock, index);
            bool getbuy = GetBuy(stock, index);

            return getbuy;
        }

        //子类可以在判断前先使用此函数准备工作
        protected virtual void Prepare(StockData stock, int index)
        {
        }

        protected abstract Boolean GetBuy(StockData stock, int index);
        public override string ToString()
        {
            return this.GetType().Name;
        }
        
    }

    
    public class BuyRandom : Buy
    {
        
        protected override Boolean GetBuy(StockData stock, int index)
        {
            Random random = new Random(Util.GetRandomSeed());

            int value = random.Next();
            if (value % 17 == 0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "RandomBuy";
        }

    }

}
