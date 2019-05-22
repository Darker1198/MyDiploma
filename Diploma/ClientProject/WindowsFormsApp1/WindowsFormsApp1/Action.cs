using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Отображает свойства на панеле
namespace WindowsFormsApp1
{   [Serializable]
    public class Action
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private int _duration;
        public int Duration { get => _duration; set => _duration = value; }

        private bool _need_feddback;
        public bool NeedFeedback { get => _need_feddback; set => _need_feddback = value; }

       public Action(string name, int duration,bool need_feedback)
        {
            Name = name;
            Duration = duration;
            NeedFeedback = need_feedback;
        }
    }
}
