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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, IWindowFragment
    {
        public List<Tuple<Frame, Page>> framesAndBlocks { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            framesAndBlocks = new List<Tuple<Frame, Page>>();
            addBlocks();

            TextTitle.Content = App.appTitle;

            this.loadBlocks(framesAndBlocks);
        }

        public void addBlocks()
        {
            framesAndBlocks.Add(new Tuple<Frame, Page>(AuthBlock, new BFormAuth()));
        }
    }
}
