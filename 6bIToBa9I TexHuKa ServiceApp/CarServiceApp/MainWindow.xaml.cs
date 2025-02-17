using CarServiceApp.ContextLibrary.Enums;
using ContextLibrary;
using ContextLibrary.Entities;
using ContextLibrary.Enums;
using ContextLibrary.Extensions;
using System.Linq;
using System.Windows;

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

            // Очистка текущих элементов перед установкой нового источника данных
            DeviceTypeSearch.Items.Clear();
            DeviceTypeSearch.ItemsSource = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();

            StatusSearch.Items.Clear();
            StatusSearch.ItemsSource = Enum.GetValues(typeof(RequestStatus)).Cast<RequestStatus>();


            //// Привязываем перечисление RequestStatus к ComboBox с описанием
            //StatusSearch.ItemsSource = Enum.GetValues(typeof(RequestStatus))
            //                                .Cast<RequestStatus>()
            //                                .Select(status => new
            //                                {
            //                                    Value = status,
            //                                    Description = status.GetDescription()
            //                                })
            //                                .ToList();

            // Отображаем только описание в ComboBox
            //StatusSearch.DisplayMemberPath = "Description";
            StatusSearch.SelectedValuePath = "Value";
        }

        // Загружаем заявки в DataGrid
        private void LoadRequests()
        {
            RequestsDataGrid.ItemsSource = _context.Requests.ToList(); // Загружаем все заявки без фильтрации
        }

        // Открытие окна добавления заявки
        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var requestWindow = new RequestWindow(_context);
            requestWindow.ShowDialog(); // Показываем окно добавления заявки
            LoadRequests(); // Перезагружаем список заявок
        }

        // Пример вызова для редактирования заявки
        private void EditRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = _context.Requests.FirstOrDefault(r => r.Number == 1);  // Пример поиска заявки
            if (selectedRequest != null)
            {
                var requestWindow = new RequestWindow(_context, selectedRequest);  // Передаем выбранную заявку для редактирования
                requestWindow.Show();
            }
        }

        private void ResetFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем текстовые поля поиска
            RequestNumberSearch.Clear();

            // Сбрасываем выбранные значения в ComboBox
            DeviceTypeSearch.SelectedItem = null;
            StatusSearch.SelectedItem = null;

            // Загружаем все заявки без фильтрации
            LoadRequests();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Requests.AsQueryable();

            // Фильтрация по номеру заявки, если введен текст
            if (!string.IsNullOrEmpty(RequestNumberSearch.Text))
            {
                query = query.Where(r => r.Number.ToString().Contains(RequestNumberSearch.Text));
            }

            // Фильтрация по выбранному типу устройства, если выбран элемент
            if (DeviceTypeSearch.SelectedItem != null)
            {
                if (DeviceTypeSearch.SelectedItem is DeviceType selectedDeviceType)
                {
                    query = query.Where(r => r.DeviceType == selectedDeviceType);
                }
            }

            // Фильтрация по выбранному статусу заявки, если выбран элемент
            if (StatusSearch.SelectedItem != null)
            {
                // Проверяем, является ли выбранный элемент правильным типом
                if (StatusSearch.SelectedItem is RequestStatus selectedStatus)
                {
                    query = query.Where(r => r.Status == selectedStatus);
                }
            }

            // Применяем фильтрацию и отображаем результаты
            RequestsDataGrid.ItemsSource = query.ToList();
        }






    }
}
