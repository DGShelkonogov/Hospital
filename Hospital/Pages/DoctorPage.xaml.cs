using Hospital.Models;
using Hospital.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        ObservableCollection<Doctor> Doctors = new ObservableCollection<Doctor>();
        ObservableCollection<DoctorType> DoctorTypes = new ObservableCollection<DoctorType>();


        ApplicationContext db;
        public DoctorPage()
        {
            db = DBConnection.getConnection();
            InitializeComponent();

            Doctors = new(db.Doctors
                .Include(x => x.User)
                .Include(x => x.DoctorType)
                .ToList());
            DoctorTypes = new(db.DoctorTypes.ToList());

            cmbDoctorTypes.ItemsSource = DoctorTypes;
            dtg.ItemsSource = Doctors;
            dtg.IsReadOnly = true;
        }

        /// <summary>
        /// Добавление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var doctortype = cmbDoctorTypes.SelectedItem as DoctorType;
                var user = new User()
                {
                    Login = txtLogin.Text,
                    Password = txtPassword.Password
                };

                


                var doctor = new Doctor
                {
                    Name = txtName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Experience = Convert.ToInt32(txtExperience.Text),
                    DoctorType = db.DoctorTypes.FirstOrDefault(x => x.Id == doctortype.Id),
                    User = user,
                };
                if (ApplicationContext.validData(doctor))
                {
                    if (ApplicationContext.validData(doctortype))
                    {
                        if (ApplicationContext.validData(user))
                        {
                            Doctors.Add(doctor);
                            db.Doctors.Add(doctor);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }




        /// <summary>
        /// Изменение данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                var doctor = Doctors[dtg.SelectedIndex];
                if (doctor != null)
                {
                    Doctors.Remove(doctor);
                    var doctortype = cmbDoctorTypes.SelectedItem as DoctorType;
                    doctor.Name = txtName.Text;
                    doctor.MiddleName = txtMiddleName.Text;
                    doctor.LastName = txtLastName.Text;
                    doctor.Phone = txtPhone.Text;
                    doctor.Experience = Convert.ToInt32(txtExperience.Text);
                    doctor.DoctorType = db.DoctorTypes.FirstOrDefault(x => x.Id == doctortype.Id);
                    doctor.User.Login = txtLogin.Text;
                    doctor.User.Password = txtPassword.Password;

                    if (ApplicationContext.validData(doctor))
                    {
                        if (ApplicationContext.validData(doctortype))
                        {
                            Doctors.Add(doctor);
                            db.Doctors.Update(doctor);
                            db.SaveChanges();
                            if (ApplicationContext.validData(doctor.User))
                            {
                                db.Doctors.Update(doctor);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }




        /// <summary>
        /// Удаление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Doctor doctor = Doctors[dtg.SelectedIndex];
            if (doctor != null)
            {
                Doctors.Remove(doctor);
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }
        }




        /// <summary>
        /// Поиск данных (Выборка данных по параметрам)
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            if (search == null)
            {
                Doctors = new(db.Doctors
                .Include(x => x.DoctorType)
                .Include(x => x.User)
                .ToList());
                dtg.ItemsSource = Doctors;
                return;
            }
            Doctors = new(db.Doctors
            .Include(x => x.DoctorType)
            .Include(x => x.User)
            .Where(x => x.Name.Contains(search) 
            || x.LastName.Contains(search))
            .ToList());
            dtg.ItemsSource = Doctors;
        }

        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Doctors[dtg.SelectedIndex];
                txtName.Text = obj.Name;
                txtMiddleName.Text = obj.MiddleName;
                txtLastName.Text = obj.LastName;
                txtPhone.Text = obj.Phone;
                txtExperience.Text = obj.Experience.ToString();
                cmbDoctorTypes.SelectedItem = obj.DoctorType;
                txtLogin.Text = obj.User.Login;
                txtPassword.Password = obj.User.Password;
            }
            catch (Exception ex) { }
        }
    }
}
