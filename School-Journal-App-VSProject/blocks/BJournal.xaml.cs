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
using System.Dynamic;
using System.Data;
using School_Journal_App_VSProject.classes;
using classes;

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Логика взаимодействия для BJournal.xaml
    /// </summary>
    public partial class BJournal : Page
    {
        private string lastValue = "";
        private Subject lastSubject = new Subject();
        private List<User> usersForJournal = new List<User>();
        private List<SubjectItem> itemsForJournal = new List<SubjectItem>();
        private string[] CHAR = new string[] { "1", "2", "3", "4", "5", "Н" };
        private User editingUser;
        private SubjectItem editingItem;

        public BJournal()
        {
            InitializeComponent();
        }

        public void UpdateJournal(Subject subject, int groupId, bool isReload)
        {
            if (lastSubject.Id != subject.Id || isReload)
            {
                lastSubject = subject;
                Text.Content = subject.Title;

                List<string> headers = new List<string> { "Студент" };

                List<List<string>> list = new List<List<string>>();

                usersForJournal = SQLController.controller.getUsersForGroup(groupId);
                itemsForJournal = SQLController.controller.getItemsForSubject(subject.Id);

                foreach (var user in usersForJournal)
                {
                    var value = new List<string> { user.name.Item1 + " " + user.name.Item2 + " " + user.name.Item3 };

                    foreach (var item in itemsForJournal)
                    {
                        headers.Add(item.Title);
                        value.Add(SQLController.controller.getMark(user.login, item.Id).CurrentMark);
                    }

                    list.Add(value);
                }

                JournalList.ItemsSource = GetDataTable(headers, list).DefaultView;
            }

        }

        private DataTable GetDataTable(List<string> labels, List<List<string>> values)
        {
            var table = new DataTable();
            DataColumn column;
            DataRow row;

            for (var i = 0; i < labels.Count; i++)
            {
                column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = labels[i],
                    ReadOnly = true
                };
                if (i != 0 && App.CurrentUser.role == 1) column.ReadOnly = false;
                column.Unique = false;
                table.Columns.Add(column);
            }

            for (var i = 0; i < values.Count; i++)
            {
                row = table.NewRow();
                for (var j = 0; j < labels.Count; j++)
                {
                    row[labels[j]] = values[i][j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private void JournalList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var clumn = e.Column.DisplayIndex;

            editingItem = itemsForJournal[clumn - 1];

            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            Console.WriteLine(row.GetIndex());
            editingUser = usersForJournal[row.GetIndex()];
            DataGridCell RowColumn = dataGrid.Columns[clumn].GetCellContent(row).Parent as DataGridCell;
            string CellValue = ((TextBlock)RowColumn.Content).Text;

            lastValue = CellValue;

            Console.WriteLine(CellValue);
            Console.WriteLine(editingItem.Title);
            Console.WriteLine(editingUser.login);
        }

        private void JournalList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = e.EditingElement as TextBox;
            string value = t.Text;

            if (value != lastValue) 
            {
                if (CHAR.Contains(value))
                {
                    if (lastValue == "")
                    {
                        SQLController.controller.Insert(Database.Marks.TABLE_NAME, null, new List<object> { value, editingUser.login, editingItem.Id });
                    }
                    else
                    {
                        Console.WriteLine("Update");
                    }
                }
                else if (value == "") 
                {
                    SQLController.controller.Delete(Database.Marks.TABLE_NAME, new Dictionary<string, object> {
                        [Database.Marks.STUDENT] = editingUser.login,
                        [Database.Marks.ITEM] = editingItem.Id
                    });
                }
                else 
                {
                    t.Text = lastValue;
                }
            }

            Console.WriteLine(t.Text .ToString());
        }
    }
}
