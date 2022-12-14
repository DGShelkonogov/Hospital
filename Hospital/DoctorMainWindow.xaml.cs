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
    /// Логика взаимодействия для DoctorMainWindow.xaml
    /// </summary>
    public partial class DoctorMainWindow : Window
    {
        public static Doctor Doctor{ get; set; }
        public DoctorMainWindow(Doctor doctor)
        {
            InitializeComponent();
            Doctor = doctor;
        }
    }
}
