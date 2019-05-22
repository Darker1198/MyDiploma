using Plans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class EventsAdministrator
    {
        static List<Events> events = new List<Events>();

        public static void AddEvents(Events _events)
        {
            events.Add(_events);
            Save();
            Show();
        }

        public static void Show()
        {
            SortEvents();
            FormAdministrator.main.ShowEvents(events);
        }
        public static void RedactAction(Events oldevent, Events newevent)
        {
            int i = events.IndexOf(oldevent);
            events[i] = newevent;
            Save();
            Show();
        }

        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FormAdministrator.CurrentFolder + "events.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, events);
            }
        }

        public static void Load()
        {
            if (FormAdministrator.CurrentFolder != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(FormAdministrator.CurrentFolder + "events.bin", FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        List<Events> bufer = (List<Events>)formatter.Deserialize(fs);
                        events = bufer;
                    }
                    else { events.Clear(); }
                }
                Show();
            }
        }

        public static List<Events> GetEvents()
        {
            return events;
        }

        private static void SortEvents()
        {
            events = events.OrderBy(x => x.StartMinute).OrderBy(x => x.StartHour).ToList();
            Save();
        }
    }
}
