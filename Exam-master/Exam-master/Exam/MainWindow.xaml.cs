using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var addRequestWindow = new AddRequestWindow();
            addRequestWindow.ShowDialog();
            LoadRequests(); 
        }
        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            var statisticsWindow = new StatisticsWindow();
            statisticsWindow.ShowDialog();
        }
        private void LoadRequests()
        {
            using (var context = new AppDbContext())
            {
                var requests = context.Requests.ToList();
                RequestsDataGrid.ItemsSource = requests;
            }
        }
    }
}