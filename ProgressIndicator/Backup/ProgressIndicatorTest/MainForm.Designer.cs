namespace ProgressIndicatorTest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trackBarCircleSize = new System.Windows.Forms.TrackBar();
            this.trackBarControlSize = new System.Windows.Forms.TrackBar();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.labelAnimationSpeed = new System.Windows.Forms.Label();
            this.labelCircleSize = new System.Windows.Forms.Label();
            this.labelControlSize = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.checkBoxShowText = new System.Windows.Forms.CheckBox();
            this.trackBarVisibleCircles = new System.Windows.Forms.TrackBar();
            this.labelVisibleCircles = new System.Windows.Forms.Label();
            this.numericUpDownPercentage = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPercentage = new System.Windows.Forms.CheckBox();
            this.trackBarNumberOfCircles = new System.Windows.Forms.TrackBar();
            this.labelNumberOfCircles = new System.Windows.Forms.Label();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStartAnimation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopAnimation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonResetValues = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonChangeColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.progressIndicator = new ProgressControls.ProgressIndicator();
            this.radioButtonCCW = new System.Windows.Forms.RadioButton();
            this.radioButtonCW = new System.Windows.Forms.RadioButton();
            this.labelRotate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCircleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBoxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVisibleCircles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfCircles)).BeginInit();
            this.toolStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarCircleSize
            // 
            this.trackBarCircleSize.Location = new System.Drawing.Point(6, 103);
            this.trackBarCircleSize.Minimum = 1;
            this.trackBarCircleSize.Name = "trackBarCircleSize";
            this.trackBarCircleSize.Size = new System.Drawing.Size(341, 45);
            this.trackBarCircleSize.TabIndex = 0;
            this.trackBarCircleSize.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarCircleSize.Value = 1;
            this.trackBarCircleSize.Scroll += new System.EventHandler(this.trackBarCircleSize_Scroll);
            // 
            // trackBarControlSize
            // 
            this.trackBarControlSize.Location = new System.Drawing.Point(6, 168);
            this.trackBarControlSize.Maximum = 360;
            this.trackBarControlSize.Minimum = 16;
            this.trackBarControlSize.Name = "trackBarControlSize";
            this.trackBarControlSize.Size = new System.Drawing.Size(341, 45);
            this.trackBarControlSize.SmallChange = 8;
            this.trackBarControlSize.TabIndex = 1;
            this.trackBarControlSize.TickFrequency = 16;
            this.trackBarControlSize.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarControlSize.Value = 16;
            this.trackBarControlSize.Scroll += new System.EventHandler(this.trackBarControlSize_Scroll);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(6, 39);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(341, 45);
            this.trackBarSpeed.TabIndex = 5;
            this.trackBarSpeed.TickFrequency = 10;
            this.trackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarSpeed.Value = 1;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // labelAnimationSpeed
            // 
            this.labelAnimationSpeed.AutoSize = true;
            this.labelAnimationSpeed.Location = new System.Drawing.Point(15, 23);
            this.labelAnimationSpeed.Name = "labelAnimationSpeed";
            this.labelAnimationSpeed.Size = new System.Drawing.Size(90, 13);
            this.labelAnimationSpeed.TabIndex = 8;
            this.labelAnimationSpeed.Text = "Animation Speed:";
            // 
            // labelCircleSize
            // 
            this.labelCircleSize.AutoSize = true;
            this.labelCircleSize.Location = new System.Drawing.Point(15, 87);
            this.labelCircleSize.Name = "labelCircleSize";
            this.labelCircleSize.Size = new System.Drawing.Size(59, 13);
            this.labelCircleSize.TabIndex = 9;
            this.labelCircleSize.Text = "Circle Size:";
            // 
            // labelControlSize
            // 
            this.labelControlSize.AutoSize = true;
            this.labelControlSize.Location = new System.Drawing.Point(15, 151);
            this.labelControlSize.Name = "labelControlSize";
            this.labelControlSize.Size = new System.Drawing.Size(66, 13);
            this.labelControlSize.TabIndex = 10;
            this.labelControlSize.Text = "Control Size:";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.labelRotate);
            this.groupBoxProperties.Controls.Add(this.radioButtonCW);
            this.groupBoxProperties.Controls.Add(this.radioButtonCCW);
            this.groupBoxProperties.Controls.Add(this.textBoxText);
            this.groupBoxProperties.Controls.Add(this.checkBoxShowText);
            this.groupBoxProperties.Controls.Add(this.trackBarVisibleCircles);
            this.groupBoxProperties.Controls.Add(this.labelVisibleCircles);
            this.groupBoxProperties.Controls.Add(this.trackBarSpeed);
            this.groupBoxProperties.Controls.Add(this.trackBarControlSize);
            this.groupBoxProperties.Controls.Add(this.labelControlSize);
            this.groupBoxProperties.Controls.Add(this.trackBarCircleSize);
            this.groupBoxProperties.Controls.Add(this.numericUpDownPercentage);
            this.groupBoxProperties.Controls.Add(this.labelCircleSize);
            this.groupBoxProperties.Controls.Add(this.checkBoxPercentage);
            this.groupBoxProperties.Controls.Add(this.labelAnimationSpeed);
            this.groupBoxProperties.Controls.Add(this.trackBarNumberOfCircles);
            this.groupBoxProperties.Controls.Add(this.labelNumberOfCircles);
            this.groupBoxProperties.Location = new System.Drawing.Point(429, 28);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(353, 432);
            this.groupBoxProperties.TabIndex = 11;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(135, 368);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(201, 20);
            this.textBoxText.TabIndex = 24;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // checkBoxShowText
            // 
            this.checkBoxShowText.AutoSize = true;
            this.checkBoxShowText.Location = new System.Drawing.Point(18, 370);
            this.checkBoxShowText.Name = "checkBoxShowText";
            this.checkBoxShowText.Size = new System.Drawing.Size(77, 17);
            this.checkBoxShowText.TabIndex = 23;
            this.checkBoxShowText.Text = "Show Text";
            this.checkBoxShowText.UseVisualStyleBackColor = true;
            this.checkBoxShowText.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // trackBarVisibleCircles
            // 
            this.trackBarVisibleCircles.Location = new System.Drawing.Point(6, 296);
            this.trackBarVisibleCircles.Maximum = 1;
            this.trackBarVisibleCircles.Minimum = 1;
            this.trackBarVisibleCircles.Name = "trackBarVisibleCircles";
            this.trackBarVisibleCircles.Size = new System.Drawing.Size(341, 45);
            this.trackBarVisibleCircles.TabIndex = 22;
            this.trackBarVisibleCircles.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarVisibleCircles.Value = 1;
            this.trackBarVisibleCircles.Scroll += new System.EventHandler(this.trackBarVisibleCircles_Scroll);
            // 
            // labelVisibleCircles
            // 
            this.labelVisibleCircles.AutoSize = true;
            this.labelVisibleCircles.Location = new System.Drawing.Point(15, 280);
            this.labelVisibleCircles.Name = "labelVisibleCircles";
            this.labelVisibleCircles.Size = new System.Drawing.Size(124, 13);
            this.labelVisibleCircles.TabIndex = 21;
            this.labelVisibleCircles.Text = "Number of visible circles:";
            // 
            // numericUpDownPercentage
            // 
            this.numericUpDownPercentage.DecimalPlaces = 2;
            this.numericUpDownPercentage.Location = new System.Drawing.Point(135, 346);
            this.numericUpDownPercentage.Name = "numericUpDownPercentage";
            this.numericUpDownPercentage.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPercentage.TabIndex = 19;
            this.numericUpDownPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPercentage.ValueChanged += new System.EventHandler(this.numericUpDownPercentage_ValueChanged);
            // 
            // checkBoxPercentage
            // 
            this.checkBoxPercentage.AutoSize = true;
            this.checkBoxPercentage.Location = new System.Drawing.Point(18, 347);
            this.checkBoxPercentage.Name = "checkBoxPercentage";
            this.checkBoxPercentage.Size = new System.Drawing.Size(111, 17);
            this.checkBoxPercentage.TabIndex = 18;
            this.checkBoxPercentage.Text = "Show Percentage";
            this.checkBoxPercentage.UseVisualStyleBackColor = true;
            this.checkBoxPercentage.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // trackBarNumberOfCircles
            // 
            this.trackBarNumberOfCircles.Location = new System.Drawing.Point(6, 232);
            this.trackBarNumberOfCircles.Maximum = 24;
            this.trackBarNumberOfCircles.Minimum = 1;
            this.trackBarNumberOfCircles.Name = "trackBarNumberOfCircles";
            this.trackBarNumberOfCircles.Size = new System.Drawing.Size(341, 45);
            this.trackBarNumberOfCircles.TabIndex = 17;
            this.trackBarNumberOfCircles.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarNumberOfCircles.Value = 1;
            this.trackBarNumberOfCircles.Scroll += new System.EventHandler(this.trackBarCircles_Scroll);
            // 
            // labelNumberOfCircles
            // 
            this.labelNumberOfCircles.AutoSize = true;
            this.labelNumberOfCircles.Location = new System.Drawing.Point(15, 216);
            this.labelNumberOfCircles.Name = "labelNumberOfCircles";
            this.labelNumberOfCircles.Size = new System.Drawing.Size(92, 13);
            this.labelNumberOfCircles.TabIndex = 16;
            this.labelNumberOfCircles.Text = "Number of circles:";
            // 
            // toolStripTop
            // 
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStartAnimation,
            this.toolStripButtonStopAnimation,
            this.toolStripSeparator1,
            this.toolStripButtonResetValues,
            this.toolStripSeparator2,
            this.toolStripButtonChangeColor,
            this.toolStripSeparator3,
            this.toolStripButtonAbout});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(794, 25);
            this.toolStripTop.TabIndex = 12;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // toolStripButtonStartAnimation
            // 
            this.toolStripButtonStartAnimation.Image = global::ProgressIndicatorTest.Properties.Resources.control;
            this.toolStripButtonStartAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartAnimation.Name = "toolStripButtonStartAnimation";
            this.toolStripButtonStartAnimation.Size = new System.Drawing.Size(110, 22);
            this.toolStripButtonStartAnimation.Text = "Start Animation";
            this.toolStripButtonStartAnimation.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // toolStripButtonStopAnimation
            // 
            this.toolStripButtonStopAnimation.Image = global::ProgressIndicatorTest.Properties.Resources.control_stop_square;
            this.toolStripButtonStopAnimation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopAnimation.Name = "toolStripButtonStopAnimation";
            this.toolStripButtonStopAnimation.Size = new System.Drawing.Size(110, 22);
            this.toolStripButtonStopAnimation.Text = "Stop Animation";
            this.toolStripButtonStopAnimation.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonResetValues
            // 
            this.toolStripButtonResetValues.Image = global::ProgressIndicatorTest.Properties.Resources.counter_reset;
            this.toolStripButtonResetValues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResetValues.Name = "toolStripButtonResetValues";
            this.toolStripButtonResetValues.Size = new System.Drawing.Size(92, 22);
            this.toolStripButtonResetValues.Text = "Reset Values";
            this.toolStripButtonResetValues.Click += new System.EventHandler(this.buttonResetValues_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonChangeColor
            // 
            this.toolStripButtonChangeColor.Image = global::ProgressIndicatorTest.Properties.Resources.color;
            this.toolStripButtonChangeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeColor.Name = "toolStripButtonChangeColor";
            this.toolStripButtonChangeColor.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonChangeColor.Text = "Change Color";
            this.toolStripButtonChangeColor.Click += new System.EventHandler(this.buttonChangeColor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Image = global::ProgressIndicatorTest.Properties.Resources.question;
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonAbout.Text = "About";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // progressIndicator
            // 
            this.progressIndicator.Location = new System.Drawing.Point(36, 67);
            this.progressIndicator.Name = "progressIndicator";
            this.progressIndicator.Percentage = 0F;
            this.progressIndicator.Size = new System.Drawing.Size(360, 360);
            this.progressIndicator.TabIndex = 2;
            this.progressIndicator.Text = "Progress Notification";
            // 
            // radioButtonCCW
            // 
            this.radioButtonCCW.AutoSize = true;
            this.radioButtonCCW.Location = new System.Drawing.Point(112, 398);
            this.radioButtonCCW.Name = "radioButtonCCW";
            this.radioButtonCCW.Size = new System.Drawing.Size(50, 17);
            this.radioButtonCCW.TabIndex = 25;
            this.radioButtonCCW.TabStop = true;
            this.radioButtonCCW.Text = "CCW";
            this.radioButtonCCW.UseVisualStyleBackColor = true;
            // 
            // radioButtonCW
            // 
            this.radioButtonCW.AutoSize = true;
            this.radioButtonCW.Location = new System.Drawing.Point(63, 398);
            this.radioButtonCW.Name = "radioButtonCW";
            this.radioButtonCW.Size = new System.Drawing.Size(43, 17);
            this.radioButtonCW.TabIndex = 26;
            this.radioButtonCW.TabStop = true;
            this.radioButtonCW.Text = "CW";
            this.radioButtonCW.UseVisualStyleBackColor = true;
            this.radioButtonCW.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // labelRotate
            // 
            this.labelRotate.AutoSize = true;
            this.labelRotate.Location = new System.Drawing.Point(15, 400);
            this.labelRotate.Name = "labelRotate";
            this.labelRotate.Size = new System.Drawing.Size(42, 13);
            this.labelRotate.TabIndex = 27;
            this.labelRotate.Text = "Rotate:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 472);
            this.Controls.Add(this.toolStripTop);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.progressIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Progress Indicator Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCircleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVisibleCircles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfCircles)).EndInit();
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarCircleSize;
        private System.Windows.Forms.TrackBar trackBarControlSize;
        private ProgressControls.ProgressIndicator progressIndicator;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label labelAnimationSpeed;
        private System.Windows.Forms.Label labelCircleSize;
        private System.Windows.Forms.Label labelControlSize;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.TrackBar trackBarNumberOfCircles;
        private System.Windows.Forms.Label labelNumberOfCircles;
        private System.Windows.Forms.NumericUpDown numericUpDownPercentage;
        private System.Windows.Forms.CheckBox checkBoxPercentage;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartAnimation;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopAnimation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonResetValues;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonChangeColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.TrackBar trackBarVisibleCircles;
        private System.Windows.Forms.Label labelVisibleCircles;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.CheckBox checkBoxShowText;
        private System.Windows.Forms.Label labelRotate;
        private System.Windows.Forms.RadioButton radioButtonCW;
        private System.Windows.Forms.RadioButton radioButtonCCW;
    }
}

