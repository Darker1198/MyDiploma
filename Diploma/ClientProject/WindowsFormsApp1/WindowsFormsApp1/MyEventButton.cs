using Plans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class MyEventButton
    {
        public Events Events { get; set; }
        private Button Parent { get; set; }


        public MyEventButton(Events events, Button parent)
        {
            Events = events;
            Parent = parent;
        }

        [Browsable(true)]
        [Description("Властивійсть: Назва дії")]
        [Category("Text params")]
        [DisplayName("Назва дії")]
        public String TextParam1
        {
            get { return Events.Name; }
            set
            {
                Events eve = Events;
                Events.Name = value;
                EventsAdministrator.RedactAction(eve, Events);
                Parent.Text = Events.Name;
            }
        }

        [Browsable(true)]
        [Description("Властивійсть: Тривалість дії")]
        [Category("Text params")]
        [DisplayName("Тривалість дії")]
        public int TextParam2
        {
            get { return Events.Duration; }
            set
            {
                Events eve = Events;
                Events.Duration = value;
                EventsAdministrator.RedactAction(eve, Events);
            }
        }

        [Browsable(true)]
        [Description("Властивійсть: Чи потрібен відгук дії")]
        [Category("Text params")]
        [DisplayName("Відгук ")]
        public bool TextParam3
        {
            get { return Events.NeedFeedback; }
            set
            {
                Events eve = Events;
                Events.NeedFeedback = value;
                EventsAdministrator.RedactAction(eve, Events);
            }
        }


        [Browsable(true)]
        [Description("Властивійсть: Година початку")]
        [Category("Time params")]
        [DisplayName("Година початку ")]
        public int StartHour
        {
            get { return Events.StartHour; }
            set
            {
                Events eve = Events;
                Events.StartHour = value;
                EventsAdministrator.RedactAction(eve, Events);
            }
        }

        [Browsable(true)]
        [Description("Властивійсть: Хвилини початку")]
        [Category("Time params")]
        [DisplayName("Хвилини початку ")]
        public int StartMinute
        {
            get { return Events.StartMinute; }
            set
            {
                Events eve = Events;
                Events.StartMinute = value;
                EventsAdministrator.RedactAction(eve, Events);
            }
        }
    }
}
