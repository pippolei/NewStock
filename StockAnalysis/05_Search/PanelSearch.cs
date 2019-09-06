using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace StockAnalysis.Panel
{
    
    public partial class PanelSearch : UserControl
    {
        private DataManager db = new DataManager();
        
        public PanelSearch()
        {
            InitializeComponent();
            this.txt_fromdate.Value = System.DateTime.Now.AddDays(-7);
        }

        private int fromdate, todate;
        private System.Collections.ArrayList list = new System.Collections.ArrayList();
        private void SearchData()
        {      
            //记录买入时间
            DateTime buytime = DateTime.Now;
            int progress = 0;

            int totalnum = StockApp.allstock.Count * pnl_buysell.GetSelectedCombGroup().Length;
            int rulenum = 0;
            int lastdate = StockDapan.GetLastDate();
            foreach (combineRule combinerule in pnl_buysell.GetSelectedCombGroup())
            {
                Buy buyitem = combinerule.buy;
                Sell sellitem = combinerule.sell;
                rulenum++;
                progress = rulenum * StockApp.allstock.Count;
                int buyvalue = chk_ml.Checked ? Rule.STATUS_BUY_ML : Rule.STATUS_BUY;
                StockOpeItem[] opeitems = StockAnalysisSQL.GetAnalysis2List(buyvalue, fromdate, todate, buyitem.ToString(), sellitem.ToString(), 
                    -0.99, //SCORE
                    false, //NO DEFAULT apply
                    false); // no restrict max sell date

                foreach (StockOpeItem item in opeitems)
                {
                    //sellprice > 0, 说明已卖出
                    if (chk_hidesold.Checked && item.selldate < Math.Min(lastdate, todate))
                    {
                        continue;
                    }

                    list.Add(item.ToRowInfo());

                }
            }
        }
        
        private void AddList()
        {   
            foreach (object[] strs in list)
            {
                dg_list.Rows.Add(strs);
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            this.dg_list.Rows.Clear();
            fromdate = Convert.ToInt32(this.txt_fromdate.Value.ToString("yyyyMMdd"));
            todate = Convert.ToInt32(this.txt_todate.Value.ToString("yyyyMMdd"));

            this.list.Clear();
            SearchData();
            AddList();
            
        }

       

        

    }
}
