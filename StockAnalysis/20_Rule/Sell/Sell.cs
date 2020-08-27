using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StockAnalysis
{
    /*public class SellGroup
    {
        private ArrayList sells;
        public SellGroup(ArrayList _sells)
        {
            sells = _sells;
        }
        public static SellGroup getSellGroup(string s)
        {
            string[] name = s.Split('/');
            ArrayList list = new ArrayList();
            for (int j = 0; j < name.Length; j++)
            {
                Sell sell = StockApp.GetSell(name[j]);
                list.Add(sell);
            }
            return new SellGroup(list);
        }
        public bool isSell(StockData stock, int index)
        {
            foreach (Sell sell in sells)
            {
                if (!sell.isSell(stock, index))
                {
                    return false;
                }
            }
            return true;
        }
        public static double getSellPrice(StockData stock, int index)
        {
            StockItem[] items = stock.items;
            if ((index + 1) == items.Length)
            {
                return items[index].end;
            }
            if (items[index + 1].high < items[index].end)
            {
                return items[index + 1].end;
            }
            return items[index].end;
        }
        public override string ToString()
        {
            string[] strs = GetSellNames();
            string s = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                s += "/" + strs[i];
            }
            return s;
        }
        public string[] GetSellNames()
        {
            int length = sells.Count;
            string[] s = new string[length];
            for (int i = 0; i < length; i++)
            {
                s[i] = sells[i].ToString();
            }
            return s;
        }
    }
    */
    
    public abstract class Sell
    {
        //public string defaultSell = StockApp.DEFAULT_SELLs[2];
        public Boolean isSell(StockData stock, int index)
        {
            Prepare(stock, index);
            return GetSell(stock, index);
        }
        protected virtual void Prepare(StockData stock, int index)
        {
        }
        protected abstract Boolean GetSell(StockData stock, int index);
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }

    public class SellDefault : Sell
    {
        protected override Boolean GetSell(StockData stock, int index)
        {
            if ((index + 1)== stock.items.Length) return true;
            return false;
        }
        
    }
   

}
