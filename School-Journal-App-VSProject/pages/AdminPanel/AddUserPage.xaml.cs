using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using School_Journal_App_VSProject.classes;

namespace School_Journal_App_VSProject.pages.AdminPanel
{
    /// <summary>
    /// Interaction logic for AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private SQLController controller;

        public AddUserPage()
        {
            InitializeComponent();

            controller = new SQLController();
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (FirstnameTxtBx.Text.Length < 1 || LastnameTxtBx.Text.Length < 1 || GroupTxtBx.Text.Length < 1 || EmailTxtBx.Text.Length < 1 || LoginTxtBx.Text.Length < 1 || PasswordTxtBx.Text.Length < 1 || RoleTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Fields can't be empty");
            }else
            if (regex.IsMatch(GroupTxtBx.Text) || GroupTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Invalid input in group text field. Only numbers are allowed.");
            }else if (regex.IsMatch(RoleTxtBx.Text) || RoleTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Invalid input in role text field. Only numbers are allowed.");
            }
            else
            {
                controller.InsertUser(FirstnameTxtBx.Text, LastnameTxtBx.Text, int.Parse(GroupTxtBx.Text), EmailTxtBx.Text, LoginTxtBx.Text, PasswordTxtBx.Text, int.Parse(RoleTxtBx.Text));
            }


        }
    }
}
