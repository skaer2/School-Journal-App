using classes;
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

namespace School_Journal_App_VSProject.pages.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelPage.xaml
    /// </summary>
    public partial class AdminPanelPage : Page
    {
        private int role = 2;
        private List<Group> groups = new List<Group>();
        private List<User> teachers = new List<User>();
        public AdminPanelPage()
        {
            InitializeComponent();

            reloadGroup();
            reloadTeachers();
        }

        private void reloadGroup() {
            groups = SQLController.controller.getGroups();
            GroupTxtBx.Items.Clear();

            foreach (var group in groups)
            {
                GroupTxtBx.Items.Add(group.Title);
                GroupsForSbject.Items.Add(group.Title);
            }
        }

        private void reloadTeachers()
        {
            teachers = SQLController.controller.getUsersWithRole(1);
            Teachers.Items.Clear();

            foreach (var teacher in teachers)
            {
                Teachers.Items.Add(teacher.name.Item2 + " " + teacher.name.Item1 + " " + teacher.name.Item3);
            }
        }

        private void AddUserBtnClick(object sender, RoutedEventArgs e)
        {
            if (FirstnameTxtBx.Text.Length < 1 || LastnameTxtBx.Text.Length < 1 || GroupTxtBx.SelectedIndex == -1 || EmailTxtBx.Text.Length < 1 || LoginTxtBx.Text.Length < 1 || PasswordTxtBx.Text.Length < 1)
            {
                ResponseAddUser.Content = "Поля не могут быть пустыми";
                ResponseAddUser.Foreground = Brushes.IndianRed;
                ResponseAddUser.Visibility = Visibility.Visible;
            }
            else
            {
                int group = groups[GroupTxtBx.SelectedIndex].Id;
                SQLController.controller.InsertUser(FirstnameTxtBx.Text, LastnameTxtBx.Text, MiddlenameTxtBx.Text, group, EmailTxtBx.Text, LoginTxtBx.Text, PasswordTxtBx.Text, role);
                ResponseAddUser.Content = "Пользователь успешно добавлен";
                ResponseAddUser.Foreground = Brushes.LightGreen;
                ResponseAddUser.Visibility = Visibility.Visible;

                FirstnameTxtBx.Text = "";
                LastnameTxtBx.Text = "";
                MiddlenameTxtBx.Text = "";
                EmailTxtBx.Text = "";
                LoginTxtBx.Text = "";
                PasswordTxtBx.Text = "";
                GroupTxtBx.SelectedIndex = -1;
            }    
        }

        private void AddGroupBtnClick(object sender, RoutedEventArgs e)
        {
            if (TitleTxtBx.Text.Length < 1)
            {
                ResponceAddGroup.Content = "Поля не могут быть пустыми";
                ResponceAddGroup.Foreground = Brushes.IndianRed;
                ResponceAddGroup.Visibility = Visibility.Visible;
            }
            else
            {
                SQLController.controller.InsertGroup(TitleTxtBx.Text);
                ResponceAddGroup.Content = "Группа успешно добавлена";
                ResponceAddGroup.Foreground = Brushes.LightGreen;
                ResponceAddGroup.Visibility = Visibility.Visible;

                TitleTxtBx.Text = "";

                reloadGroup();
            }
        }

        private void AddSbjBtnClick(object sender, RoutedEventArgs e)
        {
            if (TitleTxtBxSbj.Text.Length < 1 || Teachers.SelectedIndex == -1 || GroupsForSbject.SelectedIndex == -1)
            {
                ResponceAddSbj.Content = "Поля не могут быть пустыми";
                ResponceAddSbj.Foreground = Brushes.IndianRed;
                ResponceAddSbj.Visibility = Visibility.Visible;
            }
            else
            {
                string teacherId = teachers[Teachers.SelectedIndex].login;
                int group = groups[GroupsForSbject.SelectedIndex].Id;

                SQLController.controller.InsertSubject(TitleTxtBxSbj.Text, teacherId, group);
                ResponceAddSbj.Content = "Предмет успешно добавлен";
                ResponceAddSbj.Foreground = Brushes.LightGreen;
                ResponceAddSbj.Visibility = Visibility.Visible;

                TitleTxtBxSbj.Text = "";
                Teachers.SelectedIndex = -1;
                GroupsForSbject.SelectedIndex = -1;
            }
        }

        private void RoleChecked(object sender, RoutedEventArgs e)
        {
            role = int.Parse((sender as RadioButton).Tag as string);
            if (role != 2)
            {
                GroupLbl.Visibility = Visibility.Hidden;
                GroupTxtBx.Visibility = Visibility.Hidden;
                GroupTxtBx.SelectedIndex = -1;
            }
            else
            {
                GroupLbl.Visibility = Visibility.Visible;
                GroupTxtBx.Visibility = Visibility.Visible;
            }
        }
    }
}
