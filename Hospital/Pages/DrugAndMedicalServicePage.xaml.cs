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

namespace Hospital.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrugAndMedicalServicePage.xaml
    /// </summary>
    public partial class DrugAndMedicalServicePage : Page
    {
        public DrugAndMedicalServicePage()
        {
            InitializeComponent();

            dtgMedicalService.ItemsSource = PatientMainWindow.Patient.MedicalServices;
            dtgDrugs.ItemsSource = PatientMainWindow.Patient.Drugs;

            dtgMedicalService.IsReadOnly = true;
            dtgDrugs.IsReadOnly = true;
        }
    }
}
