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

using classes;

namespace WpfApp1.page
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        private WindowFragment wf;

        public Auth()
        {
            InitializeComponent();

            wf = new WindowFragment();

            wf.addFrameBlock(profileBlock, new blocks.Page1());
            wf.loadBlocks();
        }

        
    }
}
