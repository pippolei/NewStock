using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StockAnalysis.Panel
{
    public partial class PanelDatabase : Form
    {
        public PanelDatabase()
        {
            InitializeComponent();
        }

        private void PanelDatabase_Load(object sender, EventArgs e)
        {
            this.txt_server.Text = DataManager.server;
            this.txt_db.Text = DataManager.database;
            this.txt_user.Text = DataManager.user;
            this.txt_password.Text = DataManager.password;
            this.txt_dataurl.Text = StockApp.txtSrc;
            this.txt_startdate.Text = StockApp.STOCK_START_DATE.ToString();
            this.chk_productive.Checked = StockApp.isProductive;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataManager.changeDB(this.txt_server.Text, this.txt_db.Text,
                txt_user.Text,txt_password.Text);
            StockApp.txtSrc = this.txt_dataurl.Text;
            StockApp.STOCK_START_DATE = Convert.ToInt32(this.txt_startdate.Text);
            StockApp.isProductive = this.chk_productive.Checked;
            UtilPreference.WriteDB();
            MessageBox.Show(this, "Update Done");
            this.Close();
            Application.Exit();
        }
    }
}
