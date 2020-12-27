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
    /// Interaction logic for AddSubjectPage.xaml
    /// </summary>
    public partial class AddSubjectPage : Page
    {
        private SQLController controller;

        public AddSubjectPage()
        {
            InitializeComponent();

            controller = new SQLController();
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (TitleTxtBx.Text.Length < 1 || teacher_idTxtBx.Text.Length < 1 || GroupTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Fields can't be empty");
            }
            else
            if (regex.IsMatch(teacher_idTxtBx.Text) || teacher_idTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Invalid input in teacher id text field. Only numbers are allowed.");
            }
            else if (regex.IsMatch(GroupTxtBx.Text) || GroupTxtBx.Text.Length < 1)
            {
                MessageBox.Show("Invalid input in group id text field. Only numbers are allowed.");
            }
            else
            {
                controller.InsertSubject(TitleTxtBx.Text, int.Parse(teacher_idTxtBx.Text), int.Parse(GroupTxtBx.Text));
            }
        }
    }
}
