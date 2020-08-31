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
    public partial class PanelRuleList : UserControl
    {
        private UtilLog util = new UtilLog();


        private int startdate = StockApp.STOCK_START_DATE;
        private int enddate = StockApp.END_DATE;

        public PanelRuleList()
        {
            InitializeComponent();
            this.dtm_from.Value = Util.getDate(StockApp.STOCK_START_DATE).AddMonths(StockApp.STOCK_START_DATE_SHITE_MONTH);
            this.dtm_to.Value = DateTime.Today;
            Init();
        }

        //初始化
        private void Init()
        {

            cmb_kpi.Items.Clear();
            cmb_kpi.Items.Add(" ");

            //选中第一个KPI
            foreach (string s in StockKPI.PURE_KPIs)
            {
                cmb_kpi.Items.Add(s);
            }
            //选中大盘filter
            cmb_dapan.Items.Clear();
            cmb_dapan.Items.Add(" ");
            //选中第一个KPI
            foreach (string s in StockDapan.namelist)
            {
                cmb_dapan.Items.Add(s);
            }

        }
        
        public void SyncList()
        {
            this.dg_overview.Rows.Clear();
            StockRuleItem[] items = null, items2 = null;
            
             int selectedIndex = 0, selectedDaPan = 0;
             string selectedDaPanValue = "";
             if (cmb_kpi.SelectedIndex > 0) selectedIndex = cmb_kpi.SelectedIndex;
             if (cmb_dapan.SelectedIndex > 0) selectedDaPan = cmb_dapan.SelectedIndex;

             if (selectedDaPan > 0)
             {
                 selectedDaPanValue = StockDapan.namelist[cmb_dapan.SelectedIndex - 1];
             }
             double minumum_grade = (double)this.num_grade.Value  / 100;
             foreach (Buy rule in StockApp.listbuy)
             {   
                 items = StockRuleSQL.GetRuleBuyList(rule.ToString(), startdate, enddate, Rule.STATUS_BUY_ML);
                 AddList(items, Rule.STATUS_BUY_ML, rule.ToString(), selectedDaPanValue, 0, 0, minumum_grade);

                 items = StockRuleSQL.GetRuleBuyList(rule.ToString(), startdate, enddate, Rule.STATUS_BUY);
                 items2 = StockRuleSQL.GetRuleBuyList(rule.ToString(), startdate, enddate, Rule.STATUS_BUY_PY);
                 if (selectedIndex > 0 )
                 {
                     AddList(items, Rule.STATUS_BUY, rule.ToString(), selectedDaPanValue, cmb_kpi.SelectedIndex, 0, minumum_grade); //第SelectedIndex个KPI值为0的数据
                     AddList(items, Rule.STATUS_BUY, rule.ToString(), selectedDaPanValue, cmb_kpi.SelectedIndex, 1, minumum_grade);//第SelectedIndex个KPI值为1的数据
                     AddList(items2, Rule.STATUS_BUY_PY, rule.ToString(), selectedDaPanValue, cmb_kpi.SelectedIndex, 0, minumum_grade); //第SelectedIndex个KPI值为0的数据
                     AddList(items2, Rule.STATUS_BUY_PY, rule.ToString(), selectedDaPanValue, cmb_kpi.SelectedIndex, 1, minumum_grade);//第SelectedIndex个KPI值为1的数据

                 }
                 else
                 {
                     AddList(items, Rule.STATUS_BUY, rule.ToString(), selectedDaPanValue, 0, 0, minumum_grade); //第一个0是大盘状态, 第0个KPI值为0
                     AddList(items2, Rule.STATUS_BUY_PY, rule.ToString(), selectedDaPanValue, 0, 0, minumum_grade); //第一个0是大盘状态, 第0个KPI值为0
                 }
             }
             /*foreach (Sell rule in StockApp.listsell)
             {
                 items = StockRuleSQL.GetRuleSellList(rule.ToString(), startdate, enddate);
                 AddList(items, -1, rule.ToString(), selectedDaPanValue, 0, 0, minumum_grade);
             }*/
            
        }
        //添加列表
        private void AddList(StockRuleItem[] items, int type, string rule, string dapan_status, int kpiindex, int kpivalue, double minimum_grade)
        {
            int tradetimes = 0;
            double grade = 0;
            double next1Rate = 0;
            double next2Rate = 0;
            double next3Rate = 0;
            double next4Rate = 0;
            double post1Rate = 0;
            double post2Rate = 0;
            double post3Rate = 0;
            double post4Rate = 0;
            double post5Rate = 0;


            if (items.Length == 0) return;
            for (int i = 0; i < items.Length; i++)
            {
                //之前同类型的交易结果不理想, 则忽略当前的交易
                if (items[i].pregrade < minimum_grade) continue;
 

                //kpi相关
                if (kpiindex > 0)
                {
                    string[] kpis = items[i].kpis.Split(StockApp.seperator);
                    int value = 0;
                    if (kpis.Length > 1)
                    {
                        value = Convert.ToInt32(kpis[kpiindex - 1]);
                    }

                    if (!(kpivalue == value))
                    {
                        continue;
                    }
                }
                //大盘行情相关
                if (dapan_status != "")
                {
                    if (!(items[i].dapan == dapan_status))
                    {
                        continue;
                    }
                }

                tradetimes++;
                grade += items[i].grade;
                next1Rate += (items[i].next1 / items[i].price) - 1;
                next2Rate += (items[i].next2 / items[i].price) - 1;
                next3Rate += (items[i].next3 / items[i].price) - 1;
                next4Rate += (items[i].next4 / items[i].price) - 1;
                post1Rate += items[i].post1;
                post2Rate += items[i].post2;
                post3Rate += items[i].post3;
                post4Rate += items[i].post4;
                post5Rate += items[i].post5;
            }
            object[] strs = new object[14];
            //处理得到每一行分析数据
            strs[0] = type.ToString();
            strs[1] = rule.ToString();
            strs[2] = kpiindex.ToString() + "/" + kpivalue.ToString();
            strs[3] = tradetimes;
            strs[4] = Math.Round(grade / tradetimes, 4).ToString();
            strs[5] = Math.Round(next1Rate / tradetimes, 4).ToString();
            strs[6] = Math.Round(next2Rate / tradetimes, 4).ToString();
            strs[7] = Math.Round(next3Rate / tradetimes, 4).ToString();
            strs[8] = Math.Round(next4Rate / tradetimes, 4).ToString();
            strs[9] = Math.Round(post1Rate / tradetimes, 4).ToString();
            strs[10] = Math.Round(post2Rate / tradetimes, 4).ToString();
            strs[11] = Math.Round(post3Rate / tradetimes, 4).ToString();
            strs[12] = Math.Round(post4Rate / tradetimes, 4).ToString();
            strs[13] = Math.Round(post5Rate / tradetimes, 4).ToString();
            dg_overview.Rows.Add(strs);
        }
        private void dg_overview_DoubleClick(object sender, EventArgs e)
        {
            dg_detail.Rows.Clear();
            DataGridViewRow row = this.dg_overview.Rows[this.dg_overview.SelectedCells[0].RowIndex];
            int type = Convert.ToInt16(row.Cells[0].Value);
            string rulename = (string)row.Cells[1].Value;
            StockRuleItem[] items = null;
            
                if (Rule.contains(type))
                {
                    items = StockRuleSQL.GetRuleBuyList(rulename, startdate, enddate, type);
                }
                else
                {
                    items = StockRuleSQL.GetRuleSellList(rulename, startdate, enddate);
                }
            
            
            foreach (StockRuleItem s in items)
            {
                if (s.pregrade < (double)this.num_grade.Value / 100) continue;
                dg_detail.Rows.Add(s.ToRowInfo());
            }
            ShowDetail(true);
        }
        
        
        
        

        private void ShowDetail(bool visible)
        {
            dg_overview.Visible = !visible;
            dg_detail.Visible = visible;
            btn_export.Visible = visible;
            dtm_from.Visible = !visible;
            dtm_to.Visible = !visible;
            btn_exportAll.Visible = !visible;
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
            string filename = Util.GetSaveFile();
            Util.ExportCSV(this.dg_detail, filename);
        }

        private void btn_exportAll_Click(object sender, EventArgs e)
        {
            int size = this.dg_overview.Rows.Count;

            dg_detail.Rows.Clear();
            DataGridViewRow row = this.dg_overview.Rows[0];
            int type = Convert.ToInt16(row.Cells[0].Value);
            string rulename = (string)row.Cells[1].Value;
            StockRuleItem[] items = null;
           
                if (Rule.contains(type))
                {
                    items = StockRuleSQL.GetRuleBuyList(rulename, startdate, enddate, type);
                }
                else
                {
                    items = StockRuleSQL.GetRuleSellList(rulename, startdate, enddate);
                }
            
            foreach (StockRuleItem s in items)
            {
                dg_detail.Rows.Add(s.ToRowInfo());
            }
            Util.ExportCSV(this.dg_detail, "StockRuleAll.csv", true);
            

            for (int i = 1; i < size; i++)
            {
                dg_detail.Rows.Clear();
                row = this.dg_overview.Rows[0];
                
                type = Convert.ToInt16(row.Cells[0].Value);
                rulename = (string)row.Cells[1].Value;

                if (Rule.contains(type))
                    {
                        items = StockRuleSQL.GetRuleBuyList(rulename, startdate, enddate, type);
                    }
                    else
                    {
                        items = StockRuleSQL.GetRuleSellList(rulename, startdate, enddate);
                    }
                }
                foreach (StockRuleItem s in items)
                {
                    dg_detail.Rows.Add(s.ToRowInfo());
                }
                Util.ExportCSV(this.dg_detail, "StockRuleAll.csv", false);
            
            MessageBox.Show("done");


            
            

            
            ShowDetail(true);
        }

        //选中过滤RULE的
        private void dtm_from_ValueChanged(object sender, EventArgs e)
        {
            setDate(Util.getIntDate(dtm_from.Value), Util.getIntDate(dtm_to.Value));

        }
        private void dtm_to_ValueChanged(object sender, EventArgs e)
        {
            setDate(Util.getIntDate(dtm_from.Value), Util.getIntDate(dtm_to.Value));
        }
        public void setDate(int date1, int date2)
        {
            startdate = date1;
            enddate = date2;
        }

        
        


    }
}
