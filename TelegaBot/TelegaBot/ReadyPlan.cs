using Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegaBot
{
    public class ReadyPlan
    {
        private Plan _plan;
        private int _lastIndex;

        public Plan Plan { get => _plan; set => _plan = value; }
        public   int LastIndex { get => _lastIndex; set { _lastIndex = value; } }
        public int Last {
            get { if (LastIndex != 0)
                {
                    return LastIndex - 1;
                }
                else
                {
                    return this.Plan.Events.Count - 1;
                }
            }
            set { }
        }

       public  ReadyPlan(Plan plan)
        {
            Plan = plan;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            List<Events> Hours = Plan.Events.ToList();

            List<Events> ThisHours = Plan.Events.Where(x=>x.StartHour == hour).ToList();
            List<Events> MoreHours = Plan.Events.Where(x => x.StartHour > hour).ToList();

            if (ThisHours.Count() != 0)
            {
                List<Events> Minutes = ThisHours.Where(x => x.StartMinute > minute).ToList();
                if (Minutes.Count() != 0)
                {
                    LastIndex = Hours.IndexOf(Minutes.First());
                }
                else
                {
                    LastIndex = Hours.IndexOf(ThisHours.Last()) + 1;
                }
            }
            else if (MoreHours.Count() != 0)
            {
                LastIndex = Hours.IndexOf(MoreHours.First());
            }
            else LastIndex = 0;
           
           
            Console.WriteLine();
        }
        public void Next()
        {
            LastIndex++;
            if (LastIndex >= Plan.Events.Count)
            {
                LastIndex = 0;
            }                    
        }
    }
}
