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
    /// Логика взаимодействия для BGroupsList.xaml
    /// </summary>
    public partial class BGroupsList : Page
    {
        public delegate void DelegateSelected(int index);
        private DelegateSelected _delegate;
        List<Group> listGroups;
        public BGroupsList()
        {
            InitializeComponent();

            if (App.CurrentUser.role == 0)
            {
                listGroups = SQLController.controller.getGroups();
            }
            else if (App.CurrentUser.role == 1)
            {
                listGroups = SQLController.controller.getGroupsByTeacher(App.CurrentUser.login);
            }else if(App.CurrentUser.role == 2)
            {
                listGroups = SQLController.controller.getGroups();
            }

            if (listGroups == null) listGroups = new List<Group>();
            if (listGroups.Count > 0)
            {
                foreach (var item in listGroups)
                {
                    GroupList.Items.Add(item.Title);
                }
            }
            GroupList.SelectedIndex = 0;
        }

        public void SetOnSelectedListener(DelegateSelected rDelegate)
        {
            _delegate = rDelegate;
            if (listGroups == null) listGroups = new List<Group>();
            if (listGroups.Count > 0)
            {
                _delegate.Invoke(listGroups[0].Id);
            }
        }

        private void GroupList_Selected(object sender, RoutedEventArgs e)
        {
            if (listGroups == null) listGroups = new List<Group>();
            if (listGroups.Count > 0 && (sender as ListView).SelectedIndex >= 0)
            {
                _delegate.Invoke(listGroups[(sender as ListView).SelectedIndex].Id);
            }
        }
    }
}
