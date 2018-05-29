using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Helpers;

namespace Conference
{
    partial class Server : ServiceBase, IServer
    {

        private WebSocketServer listener;
        
        public void Run()
        {
            Run(this);
        }

        protected override void OnStart(string[] args)
        {
            if (listener == null)
            {
                listener = new WebSocketServer(AppConfigHelper.ServerEndPoint);
                listener.AddWebSocketService<WebCamBehavior>(AppConfigHelper.MainPath);
            }
            listener.Start();
        }

        protected override void OnStop()
        {
            listener.Stop();
        }
    }
}
