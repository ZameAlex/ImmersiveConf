using Conference.Helper;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Conference
{
    class ConsoleServer: IServer
    {
        private WebSocketServer listener;

        public void Run()
        {
            listener = new WebSocketServer(Helper.AppConfigHelper.ServerEndPoint);
            listener.AddWebSocketService<WebCamBehavior>(Helper.AppConfigHelper.MainPath);
            listener.Start();

            CommandLoop();

            listener.Stop();
        }

        private void CommandLoop()
        {
            Console.WriteLine($"{DateTime.Now} Server started");
            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command.CompareTo("exit") == 0)
                {
                    break;
                }
            }
        }
    }
}
