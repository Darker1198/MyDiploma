using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//Управление Action
namespace WindowsFormsApp1
{
    static class ActionAdministrator
    {
        static List<Action> actions = new List<Action>();


        public static void AddAction(Action action)
        {
            actions.Add(action);
            Save();
            Show();
        }

        public static void Show()
        {
            FormAdministrator.main.ShowActions(actions);
        }

        public static void RedactAction(Action oldaction, Action newaction)
        {
            int i = actions.IndexOf(oldaction);
            actions[i] = newaction;
            Save();
            Show();
        }

        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FormAdministrator.CurrentFolder + "actions.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, actions);
            }
        }

        public static void Load()
        {
            if (FormAdministrator.CurrentFolder != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(FormAdministrator.CurrentFolder + "actions.bin", FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        List<Action> bufer = (List<Action>)formatter.Deserialize(fs);
                        actions = bufer;
                    }
                    else { actions.Clear(); }
                }
                Show();
            }
           
        }
    }
}
