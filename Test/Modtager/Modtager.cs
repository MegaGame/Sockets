using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sockets;
using System.Threading;
using System.Net.Sockets;
using SendeOgModtagesAfData;

namespace Modtager
{
    class Modtager
    {
        static void Main(string[] args)
        {
            Modtager m = new Modtager();
            new Thread(m.Run).Start();
        }
        public void Run()
        {
            JsonTest3();
        }
        public void JsonTest3()
        {
            List<JsonBytes> listJB = new List<JsonBytes>();
            ServerSocketListen ssl = new ServerSocketListen();
            Socket s = ssl.StartHost();
            for (int i = 0; i < 3; i++)
            {
                JsonBytes jb = new JsonBytes(s.Accept());
                try
                {
                    jb.Recived += PrintObject;
                }
                catch (Exception)
                {
                }
                listJB.Add(jb);
            }
            foreach (var item in listJB)
            {
                DataClassTrans d1 = new DataClassTrans("server1");
                item.Send(d1);
            }
        }
        public void JsonTest2()
        {
            List<JsonBytes> listJB = new List<JsonBytes>();
            ServerSocketListen ssl = new ServerSocketListen();
            Socket s = ssl.StartHost();
            while (true)
            {
                JsonBytes jb = new JsonBytes(s.Accept());
                try
                {
                    jb.Recived += PrintObject;
                }
                catch (Exception)
                {
                }
                listJB.Add(jb);
            }

        }
        public void JsonTest1()
        {
            ServerSocketListen ssl = new ServerSocketListen();
            Socket s = ssl.StartHost();
            JsonBytes jb = new JsonBytes(s.Accept());
            try
            {
                jb.Recived += PrintObject;
            }
            catch (Exception)
            {
            }
        }
        public void SerialTest()
        {
            ServerSocketOne sso = new ServerSocketOne();
            Socket s = sso.StartHost();
            SerialBytes sb = new SerialBytes(s);
            try
            {
                sb.Recived += PrintObject;
            }
            catch (Exception)
            {
            }
        }
        public void PrintObject(Object s)
        {
            DataClassTrans dct = (DataClassTrans)s;
            Console.WriteLine(dct.data);
        }
        public void PrintString(string s)
        {
            Console.WriteLine(s);
        }

        public void JsonTest()
        {
            ServerSocketOne sso = new ServerSocketOne();
            Socket s = sso.StartHost();
            JsonBytes jb = new JsonBytes(s);
            try
            {
                jb.Recived += PrintObject;
            }
            catch (Exception)
            {
            }
        }
        public void StringTest()
        {
            ServerSocketOne sso = new ServerSocketOne();
            Socket s = sso.StartHost();
            StringBytes sb = new StringBytes(s);
            try
            {
                sb.Recived += PrintString;
            }
            catch (Exception)
            {
            }

        }
    }
}
