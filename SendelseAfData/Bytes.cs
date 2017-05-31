using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SendeOgModtagesAfData
{
    public class Bytes
    {
        public SendReciveBytes sr;
        public virtual event Action<Object> Recived;

        public Bytes()
        {
        }
        public virtual void Send(Object data)
        {
        }
        public void Listen()
        {
            try
            {
                sr.Recived += BytesToObject;
            }
            catch (Exception)
            {
            }
        }
        public virtual void BytesToObject(byte[] bytes)
        {           
        }
    }
}
