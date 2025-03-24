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

namespace FitPro
{
    /// <summary>
    /// Логика взаимодействия для InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private InventoryItem _item;
        public List<string> Types { get; } = new List<string> { "Гантели", "Тренажеры", "Мячи", "Другое" };
        public List<string> Statuses { get; } = new List<string> { "В наличии", "Выдан", "На обслуживании" };
        public List<string> Users { get; } = new List<string> { "Иванов И.И.", "Петров П.П.", "Сидоров С.С." };

        public InventoryWindow(InventoryItem item = null)
        {
            InitializeComponent();
            _item = item ?? new InventoryItem();
            if (item != null)
            {
                ArticleTextBox.Text = item.Article;
                NameTextBox.Text = item.Name;
                TypeComboBox.SelectedItem = item.Type;
                DescriptionTextBox.Text = item.Description;
                IssueDatePicker.SelectedDate = item.IssueDate;
                ReturnDatePicker.SelectedDate = item.ReturnDate;
                StatusComboBox.SelectedItem = item.Status;
                UserComboBox.SelectedItem = item.User;
            }
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _item.Article = ArticleTextBox.Text;
            _item.Name = NameTextBox.Text;
            _item.Type = TypeComboBox.SelectedItem as string;
            _item.Description = DescriptionTextBox.Text;
            _item.IssueDate = IssueDatePicker.SelectedDate ?? DateTime.Now;
            _item.ReturnDate = ReturnDatePicker.SelectedDate ?? DateTime.Now;
            _item.Status = StatusComboBox.SelectedItem as string;
            _item.User = UserComboBox.SelectedItem as string;

            if (_item.Status == "Выдан")
            {
                MessageBox.Show($"Инвентарь {_item.Name} выдан пользователю {_item.User}.",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }

        public InventoryItem GetInventoryItem()
        {
            return _item;
        }
    }
}
