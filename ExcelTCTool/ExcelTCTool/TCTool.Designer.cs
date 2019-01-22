namespace ExcelTCTool
{
    partial class TCTool : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public TCTool()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grp1 = this.Factory.CreateRibbonGroup();
            this.btnSetTC = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.chkSRS = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grp1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grp1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grp1
            // 
            this.grp1.Items.Add(this.btnSetTC);
            this.grp1.Items.Add(this.button1);
            this.grp1.Items.Add(this.chkSRS);
            this.grp1.Label = "ZcyTool";
            this.grp1.Name = "grp1";
            // 
            // btnSetTC
            // 
            this.btnSetTC.Label = "SetTC";
            this.btnSetTC.Name = "btnSetTC";
            this.btnSetTC.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSetTC_Click);
            // 
            // button1
            // 
            this.button1.Label = "SetCellNum";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // chkSRS
            // 
            this.chkSRS.Label = "Check SRS Number";
            this.chkSRS.Name = "chkSRS";
            this.chkSRS.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkSRS_Click);
            // 
            // TCTool
            // 
            this.Name = "TCTool";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.TCTool_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grp1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSetTC;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton chkSRS;
    }

    partial class ThisRibbonCollection
    {
        internal TCTool TCTool
        {
            get { return this.GetRibbon<TCTool>(); }
        }
    }
}
