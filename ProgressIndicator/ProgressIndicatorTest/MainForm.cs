using System;
using System.Drawing;
using System.Windows.Forms;
using ProgressControls;

namespace ProgressIndicatorTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EnableTrackBars(bool enable)
        {
            toolStripButtonResetValues.Enabled = enable;
            toolStripButtonChangeColor.Enabled = enable;
            toolStripButtonStartAnimation.Enabled = !enable;
            toolStripButtonStopAnimation.Enabled = enable;

            groupBoxProperties.Enabled = enable;

            numericUpDownPercentage.Enabled = enable ? checkBoxPercentage.Checked : false;
            textBoxText.Enabled = enable ? checkBoxShowText.Checked : false;
        }

        private void RefreshLabels()
        {
            labelAnimationSpeed.Text = string.Format("Animation Speed: {0}", progressIndicator.AnimationSpeed);
            labelCircleSize.Text = string.Format("Circle Size: {0}", progressIndicator.CircleSize);
            labelControlSize.Text = string.Format("Control Size: {0}", progressIndicator.Width);
            labelNumberOfCircles.Text = string.Format("Number of Circles: {0}", progressIndicator.NumberOfCircles);
            labelVisibleCircles.Text = string.Format("Number of visible circles: {0}", progressIndicator.NumberOfVisibleCircles);
        }

        private void EraseLabels()
        {
            labelAnimationSpeed.Text = "Animation Speed:";
            labelCircleSize.Text = "Circle Size:";
            labelControlSize.Text = "Control Size:";
            labelNumberOfCircles.Text = "Number of circles:";
            labelVisibleCircles.Text = "Number of visible circles:";
        }

        private void SetVisibleCircles()
        {
            int visible = trackBarVisibleCircles.Value;
            trackBarVisibleCircles.Maximum = trackBarNumberOfCircles.Value;
            trackBarVisibleCircles.Value = trackBarVisibleCircles.Maximum > visible ? visible : trackBarVisibleCircles.Maximum;
        }

        private void trackBarControlSize_Scroll(object sender, EventArgs e)
        {
            int value = trackBarControlSize.Value;
            progressIndicator.Size = new Size(value, value);
            RefreshLabels();
        }

        private void trackBarCircleSize_Scroll(object sender, EventArgs e)
        {
            progressIndicator.CircleSize = trackBarCircleSize.Value / 10.0F;
            RefreshLabels();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            trackBarControlSize.Value = progressIndicator.Width;
            trackBarCircleSize.Value = (int)(progressIndicator.CircleSize * 10);
            trackBarSpeed.Value = progressIndicator.AnimationSpeed;
            trackBarNumberOfCircles.Value = progressIndicator.NumberOfCircles;
            trackBarVisibleCircles.Maximum = trackBarNumberOfCircles.Value;
            trackBarVisibleCircles.Value = progressIndicator.NumberOfVisibleCircles;

            numericUpDownPercentage.Value = Convert.ToDecimal(progressIndicator.Percentage);
            textBoxText.Text = progressIndicator.Text;

            radioButtonCW.Checked = progressIndicator.Rotation == ProgressControls.ProgressIndicator.RotationType.Clockwise;

            EnableTrackBars(false);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            progressIndicator.Start();
            EnableTrackBars(true);
            RefreshLabels();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            progressIndicator.Stop();
            EnableTrackBars(false);
            EraseLabels();
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            progressIndicator.AnimationSpeed = trackBarSpeed.Value;
            RefreshLabels();
        }

        private void buttonResetValues_Click(object sender, EventArgs e)
        {
            progressIndicator.CircleColor = Color.FromArgb(20, 20, 20);
            progressIndicator.Size = new Size(360, 360);
            progressIndicator.CircleSize = 1.0F;
            progressIndicator.AnimationSpeed = 75;
            progressIndicator.NumberOfCircles = 8;
            progressIndicator.NumberOfVisibleCircles = 8;

            trackBarSpeed.Value = progressIndicator.AnimationSpeed;
            trackBarControlSize.Value = progressIndicator.Width;
            trackBarNumberOfCircles.Value = progressIndicator.NumberOfCircles;
            trackBarCircleSize.Value = (int)(progressIndicator.CircleSize * 10);
            numericUpDownPercentage.Value = Convert.ToDecimal(progressIndicator.Percentage);
            SetVisibleCircles();

            checkBoxPercentage.Checked = false;
            checkBoxShowText.Checked = false;
            radioButtonCW.Checked = true;

            RefreshLabels();
        }

        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                progressIndicator.CircleColor = colorDialog.Color;
            }
        }

        private void trackBarCircles_Scroll(object sender, EventArgs e)
        {
            progressIndicator.NumberOfCircles = trackBarNumberOfCircles.Value;
            SetVisibleCircles();
            progressIndicator.NumberOfVisibleCircles = trackBarVisibleCircles.Value;
            RefreshLabels();
        }

        private void numericUpDownPercentage_ValueChanged(object sender, EventArgs e)
        {
            progressIndicator.Percentage = Convert.ToSingle(numericUpDownPercentage.Value);
        }

        private void trackBarVisibleCircles_Scroll(object sender, EventArgs e)
        {
            progressIndicator.NumberOfVisibleCircles = trackBarVisibleCircles.Value;
            RefreshLabels();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownPercentage.Enabled = checkBoxPercentage.Checked;
            progressIndicator.ShowPercentage = checkBoxPercentage.Checked;

            textBoxText.Enabled = checkBoxShowText.Checked;
            progressIndicator.ShowText = checkBoxShowText.Checked;
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            progressIndicator.Text = textBoxText.Text;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            progressIndicator.Rotation = radioButtonCW.Checked ? ProgressControls.ProgressIndicator.RotationType.Clockwise : ProgressControls.ProgressIndicator.RotationType.CounterClockwise;
        }
    }
}
