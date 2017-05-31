using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace SendeOgModtagesAfData
{
    public class JsonBytes
    {
        SendReciveBytes sr;
        public event Action<Object> Recived;

        public JsonBytes(Socket handler)
        {
            sr = new SendReciveBytes(handler);

            new Thread(Listen).Start();
        }
        public void Send(Object data)
        {            
            sr.Send(Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(data)));
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
        public void BytesToObject(byte[] bytes)
        {
            Recived(Newtonsoft.Json.JsonConvert.DeserializeObject<DataClassTrans>(Encoding.ASCII.GetString(bytes)));
        }
    }
}
