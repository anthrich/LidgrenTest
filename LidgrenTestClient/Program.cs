using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LidgrenTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetPeerConfiguration config = new NetPeerConfiguration("LidgrenTestServer");
            config.AutoFlushSendQueue = false;
            var s_client = new NetClient(config);

            s_client.Start();
            NetOutgoingMessage hail = s_client.CreateMessage("This is the hail message");
            s_client.Connect("localhost", 14242, hail);

            NetIncomingMessage msg;
            while (true)
            {
                if ((msg = s_client.ReadMessage()) != null)
                {
                    Console.WriteLine(msg.ReadString());
                    s_client.Recycle(msg);
                }
                Thread.Sleep(20);
            }
        }
    }
}
