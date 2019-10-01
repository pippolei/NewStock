using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace StockAnalysis.Panel
{
    public partial class PanelAnalysis2 : UserControl
    {
        private DataManager db = new DataManager();
        private String TAG = "Analysis";
        private PanelProgress prog;
        
        private int analyse_total;
        int startdate, enddate;

        public PanelAnalysis2()
        {
            InitializeComponent();
            this.txt_startdate.Value = Util.getDate(StockApp.getAnalysisStartDate).AddMonths(StockApp.STOCK_START_DATE_SHITE_MONTH); //加2年
            this.txt_enddate.Value = new DateTime(System.DateTime.Now.Year, 12, 31);
            startdate = Convert.ToInt32(this.txt_startdate.Value.ToString("yyyyMMdd"));
            enddate = Convert.ToInt32(this.txt_enddate.Value.ToString("yyyyMMdd"));
            
            panel_result.Init(1, this.pnl_buysell);
            this.pnl_buysell.setReadOnly(true);
        }

        //日期相关
        private void setDate()
        {
            startdate = Convert.ToInt32(this.txt_startdate.Value.ToString("yyyyMMdd"));
            enddate = Convert.ToInt32(this.txt_enddate.Value.ToString("yyyyMMdd"));
            panel_result.setDate(startdate, enddate);
        }
        private void txt_enddate_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }
        private void txt_startdate_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }
        
        //正式分析
        private void Analyse()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            int itemnum = 0;

            list.Clear();
            
            
            foreach (Buy buyitem in pnl_buysell.GetAllBuy())
            {
                foreach (Sell sellitem in pnl_buysell.GetAllSell())
                {
                    foreach (int buyrule in Rule.rulebuy_list)
                    {
                        //计算的时候可以看到并没有考虑止损， 但实际显示结果时都有考虑
                        StockOpeItem[] rule_items = StockAnalysisSQL.CalculateSave2Analysis2(startdate, enddate, buyitem.ToString(), sellitem.ToString(), buyrule);
                        
                        //计算当前分析进度

                        foreach (StockOpeItem rule_item in rule_items)
                        {
                            if (rule_item.grade < buyitem.minumum_grade) continue;
                            list.Add(rule_item);
                        }
                    } 
                    itemnum++;
                    prog.SetProgress(itemnum * 100 * StockApp.allstock.Count / analyse_total);
                    UtilLog.AddInfo(TAG, buyitem.ToString() + "-" + sellitem.ToString() + " analysis finished ");
                }
            }// for each buy
           StockAnalysisSQL.SaveToDB_Analysis2(list);
                      
           UtilLog.AddInfo(TAG, startdate + " till " + enddate + "  buy analyse finished.");
        }
   
        private void btn_analyze_Click(object sender, EventArgs e)
        {

            setDate();
            //设置进度条:计算分析总数
            analyse_total = pnl_buysell.GetAllBuy().Length * pnl_buysell.GetAllSell().Length * StockApp.allstock.Count;
            prog = new PanelProgress("Analysing", analyse_total);

            prog.Show();
            prog.doWork += new PanelProgress.ProHandler(Analyse);
            prog.compWork += new PanelProgress.ProHandler(panel_result.SyncList);
            prog.Start();
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            panel_result.SyncList();
            panel_result.ShowDetail(false);
            
        }


    }
}
