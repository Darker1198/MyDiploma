using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   static class SectionAdministrator
    {
        static List<Section> sections = new List<Section>();

        public static void AddSection(Section section)
        {
            sections.Add(section);
            Show();
        }

        public static void Show()
        {
            FormAdministrator.main.ShowSections(sections);
        }

        public static void Load ()
        {
            string directory = FormAdministrator.SectionsFolder;
            string[] a = Directory.GetDirectories(directory);

            foreach(string  b in a)
            {
                // int n = b.IndexOf(FormAdministrator.SectionsFolder);
                // string c = b.Remove(n, FormAdministrator.SectionsFolder.Length);
                // Section bufer = new Section(c);
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(b + "/section.bin", FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        Section bufer = (Section)formatter.Deserialize(fs);
                        AddSection(bufer);
                    }
                    else { }
                }
               
            }         
            Show();
        }
    }
}
