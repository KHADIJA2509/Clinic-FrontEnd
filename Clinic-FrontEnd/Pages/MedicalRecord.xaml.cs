using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecord : Page
    {
        public MedicalRecord()
        {
            InitializeComponent();
        }

        private void OpenIntegratedView(object sender, RoutedEventArgs e)
        {
            IntegratedVeiw Patient = new IntegratedVeiw();
            this.Visibility = Visibility.Hidden;
            NavigationService.Navigate(Patient);

        }
    }
}
