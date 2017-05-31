using System.Net;
using System.Net.Sockets;
namespace Sockets
{
    public class ServerSocketListen
    {
        public Socket StartHost()
        {
            Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            host.Bind(new IPEndPoint(IPAddress.Any, 11000)); 
            host.Listen(10); //vil det virke med 1 eller 0?
            return host;
        }
        public Socket StartHost(int port) //OVERLOAD
        {
            Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //denne linje og næstes parameter være dynamisk i en overload.
            host.Bind(new IPEndPoint(IPAddress.Any, port));
            host.Listen(10);
            return host;
        }
    }
}
