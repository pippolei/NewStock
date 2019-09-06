using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace StockAnalysis.Panel
{
    public partial class PanelProgress : Form
    {
        private static readonly string TAG = "Worker";
        public delegate void ProHandler();
        public ProHandler doWork = null;
        public ProHandler compWork = null;
        private DateTime starttime;
        private DateTime curtime;
        private Boolean finished = false;
        public PanelProgress(string title, int maximum)
        {
            InitializeComponent();
            this.Text = title;
            bg_worker.DoWork +=
                new DoWorkEventHandler(DoWork);
            bg_worker.ProgressChanged +=
                new ProgressChangedEventHandler(ProgressChanged);
            bg_worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(RunWorkerCompleted);
        }
        public void Start()
        {
            starttime = System.DateTime.Now;
            finished = false;
            bg_worker.RunWorkerAsync();
        }
        public void SetProgress(int status)
        {
            curtime = System.DateTime.Now; 
            bg_worker.ReportProgress(status);
        }
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (finished)
            {
                MessageBox.Show(this,this.Text + " Done!");
                this.Visible = false;
                if (compWork != null)
                {
                    compWork();
                }
            }            
            this.Dispose();
        }
        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                doWork();
                finished = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                UtilLog.AddError(TAG, ex.ToString());
            }                                 
        }

        // This event handler updates the progress bar.
        private void ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            int value = e.ProgressPercentage;
            this.prog.Value = value;
            this.lbl_progress.Text = value.ToString() + "%";
            TimeSpan elap = curtime.Subtract(starttime);
            int hour = elap.Hours;
            int minute = elap.Minutes;
            minute = hour * 60 + minute;
            this.txt_elapsetime.Text = minute.ToString() + " Minutes";
            if (value > 0)
            {
                int left = minute * (100 - value) / value;
                this.txt_lefttime.Text = left.ToString() + " Minutes";
            }
        }
    }
}