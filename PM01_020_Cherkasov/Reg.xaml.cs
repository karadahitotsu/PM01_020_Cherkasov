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

namespace PM01_020_Cherkasov
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        private int uniqueId;
        public Reg()
        {
            InitializeComponent();
            uniqueId = GenerateUniqueId();
            UniqueIdTextBox.Text = uniqueId.ToString();
        }

        private int GenerateUniqueId()
        {
            DateTime now = DateTime.Now;
            int hash = now.Hour * 3600 + now.Minute * 60 + now.Second;
            return hash;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registr(FullNameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text, PasswordBox.Password, DirectionTextBox.Text, DirectionText1Box.Text, "", RoleComboBox.Text);
        }

        public bool Registr(string name, string mail, string tel, string password, string direct, string eventn, string male, string role1)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(tel) ||
             string.IsNullOrEmpty(direct) || string.IsNullOrEmpty(eventn) || password.Length < 6)
            {
                MessageBox.Show("Заполните все обязательные поля");
                return false;
            }
            else
            {
                using (var db = new cherkasovpm1Entities())
                {
                    var role = role1;

                    if (role == "Жюри")
                    {
                        //Jury jury = new Jury()
                        {
                          //  ID = uniqueId,
                           // Mail = mail,
                           // Tel = tel,
                          //  Password = password,
                          //  Direct = direct,

                        };

                      //  db.Jury.Add(jury);

                    }

                    else if (role == "Модератор")
                    {
                        Moderators moderator = new Moderators()
                        {
                          // ID = uniqueId,
                           // Password = password,
                           // Direct = direct,
                           // Event = eventn
                        };

                        db.Moderators.Add(moderator);

                    }
                    else
                    {
                        MessageBox.Show("Неверная роль");
                        return false;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Пользователь создан");
                }
                MessageBox.Show("Регистрация успешна!");
                return true;
            }
        }
    }

}
