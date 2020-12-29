using classes;
using interfaces;
using School_Journal_App_VSProject.blocks;
using School_Journal_App_VSProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace School_Journal_App_VSProject.pages
{
    /// <summary>
    /// Interaction logic for WSubjectInfo.xaml
    /// </summary>
    public partial class WSubjectInfo : Window, IWindowFragment
    {
        private int subject;

        public List<Tuple<Frame, Page>> framesAndBlocks { get; set; }

        public WSubjectInfo(int subject)
        {
            InitializeComponent();

            this.subject = subject;

            framesAndBlocks = new List<Tuple<Frame, Page>>();
            addBlocks();

            this.loadBlocks(framesAndBlocks);
        }

        public void addBlocks()
        {
            string teacherLogin = SQLController.controller.getTeacherBySubject(subject);
            User user = SQLController.controller.GetUser(teacherLogin);
            if (user.name != null)
            {
                framesAndBlocks.Add(new Tuple<Frame, Page>(ProfileCardFrame, new BProfileCard(user, false, false)));
            }
            else Console.WriteLine("Teacher was not found in database");

            framesAndBlocks.Add(new Tuple<Frame, Page>(ChartFrame, new BStatisticsChart(subject)));
        }
    }
}
