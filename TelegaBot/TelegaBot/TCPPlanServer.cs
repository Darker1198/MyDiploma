using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelegaBot
{
    static class TCPPlanServer
    {
        static string Folder = "Plans/";
        public static  void Waiting()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] data = new byte[256];

                string filename;
                int bytes = stream.Read(data, 0, data.Length);
                filename = Encoding.UTF8.GetString(data, 0, bytes);
                stream.Flush();

                stream = client.GetStream();
                long size;
                bytes = stream.Read(data, 0, data.Length);
                size = long.Parse(Encoding.UTF8.GetString(data, 0, bytes));
                stream.Flush();

                List<byte> bufer = new List<byte>();

                int i = 0;

                do
                {
                    byte[] datas = new byte[100];
                    bytes = stream.Read(datas, 0, datas.Length);
                    foreach (byte a in datas)
                    {
                        bufer.Add(a);
                    }
                    if (bytes < 100)
                        break;
                    i += 100;
                } while (i < size);

                var mem = new MemoryStream();
                mem.Write(bufer.ToArray(), 0, bufer.Count);
                using (FileStream fs = new FileStream(Folder + filename, FileMode.OpenOrCreate))
                {
                    fs.Write(mem.GetBuffer(), 0, mem.GetBuffer().Length);
                }
                client.Close();
                Program.plans =  PlanAdministrator.LoadAll();
            }
            server.Stop();

        }
    }
}
