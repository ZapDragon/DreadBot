using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace GroupGuardian
{
    class DataReader
    {

        private string RestAPI = "";
        private int payLoadOffset = 0;
        private byte[] UpdatePayload;


        public DataReader(TcpClient tcpsocket, SslStream securesocket)
        {

            byte[] payLoad = SocketReader(tcpsocket, securesocket);
            try
            {
                securesocket.Write(HttpsServer.Http200(), 0, HttpsServer.Http200().Length);
                securesocket.Flush();
            }
            catch { return; }
            string Packet = Encoding.UTF8.GetString(payLoad);
            GetHeaders(Packet);

            if (payLoadOffset > 0)
            {
                UpdatePayload = new byte[payLoadOffset];
                UpdatePayload = payLoad.Skip(payLoad.Length - payLoadOffset - 1).Take(payLoadOffset).ToArray();
            }
            else { Console.WriteLine("Nope. Regex broke."); }

            Update update;
            try { update = (Update)new DataContractJsonSerializer(typeof(Update)).ReadObject(new MemoryStream(UpdatePayload, 0, payLoadOffset)); }
            catch (Exception e) { Console.WriteLine("Exception during deserialization. Line 65.\n" + Encoding.UTF8.GetString(UpdatePayload)); return; }
            new UpdateParser(update);
        }
        private byte[] SocketReader(TcpClient tcpClient, SslStream sslStream)
        {
            byte[] data = new byte[10240];
            byte[] payLoad;
            int offSet = 0;
            while (tcpClient.Available > 0)
            {
                //Console.WriteLine("Availible: " + tcpClient.Available);
                offSet += sslStream.Read(data, offSet, data.Length - offSet);
                //Console.WriteLine("Offset: " + offSet);
            }
            payLoad = new byte[offSet];
            payLoad = data.Take(offSet).ToArray();
            return payLoad;
        }

        private void GetHeaders(string packet)
        {
            //Regex Expect = new Regex(@"(?:POST\s(?<api>\/\w+)\sHTTP\/1.1)");
            Match postMatch = new Regex(@"(?:POST\s(?<api>\/\w+)\sHTTP\/1.1)").Match(packet);
            Match lengthMatch = new Regex(@"(Content-Length:\s(?<length>\d+))").Match(packet);

            if (postMatch.Success) { RestAPI = postMatch.Groups["api"].Value; }
            if (lengthMatch.Success) { payLoadOffset = Int32.Parse(lengthMatch.Groups["length"].Value); }
        }
    }
}
