using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace School_Journal_App_VSProject.pages
{
    /// <summary>
    /// Логика взаимодействия для WAddSubjectItem.xaml
    /// </summary>
    public partial class WAddSubjectItem : Window
    {
        private int changedSubject;
        private List<string> fileArr = new List<string>();
        public WAddSubjectItem(int _changedSubject)
        {
            InitializeComponent();

            changedSubject = _changedSubject;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentDate.Content = (sender as DatePicker).SelectedDate;
        }

        private void AddFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|DOC files (*.docx; *.doc)|*.docx; *.doc";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true) {
                fileArr.Add(openFileDialog.FileName);
                SavedFiles.Content = openFileDialog.FileName;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Text.Length < 1 || Comment.Text.Length < 1 || Date.SelectedDate == null || MaxMark.SelectedIndex == -1)
            {
                Error.Visibility = Visibility.Visible;
            }
            else 
            {

                SQLController.controller.Insert(Database.SubjectItem.TABLE_NAME, new List<string> {
                    Database.SubjectItem.TITLE,
                    Database.SubjectItem.COMMENT,
                    Database.SubjectItem.DATE,
                    Database.SubjectItem.MAX_MARK,
                    Database.SubjectItem.SUBJECT_ID
                }, new List<object> {
                    Title.Text,
                    Comment.Text,
                    Date.SelectedDate.ToString(),
                    MaxMark.SelectedIndex + 2,
                    changedSubject
                });

                Close();
            }
        }
    }
}
