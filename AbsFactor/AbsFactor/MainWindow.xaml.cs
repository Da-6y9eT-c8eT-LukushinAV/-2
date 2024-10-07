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

namespace AbsFactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IShapeFactory _currentFactory;  // Текущая фабрика для цвета
        private string _currentShape;           // Текущий тип фигуры

        public MainWindow()
        {
            InitializeComponent();
            _currentFactory = new RedFactory();  // Устанавливаем начальную фабрику
            _currentShape = "Circle";            // Устанавливаем начальный тип фигуры
            DrawShape();
        }

        // Обработчик смены фабрики (цвета)
        private void FactoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FactoryComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Red Factory":
                        _currentFactory = new RedFactory();
                        break;
                    case "Blue Factory":
                        _currentFactory = new BlueFactory();
                        break;
                }

                DrawShape();  // Перерисовываем фигуру при изменении цвета
            }
        }

        // Обработчик смены типа фигуры
        private void ShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShapeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                _currentShape = selectedItem.Content.ToString();  // Устанавливаем текущий тип фигуры
                DrawShape();  // Перерисовываем фигуру при изменении типа
            }
        }

        // Метод для отрисовки выбранной фигуры
        private void DrawShape()
        {
            ShapesCanvas.Children.Clear();  // Очищаем Canvas перед новой отрисовкой

            IShape shape = _currentShape switch
            {
                "Circle" => _currentFactory.CreateCircle(),
                "Square" => _currentFactory.CreateSquare(),
                "Triangle" => _currentFactory.CreateTriangle(),
                _ => _currentFactory.CreateCircle()
            };

            shape.Draw(ShapesCanvas);  // Рисуем выбранную фигуру
        }
    }

}