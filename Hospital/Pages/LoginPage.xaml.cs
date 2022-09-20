using Hospital.Models;
using Hospital.Service;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ApplicationContext db;
        public LoginPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            var user = DataStorage.getUser();
            if (user != null)
            {
                txtLogin.Text = user.Login;
                txtPassword.Password = user.Password;
            }
        }

        private void ButtonClickLogin(object sender, RoutedEventArgs e)
        {
            var user = new User()
            {
                Login = txtLogin.Text,
                Password = txtPassword.Password
            };
            Login(user);
        }

        private void ButtonClickRegister(object sender, RoutedEventArgs e)
        {
            var win = (StartWindow) Window.GetWindow(this);
            win.setRegister();
        }

        public void Login(User user)
        {
            var win = Window.GetWindow(this);
         
            if (user != null)
            {
                if(user.Login.Equals("admin") && user.Password.Equals("admin"))
                {
                    var window = new AdminMainWindow();
                    window.Show();
                    win.Close();
                    return;
                }
                var doctor = db.Doctors
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.User.Login == user.Login && x.User.Password == user.Password);
                var patient = db.Patients
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.User.Login == user.Login && x.User.Password == user.Password);

                if (doctor != null)
                {
                    var window = new DoctorMainWindow(doctor);
                    window.Show();
                    win.Close();
                    DataStorage.saveUser(user);
                    return;
                }

                if (patient != null)
                {
                    var window = new PatientMainWindow(patient);
                    window.Show();
                    win.Close();
                    DataStorage.saveUser(user);
                    return;
                }
                MessageBox.Show("Неправильные логин или пароль");
            }
        }
    }
}
