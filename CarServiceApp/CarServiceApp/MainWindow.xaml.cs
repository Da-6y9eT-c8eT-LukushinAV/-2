using ContextLibrary;
using ContextLibrary.Entities;
using System.Linq;
using System.Windows;
using CarServiceApp;

namespace CarServiceApp
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationContext(); // создаем экземпляр контекста
            LoadRequests();
        }

        // Загружаем заявки в DataGrid
        private void LoadRequests()
        {
            RequestsDataGrid.ItemsSource = _context.Requests; // используем экземпляр _context
        }

        // Открытие окна добавления заявки
        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var requestWindow = new RequestWindow();
            requestWindow.ShowDialog(); // Показываем окно добавления заявки
            LoadRequests(); // Перезагружаем список заявок
        }

        // Открытие окна редактирования заявки
        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem is Request selectedRequest)
            {
                var requestWindow = new RequestWindow(selectedRequest); // Передаем выбранную заявку
                requestWindow.ShowDialog();
                LoadRequests(); // Перезагружаем список заявок
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования.");
            }
        }


    }
}
