using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sockets;
using System.Threading;
using System.Net.Sockets;
using SendeOgModtagesAfData;

namespace Sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            Sender s = new Sender();
            new Thread(s.Run).Start();
        }
        public void Run()
        {
            JsonTest3();
        }
        public void JsonTest3()
        {
            ClientSocket cs = new ClientSocket();
            Socket s = cs.ConnectToServer();
            JsonBytes jb = new JsonBytes(s);
            try
            {
                jb.Recived += PrintObject;
            }
            catch (Exception)
            {
            }
            DataClassTrans d1 = new DataClassTrans("test1");
            DataClassTrans d2 = new DataClassTrans("test2");
            DataClassTrans d3 = new DataClassTrans("test3");
            DataClassTrans d4 = new DataClassTrans("test4");
            jb.Send(d1);
            Thread.Sleep(50);
            jb.Send(d2);
            Thread.Sleep(50);
            jb.Send(d3);
            Thread.Sleep(50);
            jb.Send(d4);
        }
        public void PrintObject(Object s)
        {
            DataClassTrans dct = (DataClassTrans)s;
            Console.WriteLine(dct.data);
        }
        public void SerialTest()
        {
            ClientSocket cs = new ClientSocket();
            Socket s = cs.ConnectToServer();
            SerialBytes jb = new SerialBytes(s);
            DataClassTrans d1 = new DataClassTrans("test1");
            DataClassTrans d2 = new DataClassTrans("test2");
            DataClassTrans d3 = new DataClassTrans("test3");
            DataClassTrans d4 = new DataClassTrans("test4");
            jb.Send(d1);
            Thread.Sleep(50);
            jb.Send(d2);
            Thread.Sleep(50);
            jb.Send(d3);
            Thread.Sleep(50);
            jb.Send(d4);
        }
        public void JsonTest()
        {
            ClientSocket cs = new ClientSocket();
            Socket s = cs.ConnectToServer();
            JsonBytes jb = new JsonBytes(s);
            DataClassTrans d1 = new DataClassTrans("test1");
            DataClassTrans d2 = new DataClassTrans("test2");
            DataClassTrans d3 = new DataClassTrans("test3");
            DataClassTrans d4 = new DataClassTrans("test4");
            jb.Send(d1);
            Thread.Sleep(50);
            jb.Send(d2);
            Thread.Sleep(50);
            jb.Send(d3);
            Thread.Sleep(50);
            jb.Send(d4);
        }
        public void StringTest()
        {
            ClientSocket cs = new ClientSocket();
            Socket s = cs.ConnectToServer();
            StringBytes sb = new StringBytes(s);
            sb.Send("test1");
            Thread.Sleep(50);
            sb.Send("test2");
            Thread.Sleep(50);
            sb.Send("test3");
            Thread.Sleep(50);
            sb.Send("test4");
        }
    }
}
