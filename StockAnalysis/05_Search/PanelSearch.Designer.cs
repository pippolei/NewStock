namespace StockAnalysis.Panel
{
    partial class PanelSearch
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
            this.dg_list = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl_buysell = new StockAnalysis.Panel.PanelCombineRule();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_goodscore = new System.Windows.Forms.CheckBox();
            this.chk_hidesold = new System.Windows.Forms.CheckBox();
            this.txt_fromdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_todate = new System.Windows.Forms.DateTimePicker();
            this.chk_ml = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_list)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_list
            // 
            this.dg_list.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.dg_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column9,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dg_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_list.Location = new System.Drawing.Point(0, 168);
            this.dg_list.Name = "dg_list";
            this.dg_list.Size = new System.Drawing.Size(1015, 432);
            this.dg_list.TabIndex = 0;
            this.dg_list.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "buyrule";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "sellrule";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Date";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Price";
            this.Column5.Name = "Column5";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "grade";
            this.Column9.Name = "Column9";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "selldate";
            this.Column8.Name = "Column8";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "sellprice";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Type";
            this.Column7.Name = "Column7";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dg_list);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 600);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnl_buysell);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1015, 168);
            this.panel3.TabIndex = 2;
            // 
            // pnl_buysell
            // 
            this.pnl_buysell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_buysell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_buysell.Location = new System.Drawing.Point(0, 0);
            this.pnl_buysell.Name = "pnl_buysell";
            this.pnl_buysell.Size = new System.Drawing.Size(1015, 135);
            this.pnl_buysell.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chk_ml);
            this.panel2.Controls.Add(this.chk_goodscore);
            this.panel2.Controls.Add(this.chk_hidesold);
            this.panel2.Controls.Add(this.txt_fromdate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lable1);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.txt_todate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 33);
            this.panel2.TabIndex = 1;
            // 
            // chk_goodscore
            // 
            this.chk_goodscore.AutoSize = true;
            this.chk_goodscore.Location = new System.Drawing.Point(742, 8);
            this.chk_goodscore.Name = "chk_goodscore";
            this.chk_goodscore.Size = new System.Drawing.Size(78, 16);
            this.chk_goodscore.TabIndex = 6;
            this.chk_goodscore.Text = "Goodscore";
            this.chk_goodscore.UseVisualStyleBackColor = true;
            // 
            // chk_hidesold
            // 
            this.chk_hidesold.AutoSize = true;
            this.chk_hidesold.Checked = true;
            this.chk_hidesold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_hidesold.Location = new System.Drawing.Point(603, 7);
            this.chk_hidesold.Name = "chk_hidesold";
            this.chk_hidesold.Size = new System.Drawing.Size(120, 16);
            this.chk_hidesold.TabIndex = 5;
            this.chk_hidesold.Text = "Hide Sold Record";
            this.chk_hidesold.UseVisualStyleBackColor = true;
            // 
            // txt_fromdate
            // 
            this.txt_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_fromdate.Location = new System.Drawing.Point(44, 8);
            this.txt_fromdate.Name = "txt_fromdate";
            this.txt_fromdate.Size = new System.Drawing.Size(138, 21);
            this.txt_fromdate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(3, 9);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(29, 12);
            this.lable1.TabIndex = 3;
            this.lable1.Text = "From";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(368, 6);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 21);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_todate
            // 
            this.txt_todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_todate.Location = new System.Drawing.Point(214, 8);
            this.txt_todate.Name = "txt_todate";
            this.txt_todate.Size = new System.Drawing.Size(148, 21);
            this.txt_todate.TabIndex = 2;
            // 
            // chk_ml
            // 
            this.chk_ml.AutoSize = true;
            this.chk_ml.Checked = true;
            this.chk_ml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ml.Location = new System.Drawing.Point(477, 11);
            this.chk_ml.Name = "chk_ml";
            this.chk_ml.Size = new System.Drawing.Size(66, 16);
            this.chk_ml.TabIndex = 7;
            this.chk_ml.Text = "ML Data";
            this.chk_ml.UseVisualStyleBackColor = true;
            // 
            // PanelSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PanelSearch";
            this.Size = new System.Drawing.Size(1015, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dg_list)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_list;
        private System.Windows.Forms.Panel panel1;
        private PanelCombineRule pnl_buysell;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker txt_todate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker txt_fromdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.CheckBox chk_hidesold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.CheckBox chk_goodscore;
        private System.Windows.Forms.CheckBox chk_ml;

    }
}
