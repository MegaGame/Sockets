using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SendeOgModtagesAfData
{
    public class StringBytes : Bytes
    {
        public override event Action<Object> Recived;

        public StringBytes(Socket handler)
        {
            sr = new SendReciveBytes(handler);
            new Thread(Listen).Start();
        }
        public override void Send(Object data)
        {
            string s = (string)data;
            byte[] msg = Encoding.ASCII.GetBytes(s);
            sr.Send(msg);
        }
        public override void BytesToObject(byte[] bytes)
        {
            Object data = Encoding.ASCII.GetString(bytes);            
            Recived(data); //HUSK string s = (string)data HVOR data modtages
        }
    }
}
