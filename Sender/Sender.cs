using Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Sender
{
    public class Sender
    {
        private WebSocket socket;
        public Sender()
        {
            socket = new WebSocket(Conference.Helper.AppConfigHelper.ServerEndPoint);

            socket.OnOpen += (sender, e) => Console.WriteLine("Socket Opened");
            socket.OnError += (sender, e) => Console.WriteLine("Socket Error: " + e.Message);
            socket.OnClose += (sender, e) => Console.WriteLine("Socket Closed: " + e.Reason);
            socket.ConnectAsync();

        }

        public void Send(Bitmap Frame)
        {
            if (socket.IsAlive)
            {
                socket.SendAsync(Frame.ToByteArray(), null);
            }

        }
    }
}
