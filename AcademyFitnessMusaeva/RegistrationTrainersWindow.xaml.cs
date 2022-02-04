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

namespace AcademyFitnessMusaeva
{
    /// <summary>
    /// Логика взаимодействия для RegistrationTrainersWindow.xaml
    /// </summary>
    public partial class RegistrationTrainersWindow : Window
    {
       AcademyFitnessMusaevaEntities context;

       /* public RegistrationTrainersWindow()
        {

        }*/

        public RegistrationTrainersWindow()
        {
            
            InitializeComponent();
            context = new AcademyFitnessMusaevaEntities(); 
        }

        private void Button_Reg_click(object sender, RoutedEventArgs e)
        {

            string Name = textBoxName.Text.Trim();
            string Surname = textBoxSurname.Text.Trim();

            string pass = passBox.Text.Trim();

            string pass_2 = passBox_2.Text.Trim();


            if (Name.Length == 0)
            {
                textBoxName.ToolTip = "Это поле введено некоректно!";
                textBoxName.Background = Brushes.DarkRed;
            }

            else if (Surname.Length == 0)
            {
                textBoxSurname.ToolTip = "Это поле введено некоректно!";
                textBoxSurname.Background = Brushes.DarkRed;
            }

            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено некоректно!";
                passBox.Background = Brushes.DarkRed;
            }

            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле введено некоректно!";
                passBox_2.Background = Brushes.DarkRed;
            }

            

            else
            {
                textBoxName.ToolTip = "";
                textBoxName.Background = Brushes.Transparent;
                textBoxSurname.ToolTip = "";
                textBoxSurname.Background = Brushes.Transparent;
                passBox.ToolTip = " ";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = " ";
                passBox_2.Background = Brushes.Transparent;

                MessageBox.Show("Успешно");
                Trainer user = new Trainer(Name, Surname, pass);
                context.Trainers.Add(user);
                context.SaveChanges();

               /* db.Users.Add(user);
                db.SaveChanges();*/

            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
