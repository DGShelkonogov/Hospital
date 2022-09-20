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
    /// Логика взаимодействия для DoctorHomePage.xaml
    /// </summary>
    public partial class DoctorHomePage : Page
    {
        ApplicationContext db;
        public DoctorHomePage()
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
                var mainWindow = Window.GetWindow(this);
                mainWindow.Close();
                DataStorage.DeleteFile(DataStorage.USER_FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonClickEdit(object sender, RoutedEventArgs e)
        {
            if (txtPasswordNew.IsEnabled)
            {
                DoctorMainWindow.Doctor.User.Password = txtPasswordNew.Password;
                txtPasswordNew.IsEnabled = false;
                txtPasswordNew.Password = "";
                txtPasswordOld.Password = "";
            }

            db.Doctors.Update(DoctorMainWindow.Doctor);
            db.SaveChanges();
            DataStorage.saveUser(DoctorMainWindow.Doctor.User);
        }

        private void txtPasswordOld_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordNew.IsEnabled = txtPasswordOld.Password == DoctorMainWindow.Doctor.User.Password;
        }
    }
}
