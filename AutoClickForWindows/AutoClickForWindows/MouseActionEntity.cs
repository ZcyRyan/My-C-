using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoClickForWindows
{
        //[Flags]
    public enum ClickType
    {
        click = 0,
        rightClick,
        doubleClick,
        SendKeys
    }

    [Serializable]
    public class MouseActionEntity : INotifyPropertyChanged
    {
        private int actionNo;
        private int x;
        private int y;
        private string comment;
        private int interval;
        private ClickType type;
        private string displayType;

        #region Implement Notify interface
        /// <summary>
        ///  PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify property changed.
        /// </summary>
        /// <param name="info">Name of changed property.</param>
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        public MouseActionEntity()
        {
        }

        public MouseActionEntity(int x, int y, string text, int interval, ClickType type)
        {
            
            this.x = x;
            this.y = y;
            this.comment = text;
            this.interval = interval;
            this.type = type;
            this.displayType = GetDisplayType(type);
        }

        public MouseActionEntity(int actionNo, int x, int y, string text, int interval, ClickType type)
            : this(x, y, text, interval, type)
        {
            this.actionNo = actionNo;
        }

        public int ActionNo
        {
            set
            {
                actionNo = value;
                NotifyPropertyChanged("ActionNo");
            }
            get
            {
                return actionNo;
            }
        }
        
        public int X
        {
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
            get
            {
                return x;
            }
        }

        public int Y
        {
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
            get
            {
                return y;
            }
        }

        public string Comment
        {
            set
            {
                comment = value;
                NotifyPropertyChanged("Comment");
            }
            get
            {
                return comment;
            }
        }

        public int Interval
        {
            set
            {
                interval = value;
                NotifyPropertyChanged("Interval");
            }
            get
            {
                return interval;
            }
        }

        public string DisplayType
        {
            set
            {
                displayType = value;
                NotifyPropertyChanged("DisplayType");
            }
            get
            {
                return displayType;
            }
        }

        public ClickType Type
        {
            set
            {
                type = value;
                displayType = GetDisplayType(type);
            }
            get
            {
                return type;
            }
        }

        public static string GetDisplayType(ClickType type)
        {
            string ret = string.Empty;
            switch (type)
            {
                case ClickType.click:
                    ret = "Left Click";
                    break;
                case ClickType.doubleClick:
                    ret = "Double Click";
                    break;
                case ClickType.rightClick:
                    ret = "Right Click";
                    break;
                case ClickType.SendKeys:
                    ret = "SendKeys";
                    break;
                default:
                    break;
            }
            return ret;
        }

        public static ClickType GetClickType(Keys keycode)
        {
            ClickType clickType;
            if (keycode == Keys.L)
            {
                clickType = ClickType.click;
            }
            else if (keycode == Keys.D)
            {
                clickType = ClickType.doubleClick;
            }
            else if (keycode == Keys.R)
            {
                clickType = ClickType.rightClick;
            }
            else
            {
                clickType = ClickType.SendKeys;
            }
            return clickType;
        }
    }
}
