using Hospital.Models;
using Hospital.Service;
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
    /// Логика взаимодействия для PatientHomePage.xaml
    /// </summary>
    public partial class PatientHomePage : Page
    {
        ApplicationContext db;
        public PatientHomePage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();
            txtPasswordNew.IsEnabled = false;
        }

        private void ButtonClickLogout(object sender, RoutedEventArgs e)
        {
            try 
            {
                var startWindow = new StartWindow();
                startWindow.Show();
                var patientMainWindow = (PatientMainWindow)Window.GetWindow(this);
                patientMainWindow.Close();
                DataStorage.DeleteFile(DataStorage.USER_FILE);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            if (txtPasswordNew.IsEnabled)
            {
                PatientMainWindow.Patient.User.Password = txtPasswordNew.Password;
                txtPasswordNew.IsEnabled = false;
                txtPasswordNew.Password = "";
                txtPasswordOld.Password = "";
            }

            db.Patients.Update(PatientMainWindow.Patient);
            db.SaveChanges();
            DataStorage.saveUser(PatientMainWindow.Patient.User);
        }

        private void txtPasswordOld_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordNew.IsEnabled = txtPasswordOld.Password == PatientMainWindow.Patient.User.Password;
        }
    }
}
