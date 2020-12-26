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

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для BSubjectsList.xaml
    /// </summary>
    public partial class BSubjectsList : Page
    {
        public delegate void DelegateSelect(string subject);
        private DelegateSelect _delegate;

        List<Subject> listSubjects;
        int prevGroup = -1;

        public BSubjectsList()
        {
            InitializeComponent();

        }

        public void Reload(int groupId) 
        {
            if (groupId != prevGroup) {
                prevGroup = groupId;
                SubjectList.Items.Clear();
                listSubjects = SQLController.controller.getSubjectsForGroups(groupId);

                foreach (var item in listSubjects) {
                    SubjectList.Items.Add(item.Title);
                }

                SubjectList.SelectedIndex = 0;
                _delegate?.Invoke(listSubjects[0].Title);
            }
        }

        public void setOnSelectedListener(DelegateSelect rDelegate) 
        {
            _delegate = rDelegate;
            _delegate?.Invoke(listSubjects[0].Title);
        }

        private void SubjectList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _delegate?.Invoke((string)(sender as ListView).SelectedItem);
        }
    }
}
