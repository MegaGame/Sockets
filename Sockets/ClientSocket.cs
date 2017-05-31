using System.Net;
using System.Net.Sockets;

namespace Sockets
{
    public class ClientSocket
    {
        public Socket ConnectToServer()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            Socket connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connector.Connect(remoteEP); //test med new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000)
            return connector;
        }
        public Socket ConnectToServer(string ip, int port)
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connector.Connect(remoteEP); // test med handler hele vejen istedet for connector
            return connector;
        }
    }
}
