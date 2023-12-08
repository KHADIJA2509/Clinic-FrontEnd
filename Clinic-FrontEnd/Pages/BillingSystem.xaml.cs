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
    /// Interaction logic for BillingSystem.xaml
    /// </summary>
    public partial class BillingSystem : Page
    {
        public BillingSystem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add the logic that should be executed when buttons are clicked
            // This logic will be the same for all buttons using this event handler
            // You can differentiate between buttons if necessary using the sender parameter
        }
        private void OpenBillRecord(object sender, RoutedEventArgs e)
        {
            BillRecord Bill = new BillRecord();
            this.Visibility = Visibility.Hidden;
            NavigationService.Navigate(Bill);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Add the logic for when the text in any TextBox changes
            // The sender parameter can be used to determine which TextBox triggered the event
        }

        // You may add additional event handlers for other events mentioned in your XAML
        // For example, if you have a DatePicker that needs handling, you would add it here

        // Also, you may want to add logic for initializing your window,
        // such as loading data or setting initial states of controls
    }
}
