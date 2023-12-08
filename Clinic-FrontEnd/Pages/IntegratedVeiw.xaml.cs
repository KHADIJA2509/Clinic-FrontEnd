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
    /// Interaction logic for IntegratedVeiw.xaml
    /// </summary>
    public partial class IntegratedVeiw : Page
    {
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public SeriesCollection PSeriesCollection { get; set; }
        public string[] PLabels { get; set; }
        public Func<double, string> PFormatter { get; set; }

        public SeriesCollection DSeriesCollection { get; set; }


        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public IntegratedVeiw()
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
        Title = "First 2 Weeks",
        Values = new ChartValues<double> { 10, 50, 39, 50, 60, 70, 90, 10, 100, 40, 60, 80 },
        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF89CFF0")) // Set the bar color here
    }
};

            // Adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Socund 2 Weeks",
                Values = new ChartValues<double> { 11, 56, 42, 55, 84, 93, 100, 86, 19, 108, 25, 94 },
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3498DB")) // Set the bar color here
            });

            Labels = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Formatter = value => value.ToString("N");

            DataContext = this;







            SeriesCollection1 = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7 }
                }
            };

            Labels1 = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SeriesCollection1.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 1, //0: straight lines, 1: really smooth lines
            });

            //modifying any series values will also animate and update the chart
            SeriesCollection1[3].Values.Add(5d);

            //DataContext = this;


            PSeriesCollection = new SeriesCollection
            {
                new StackedRowSeries
                {
                    Values = new ChartValues<double> {4, 5, 6, 8},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString(),
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFB6C1"))
                },
                new StackedRowSeries
                {
                    Values = new ChartValues<double> {2, 5, 6, 7},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString(),
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFA0E9"))
        }
            };

            //adding series updates and animates the chart
            PSeriesCollection.Add(new StackedRowSeries
            {
                Values = new ChartValues<double> { 6, 2, 7 },
                StackMode = StackMode.Percentage,
                DataLabels = true,
                LabelPoint = p => p.X.ToString(),
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF89CFF0"))
            });

            //adding values also updates and animates
            PSeriesCollection[2].Values.Add(4d);

            PLabels = new[] { "Chrome", "Mozilla", "Opera", "IE" };
            PFormatter = val => val.ToString("P");

            //DataContext = this;


            DSeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(8) },
                    DataLabels = true,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF428787"))
                },
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
                    DataLabels = true,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E44AD"))
        },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE91E63"))
        },
                new PieSeries
                {
                    Title = "Explorer",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true,
                    Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3498DB"))
                }
            };


            DataContext = this;


        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}