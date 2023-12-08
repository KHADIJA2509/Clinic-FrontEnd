using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
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

namespace Clinic_FrontEnd.Pages
{
    /// <summary>
    /// Interaction logic for ReceptionDashboard.xaml
    /// </summary>
    public partial class ReceptionDashboard : Page
    {

        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        public ReceptionDashboard()
        {

            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {25,52,61,89},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<double> {-15,-75,-16,-49},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(9),
                        new ObservableValue(4),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            LastHourSeries1 = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(13),
                        new ObservableValue(11),
                        new ObservableValue(9),
                        new ObservableValue(14),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(12),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            Labels = new[] { "Feb 7", "Feb 8", "Feb 9", "Feb 10" };
            Formatter = value => value.ToString();
            DataContext = this;



            SeriesCollection = new SeriesCollection
{
    new ColumnSeries
    {
        Title = "Total Patient",
        Values = new ChartValues<double> { 10, 50, 39, 50, 60, 70, 90 },
        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E44AD")) // Set the bar color here
    }
};

            // Adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "New Patient",
                Values = new ChartValues<double> { 11, 56, 42, 55, 84, 93, 100 },
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFA0E9")) // Set the bar color here
            });

            Labels = new[] { "Sat", "Sun", "Mon", "Tue", "Wed", "thu", "Fri" };
            Formatter = value => value.ToString("N");

            DataContext = this;



        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
 

private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the Add button
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the Cancel button
        }




    }
}

