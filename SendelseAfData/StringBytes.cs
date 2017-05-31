using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SendeOgModtagesAfData
{
    public class StringBytes
    {
        SendReciveBytes sr;
        public event Action<string> Recived;

        public StringBytes(Socket handler)
        {
            sr = new SendReciveBytes(handler);
            new Thread(Listen).Start();
        }
        public void Send(String data)
        {
            byte[] msg = Encoding.ASCII.GetBytes(data);
            sr.Send(msg);
        }
        public void Listen()
        {
            try
            {
                sr.Recived += BytesToString;
            }
            catch (Exception)
            {
            }
        }
        public void BytesToString(byte[] bytes)
        {
            String data = Encoding.ASCII.GetString(bytes);
            Recived(data);
        }
    }
}
