using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace GroupGuardian
{
    class HttpsServer
    {
        public static X509Certificate2 certificate; //Used to TLS authenticate the incomming HTTPS Connections from Telegram.
        public static TcpListener tcplistener = new TcpListener(IPAddress.Parse("10.0.0.50"), 8443); //NEW TCP LISTEN SOCKET
        public static List<HttpsClient> clientList = new List<HttpsClient>();

        public static byte[] Http200() {
            return new HttpsResponse().payload();
            //return Encoding.UTF8.GetBytes("HTTP/1.1 200 OK" + Environment.NewLine + "Date: " + System.DateTime.Now.ToString("R") + Environment.NewLine + "Server: TelegramBot-0.0.01a TelegramBotAPI Client" + Environment.NewLine + "X-Powered-By: .NET-4.5.6" + Environment.NewLine + "Connection: Keep-Alive" + Environment.NewLine + "Content-Type: application/json" + Environment.NewLine + Environment.NewLine);
        }

        public static void newClient()
        {
            HttpsClient httpClient = new HttpsClient(tcplistener.AcceptTcpClient());
            //Console.WriteLine("New connection");
        }
    }

    class HttpsResponse
    {
        public uint responseCode;
        public string body;
        private static string userAgent = "TelegramBot-0.0.01a TelegramBotAPI Client";

        public static Dictionary<uint, string> responseCodeNames = new Dictionary<uint, string>()
        {
            { 200, "OK" },
            { 400, "Bad Request" }
        };

        public HttpsResponse()
        {
            body = "";
            responseCode = 200;
        }

        public byte[] payload()
        {
            string response = "HTTP/1.1 ";
            response += responseCode.ToString();
            response += " " + responseCodeNames[responseCode];
            response += "\r\n";
            response += "Date: " + DateTime.Now.ToString("R") + "\r\n";
            response += "Server: " + userAgent + "\r\n";
            response += "Content-Length: " + body.Length + "\r\n";
            response += "\r\n";

            return Encoding.UTF8.GetBytes(response);
        }
    }


    public class HttpsClient
    {
        private Thread thread;
        public string address = "";
        public TcpClient opensocket;
        public SslStream securesocket;
        public int CID = 0;

        public HttpsClient(TcpClient opensocket)
        {
            this.opensocket = opensocket;
            address = ((IPEndPoint)opensocket.Client.RemoteEndPoint).Address.ToString();
            securesocket = new SslStream(opensocket.GetStream());
            try { securesocket.AuthenticateAsServer(HttpsServer.certificate, false, SslProtocols.Tls12, false); }
            catch { return; }
            //securesocket.WriteTimeout = 5000;
            thread = new Thread(SocketListener);
            thread.IsBackground = true;
            thread.Start();
        }

        private void SocketListener()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (!opensocket.Connected) { thread.Abort(); } // Check of connection still exists with Dictionary object of TCP connection....
                if (opensocket.Available > 0) { // ... Check if there is data waiting for this client.
                    new DataReader(opensocket, securesocket);
                }
                
            }
        }
    }
}
