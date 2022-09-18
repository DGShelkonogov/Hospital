using Hospital.Models;
using Hospital.Service;
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
    /// Логика взаимодействия для MedicalServicePage.xaml
    /// </summary>
    public partial class MedicalServicePage : Page
    {
        public ObservableCollection<MedicalService> MedicalServices { get; set; }

        ApplicationContext db;

        public MedicalServicePage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            MedicalServices = new(db.MedicalServices.ToList());
            dtg.ItemsSource = MedicalServices;
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
                MedicalService medicalservice = new MedicalService
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToInt32(txtPrice.Text),
                };
                if (ApplicationContext.validData(medicalservice))
                {
                    MedicalServices.Add(medicalservice);
                    db.MedicalServices.Add(medicalservice);
                    db.SaveChanges();
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
                var medicalservice = MedicalServices[dtg.SelectedIndex];
                if (medicalservice != null)
                {
                    MedicalServices.Remove(medicalservice);
                    medicalservice.Title = txtTitle.Text;
                    medicalservice.Description = txtDescription.Text;
                    medicalservice.Price = Convert.ToInt32(txtPrice.Text);
                    if (ApplicationContext.validData(medicalservice))
                    {
                        MedicalServices.Add(medicalservice);
                        db.MedicalServices.Update(medicalservice);
                        db.SaveChanges();
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
            MedicalService medicalservice = MedicalServices[dtg.SelectedIndex];
            if (medicalservice != null)
            {
                MedicalServices.Remove(medicalservice);
                db.MedicalServices.Remove(medicalservice);
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
                MedicalServices = new(db.MedicalServices
                .ToList());
                dtg.ItemsSource = MedicalServices;
                return;
            }
            MedicalServices = new(db.MedicalServices
            .Where(x => x.Title.Contains(search))
            .ToList());
            dtg.ItemsSource = MedicalServices;
        }
        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = MedicalServices[dtg.SelectedIndex];
                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                txtPrice.Text = obj.Price.ToString();
            }
            catch (Exception ex) { }
        }

    }
}
