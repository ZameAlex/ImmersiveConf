using System;
using VideoConfClient.Helpers;
using WebSocketSharp;

namespace VideoConfClient.Core
{
    /// <summary>
    /// Class that encapsulates WebSocket from WebSocketSharp library.
    /// </summary>
    public class WebSocketClient
    {
        public event EventHandler<MessageEventArgs> OnMessage;
        private WebSocket webSocket;

        public WebSocketClient()
        {
            webSocket = new WebSocket(AppConfig.ServerEndpoint);
            webSocket.OnMessage += OnMessageTrigger;
        }

        public void Connect()
        {
            webSocket.ConnectAsync();
        }

        public void Close()
        {
            if (webSocket.IsAlive)
            {
                webSocket.Close();
            }
        }

        private void OnMessageTrigger(object sender, MessageEventArgs args)
        {
            OnMessage?.Invoke(sender, args);
        }
    }
}
