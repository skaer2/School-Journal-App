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
using System.Windows.Navigation;
using System.Windows.Shapes;

using interfaces;
using School_Journal_App_VSProject.blocks;
using School_Journal_App_VSProject.classes;

namespace School_Journal_App_VSProject.pages
{
    /// <summary>
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page, IWindowFragment
    {
        public List<Tuple<Frame, Page>> framesAndBlocks { get; set; }

        public JournalPage()
        {
            InitializeComponent();

            framesAndBlocks = new List<Tuple<Frame, Page>>();
            addBlocks();

            this.loadBlocks(framesAndBlocks);

            if (App.CurrentUser.role == 2) {
                Groups.Height = new GridLength(0, GridUnitType.Pixel);
                List.Height = new GridLength(6, GridUnitType.Star);
            }
            
        }

        public void addBlocks()
        {
            framesAndBlocks.Add(new Tuple<Frame, Page>(ProfileBlock, new BProfileCard(App.CurrentUser)));

            var groups = new BGroupsList();
            var pageSubject = new BSubjectsList();
            var journal = new BJournal();

            groups.SetOnSelectedListener((group) => {
                pageSubject.Reload(group);
            });
            
            pageSubject.setOnSelectedListener((subject, id, isAdd) => {
                journal.UpdateJournal(subject, id, isAdd);
            });

            framesAndBlocks.Add(new Tuple<Frame, Page>(GroupsBlock, groups));
            framesAndBlocks.Add(new Tuple<Frame, Page>(SubjectsBlock, pageSubject));
            framesAndBlocks.Add(new Tuple<Frame, Page>(JournalBlock, journal));
        }
    }
}
