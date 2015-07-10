using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LidgrenTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            NetPeerConfiguration config = new NetPeerConfiguration("LidgrenTestServer");
            config.Port = 14242;
            config.MaximumConnections = 200;

            NetServer server = new NetServer(config);

            server.Start();

            NetIncomingMessage msg;
            while(true)
            {
                if((msg = server.ReadMessage()) != null)
                {
                    Console.WriteLine(msg.ReadString());
                    server.Recycle(msg);
                }
                Thread.Sleep(20);
            }
        }
    }
}
