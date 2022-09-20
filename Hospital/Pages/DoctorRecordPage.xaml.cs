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

          
        }

        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Records[dtg.SelectedIndex];
                if (obj != null)
                {
                    Records.Remove(obj);
                    obj.Status = RecordStatus.COMPLETED;
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
    }
}
