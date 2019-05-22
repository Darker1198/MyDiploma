using Plans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TelegaBot
{
    static class PlanAdministrator
    {
        static string DestinationFolder = "Plans/";

        public static Plan Load(string Folder)
        {
            Plan plan = new Plan();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Folder, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    Plan bufer = (Plan)formatter.Deserialize(fs);
                    plan = bufer;
                }           
            }
 
            return plan;
        }

        public static List<ReadyPlan> LoadAll()
        {
            List<ReadyPlan> readyplan = new List<ReadyPlan>();
            List<Plan> plans = new List<Plan>();
           string[] a =  Directory.GetFiles(DestinationFolder);
            int i = 0;
            foreach (string b in a )
            {
                plans.Add(Load(b));
            }

            foreach ( Plan b in plans)
            {
                readyplan.Add(new ReadyPlan(b));
            }
            return readyplan;
        }
    }
}
