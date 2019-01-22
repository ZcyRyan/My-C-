namespace AutoClickForWindows
{
    partial class AutoMouseClickSettingDialog
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
            this.components = new System.ComponentModel.Container();
            this.dgvClickInfo = new System.Windows.Forms.DataGridView();
            this.actionNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numH = new System.Windows.Forms.NumericUpDown();
            this.numM = new System.Windows.Forms.NumericUpDown();
            this.numS = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.actionNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intervalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouseActionEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClickInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseActionEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClickInfo
            // 
            this.dgvClickInfo.AllowUserToAddRows = false;
            this.dgvClickInfo.AllowUserToDeleteRows = false;
            this.dgvClickInfo.AllowUserToResizeRows = false;
            this.dgvClickInfo.AutoGenerateColumns = false;
            this.dgvClickInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClickInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.actionNoDataGridViewTextBoxColumn1,
            this.displayTypeDataGridViewTextBoxColumn,
            this.xDataGridViewTextBoxColumn1,
            this.yDataGridViewTextBoxColumn1,
            this.intervalDataGridViewTextBoxColumn1,
            this.commentDataGridViewTextBoxColumn1,
            this.typeDataGridViewTextBoxColumn1});
            this.dgvClickInfo.DataSource = this.mouseActionEntityBindingSource;
            this.dgvClickInfo.Location = new System.Drawing.Point(31, 27);
            this.dgvClickInfo.MultiSelect = false;
            this.dgvClickInfo.Name = "dgvClickInfo";
            this.dgvClickInfo.ReadOnly = true;
            this.dgvClickInfo.RowHeadersVisible = false;
            this.dgvClickInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvClickInfo.RowTemplate.Height = 23;
            this.dgvClickInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClickInfo.Size = new System.Drawing.Size(604, 109);
            this.dgvClickInfo.TabIndex = 0;
            this.dgvClickInfo.DoubleClick += new System.EventHandler(this.dgvClickInfo_DoubleClick);
            // 
            // actionNoDataGridViewTextBoxColumn
            // 
            this.actionNoDataGridViewTextBoxColumn.DataPropertyName = "ActionNo";
            this.actionNoDataGridViewTextBoxColumn.HeaderText = "ActionNo";
            this.actionNoDataGridViewTextBoxColumn.Name = "actionNoDataGridViewTextBoxColumn";
            this.actionNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // intervalDataGridViewTextBoxColumn
            // 
            this.intervalDataGridViewTextBoxColumn.DataPropertyName = "Interval";
            this.intervalDataGridViewTextBoxColumn.HeaderText = "Interval";
            this.intervalDataGridViewTextBoxColumn.Name = "intervalDataGridViewTextBoxColumn";
            this.intervalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(28, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Press \'Alt+d\' to double click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(28, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Press \'Alt+r\' to right click";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(28, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Press \'Alt+l\' to left click";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(427, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(486, 154);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "Timer Interval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "&H";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "&M";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "&S";
            // 
            // numH
            // 
            this.numH.Location = new System.Drawing.Point(281, 187);
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(39, 21);
            this.numH.TabIndex = 14;
            // 
            // numM
            // 
            this.numM.Location = new System.Drawing.Point(326, 187);
            this.numM.Name = "numM";
            this.numM.Size = new System.Drawing.Size(39, 21);
            this.numM.TabIndex = 16;
            // 
            // numS
            // 
            this.numS.Location = new System.Drawing.Point(371, 187);
            this.numS.Name = "numS";
            this.numS.Size = new System.Drawing.Size(39, 21);
            this.numS.TabIndex = 17;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(427, 183);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 23);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "&Start Action";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(540, 154);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(40, 52);
            this.btnStop.TabIndex = 44;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(586, 154);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(55, 23);
            this.btnSaveSetting.TabIndex = 45;
            this.btnSaveSetting.Text = "S&ave";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(586, 183);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 23);
            this.btnLoad.TabIndex = 46;
            this.btnLoad.Text = "L&oad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // actionNoDataGridViewTextBoxColumn1
            // 
            this.actionNoDataGridViewTextBoxColumn1.DataPropertyName = "ActionNo";
            this.actionNoDataGridViewTextBoxColumn1.HeaderText = "ActionNo";
            this.actionNoDataGridViewTextBoxColumn1.Name = "actionNoDataGridViewTextBoxColumn1";
            this.actionNoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.actionNoDataGridViewTextBoxColumn1.Width = 60;
            // 
            // displayTypeDataGridViewTextBoxColumn
            // 
            this.displayTypeDataGridViewTextBoxColumn.DataPropertyName = "DisplayType";
            this.displayTypeDataGridViewTextBoxColumn.HeaderText = "Click Event";
            this.displayTypeDataGridViewTextBoxColumn.Name = "displayTypeDataGridViewTextBoxColumn";
            this.displayTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xDataGridViewTextBoxColumn1
            // 
            this.xDataGridViewTextBoxColumn1.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn1.HeaderText = "Pos X";
            this.xDataGridViewTextBoxColumn1.Name = "xDataGridViewTextBoxColumn1";
            this.xDataGridViewTextBoxColumn1.ReadOnly = true;
            this.xDataGridViewTextBoxColumn1.Width = 60;
            // 
            // yDataGridViewTextBoxColumn1
            // 
            this.yDataGridViewTextBoxColumn1.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn1.HeaderText = "Pos Y";
            this.yDataGridViewTextBoxColumn1.Name = "yDataGridViewTextBoxColumn1";
            this.yDataGridViewTextBoxColumn1.ReadOnly = true;
            this.yDataGridViewTextBoxColumn1.Width = 60;
            // 
            // intervalDataGridViewTextBoxColumn1
            // 
            this.intervalDataGridViewTextBoxColumn1.DataPropertyName = "Interval";
            this.intervalDataGridViewTextBoxColumn1.HeaderText = "Waiting(s)";
            this.intervalDataGridViewTextBoxColumn1.Name = "intervalDataGridViewTextBoxColumn1";
            this.intervalDataGridViewTextBoxColumn1.ReadOnly = true;
            this.intervalDataGridViewTextBoxColumn1.Width = 70;
            // 
            // commentDataGridViewTextBoxColumn1
            // 
            this.commentDataGridViewTextBoxColumn1.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn1.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn1.Name = "commentDataGridViewTextBoxColumn1";
            this.commentDataGridViewTextBoxColumn1.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn1.Width = 250;
            // 
            // typeDataGridViewTextBoxColumn1
            // 
            this.typeDataGridViewTextBoxColumn1.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn1.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn1.Name = "typeDataGridViewTextBoxColumn1";
            this.typeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn1.Visible = false;
            // 
            // mouseActionEntityBindingSource
            // 
            this.mouseActionEntityBindingSource.DataSource = typeof(AutoClickForWindows.MouseActionEntity);
            // 
            // AutoMouseClickSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 214);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numS);
            this.Controls.Add(this.numM);
            this.Controls.Add(this.numH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvClickInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AutoMouseClickSettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mouse Auto Action Setting Dialog";
            this.Load += new System.EventHandler(this.AutoMouseClickSettingDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AutoMouseClickSetting_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClickInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouseActionEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClickInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource mouseActionEntityBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numH;
        private System.Windows.Forms.NumericUpDown numM;
        private System.Windows.Forms.NumericUpDown numS;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
    }
}

