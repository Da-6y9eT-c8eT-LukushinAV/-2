using System;

// Абстрактный класс - Шаблонный метод
abstract class ReportGenerator
{
    // Шаблонный метод
    public void GenerateReport()
    {
        CollectData();
        ProcessData();
        FormatReport();
        ExportReport();
    }

    // Абстрактные методы, которые реализуют подклассы
    protected abstract void CollectData();
    protected abstract void ProcessData();
    protected abstract void FormatReport();
    protected abstract void ExportReport();
}

// Конкретный класс для отчета по студентам
class StudentReportGenerator : ReportGenerator
{
    protected override void CollectData()
    {
        Console.WriteLine("Шаг 1: Сбор данных о студентах...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Шаг 2: Обработка данных о студентах...");
    }

    protected override void FormatReport()
    {
        Console.WriteLine("Шаг 3: Форматирование отчета по студентам...");
    }

    protected override void ExportReport()
    {
        Console.WriteLine("Шаг 4: Экспорт отчета по студентам в файл.");
    }
}

// Конкретный класс для отчета по курсам
class CourseReportGenerator : ReportGenerator
{
    protected override void CollectData()
    {
        Console.WriteLine("Шаг 1: Сбор данных о курсах...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Шаг 2: Обработка данных о курсах...");
    }

    protected override void FormatReport()
    {
        Console.WriteLine("Шаг 3: Форматирование отчета по курсам...");
    }

    protected override void ExportReport()
    {
        Console.WriteLine("Шаг 4: Экспорт отчета по курсам в файл.");
    }
}

// Тестирование системы отчетности
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Генерация отчета по студентам:");
        ReportGenerator studentReport = new StudentReportGenerator();
        studentReport.GenerateReport();

        Console.WriteLine("\nГенерация отчета по курсам:");
        ReportGenerator courseReport = new CourseReportGenerator();
        courseReport.GenerateReport();
    }
}
