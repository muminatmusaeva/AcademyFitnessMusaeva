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
using System.Windows.Automation;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

namespace AcademyFitnessMusaeva
{
    /// <summary>
    /// Логика взаимодействия для RegistrationTrainersWindow.xaml
    /// </summary>
    public partial class RegistrationTrainersWindow : Window
    {
        AcademyFitnessMusaevaEntities context;
        public RegistrationTrainersWindow()
        {
            
            InitializeComponent();
            context = new AcademyFitnessMusaevaEntities();
        }

        private void Button_Reg_click(object sender, RoutedEventArgs e)
        {
            string Surname = textBoxSurname.Text.Trim();
            string Name = textBoxName.Text.Trim();
            string CallNumber = textBoxCallNumber.Text.Trim();

            if (Surname.Length == 0)
            {
                textBoxSurname.ToolTip = "Это поле введено некоректно!";
                textBoxSurname.Background = Brushes.DarkRed;
            }
            
            else if (Name.Length == 0)
            {
                textBoxName.ToolTip = "Это поле введено некоректно!";
                textBoxName.Background = Brushes.DarkRed;
            }

            else if (CallNumber.Length!=11)
            {
                textBoxSurname.ToolTip = "Это поле введено некоректно!";
                textBoxSurname.Background = Brushes.DarkRed;
            }

            else
            {
                textBoxSurname.ToolTip = "";
                textBoxSurname.Background = Brushes.Transparent;
                textBoxName.ToolTip = "";
                textBoxName.Background = Brushes.Transparent;
                textBoxCallNumber.ToolTip = "";
                textBoxCallNumber.Background = Brushes.Transparent;
                

                MessageBox.Show("Вы зарегистрированы!");
                Trainer trainer = new Trainer(Surname, Name, CallNumber);
                context.Trainers.Add(trainer);
                context.SaveChanges();
                TrainersList trainersList = new TrainersList();
                trainersList.Show();
                this.Close();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void passBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation btnreg = new DoubleAnimation();
            btnreg.From = 200;
            btnreg.To = 500;
            btnreg.Duration = TimeSpan.FromSeconds(1);
            regButton.BeginAnimation(Button.WidthProperty, btnreg);
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
