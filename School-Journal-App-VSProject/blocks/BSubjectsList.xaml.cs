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

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для BSubjectsList.xaml
    /// </summary>
    public partial class BSubjectsList : Page
    {
        public delegate void DelegateClick(string text);
        private DelegateClick _delegate;

        public BSubjectsList()
        {
            InitializeComponent();

        }

        public void setOnClickListener(DelegateClick rDelegate) 
        {
            _delegate = rDelegate;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           _delegate?.Invoke((string)(sender as Button).Content);
        }
    }
}
