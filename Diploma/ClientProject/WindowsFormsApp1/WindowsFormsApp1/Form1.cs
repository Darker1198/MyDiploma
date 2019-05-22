using Plans;
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
    public partial class Form1 : Form
    {
        public List<Button> Actions = new List<Button>();
        public List<TabPage> Sections = new List<TabPage>();
        public List<Button> Eventses = new List<Button>();
        public Button Example = null;

        public Form1()
        {
            InitializeComponent();
            FormAdministrator.main = this;
            SectionAdministrator.Load();
            if(SectionBox.TabPages.Count != 0)
            {
                FormAdministrator.CurrentFolder = SectionBox.TabPages[0].Text;
            }           
            ActionAdministrator.Load();
            EventsAdministrator.Load();
        }

        private void додатиДіюToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        public void ShowActions(List<Action> actions)
        {
            ActionPanel.Controls.Clear();
            Actions.Clear();
            actions.ForEach(x =>
            {
                Button button = new Button();
                button.Tag = new MyActionButton(x, button);
                button.Height = 50;
                button.Left = 20;
                button.Top = actions.IndexOf(x) * 50 + 10;
                button.Text = x.Name;
                button.Width = 200;
                button.BackColor = Color.LightGray;
                button.Click += ActionEvents.ShowProperties;
                button.MouseDown += ActionMouseDown;
                button.MouseUp += ActionMouseUp;
                //button.ContextMenu = ContextMyMenu.GetContextItemMenu(button);
                Actions.Add(button);
                ActionPanel.Controls.Add(button);
            });

        }

        public void ShowSections(List<Section> sections)
        {
            SectionBox.TabPages.Clear();
            Sections.Clear();
            sections.ForEach(x =>
            {
                TabPage tabpage = new TabPage(x.Name);
                tabpage.AutoScroll = true;
                tabpage.AllowDrop = true;
                tabpage.UseVisualStyleBackColor = true;
                tabpage.Tag = x;
                Panel panel = new Panel();
                panel.Width = 40;
                panel.Top = 0;
                panel.Left = 813;
                panel.Visible = true;
                panel.ForeColor = Color.Black;
                panel.Paint += Drawer.DrawTimeLine;

                tabpage.Controls.Add(panel);
                panel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                Sections.Add(tabpage);
                SectionBox.TabPages.Add(tabpage);
            });

            if (SectionBox.TabPages.Count != 0)
            {
                FormAdministrator.CurrentFolder = SectionBox.SelectedTab.Text;
            }
            

        }

        private void додатиПідрозділToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdministrator.Addsectionnform().Show();
        }

        public void ShowProperties(object sender)
        {
            propertyGrid1.SelectedObject = sender;
        }

        int Xras = 0;
        int Yras = 0;


        private void ActionMouseDown(object sender, MouseEventArgs e)
        {
            Example = (sender as Button);
            int ras = (sender as Button).Top;
            Xras = e.Location.X;
            Yras = (sender as Button).Top;
        }

        private void ActionMouseUp(object sender, MouseEventArgs e)
        {
            int a = 0;
            if (Example != null && e.Location.X>200)
            {
                Button bufer = (sender as Button);
                object buff = bufer.Tag;
                MyActionButton tag = buff as MyActionButton;             
                int Top = (((e.Location.Y + Yras - 30) / 30) * 30 + 5) + SectionBox.TabPages[a].VerticalScroll.Value;
                int duration = tag.Action.Duration;
                int starthour = hours[(Top / 30) / 12];
                int startminute = minute[(Top / 30) % 12];
                int endhour = starthour + (startminute + duration) / 60;
                int endminute = (startminute + duration) % 60;
                Events eve = new Events(Example.Text,duration,tag.Action.NeedFeedback,starthour,startminute,endhour,endminute);
                EventsAdministrator.AddEvents(eve);
            }
            Example = null;
            Xras = 0;
            Yras = 0;
        }

        int[] hours = { 19, 20, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
        int[] minute = { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };

        public void ShowEvents(List<Events> events)
        {
            int a = SectionBox.SelectedIndex;
           if(a != -1)
          { 
            TabPage current = SectionBox.TabPages[a];
            int value = current.VerticalScroll.Value;

          //  SectionAdministrator.Show();
            current = SectionBox.TabPages[a];
            Eventses.Clear();
                int cur = 0;
                for (int i = 0; i < current.Controls.Count -1;i++)
                {
                    if (!(current.Controls[cur]  is Button))
                    {
                        cur++;
                    }
                 current.Controls.RemoveAt(cur);
            }
                current.VerticalScroll.Minimum = 0;
                current.VerticalScroll.Maximum = 8640;
                current.VerticalScroll.Value = 0;
            events.ForEach(x =>
            {
                Button button = new Button();
                button.Tag = new MyEventButton(x, button);
                button.Height = (x.Duration / 5) * 30;
                button.Left = 0;
                button.Top = hours.ToList().IndexOf(x.StartHour) * 12 * 30 + minute.ToList().IndexOf(x.StartMinute) * 30 + 5;
                button.Text = x.Name;
                button.Width = SectionBox.TabPages[a].Width - 40;
                button.BackColor = Color.LightGray;
                button.Click += ActionEvents.ShowProperties;
                /*button.MouseDown += ActionMouseDown;
                 button.MouseUp += ActionMouseUp;*/
                //button.ContextMenu = ContextMyMenu.GetContextItemMenu(button);
                Eventses.Add(button);
                current.Controls.Add(button);
            });
            SectionBox.SelectedIndex = a;
            current = SectionBox.TabPages[a];
            current.VerticalScroll.Value = value;
           }
        }

        private void свояДіяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdministrator.Addactionform().Show();
        }

        private void курсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FormAdministrator.CategoriesFolder + "kurs.bin", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<Action> bufer = (List<Action>)formatter.Deserialize(fs);
                    foreach(Action a in bufer)
                    {
                        ActionAdministrator.AddAction(a);
                    }
                }
            }
            
        }

        private void SectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionBox.SelectedIndex != -1)
            {
                FormAdministrator.CurrentFolder = SectionBox.SelectedTab.Text;
                ActionAdministrator.Load();
                EventsAdministrator.Load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a  = SectionBox.SelectedIndex;
            Plan plan = new Plan((Sections[a].Tag as Section).Name, (Sections[a].Tag as Section).TelegaName, (Sections[a].Tag as Section).Destination, EventsAdministrator.GetEvents());
            PlanAdministrator.SendPlan(plan);
        }

        private void черговийІнститутуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FormAdministrator.CategoriesFolder + "cherg.bin", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<Action> bufer = (List<Action>)formatter.Deserialize(fs);
                    foreach (Action a in bufer)
                    {
                        ActionAdministrator.AddAction(a);
                    }
                }
            }
        }
    }
}
