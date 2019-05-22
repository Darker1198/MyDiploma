using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   public class MyActionButton
    {
         public Action Action { get; set; }
         private Button Parent { get; set; }
         

        public MyActionButton(Action action , Button parent)
        {
            Action = action;
            Parent = parent;
        }

        [Browsable(true)]
        [Description("Властивійсть: Назва дії")]
        [Category("Text params")]
        [DisplayName("Назва дії")]
        public String TextParam1
        {
            get { return Action.Name; }
            set
            {
                Action act = Action;
                Action.Name = value;
                ActionAdministrator.RedactAction(act, Action);
                Parent.Text = Action.Name;
            }
        }

        [Browsable(true)]
        [Description("Властивійсть: Тривалість дії")]
        [Category("Text params")]
        [DisplayName("Тривалість дії")]
        public int TextParam2
        {
            get { return Action.Duration; }
            set
            {
                Action act = Action;
                Action.Duration = value;
                ActionAdministrator.RedactAction(act, Action);
            }
        }

        [Browsable(true)]
        [Description("Властивійсть: Чи потрібен відгук дії")]
        [Category("Text params")]
        [DisplayName("Відгук ")]
        public bool TextParam3
        {
            get { return Action.NeedFeedback; }
            set
            {
                Action act = Action;
                Action.NeedFeedback = value;
                ActionAdministrator.RedactAction(act, Action);
            }
        }
    }
}
