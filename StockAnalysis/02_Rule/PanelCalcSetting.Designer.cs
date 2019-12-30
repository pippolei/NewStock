namespace StockAnalysis.Panel
{
    partial class PanelCalcSetting
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_buy = new System.Windows.Forms.ListBox();
            this.lbl_buy = new System.Windows.Forms.Label();
            this.lbl_sell = new System.Windows.Forms.Label();
            this.lst_sell = new System.Windows.Forms.ListBox();
            this.btn_calc = new System.Windows.Forms.Button();
            this.lst_kpi = new System.Windows.Forms.ListBox();
            this.cmb_kpi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_isKPI = new System.Windows.Forms.NumericUpDown();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.chkl_status = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_sync = new System.Windows.Forms.Button();
            this.chk_limited = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_isKPI)).BeginInit();
            this.SuspendLayout();
            // 
            // lst_buy
            // 
            this.lst_buy.FormattingEnabled = true;
            this.lst_buy.ItemHeight = 12;
            this.lst_buy.Location = new System.Drawing.Point(5, 33);
            this.lst_buy.MultiColumn = true;
            this.lst_buy.Name = "lst_buy";
            this.lst_buy.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_buy.Size = new System.Drawing.Size(190, 136);
            this.lst_buy.TabIndex = 0;
            this.lst_buy.SelectedIndexChanged += new System.EventHandler(this.lst_buy_SelectedIndexChanged);
            // 
            // lbl_buy
            // 
            this.lbl_buy.AutoSize = true;
            this.lbl_buy.Location = new System.Drawing.Point(2, 18);
            this.lbl_buy.Name = "lbl_buy";
            this.lbl_buy.Size = new System.Drawing.Size(59, 12);
            this.lbl_buy.TabIndex = 12;
            this.lbl_buy.Text = "Buy Rules";
            // 
            // lbl_sell
            // 
            this.lbl_sell.AutoSize = true;
            this.lbl_sell.Location = new System.Drawing.Point(618, 14);
            this.lbl_sell.Name = "lbl_sell";
            this.lbl_sell.Size = new System.Drawing.Size(65, 12);
            this.lbl_sell.TabIndex = 21;
            this.lbl_sell.Text = "Sell Rules";
            // 
            // lst_sell
            // 
            this.lst_sell.FormattingEnabled = true;
            this.lst_sell.ItemHeight = 12;
            this.lst_sell.Location = new System.Drawing.Point(620, 36);
            this.lst_sell.MultiColumn = true;
            this.lst_sell.Name = "lst_sell";
            this.lst_sell.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_sell.Size = new System.Drawing.Size(204, 136);
            this.lst_sell.TabIndex = 20;
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(67, 10);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 21);
            this.btn_calc.TabIndex = 28;
            this.btn_calc.Text = "Calculate";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // lst_kpi
            // 
            this.lst_kpi.Enabled = false;
            this.lst_kpi.FormattingEnabled = true;
            this.lst_kpi.ItemHeight = 12;
            this.lst_kpi.Location = new System.Drawing.Point(362, 60);
            this.lst_kpi.Name = "lst_kpi";
            this.lst_kpi.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_kpi.Size = new System.Drawing.Size(233, 112);
            this.lst_kpi.TabIndex = 29;
            // 
            // cmb_kpi
            // 
            this.cmb_kpi.FormattingEnabled = true;
            this.cmb_kpi.Location = new System.Drawing.Point(362, 36);
            this.cmb_kpi.Name = "cmb_kpi";
            this.cmb_kpi.Size = new System.Drawing.Size(96, 20);
            this.cmb_kpi.TabIndex = 30;
            this.cmb_kpi.SelectedIndexChanged += new System.EventHandler(this.cmb_kpi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "=";
            // 
            // cmb_isKPI
            // 
            this.cmb_isKPI.Location = new System.Drawing.Point(483, 37);
            this.cmb_isKPI.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cmb_isKPI.Name = "cmb_isKPI";
            this.cmb_isKPI.Size = new System.Drawing.Size(36, 21);
            this.cmb_isKPI.TabIndex = 32;
            this.cmb_isKPI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(535, 35);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 19);
            this.btn_add.TabIndex = 33;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Visible = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(535, 35);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(60, 19);
            this.btn_del.TabIndex = 34;
            this.btn_del.Text = "Del";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Visible = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // chkl_status
            // 
            this.chkl_status.Enabled = false;
            this.chkl_status.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkl_status.FormattingEnabled = true;
            this.chkl_status.Location = new System.Drawing.Point(212, 51);
            this.chkl_status.Name = "chkl_status";
            this.chkl_status.Size = new System.Drawing.Size(132, 112);
            this.chkl_status.TabIndex = 35;
            this.chkl_status.SelectedValueChanged += new System.EventHandler(this.chkl_status_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "Exclude";
            // 
            // btn_sync
            // 
            this.btn_sync.Location = new System.Drawing.Point(705, 6);
            this.btn_sync.Name = "btn_sync";
            this.btn_sync.Size = new System.Drawing.Size(75, 23);
            this.btn_sync.TabIndex = 37;
            this.btn_sync.Text = "Sync";
            this.btn_sync.UseVisualStyleBackColor = true;
            this.btn_sync.Click += new System.EventHandler(this.btn_sync_Click);
            // 
            // chk_limited
            // 
            this.chk_limited.AutoSize = true;
            this.chk_limited.Checked = true;
            this.chk_limited.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_limited.Location = new System.Drawing.Point(786, 10);
            this.chk_limited.Name = "chk_limited";
            this.chk_limited.Size = new System.Drawing.Size(54, 16);
            this.chk_limited.TabIndex = 38;
            this.chk_limited.Text = "Limit";
            this.chk_limited.UseVisualStyleBackColor = true;
            // 
            // PanelCalcSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chk_limited);
            this.Controls.Add(this.btn_sync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkl_status);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_isKPI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_kpi);
            this.Controls.Add(this.lst_kpi);
            this.Controls.Add(this.lbl_buy);
            this.Controls.Add(this.lst_buy);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.lst_sell);
            this.Controls.Add(this.lbl_sell);
            this.Name = "PanelCalcSetting";
            this.Size = new System.Drawing.Size(856, 186);
            this.Load += new System.EventHandler(this.PanelBuySell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_isKPI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_buy;
        private System.Windows.Forms.Label lbl_buy;
        private System.Windows.Forms.Label lbl_sell;
        private System.Windows.Forms.ListBox lst_sell;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.ListBox lst_kpi;
        private System.Windows.Forms.ComboBox cmb_kpi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cmb_isKPI;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.CheckedListBox chkl_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_sync;
        private System.Windows.Forms.CheckBox chk_limited;
    }
}
