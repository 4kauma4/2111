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
using Exam.Model;


namespace Exam
{
    /// <summary>
    /// Interaction logic for AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        public AddRequestWindow()
        {
            InitializeComponent();
        }

        private void SaveRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var newRequest = new Request
                    {
                        StartDate = DateTime.Now,
                        OrgTechModel = ModelTextBox.Text,
                        ProblemDescription = ProblemTextBox.Text,
                        RequestStatus = "Новая"
                    };

                    context.Requests.Add(newRequest);
                    context.SaveChanges();
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
