using Hospital.Models;
using Hospital.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        ObservableCollection<TimeOnly> schedule = new ObservableCollection<TimeOnly>
        {
            new TimeOnly(8, 30), 
            new TimeOnly(9, 0), 
            new TimeOnly(9, 30), 
            new TimeOnly(10, 0), 
            new TimeOnly(10, 30), 
            new TimeOnly(11, 0), 
            new TimeOnly(11, 30), 
            new TimeOnly(13, 0), 
            new TimeOnly(13, 30), 
            new TimeOnly(14, 0), 
            new TimeOnly(14, 30),
            new TimeOnly(15, 0),
            new TimeOnly(15, 30) 
        };

        private Patient _patient { get; set; }

        public ObservableCollection<Record> Records { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }

        ApplicationContext db;

        public string FullNameDoctor { get; set; }

        public void setSchedule(Doctor doctor, DateTime? date)
        {
            schedule = new ObservableCollection<TimeOnly>
            {
                new TimeOnly(8, 30),
                new TimeOnly(9, 0),
                new TimeOnly(9, 30),
                new TimeOnly(10, 0),
                new TimeOnly(10, 30),
                new TimeOnly(11, 0),
                new TimeOnly(11, 30),
                new TimeOnly(13, 0),
                new TimeOnly(13, 30),
                new TimeOnly(14, 0),
                new TimeOnly(14, 30),
                new TimeOnly(15, 0),
                new TimeOnly(15, 30)
            };

            var sheduleDoctor = db.Records
                .Include(x => x.Doctor)
                .Where(x => x.Doctor.Id == doctor.Id)
                .Where(x => x.DateTime.Day == date.Value.Day)
                .Where(x => x.DateTime.Month == date.Value.Month)
                .Where(x => x.DateTime.Year == date.Value.Year)
                .Where(x => x.Status != RecordStatus.CANCELED)
                .ToList();

            foreach (var record in sheduleDoctor)
            {
                var item = schedule.FirstOrDefault(x => x.Hour == record.DateTime.Hour && x.Minute == record.DateTime.Minute);
                if (item != null)
                    schedule.Remove(item);
            }
        }



        public RecordPage()
        {
            InitializeComponent();


            db = DBConnection.getConnection();

            _patient = PatientMainWindow.Patient;

            

            dtp.DisplayDateStart = DateTime.Now;
            cmbSchedule.ItemsSource = schedule;

            Doctors = new(db.Doctors.Include(x => x.DoctorType).ToList());
            Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Where(x => x.Patient.Id == _patient.Id)
                .ToList());



            dtg.ItemsSource = Records;
            dtg.IsReadOnly = true;

            cmbDoctors.ItemsSource = Doctors;
            dtp.IsEnabled = false;
            cmbSchedule.IsEnabled = false;
        }

        private void dtp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = dtp.SelectedDate;
            if(date != null)
            {
                cmbSchedule.IsEnabled = true;
                setSchedule(cmbDoctors.SelectedItem as Doctor, date);
                cmbSchedule.ItemsSource = schedule;
            }
        }

        private void cmbDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctor = cmbDoctors.SelectedItem as Doctor;
            if (doctor != null)
            {
                dtp.IsEnabled = true;
                cmbSchedule.IsEnabled = false;
                dtp.SelectedDate = null;
                cmbSchedule.SelectedItem = null;
            }
            else
                dtp.IsEnabled = false;
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            try {
                var doctor = cmbDoctors.SelectedItem as Doctor;
                var date = dtp.SelectedDate;
                var time = (TimeOnly)cmbSchedule.SelectedItem;

                if (doctor != null && date != null)
                {
                    schedule.Remove(time);

                    var dateTime = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Hour, time.Minute, 0, DateTimeKind.Utc);

                    var record = new Record()
                    {
                        Doctor = db.Doctors.FirstOrDefault(x => x.Id == doctor.Id),
                        Patient = db.Patients.FirstOrDefault(x => x.Id == _patient.Id),
                        Status = RecordStatus.PENDING,
                        DateTime = dateTime
                    };

                    Records.Add(record);
                    db.Records.Add(record);
                    db.SaveChanges();
                }


            }catch(Exception ex) { }
        }

        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Records[dtg.SelectedIndex];

                cmbDoctors.SelectedItem = obj.Doctor;
                dtp.SelectedDate = obj.DateTime.Date;
            }
            catch (Exception ex) { }
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
                Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Where(x => x.Patient.Id == _patient.Id)
                .ToList());
                dtg.ItemsSource = Records;
                return;
            }
            Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
            .Where(x => x.Doctor.Name.Contains(search))
            .ToList());
            dtg.ItemsSource = Records;
        }

        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            var obj = Records[dtg.SelectedIndex];
            if(obj != null)
            {
                Records.Remove(obj);
                obj.Status = RecordStatus.CANCELED;
                db.Records.Update(obj);
                Records.Add(obj);
                db.SaveChanges();
            }
        }
    }
}
