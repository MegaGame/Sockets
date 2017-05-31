using System;
using System.Net.Sockets;
using System.Threading;

namespace SendeOgModtagesAfData
{
    public class SendReciveBytes
    {
        Socket handler;
        public event Action<byte[]> Recived;

        public SendReciveBytes(Socket socket)
        {
            handler = socket;
            new Thread(Listen).Start();
        }
        public void Send(byte[] msg)
        {
            handler.Send(msg);
        }
        public void Listen()
        {
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024]; //hvorfor 1024?                    
                    handler.Receive(bytes);
                    Recived(bytes);
                }
                catch (Exception)
                {
                }
            }

        }
    }
}
