using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace StockAnalysis.Panel
{
    public partial class PanelCombineRuleList : UserControl
    {
        private UtilLog util = new UtilLog();
        private int istype_Group = 0;
        private PanelCalcSetting calcpanel = null;
        private int startdate = StockApp.STOCK_START_DATE;
        private int enddate = StockApp.END_DATE;
        public PanelCombineRuleList()
        {
            InitializeComponent();
        }

        public void setDate(int date1, int date2)
        {
            startdate = date1;
            enddate = date2;
        }
        public void Init(int type, PanelCalcSetting panel)
        {
            istype_Group = type;
            calcpanel = panel;
        }

        private void dg_overview_DoubleClick(object sender, EventArgs e)
        {
            dg_detail.Rows.Clear();
            DataGridViewRow row = this.dg_overview.Rows[this.dg_overview.SelectedCells[0].RowIndex];
            int type = Convert.ToInt16(row.Cells[0].Value);
            string buyrule = (string)row.Cells[1].Value;
            string sellrule = (string)row.Cells[2].Value;
            StockOpeItem[] items = null;
            items = StockAnalysisSQL.GetAnalysis2List(type, startdate, enddate, buyrule, sellrule, (double)this.cmb_scorefilter.Value / 100);
            
            int index = 0;
            foreach (StockOpeItem s in items)
            {
                index++;
                dg_detail.Rows.Add(s.ToRowInfo());
            }
            ShowDetail(true);
        }


        private void AddList(StockOpeItem[] items, int type, string buyrule, string sellrule)
        {
            int tradetimes = 0;
            double next1 = 0;
            double next1Rate = 0;

            for (int i = 0; i < items.Length; i++)
            {
                tradetimes++;
                if (items[i].sellprice > items[i].buyprice)
                {
                    next1++;
                }
                next1Rate += (items[i].sellprice - items[i].buyprice) / items[i].buyprice;
            }

            object[] strs = new object[12];
            //处理得到每一行分析数据
            strs[0] = type;
            strs[1] = buyrule.ToString();
            strs[2] = sellrule.ToString();
            strs[3] = StockApp.GetBuy(buyrule).defaultSell;
            strs[4] = tradetimes;
            strs[5] = Math.Round(next1 / tradetimes, 4).ToString();
            strs[6] = Math.Round(next1Rate / tradetimes, 4).ToString();           

            dg_overview.Rows.Add(strs);
        }
        
        public void SyncList()
        {
            this.dg_overview.Rows.Clear();
            StockOpeItem[] items = null;
            foreach (Buy buyitem in calcpanel.GetAllBuy())
            {
                foreach (Sell sellitem in calcpanel.GetAllSell())
                {
                    foreach (int rulevalue in Rule.rulebuy_list)
                    {
                        items = StockAnalysisSQL.GetAnalysis2List(rulevalue, startdate, enddate, buyitem.ToString(), sellitem.ToString(), (double)this.cmb_scorefilter.Value / 100
                        
                        );
                        AddList(items, rulevalue, buyitem.ToString(), sellitem.ToString());
                
                    }
                }
            }            
            
        }

        
        public void ShowDetail(bool visible)
        {
            dg_overview.Visible = !visible;
            dg_detail.Visible = visible;
            btn_export.Visible = visible;
            btn_getresult.Visible = !visible;

        }

    

        private void btn_getresult_Click(object sender, EventArgs e)
        {
            SyncList(); 
        }

        private void dg_detail_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowDetail(false);
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string filename = Util.GetFile();
            Util.ExportCSV(this.dg_detail, filename);
        }

        private void chk_defaultSell_CheckedChanged(object sender, EventArgs e)
        {
            SyncList(); 
        }


    }
}
