using classes;
using School_Journal_App_VSProject.classes;
using School_Journal_App_VSProject.pages;
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
        public delegate void DelegateSelect(Subject subject, int groupId, bool isNew = false);
        private DelegateSelect _delegate;

        List<Subject> listSubjects;
        int prevGroup = -1;
        private int currentGroupId = 0;
        private int selected = 0;

        public BSubjectsList()
        {
            InitializeComponent();

            if (App.CurrentUser.role == 2)
            {
                AddItenBtn.Width = 0;
            }


        }

        public void Reload(int groupId) 
        {
            currentGroupId = groupId;
            if (App.CurrentUser.groupId != 0) currentGroupId = App.CurrentUser.groupId;
            if (currentGroupId != prevGroup) {
                selected = 0;
                prevGroup = groupId;
                SubjectList.Items.Clear();
                listSubjects = SQLController.controller.getSubjectsForGroups(currentGroupId);
                if (listSubjects == null) listSubjects = new List<Subject>();

                if (listSubjects.Count > 0)
                {
                    foreach (var item in listSubjects)
                    {
                        SubjectList.Items.Add(item);
                    }
                }
            }
        }

        public void setOnSelectedListener(DelegateSelect rDelegate) 
        {
            _delegate = rDelegate;
            if (listSubjects == null) listSubjects = new List<Subject>();
            if (listSubjects.Count > 0)
            {
                _delegate?.Invoke(listSubjects[selected], currentGroupId);
            }
        }

        private void SubjectList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selected = (sender as ListView).SelectedIndex;
            if (listSubjects == null) listSubjects = new List<Subject>();
            if (listSubjects.Count > 0 && selected >= 0)
            {
                _delegate?.Invoke(listSubjects[selected], currentGroupId);
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new WAddSubjectItem((int)(sender as Button).Tag);
            addWindow.Show();
            addWindow.Closed += AddWindow_Closed;
        }

        private void AddWindow_Closed(object sender, EventArgs e)
        {
            if (listSubjects == null) listSubjects = new List<Subject>();
            if (listSubjects.Count > 0 && selected >= 0)
            {
                _delegate?.Invoke(listSubjects[selected], currentGroupId, true);
            }
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            var infoWindow = new WSubjectInfo((int)(sender as Button).Tag);
            infoWindow.Show();
            infoWindow.Closed += AddWindow_Closed;
        }
    }
}
