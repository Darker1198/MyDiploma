using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Section
    {
        private string _name;
        private string _teleganame;
        private string _destination;
        public string Name { get => _name; set => _name = value; }
        public string TelegaName { get => _teleganame; set => _teleganame = value; }
        public string Destination { get => _destination; set => _destination = value; }
        

        public Section(string name,string teleganame,string destination)
        {
            Name = name;
            TelegaName = teleganame;
            Destination = destination;
        }
    }
}
