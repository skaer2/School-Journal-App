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
        }

        public void addBlocks()
        {
            var pageSubject = new BSubjectsList();
            var journal = new BJournal();
            pageSubject.setOnClickListener((text) => {
                journal.setText(text);
            });
            framesAndBlocks.Add(new Tuple<Frame, Page>(SubjectsBlock, pageSubject));
            framesAndBlocks.Add(new Tuple<Frame, Page>(JournalBlock, journal));
        }
    }
}
