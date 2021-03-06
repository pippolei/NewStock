using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis
{
    public abstract class Rule
    {
        public static readonly int STATUS_BUY = 1;
        public static readonly int STATUS_BUY_PY = 2;
        public static readonly int STATUS_BUY_ML = 3;
        public static readonly int STATUS_BUY_ML_TEST = 4;
        public static readonly int STATUS_SELL = -1;
        public static readonly int[] rulebuy_type = new int[] { STATUS_BUY,STATUS_BUY_PY, STATUS_BUY_ML,STATUS_BUY_ML_TEST };

        public static bool contains(int type)
        {
            int size = rulebuy_type.Length;
            for (int i = 0; i < size; i++)
            {
                if (rulebuy_type[i] == type) return true;
            }
            return false;
        }

    }
    
    public class combineRule
    {
        public Buy buy;
        public Sell sell;

        public combineRule(Buy buyrule, Sell sellrule)
        {
            buy = buyrule;
            sell = sellrule;
        }
        public static combineRule getCombRule(string name)
        {
            string[] names = name.Split('-');
            string buyname = names[0];
            string sellname = names[1];
            Buy bg = StockApp.GetBuy(buyname);
            Sell sg = StockApp.GetSell(sellname);
            return new combineRule(bg, sg);
        }
        public override string ToString()
        {
            return buy.ToString() + "-" + sell.ToString();
        }
        public static string CombindRuleString(string buyname, string sellname)
        {
            return buyname + "-" + sellname;
        }
        
    }

   

}
