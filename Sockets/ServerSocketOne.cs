using System.Net;
using System.Net.Sockets;

namespace Sockets
{
    public class ServerSocketOne
    {
        public Socket StartHost()
        {
            Socket connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);            
            connector.Bind(new IPEndPoint(IPAddress.Any, 11000)); 
            connector.Listen(10); //vil det virke med 1 eller 0?
            return connector.Accept();
        }
        public Socket StartHost(int port) //OVERLOAD
        {
            Socket connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //denne linje og næstes parameter være dynamisk i en overload.            
            connector.Bind(new IPEndPoint(IPAddress.Any, port));
            connector.Listen(10);
            return connector.Accept();
        }
    }
}
