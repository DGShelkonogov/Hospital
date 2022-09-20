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
    /// Логика взаимодействия для DoctorRecordPage.xaml
    /// </summary>
    public partial class DoctorRecordPage : Page
    {
        public ObservableCollection<Record> Records { get; set; }
        public ObservableCollection<Drug> Drugs { get; set; }
        public ObservableCollection<MedicalService> MedicalServices { get; set; }

        private ObservableCollection<Drug> DrugBuffer { get; set; } = new ObservableCollection<Drug>();
        private ObservableCollection<MedicalService> MedicalServiceBuffer { get; set; } = new ObservableCollection<MedicalService>();

        ApplicationContext db;

        public DoctorRecordPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Where(x => x.Doctor.Id == DoctorMainWindow.Doctor.Id)
                .ToList());

            dtg.ItemsSource = Records;
            dtg.IsReadOnly = true;

            Drugs = new(db.Drugs.ToList());
            MedicalServices = new(db.MedicalServices.ToList());

            cmbDrugs.ItemsSource = Drugs;
            cmbMedicalServices.ItemsSource = MedicalServices;

            listDrugs.ItemsSource = DrugBuffer;
            listMedicalServices.ItemsSource = MedicalServiceBuffer;
        }

        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Records[dtg.SelectedIndex];
                if (obj != null)
                {
                    var patient = obj.Patient;

                    foreach(var i in DrugBuffer)
                        patient.Drugs.Add(i);

                    foreach (var i in MedicalServiceBuffer)
                        patient.MedicalServices.Add(i);


                    Records.Remove(obj);
                    obj.Status = RecordStatus.COMPLETED;
                    db.Patients.Update(patient);
                    db.Records.Update(obj);
                    Records.Add(obj);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            if (search == null)
            {
                Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Where(x => x.Doctor.Id == DoctorMainWindow.Doctor.Id)
                .ToList());
                dtg.ItemsSource = Records;
                return;
            }
            Records = new(db.Records
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
            .Where(x => x.Patient.Name.Contains(search) && x.Doctor.Id == DoctorMainWindow.Doctor.Id)
            .ToList());
            dtg.ItemsSource = Records;
        }

        private void cmbDrugs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = cmbDrugs.SelectedItem as Drug;
            if(obj != null)
            {
                if (DrugBuffer.Contains(obj))
                    DrugBuffer.Remove(obj);
                else
                    DrugBuffer.Add(obj);
            }
        }

        private void cmbMedicalServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = cmbMedicalServices.SelectedItem as MedicalService;
            if (obj != null)
            {
                if (MedicalServiceBuffer.Contains(obj))
                    MedicalServiceBuffer.Remove(obj);
                else
                    MedicalServiceBuffer.Add(obj);
            }
        }
    }
}
