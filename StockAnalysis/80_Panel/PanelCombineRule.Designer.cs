namespace StockAnalysis.Panel
{
    partial class PanelCombineRule
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
            this.lst_buy2 = new System.Windows.Forms.ListBox();
            this.lbl_buy2 = new System.Windows.Forms.Label();
            this.lbl_sell2 = new System.Windows.Forms.Label();
            this.lst_sell2 = new System.Windows.Forms.ListBox();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_comb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_buy2
            // 
            this.lst_buy2.FormattingEnabled = true;
            this.lst_buy2.Location = new System.Drawing.Point(5, 24);
            this.lst_buy2.Name = "lst_buy2";
            this.lst_buy2.Size = new System.Drawing.Size(167, 147);
            this.lst_buy2.TabIndex = 22;
            // 
            // lbl_buy2
            // 
            this.lbl_buy2.AutoSize = true;
            this.lbl_buy2.Location = new System.Drawing.Point(3, 0);
            this.lbl_buy2.Name = "lbl_buy2";
            this.lbl_buy2.Size = new System.Drawing.Size(109, 13);
            this.lbl_buy2.TabIndex = 26;
            this.lbl_buy2.Text = "Compound Buy Rules";
            // 
            // lbl_sell2
            // 
            this.lbl_sell2.AutoSize = true;
            this.lbl_sell2.Location = new System.Drawing.Point(185, 0);
            this.lbl_sell2.Name = "lbl_sell2";
            this.lbl_sell2.Size = new System.Drawing.Size(108, 13);
            this.lbl_sell2.TabIndex = 27;
            this.lbl_sell2.Text = "Compound Sell Rules";
            // 
            // lst_sell2
            // 
            this.lst_sell2.FormattingEnabled = true;
            this.lst_sell2.Location = new System.Drawing.Point(178, 24);
            this.lst_sell2.Name = "lst_sell2";
            this.lst_sell2.Size = new System.Drawing.Size(187, 147);
            this.lst_sell2.TabIndex = 24;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(385, 102);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 25);
            this.btn_del.TabIndex = 28;
            this.btn_del.Text = "<<";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(385, 58);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 25);
            this.btn_add.TabIndex = 29;
            this.btn_add.Text = ">>";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Compound Rules";
            // 
            // lst_comb
            // 
            this.lst_comb.FormattingEnabled = true;
            this.lst_comb.Location = new System.Drawing.Point(477, 24);
            this.lst_comb.Name = "lst_comb";
            this.lst_comb.Size = new System.Drawing.Size(287, 147);
            this.lst_comb.TabIndex = 30;
            // 
            // PanelCombineRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_comb);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.lbl_buy2);
            this.Controls.Add(this.lst_buy2);
            this.Controls.Add(this.lbl_sell2);
            this.Controls.Add(this.lst_sell2);
            this.Name = "PanelCombineRule";
            this.Size = new System.Drawing.Size(792, 183);
            this.Load += new System.EventHandler(this.PanelCombineRule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_buy2;
        private System.Windows.Forms.Label lbl_buy2;
        private System.Windows.Forms.Label lbl_sell2;
        private System.Windows.Forms.ListBox lst_sell2;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_comb;
    }
}
