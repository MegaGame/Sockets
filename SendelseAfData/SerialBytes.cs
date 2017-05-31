using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SendeOgModtagesAfData
{
    public class SerialBytes : Bytes
    {
        
        public override event Action<Object> Recived;

        public SerialBytes(Socket handler)
        {
            sr = new SendReciveBytes(handler);
            new Thread(Listen).Start();
        }
        public override void Send(Object data)
        {
            byte[] msg = ObjectToByteArray(data);
            sr.Send(msg);
        }
        public override void BytesToObject(byte[] bytes)
        {
            Object dct = ByteArrayToObject(bytes);
            Recived(dct);
        }
        // Convert an object to a byte array
        private static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        // Convert a byte array to an Object
        private static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
