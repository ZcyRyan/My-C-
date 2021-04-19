using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace SSHNetSample.CommunicationUtility
{
    public class WebSocketUtility
    {
        // Instance
        private static WebSocketUtility instance = null;
        // WebSocket client
        private WebSocket webSocketClient = null;
        /// <summary>
        /// Instance of WebSocket Utility
        /// </summary>
        public static WebSocketUtility Instance
        {
            get
            {
                return instance ?? (instance = new WebSocketUtility());
            }
        }

        public void Connect(string wsSite)
        {
            webSocketClient = new WebSocket(wsSite);
            webSocketClient.Connect();
        }
    }
}
