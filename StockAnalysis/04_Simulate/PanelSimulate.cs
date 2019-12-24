using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using StockAnalysis.Panel;
using StockAnalysis;
using System.Collections;


namespace StockAnalysis.Panel
{
    public partial class PanelSimulate : UserControl
    {
        private DataManager db = new DataManager();
        private SimulateManager sm;
        private int holdstocknum;
        private  int batch_interval = 36; //批量分析一次的时间间隔
        
        private System.Collections.ArrayList list = new System.Collections.ArrayList();

        #region init stock not used
        //init stock
        /*private void btn_initstock_Click(object sender, EventArgs e)
        {
            simulate_total = StockApp.allstock.Count;
            prog = new PanelProgress("Init Stock", simulate_total);
            prog.Show();
            prog.doWork += new PanelProgress.ProHandler(InitStock);
            prog.compWork += new PanelProgress.ProHandler(SetVisible);
            prog.Start();
        }
        private void InitStock()
        {
            simulate_total = StockApp.allstock.Count;
            StockData[] stocks = StockSQL.GetStockHeaders();
            int size = stocks.Length;
            for (int i = 0; i < size; i++)
            {
                GC.Collect();
                StockApp.GetStock(stocks[i].code);
                prog.SetProgress((i + 1) * 100 / simulate_total);
            }
        }*/
        #endregion
        //只有当init之后才能显示
        private void SetVisible()
        {
            btn_simulate.Visible = true;
        }
        public PanelSimulate()
        {
            InitializeComponent();
            this.txt_fromdate.Value = Util.getDate(StockApp.getAnalysisStartDate).AddMonths(StockApp.STOCK_START_DATE_SHITE_MONTH); //从起始数据的下一年开始分析
            this.txt_todate.Value = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
            this.txt_num.Value = StockApp.BUY_STOCK_NUM;
        }
        //双击显示详细
        private void dg_overview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.pnl_main_bottom.Visible = false;
            this.pnl_main_top.Visible = false;
            DataGridViewRow row = this.dg_overview.Rows[this.dg_overview.SelectedCells[0].RowIndex];
            int type = Convert.ToInt16(row.Cells[0].Value);
            string buyname = (string)row.Cells[1].Value;
            string sellname = (string)row.Cells[2].Value;
            string startdate = (string)row.Cells[3].Value;
            string enddate = (string)row.Cells[4].Value;

