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

namespace School_Journal_App_VSProject.blocks
{
    /// <summary>
    /// Interaction logic for BStatisticsChart.xaml
    /// </summary>
    public partial class BStatisticsChart : Page
    {
        public BStatisticsChart()
        {
            InitializeComponent();

            ChartC.ChartAreas.Add(new ChartArea("Main"));

            var currentSeries = new Series("Check")
            {
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie                
            };

            

            currentSeries.Points.AddXY("1", "1");
            currentSeries.Points.AddXY("2", "7");
            currentSeries.Points.AddXY("3", "3");
            currentSeries.Points.AddXY("4", "2");

            ChartC.Series.Add(currentSeries);

        }
    }
}
