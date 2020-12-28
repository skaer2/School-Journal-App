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

using System.Windows.Forms.DataVisualization.Charting;
using School_Journal_App_VSProject.classes;
using classes;
using System.Text.RegularExpressions;

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Interaction logic for BStatisticsChart.xaml
    /// </summary>
    public partial class BStatisticsChart : Page
    {
        public int subjectId { get; private set; }

        public BStatisticsChart(int subjectId)
        {
            InitializeComponent();
            this.subjectId = subjectId;

            updateChart();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            updateChart();
        }

        private void updateChart()
        {
            ChartC.ChartAreas.Clear();
            ChartC.ChartAreas.Add(new ChartArea("Статистика"));

            var currentSeries = new Series("Check")
            {
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie,
                Palette = ChartColorPalette.Excel,
            };

            var users = SQLController.controller.getUsersBySubject(subjectId);

            List<int> scores = new List<int>();

            if (users == null) users = new List<User>();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    var marks = SQLController.controller.getMarks(user.login, subjectId);
                    int sum = 0;
                    foreach (var mark in marks)
                    {
                        Regex regex = new Regex("[0-9]+");
                        if (mark.CurrentMark.Length > 0 && regex.IsMatch(mark.CurrentMark))
                        {
                            sum += int.Parse(mark.CurrentMark);
                        }
                    }
                    if (marks.Count > 0)
                    {
                        double buf = ((double)sum) / ((double)marks.Count);
                        int averageScore = (int) Math.Ceiling(buf);
                        scores.Add(averageScore);
                    }
                }
                if (scores == null) scores = new List<int>();
                if (scores.Count > 0)
                { 
                    Dictionary<int, int> scoreCounts = new Dictionary<int, int>();
                    foreach (var score in scores)
                    {
                        if (scoreCounts.TryGetValue(score, out int buf)) scoreCounts[score] = buf + 1;
                        else scoreCounts.Add(score, 1);
                    }

                    foreach (var scoreDivision in scoreCounts)
                    {
                        currentSeries.Points.AddXY("Со средней оценкой \"" + scoreDivision.Key.ToString() + "\" : " + scoreDivision.Value.ToString(),
                            scoreDivision.Value);
                    }
                    ChartC.Series.Clear();
                    ChartC.Series.Add(currentSeries);
                    WinFormHost.Visibility = Visibility.Visible;
                    EmptyListLbl.Visibility = Visibility.Hidden;
                }
                else
                {
                    WinFormHost.Visibility = Visibility.Hidden;
                    EmptyListLbl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                WinFormHost.Visibility = Visibility.Hidden;
                EmptyListLbl.Visibility = Visibility.Visible;
            }

            
        }
    }
}
