using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   static class FormAdministrator
    {

        public static  string CategoriesFolder = "Resourses/EventsCategories/";
        public static string SectionsFolder = "Resourses/Sections/";
        public static string PlansFolder = "Resourses/Plans/";
        private static string currentFolder;
        public static Form1 main { get; set; }
        public static string CurrentFolder { get => currentFolder; set => currentFolder = SectionsFolder+ value + "/"; }

        public static AddActionForm Addactionform()
        {
            return new AddActionForm();
        }
        public static SectionAdition Addsectionnform()
        {
            return new SectionAdition();
        }
    }
}
