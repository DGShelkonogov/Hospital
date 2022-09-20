using Hospital.Models;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ApplicationContext db;
        public RegisterPage()
        {
            db = DBConnection.getConnection();
            InitializeComponent();
        }

        private void ButtonClickBack(object sender, RoutedEventArgs e)
        {
            var win = (StartWindow) Window.GetWindow(this);
            win.setLogin();
        }

        private void ButtonClickCreateAccount(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Equals(txtPasswordR.Password)) 
                CreateAccount();
        }

        public async void CreateAccount()
        {
            await Task.Run(() => {
                try
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        var user = new User
                        {
                            Password = txtPassword.Password,
                            Login = txtLogin.Text,
                        };

                        var o = db.Users.FirstOrDefault(x => x.Login == user.Login);

                        if(o != null)
                        {
                            MessageBox.Show("Логин занят");
                            return;
                        }

                        var patient = new Patient
                        {
                            LastName = txtLastName.Text,
                            MiddleName = txtMiddleName.Text,
                            Policy = txtPolicy.Text,
                            Name = txtName.Text,
                            Registration = txtRegistration.Text,
                            User = user, 
                        };

                        if (ApplicationContext.validData(user) && ApplicationContext.validData(patient))
                        {
                            db.Patients.Add(patient);
                            db.SaveChanges();

                            DataStorage.saveUser(user);

                            var window = new PatientMainWindow(patient);
                            window.Show();
                            var win = Window.GetWindow(this);
                            win.Close();
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
