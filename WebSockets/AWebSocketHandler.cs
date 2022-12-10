using System;
using UnityEngine;
using WebSocketSharp;

namespace WebSockets_Nika
{
    public abstract class AWebSocketHandler : MonoBehaviour
    {
        public abstract void InitializeWebSocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback);
        public abstract void CloseWebSocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback);
        public abstract void CleanUpDuringExit();//Disabling all websockets while exiting
    }
}
