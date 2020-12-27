﻿using System;
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
using School_Journal_App_VSProject.classes;
using School_Journal_App_VSProject.models;
using School_Journal_App_VSProject.pages;

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для BFormAuth.xaml
    /// </summary>
    public partial class BFormAuth : Page
    {
        private SQLController controller;

        public BFormAuth()
        {
            InitializeComponent();

            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            Login.Text = "admin";
            Password.Password = "admin";
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS
            //DELETE THIS


            controller = new SQLController();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length > 0 && Password.Password.Length > 0)
            {
                User user = SQLController.controller.GetUser(Login.Text);
                if (user.CheckPassword(Password.Password))
                {
                    App.CurrentUser = user;
                    WindowRouter.router.openPage(new JournalPage());
                }
                else
                {
                    Error.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
