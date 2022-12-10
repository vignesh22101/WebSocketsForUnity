using System;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

namespace WebSockets_Nika
{
    public class WebSocketHandler : AWebSocketHandler
    {
        public Dictionary<string, WebSocket> webSocketContainer = new Dictionary<string, WebSocket>();

        private void OnDestroy()
        {
            CleanUpDuringExit();
        }

        public override void CleanUpDuringExit()
        {
            foreach (var item in webSocketContainer)
            {
                item.Value.Close();
            }
        }

        public override void CloseWebSocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback)
        {
            if (webSocketContainer.ContainsKey(url))
            {
                WebSocket webSocket = webSocketContainer[url];

                if (!webSocket.IsAlive)
                {
                    Debug.LogWarning($"Websocket already closed, discarding closing again:{url}");
                }
                else
                {
                    webSocket.Close();
                    if (messageCallback != null)
                        webSocket.OnMessage -= messageCallback;
                    if (errorCallback != null)
                        webSocket.OnError -= errorCallback;
                }
            }
            else
            {
                Debug.LogWarning($"Request websocket doesn't exists: {url}");
            }
        }

        public override void InitializeWebSocket(string url, EventHandler<MessageEventArgs> messageCallback, EventHandler<ErrorEventArgs> errorCallback)
        {
            WebSocket webSocket = null;

            if (webSocketContainer.ContainsKey(url))
            {
                webSocket = webSocketContainer[url];

                if (webSocket.IsAlive)
                {
                    Debug.LogWarning($"Websocket already initialized, discarding initializing again:{url}");
                }
                else
                {
                    webSocket.Connect();

                    webSocket.OnMessage += messageCallback;
                    webSocket.OnError += errorCallback;
                }
            }
            else
            {
                webSocket = new WebSocket(url);

                webSocket.Connect();
                webSocket.OnMessage += messageCallback;
                webSocket.OnError += errorCallback;

                webSocketContainer.Add(url, webSocket);
            }
        }
    }
}
