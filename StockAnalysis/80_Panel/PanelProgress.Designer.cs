namespace StockAnalysis.Panel
{
    partial class PanelProgress
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
            this.label1 = new System.Windows.Forms.Label();
            this.prog = new System.Windows.Forms.ProgressBar();
            this.bg_worker = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_elapsetime = new System.Windows.Forms.TextBox();
            this.txt_lefttime = new System.Windows.Forms.TextBox();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Progress";
            // 
            // prog
            // 
            this.prog.Location = new System.Drawing.Point(12, 29);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(503, 23);
            this.prog.Step = 1;
            this.prog.TabIndex = 1;
            // 
            // bg_worker
            // 
            this.bg_worker.WorkerReportsProgress = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elapsed Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Left Time";
            // 
            // txt_elapsetime
            // 
            this.txt_elapsetime.Location = new System.Drawing.Point(144, 73);
            this.txt_elapsetime.Name = "txt_elapsetime";
            this.txt_elapsetime.ReadOnly = true;
            this.txt_elapsetime.Size = new System.Drawing.Size(205, 20);
            this.txt_elapsetime.TabIndex = 4;
            // 
            // txt_lefttime
            // 
            this.txt_lefttime.Location = new System.Drawing.Point(144, 100);
            this.txt_lefttime.Name = "txt_lefttime";
            this.txt_lefttime.ReadOnly = true;
            this.txt_lefttime.Size = new System.Drawing.Size(205, 20);
            this.txt_lefttime.TabIndex = 5;
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_progress.Location = new System.Drawing.Point(164, 9);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(0, 17);
            this.lbl_progress.TabIndex = 6;
            // 
            // PanelProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 140);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.txt_lefttime);
            this.Controls.Add(this.txt_elapsetime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prog);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PanelProgress";
            this.ShowIcon = false;
            this.Text = "PanelStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prog;
        private System.ComponentModel.BackgroundWorker bg_worker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_elapsetime;
        private System.Windows.Forms.TextBox txt_lefttime;
        private System.Windows.Forms.Label lbl_progress;
    }
}