using System;
using UnityEngine;
using WebSocketSharp;

namespace WebSockets_Nika
{
    public class WebSocketManager : MonoBehaviour
    {
        [SerializeField] AWebSocketHandler webSocketHandler;

        private void OnEnable()
        {
            WebSocketEvents.OnWebSocketInitializeRequest += WebSocketEvents_OnWebSocketInitializeRequest;
            WebSocketEvents.OnWebSocketCloseRequest += WebSocketEvents_OnWebSocketCloseRequest;
            WebSocketEvents.OnWebSocketReConnectRequest += WebSocketEvents_OnWebSocketReConnectRequest;
        }

        private void OnDisable()
        {
            WebSocketEvents.OnWebSocketInitializeRequest -= WebSocketEvents_OnWebSocketInitializeRequest;
            WebSocketEvents.OnWebSocketCloseRequest -= WebSocketEvents_OnWebSocketCloseRequest;
            WebSocketEvents.OnWebSocketReConnectRequest -= WebSocketEvents_OnWebSocketReConnectRequest;
        }

        private void WebSocketEvents_OnWebSocketReConnectRequest(string arg1, EventHandler<MessageEventArgs> arg2, EventHandler<ErrorEventArgs> arg3)
        {
            webSocketHandler.CloseWebSocket(arg1, arg2, arg3);
            webSocketHandler.InitializeWebSocket(arg1, arg2, arg3);
        }

        private void WebSocketEvents_OnWebSocketCloseRequest(string arg1, EventHandler<MessageEventArgs> arg2, EventHandler<ErrorEventArgs> arg3)
        {
            webSocketHandler.CloseWebSocket(arg1, arg2, arg3);
        }

        private void WebSocketEvents_OnWebSocketInitializeRequest(string arg1, EventHandler<MessageEventArgs> arg2, EventHandler<ErrorEventArgs> arg3)
        {
            webSocketHandler.InitializeWebSocket(arg1, arg2, arg3);
        }
    }
}
