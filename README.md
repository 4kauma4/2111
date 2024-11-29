<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Редактирование данных" Height="300" Width="400">
    <Grid>
        <DataGrid x:Name="dataGrid" AutoGenerateColumns="True" 
                  SelectionChanged="DataGrid_SelectionChanged"/>
        <StackPanel Orientation="Horizontal" VerticalAlignment="Bottom">
            <TextBox x:Name="textBoxEdit" Width="200" Margin="5"/>
            <Button x:Name="buttonSave" Content="Сохранить" Click="ButtonSave_Click" Margin="5"/>
        </StackPanel>
    </Grid>
</Window>

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private DataTable dataTable;
        private string connectionString = "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;";
        
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM your_table";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();

                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is DataRowView selectedRow)
            {
                textBoxEdit.Text = selectedRow[0].ToString(); // Измените индекс колонки по мере необходимости
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is DataRowView selectedRow)
            {
                selectedRow[0] = textBoxEdit.Text; // Измените индекс колонки по мере необходимости
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            string updateQuery = "UPDATE your_table SET your_column = @value WHERE your_condition"; // Укажите нужные значения

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@value", textBoxEdit.Text);
                    // Добавьте параметры для условия обновления

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Изменения сохранены!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                    }
                }
            }
        }
    }
}
