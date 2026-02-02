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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            dGridHistory.ItemsSource = Entities.GetContext().LoginHistory.ToList();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите очистить историю входа?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    Entities deleteHistory = new Entities();
                    var sql = deleteHistory.Database.ExecuteSqlCommand("DELETE  FROM LoginHistory Where Id != 0");
                    Entities.GetContext().SaveChanges();
                    dGridHistory.ItemsSource = Entities.GetContext().LoginHistory.ToArray();
                    MessageBox.Show("История очищена!");
                }
            }
            catch
            {
                MessageBox.Show("Успешно удалено!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new AddUsersPage());
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            dGridHistory.ItemsSource = Entities.GetContext().LoginHistory.ToList().Where(p => p.Users.Login.ToLower().Contains(tbSearch.Text.ToLower())); 
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new HistoryPrintPage());
        }
    }
}
