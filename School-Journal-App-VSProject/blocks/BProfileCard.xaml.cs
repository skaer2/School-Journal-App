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
using System.Windows.Navigation;
using System.Windows.Shapes;

using School_Journal_App_VSProject.models;
using School_Journal_App_VSProject.pages;
using classes;

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для ProfileCard.xaml
    /// </summary>
    public partial class BProfileCard : Page
    {
        public BProfileCard(User user, bool showSettings = true)
        {
            InitializeComponent();

            if (user.role == 0)
            {
                AdminPanel.Visibility = Visibility.Visible;
                UserGroup.Content = "Администратор";
            }
            if (user.role == 1) 
            {
                UserGroup.Content = "Преподаватель";
            }
            if (user.role == 2)
            {
                var buf = SQLController.controller.getGroups(user.groupId);
                if (buf.Count > 0)
                {
                    Group group = buf[0];
                    UserGroup.Content = "Студент, " + group.Title;
                }
                else UserGroup.Content = "Студент, нет группы";


            }

            if (user != null) 
            {
                NameUser.Content = user.name.Item1 + " " + user.name.Item2 + " " + user.name.Item3;
            }

            if (showSettings)
            {
                SettingUser.Visibility = Visibility.Visible;
            }else SettingUser.Visibility = Visibility.Hidden;
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            WindowRouter.router.openPage(new AdminPanelClass());
        }
    }
}
