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

        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем окно для добавления новой заявки, передаем только контекст
            var requestWindow = new RequestWindow(_context);
            requestWindow.ShowDialog(); // Показываем окно добавления заявки

            // Перезагружаем список заявок после закрытия окна
            LoadRequests();
        }


        // Пример вызова для редактирования
        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = _context.Requests.FirstOrDefault(r => r.Number == 1);  // Пример поиска заявки
            if (selectedRequest != null)
            {
                var requestWindow = new RequestWindow(_context, selectedRequest);  // Передаем выбранную заявку для редактирования
                requestWindow.Show();
            }
        }


    }
}
