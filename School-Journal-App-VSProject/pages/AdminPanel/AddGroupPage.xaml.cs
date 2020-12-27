using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using School_Journal_App_VSProject.classes;
namespace School_Journal_App_VSProject.pages.AdminPanel
{
    /// <summary>
    /// Interaction logic for AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        private SQLController controller;

        public AddGroupPage()
        {
            InitializeComponent();

            controller = new SQLController();
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (TitleTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Fields can't be empty");
            }
            else
            {
                controller.InsertGroup(TitleTxtBx.Text);
            }
        }
    }
}
