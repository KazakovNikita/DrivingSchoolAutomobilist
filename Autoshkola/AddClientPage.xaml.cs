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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private Client _currentClients = new Client();
        public AddClientPage(Client selectedClients)
        {
            InitializeComponent();
            if (selectedClients != null)
                _currentClients = selectedClients;

            DataContext = _currentClients;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            DateTime birth = DateTime.Parse(tbBirth.Text);

            _currentClients.DateOfBirth = DateTime.Parse(birth.ToString("yyyy/MM/dd"));



            if (string.IsNullOrWhiteSpace(_currentClients.Name))
               errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrWhiteSpace(_currentClients.LastName))
                errors.AppendLine("Укажите фамилию клиента");
            if (tbBirth.Text.Length == 0)
                errors.AppendLine("Укажите дату рождения клиента");
            if (string.IsNullOrWhiteSpace(_currentClients.Number))
                errors.AppendLine("Укажите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClients.Id == 0)
               Entities.GetContext().Client.Add(_currentClients);

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.BaseFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите отменить изменения?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Manager.BaseFrame.GoBack();
            }
            else
            {
                return;
            }
        }
    }
}
