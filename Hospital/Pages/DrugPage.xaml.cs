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
using System.Xml.Linq;

namespace Hospital.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrugPage.xaml
    /// </summary>
    public partial class DrugPage : Page
    {
        public ObservableCollection<Drug> Drugs { get; set; }

        ApplicationContext db;

        public DrugPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            Drugs = new(db.Drugs.ToList());
            dtg.ItemsSource = Drugs;
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
                var drug = new Drug
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToInt32(txtPrice.Text),
                };
                if (ApplicationContext.validData(drug))
                {
                    Drugs.Add(drug);
                    db.Drugs.Add(drug);
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
                var drug = Drugs[dtg.SelectedIndex];
                if (drug != null)
                {
                    Drugs.Remove(drug);
                    drug.Name = txtName.Text;
                    drug.Description = txtDescription.Text;
                    drug.Price = Convert.ToInt32(txtPrice.Text);
                    if (ApplicationContext.validData(drug))
                    {
                        Drugs.Add(drug);
                        db.Drugs.Update(drug);
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
            Drug drug = Drugs[dtg.SelectedIndex];
            if (drug != null)
            {
                Drugs.Remove(drug);
                db.Drugs.Remove(drug);
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
                Drugs = new(db.Drugs
                .ToList());
                dtg.ItemsSource = Drugs;
                return;
            }
            Drugs = new(db.Drugs
            .Where(x => x.Name.Contains(search))
            .ToList());
            dtg.ItemsSource = Drugs;
        }
        /// <summary>
        /// Заполнение полей для редактирования>
        /// </summary>>
        private void dtg_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Drugs[dtg.SelectedIndex];
                txtName.Text = obj.Name;
                txtDescription.Text = obj.Description;
                txtPrice.Text = obj.Price.ToString();
            }
            catch (Exception ex) { }
        }
    }
}
