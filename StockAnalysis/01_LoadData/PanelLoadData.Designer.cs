namespace StockAnalysis.Panel
{
    partial class PanelLoadData
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
            this.pnl_top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_database = new System.Windows.Forms.Label();
            this.btn_getlist = new System.Windows.Forms.Button();
            this.btn_syncData = new System.Windows.Forms.Button();
            this.btn_folder = new System.Windows.Forms.Button();
            this.lbl_stockfolder = new System.Windows.Forms.Label();
            this.txt_stockfolder = new System.Windows.Forms.TextBox();
            this.bg_worker = new System.ComponentModel.BackgroundWorker();
            this.pnl_list = new StockAnalysis.Panel.PanelStockList();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_top.Controls.Add(this.label1);
            this.pnl_top.Controls.Add(this.txt_date);
            this.pnl_top.Controls.Add(this.lbl_database);
            this.pnl_top.Controls.Add(this.btn_getlist);
            this.pnl_top.Controls.Add(this.btn_syncData);
            this.pnl_top.Controls.Add(this.btn_folder);
            this.pnl_top.Controls.Add(this.lbl_stockfolder);
            this.pnl_top.Controls.Add(this.txt_stockfolder);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(850, 47);
            this.pnl_top.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(593, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Start From";
            // 
            // txt_date
            // 
            this.txt_date.Enabled = false;
            this.txt_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_date.Location = new System.Drawing.Point(678, 18);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(168, 21);
            this.txt_date.TabIndex = 15;
            // 
            // lbl_database
            // 
            this.lbl_database.AutoSize = true;
            this.lbl_database.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_database.ForeColor = System.Drawing.Color.Blue;
            this.lbl_database.Location = new System.Drawing.Point(2, 19);
            this.lbl_database.Name = "lbl_database";
            this.lbl_database.Size = new System.Drawing.Size(101, 18);
            this.lbl_database.TabIndex = 14;
            this.lbl_database.Text = "StockAnalysis";
            // 
            // btn_getlist
            // 
            this.btn_getlist.Location = new System.Drawing.Point(512, 16);
            this.btn_getlist.Name = "btn_getlist";
            this.btn_getlist.Size = new System.Drawing.Size(75, 21);
            this.btn_getlist.TabIndex = 13;
            this.btn_getlist.Text = "GetList";
            this.btn_getlist.UseVisualStyleBackColor = true;
            this.btn_getlist.Click += new System.EventHandler(this.btn_getlist_Click);
            // 
            // btn_syncData
            // 
            this.btn_syncData.Location = new System.Drawing.Point(431, 17);
            this.btn_syncData.Name = "btn_syncData";
            this.btn_syncData.Size = new System.Drawing.Size(75, 21);
            this.btn_syncData.TabIndex = 12;
            this.btn_syncData.Text = "Sync Data";
            this.btn_syncData.UseVisualStyleBackColor = true;
            this.btn_syncData.Click += new System.EventHandler(this.btn_syncData_Click);
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(395, 18);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(30, 21);
            this.btn_folder.TabIndex = 10;
            this.btn_folder.Text = "...";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // lbl_stockfolder
            // 
            this.lbl_stockfolder.AutoSize = true;
            this.lbl_stockfolder.Location = new System.Drawing.Point(95, 22);
            this.lbl_stockfolder.Name = "lbl_stockfolder";
            this.lbl_stockfolder.Size = new System.Drawing.Size(77, 12);
            this.lbl_stockfolder.TabIndex = 8;
            this.lbl_stockfolder.Text = "Stock Folder";
            // 
            // txt_stockfolder
            // 
            this.txt_stockfolder.Location = new System.Drawing.Point(169, 18);
            this.txt_stockfolder.Name = "txt_stockfolder";
            this.txt_stockfolder.Size = new System.Drawing.Size(220, 21);
            this.txt_stockfolder.TabIndex = 9;
            this.txt_stockfolder.Text = "C:\\StockAnalysis\\test";
            // 
            // bg_worker
            // 
            this.bg_worker.WorkerReportsProgress = true;
            // 
            // pnl_list
            // 
            this.pnl_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_list.Location = new System.Drawing.Point(0, 47);
            this.pnl_list.Name = "pnl_list";
            this.pnl_list.Size = new System.Drawing.Size(850, 553);
            this.pnl_list.TabIndex = 3;
            // 
            // PanelLoadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_list);
            this.Controls.Add(this.pnl_top);
            this.Name = "PanelLoadData";
            this.Size = new System.Drawing.Size(850, 600);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.TextBox txt_stockfolder;
        private System.Windows.Forms.Label lbl_stockfolder;
        private System.Windows.Forms.Button btn_folder;
        private System.ComponentModel.BackgroundWorker bg_worker;
        private PanelStockList pnl_list;
        private System.Windows.Forms.Button btn_syncData;
        private System.Windows.Forms.Button btn_getlist;
        private System.Windows.Forms.Label lbl_database;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker txt_date;
    }
}
