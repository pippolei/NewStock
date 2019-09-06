using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StockAnalysis.Panel
{

    public partial class MainApp : Form
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApp());
        }

        private DataManager db = new DataManager();

        public MainApp()
        {
            UtilPreference.Init();
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.pnl_database.Select();
            this.pnl_database.Focus();
        }

        private void tab_main_SelectedIndexChanged(object sender, EventArgs e)
        {            
            System.Windows.Forms.UserControl p = (System.Windows.Forms.UserControl)tab_main.SelectedTab.Controls[0];
            p.Focus();    
        }


        private void resetRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockSQL.DeleteRuleFilter(); //rule_filter, rule_filter_dapan
            MessageBox.Show("Reset Rule Done!");
        }

        private void setDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelDatabase pnl_db = new PanelDatabase();
            pnl_db.ShowDialog();
            tab_main.SelectedIndex = 0;
            tab_database.Controls[0].Refresh();
        }

        private void truncateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm truncate!!!!!!? It'll take long time to regenerate", "Delete Stock", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                StockSQL.DeleteRule();  //rulebuy, rullsell
                StockSQL.DeleteStock(); //header, item, attribute, kpi, dapan
                StockSQL.DeleteAnalysis();
                StockSQL.DeleteSimulate();
                MessageBox.Show("Reset Database Done!");
            }    
        }

        

        private void MainApp_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && StockApp.isProductive)
            {
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetSimulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm delete simulation!!!!!!? It'll take long time to regenerate", "Delete Stock", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                StockSQL.DeleteSimulate();
                MessageBox.Show("Reset Simulate Done!");
            }    
        }

        



       

       
    }
}