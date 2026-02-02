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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (boxLog.Text != "" && boxPass.Password != "")
            {
                try
                {
                    int n = 0;
                    int userid = 0;
                    foreach (var user in Entities.GetContext().Users)
                        if ((boxLog.Text == user.Login) && (boxPass.Password == user.Password))
                        {
                            userid = user.Id;
                            if (user.IdRole == 1)
                            {

                                MessageBox.Show(user.Login + ", Вы успешно авторизовались!", "Администратор", MessageBoxButton.OK, MessageBoxImage.Information);
                                Manager.BaseFrame.Navigate(new AdminPage());

                            }
                            if (user.IdRole == 3)
                            {

                                MessageBox.Show(user.Login + ", Вы успешно авторизовались!", "Преподаватель", MessageBoxButton.OK, MessageBoxImage.Information);
                                Manager.BaseFrame.Navigate(new TeacherPage());

                            }
                            if (user.IdRole == 4)
                            {

                                MessageBox.Show(user.Login + ", Вы успешно авторизовались!", "Инструктор", MessageBoxButton.OK, MessageBoxImage.Information);
                                Manager.BaseFrame.Navigate(new InstructorPage());

                            }
                            else if (user.IdRole == 2)
                            {

                                MessageBox.Show(user.Login + ", Вы успешно авторизовались!", "Менеджер", MessageBoxButton.OK, MessageBoxImage.Information);
                                Manager.BaseFrame.Navigate(new ManagerPage());

                            }
                            n = 0;
                            break;
                        }
                        else if (boxLog.Text == user.Login)
                        {
                            n += 2;
                            userid = user.Id;
                        }
                        else
                        {
                            n++;
                        }
                    if (n == 0)
                    {
                        addHistory(userid, true);
                    }
                    else
                    {
                        if (n == 2)
                        {
                            addHistory(userid, false);
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch
                {
       
                }
            }
            
            
        }

        private void btnPass_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbPass.Text = boxPass.Password;
            boxPass.Visibility = Visibility.Hidden;
            tbPass.Visibility = Visibility.Visible;
        }

        private void btnPass_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            boxPass.Visibility = Visibility.Visible;
            tbPass.Visibility = Visibility.Hidden;
        }
         public static void addHistory(int login, bool result)
    {
    LoginHistory loginHistory = new LoginHistory();
    loginHistory.IdManager = login;
    loginHistory.Date = DateTime.Now;
    loginHistory.Status = result;
    Entities.GetContext().LoginHistory.Add(loginHistory);
    Entities.GetContext().SaveChanges();
    }
  

    }
  }
    
