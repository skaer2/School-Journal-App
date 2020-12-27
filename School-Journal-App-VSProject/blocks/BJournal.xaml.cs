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

            string[] labels = new string[] { "Студент", "Занятие 1", "Занятие 2", "Занятие 3" };

            foreach (string label in labels)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = label;
                column.IsReadOnly = false;
                column.Binding = new Binding(label.Replace(' ', '_'));

                JournalList.Columns.Add(column);
            }

            string[] values = new string[] { "Алёна", "5", "н", "1" };

            dynamic row = new ExpandoObject();

            for (int i = 0; i < labels.Length; i++)
                ((IDictionary<String, Object>)row)[labels[i].Replace(' ', '_')] = values[i];

            JournalList.Items.Add(row);

            string[] values1 = new string[] { "Игорь", "3", "2", "3" };


            JournalList.Items.Add(makeRow(labels, values1));
        }

        public dynamic makeRow(string[] labels, string[] values)
        {
            dynamic row = new ExpandoObject();

            for (int i = 0; i < labels.Length; i++)
                ((IDictionary<String, Object>)row)[labels[i].Replace(' ', '_')] = values[i];

            return row;
        }

        private void JournalList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
    }
}
