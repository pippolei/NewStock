namespace StockAnalysis.Panel
{
    partial class PanelAnalysis2
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
            this.pnl_overview = new System.Windows.Forms.Panel();
            this.panel_result = new StockAnalysis.Panel.PanelCombineRuleList();
            this.pnl_buysell = new StockAnalysis.Panel.PanelCalcSetting();
            this.pnl_overview_date = new System.Windows.Forms.Panel();
            this.btn_result = new System.Windows.Forms.Button();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.txt_enddate = new System.Windows.Forms.DateTimePicker();
            this.txt_startdate = new System.Windows.Forms.DateTimePicker();
            this.lbl_endate = new System.Windows.Forms.Label();
            this.lbl_startdate = new System.Windows.Forms.Label();
            this.pnl_overview.SuspendLayout();
            this.pnl_overview_date.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_overview
            // 
            this.pnl_overview.Controls.Add(this.panel_result);
            this.pnl_overview.Controls.Add(this.pnl_buysell);
            this.pnl_overview.Controls.Add(this.pnl_overview_date);
            this.pnl_overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_overview.Location = new System.Drawing.Point(0, 0);
            this.pnl_overview.Name = "pnl_overview";
            this.pnl_overview.Size = new System.Drawing.Size(900, 419);
            this.pnl_overview.TabIndex = 3;
            // 
            // panel_result
            // 
            this.panel_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_result.Location = new System.Drawing.Point(0, 60);
            this.panel_result.Name = "panel_result";
            this.panel_result.Size = new System.Drawing.Size(900, 184);
            this.panel_result.TabIndex = 2;
            // 
            // pnl_buysell
            // 
            this.pnl_buysell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_buysell.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_buysell.Location = new System.Drawing.Point(0, 244);
            this.pnl_buysell.Name = "pnl_buysell";
            this.pnl_buysell.Size = new System.Drawing.Size(900, 175);
            this.pnl_buysell.TabIndex = 0;
            // 
            // pnl_overview_date
            // 
            this.pnl_overview_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_overview_date.Controls.Add(this.btn_result);
            this.pnl_overview_date.Controls.Add(this.btn_analyze);
            this.pnl_overview_date.Controls.Add(this.txt_enddate);
            this.pnl_overview_date.Controls.Add(this.txt_startdate);
            this.pnl_overview_date.Controls.Add(this.lbl_endate);
            this.pnl_overview_date.Controls.Add(this.lbl_startdate);
            this.pnl_overview_date.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_overview_date.Location = new System.Drawing.Point(0, 0);
            this.pnl_overview_date.Name = "pnl_overview_date";
            this.pnl_overview_date.Size = new System.Drawing.Size(900, 60);
            this.pnl_overview_date.TabIndex = 1;
            // 
            // btn_result
            // 
            this.btn_result.Location = new System.Drawing.Point(634, 21);
            this.btn_result.Name = "btn_result";
            this.btn_result.Size = new System.Drawing.Size(75, 21);
            this.btn_result.TabIndex = 11;
            this.btn_result.Text = "Get Result";
            this.btn_result.UseVisualStyleBackColor = true;
            this.btn_result.Click += new System.EventHandler(this.btn_result_Click);
            // 
            // btn_analyze
            // 
            this.btn_analyze.Location = new System.Drawing.Point(16, 21);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(75, 21);
            this.btn_analyze.TabIndex = 10;
            this.btn_analyze.Text = "Analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // txt_enddate
            // 
            this.txt_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_enddate.Location = new System.Drawing.Point(438, 21);
            this.txt_enddate.Name = "txt_enddate";
            this.txt_enddate.Size = new System.Drawing.Size(190, 21);
            this.txt_enddate.TabIndex = 4;
            this.txt_enddate.ValueChanged += new System.EventHandler(this.txt_enddate_ValueChanged);
            // 
            // txt_startdate
            // 
            this.txt_startdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_startdate.Location = new System.Drawing.Point(168, 21);
            this.txt_startdate.Name = "txt_startdate";
            this.txt_startdate.Size = new System.Drawing.Size(190, 21);
            this.txt_startdate.TabIndex = 3;
            this.txt_startdate.ValueChanged += new System.EventHandler(this.txt_startdate_ValueChanged);
            // 
            // lbl_endate
            // 
            this.lbl_endate.AutoSize = true;
            this.lbl_endate.Location = new System.Drawing.Point(380, 26);
            this.lbl_endate.Name = "lbl_endate";
            this.lbl_endate.Size = new System.Drawing.Size(53, 12);
            this.lbl_endate.TabIndex = 2;
            this.lbl_endate.Text = "End Date";
            // 
            // lbl_startdate
            // 
            this.lbl_startdate.AutoSize = true;
            this.lbl_startdate.Location = new System.Drawing.Point(107, 21);
            this.lbl_startdate.Name = "lbl_startdate";
            this.lbl_startdate.Size = new System.Drawing.Size(65, 12);
            this.lbl_startdate.TabIndex = 1;
            this.lbl_startdate.Text = "Start Date";
            // 
            // PanelAnalysis2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_overview);
            this.Name = "PanelAnalysis2";
            this.Size = new System.Drawing.Size(900, 419);
            this.pnl_overview.ResumeLayout(false);
            this.pnl_overview_date.ResumeLayout(false);
            this.pnl_overview_date.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_overview;
        private PanelCalcSetting pnl_buysell;
        private System.Windows.Forms.Panel pnl_overview_date;
        private System.Windows.Forms.DateTimePicker txt_enddate;
        private System.Windows.Forms.DateTimePicker txt_startdate;
        private System.Windows.Forms.Label lbl_endate;
        private System.Windows.Forms.Label lbl_startdate;
        private PanelCombineRuleList panel_result;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Button btn_result;




    }
}
