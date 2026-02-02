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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            dGridClients.ItemsSource = Entities.GetContext().Client.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new AddClientPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = dGridClients.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Client.RemoveRange(usersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dGridClients.ItemsSource = Entities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

       

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            dGridClients.ItemsSource = Entities.GetContext().Client.ToList().Where(p => p.Name.ToLower().Contains(tbSearch.Text.ToLower()) || p.LastName.ToLower().Contains(tbSearch.Text.ToLower()));
        }
    }
}
