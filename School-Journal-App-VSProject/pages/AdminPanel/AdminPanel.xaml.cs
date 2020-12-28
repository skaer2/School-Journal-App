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
using School_Journal_App_VSProject.models;
using School_Journal_App_VSProject.pages;

namespace School_Journal_App_VSProject.pages
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanelClass : Page
    {
        public AdminPanelClass()
        {
            InitializeComponent();
            AdminPanelFrame.Navigate(new AdminPanel.AdminPanelPage());
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            WindowRouter.router.openPage(new JournalPage());
        }
    }
}
