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
    /// Логика взаимодействия для BJournal.xaml
    /// </summary>
    public partial class BJournal : Page
    {
        

        public BJournal()
        {
            InitializeComponent();
        }

        public void setText(string text) 
        {
            Text.Content = text;
        }
    }
}
