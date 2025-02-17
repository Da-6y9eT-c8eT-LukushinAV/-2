using CarServiceApp.ContextLibrary.Enums;
using ContextLibrary;
using ContextLibrary.Entities;
using ContextLibrary.Enums;
using ContextLibrary.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CarServiceApp
{
    public partial class RequestWindow : Window
    {
        private bool isEditMode = false;  // Переменная для проверки режима
        private ApplicationContext _context;  // Контекст
        private Request _request;  // Переменная для заявки

        // Конструктор по умолчанию для создания новой заявки
        public RequestWindow(ApplicationContext context)
        {
            InitializeComponent();
            _context = context ?? throw new ArgumentNullException(nameof(context));  // Проверка контекста на null

            // Инициализация элементов UI
            DeviceTypeComboBox.ItemsSource = Enum.GetValues(typeof(DeviceType));
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(RequestStatus));
            StageComboBox.ItemsSource = Enum.GetValues(typeof(RequestStage));

            // Инициализация списка механиков
            MechanicComboBox.ItemsSource = _context.Mechanics;

            // Дополнительная инициализация
        }

        // Конструктор для редактирования заявки
        public RequestWindow(ApplicationContext context, Request existingRequest) : this(context)
        {
            isEditMode = true;
            _request = existingRequest ?? throw new ArgumentNullException(nameof(existingRequest));  // Проверка на null

            // Заполнение полей для редактирования
            NumberTextBox.Text = existingRequest.Number.ToString();
            AddedDatePicker.SelectedDate = existingRequest.AddedDate;
            DeviceTypeComboBox.SelectedItem = existingRequest.DeviceType;
            DeviceModelTextBox.Text = existingRequest.DeviceModel;
            ProblemDescriptionTextBox.Text = existingRequest.ProblemDescription;
            ClientLFPTextBox.Text = existingRequest.ClientLFP;
            PhoneNumberTextBox.Text = existingRequest.PhoneNumber;
            StatusComboBox.SelectedItem = existingRequest.Status;
            MechanicComboBox.SelectedItem = existingRequest.ResponsibleMechanic;
            StageComboBox.SelectedItem = existingRequest.Stage;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем данные с формы
                var number = isEditMode ? int.Parse(NumberTextBox.Text) : _context.GenerateRequestNumber();
                var addedDate = AddedDatePicker.SelectedDate ?? DateTime.Now;
                var deviceType = (DeviceType)DeviceTypeComboBox.SelectedItem;
                var deviceModel = DeviceModelTextBox.Text;
                var problemDescription = ProblemDescriptionTextBox.Text;
                var clientLFP = ClientLFPTextBox.Text;
                var phoneNumber = PhoneNumberTextBox.Text;
                var status = (RequestStatus)StatusComboBox.SelectedItem;
                var mechanic = (Mechanic)MechanicComboBox.SelectedItem ?? new Mechanic { LFP = "Не назначен" };  // Создаем механика с заполненным полем LFP
                var stage = (RequestStage)StageComboBox.SelectedItem;

                // Создаем или редактируем заявку
                var request = new Request
                {
                    Number = number,
                    AddedDate = addedDate,
                    DeviceType = deviceType,
                    DeviceModel = deviceModel,
                    ProblemDescription = problemDescription,
                    ClientLFP = clientLFP,
                    PhoneNumber = phoneNumber,
                    Status = status,
                    ResponsibleMechanic = mechanic,
                    Stage = stage
                };

                if (isEditMode)
                {
                    // Редактирование существующей заявки
                    var existingRequest = _context.Requests.FirstOrDefault(r => r.Number == request.Number);
                    if (existingRequest != null)
                    {
                        // Обновляем существующую заявку
                        _context.Requests.Remove(existingRequest);
                        _context.Requests.Add(request);
                    }
                }
                else
                {
                    // Добавление новой заявки
                    _context.Requests.Add(request);
                }

                // Закрытие окна
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }





}
