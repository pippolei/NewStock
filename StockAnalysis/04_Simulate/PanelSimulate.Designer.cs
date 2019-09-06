namespace StockAnalysis.Panel
{
    partial class PanelSimulate
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
            this.components = new System.ComponentModel.Container();
            this.dg_detail = new System.Windows.Forms.DataGridView();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_main_toptop = new System.Windows.Forms.Panel();
            this.btn_batch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_allresult = new System.Windows.Forms.Button();
            this.num_interval = new System.Windows.Forms.NumericUpDown();
            this.btn_simulate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_todate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_fromdate = new System.Windows.Forms.DateTimePicker();
            this.pnl_main_top = new System.Windows.Forms.Panel();
            this.pnl_buysell2 = new StockAnalysis.Panel.PanelCombineRule();
            this.pnl_main_top_bottom = new System.Windows.Forms.Panel();
            this.lbl_growth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_num = new System.Windows.Forms.NumericUpDown();
            this.pnl_main_bg = new System.Windows.Forms.Panel();
            this.pnl_main_bg_bottom = new System.Windows.Forms.Panel();
            this.pnl_main_bg_top = new System.Windows.Forms.Panel();
            this.btn_exportdetail = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_main_bottom = new System.Windows.Forms.Panel();
            this.dg_overview = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSimulatRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dg_batch = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dapan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).BeginInit();
            this.pnl_main_toptop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_interval)).BeginInit();
            this.pnl_main_top.SuspendLayout();
            this.pnl_main_top_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num)).BeginInit();
            this.pnl_main_bg.SuspendLayout();
            this.pnl_main_bg_bottom.SuspendLayout();
            this.pnl_main_bg_top.SuspendLayout();
            this.pnl_main_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_overview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_batch)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_detail
            // 
            this.dg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column21,
            this.Column1,
            this.Column3,
            this.Column7,
            this.Column19,
            this.Column4,
            this.Volume,
            this.Column20,
            this.Column5,
            this.Column26,
            this.Column27,
            this.Column6,
            this.Column22,
            this.Column18,
            this.Column2,
            this.Column9,
            this.Column10});
            this.dg_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_detail.Location = new System.Drawing.Point(0, 0);
            this.dg_detail.Name = "dg_detail";
            this.dg_detail.RowTemplate.Height = 23;
            this.dg_detail.Size = new System.Drawing.Size(877, 224);
            this.dg_detail.TabIndex = 0;
            this.dg_detail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_detail_MouseClick_1);
            // 
            // Column21
            // 
            this.Column21.HeaderText = "Type";
            this.Column21.Name = "Column21";
            this.Column21.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Buyrule";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sellrule";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "stockcode";
            this.Column7.Name = "Column7";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "buydate";
            this.Column19.Name = "Column19";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "buyindex";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "buyprice";
            this.Volume.Name = "Volume";
            // 
            // Column20
            // 
            this.Column20.HeaderText = "selldate";
            this.Column20.Name = "Column20";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "sellprice";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "sellprice";
            this.Column26.Name = "Column26";
            // 
            // Column27
            // 
            this.Column27.HeaderText = "buyvolume";
            this.Column27.Name = "Column27";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "stockvalue";
            this.Column6.Name = "Column6";
            // 
            // Column22
            // 
            this.Column22.HeaderText = "winvalue";
            this.Column22.Name = "Column22";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "holdstocknum";
            this.Column18.Name = "Column18";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "totalstockvalue";
            this.Column2.Name = "Column2";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "leftmoney";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "totalamount";
            this.Column10.Name = "Column10";
            // 
            // pnl_main_toptop
            // 
            this.pnl_main_toptop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_main_toptop.Controls.Add(this.btn_batch);
            this.pnl_main_toptop.Controls.Add(this.label4);
            this.pnl_main_toptop.Controls.Add(this.btn_allresult);
            this.pnl_main_toptop.Controls.Add(this.num_interval);
            this.pnl_main_toptop.Controls.Add(this.btn_simulate);
            this.pnl_main_toptop.Controls.Add(this.label2);
            this.pnl_main_toptop.Controls.Add(this.txt_todate);
            this.pnl_main_toptop.Controls.Add(this.label1);
            this.pnl_main_toptop.Controls.Add(this.txt_fromdate);
            this.pnl_main_toptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_main_toptop.Location = new System.Drawing.Point(0, 0);
            this.pnl_main_toptop.Name = "pnl_main_toptop";
            this.pnl_main_toptop.Size = new System.Drawing.Size(877, 34);
            this.pnl_main_toptop.TabIndex = 1;
            // 
            // btn_batch
            // 
            this.btn_batch.Location = new System.Drawing.Point(429, 7);
            this.btn_batch.Name = "btn_batch";
            this.btn_batch.Size = new System.Drawing.Size(75, 23);
            this.btn_batch.TabIndex = 15;
            this.btn_batch.Text = "Batch";
            this.btn_batch.UseVisualStyleBackColor = true;
            this.btn_batch.Click += new System.EventHandler(this.btn_batch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(669, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Interval";
            this.label4.Visible = false;
            // 
            // btn_allresult
            // 
            this.btn_allresult.Location = new System.Drawing.Point(522, 6);
            this.btn_allresult.Name = "btn_allresult";
            this.btn_allresult.Size = new System.Drawing.Size(85, 21);
            this.btn_allresult.TabIndex = 14;
            this.btn_allresult.Text = "GetAllResult";
            this.btn_allresult.UseVisualStyleBackColor = true;
            this.btn_allresult.Click += new System.EventHandler(this.btn_allresult_Click);
            // 
            // num_interval
            // 
            this.num_interval.Increment = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.num_interval.Location = new System.Drawing.Point(727, 7);
            this.num_interval.Name = "num_interval";
            this.num_interval.Size = new System.Drawing.Size(64, 21);
            this.num_interval.TabIndex = 13;
            this.num_interval.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.num_interval.Visible = false;
            this.num_interval.ValueChanged += new System.EventHandler(this.num_interval_ValueChanged);
            // 
            // btn_simulate
            // 
            this.btn_simulate.Location = new System.Drawing.Point(338, 7);
            this.btn_simulate.Name = "btn_simulate";
            this.btn_simulate.Size = new System.Drawing.Size(75, 23);
            this.btn_simulate.TabIndex = 10;
            this.btn_simulate.Text = "Simulate";
            this.btn_simulate.UseVisualStyleBackColor = true;
            this.btn_simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // txt_todate
            // 
            this.txt_todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_todate.Location = new System.Drawing.Point(205, 7);
            this.txt_todate.Name = "txt_todate";
            this.txt_todate.Size = new System.Drawing.Size(110, 21);
            this.txt_todate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // txt_fromdate
            // 
            this.txt_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_fromdate.Location = new System.Drawing.Point(53, 7);
            this.txt_fromdate.Name = "txt_fromdate";
            this.txt_fromdate.Size = new System.Drawing.Size(107, 21);
            this.txt_fromdate.TabIndex = 4;
            // 
            // pnl_main_top
            // 
            this.pnl_main_top.Controls.Add(this.pnl_buysell2);
            this.pnl_main_top.Controls.Add(this.pnl_main_toptop);
            this.pnl_main_top.Controls.Add(this.pnl_main_top_bottom);
            this.pnl_main_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_main_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_main_top.Name = "pnl_main_top";
            this.pnl_main_top.Size = new System.Drawing.Size(877, 214);
            this.pnl_main_top.TabIndex = 1;
            // 
            // pnl_buysell2
            // 
            this.pnl_buysell2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_buysell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_buysell2.Location = new System.Drawing.Point(0, 34);
            this.pnl_buysell2.Name = "pnl_buysell2";
            this.pnl_buysell2.Size = new System.Drawing.Size(877, 133);
            this.pnl_buysell2.TabIndex = 2;
            // 
            // pnl_main_top_bottom
            // 
            this.pnl_main_top_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_main_top_bottom.Controls.Add(this.lbl_growth);
            this.pnl_main_top_bottom.Controls.Add(this.label3);
            this.pnl_main_top_bottom.Controls.Add(this.txt_num);
            this.pnl_main_top_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_main_top_bottom.Location = new System.Drawing.Point(0, 167);
            this.pnl_main_top_bottom.Name = "pnl_main_top_bottom";
            this.pnl_main_top_bottom.Size = new System.Drawing.Size(877, 47);
            this.pnl_main_top_bottom.TabIndex = 3;
            // 
            // lbl_growth
            // 
            this.lbl_growth.AutoSize = true;
            this.lbl_growth.Location = new System.Drawing.Point(336, 18);
            this.lbl_growth.Name = "lbl_growth";
            this.lbl_growth.Size = new System.Drawing.Size(0, 12);
            this.lbl_growth.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stocks one time";
            // 
            // txt_num
            // 
            this.txt_num.Location = new System.Drawing.Point(16, 15);
            this.txt_num.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txt_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(36, 21);
            this.txt_num.TabIndex = 4;
            this.txt_num.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // pnl_main_bg
            // 
            this.pnl_main_bg.Controls.Add(this.pnl_main_bg_bottom);
            this.pnl_main_bg.Controls.Add(this.pnl_main_bg_top);
            this.pnl_main_bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main_bg.Location = new System.Drawing.Point(0, 214);
            this.pnl_main_bg.Name = "pnl_main_bg";
            this.pnl_main_bg.Size = new System.Drawing.Size(877, 256);
            this.pnl_main_bg.TabIndex = 4;
            this.pnl_main_bg.Visible = false;
            // 
            // pnl_main_bg_bottom
            // 
            this.pnl_main_bg_bottom.Controls.Add(this.dg_detail);
            this.pnl_main_bg_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main_bg_bottom.Location = new System.Drawing.Point(0, 32);
            this.pnl_main_bg_bottom.Name = "pnl_main_bg_bottom";
            this.pnl_main_bg_bottom.Size = new System.Drawing.Size(877, 224);
            this.pnl_main_bg_bottom.TabIndex = 5;
            // 
            // pnl_main_bg_top
            // 
            this.pnl_main_bg_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_main_bg_top.Controls.Add(this.btn_exportdetail);
            this.pnl_main_bg_top.Controls.Add(this.label6);
            this.pnl_main_bg_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_main_bg_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_main_bg_top.Name = "pnl_main_bg_top";
            this.pnl_main_bg_top.Size = new System.Drawing.Size(877, 32);
            this.pnl_main_bg_top.TabIndex = 4;
            // 
            // btn_exportdetail
            // 
            this.btn_exportdetail.Location = new System.Drawing.Point(120, 5);
            this.btn_exportdetail.Name = "btn_exportdetail";
            this.btn_exportdetail.Size = new System.Drawing.Size(75, 21);
            this.btn_exportdetail.TabIndex = 1;
            this.btn_exportdetail.Text = "Export";
            this.btn_exportdetail.UseVisualStyleBackColor = true;
            this.btn_exportdetail.Click += new System.EventHandler(this.btn_exportdetail_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Simulate Log";
            // 
            // pnl_main_bottom
            // 
            this.pnl_main_bottom.Controls.Add(this.dg_overview);
            this.pnl_main_bottom.Controls.Add(this.dg_batch);
            this.pnl_main_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main_bottom.Location = new System.Drawing.Point(0, 214);
            this.pnl_main_bottom.Name = "pnl_main_bottom";
            this.pnl_main_bottom.Size = new System.Drawing.Size(877, 256);
            this.pnl_main_bottom.TabIndex = 3;
            // 
            // dg_overview
            // 
            this.dg_overview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_overview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.Column8,
            this.Column12,
            this.Column23,
            this.Column24,
            this.Column11,
            this.Dapan});
            this.dg_overview.ContextMenuStrip = this.contextMenuStrip1;
            this.dg_overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_overview.Location = new System.Drawing.Point(0, 0);
            this.dg_overview.Name = "dg_overview";
            this.dg_overview.RowTemplate.Height = 23;
            this.dg_overview.Size = new System.Drawing.Size(877, 256);
            this.dg_overview.TabIndex = 2;
            this.dg_overview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dg_overview_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSimulatRecordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 26);
            // 
            // deleteSimulatRecordToolStripMenuItem
            // 
            this.deleteSimulatRecordToolStripMenuItem.Name = "deleteSimulatRecordToolStripMenuItem";
            this.deleteSimulatRecordToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteSimulatRecordToolStripMenuItem.Text = "Delete Simulat Record";
            this.deleteSimulatRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteSimulatRecordToolStripMenuItem_Click);
            // 
            // dg_batch
            // 
            this.dg_batch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_batch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column13,
            this.Column14,
            this.Column17});
            this.dg_batch.Location = new System.Drawing.Point(552, 97);
            this.dg_batch.Name = "dg_batch";
            this.dg_batch.RowTemplate.Height = 23;
            this.dg_batch.Size = new System.Drawing.Size(240, 138);
            this.dg_batch.TabIndex = 3;
            this.dg_batch.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "buyrule";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "sellrule";
            this.Column16.Name = "Column16";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "startdate";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "enddate";
            this.Column14.Name = "Column14";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "amount";
            this.Column17.Name = "Column17";
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "BuyRule";
            this.Column8.Name = "Column8";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "SellRule";
            this.Column12.Name = "Column12";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "startdate";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.HeaderText = "enddate";
            this.Column24.Name = "Column24";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Amount";
            this.Column11.Name = "Column11";
            // 
            // Dapan
            // 
            this.Dapan.HeaderText = "DaPan";
            this.Dapan.Name = "Dapan";
            // 
            // PanelSimulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_main_bottom);
            this.Controls.Add(this.pnl_main_bg);
            this.Controls.Add(this.pnl_main_top);
            this.Name = "PanelSimulate";
            this.Size = new System.Drawing.Size(877, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).EndInit();
            this.pnl_main_toptop.ResumeLayout(false);
            this.pnl_main_toptop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_interval)).EndInit();
            this.pnl_main_top.ResumeLayout(false);
            this.pnl_main_top_bottom.ResumeLayout(false);
            this.pnl_main_top_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_num)).EndInit();
            this.pnl_main_bg.ResumeLayout(false);
            this.pnl_main_bg_bottom.ResumeLayout(false);
            this.pnl_main_bg_top.ResumeLayout(false);
            this.pnl_main_bg_top.PerformLayout();
            this.pnl_main_bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_overview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_batch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_detail;
        private System.Windows.Forms.Panel pnl_main_toptop;
        private System.Windows.Forms.Panel pnl_main_top;
        private PanelCombineRule pnl_buysell2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txt_todate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txt_fromdate;
        private System.Windows.Forms.Panel pnl_main_top_bottom;
        private System.Windows.Forms.DataGridView dg_overview;
        private System.Windows.Forms.Panel pnl_main_bottom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txt_num;
        private System.Windows.Forms.Panel pnl_main_bg;
        private System.Windows.Forms.Panel pnl_main_bg_top;
        private System.Windows.Forms.Button btn_exportdetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_main_bg_bottom;
        private System.Windows.Forms.Button btn_simulate;
        private System.Windows.Forms.Label lbl_growth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridView dg_batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.Button btn_allresult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteSimulatRecordToolStripMenuItem;
        private System.Windows.Forms.Button btn_batch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dapan;


    }
}
