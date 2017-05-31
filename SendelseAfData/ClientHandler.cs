using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SendeOgModtagesAfData
{
    public class ClientHandler
    {
        List<Bytes> clientList = new List<Bytes>();
        public event Action<Object> Recived;
        public bool clientToClientBroadcast;
        public bool clientToServerBroadcast;
        Socket handler;

        public ClientHandler(Socket Handler, bool ClientToClientBroadcast, bool ClientToServerBroadcast)
        {
            clientToClientBroadcast = ClientToClientBroadcast;
            clientToServerBroadcast = ClientToServerBroadcast;
            handler = Handler;
        }
        public void AcceptClientsSerialBytes()
        {
            while (true)
            {               
                SerialBytes sb = new SerialBytes(handler.Accept());
                AddClient(sb);
            }            
        }
        public void AcceptClientsJsonBytes()
        {
            while (true)
            {                
                JsonBytes jb = new JsonBytes(handler.Accept());
                AddClient(jb);
            }
        }
        public void AcceptClientsStringBytes()
        {
            while (true)
            {                
                StringBytes sb = new StringBytes(handler.Accept());
                AddClient(sb);
            }
        }

        public void AddClient(Bytes b)
        {
            if (clientToServerBroadcast == true)
            {
                try
                {
                    b.Recived += SendToServer;
                }
                catch (Exception)
                {
                }                
            }
            if (clientToClientBroadcast == true)
            {
                try
                {
                    b.Recived += SendToClient;
                }
                catch (Exception)
                {
                }
            }            
            clientList.Add(b);

        }
        public void SendToServer(Object o)
        {
            Recived(o);
        }
        public void SendToClient(Object o)
        {           
            foreach (var client in clientList)
            {
                client.Send(o);
            }
        }
    }
}
