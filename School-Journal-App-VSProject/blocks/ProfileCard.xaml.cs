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

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для ProfileCard.xaml
    /// </summary>
    public partial class ProfileCard : Page
    {
        public ProfileCard()
        {
            InitializeComponent();

            if (App.CurrentUser.role == 0)
                AdminPanel.Visibility = Visibility.Visible;

            if (App.CurrentUser != null) 
            {
                NameUser.Content = App.CurrentUser.name.Item1 + " " + App.CurrentUser.name.Item2 + " " + App.CurrentUser.name.Item3;
            }
        }
    }
}