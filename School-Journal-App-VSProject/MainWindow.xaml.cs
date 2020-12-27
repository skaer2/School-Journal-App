using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using School_Journal_App_VSProject.classes;
using School_Journal_App_VSProject.models;
using School_Journal_App_VSProject.pages;

namespace School_Journal_App_VSProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowRouter.router.setFrame(MainFrame);

            WindowRouter.router.openPage(new LoginPage());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
