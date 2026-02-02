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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            dGridHistory.ItemsSource = Entities.GetContext().Timetable.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            dGridHistory.ItemsSource = Entities.GetContext().Timetable.ToList().Where(p => p.Groups.Category.ToLower().Contains(tbSearch.Text.ToLower()));
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new PrintPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new PlanOfTheEducation());
        }
    }
}
