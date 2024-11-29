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
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            LoadStatistics();
        }
        private void LoadStatistics()
        {
            using (var context = new AppDbContext())
            {
                // Получаем количество завершенных заявок
                var completedRequests = context.Requests.Where(r => r.RequestStatus == "Завершена").ToList();
                int totalCompletedRequests = completedRequests.Count;

                // Вычисляем среднее время выполнения заявок
                double averageTime = completedRequests.Average(r => r.CompletionDate.HasValue
                    ? (r.CompletionDate.Value - r.StartDate).TotalDays : 0);

                // Отображаем статистику на экране
                TotalRequestsTextBlock.Text = $"Завершенные заявки: {totalCompletedRequests}";
                AverageTimeTextBlock.Text = $"Среднее время выполнения: {averageTime:F2} дней";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрытие окна
        }
    }
}
