using System;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

namespace WebSockets_Nika
{
    public static class WebSocketEvents
    {
        public static event Action<string, EventHandler<MessageEventArgs>, EventHandler<ErrorEventArgs>> OnWebSocketInitializeRequest;
        public static event Action<string, EventHandler<MessageEventArgs>, EventHandler<ErrorEventArgs>> OnWebSocketCloseRequest;
        public static event Action<string, EventHandler<MessageEventArgs>, EventHandler<ErrorEventArgs>> OnWebSocketReConnectRequest;

        public static void InitializeWebsocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback)
        {
            OnWebSocketInitializeRequest?.Invoke(url, messageCallback, errorCallback);
        }

        public static void CloseWebsocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback)
        {
            OnWebSocketCloseRequest?.Invoke(url, messageCallback, errorCallback);
        }

        public static void ReconnetWebsocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback)
        {
            OnWebSocketReConnectRequest?.Invoke(url, messageCallback, errorCallback);
        }
    }
}
