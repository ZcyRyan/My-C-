using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoClickForWindows
{
    public partial class AutoMouseClickSettingDialog : Form
    {
        //Thread to work in other thread
        private SynchronizationContext context = null;
        private ClickType clickType = ClickType.click;
        private BindingList<MouseActionEntity> mouseInfoList = new BindingList<MouseActionEntity>();
        private int RunCount = 0;

        public AutoMouseClickSettingDialog()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            KeyPreview = true;
            this.dgvClickInfo.DataSource = mouseInfoList;
            this.numM.Value = 8;
        }

        private void AutoMouseClickSetting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Alt && (e.KeyCode == Keys.L || e.KeyCode == Keys.D || e.KeyCode == Keys.R))
                {
                    clickType = MouseActionEntity.GetClickType(e.KeyCode);
                    int x = Cursor.Position.X;
                    int y = Cursor.Position.Y;
                    MouseActionEntity mouseInfo = new MouseActionEntity(
                        x, y, string.Empty, 0, clickType);
                    InputForm form = new InputForm(mouseInfo);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //Add one list
                        form.MouseResult.ActionNo = mouseInfoList.Count + 1;
                        mouseInfoList.Add(form.MouseResult);
                        this.dgvClickInfo.Refresh();
                        this.dgvClickInfo.Rows[mouseInfoList.Count - 1].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClickInfo.SelectedRows.Count > 0)
                {
                    mouseInfoList.RemoveAt(this.dgvClickInfo.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (mouseInfoList != null && mouseInfoList.Count > 0)
                {
                    mouseInfoList.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonUtility.IsConfigFileExists())
                {
                    if (mouseInfoList.Count > 0)
                    {
                        CommonUtility.SaveConfiguration(this.mouseInfoList.ToList());
                    }
                }

                EnableButtons(false);
                this.timer = new System.Windows.Forms.Timer();
                int seconds = (int)(numH.Value * 3600 + numM.Value * 60 + numS.Value);
                if (seconds == 0)
                {
                    //Default 10
                    seconds = 10;
                }
                this.timer.Interval = seconds * 1000;
                this.timer.Tick += timer_Tick;
                this.timer.Start();
                //Set can not be seen
                this.WindowState = FormWindowState.Minimized;
                //Call once
                timer_Tick(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                RunCount++;
                foreach (MouseActionEntity action in mouseInfoList)
                {
                    if (action.Type.Equals(ClickType.SendKeys))
                    {
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(WorkSendKeys), action);
                    }
                    else// if (entry is ClickEntry)
                    {
                        Thread.Sleep(action.Interval * 1000 - 100);
                        WorkClick(action);
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(WorkClick), action);
                    }
                }
                Logger.WriteLog("all action is over! Time: " + RunCount.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WorkSendKeys(object state)
        {
            //this.context.Send(new SendOrPostCallback(delegate(object _state)
            //{
            //    MouseActionEntity action = state as MouseActionEntity;
            //    SendKeys.Send(action.Comment);
            //}), state);
        }

        private void WorkClick(object state)
        {
            this.context.Send(new SendOrPostCallback(delegate(object _state)
            {
                MouseActionEntity action = state as MouseActionEntity;
                Win32.SetCursorPos(action.X, action.Y);
                Thread.Sleep(100);
                if (action.Type.Equals(ClickType.click))
                {
                    Logger.WriteLog(action.ActionNo + " " + action.X.ToString() + " " + action.Y.ToString() + " " + action.Interval.ToString());
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else if (action.Type.Equals(ClickType.doubleClick))
                {
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                else //if (action.Type.Equals(ClickType.rightClick))
                {
                    Win32.mouse_event(Win32.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    Win32.mouse_event(Win32.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                }
            }), state);
        }

        private void EnableButtons(bool enabled)
        {
            btnClear.Enabled = enabled;
            btnDelete.Enabled = enabled;
            btnStart.Enabled = enabled;
            this.KeyPreview = enabled;
            this.numH.Enabled = enabled;
            this.numM.Enabled = enabled;
            this.numS.Enabled = enabled;
            this.btnSaveSetting.Enabled = enabled;
            this.btnLoad.Enabled = enabled;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                timer.Dispose();
                EnableButtons(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (mouseInfoList.Count > 0)
                {
                    CommonUtility.SaveConfiguration(this.mouseInfoList.ToList());
                }
                else
                {
                    MessageBox.Show("No data to save!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonUtility.IsConfigFileExists())
                {
                    mouseInfoList = new BindingList<MouseActionEntity>();
                    var list = CommonUtility.ReadConfiguration();
                    list.ForEach(data => mouseInfoList.Add(data));
                    this.dgvClickInfo.DataSource = mouseInfoList;
                }
                else
                {
                    MessageBox.Show("No saved data to load!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvClickInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClickInfo.SelectedRows.Count > 0)
                {
                    MouseActionEntity mouseInfo = mouseInfoList[this.dgvClickInfo.SelectedRows[0].Index];
                    InputForm form = new InputForm(mouseInfo);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        mouseInfoList[this.dgvClickInfo.SelectedRows[0].Index] = form.MouseResult;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AutoMouseClickSettingDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            Logger.CleanLogger();
        }
    }
}
