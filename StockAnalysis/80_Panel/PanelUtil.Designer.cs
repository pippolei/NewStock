namespace StockAnalysis
{
    partial class PanelUtil
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_stockfull = new System.Windows.Forms.Button();
            this.btn_rulefull = new System.Windows.Forms.Button();
            this.btn_stockdata = new System.Windows.Forms.Button();
            this.btn_importrule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_stockfull
            // 
            this.btn_stockfull.Location = new System.Drawing.Point(248, 24);
            this.btn_stockfull.Name = "btn_stockfull";
            this.btn_stockfull.Size = new System.Drawing.Size(160, 23);
            this.btn_stockfull.TabIndex = 0;
            this.btn_stockfull.Text = "Export Stock Full";
            this.btn_stockfull.UseVisualStyleBackColor = true;
            this.btn_stockfull.Click += new System.EventHandler(this.btn_stockfull_Click);
            // 
            // btn_rulefull
            // 
            this.btn_rulefull.Location = new System.Drawing.Point(47, 65);
            this.btn_rulefull.Name = "btn_rulefull";
            this.btn_rulefull.Size = new System.Drawing.Size(160, 23);
            this.btn_rulefull.TabIndex = 1;
            this.btn_rulefull.Text = "Export Rule Full";
            this.btn_rulefull.UseVisualStyleBackColor = true;
            this.btn_rulefull.Click += new System.EventHandler(this.btn_rulefull_Click);
            // 
            // btn_stockdata
            // 
            this.btn_stockdata.Location = new System.Drawing.Point(47, 24);
            this.btn_stockdata.Name = "btn_stockdata";
            this.btn_stockdata.Size = new System.Drawing.Size(160, 23);
            this.btn_stockdata.TabIndex = 2;
            this.btn_stockdata.Text = "Export Stock Item";
            this.btn_stockdata.UseVisualStyleBackColor = true;
            this.btn_stockdata.Click += new System.EventHandler(this.btn_stockdata_Click);
            // 
            // btn_importrule
            // 
            this.btn_importrule.Location = new System.Drawing.Point(47, 123);
            this.btn_importrule.Name = "btn_importrule";
            this.btn_importrule.Size = new System.Drawing.Size(160, 23);
            this.btn_importrule.TabIndex = 3;
            this.btn_importrule.Text = "Import ML Rule";
            this.btn_importrule.UseVisualStyleBackColor = true;
            this.btn_importrule.Click += new System.EventHandler(this.btn_importrule_Click);
            // 
            // PanelUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_importrule);
            this.Controls.Add(this.btn_stockdata);
            this.Controls.Add(this.btn_rulefull);
            this.Controls.Add(this.btn_stockfull);
            this.Name = "PanelUtil";
            this.Size = new System.Drawing.Size(744, 269);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_stockfull;
        private System.Windows.Forms.Button btn_rulefull;
        private System.Windows.Forms.Button btn_stockdata;
        private System.Windows.Forms.Button btn_importrule;
    }
}