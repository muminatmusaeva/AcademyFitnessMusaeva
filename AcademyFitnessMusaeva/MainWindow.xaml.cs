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

namespace AcademyFitnessMusaeva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AcademyFitnessMusaevaEntities context;
        
        public MainWindow()
        {
            InitializeComponent();
            context = new AcademyFitnessMusaevaEntities();
            CmbSelectTrainer.ItemsSource = context.Trainers.ToList();
            RegistrationGrid.ItemsSource = context.CourseRegistrations.ToList();

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { LblTime.Content = DateTime.Now.ToString(); };
            timer.Start();
        }

        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newRegistration = new CourseRegistration();
            context.CourseRegistrations.Add(newRegistration);
            var win = new RegistrationCourseWindow(context, newRegistration);
            win.ShowDialog();
            RegistrationGrid.ItemsSource = context.CourseRegistrations.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = RegistrationGrid.SelectedItem as CourseRegistration;
            if (row==null)
            {
                MessageBox.Show("Строка не выбрана");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы уверены", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.CourseRegistrations.Remove(row);
                context.SaveChanges();
                RegistrationGrid.ItemsSource = context.CourseRegistrations.ToList();
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button EditButton = sender as Button;
            var currentRegistration = EditButton.DataContext as CourseRegistration;
            var win = new RegistrationCourseWindow(context, currentRegistration);
            win.ShowDialog();
        }

        private void FiltrButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationGrid.ItemsSource = context.CourseRegistrations.Where(x => x.IsDone == true).ToList();
            MessageBoxResult result = MessageBox.Show("Вернуть все записи ?", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                RegistrationGrid.ItemsSource = context.CourseRegistrations.ToList();
            }
        }

        private void CmbSelectTrainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSelectTrainer.SelectedItem == null) return;
            var currentTrainer = (Trainer)CmbSelectTrainer.SelectedItem;
            List<CourseRegistration> ListTrainer = context.CourseRegistrations.ToList();
            RegistrationGrid.ItemsSource = ListTrainer.Where(x => x.Trainer == currentTrainer).ToList();
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationGrid.ItemsSource = context.CourseRegistrations.ToList();
        }

        private void AddTrainer_Click(object sender, RoutedEventArgs e)
        {
            RegistrationTrainersWindow registrationTrainersWindow = new RegistrationTrainersWindow();
            registrationTrainersWindow.Show();
        }
    }
    class PrefixValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value.ToString();
            int prefixLength;
            if (!int.TryParse(parameter.ToString(), out prefixLength) ||
                s.Length <= prefixLength)
            {
                return s;
            }
            return s.Substring(0, prefixLength);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
