using Plans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   static  class PlanAdministrator
    {

       static string Folder = FormAdministrator.PlansFolder;

       public static void SendPlan(Plan plan)
       {
            BinaryFormatter formatter = new BinaryFormatter();
            string name = plan.Name + ".bin";
            using (FileStream fs = new FileStream(Folder + name, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, plan);
            }

         
            SendP(name);
       }

        static async void SendP(string Name)
        {
            await Task.Run(() => Send(Name));
        }


        static void Send(string Name)
        {
            TcpClient tcpClient = new TcpClient();
            //"192.168.43.13"
            //"127.0.0.1"
            tcpClient.Connect("127.0.0.1", 8888);

            NetworkStream netStream = tcpClient.GetStream();
            //string response = Console.ReadLine();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(Name);
            netStream.Write(data, 0, data.Length);
            Thread.Sleep(700);

            using (FileStream fs = new FileStream(Folder+Name, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    var mem = new MemoryStream();
                    fs.CopyTo(mem);
                    byte[] data1 = mem.GetBuffer();
                    data = Encoding.UTF8.GetBytes(data1.Length.ToString());
                    netStream.Write(data, 0, data.Length);
                    Thread.Sleep(700);
                    // fs.Write(data1, 0, data1.Length);
                    int i = 0;
                    do
                    {
                        int size = 100;
                        if (size > data1.Length - i)
                        {
                            size = data1.Length - i;
                        }
                        netStream.Write(data1, i, size);
                        Thread.Sleep(700);
                        i += 100;
                    } while (i < data1.Length);
                }
            }

            tcpClient.Close();
        }
    }
}
