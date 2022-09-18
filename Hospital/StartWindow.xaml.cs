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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();

            mainFrame.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
        }

        public void setLogin()
        {
            mainFrame.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
        }
        public void setRegister()
        {
            mainFrame.Source = new Uri("Pages/RegisterPage.xaml", UriKind.Relative);
        }
    }
}
