using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AutoClickForWindows
{
    public class Win32
    {

        #region Mouse action
        public const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        public const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        public const int MOUSEEVENTF_RIGHTUP = 0x0010; /* right button up */
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; /* middle button down */
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040; /* middle button up */
        public const int MOUSEEVENTF_XDOWN = 0x0080; /* x button down */
        public const int MOUSEEVENTF_XUP = 0x0100; /* x button down */
        public const int MOUSEEVENTF_WHEEL = 0x0800; /* wheel button rolled */
        public const int MOUSEEVENTF_VIRTUALDESK = 0x4000; /* map to entire virtual desktop */
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; /* absolute move */
        #endregion

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        public static class CursorPosition
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct PointInter
            {
                public int X;
                public int Y;
                public static explicit operator Point(PointInter point)
                {
                    return new Point(point.X, point.Y);
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out AutoClickForWindows.Win32.CursorPosition.PointInter lpPoint);

        // For your convenience
        public static Point GetCursorPosition()
        {
            AutoClickForWindows.Win32.CursorPosition.PointInter lpPoint;
            GetCursorPos(out lpPoint);
            return (Point) lpPoint;
        }
    }
}
