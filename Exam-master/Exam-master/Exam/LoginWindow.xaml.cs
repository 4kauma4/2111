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


namespace Exam
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new AppDbContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    
                    if (user.Type == "Manager")
                        new ManagerWindow().Show();
                    else if (user.Type == "Technician")
                        new TechnicianWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login or password");
                }
            }
        }
    }
}
