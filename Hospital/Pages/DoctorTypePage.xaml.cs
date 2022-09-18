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
    /// Логика взаимодействия для DoctorTypePage.xaml
    /// </summary>
    public partial class DoctorTypePage : Page
    {
        public ObservableCollection<DoctorType> DoctorTypes { get; set; }


        ApplicationContext db;
        public DoctorTypePage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            DoctorTypes = new(db.DoctorTypes.ToList());
            dtg.IsReadOnly = true;
         
            dtg.ItemsSource = DoctorTypes;
        }

        /// <summary>
        /// Добавление данных в БД>
        /// </summary>>
        /// <param name=sender>нажатая кнопка</param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var doctortype = new DoctorType
                {
                    Title = txtTitle.Text,
                };
                if (ApplicationContext.validData(doctortype))
                {
                    DoctorTypes.Add(doctortype);
                    db.DoctorTypes.Add(doctortype);
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
                var doctortype = DoctorTypes[dtg.SelectedIndex];
               

                if (doctortype != null) {

                    DoctorTypes.Remove(doctortype);

                    doctortype.Title = txtTitle.Text;
                    if (ApplicationContext.validData(doctortype))
                    {
                        DoctorTypes.Add(doctortype);
                        db.DoctorTypes.Update(doctortype);
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
            var doctortype = DoctorTypes[dtg.SelectedIndex];
            if (doctortype != null)
            {
                db.DoctorTypes.Remove(doctortype);
                DoctorTypes.Remove(doctortype);
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
                DoctorTypes = new(db.DoctorTypes
                .ToList());
                dtg.ItemsSource = DoctorTypes;
                return;
            }
            DoctorTypes = new(db.DoctorTypes
            .Where(x => x.Title.Contains(search))
            .ToList());
            dtg.ItemsSource = DoctorTypes;
        }

        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var doctortype = DoctorTypes[dtg.SelectedIndex];
                if (doctortype != null)
                {
                    txtTitle.Text = doctortype.Title;

                    doctortype.Title = txtTitle.Text;
                }
            }
            catch(Exception ex)
            {

            }
        }

      
    }
}
