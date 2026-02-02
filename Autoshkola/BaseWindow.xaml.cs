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

namespace Autoshkola
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            baseFrame.Navigate(new AutorizationPage());
            Manager.BaseFrame = baseFrame;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            baseFrame.GoBack();
        }

        private void btnExitAccount_Click(object sender, RoutedEventArgs e)
        {
            baseFrame.Navigate(new AutorizationPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        private void baseFrame_ContentRendered(object sender, EventArgs e)
        {
            if (baseFrame.CanGoBack)
            {
                ResizeMode = ResizeMode.CanResize;
                btnBack.Visibility = Visibility.Visible;
                btnExitAccount.Visibility = Visibility.Visible;
            }
            else
            {
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Normal;
                btnBack.Visibility = Visibility.Hidden;
                btnExitAccount.Visibility = Visibility.Hidden;
            }
        }
    }
}
