using Hospital.Models;
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

namespace Hospital
{
    /// <summary>
    /// Логика взаимодействия для PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        public static Patient Patient { get; set; } 
        public PatientMainWindow(Patient patient)
        {
            InitializeComponent();

            Patient = patient;
        }
    }
}
