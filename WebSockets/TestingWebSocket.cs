using UnityEngine;
using WebSockets_Nika;
using WebSocketSharp;

public class TestingWebSocket : MonoBehaviour
{
    public bool closeWebSocket;
    public bool initializeWebscoket;
    public bool reconnect;
    string url= "wss://stream.binance.com:9443/stream?streams=btcusdt@depth10@1000ms";

    void Start()
    {
        WebSocketEvents.InitializeWebsocket(url, OnMessage, null);
    }

    private void OnMessage(object sender, MessageEventArgs messageEventArgs)
    {
        print($"{messageEventArgs.Data}");
    }

    private void OnValidate()
    {
        if (closeWebSocket)
        {
            WebSocketEvents.CloseWebsocket(url, OnMessage, null);
            closeWebSocket = false;
        }

        if (initializeWebscoket)
        {
            WebSocketEvents.InitializeWebsocket(url, OnMessage, null);
            initializeWebscoket = false;
        }

        if (reconnect)
        {
            WebSocketEvents.ReconnetWebsocket(url, OnMessage, null);
            reconnect = false;
        }
    }
}
