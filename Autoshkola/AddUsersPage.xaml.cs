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
    /// Логика взаимодействия для AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        private Users _currentUser = new Users();
        public AddUsersPage()
        {
            InitializeComponent();
            DataContext = _currentUser;
            cbRole.ItemsSource = Entities.GetContext().UsersRoles.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Name))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");
            if (_currentUser.UsersRoles == null)
                errors.AppendLine("Укажите роль");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.Id == 0)
                Entities.GetContext().Users.Add(_currentUser);

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
