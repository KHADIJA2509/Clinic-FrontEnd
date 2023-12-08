using Clinic_FrontEnd.Pages;
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
using System.Windows.Shapes;

namespace Clinic_FrontEnd
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
            // Add options to the ComboBox
            UserComboBox.Items.Add("Owner");
            UserComboBox.Items.Add("Doctor");
            UserComboBox.Items.Add("Reception");
           
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected item from the ComboBox
            string selectedPerson = UserComboBox.SelectedItem as string;

            // Open the corresponding page based on the selected person
            switch (selectedPerson)
            {
                case "Reception":
                    ReceptionWindow reception = new ReceptionWindow();
                    this.Visibility = Visibility.Hidden;
                    reception.Show();
                    break;

                case "Doctor":
                    DoctorWindow doctor = new DoctorWindow();
                    this.Visibility = Visibility.Hidden;
                    doctor.Show();
                    break;

                case "Owner":
                    OwnerWindow owner = new OwnerWindow();
                    this.Visibility = Visibility.Hidden;
                    owner.Show();
                    break;
                default:
                    MessageBox.Show("Please select a person.");
                    break;
            }
        }
    }
}
