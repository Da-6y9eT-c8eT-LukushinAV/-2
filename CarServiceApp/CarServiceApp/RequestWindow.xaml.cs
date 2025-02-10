using ContextLibrary;
using ContextLibrary.Entities;
using ContextLibrary.Enums;
using System;
using System.Windows;

namespace CarServiceApp
{
    public partial class RequestWindow : Window
    {
        private Request? _currentRequest;
        private readonly ApplicationContext _context;

        public RequestWindow(Request? request = null)
        {
            InitializeComponent();
            _context = new ApplicationContext(); // создаем экземпляр контекста

            _currentRequest = request;

            if (_currentRequest != null)
            {
                // Заполняем поля для редактирования
                NumberTextBox.Text = _currentRequest.Number.ToString();
                AddedDateTextBox.Text = _currentRequest.AddedDate.ToString("dd.MM.yyyy");
                CarTypeComboBox.SelectedItem = CarTypeComboBox.Items[_currentRequest.CarType.GetHashCode()];
                CarModelTextBox.Text = _currentRequest.CarModel;
                DescriptionTextBox.Text = _currentRequest.Description;
                ClientLFPTextBox.Text = _currentRequest.ClientLFP;
                PhoneNumberTextBox.Text = _currentRequest.PhoneNumber;
                StatusComboBox.SelectedItem = StatusComboBox.Items[_currentRequest.Status.GetHashCode()];
            }
            else
            {
                // Для нового запроса генерируем номер
                NumberTextBox.Text = _context.GenerateRequestNumber().ToString();
                AddedDateTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentRequest == null)
            {
                // Создаём новую заявку
                var newRequest = new Request
                {
                    Number = int.Parse(NumberTextBox.Text),
                    AddedDate = DateTime.Parse(AddedDateTextBox.Text),
                    CarType = (CarType)CarTypeComboBox.SelectedIndex,
                    CarModel = CarModelTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    ClientLFP = ClientLFPTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Status = (RequestStatus)StatusComboBox.SelectedIndex
                };

                _context.Requests.Add(newRequest); // используем экземпляр _context
            }
            else
            {
                // Редактируем существующую заявку
                _currentRequest.CarType = (CarType)CarTypeComboBox.SelectedIndex;
                _currentRequest.CarModel = CarModelTextBox.Text;
                _currentRequest.Description = DescriptionTextBox.Text;
                _currentRequest.ClientLFP = ClientLFPTextBox.Text;
                _currentRequest.PhoneNumber = PhoneNumberTextBox.Text;
                _currentRequest.Status = (RequestStatus)StatusComboBox.SelectedIndex;
            }

            MessageBox.Show("Заявка сохранена!");
            Close();
        }
    }

}
