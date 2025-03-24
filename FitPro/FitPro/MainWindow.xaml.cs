using System.Collections.ObjectModel;
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

namespace FitPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<InventoryItem> inventoryItems = new ObservableCollection<InventoryItem>();

        public MainWindow()
        {
            InitializeComponent();
            InventoryDataGrid.ItemsSource = inventoryItems;
            FilterComboBox.ItemsSource = new string[] { "Все", "В наличии", "Выдан", "На обслуживании" };
            FilterComboBox.SelectedIndex = 0;
        }

        private void AddInventory_Click(object sender, RoutedEventArgs e)
        {
            var inventoryWindow = new InventoryWindow();
            if (inventoryWindow.ShowDialog() == true)
            {
                inventoryItems.Add(inventoryWindow.GetInventoryItem());
            }
        }

        private void EditInventory_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem is InventoryItem selectedItem)
            {
                var inventoryWindow = new InventoryWindow(selectedItem);
                inventoryWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteInventory_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem is InventoryItem selectedItem)
            {
                inventoryItems.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            InventoryDataGrid.ItemsSource = inventoryItems.Where(item =>
                item.Name.ToLower().Contains(searchText) ||
                item.Type.ToLower().Contains(searchText)).ToList();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFilter = FilterComboBox.SelectedItem as string;
            if (selectedFilter == "Все")
            {
                InventoryDataGrid.ItemsSource = inventoryItems;
            }
            else
            {
                InventoryDataGrid.ItemsSource = inventoryItems.Where(item => item.Status == selectedFilter).ToList();
            }
        }
    }
}