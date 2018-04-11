using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public delegate void ClientCallable(Socket socket);
    public class Client
    {
        private Socket socket;
        public Client(byte[] ip, int port)
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new (new IPAddress(ip)),port);
        }
        public void Write(string Connection)
        {

        }
        public void Call(ClientCallable callable)
        {
            callable(socket);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
