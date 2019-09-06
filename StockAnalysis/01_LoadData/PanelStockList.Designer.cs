namespace StockAnalysis.Panel
{
    partial class PanelStockList
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
            this.col_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_detail = new System.Windows.Forms.DataGridView();
            this.pnl_detail = new System.Windows.Forms.Panel();
            this.btn_export = new System.Windows.Forms.Button();
            this.lbl_code = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_title2 = new System.Windows.Forms.Label();
            this.lbl_title1 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_indexitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_high = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_low = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).BeginInit();
            this.pnl_detail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_list
            // 
            this.dg_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_code,
            this.col_name});
            this.dg_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_list.Location = new System.Drawing.Point(0, 0);
            this.dg_list.Name = "dg_list";
            this.dg_list.ReadOnly = true;
            this.dg_list.Size = new System.Drawing.Size(650, 508);
            this.dg_list.TabIndex = 0;
            this.dg_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dg_list_MouseDoubleClick);
            // 
            // col_code
            // 
            this.col_code.HeaderText = "Code";
            this.col_code.Name = "col_code";
            this.col_code.ReadOnly = true;
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // dg_detail
            // 
            this.dg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.col_indexitem,
            this.col_date,
            this.col_start,
            this.col_high,
            this.col_low,
            this.col_end,
            this.Column1});
            this.dg_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_detail.Location = new System.Drawing.Point(0, 0);
            this.dg_detail.Name = "dg_detail";
            this.dg_detail.Size = new System.Drawing.Size(650, 508);
            this.dg_detail.TabIndex = 1;
            this.dg_detail.Visible = false;
            this.dg_detail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dg_detail_MouseClick);
            // 
            // pnl_detail
            // 
            this.pnl_detail.Controls.Add(this.btn_export);
            this.pnl_detail.Controls.Add(this.lbl_code);
            this.pnl_detail.Controls.Add(this.lbl_name);
            this.pnl_detail.Controls.Add(this.lbl_title2);
            this.pnl_detail.Controls.Add(this.lbl_title1);
            this.pnl_detail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_detail.Location = new System.Drawing.Point(0, 0);
            this.pnl_detail.Name = "pnl_detail";
            this.pnl_detail.Size = new System.Drawing.Size(650, 31);
            this.pnl_detail.TabIndex = 2;
            this.pnl_detail.Visible = false;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(572, 6);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 21);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_code.Location = new System.Drawing.Point(61, 10);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(0, 13);
            this.lbl_code.TabIndex = 3;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_name.Location = new System.Drawing.Point(197, 10);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 13);
            this.lbl_name.TabIndex = 2;
            // 
            // lbl_title2
            // 
            this.lbl_title2.AutoSize = true;
            this.lbl_title2.Location = new System.Drawing.Point(156, 10);
            this.lbl_title2.Name = "lbl_title2";
            this.lbl_title2.Size = new System.Drawing.Size(29, 12);
            this.lbl_title2.TabIndex = 1;
            this.lbl_title2.Text = "Name";
            // 
            // lbl_title1
            // 
            this.lbl_title1.AutoSize = true;
            this.lbl_title1.Location = new System.Drawing.Point(3, 10);
            this.lbl_title1.Name = "lbl_title1";
            this.lbl_title1.Size = new System.Drawing.Size(29, 12);
            this.lbl_title1.TabIndex = 0;
            this.lbl_title1.Text = "Code";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Code";
            this.Column2.Name = "Column2";
            // 
            // col_indexitem
            // 
            this.col_indexitem.HeaderText = "Index";
            this.col_indexitem.Name = "col_indexitem";
            // 
            // col_date
            // 
            this.col_date.HeaderText = "Date";
            this.col_date.Name = "col_date";
            // 
            // col_start
            // 
            this.col_start.HeaderText = "Start";
            this.col_start.Name = "col_start";
            // 
            // col_high
            // 
            this.col_high.HeaderText = "High";
            this.col_high.Name = "col_high";
            // 
            // col_low
            // 
            this.col_low.HeaderText = "Low";
            this.col_low.Name = "col_low";
            // 
            // col_end
            // 
            this.col_end.HeaderText = "End";
            this.col_end.Name = "col_end";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Volume";
            this.Column1.Name = "Column1";
            // 
            // PanelStockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_detail);
            this.Controls.Add(this.dg_detail);
            this.Controls.Add(this.dg_list);
            this.Name = "PanelStockList";
            this.Size = new System.Drawing.Size(650, 508);
            ((System.ComponentModel.ISupportInitialize)(this.dg_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).EndInit();
            this.pnl_detail.ResumeLayout(false);
            this.pnl_detail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_list;
        private System.Windows.Forms.DataGridView dg_detail;
        private System.Windows.Forms.Panel pnl_detail;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_title2;
        private System.Windows.Forms.Label lbl_title1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_indexitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_high;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_low;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
