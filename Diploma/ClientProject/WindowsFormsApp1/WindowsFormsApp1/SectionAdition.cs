using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SectionAdition : Form
    {
        public SectionAdition()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Section section = new Section(textBox1.Text, textBox2.Text,textBox3.Text);
            SectionAdministrator.AddSection(section);
            Directory.CreateDirectory(FormAdministrator.SectionsFolder+section.Name);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FormAdministrator.SectionsFolder + section.Name + "/section.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, section);
            }
            this.Close();
        }
    }
}
