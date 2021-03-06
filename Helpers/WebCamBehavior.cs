﻿using System.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Helpers
{
    public class WebCamBehavior :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsBinary)
            {
                Sessions.Sessions
                   .Where(x => x.State == WebSocketState.Open && x.ID != ID)
                   .ToList()
                   .ForEach(x => Sessions.SendToAsync(e.RawData, x.ID, null));
            }
        }
    }
}
