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

namespace AcademyFitnessMusaeva
{
    /// <summary>
    /// Логика взаимодействия для TrainersList.xaml
    /// </summary>
    public partial class TrainersList : Window
    {
        AcademyFitnessMusaevaEntities context;
        public TrainersList()
        {
            InitializeComponent();
           context = new AcademyFitnessMusaevaEntities();
            RegistrationGrid.ItemsSource = context.Trainers.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var trainer= new Trainer();
            context.Trainers.Add(trainer);
           var userwin = new RegistrationTrainersWindow();
            userwin.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = RegistrationGrid.SelectedItem as Trainer;
            if (row == null)
            {
                MessageBox.Show("Строка не выбрана");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы уверены", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Trainers.Remove(row);
                context.SaveChanges();
                RegistrationGrid.ItemsSource = context.Trainers.ToList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button EditButton = sender as Button;
            var currentRegistration = EditButton.DataContext as Trainer;
            var userwin = new RegistrationTrainersWindow();
            userwin.ShowDialog();
        }

        private void AddTrainer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
