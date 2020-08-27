
namespace StockAnalysis.Panel
{
    partial class MainApp
    {
        private System.Windows.Forms.MenuStrip manMenu;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateToolStripMenuItem;
        private System.Windows.Forms.TabPage tab_simulate;
        private PanelSimulate pnl_simulate;
        private System.Windows.Forms.TabPage tab_search;
        private PanelSearch pnl_search;
        private System.Windows.Forms.TabPage tab_database;
        private PanelLoadData pnl_database;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.manMenu = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSimulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tab_database = new System.Windows.Forms.TabPage();
            this.tab_calcrule = new System.Windows.Forms.TabPage();
            this.tab_combAnalysis = new System.Windows.Forms.TabPage();
            this.tab_simulate = new System.Windows.Forms.TabPage();
            this.tab_search = new System.Windows.Forms.TabPage();
            this.tab_util = new System.Windows.Forms.TabPage();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_database = new StockAnalysis.Panel.PanelLoadData();
            this.panelCalculate1 = new StockAnalysis.Panel.PanelRule();
            this.panelAnalysis21 = new StockAnalysis.Panel.PanelAnalysis2();
            this.pnl_simulate = new StockAnalysis.Panel.PanelSimulate();
            this.pnl_search = new StockAnalysis.Panel.PanelSearch();
            this.panelUtil1 = new StockAnalysis.PanelUtil();
            this.manMenu.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tab_database.SuspendLayout();
            this.tab_calcrule.SuspendLayout();
            this.tab_combAnalysis.SuspendLayout();
            this.tab_simulate.SuspendLayout();
            this.tab_search.SuspendLayout();
            this.tab_util.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // manMenu
            // 
            this.manMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.operationToolStripMenuItem});
            this.manMenu.Location = new System.Drawing.Point(0, 0);
            this.manMenu.Name = "manMenu";
            this.manMenu.Size = new System.Drawing.Size(892, 25);
            this.manMenu.TabIndex = 1;
            this.manMenu.Text = "manMenu";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDatabaseToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // setDatabaseToolStripMenuItem
            // 
            this.setDatabaseToolStripMenuItem.Name = "setDatabaseToolStripMenuItem";
            this.setDatabaseToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.setDatabaseToolStripMenuItem.Text = "SetDatabase";
            this.setDatabaseToolStripMenuItem.Click += new System.EventHandler(this.setDatabaseToolStripMenuItem_Click);
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetRuleToolStripMenuItem,
            this.resetSimulateToolStripMenuItem,
            this.truncateToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.operationToolStripMenuItem.Text = "Clear";
            // 
            // resetRuleToolStripMenuItem
            // 
            this.resetRuleToolStripMenuItem.Name = "resetRuleToolStripMenuItem";
            this.resetRuleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetRuleToolStripMenuItem.Text = "Reset Rule Filter";
            this.resetRuleToolStripMenuItem.Click += new System.EventHandler(this.resetRuleToolStripMenuItem_Click);
            // 
            // resetSimulateToolStripMenuItem
            // 
            this.resetSimulateToolStripMenuItem.Name = "resetSimulateToolStripMenuItem";
            this.resetSimulateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetSimulateToolStripMenuItem.Text = "Reset Simulate";
            this.resetSimulateToolStripMenuItem.Click += new System.EventHandler(this.resetSimulateToolStripMenuItem_Click);
            // 
            // truncateToolStripMenuItem
            // 
            this.truncateToolStripMenuItem.Name = "truncateToolStripMenuItem";
            this.truncateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.truncateToolStripMenuItem.Text = "Truncate All";
            this.truncateToolStripMenuItem.Click += new System.EventHandler(this.truncateToolStripMenuItem_Click);
            this.truncateToolStripMenuItem.VisibleChanged += new System.EventHandler(this.truncateToolStripMenuItem_VisibleChanged);
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.tab_database);
            this.tab_main.Controls.Add(this.tab_calcrule);
            this.tab_main.Controls.Add(this.tab_combAnalysis);
            this.tab_main.Controls.Add(this.tab_simulate);
            this.tab_main.Controls.Add(this.tab_search);
            this.tab_main.Controls.Add(this.tab_util);
            this.tab_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_main.Location = new System.Drawing.Point(0, 25);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(892, 559);
            this.tab_main.TabIndex = 0;
            this.tab_main.SelectedIndexChanged += new System.EventHandler(this.tab_main_SelectedIndexChanged);
            // 
            // tab_database
            // 
            this.tab_database.Controls.Add(this.pnl_database);
            this.tab_database.Location = new System.Drawing.Point(4, 22);
            this.tab_database.Name = "tab_database";
            this.tab_database.Padding = new System.Windows.Forms.Padding(3);
            this.tab_database.Size = new System.Drawing.Size(884, 533);
            this.tab_database.TabIndex = 0;
            this.tab_database.Text = "LoadData";
            this.tab_database.UseVisualStyleBackColor = true;
            // 
            // tab_calcrule
            // 
            this.tab_calcrule.Controls.Add(this.panelCalculate1);
            this.tab_calcrule.Location = new System.Drawing.Point(4, 22);
            this.tab_calcrule.Name = "tab_calcrule";
            this.tab_calcrule.Size = new System.Drawing.Size(884, 533);
            this.tab_calcrule.TabIndex = 10;
            this.tab_calcrule.Text = "CalcRule";
            this.tab_calcrule.UseVisualStyleBackColor = true;
            // 
            // tab_combAnalysis
            // 
            this.tab_combAnalysis.Controls.Add(this.panelAnalysis21);
            this.tab_combAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tab_combAnalysis.Name = "tab_combAnalysis";
            this.tab_combAnalysis.Size = new System.Drawing.Size(884, 533);
            this.tab_combAnalysis.TabIndex = 9;
            this.tab_combAnalysis.Text = "Comb Analysis";
            this.tab_combAnalysis.UseVisualStyleBackColor = true;
            // 
            // tab_simulate
            // 
            this.tab_simulate.Controls.Add(this.pnl_simulate);
            this.tab_simulate.Location = new System.Drawing.Point(4, 22);
            this.tab_simulate.Name = "tab_simulate";
            this.tab_simulate.Size = new System.Drawing.Size(884, 533);
            this.tab_simulate.TabIndex = 5;
            this.tab_simulate.Text = "Simulate";
            this.tab_simulate.UseVisualStyleBackColor = true;
            // 
            // tab_search
            // 
            this.tab_search.Controls.Add(this.pnl_search);
            this.tab_search.Location = new System.Drawing.Point(4, 22);
            this.tab_search.Name = "tab_search";
            this.tab_search.Size = new System.Drawing.Size(884, 533);
            this.tab_search.TabIndex = 3;
            this.tab_search.Text = "Search";
            this.tab_search.UseVisualStyleBackColor = true;
            // 
            // tab_util
            // 
            this.tab_util.Controls.Add(this.panelUtil1);
            this.tab_util.Location = new System.Drawing.Point(4, 22);
            this.tab_util.Name = "tab_util";
            this.tab_util.Size = new System.Drawing.Size(884, 533);
            this.tab_util.TabIndex = 11;
            this.tab_util.Text = "Utility";
            this.tab_util.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "StockAnalysis";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnl_database
            // 
            this.pnl_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_database.Location = new System.Drawing.Point(3, 3);
            this.pnl_database.Name = "pnl_database";
            this.pnl_database.Size = new System.Drawing.Size(878, 527);
            this.pnl_database.TabIndex = 0;
            // 
            // panelCalculate1
            // 
            this.panelCalculate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalculate1.Location = new System.Drawing.Point(0, 0);
            this.panelCalculate1.Name = "panelCalculate1";
            this.panelCalculate1.Size = new System.Drawing.Size(884, 533);
            this.panelCalculate1.TabIndex = 0;
            // 
            // panelAnalysis21
            // 
            this.panelAnalysis21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalysis21.Location = new System.Drawing.Point(0, 0);
            this.panelAnalysis21.Name = "panelAnalysis21";
            this.panelAnalysis21.Size = new System.Drawing.Size(884, 533);
            this.panelAnalysis21.TabIndex = 0;
            // 
            // pnl_simulate
            // 
            this.pnl_simulate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_simulate.Location = new System.Drawing.Point(0, 0);
            this.pnl_simulate.Name = "pnl_simulate";
            this.pnl_simulate.Size = new System.Drawing.Size(884, 533);
            this.pnl_simulate.TabIndex = 0;
            // 
            // pnl_search
            // 
            this.pnl_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_search.Location = new System.Drawing.Point(0, 0);
            this.pnl_search.Name = "pnl_search";
            this.pnl_search.Size = new System.Drawing.Size(884, 533);
            this.pnl_search.TabIndex = 0;
            // 
            // panelUtil1
            // 
            this.panelUtil1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUtil1.Location = new System.Drawing.Point(0, 0);
            this.panelUtil1.Name = "panelUtil1";
            this.panelUtil1.Size = new System.Drawing.Size(884, 533);
            this.panelUtil1.TabIndex = 0;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 584);
            this.Controls.Add(this.tab_main);
            this.Controls.Add(this.manMenu);
            this.Name = "MainApp";
            this.Text = "Analysis";
            this.Resize += new System.EventHandler(this.MainApp_Resize);
            this.manMenu.ResumeLayout(false);
            this.manMenu.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.tab_database.ResumeLayout(false);
            this.tab_calcrule.ResumeLayout(false);
            this.tab_combAnalysis.ResumeLayout(false);
            this.tab_simulate.ResumeLayout(false);
            this.tab_search.ResumeLayout(false);
            this.tab_util.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem setDatabaseToolStripMenuItem;
        private System.Windows.Forms.TabPage tab_combAnalysis;
        private PanelAnalysis2 panelAnalysis21;
        private System.Windows.Forms.TabPage tab_calcrule;
        private PanelRule panelCalculate1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSimulateToolStripMenuItem;
        private System.Windows.Forms.TabPage tab_util;
        private PanelUtil panelUtil1;

        
    }
}

