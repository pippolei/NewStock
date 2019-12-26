using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace StockAnalysis.Panel
{
    public partial class PanelCalcSetting: UserControl
    {
        private DataManager db = new DataManager();
        private String TAG = "RuleCalc";
        private int analyse_total;
        private int analyse_now;
        private PanelProgress prog;
        private ArrayList filterlist = null;
        private ArrayList dapanlist = null;

        public PanelCalcSetting()
        {
            InitializeComponent();
            this.lst_buy.SelectionMode = SelectionMode.One; 
        }

        public void setReadOnly(bool isreadonly)
        {
            this.btn_calc.Visible = !isreadonly;
            this.btn_add.Visible = !isreadonly;
            this.btn_del.Visible = !isreadonly;
            this.lst_buy.Enabled = !isreadonly;
            this.lst_sell.Enabled = !isreadonly;
            this.chkl_status.Items.Clear();
        }
        
        //��ʼ��������Ҫ�Ĺ���
        private void PanelBuySell_Load(object sender, EventArgs e)
        {
            foreach (Buy rule in StockApp.listbuy)
            {
                this.lst_buy.Items.Add(rule);
            }
            foreach (Sell rule in StockApp.listsell)
            {
                this.lst_sell.Items.Add(rule);
            }
            
            //ѡ�е�һ��KPI
            foreach (string s in StockDapan.namelist)
            {
                chkl_status.Items.Add(s);
            }
            
        }
        private void CalculateData()
        {
            //��ÿ����Ʊ���з���
            StockSQL.DeleteRule();

            analyse_now = 0;
            foreach (StockData stockheader in StockApp.allstock.Values)
            {
                //��ʼ����Ʊ
                StockData stock = StockSQL.GetStockDetail_2(stockheader.code, stockheader.name);
                UtilLog.AddInfo(TAG, "Start to calculate " + stock.code);
                int stock_length = stock.items.Length;
                //�ڼ��������Ĺ�Ʊ
                analyse_now++;

                CalBuy(stock);
                CalSell(stock);

                prog.SetProgress(analyse_now * 100 / analyse_total);
                //�ͷ��ڴ�
                if (analyse_now % 100 == 0)
                {
                    UtilLog.AddInfo(TAG, "Start to free memory");
                    GC.Collect();
                    UtilLog.AddInfo(TAG, "Free memory done!");
                    System.Threading.Thread.CurrentThread.Join(500);
                }
                UtilLog.AddInfo(TAG, analyse_now + "/" + analyse_total + ":" + stock.name + "(" + stock.code + ")" + " calculate finished ");
            }

            RuleScore.SetRuleScore();
            RuleScore.SetAllPreScore();
            

        }
        //������������
        private void CalBuy(StockData stock)
        {
            //���趨ʱ�俪ʼ����
            int analyse_startindex = StockApp.START_ANALYSIS;

            int id = db.GetMaxTableId(StockSQL.TABLE_RULE_BUY0);
            SQLMassImport rulefile = new SQLMassImport("RuleBuy");
            foreach (Buy rule in GetAllBuy())
            {   
                int stock_length = stock.items.Length;
                
                for (int i = analyse_startindex; i < stock_length; i++)
                {
                    StockItem item = stock.items[i];
                    if (rule.isBuy(stock, i))
                    {
                        id++;
                        string[] attristrs = new string[21];
                        attristrs[0] = Rule.STATUS_BUY.ToString();
                        attristrs[1] = id.ToString();
                        attristrs[2] = rule.ToString();
                        attristrs[3] = stock.code;
                        attristrs[4] = item.date.ToString();
                        attristrs[5] = item.index.ToString();
                        attristrs[6] = item.end.ToString();
                        attristrs[7] = "0"; //pregrade
                        attristrs[8] = stock.getGrade(rule.defaultSell, i).ToString();//grade
                        attristrs[9] = stock.getKPIs(i);
                        attristrs[10] = stock.getNumKPIs(i);
                        attristrs[11] =  StockDapan.GetDaPanScore(item.date).ToString();   //dapan
                        attristrs[12] = item.kpi[StockApp.DEFAULT_SELLs[0] + StockKPI.default_price].ToString();   //short
                        attristrs[13] = item.kpi[StockApp.DEFAULT_SELLs[1] + StockKPI.default_price].ToString(); ;   //medium
                        attristrs[14] = item.kpi[StockApp.DEFAULT_SELLs[2] + StockKPI.default_price].ToString(); ;  //long
                        attristrs[15] = item.kpi[StockApp.DEFAULT_SELLs[3] + StockKPI.default_price].ToString();  //end
                        //���������źź�1~5��ı���,���ο�,δ���κεط�ʹ��
                        attristrs[16] = item.attributes[StockAttribute.POST1].ToString();
                        attristrs[17] = item.attributes[StockAttribute.POST2].ToString(); ;
                        attristrs[18] = item.attributes[StockAttribute.POST3].ToString(); ;
                        attristrs[19] = item.attributes[StockAttribute.POST4].ToString(); ;
                        attristrs[20] = item.attributes[StockAttribute.POST5].ToString(); ;
                        rulefile.AddRow(attristrs);
                    }
                }//foreach

                //UtilLog.AddInfo(TAG, rule.ToString() + " calculation finished. ");
            }
            //����������������
            rulefile.ImportClose(db, StockSQL.TABLE_RULE_BUY0);
            UtilLog.AddInfo(TAG, stock.code + " RuleBuy calculation finished. ");            
        }
        //������������
        private void CalSell(StockData stock)
        {
            //���趨ʱ�俪ʼ����
            int analyse_startindex = StockApp.START_ANALYSIS;

            int id = db.GetMaxTableId(StockSQL.TABLE_RULE_BUY0);
            SQLMassImport rulefile = new SQLMassImport("RuleSell");
            foreach (Sell rule in GetAllSell())
            {
                int stock_length = stock.items.Length;
                
                for (int i = analyse_startindex; i < stock_length; i++)
                {
                    StockItem item = stock.items[i];
                    if (rule.isSell(stock, i))
                    {
                        id++;
                        string[] attristrs = new string[21];
                        attristrs[0] = Rule.STATUS_SELL.ToString();
                        attristrs[1] = id.ToString();
                        attristrs[2] = rule.ToString();
                        attristrs[3] = stock.code;
                        attristrs[4] = item.date.ToString();
                        attristrs[5] = item.index.ToString();
                        attristrs[6] = item.end.ToString();
                        attristrs[7] = "0"; //pregrade
                        attristrs[8] = "0";//grade
                        attristrs[9] = "0";
                        attristrs[10] = "0";
                        attristrs[11] = "0"; //stockdapanû����
                        attristrs[12] = "0";
                        attristrs[13] = "0";
                        attristrs[14] = "0";
                        attristrs[15] = "0";
                        //���������źź�1~5��ı���,���ο�,δ���κεط�ʹ��
                        attristrs[16] = item.attributes[StockAttribute.POST1].ToString(); 
                        attristrs[17] = item.attributes[StockAttribute.POST2].ToString(); 
                        attristrs[18] = item.attributes[StockAttribute.POST3].ToString();
                        attristrs[19] = item.attributes[StockAttribute.POST4].ToString();
                        attristrs[20] = item.attributes[StockAttribute.POST5].ToString(); 
                        rulefile.AddRow(attristrs);
                   
                    }
                }
                //UtilLog.AddInfo(TAG, rule.ToString() + " calculation finished. ");
            }
            //����������������
            rulefile.ImportClose(db, StockSQL.TABLE_RULE_BUY0);                
            UtilLog.AddInfo(TAG, stock.code + " RuleSell calculation finished. ");
        }
        private void btn_sync_Click(object sender, EventArgs e)
        {
            db.RunSql("truncate table Rule_Buy");
            string sql = @"insert into Rule_Buy select * from Rule_Buy0";
            db.RunSql(sql);

            ArrayList list = new ArrayList();

            //�Ƴ�filter
            foreach (Buy rule in GetAllBuy())
            {
                string rulename = rule.ToString();
                StockRuleItem[] items = StockRuleSQL.GetRuleBuy0List(rulename, StockApp.STOCK_START_DATE, StockApp.END_DATE);
                for (int i = 0; i < items.Length; i++)
                {
                    if (!isfilter(rulename, items[i]) && items[i].type == Rule.STATUS_BUY)
                    {
                        list.Add("delete from Rule_Buy where type = '" + Rule.STATUS_BUY + "' and id = '" + items[i].id + "';");
                    }
                }
                dapanlist = null;
                filterlist = null; 
            }
            
            //�Ƴ�sequence
            sql = @"select [TYPE], ID from
                (
                select ROW_NUMBER() OVER (PARTITION BY [type], rulename, [date] order by pregrade desc) AS SEQUENCE,* from rule_buy0 
                ) T1
                where T1.SEQUENCE > " + (StockApp.BUY_STOCK_NUM * 2) + " and [TYPE] > 0;";
            DataTable dt = db.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                list.Add("delete from Rule_Buy where type = '" + dr["TYPE"] + "' and id = '" + dr["ID"] + "';");
            }
            db.RunSql(list);

            
            StockRuleSQL.SetAnalysis();
            MessageBox.Show("Rule Sync Done!");
        }
       
        //���stockitem kpi��filter
        private bool isfilter(string rulename, StockRuleItem item)
        {
            if (dapanlist == null)
            {
                //��ʼ�� �õ�����������filter�Ĺ���
                dapanlist = StockRuleSQL.GetDapanFilter(rulename);
            }
            string dapanstatus = StockDapan.GetDaPanScore(item.date);
            if (dapanlist.Contains(dapanstatus))
            {
                return false;
            }

            if (filterlist == null)
            {
                //��ʼ�� �õ�����������filter�Ĺ���
                filterlist = StockRuleSQL.GetRuleFilter(rulename);
            }
            int size = filterlist.Count;
            for (int i = 0; i < size; i++)
            {
                string[] s = (string[])filterlist[i]; //s����kpivalue, kpivalue
                string[] kpis = item.kpis.Split(StockApp.seperator);
                //�жϵ�ǰ�Ƿ����filter����
                //{"kpiname","kpiindex","kpivalue"}
                if (!kpis[Convert.ToInt16(s[1])].ToString().Equals(s[2]))
                {
                    return false;
                }
            }
            return true;
        }
        private void btn_calc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                DialogResult result = MessageBox.Show("Confirm re calculate rule !!!!!!? It'll take long time to regenerate", "Calc Rule", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK)
                {
                    MessageBox.Show("Action Cancelled");
                    return;
                }
            }
            //���ڼ�¼�ѷ�����Ʊ����(����)
            analyse_total = StockApp.allstock.Count;
            analyse_now = 0;

            if (analyse_total == 0)
            {
                MessageBox.Show("Please sync list first!");
                return;
            }

            prog = new PanelProgress("Calculate Rules", analyse_total);
            prog.Show();
            prog.doWork += new PanelProgress.ProHandler(CalculateData);            
            prog.Start();
        }

        //2018-03-14 Reviewed
        #region getrule
        //������������б�
        public Buy[] GetAllBuy()
        {
            int len = lst_buy.Items.Count;
            Buy[] obj = new Buy[len];
            for (int i = 0; i < len; i++)
            {
                obj[i] = (Buy)lst_buy.Items[i];           
            }
            return obj;
        }
        //�������������б�
        public Sell[] GetAllSell()
        {
            int len = lst_sell.Items.Count;
            Sell[] obj = new Sell[len];
            for (int i = 0; i < len; i++)
            {
                obj[i] = (Sell)lst_sell.Items[i];
            }
            return obj;
        }
        
        
        #endregion

        
        #region ��rule kpi filter���
        private void lst_buy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //���û���κ�RULEѡ��, ����ʾfilter
            if (!(lst_buy.SelectedItems.Count > 0))
            {   
                btn_add.Visible = false;
                btn_del.Visible = false;
                return;
            }
            //���ѡ�ж��, Ҳ����ʾfilter
            if ((lst_buy.SelectedItems.Count > 1))
            {
                btn_add.Visible = false;
                btn_del.Visible = false;
                this.lst_kpi.Items.Clear();
                return;
            } 
            //��KPI����ѡ��
            cmb_kpi.Items.Clear();
            //ѡ�е�һ��KPI
            foreach (string s in StockKPI.PURE_KPIs)
            {
                cmb_kpi.Items.Add(s);
            }
            cmb_kpi.SelectedIndex = 0;
            RefreshKpiSelection();

            RefreshDaPan();

        }

        ////2018-03-14 
        private void cmb_kpi_SelectedIndexChanged(object sender, EventArgs e)
        {   
            string rulename = lst_buy.SelectedItems[0].ToString();
            string select_text = this.cmb_kpi.SelectedItem.ToString();
            string sql = "select * from Rule_filter where rulename = '" + rulename + "' and kpiname = '" + select_text + "';";
            if (db.GetSqlCount(sql) > 0)
            {
                isAddbutton(false);
            }
            else
            {
                isAddbutton(true);
            }

        }

        //2018-03-14 ��ť��ʾ���ӻ��߼���
        private void isAddbutton(bool isadd)
        {
            btn_add.Visible = isadd;
            btn_del.Visible = !isadd;
        }
        //2018-03-14 �����ݿ����ӵ�ǰkpi filter
        private void btn_add_Click(object sender, EventArgs e)
        {
            string rulename = lst_buy.SelectedItems[0].ToString();
            string kpiname = this.cmb_kpi.SelectedItem.ToString();
            int kpiindex = this.cmb_kpi.SelectedIndex;
            int selected = (int)this.cmb_isKPI.Value;
            string sql = "insert into Rule_filter values('" + rulename + "','"+kpiname+"','" + kpiindex + "','" + selected + "');";
            db.RunSql(sql);
            RefreshKpiSelection();
            isAddbutton(false);
        }
        //2018-03-14 �����ݿ�ɾ����ǰkpi filter
        private void btn_del_Click(object sender, EventArgs e)
        {
            string rulename = lst_buy.SelectedItems[0].ToString();
            string kpiname = this.cmb_kpi.SelectedItem.ToString();
            int selected = (int)this.cmb_isKPI.Value;
            string sql = "delete from Rule_filter where rulename = '" + rulename + "' and kpiname = '" + kpiname + "';";
            db.RunSql(sql);
            RefreshKpiSelection();
            isAddbutton(true);
            
        }
        //2018-03-14 ˢ��KPI����ʾ����
        private void RefreshKpiSelection()
        {
            if (!(lst_buy.SelectedItems.Count > 0)) return;
            if (!(lst_buy.SelectedItems.Count < 2)) return;
            string rulename = lst_buy.SelectedItems[0].ToString();
            string sql = "select kpiname, kpivalue from Rule_filter where rulename = '" + rulename + "';";
            DataTable dt = db.GetTable(sql);

            this.lst_kpi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string item = dr["kpiname"].ToString() + "=" + dr["kpivalue"].ToString();
                lst_kpi.Items.Add(item);
            }

        }
        #endregion

        #region ��������
        private void RefreshDaPan()
        {
            if (!(lst_buy.SelectedItems.Count > 0)) return;
            if (!(lst_buy.SelectedItems.Count < 2)) return;
            string rulename = lst_buy.SelectedItems[0].ToString();

            //�����в�ѡ��
            for (int i = 0; i < chkl_status.Items.Count; i++)
            {
                this.chkl_status.SetItemChecked(i,false);
            }

            string sql = "select * from Rule_filter_dapan where rulename = '" + rulename + "';";
            DataTable dt = db.GetTable(sql);            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                this.chkl_status.SetItemChecked(StockDapan.GetGradeIndex((string)dr["kpiname"]), true);

            }
        }

        private void chkl_status_SelectedValueChanged(object sender, EventArgs e)
        {
            string rulename = lst_buy.SelectedItems[0].ToString();
            string sql = "delete from Rule_filter_dapan where rulename = '" + rulename + "';";
            foreach (int index in this.chkl_status.CheckedIndices)
            {
                sql += "insert into Rule_filter_dapan values('" + rulename + "','" + chkl_status.Items[index].ToString() + "','X');";
            }
            db.RunSql(sql);
            RefreshDaPan();
            isAddbutton(false);
        }
        
        #endregion

        

        

       

        

        




    }


    
}
