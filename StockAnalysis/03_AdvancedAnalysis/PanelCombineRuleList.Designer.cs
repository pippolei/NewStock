namespace StockAnalysis.Panel
{
    partial class PanelCombineRuleList
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
            this.dg_detail = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_overview = new System.Windows.Forms.DataGridView();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.cmb_scorefilter = new System.Windows.Forms.NumericUpDown();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_getresult = new System.Windows.Forms.Button();
            this.pnl_fill = new System.Windows.Forms.Panel();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_overview)).BeginInit();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_scorefilter)).BeginInit();
            this.pnl_fill.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_detail
            // 
            this.dg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.dataGridViewTextBoxColumn1,
            this.Column11,
            this.Column12,
            this.Column1});
            this.dg_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_detail.Location = new System.Drawing.Point(0, 0);
            this.dg_detail.Name = "dg_detail";
            this.dg_detail.RowTemplate.Height = 23;
            this.dg_detail.Size = new System.Drawing.Size(650, 468);
            this.dg_detail.TabIndex = 1;
            this.dg_detail.Visible = false;
            this.dg_detail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_detail_MouseClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "stockcode";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "buyrule";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "sellrule";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "buydate";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "buyprice";
            this.Column6.Name = "Column6";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "grade";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "selldate";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "sellprice";
            this.Column12.Name = "Column12";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "type";
            this.Column1.Name = "Column1";
            // 
            // dg_overview
            // 
            this.dg_overview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_overview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column7,
            this.Column8,
            this.Column13,
            this.Column10,
            this.Column14,
            this.Column15});
            this.dg_overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_overview.Location = new System.Drawing.Point(0, 0);
            this.dg_overview.Name = "dg_overview";
            this.dg_overview.RowTemplate.Height = 23;
            this.dg_overview.Size = new System.Drawing.Size(650, 468);
            this.dg_overview.TabIndex = 2;
            this.dg_overview.DoubleClick += new System.EventHandler(this.dg_overview_DoubleClick);
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.cmb_scorefilter);
            this.pnl_header.Controls.Add(this.btn_export);
            this.pnl_header.Controls.Add(this.btn_getresult);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(650, 40);
            this.pnl_header.TabIndex = 3;
            // 
            // cmb_scorefilter
            // 
            this.cmb_scorefilter.Location = new System.Drawing.Point(202, 15);
            this.cmb_scorefilter.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cmb_scorefilter.Name = "cmb_scorefilter";
            this.cmb_scorefilter.Size = new System.Drawing.Size(39, 21);
            this.cmb_scorefilter.TabIndex = 3;
            this.cmb_scorefilter.Value = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.cmb_scorefilter.Visible = false;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(541, 16);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 21);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Visible = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_getresult
            // 
            this.btn_getresult.Location = new System.Drawing.Point(21, 13);
            this.btn_getresult.Name = "btn_getresult";
            this.btn_getresult.Size = new System.Drawing.Size(75, 21);
            this.btn_getresult.TabIndex = 0;
            this.btn_getresult.Text = "Get Result";
            this.btn_getresult.UseVisualStyleBackColor = true;
            this.btn_getresult.Click += new System.EventHandler(this.btn_getresult_Click);
            // 
            // pnl_fill
            // 
            this.pnl_fill.Controls.Add(this.dg_overview);
            this.pnl_fill.Controls.Add(this.dg_detail);
            this.pnl_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_fill.Location = new System.Drawing.Point(0, 40);
            this.pnl_fill.Name = "pnl_fill";
            this.pnl_fill.Size = new System.Drawing.Size(650, 468);
            this.pnl_fill.TabIndex = 4;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "type";
            this.Column9.Name = "Column9";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "buyrule";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "sellrule";
            this.Column8.Name = "Column8";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "DftSell";
            this.Column13.Name = "Column13";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Count";
            this.Column10.Name = "Column10";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "nextWinRate";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "nextWinPercent";
            this.Column15.Name = "Column15";
            // 
            // PanelCombineRuleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_fill);
            this.Controls.Add(this.pnl_header);
            this.Name = "PanelCombineRuleList";
            this.Size = new System.Drawing.Size(650, 508);
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_overview)).EndInit();
            this.pnl_header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_scorefilter)).EndInit();
            this.pnl_fill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_detail;
        private System.Windows.Forms.DataGridView dg_overview;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_fill;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_getresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.NumericUpDown cmb_scorefilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
    }
}
