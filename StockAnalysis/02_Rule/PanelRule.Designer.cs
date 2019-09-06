namespace StockAnalysis.Panel
{
    partial class PanelRule
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
            this.panelRuleList1 = new StockAnalysis.Panel.PanelRuleList();
            this.panelCalcSetting1 = new StockAnalysis.Panel.PanelCalcSetting();
            this.SuspendLayout();
            // 
            // panelRuleList1
            // 
            this.panelRuleList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRuleList1.Location = new System.Drawing.Point(0, 181);
            this.panelRuleList1.Name = "panelRuleList1";
            this.panelRuleList1.Size = new System.Drawing.Size(1010, 238);
            this.panelRuleList1.TabIndex = 1;
            // 
            // panelCalcSetting1
            // 
            this.panelCalcSetting1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCalcSetting1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCalcSetting1.Location = new System.Drawing.Point(0, 0);
            this.panelCalcSetting1.Name = "panelCalcSetting1";
            this.panelCalcSetting1.Size = new System.Drawing.Size(1010, 181);
            this.panelCalcSetting1.TabIndex = 0;
            // 
            // PanelRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRuleList1);
            this.Controls.Add(this.panelCalcSetting1);
            this.Name = "PanelRule";
            this.Size = new System.Drawing.Size(1010, 419);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelCalcSetting panelCalcSetting1;
        private PanelRuleList panelRuleList1;





    }
}