            ShowDetail(type, Convert.ToInt32(startdate), Convert.ToInt32(enddate), buyname, sellname);
            this.pnl_main_bg.Visible = true;
        }
        //鼠标右键返回overview
        private void dg_detail_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.pnl_main_bottom.Visible = true;
                this.pnl_main_top.Visible = true;
                this.pnl_main_bg.Visible = false;
            }
        }

        private void btn_simulate_Click(object sender, EventArgs e)
        {
            //得到起始时间和终止时间
            int startdate = Convert.ToInt32(this.txt_fromdate.Value.ToString("yyyyMMdd"));
            int enddate = Convert.ToInt32(this.txt_todate.Value.ToString("yyyyMMdd"));
             
            //仓位股票数量
            holdstocknum = (int)txt_num.Value;
                  
            list.Clear();
            Simulate(startdate, enddate);
            MessageBox.Show("Done");
            
        }
        private void Simulate(int new_startdate, int new_enddate)
        {
            this.dg_overview.Rows.Clear();
            //仓位股票数量
            holdstocknum = (int)txt_num.Value;
            foreach (int buyvalue in Rule.rulebuy_list)
            {   
                for (int i = 0; i < pnl_buysell2.GetSelectedCombGroup().Length; i++)
                {
                    sm = new SimulateManager(new_startdate, new_enddate, holdstocknum);
                    combineRule combinerule = pnl_buysell2.GetSelectedCombGroup()[i];
                    //得到所有符合买卖原则的数据
                    StockOpeItem[] items = StockAnalysisSQL.GetAnalysis2List(buyvalue, new_startdate, new_enddate, combinerule.buy.ToString(), combinerule.sell.ToString(), -0.99,
                        true,  //apply default Sell 
                        true);
                    foreach (StockOpeItem item in items)
                    {
                        sm.AddOpeItem(item);
                    }
                    sm.Simulate(new_startdate, new_enddate);
                    sm.SaveToDB(buyvalue, combinerule.buy.ToString(), combinerule.sell.ToString());
                }                
            }           
            
        }

        
        //显示详细分析的操作记录
        private void ShowDetail(int type, int new_startdate, int new_enddate, string buyname, string sellname)
        {
            this.dg_detail.Rows.Clear();
            //得到起始时间和终止时间
            int startdate = new_startdate; // Convert.ToInt32(this.txt_fromdate.Value.ToString("yyyyMMdd"));
            int enddate = new_enddate; // Convert.ToInt32(this.txt_todate.Value.ToString("yyyyMMdd"));
            
            StockSimulateItem[] items = StockSimulateSQL.GetSimulateList(type, startdate, enddate, buyname, sellname);

            int rowsize = items.Length;
            for (int row = 0; row < rowsize; row++)
            {   
                this.dg_detail.Rows.Add(items[row].ToRowInfo());
            }
        }

        private void btn_exportdetail_Click(object sender, EventArgs e)
        {            
            Util.ExportCSV(this.dg_detail);
        }

        



       

        private void AddOverview(int type, int new_startdate, int new_enddate, string buyrule, string sellrule)
        {

            double growth = (int)(StockSimulateSQL.GetAverageGrowth(new_startdate, new_enddate) * StockApp.INIT_VALUE);
            
            
            {
                double value = StockSimulateSQL.GetFinalValue(type, new_startdate, new_enddate, buyrule, sellrule);
                string[] s = new string[7];
                s[0] = type.ToString();
                s[1] = buyrule.ToString();
                s[2] = sellrule.ToString();
                s[3] = new_startdate.ToString();
                s[4] = new_enddate.ToString();
                s[5] = value.ToString();
                s[6] = growth.ToString();
                dg_overview.Rows.Add(s);
            }
           
        }
        private void btn_allresult_Click(object sender, EventArgs e)
        {
            getAllResult();
        }

        private void getAllResult()
        {
            this.dg_overview.Rows.Clear();
            string sql = "select * from Ope_simulate;";
            DataTable dt = db.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int type = Convert.ToInt16(dr["type"]);
                int startdate = Convert.ToInt32(dr["startdate"]);
                int enddate = Convert.ToInt32(dr["enddate"]);
                string buyname = dr["buyrule"].ToString();
                string sellname = dr["sellrule"].ToString();
                AddOverview(type, startdate, enddate, buyname, sellname);
            }
        }



        private void deleteSimulatRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dg_overview.Rows[this.dg_overview.SelectedCells[0].RowIndex];
            int type = Convert.ToInt16(row.Cells[0].Value);
            string startdate = (string)row.Cells[1].Value;
            string enddate = (string)row.Cells[2].Value;

            DialogResult result = MessageBox.Show("Confirm delete startdate = " + startdate + ", enddate = " + enddate, "Delete Record", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                StockSimulateSQL.ClearDB(type, Convert.ToInt32(startdate), Convert.ToInt32(enddate), "buy", "sell");
                MessageBox.Show("Delete Simulate Done!");
            }    
            
            this.dg_detail.Rows.Clear();
            getAllResult();
        }



        private void chk_toend_CheckedChanged(object sender, EventArgs e)
        {
            this.num_interval.Enabled = false;
        }

        private void num_interval_ValueChanged(object sender, EventArgs e)
        {
            batch_interval = (int)this.num_interval.Value;
        }


        private void btn_batch_Click(object sender, EventArgs e)
        {
            int[] startdates = new int[] { 20120101, 20140101, 20160101, 20130101, 20140101, 20150101, 20160101, 20170101, 20180101, 20190101 };
            int[] enddated = new int[] { 20200101, 20200101, 20200101, 20140101, 20150101, 20160101, 20170101, 20180101, 20190101, 20200101 };

            for (int i = 0; i < startdates.Length; i++)
            {
                int tempdate = startdates[i];                
                Simulate(tempdate, enddated[i]);
            }

            MessageBox.Show("Done!");
            

        }




        #region not used
        
        
        #endregion

        


    }
}
