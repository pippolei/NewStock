using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using StockAnalysis.Panel;
using System.Collections;


namespace StockAnalysis.Panel
{
    public partial class PanelLoadData : UserControl
    {
        private DataManager db = new DataManager();
        
        private String TAG = "LoadData";

        private System.Collections.ArrayList filelist = new System.Collections.ArrayList();      
        private PanelProgress prog;

        
        public PanelLoadData()
        {   
            InitializeComponent();
            this.lbl_database.Text = DataManager.database;
            this.txt_date.Value = Util.getDate(StockApp.STOCK_START_DATE);
            this.txt_stockfolder.Text = StockApp.txtSrc + this.lbl_database.Text;
            this.SyncList();
            this.btn_syncData.Enabled = !StockApp.isProductive;
        }
        //得到需要分析的股票列表
        //2018-03-14 Reviewed
        private void SyncList()
        {
            StockApp.InitStockHeader();
            pnl_list.Init();
        }
        


        //得到股票数据文件夹
        //2018-03-14 Reviewed
        private void btn_folder_Click(object sender, EventArgs e)
        {
            string folder = Util.GetFolder();
            if (folder.Length > 1)
            {
                this.txt_stockfolder.Text = folder;
            }
            else
            {
                return;
            }
        }
        //得到股票数据文件夹下所有文件
        //2018-03-14 Reviewed
        private ArrayList GetFileList()
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            
            string dir = this.txt_stockfolder.Text;
            DirectoryInfo folder = new DirectoryInfo(dir);

            foreach (FileInfo f in folder.GetFiles("*.txt"))
            {
                string filename = dir + "\\" + f.ToString();
                list.Add(filename);
            }
            return list;
        }

        //同步股票数据记录
        //2018-03-14 Reviewed
        private void btn_syncData_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                DialogResult result = MessageBox.Show("Confirm resync data!!!!!!? It'll take long time to regenerate", "Calc Data", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK)
                {
                    MessageBox.Show("Action Cancelled");
                    return;
                }    
            }
            
            pnl_list.Clear();
            filelist = GetFileList();
            prog = new PanelProgress("Importing Stock", filelist.Count);
            prog.Show();
            prog.doWork += new PanelProgress.ProHandler(SyncData);
            prog.compWork += new PanelProgress.ProHandler(SyncList);
            prog.Start();
        }

        //同步股票数据
        //2018-03-14 Reviewed
        private void SyncData()
        {
            //更新进度
            int statusNum = 0;

            //删除已有股票
            StockSQL.DeleteStock();
            this.btn_syncData.Enabled = false;

            foreach (object obj in filelist)
            {
                statusNum++;
                string filename = (string)obj;                

                StockData stock = new StockData();                
                stock.Init(filename);
                UtilLog.AddInfo(TAG, "Start to analyse " + stock.code + ";");
                StockAttribute attri = new StockAttribute(stock);
                StockKPI kpi = new StockKPI(stock);

                if (!stock.IsValid())
                {
                    UtilLog.AddInfo(TAG, statusNum + "/" + filelist.Count + "  " + stock.code + " skipped");
                }
                else
                {
                    attri.InitAttribute();
                    kpi.InitKPI();

                    StockSQL.InsertStockWithItem(stock);
                    UtilLog.AddInfo(TAG, statusNum + "/" + filelist.Count + "  " + stock.code + " initialization finished");
                }      
                int status = statusNum * 100 / filelist.Count;
                if (statusNum % 100 == 0)
                {
                    GC.Collect();
                }
                prog.SetProgress(status);
            }
            StockData.SetStockFull();
            StockDapan.InsertStockDaPan();
            this.btn_syncData.Enabled = true;
                        
        }

        //2018-03-14 Reviewed
        private void btn_getlist_Click(object sender, EventArgs e)
        {
            this.SyncList();
        }

        










        
       

    }
}
