using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NP_Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = 
                new Socket(SocketType.Stream, ProtocolType.Tcp);

            server.Bind(
                new IPEndPoint(
                    new IPAddress(
                        new byte[] { 127, 0, 0, 1 }), 
                    3080));

            server.Listen(10);

            var client = server.Accept();
            byte[] buffer = new byte[10];
            StringBuilder globalBuffer = new StringBuilder();

            while (!client.Poll(1000, SelectMode.SelectRead)&&client.Connected)
            {
                var readed = client.Receive(buffer);
                for(int i = 0; i < readed; i++)
                {
                    if (buffer[i]==13)
                    {
                        client.Send(
                            Encoding.ASCII.GetBytes(
                                $"Recieved text: {globalBuffer.ToString()}"));
                        globalBuffer.Clear();
                    }
                    else
                    {
                        if (buffer[i] == 10) continue;
                        globalBuffer.Append(Convert.ToChar(buffer[i]));
                    }
                }
            }

        }
    }
}
