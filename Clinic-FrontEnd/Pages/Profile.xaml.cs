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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic for when the button is clicked
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Enable editing of profile fields
            GenderComboBox.IsEnabled = true;
            PasswordTextBox.IsEnabled = true;
            FNameTextBox.IsEnabled = true;
            LNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;
            AddressTextBox.IsEnabled = true;
            AboutTextBox.IsEnabled = true;

            // Maybe change the visibility of some buttons
            EditButton.Visibility = Visibility.Collapsed;
            DoneButton.Visibility = Visibility.Visible;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable editing of profile fields
            GenderComboBox.IsEnabled = false;
            PasswordTextBox.IsEnabled = false;
            FNameTextBox.IsEnabled = false;
            LNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PhoneTextBox.IsEnabled = false;
            AddressTextBox.IsEnabled = false;
            AboutTextBox.IsEnabled = false;

            // Maybe change the visibility of some buttons
            EditButton.Visibility = Visibility.Visible;
            DoneButton.Visibility = Visibility.Collapsed;

            // Logic to handle the updated profile data
        }

        private void AboutTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic for when the text changes in AboutTextBox
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Ensure the sender is indeed a ComboBox and an item is selected
            if (comboBox != null && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedGender = selectedItem.Content.ToString();
                // Now you have the selected gender in selectedGender variable
                // You can use it as needed, for example:
                // UpdateGender(selectedGender); // A hypothetical method to handle the gender change
            }
        }

        // Other methods and event handlers as needed
    }
}