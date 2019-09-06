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
    public partial class PanelStockList : UserControl
    {
        private UtilLog utillog = new UtilLog();
        public PanelStockList()
        {
            InitializeComponent();
            AddColumn();
        }
        //添加属性列
        public void AddColumn()
        {
            foreach (string attr in StockAttribute.attributes)
            {
                dg_detail.Columns.Add("btn_" + attr, attr);
            }
            foreach (string kpi in StockKPI.KPIs)
            {
                dg_detail.Columns.Add("btn_" + kpi, kpi);
            }
        }
        public void Clear()
        {
            dg_list.Rows.Clear();
        }
        //初始显示股票列表
        public void Init()
        {
            dg_list.Rows.Clear();

            string[] strs;
            foreach (StockData s in StockApp.allstock.Values)
            {
                strs = new string[2];
                
                if (StockApp.isProductive)
                {
                    strs[0] = s.code;
                    strs[1] = s.name;
                }
                else
                {
                    strs[0] = s.code;
                    strs[1] = s.code;
                }
                
                dg_list.Rows.Add(strs);
            }
        }
        //右键返回
        private void dg_detail_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lbl_code.Text = "";
                lbl_name.Text = "";
                ShowDetail(false);
            }
        }
        //是否显示detail
        private void ShowDetail(Boolean show)
        {
            this.dg_list.Visible = !show;
            this.dg_detail.Visible = show;
            this.pnl_detail.Visible = show;
        }


        private void dg_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dg_detail.Rows.Clear();

            DataGridViewRow row = null;
            try
            {
                row = this.dg_list.Rows[this.dg_list.SelectedCells[0].RowIndex];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            
            StockData stock = StockSQL.GetStockDetail_2((string)row.Cells[0].Value, (string)row.Cells[1].Value);

            lbl_code.Text = stock.code;
            lbl_name.Text = stock.name;
            foreach (StockItem s in stock.items)
            {
                dg_detail.Rows.Add(s.ToRowInfo());
            }
            ShowDetail(true);
        }

        public string[] GetSelectedList()
        {
            DataGridViewSelectedRowCollection rows = this.dg_list.SelectedRows;
            int size = rows.Count;
            string[] codes = new string[size];
            for (int i = 0; i < size; i++)
            {
                codes[i] = (string)rows[i].Cells[0].Value;
            }
            return codes;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {   
            Util.ExportCSV(this.dg_detail);
        }
        
        public void exportAll()
        {
            int size = this.dg_list.Rows.Count;
            dg_detail.Rows.Clear();
            DataGridViewRow row = this.dg_list.Rows[0];
            StockData stock = StockSQL.GetStockDetail_2((string)row.Cells[0].Value, (string)row.Cells[1].Value);

            foreach (StockItem s in stock.items)
            {
                dg_detail.Rows.Add(s.ToRowInfo());
            }
            Util.ExportCSV(this.dg_detail, "StockAll.csv", true);
            
            dg_detail.Rows.Clear();
            for (int i = 1; i < size; i++)
            {   
                row = this.dg_list.Rows[i];
                stock = StockSQL.GetStockDetail_2((string)row.Cells[0].Value, (string)row.Cells[1].Value);
                foreach (StockItem s in stock.items)
                {
                    dg_detail.Rows.Add(s.ToRowInfo());
                }
                UtilLog.AddInfo("stock list",  i + "/" + size + " completed");
                if (i % 500 == 0)
                {
                    Util.ExportCSV(this.dg_detail, "StockAll.csv", false);
                    dg_detail.Rows.Clear();
                }
            }
            Util.ExportCSV(this.dg_detail, "StockAll.csv", false);
            MessageBox.Show("done");
        }

    }
}